using log4net;
using System;

namespace SparkliTwizzl.Trioxichor.Logging.Frameworks;

public class log4netLogger : ILogger
{
    private ILog Logger { get; set; }


    public string CategoryName { get; private set; } = string.Empty;

    public log4netLogger( ILog logger )
    {
        Logger = logger;
        CategoryName = logger.Logger.Name;
    }

    public void Debug( string message ) => Logger.Debug( message );

    public void Debug( string message, params object[] args ) => Logger.DebugFormat( message, args );

    public void Debug( Exception exception, string message ) => Logger.Debug( message, exception );

    public void Debug( Exception exception, string message, params object[] args ) => Logger.Debug( string.Format( message, args ), exception );

    public void Debug( Func<string> messageFactory ) => Logger.Debug( messageFactory() );

    public void Error( string message ) => Logger.Error( message );

    public void Error( string message, params object[] args ) => Logger.ErrorFormat( message, args );

    public void Error( Exception exception, string message ) => Logger.Error( message, exception );

    public void Error( Exception exception, string message, params object[] args ) => Logger.Error( string.Format( message, args ), exception );

    public void Error( Func<string> messageFactory ) => Logger.Error( messageFactory() );

    public void Fatal( string message ) => Logger.Fatal( message );

    public void Fatal( string message, params object[] args ) => Logger.FatalFormat( message, args );

    public void Fatal( Exception exception, string message ) => Logger.Fatal( message, exception );

    public void Fatal( Exception exception, string message, params object[] args ) => Logger.Fatal( string.Format( message, args ), exception );

    public void Fatal( Func<string> messageFactory ) => Logger.Fatal( messageFactory() );

    public void Info( string message ) => Logger.Info( message );

    public void Info( string message, params object[] args ) => Logger.InfoFormat( message, args );

    public void Info( Exception exception, string message ) => Logger.Info( message, exception );

    public void Info( Exception exception, string message, params object[] args ) => Logger.Info( string.Format( message, args ), exception );

    public void Info( Func<string> messageFactory ) => Logger.Info( messageFactory() );

    public void Trace( string message ) => Logger.Debug( message );

    public void Trace( string message, params object[] args ) => Logger.DebugFormat( message, args );

    public void Trace( Exception exception, string message ) => Logger.Debug( message, exception );

    public void Trace( Exception exception, string message, params object[] args ) => Logger.Debug( string.Format( message, args ), exception );

    public void Trace( Func<string> messageFactory ) => Logger.Debug( messageFactory() );

    public void Warning( string message ) => Logger.Warn( message );

    public void Warning( string message, params object[] args ) => Logger.WarnFormat( message, args );

    public void Warning( Exception exception, string message ) => Logger.Warn( message, exception );

    public void Warning( Exception exception, string message, params object[] args ) => Logger.Warn( string.Format( message, args ), exception );

    public void Warning( Func<string> messageFactory ) => Logger.Warn( messageFactory() );
}
