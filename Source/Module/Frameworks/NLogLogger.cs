namespace SparkliTwizzl.Trioxichor.Logging.Frameworks;

public class NLogLogger : ILogger
{
    NLog.Logger Logger { get; set; }

    public NLogLogger( NLog.Logger logger ) => Logger = logger;

    public void LogDebug( string message ) => Logger.Debug( message );
    public void LogDebug( string message, params object[] args ) => Logger.Debug( message, args );
    public void LogDebug( Exception exception, string message ) => Logger.Debug( exception, message );
    public void LogDebug( Exception exception, string message, params object[] args ) => Logger.Debug( exception, message, args );
    public void LogDebug( Func<string> messageFactory ) => Logger.Debug( messageFactory );
    public void LogError( string message ) => Logger.Error( message );
    public void LogError( string message, params object[] args ) => Logger.Error( message, args );
    public void LogError( Exception exception, string message ) => Logger.Error( exception, message );
    public void LogError( Exception exception, string message, params object[] args ) => Logger.Error( exception, message, args );
    public void LogError( Func<string> messageFactory ) => Logger.Error( messageFactory );
    public void LogFatal( string message ) => Logger.Fatal( message );
    public void LogFatal( string message, params object[] args ) => Logger.Fatal( message, args );
    public void LogFatal( Exception exception, string message ) => Logger.Fatal( exception, message );
    public void LogFatal( Exception exception, string message, params object[] args ) => Logger.Fatal( exception, message, args );
    public void LogFatal( Func<string> messageFactory ) => Logger.Fatal( messageFactory );
    public void LogInfo( string message ) => Logger.Info( message );
    public void LogInfo( string message, params object[] args ) => Logger.Info( message, args );
    public void LogInfo( Exception exception, string message ) => Logger.Info( exception, message );
    public void LogInfo( Exception exception, string message, params object[] args ) => Logger.Info( exception, message, args );
    public void LogInfo( Func<string> messageFactory ) => Logger.Info( messageFactory );
    public void LogTrace( string message ) => Logger.Trace( message );
    public void LogTrace( string message, params object[] args ) => Logger.Trace( message, args );
    public void LogTrace( Exception exception, string message ) => Logger.Trace( exception, message );
    public void LogTrace( Exception exception, string message, params object[] args ) => Logger.Trace( exception, message, args );
    public void LogTrace( Func<string> messageFactory ) => Logger.Trace( messageFactory );
    public void LogWarning( string message ) => Logger.Warn( message );
    public void LogWarning( string message, params object[] args ) => Logger.Warn( message, args );
    public void LogWarning( Exception exception, string message ) => Logger.Warn( exception, message );
    public void LogWarning( Exception exception, string message, params object[] args ) => Logger.Warn( exception, message, args );
    public void LogWarning( Func<string> messageFactory ) => Logger.Warn( messageFactory );
}
