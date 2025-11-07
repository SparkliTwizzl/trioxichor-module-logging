namespace SparkliTwizzl.Trioxichor.Logging.Frameworks
{
    public interface ILoggingFramework : ILogger
    {
        public void Configure( LogConfiguration config );
    }
}
