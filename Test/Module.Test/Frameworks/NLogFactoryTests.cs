using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using NLog.Targets;
using Xunit;

namespace SparkliTwizzl.Trioxichor.Logging.Frameworks.Test;

public class NLogFactoryTests
{
    [Fact]
    public void Constructor_ShouldApplyMinimumLogLevel()
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
    public void Construcor_ShouldApplyLayoutFormat()
    {
        var layoutFormat = "${longdate}|${level}|${message}";
        var target = new LogTarget
        {
            Type = LogTargetType.ColorlessConsole,
        };
        var config = new LogConfiguration
        {
            Layout = layoutFormat,
            Targets = new List<LogTarget> { target }
        };
        _ = new NLogFactory( config );
        var nlogConfig = LogManager.Configuration;
        Assert.NotNull( nlogConfig );
        var consoleTarget = nlogConfig.AllTargets.OfType<ConsoleTarget>().FirstOrDefault();
        Assert.NotNull( consoleTarget );
        if ( consoleTarget != null )
        {
            Assert.Equal( layoutFormat, consoleTarget.Layout.ToString() );
        }
    }

    [Fact]
    public void Constructor_ShouldCreateValidColorlessConsoleTarget()
    {
        var target = new LogTarget
        {
            Type = LogTargetType.ColorlessConsole
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

    [Fact]
    public void Constructor_ShouldCreateValidColoredConsoleTarget()
    {
        var target = new LogTarget
        {
            Type = LogTargetType.ColoredConsole,
        };
        var config = new LogConfiguration
        {
            ConsoleColorMap = new Dictionary<LogLevel, ConsoleColor>
            {
                { LogLevel.Info, ConsoleColor.Green },
                { LogLevel.Warning, ConsoleColor.Yellow },
                { LogLevel.Error, ConsoleColor.Red },
            },
            Targets = new List<LogTarget> { target },
        };
        _ = new NLogFactory( config );
        var nlogConfig = LogManager.Configuration;
        Assert.NotNull( nlogConfig );
        Assert.Contains( nlogConfig.AllTargets, t => t is ColoredConsoleTarget );
        var coloredConsoleTarget = nlogConfig.AllTargets.OfType<ColoredConsoleTarget>().FirstOrDefault();
        Assert.NotNull( coloredConsoleTarget );
        if ( coloredConsoleTarget != null )
        {
            Assert.Contains( coloredConsoleTarget.RowHighlightingRules, rule => rule.Condition!.ToString().Contains( "level == 'Info'" ) && rule.ForegroundColor.ToString() == "Green" );
            Assert.Contains( coloredConsoleTarget.RowHighlightingRules, rule => rule.Condition!.ToString().Contains( "level == 'Warn'" ) && rule.ForegroundColor.ToString() == "Yellow" );
            Assert.Contains( coloredConsoleTarget.RowHighlightingRules, rule => rule.Condition!.ToString().Contains( "level == 'Error'" ) && rule.ForegroundColor.ToString() == "Red" );
        }
    }

    [Fact]
    public void Constructor_ShouldCreateValidJsonTarget()
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
    public void CreateLogger_ShouldReturnNLogLogger()
    {
        var factory = new NLogFactory();
        var categoryName = "TestCategory";
        var logger = factory.CreateLogger( categoryName );
        Assert.NotNull( logger );
        _ = Assert.IsType<NLogLogger>( logger );
        Assert.Equal( categoryName, ( ( NLogLogger ) logger ).CategoryName );
    }
}
