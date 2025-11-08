using System;

namespace SparkliTwizzl.Trioxichor.Logging.Frameworks;

public class LogaryFactory : ILoggingFrameworkFactory
{
    private void Configure( LogConfiguration config ) => throw new NotImplementedException();

    public LogConfiguration Configuration { get; private set; } = new LogConfiguration();

    /// <summary>Creates a new factory instance using default configuration.</summary>
    /// <remarks>
    /// <para>The framework specified by the configuration is ignored, because it is not relevant at this level.</para>
    /// </remarks>
    public LogaryFactory() => Configure( new LogConfiguration() );

    /// <summary>Creates a new factory instance using the provided configuration.</summary>
    /// <remarks>
    /// <para>The framework specified by the configuration is ignored, because it is not relevant at this level.</para>
    /// </remarks>
    /// <param name="config">Configuration to apply.</param>
    public LogaryFactory( LogConfiguration config ) => Configure( config );

    public ILogger CreateLogger( string categoryName ) => throw new NotImplementedException();
}
