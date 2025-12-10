using log4net;
using log4net.Appender;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static log4net.Appender.ColoredConsoleAppender;

namespace SparkliTwizzl.Trioxichor.Logging.Frameworks.Test;

public class log4netFactoryTests
{
    [Fact]
    public void Constructor_ShouldApplyMinimumLogLevel()
    {
        var config = new LogConfiguration
        {
            MinimumLevel = LogLevel.Warning
        };
        _ = new log4netFactory( config );
        var log4netConfig = LogManager.GetRepository();
        Assert.NotNull( log4netConfig );
        var hierarchy = ( log4net.Repository.Hierarchy.Hierarchy ) log4netConfig;
        Assert.NotNull( hierarchy.Root.Level );
        Assert.DoesNotContain( Level.All, ( IEnumerable<Level> ) hierarchy.Root.Level );
        Assert.DoesNotContain( Level.Debug, ( IEnumerable<Level> ) hierarchy.Root.Level );
        Assert.DoesNotContain( Level.Info, ( IEnumerable<Level> ) hierarchy.Root.Level );
        Assert.Contains( Level.Warn, ( IEnumerable<Level> ) hierarchy.Root.Level );
        Assert.Contains( Level.Error, ( IEnumerable<Level> ) hierarchy.Root.Level );
        Assert.Contains( Level.Fatal, ( IEnumerable<Level> ) hierarchy.Root.Level );
    }

    [Fact]
    public void Constructor_ShouldApplyLayoutFormat()
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
        _ = new log4netFactory( config );
        var log4netConfig = LogManager.GetRepository();
        Assert.NotNull( log4netConfig );
        var consoleAppender = log4netConfig.GetAppenders().OfType<ConsoleAppender>().FirstOrDefault();
        Assert.NotNull( consoleAppender );
        Assert.NotNull( consoleAppender?.Layout );
        if ( consoleAppender is not null )
        {
            Assert.Equal( layoutFormat, consoleAppender?.Layout?.ToString() );
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
        _ = new log4netFactory( config );
        var log4netConfig = LogManager.GetRepository();
        Assert.NotNull( log4netConfig );
        Assert.Contains( log4netConfig.GetAppenders(), t => t is ConsoleAppender );
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
        _ = new log4netFactory( config );
        var log4netConfig = LogManager.GetRepository();
        var appenders = log4netConfig.GetAppenders();
        var coloredConsoleAppender = appenders.OfType<ColoredConsoleAppender>().FirstOrDefault();
        Assert.NotNull( coloredConsoleAppender );
        var levelMappings = coloredConsoleAppender.GetType()
            .GetField( "m_levelColors", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance )
            ?.GetValue( coloredConsoleAppender ) as IEnumerable<LevelColors>;
        Assert.NotNull( levelMappings );
        Assert.Contains( levelMappings, mapping => mapping.Level == Level.Info && mapping.ForeColor == Colors.Green );
        Assert.Contains( levelMappings, mapping => mapping.Level == Level.Warn && mapping.ForeColor == Colors.Yellow );
        Assert.Contains( levelMappings, mapping => mapping.Level == Level.Error && mapping.ForeColor == Colors.Red );
    }

    [Fact]
    public void Constructor_ShouldCreateValidJsonTarget()
    {
        var target = new LogTarget
        {
            Type = LogTargetType.Json,
            FilePath = "log.json",
        };
        var config = new LogConfiguration
        {
            Targets = new List<LogTarget> { target }
        };
        _ = new log4netFactory( config );
        var log4netConfig = LogManager.GetRepository();
        Assert.NotNull( log4netConfig );
        var fileTarget = log4netConfig.GetAppenders().OfType<FileAppender>().FirstOrDefault();
        Assert.NotNull( fileTarget );
        Assert.NotNull( fileTarget.File );
        Assert.Equal( target.FilePath, fileTarget.File );
    }

    [Fact]
    public void CreateLogger_ShouldReturnLog4netLogger()
    {
        var factory = new log4netFactory();
        var categoryName = "TestCategory";
        var logger = factory.CreateLogger( categoryName );
        Assert.NotNull( logger );
        _ = Assert.IsType<log4netLogger>( logger );
        Assert.Equal( categoryName, ( ( log4netLogger ) logger ).CategoryName );
    }
}
