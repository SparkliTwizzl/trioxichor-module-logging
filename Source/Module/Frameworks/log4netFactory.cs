using log4net;
using log4net.Appender;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;

namespace SparkliTwizzl.Trioxichor.Logging.Frameworks;

public class log4netFactory : ILoggingFrameworkFactory
{
    private void Configure( LogConfiguration config )
    {
        if ( config is null )
        {
            throw new ArgumentNullException( nameof( config ), $"{nameof( config )} cannot be null." );
        }
        config.Layout = ConvertLayoutToLog4netPattern( config.Layout );
        var hierarchy = ( Hierarchy ) LogManager.GetRepository();
        var patternLayout = new PatternLayout();
        patternLayout.ConversionPattern = config.Layout;
        patternLayout.ActivateOptions();
        foreach ( var target in config.Targets )
        {
            var appender = CreateLog4netTarget( target, config );
            hierarchy.Root.AddAppender( appender );
        }
        hierarchy.Root.Level = ConvertLogLevelToLog4net( config.MinimumLevel );
        hierarchy.Configured = true;
    }

    private ColoredConsoleAppender.Colors ConvertConsoleColorToLog4netColor( ConsoleColor color ) => color switch
    {
        ConsoleColor.Black => 0,
        ConsoleColor.Blue => ColoredConsoleAppender.Colors.Blue | ColoredConsoleAppender.Colors.HighIntensity,
        ConsoleColor.Cyan => ColoredConsoleAppender.Colors.Cyan | ColoredConsoleAppender.Colors.HighIntensity,
        ConsoleColor.DarkBlue => ColoredConsoleAppender.Colors.Blue,
        ConsoleColor.DarkCyan => ColoredConsoleAppender.Colors.Cyan,
        ConsoleColor.DarkGray => ColoredConsoleAppender.Colors.White,
        ConsoleColor.DarkGreen => ColoredConsoleAppender.Colors.Green,
        ConsoleColor.DarkMagenta => ColoredConsoleAppender.Colors.Purple,
        ConsoleColor.DarkRed => ColoredConsoleAppender.Colors.Red,
        ConsoleColor.DarkYellow => ColoredConsoleAppender.Colors.Yellow,
        ConsoleColor.Gray => ColoredConsoleAppender.Colors.White,
        ConsoleColor.Green => ColoredConsoleAppender.Colors.Green | ColoredConsoleAppender.Colors.HighIntensity,
        ConsoleColor.Magenta => ColoredConsoleAppender.Colors.Purple | ColoredConsoleAppender.Colors.HighIntensity,
        ConsoleColor.Red => ColoredConsoleAppender.Colors.Red | ColoredConsoleAppender.Colors.HighIntensity,
        ConsoleColor.White => ColoredConsoleAppender.Colors.White | ColoredConsoleAppender.Colors.HighIntensity,
        ConsoleColor.Yellow => ColoredConsoleAppender.Colors.Yellow | ColoredConsoleAppender.Colors.HighIntensity,
        _ => throw new ArgumentOutOfRangeException( nameof( color ), $"Unsupported {nameof( ConsoleColor )}: {color}" )
    };

    private string ConvertLayoutToLog4netPattern( string layout )
    {
        if ( string.IsNullOrWhiteSpace( layout ) )
        {
            throw new ArgumentException( $"Layout cannot be null or empty.", nameof( layout ) );
        }
        var log4netPattern = layout
            .Replace( "}", "" )
            .Replace( "${", "%" )
            + "%newline";
        return log4netPattern;
    }

    private log4net.Core.Level ConvertLogLevelToLog4net( LogLevel level ) => level switch
    {
        LogLevel.Trace => log4net.Core.Level.Trace,
        LogLevel.Debug => log4net.Core.Level.Debug,
        LogLevel.Info => log4net.Core.Level.Info,
        LogLevel.Warning => log4net.Core.Level.Warn,
        LogLevel.Error => log4net.Core.Level.Error,
        LogLevel.Fatal => log4net.Core.Level.Fatal,
        LogLevel.None => log4net.Core.Level.Off,
        _ => throw new ArgumentOutOfRangeException( nameof( level ), $"Unsupported {nameof( LogLevel )}: {level}" )
    };

    private IAppender CreateLog4netColorlessConsoleTarget( string layout )
    {
        var appender = new ConsoleAppender
        {
            Layout = new PatternLayout( layout ),
        };
        appender.ActivateOptions();
        return appender;
    }

    private IAppender CreateLog4netColoredConsoleTarget( string layout, Dictionary<LogLevel, ConsoleColor> colorMap )
    {
        if ( colorMap is null || colorMap.Count == 0 )
        {
            throw new ArgumentNullException( nameof( colorMap ), $"{nameof( colorMap )} cannot be null or empty when creating a colored console target." );
        }
        var appender = new ColoredConsoleAppender
        {
            Layout = new PatternLayout( layout ),
        };
        foreach ( var mapping in colorMap )
        {
            var log4netLevel = ConvertLogLevelToLog4net( mapping.Key );
            appender.AddMapping( new ColoredConsoleAppender.LevelColors
            {
                Level = log4netLevel,
                ForeColor = ConvertConsoleColorToLog4netColor( mapping.Value ),
            } );
        }
        appender.ActivateOptions();
        return appender;
    }

    private IAppender CreateLog4netJsonTarget( string filePath, string layout )
    {
        if ( string.IsNullOrWhiteSpace( filePath ) )
        {
            throw new ArgumentException( $"File path cannot be null or empty.", nameof( filePath ) );
        }
        var appender = new FileAppender
        {
            File = filePath,
            Layout = new PatternLayout( layout ),
        };
        appender.ActivateOptions();
        return appender;
    }

    private IAppender CreateLog4netTarget( LogTarget target, LogConfiguration config ) => target.Type switch
    {
        LogTargetType.ColorlessConsole => CreateLog4netColorlessConsoleTarget( config.Layout ),
        LogTargetType.ColoredConsole => CreateLog4netColoredConsoleTarget( config.Layout, config.ConsoleColorMap ),
        LogTargetType.Json => CreateLog4netJsonTarget( target.FilePath, config.JsonLayout ),
        _ => throw new NotSupportedException( $"Unsupported {nameof( LogTargetType )}: {target.Type}" )
    };


    public LogConfiguration Configuration { get; private set; } = new LogConfiguration();

    /// <summary>Creates a new factory instance using default configuration.</summary>
    /// <remarks>
    /// <para>The framework specified by the configuration is ignored, because it is not relevant at this level.</para>
    /// </remarks>
    public log4netFactory() => Configure( new LogConfiguration() );

    /// <summary>Creates a new factory instance using the provided configuration.</summary>
    /// <remarks>
    /// <para>The framework specified by the configuration is ignored, because it is not relevant at this level.</para>
    /// </remarks>
    /// <param name="config">Configuration to apply.</param>
    public log4netFactory( LogConfiguration config ) => Configure( config );

    public ILogger CreateLogger( string categoryName ) => new log4netLogger( LogManager.GetLogger( categoryName ) );
}
