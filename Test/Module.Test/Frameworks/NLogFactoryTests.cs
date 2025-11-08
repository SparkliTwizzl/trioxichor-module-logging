using System.Collections.Generic;
using NLog;
using NLog.Targets;
using SparkliTwizzl.Trioxichor.Logging.Frameworks;
using Xunit;

namespace SparkliTwizzl.Trioxichor.Logging.Test.Frameworks;

public class NLogFactoryTests
{
    [Fact]
    public void CreateLogger_ShouldReturnNLogLogger()
    {
        var factory = new NLogFactory();
        var categoryName = "TestCategory";
        var logger = factory.CreateLogger( categoryName );
        Assert.NotNull( logger );
        _ = Assert.IsType<NLogLogger>( logger );
        Assert.Equal( categoryName, ( ( NLogLogger ) logger ).CategoryName );
    }

    [Fact]
    public void Configure_ShouldApplyMinimumLogLevel()
    {
        var config = new LogConfiguration
        {
            MinimumLevel = LogLevel.Warning
        };
        var factory = new NLogFactory( config );
        var nlogConfig = LogManager.Configuration;
        Assert.NotNull( nlogConfig );
        Assert.DoesNotContain( nlogConfig.LoggingRules, rule => rule.Levels.Contains( NLog.LogLevel.Trace ) );
        Assert.DoesNotContain( nlogConfig.LoggingRules, rule => rule.Levels.Contains( NLog.LogLevel.Debug ) );
        Assert.DoesNotContain( nlogConfig.LoggingRules, rule => rule.Levels.Contains( NLog.LogLevel.Info ) );
        Assert.Contains( nlogConfig.LoggingRules, rule => rule.Levels.Contains( NLog.LogLevel.Warn ) );
        Assert.Contains( nlogConfig.LoggingRules, rule => rule.Levels.Contains( NLog.LogLevel.Error ) );
        Assert.Contains( nlogConfig.LoggingRules, rule => rule.Levels.Contains( NLog.LogLevel.Fatal ) );
    }

    [Fact]
    public void CreateNLogJsonTarget_ShouldCreateValidJsonTarget()
    {
        var target = new LogTarget
        {
            Type = LogTargetType.Json,
            FilePath = "log.json"
        };
        var config = new LogConfiguration
        {
            Targets = new List<LogTarget> { target }
        };
        _ = new NLogFactory( config );
        var nlogConfig = LogManager.Configuration;
        Assert.NotNull( nlogConfig );
        var allTargets = nlogConfig?.AllTargets;
        Assert.NotNull( allTargets );
        if ( allTargets != null )
        {
            foreach ( var t in allTargets )
            {
                Assert.NotNull( t );
                if ( t is FileTarget fileTarget )
                {
                    Assert.NotNull( fileTarget.FileName );
                    Assert.Contains( "log.json", fileTarget.FileName.ToString() );
                }
            }
        }
    }

    [Fact]
    public void CreateNLogConsoleTarget_ShouldCreateValidConsoleTarget()
    {
        var target = new LogTarget
        {
            Type = LogTargetType.Console
        };
        var config = new LogConfiguration
        {
            Targets = new List<LogTarget> { target }
        };
        _ = new NLogFactory( config );
        var nlogConfig = LogManager.Configuration;
        Assert.NotNull( nlogConfig );
        Assert.Contains( nlogConfig.AllTargets, t => t is ConsoleTarget );
    }
}
