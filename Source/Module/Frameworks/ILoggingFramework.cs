namespace SparkliTwizzl.Trioxichor.Logging.Frameworks;

public interface ILoggingFramework : ILogger
{
    /// <summary>Configure framework from a <see cref="LogConfiguration"/>.</summary>
    /// <remarks>Some frameworks may not support all Trioxichor config fields.</remarks>
    /// <param name="config">Configuration to apply.</param>
    public void Configure( LogConfiguration config );
}
