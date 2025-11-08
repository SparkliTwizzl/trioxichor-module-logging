using SparkliTwizzl.Trioxichor.Logging.Frameworks;
using System;

namespace SparkliTwizzl.Trioxichor.Logging;

class LoggerFactory : ILoggerFactory
{
    ILoggingFrameworkFactory FrameworkFactory { get; set; }

    ILoggingFrameworkFactory CreateFrameworkFactory( LogConfiguration config ) => config.Framework switch
    {
        LogFramework.log4net => new log4netFactory( config ),
        LogFramework.Logary => new LogaryFactory( config ),
        LogFramework.NLog => new NLogFactory( config ),
        LogFramework.Serilog => new SerilogFactory( config ),
        LogFramework.ZLogger => new ZLoggerFactory( config ),
        _ => throw new NotSupportedException()
    };

    /// <summary>Creates a factory instance using default configuration.</summary>
    public LoggerFactory() => FrameworkFactory = CreateFrameworkFactory( new LogConfiguration() );

    /// <summary>Creates a factory instance using the provided configuration.</summary>
    /// <param name="config">Configuration to apply.</param>
    public LoggerFactory( LogConfiguration config ) => FrameworkFactory = CreateFrameworkFactory( config );

    public ILogger CreateLogger( string categoryName ) => FrameworkFactory.CreateLogger( categoryName );
}
