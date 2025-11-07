using NLog;
using NLog.Config;
using NLog.Targets;

namespace SparkliTwizzl.Trioxichor.Logging.Frameworks;

class NLogLogger : ILoggingFramework
{
    NLog.LogLevel ConvertLogLevelToNLog( LogLevel level ) => level switch
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

    Target CreateConsoleTarget( LogConfiguration config )
    {
        if ( config.UsePerLevelColors && config.ConsoleColorMap != null )
        {
            return CreateColoredConsoleTarget( config.ConsoleColorMap );
        }
        return CreateMonochromeConsoleTarget();
    }

    ColoredConsoleTarget CreateColoredConsoleTarget( Dictionary<LogLevel, ConsoleColor> colorMap )
    {
        var target = new ColoredConsoleTarget( "coloredConsole" );
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
                _ => throw new ArgumentOutOfRangeException( nameof( mapping.Key ), $"Unsupported LogLevel: {mapping.Key}" )
            };
            target.RowHighlightingRules.Add( new ConsoleRowHighlightingRule
            {
                Condition = $"level == '{nlogLevel.Name}'",
                ForegroundColor = ( ConsoleOutputColor ) mapping.Value
            } );
        }
        return target;
    }

    FileTarget CreateJsonTarget( string filePath ) => new FileTarget( "jsonFile" )
    {
        FileName = filePath,
        Layout = "${json:time=${longdate},level=${level:uppercase=true},message=${message}}",
    };

    ConsoleTarget CreateMonochromeConsoleTarget() => new ConsoleTarget( "console" );

    public void Configure( LogConfiguration config )
    {
        var nlogConfig = new LoggingConfiguration();
        var nlogMinimumLevel = ConvertLogLevelToNLog( config.MinimumLevel );
        foreach ( var target in config.Targets )
        {
            Target nlogTarget;
            switch ( target.Type )
            {
                case LogTargetType.Console:
                    nlogTarget = CreateConsoleTarget( config );
                    break;
                case LogTargetType.Json:
                    nlogTarget = CreateJsonTarget( target.FilePath );
                    break;
                default:
                    throw new NotSupportedException( $"Unsupported {nameof( LogTargetType )}: {target.Type}" );
            }
            nlogConfig.AddRule( nlogMinimumLevel, NLog.LogLevel.Fatal, nlogTarget );
        }
        LogManager.Configuration = nlogConfig;
    }

    public void LogDebug( object message ) => throw new NotImplementedException();
    public void LogDebug( object message, params object[] args ) => throw new NotImplementedException();
    public void LogDebug( Exception exception, object message ) => throw new NotImplementedException();
    public void LogDebug( Exception exception, object message, params object[] args ) => throw new NotImplementedException();
    public void LogDebug( Func<string> messageFactory ) => throw new NotImplementedException();
    public void LogError( object message ) => throw new NotImplementedException();
    public void LogError( object message, params object[] args ) => throw new NotImplementedException();
    public void LogError( Exception exception, object message ) => throw new NotImplementedException();
    public void LogError( Exception exception, object message, params object[] args ) => throw new NotImplementedException();
    public void LogError( Func<string> messageFactory ) => throw new NotImplementedException();
    public void LogFatal( object message ) => throw new NotImplementedException();
    public void LogFatal( object message, params object[] args ) => throw new NotImplementedException();
    public void LogFatal( Exception exception, object message ) => throw new NotImplementedException();
    public void LogFatal( Exception exception, object message, params object[] args ) => throw new NotImplementedException();
    public void LogFatal( Func<string> messageFactory ) => throw new NotImplementedException();
    public void LogInfo( object message ) => throw new NotImplementedException();
    public void LogInfo( object message, params object[] args ) => throw new NotImplementedException();
    public void LogInfo( Exception exception, object message ) => throw new NotImplementedException();
    public void LogInfo( Exception exception, object message, params object[] args ) => throw new NotImplementedException();
    public void LogInfo( Func<string> messageFactory ) => throw new NotImplementedException();
    public void LogTrace( object message ) => throw new NotImplementedException();
    public void LogTrace( object message, params object[] args ) => throw new NotImplementedException();
    public void LogTrace( Exception exception, object message ) => throw new NotImplementedException();
    public void LogTrace( Exception exception, object message, params object[] args ) => throw new NotImplementedException();
    public void LogTrace( Func<string> messageFactory ) => throw new NotImplementedException();
    public void LogWarning( object message ) => throw new NotImplementedException();
    public void LogWarning( object message, params object[] args ) => throw new NotImplementedException();
    public void LogWarning( Exception exception, object message ) => throw new NotImplementedException();
    public void LogWarning( Exception exception, object message, params object[] args ) => throw new NotImplementedException();
    public void LogWarning( Func<string> messageFactory ) => throw new NotImplementedException();
}
