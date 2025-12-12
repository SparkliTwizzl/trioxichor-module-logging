using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using Xunit;

namespace SparkliTwizzl.Trioxichor.Logging.Frameworks.Test;

public class NLogLoggerTests
{
    private const string testCategoryName = "TestCategory";
    private const string testExceptionMessage = "Test exception";
    private const string testArgument = "ArgumentValue";
    private const string testFormatMessage = "Formatted message with arg: {0}";
    private const string testFormattedMessage = "Formatted message with arg: ArgumentValue";
    private const string testMessage = "Test message";
    private LogFactory logFactoryAllLevels;
    private LogFactory logFactoryNoLevels;


    public NLogLoggerTests()
    {
        var memoryTarget = new MemoryTarget();
        memoryTarget.Layout = "${level}|${message}|${exception:format=toString}";

        var configAllLevels = new LoggingConfiguration();
        configAllLevels.AddRule( NLog.LogLevel.Trace, NLog.LogLevel.Fatal, memoryTarget );
        logFactoryAllLevels = new LogFactory();
        logFactoryAllLevels.Configuration = configAllLevels;

        var configNoLevels = new LoggingConfiguration();
        configNoLevels.AddRule( NLog.LogLevel.Off, NLog.LogLevel.Off, memoryTarget );
        logFactoryNoLevels = new LogFactory();
        logFactoryNoLevels.Configuration = configNoLevels;
    }

    [Fact]
    public void Constructor_ShouldSetCategoryName()
    {
        var loggerName = testCategoryName;
        var internalLogger = logFactoryAllLevels.GetLogger( loggerName );
        var testLogger = new NLogLogger( internalLogger );
        Assert.Equal( loggerName, testLogger.CategoryName );
    }

    [Fact]
    public void Debug_Message_ShouldLogMessage()
    {
        var internalLogger = logFactoryAllLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        testLogger.Debug( testMessage );
        var config = logFactoryAllLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.Contains( "Debug|" + testMessage + "|", memoryTarget.Logs );
    }

    [Fact]
    public void Debug_MessageWithArgs_ShouldLogFormattedMessage()
    {
        var internalLogger = logFactoryAllLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        testLogger.Debug( testFormatMessage, testArgument );
        var config = logFactoryAllLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.Contains( "Debug|" + testFormattedMessage + "|", memoryTarget.Logs );
    }

    [Fact]
    public void Debug_ExceptionWithMessage_ShouldLogExceptionAndMessage()
    {
        var internalLogger = logFactoryAllLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        var exception = new Exception( testExceptionMessage );
        testLogger.Debug( exception, testMessage );
        var config = logFactoryAllLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.Contains( "Debug|" + testMessage + "|" + exception.ToString(), memoryTarget.Logs );
    }

    [Fact]
    public void Debug_ExceptionWithMessageAndArgs_ShouldLogExceptionAndFormattedMessage()
    {
        var internalLogger = logFactoryAllLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        var exception = new Exception( testExceptionMessage );
        testLogger.Debug( exception, testFormatMessage, testArgument );
        var config = logFactoryAllLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.Contains( "Debug|" + testFormattedMessage + "|" + exception.ToString(), memoryTarget.Logs );
    }

    [Fact]
    public void Debug_MessageFactory_LevelDisabled_ShouldNotLogMessage()
    {
        var internalLogger = logFactoryNoLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        testLogger.Debug( () => testMessage );
        var config = logFactoryNoLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.DoesNotContain( "Debug|" + testMessage + "|", memoryTarget.Logs );
    }

    [Fact]
    public void Debug_MessageFactory_LevelEnabled_ShouldLogMessage()
    {
        var internalLogger = logFactoryAllLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        testLogger.Debug( () => testMessage );
        var config = logFactoryAllLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.Contains( "Debug|" + testMessage + "|", memoryTarget.Logs );
    }

    [Fact]
    public void Error_Message_ShouldLogMessage()
    {
        var internalLogger = logFactoryAllLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        testLogger.Error( testMessage );
        var config = logFactoryAllLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.Contains( "Error|" + testMessage + "|", memoryTarget.Logs );
    }

    [Fact]
    public void Error_MessageWithArgs_ShouldLogFormattedMessage()
    {
        var internalLogger = logFactoryAllLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        testLogger.Error( testFormatMessage, testArgument );
        var config = logFactoryAllLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.Contains( "Error|" + testFormattedMessage + "|", memoryTarget.Logs );
    }

    [Fact]
    public void Error_ExceptionWithMessage_ShouldLogExceptionAndMessage()
    {
        var internalLogger = logFactoryAllLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        var exception = new Exception( testExceptionMessage );
        testLogger.Error( exception, testMessage );
        var config = logFactoryAllLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.Contains( "Error|" + testMessage + "|" + exception.ToString(), memoryTarget.Logs );
    }

