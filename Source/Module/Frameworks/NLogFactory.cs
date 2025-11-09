using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;

namespace SparkliTwizzl.Trioxichor.Logging.Frameworks;

public class NLogFactory : ILoggingFrameworkFactory
{
    private NLog.LogLevel ConvertLogLevelToNLog( LogLevel level ) => level switch
    {
        LogLevel.Trace => NLog.LogLevel.Trace,
        LogLevel.Debug => NLog.LogLevel.Debug,
        LogLevel.Info => NLog.LogLevel.Info,
        LogLevel.Warning => NLog.LogLevel.Warn,
        LogLevel.Error => NLog.LogLevel.Error,
        LogLevel.Fatal => NLog.LogLevel.Fatal,
        LogLevel.None => NLog.LogLevel.Off,
        _ => throw new ArgumentOutOfRangeException( nameof( level ), $"Unsupported {nameof( LogLevel )}: {level}" )
    };

    private ConsoleTarget CreateNLogColorlessConsoleTarget( string layout )
    {
        var target = new ConsoleTarget( "console" );
        target.Layout = layout;
        return target;
    }

    private ColoredConsoleTarget CreateNLogColoredConsoleTarget( string layout, Dictionary<LogLevel, ConsoleColor> colorMap )
    {
        if ( colorMap == null )
        {
            throw new ArgumentNullException( nameof( colorMap ), $"{nameof( colorMap )} cannot be null when creating a colored console target." );
        }
        var target = new ColoredConsoleTarget( "coloredConsole" );
        target.Layout = layout;
        foreach ( var mapping in colorMap )
        {
            var nlogLevel = mapping.Key switch
            {
                LogLevel.Trace => NLog.LogLevel.Trace,
                LogLevel.Debug => NLog.LogLevel.Debug,
                LogLevel.Info => NLog.LogLevel.Info,
                LogLevel.Warning => NLog.LogLevel.Warn,
                LogLevel.Error => NLog.LogLevel.Error,
                LogLevel.Fatal => NLog.LogLevel.Fatal,
                _ => throw new ArgumentOutOfRangeException( nameof( mapping.Key ), $"Unsupported {nameof( LogLevel )}: {mapping.Key}" )
            };
            target.RowHighlightingRules.Add( new ConsoleRowHighlightingRule
            {
                Condition = $"level == '{nlogLevel.Name}'",
                ForegroundColor = ( ConsoleOutputColor ) mapping.Value
            } );
        }
        return target;
    }

    private FileTarget CreateNLogJsonTarget( string filePath ) => new FileTarget( "jsonFile" )
    {
        FileName = filePath,
        Layout = "${json:time=${longdate},level=${level:uppercase=true},message=${message}}",
    };

    private Target CreateNLogTarget( LogTarget target, LogConfiguration config ) => target.Type switch
    {
        LogTargetType.ColorlessConsole => CreateNLogColorlessConsoleTarget( config.Layout ),
        LogTargetType.ColoredConsole => CreateNLogColoredConsoleTarget( config.Layout, config.ConsoleColorMap ),
        LogTargetType.Json => CreateNLogJsonTarget( target.FilePath ),
        _ => throw new NotSupportedException( $"Unsupported {nameof( LogTargetType )}: {target.Type}" )
    };

    private void Configure( LogConfiguration config )
    {
        var nlogMinimumLevel = ConvertLogLevelToNLog( config.MinimumLevel );
        var nlogConfig = new LoggingConfiguration();
        foreach ( var target in config.Targets )
        {
            Target nlogTarget = CreateNLogTarget( target, config );
            nlogConfig.AddRule( nlogMinimumLevel, NLog.LogLevel.Fatal, nlogTarget );
        }
        LogManager.Configuration = nlogConfig;
    }


    public LogConfiguration Configuration { get; private set; } = new LogConfiguration();

    /// <summary>Creates a new factory instance using default configuration.</summary>
    /// <remarks>
    /// <para>The framework specified by the configuration is ignored, because it is not relevant at this level.</para>
    /// </remarks>
    public NLogFactory() => Configure( new LogConfiguration() );

    /// <summary>Creates a new factory instance using the provided configuration.</summary>
    /// <remarks>
    /// <para>The framework specified by the configuration is ignored, because it is not relevant at this level.</para>
    /// </remarks>
    /// <param name="config">Configuration to apply.</param>
    public NLogFactory( LogConfiguration config ) => Configure( config );

    public ILogger CreateLogger( string categoryName ) => new NLogLogger( LogManager.GetLogger( categoryName ) );
}
