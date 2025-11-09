namespace SparkliTwizzl.Trioxichor.Logging;

/// <summary>Defines the types of logging targets available.</summary>
public enum LogTargetType
{
    ColorlessConsole,
    ColoredConsole,
    Json,
}

/// <summary>Represents a logging target configuration.</summary>
public sealed class LogTarget
{
    /// <summary>
    /// The type of this log target.
    /// </summary>
    public LogTargetType Type { get; set; }

    /// <summary>File path for file-based targets.</summary>
    /// <remarks>
    /// <para>Ignored for console targets.</para>
    /// </remarks>
    public string FilePath { get; set; } = string.Empty;
}