    [Fact]
    public void Error_ExceptionWithMessageAndArgs_ShouldLogExceptionAndFormattedMessage()
    {
        var internalLogger = logFactoryAllLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        var exception = new Exception( testExceptionMessage );
        testLogger.Error( exception, testFormatMessage, testArgument );
        var config = logFactoryAllLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.Contains( "Error|" + testFormattedMessage + "|" + exception.ToString(), memoryTarget.Logs );
    }

    [Fact]
    public void Error_MessageFactory_LevelDisabled_ShouldNotLogMessage()
    {
        var internalLogger = logFactoryNoLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        testLogger.Error( () => testMessage );
        var config = logFactoryNoLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.DoesNotContain( "Error|" + testMessage + "|", memoryTarget.Logs );
    }

    [Fact]
    public void Error_MessageFactory_LevelEnabled_ShouldLogMessage()
    {
        var internalLogger = logFactoryAllLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        testLogger.Error( () => testMessage );
        var config = logFactoryAllLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.Contains( "Error|" + testMessage + "|", memoryTarget.Logs );
    }

    [Fact]
    public void Fatal_Message_ShouldLogMessage()
    {
        var internalLogger = logFactoryAllLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        testLogger.Fatal( testMessage );
        var config = logFactoryAllLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.Contains( "Fatal|" + testMessage + "|", memoryTarget.Logs );
    }

    [Fact]
    public void Fatal_MessageWithArgs_ShouldLogFormattedMessage()
    {
        var internalLogger = logFactoryAllLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        testLogger.Fatal( testFormatMessage, testArgument );
        var config = logFactoryAllLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.Contains( "Fatal|" + testFormattedMessage + "|", memoryTarget.Logs );
    }

    [Fact]
    public void Fatal_ExceptionWithMessage_ShouldLogExceptionAndMessage()
    {
        var internalLogger = logFactoryAllLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        var exception = new Exception( testExceptionMessage );
        testLogger.Fatal( exception, testMessage );
        var config = logFactoryAllLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.Contains( "Fatal|" + testMessage + "|" + exception.ToString(), memoryTarget.Logs );
    }

    [Fact]
    public void Fatal_ExceptionWithMessageAndArgs_ShouldLogExceptionAndFormattedMessage()
    {
        var internalLogger = logFactoryAllLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        var exception = new Exception( testExceptionMessage );
        testLogger.Fatal( exception, testFormatMessage, testArgument );
        var config = logFactoryAllLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.Contains( "Fatal|" + testFormattedMessage + "|" + exception.ToString(), memoryTarget.Logs );
    }

    [Fact]
    public void Fatal_MessageFactory_LevelDisabled_ShouldNotLogMessage()
    {
        var internalLogger = logFactoryNoLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        testLogger.Fatal( () => testMessage );
        var config = logFactoryNoLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.DoesNotContain( "Fatal|" + testMessage + "|", memoryTarget.Logs );
    }

    [Fact]
    public void Fatal_MessageFactory_LevelEnabled_ShouldLogMessage()
    {
        var internalLogger = logFactoryAllLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        testLogger.Fatal( () => testMessage );
        var config = logFactoryAllLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.Contains( "Fatal|" + testMessage + "|", memoryTarget.Logs );
    }

    [Fact]
    public void Info_Message_ShouldLogMessage()
    {
        var internalLogger = logFactoryAllLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        testLogger.Info( testMessage );
        var config = logFactoryAllLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.Contains( "Info|" + testMessage + "|", memoryTarget.Logs );
    }

    [Fact]
    public void Info_MessageWithArgs_ShouldLogFormattedMessage()
    {
        var internalLogger = logFactoryAllLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        testLogger.Info( testFormatMessage, testArgument );
        var config = logFactoryAllLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.Contains( "Info|" + testFormattedMessage + "|", memoryTarget.Logs );
    }

    [Fact]
    public void Info_ExceptionWithMessage_ShouldLogExceptionAndMessage()
    {
        var internalLogger = logFactoryAllLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        var exception = new Exception( testExceptionMessage );
        testLogger.Info( exception, testMessage );
        var config = logFactoryAllLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.Contains( "Info|" + testMessage + "|" + exception.ToString(), memoryTarget.Logs );
    }

    [Fact]
    public void Info_ExceptionWithMessageAndArgs_ShouldLogExceptionAndFormattedMessage()
    {
        var internalLogger = logFactoryAllLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        var exception = new Exception( testExceptionMessage );
        testLogger.Info( exception, testFormatMessage, testArgument );
        var config = logFactoryAllLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.Contains( "Info|" + testFormattedMessage + "|" + exception.ToString(), memoryTarget.Logs );
    }

    [Fact]
    public void Info_MessageFactory_LevelDisabled_ShouldNotLogMessage()
    {
        var internalLogger = logFactoryNoLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        testLogger.Info( () => testMessage );
        var config = logFactoryNoLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.DoesNotContain( "Info|" + testMessage + "|", memoryTarget.Logs );
    }

