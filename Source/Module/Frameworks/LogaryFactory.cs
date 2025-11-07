namespace SparkliTwizzl.Trioxichor.Logging.Frameworks;

public class LogaryFactory : ILoggingFrameworkFactory
{
    void Configure( LogConfiguration config ) => throw new NotImplementedException();

    /// <summary>Creates a new factory instance using default configuration.</summary>
    public LogaryFactory() => Configure( new LogConfiguration() );

    /// <summary>Creates a new factory instance using the provided configuration.</summary>
    /// <param name="config">Configuration to apply.</param>
    public LogaryFactory( LogConfiguration config ) => Configure( config );

    public ILogger CreateLogger( string categoryName ) => throw new NotImplementedException();
}
