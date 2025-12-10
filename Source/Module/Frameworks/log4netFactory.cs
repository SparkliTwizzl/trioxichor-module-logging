using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Layout;
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
        var log4netMinimumLevel = ConvertLogLevelToLog4net( config.MinimumLevel );
        var log4netConfig = new log4net.Repository.Hierarchy.Hierarchy();
        foreach ( var target in config.Targets )
        {
            var appender = CreateLog4netTarget( target, config );
            log4netConfig.Root.AddAppender( appender );
        }
        log4netConfig.Root.Level = log4netMinimumLevel;
        log4netConfig.Configured = true;
        _ = BasicConfigurator.Configure( log4netConfig );
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
        return appender;
    }

    private IAppender CreateLog4netColoredConsoleTarget( string layout, Dictionary<LogLevel, ConsoleColor> colorMap )
    {
        if ( colorMap is null )
        {
            throw new ArgumentNullException( nameof( colorMap ), $"{nameof( colorMap )} cannot be null when creating a colored console target." );
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
        return appender;
    }

    private IAppender CreateLog4netJsonTarget( string filePath, string layout ) => new FileAppender
    {
        File = filePath,
        Layout = new PatternLayout( layout ),
    };

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
