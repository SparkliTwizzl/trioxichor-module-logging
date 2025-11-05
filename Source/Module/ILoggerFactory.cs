namespace SparkliTwizzl.Trioxichor.Logging
{
    public interface ILoggerFactory
    {
        /// <summary>
        /// Configures the logger factory with the given configuration.
        /// </summary>
        /// <param name="config">The configuration to apply.</param>
        void Configure( LoggerConfiguration config );

        /// <summary>
        /// Creates a new <see cref="ILogger"/> instance.
        /// </summary>
        /// <remarks>
        /// All <see cref="ILogger"/> instances will write to the same <see cref="LogTarget"/>s.
        /// </remarks>
        /// <param name="categoryName">Category name for messages produced by the logger.</param>
        /// <returns>The new <see cref="ILogger"/> instance.</returns>
        ILogger CreateLogger( string categoryName );
    }
}
