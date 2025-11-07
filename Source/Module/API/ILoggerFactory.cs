namespace SparkliTwizzl.Trioxichor.Logging
{
    public interface ILoggerFactory
    {
        /// <summary>Configures the logger factory from a <see cref="LogConfiguration"/>.</summary>
        /// <param name="config">The configuration to apply.</param>
        void Configure( LogConfiguration config );

        /// <summary>Creates a new <see cref="ILogger"/> instance.</summary>
        /// <remarks>
        /// <para>All <see cref="ILogger"/> instances will write to the same <see cref="LogTarget"/>s.</para>
        /// </remarks>
        /// <param name="categoryName">Category name for messages produced by the logger.</param>
        /// <returns>The new <see cref="ILogger"/> instance.</returns>
        ILogger CreateLogger( string categoryName );
    }
}
