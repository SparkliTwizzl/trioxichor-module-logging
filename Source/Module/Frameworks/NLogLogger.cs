using NLog;
using System;

namespace SparkliTwizzl.Trioxichor.Logging.Frameworks;

public class NLogLogger : ILogger
{
    private Logger Logger { get; set; }


    public string CategoryName { get; private set; } = string.Empty;

    public NLogLogger( Logger logger )
    {
        Logger = logger;
        CategoryName = logger.Name;
    }

    public void Debug( string message ) => Logger.Debug( message );

    public void Debug( string message, params object[] args ) => Logger.Debug( message, args );

    public void Debug( Exception exception, string message ) => Logger.Debug( exception, message );

    public void Debug( Exception exception, string message, params object[] args ) => Logger.Debug( exception, message, args );

    public void Debug( Func<string> messageFactory ) => Logger.Debug( new LogMessageGenerator( messageFactory ) );

    public void Error( string message ) => Logger.Error( message );

    public void Error( string message, params object[] args ) => Logger.Error( message, args );

    public void Error( Exception exception, string message ) => Logger.Error( exception, message );

    public void Error( Exception exception, string message, params object[] args ) => Logger.Error( exception, message, args );

    public void Error( Func<string> messageFactory ) => Logger.Error( new LogMessageGenerator( messageFactory ) );

    public void Fatal( string message ) => Logger.Fatal( message );

    public void Fatal( string message, params object[] args ) => Logger.Fatal( message, args );

    public void Fatal( Exception exception, string message ) => Logger.Fatal( exception, message );

    public void Fatal( Exception exception, string message, params object[] args ) => Logger.Fatal( exception, message, args );

    public void Fatal( Func<string> messageFactory ) => Logger.Fatal( new LogMessageGenerator( messageFactory ) );

    public void Info( string message ) => Logger.Info( message );

    public void Info( string message, params object[] args ) => Logger.Info( message, args );

    public void Info( Exception exception, string message ) => Logger.Info( exception, message );

    public void Info( Exception exception, string message, params object[] args ) => Logger.Info( exception, message, args );

    public void Info( Func<string> messageFactory ) => Logger.Info( new LogMessageGenerator( messageFactory ) );

    public void Trace( string message ) => Logger.Trace( message );

    public void Trace( string message, params object[] args ) => Logger.Trace( message, args );

    public void Trace( Exception exception, string message ) => Logger.Trace( exception, message );

    public void Trace( Exception exception, string message, params object[] args ) => Logger.Trace( exception, message, args );

    public void Trace( Func<string> messageFactory ) => Logger.Trace( new LogMessageGenerator( messageFactory ) );

    public void Warning( string message ) => Logger.Warn( message );

    public void Warning( string message, params object[] args ) => Logger.Warn( message, args );

    public void Warning( Exception exception, string message ) => Logger.Warn( exception, message );

    public void Warning( Exception exception, string message, params object[] args ) => Logger.Warn( exception, message, args );

    public void Warning( Func<string> messageFactory ) => Logger.Warn( new LogMessageGenerator( messageFactory ) );
}
