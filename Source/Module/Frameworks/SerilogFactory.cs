namespace SparkliTwizzl.Trioxichor.Logging.Frameworks;

public class SerilogFactory : ILoggingFrameworkFactory
{
    void Configure( LogConfiguration config ) => throw new NotImplementedException();

    /// <summary>Creates a new factory instance using default configuration.</summary>
    public SerilogFactory() => Configure( new LogConfiguration() );

    /// <summary>Creates a new factory instance using the provided configuration.</summary>
    /// <param name="config">Configuration to apply.</param>
    public SerilogFactory( LogConfiguration config ) => Configure( config );

    public ILogger CreateLogger( string categoryName ) => throw new NotImplementedException();
}
