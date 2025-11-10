using SparkliTwizzl.Trioxichor.Logging.Frameworks;
using System;
using Xunit;

namespace SparkliTwizzl.Trioxichor.Logging.Tests;

public class LoggerFactoryTests
{
    private const string TestCategory = "TestCategory";


    [Fact]
    public void DefaultConstructor_ShouldUseDefaultFramework()
    {
        var factory = new LoggerFactory();
        var logger = factory.CreateLogger( TestCategory );
        Assert.NotNull( logger );
        _ = Assert.IsType<NLogLogger>( logger );
    }

    [Theory]
    [InlineData( LogFramework.log4net, typeof( log4netLogger ) )]
    [InlineData( LogFramework.Logary, typeof( LogaryLogger ) )]
    [InlineData( LogFramework.NLog, typeof( NLogLogger ) )]
    [InlineData( LogFramework.Serilog, typeof( SerilogLogger ) )]
    [InlineData( LogFramework.ZLogger, typeof( ZLoggerLogger ) )]
    public void CustomConstructor_ShouldUseSpecifiedFramework( LogFramework framework, Type expectedLoggerType )
    {
        var config = new LogConfiguration { Framework = framework };
        var factory = new LoggerFactory( config );
        var logger = factory.CreateLogger( TestCategory );
        Assert.NotNull( logger );
        Assert.IsType( expectedLoggerType, logger );
    }
}
