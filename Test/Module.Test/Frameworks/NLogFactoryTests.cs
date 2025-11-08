using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace SparkliTwizzl.Trioxichor.Logging.Frameworks.Test;

[TestClass]
public class NLogFactoryTests
{
    [TestMethod]
    public void DefaultConstructor_ShouldApplyDefaultConfiguration()
    {
        var factory = new NLogFactory();
        var expected = new LogConfiguration();
        var actual = factory.Configuration;
        Assert.IsNotNull( actual );
        Assert.AreEqual( expected, actual );
    }

    [TestMethod]
    public void CustomConstructor_ShouldApplyCustomConfiguration()
    {
        var config = new LogConfiguration()
        {
            ConsoleColorMap = new Dictionary<LogLevel, ConsoleColor>
            {
                { LogLevel.Info, ConsoleColor.Green },
                { LogLevel.Warning, ConsoleColor.Yellow },
                { LogLevel.Error, ConsoleColor.Red }
            },
            MinimumLevel = LogLevel.Warning,
            Targets = new List<LogTarget>
            {
                new LogTarget { Type = LogTargetType.Console },
                new LogTarget { Type = LogTargetType.Json, FilePath = "logs/log.txt" }
            }
        };
        var factory = new NLogFactory( config );
        var expected = config;
        var actual = factory.Configuration;
        Assert.IsNotNull( actual );
        Assert.AreEqual( expected, actual );
    }

    [TestMethod]
    public void CreateLogger_ShouldReturnNLogLoggerInstance()
    {
    }
}
