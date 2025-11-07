namespace SparkliTwizzl.Trioxichor.Logging.Frameworks;

public class ZLoggerFactory : ILoggingFrameworkFactory
{
    void Configure( LogConfiguration config ) => throw new NotImplementedException();

    /// <summary>Creates a new factory instance using default configuration.</summary>
    public ZLoggerFactory() => Configure( new LogConfiguration() );

    /// <summary>Creates a new factory instance using the provided configuration.</summary>
    /// <param name="config">Configuration to apply.</param>
    public ZLoggerFactory( LogConfiguration config ) => Configure( config );

    public ILogger CreateLogger( string categoryName ) => throw new NotImplementedException();
}
