namespace SparkliTwizzl.Trioxichor.Logging.Frameworks;

public interface ILoggingFrameworkFactory
{
    /// <summary>Creates a new <see cref="ILogger"/> instance from the framework's logger factory.</summary>
    /// <remarks>
    /// <para>All <see cref="ILogger"/> instances will write to the same <see cref="LogTarget"/>s.</para>
    /// </remarks>
    /// <param name="categoryName">Category name for messages produced by the logger.</param>
    /// <returns>The new <see cref="ILogger"/> instance.</returns>
    ILogger CreateLogger( string categoryName );
}