    [Fact]
    public void Info_MessageFactory_LevelEnabled_ShouldLogMessage()
    {
        var internalLogger = logFactoryAllLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        testLogger.Info( () => testMessage );
        var config = logFactoryAllLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.Contains( "Info|" + testMessage + "|", memoryTarget.Logs );
    }

    [Fact]
    public void Trace_Message_ShouldLogMessage()
    {
        var internalLogger = logFactoryAllLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        testLogger.Trace( testMessage );
        var config = logFactoryAllLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.Contains( "Trace|" + testMessage + "|", memoryTarget.Logs );
    }

    [Fact]
    public void Trace_MessageWithArgs_ShouldLogFormattedMessage()
    {
        var internalLogger = logFactoryAllLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        testLogger.Trace( testFormatMessage, testArgument );
        var config = logFactoryAllLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.Contains( "Trace|" + testFormattedMessage + "|", memoryTarget.Logs );
    }

    [Fact]
    public void Trace_ExceptionWithMessage_ShouldLogExceptionAndMessage()
    {
        var internalLogger = logFactoryAllLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        var exception = new Exception( testExceptionMessage );
        testLogger.Trace( exception, testMessage );
        var config = logFactoryAllLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.Contains( "Trace|" + testMessage + "|" + exception.ToString(), memoryTarget.Logs );
    }

    [Fact]
    public void Trace_ExceptionWithMessageAndArgs_ShouldLogExceptionAndFormattedMessage()
    {
        var internalLogger = logFactoryAllLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        var exception = new Exception( testExceptionMessage );
        testLogger.Trace( exception, testFormatMessage, testArgument );
        var config = logFactoryAllLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.Contains( "Trace|" + testFormattedMessage + "|" + exception.ToString(), memoryTarget.Logs );
    }

    [Fact]
    public void Trace_MessageFactory_LevelDisabled_ShouldNotLogMessage()
    {
        var internalLogger = logFactoryNoLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        testLogger.Trace( () => testMessage );
        var config = logFactoryNoLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.DoesNotContain( "Trace|" + testMessage + "|", memoryTarget.Logs );
    }

    [Fact]
    public void Trace_MessageFactory_LevelEnabled_ShouldLogMessage()
    {
        var internalLogger = logFactoryAllLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        testLogger.Trace( () => testMessage );
        var config = logFactoryAllLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.Contains( "Trace|" + testMessage + "|", memoryTarget.Logs );
    }

    [Fact]
    public void Warning_Message_ShouldLogMessage()
    {
        var internalLogger = logFactoryAllLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        testLogger.Warning( testMessage );
        var config = logFactoryAllLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.Contains( "Warn|" + testMessage + "|", memoryTarget.Logs );
    }

    [Fact]
    public void Warning_MessageWithArgs_ShouldLogFormattedMessage()
    {
        var internalLogger = logFactoryAllLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        testLogger.Warning( testFormatMessage, testArgument );
        var config = logFactoryAllLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.Contains( "Warn|" + testFormattedMessage + "|", memoryTarget.Logs );
    }

    [Fact]
    public void Warning_ExceptionWithMessage_ShouldLogExceptionAndMessage()
    {
        var internalLogger = logFactoryAllLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        var exception = new Exception( testExceptionMessage );
        testLogger.Warning( exception, testMessage );
        var config = logFactoryAllLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.Contains( "Warn|" + testMessage + "|" + exception.ToString(), memoryTarget.Logs );
    }

    [Fact]
    public void Warning_ExceptionWithMessageAndArgs_ShouldLogExceptionAndFormattedMessage()
    {
        var internalLogger = logFactoryAllLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        var exception = new Exception( testExceptionMessage );
        testLogger.Warning( exception, testFormatMessage, testArgument );
        var config = logFactoryAllLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.Contains( "Warn|" + testFormattedMessage + "|" + exception.ToString(), memoryTarget.Logs );
    }

    [Fact]
    public void Warning_MessageFactory_LevelDisabled_ShouldNotLogMessage()
    {
        var internalLogger = logFactoryNoLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        testLogger.Warning( () => testMessage );
        var config = logFactoryNoLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.DoesNotContain( "Warn|" + testMessage + "|", memoryTarget.Logs );
    }

    [Fact]
    public void Warning_MessageFactory_LevelEnabled_ShouldLogMessage()
    {
        var internalLogger = logFactoryAllLevels.GetLogger( testCategoryName );
        var testLogger = new NLogLogger( internalLogger );
        testLogger.Warning( () => testMessage );
        var config = logFactoryAllLevels.Configuration;
        Assert.NotNull( config );
        var memoryTarget = ( MemoryTarget ) config.AllTargets[ 0 ];
        Assert.Contains( "Warn|" + testMessage + "|", memoryTarget.Logs );
    }
}
