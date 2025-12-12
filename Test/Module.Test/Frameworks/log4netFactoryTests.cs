using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;
using static log4net.Appender.ManagedColoredConsoleAppender;

namespace SparkliTwizzl.Trioxichor.Logging.Frameworks.Test;

public class log4netFactoryTests : IDisposable
{
    public void Dispose()
    {
        var repository = LogManager.GetRepository();
        if ( repository is log4net.Repository.Hierarchy.Hierarchy hierarchy )
        {
            hierarchy.Root.RemoveAllAppenders();
        }
    }

    [Fact]
    public void Constructor_ShouldApplyMinimumLogLevel()
    {
        var config = new LogConfiguration
        {
            MinimumLevel = LogLevel.Warning
        };
        _ = new log4netFactory( config );
        var repository = LogManager.GetRepository();
        Assert.NotNull( repository );
        var hierarchy = ( log4net.Repository.Hierarchy.Hierarchy ) repository;
        Assert.NotNull( hierarchy.Root.Level );
        Assert.True( hierarchy.Root.Level == Level.Warn );
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
        var repository = LogManager.GetRepository();
        Assert.NotNull( repository );
        var consoleAppender = repository.GetAppenders().OfType<ConsoleAppender>().FirstOrDefault();
        Assert.NotNull( consoleAppender );
        var layout = consoleAppender.Layout as log4net.Layout.PatternLayout;
        Assert.NotNull( layout );
        var expected = "%longdate|%level|%message%newline";
        var actual = layout.ConversionPattern.ToString();
        Assert.Equal( expected, actual );
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
        var repository = LogManager.GetRepository();
        Assert.NotNull( repository );
        Assert.Contains( repository.GetAppenders(), t => t is ConsoleAppender );
    }

    [Fact]
    public void Constructor_ShouldCreateValidColoredConsoleTarget()
    {
        var target = new LogTarget
        {
            Type = LogTargetType.ColoredConsole,
        };
        var colorMap = new Dictionary<LogLevel, ConsoleColor>
        {
            { LogLevel.Info, ConsoleColor.Green },
            { LogLevel.Warning, ConsoleColor.Yellow },
            { LogLevel.Error, ConsoleColor.Red },
        };
        var config = new LogConfiguration
        {
            ConsoleColorMap = colorMap,
            Targets = new List<LogTarget> { target },
        };
        _ = new log4netFactory( config );
        var repository = LogManager.GetRepository();
        var allAppenders = repository.GetAppenders();
        var appender = allAppenders.OfType<ManagedColoredConsoleAppender>().FirstOrDefault();
        Assert.NotNull( appender );

        var expected = new Dictionary<Level, LevelColors>
        {
            { Level.Info, new() { Level = Level.Info, ForeColor = ConsoleColor.Green } },
            { Level.Warn, new() { Level = Level.Warn, ForeColor = ConsoleColor.Yellow } },
            { Level.Error, new() { Level = Level.Error, ForeColor = ConsoleColor.Red } },
        };

        var levelMapping = appender
            .GetType()
            .GetField( "_levelMapping", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance )?
            .GetValue( appender );
        Assert.NotNull( levelMapping );
        var entries = levelMapping
            .GetType()
            .GetField( "_entries", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance )?
            .GetValue( levelMapping );
        Assert.NotNull( entries );
        var actual = entries as Dictionary<Level, LevelMappingEntry>;
        Assert.NotNull( actual );

        Assert.Equal( expected.Count, actual.Count );
        foreach ( var expectedItem in expected )
        {
            Assert.True( actual.ContainsKey( expectedItem.Key ) );
            var expectedValue = expectedItem.Value;
            var actualValue = actual[ expectedItem.Key ] as LevelColors;
            Assert.NotNull( actualValue );
            Assert.Equal( expectedValue.BackColor, actualValue.BackColor );
            Assert.Equal( expectedValue.ForeColor, actualValue.ForeColor );
            Assert.Equal( expectedValue.Level, actualValue.Level );
        }
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
        var repository = LogManager.GetRepository();
        Assert.NotNull( repository );
        var allAppenders = repository.GetAppenders();
        var appender = allAppenders.OfType<FileAppender>().FirstOrDefault();
        Assert.NotNull( appender );
        Assert.NotNull( appender.File );
        var actual = Path.GetFileName( appender.File );
        Assert.Equal( target.FilePath, actual );
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
