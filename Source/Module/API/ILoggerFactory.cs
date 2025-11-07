namespace SparkliTwizzl.Trioxichor.Logging;

public interface ILoggerFactory
{
    /// <summary>Creates a new <see cref="ILogger"/> instance from the configured logging framework.</summary>
    /// <remarks>
    /// <para>All logger instances will write to the same targets.</para>
    /// </remarks>
    /// <param name="categoryName">Category name for messages produced by the logger.</param>
    /// <returns>The new logger instance.</returns>
    ILogger CreateLogger( string categoryName );
}
