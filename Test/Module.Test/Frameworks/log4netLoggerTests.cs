using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using System;
using Xunit;

namespace SparkliTwizzl.Trioxichor.Logging.Frameworks.Test;

public class log4netLoggerTests
{
    private const string testCategoryName = "TestCategory";
    private const string testExceptionMessage = "Test exception";
    private const string testArgument = "ArgumentValue";
    private const string testFormatMessage = "Formatted message with arg: {0}";
    private const string testFormattedMessage = "Formatted message with arg: ArgumentValue";
    private const string testMessage = "Test message";
    private Hierarchy repositoryAllLevels;
    private Hierarchy repositoryNoLevels;
    private MemoryAppender memoryAppender;


    public log4netLoggerTests()
    {
        memoryAppender = new MemoryAppender();
        var patternLayout = new PatternLayout( "%level|%message|%exception" );
        patternLayout.ActivateOptions();
        memoryAppender.Layout = patternLayout;
        memoryAppender.ActivateOptions();

        repositoryAllLevels = new Hierarchy();
        _ = BasicConfigurator.Configure( repositoryAllLevels, memoryAppender );
        repositoryAllLevels.Root.Level = Level.All;
        repositoryAllLevels.RaiseConfigurationChanged( EventArgs.Empty );
        repositoryAllLevels.Configured = true;

        repositoryNoLevels = new Hierarchy();
        _ = BasicConfigurator.Configure( repositoryNoLevels, memoryAppender );
        repositoryNoLevels.Root.Level = Level.Off;
        repositoryNoLevels.RaiseConfigurationChanged( EventArgs.Empty );
        repositoryNoLevels.Configured = true;
    }

    [Fact]
    public void Constructor_ShouldSetCategoryName()
    {
        var internalLogger = repositoryAllLevels.GetLogger( testCategoryName ) as ILog;
        var testLogger = new log4netLogger( internalLogger! );
        Assert.Equal( testCategoryName, testLogger.CategoryName );
    }

    [Fact]
    public void Debug_Message_ShouldLogMessage()
    {
        memoryAppender.Clear();
        var internalLogger = repositoryAllLevels.GetLogger( testCategoryName ) as ILog;
        var testLogger = new log4netLogger( internalLogger! );
        testLogger.Debug( testMessage );
        var events = memoryAppender.GetEvents();
        Assert.NotEmpty( events );
        Assert.Contains( events, e => e.RenderedMessage!.Contains( testMessage ) && e.Level == Level.Debug );
    }

    [Fact]
    public void Debug_MessageWithArgs_ShouldLogFormattedMessage()
    {
        memoryAppender.Clear();
        var internalLogger = repositoryAllLevels.GetLogger( testCategoryName ) as ILog;
        var testLogger = new log4netLogger( internalLogger! );
        testLogger.Debug( testFormatMessage, testArgument );
        var events = memoryAppender.GetEvents();
        Assert.NotEmpty( events );
        Assert.Contains( events, e => e.RenderedMessage!.Contains( testFormattedMessage ) && e.Level == Level.Debug );
    }

    [Fact]
    public void Debug_ExceptionWithMessage_ShouldLogExceptionAndMessage()
    {
        memoryAppender.Clear();
        var internalLogger = repositoryAllLevels.GetLogger( testCategoryName ) as ILog;
        var testLogger = new log4netLogger( internalLogger! );
        var exception = new Exception( testExceptionMessage );
        testLogger.Debug( exception, testMessage );
        var events = memoryAppender.GetEvents();
        Assert.NotEmpty( events );
        Assert.Contains( events, e => e.RenderedMessage!.Contains( testMessage ) && e.Level == Level.Debug && e.ExceptionObject == exception );
    }

    [Fact]
    public void Debug_ExceptionWithMessageAndArgs_ShouldLogExceptionAndFormattedMessage()
    {
        memoryAppender.Clear();
        var internalLogger = repositoryAllLevels.GetLogger( testCategoryName ) as ILog;
        var testLogger = new log4netLogger( internalLogger! );
        var exception = new Exception( testExceptionMessage );
        testLogger.Debug( exception, testFormatMessage, testArgument );
        var events = memoryAppender.GetEvents();
        Assert.NotEmpty( events );
        Assert.Contains( events, e => e.RenderedMessage!.Contains( testFormattedMessage ) && e.Level == Level.Debug && e.ExceptionObject == exception );
    }

    [Fact]
    public void Debug_MessageFactory_LevelDisabled_ShouldNotLogMessage()
    {
        memoryAppender.Clear();
        var internalLogger = repositoryNoLevels.GetLogger( testCategoryName ) as ILog;
        var testLogger = new log4netLogger( internalLogger! );
        testLogger.Debug( () => testMessage );
        var events = memoryAppender.GetEvents();
        Assert.DoesNotContain( events, e => e.RenderedMessage!.Contains( testMessage ) && e.Level == Level.Debug );
    }

    [Fact]
    public void Debug_MessageFactory_LevelEnabled_ShouldLogMessage()
    {
        memoryAppender.Clear();
        var internalLogger = repositoryAllLevels.GetLogger( testCategoryName ) as ILog;
        var testLogger = new log4netLogger( internalLogger! );
        testLogger.Debug( () => testMessage );
        var events = memoryAppender.GetEvents();
        Assert.NotEmpty( events );
        Assert.Contains( events, e => e.RenderedMessage!.Contains( testMessage ) && e.Level == Level.Debug );
    }
}
