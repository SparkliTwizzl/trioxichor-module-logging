namespace SparkliTwizzl.Trioxichor.Logging.Utilities
{
    class LoggerFactory : ILoggerFactory
    {
        LogConfiguration Config { get; set; } = new();

        public void Configure( LogConfiguration config ) => Config = config;

        public ILogger CreateLogger( string categoryName ) => throw new NotImplementedException();
    }
}
