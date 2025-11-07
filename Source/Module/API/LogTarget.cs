namespace SparkliTwizzl.Trioxichor.Logging
{
    public enum LogTargetType
    {
        Console,
        Json,
    }

    public sealed class LogTarget
    {
        /// <summary>
        /// Type of log target.
        /// </summary>
        public LogTargetType Type { get; set; }

        /// <summary>
        /// File path for file-based log targets.
        /// Ignored for console log targets.
        /// </summary>
        public string FilePath { get; set; } = string.Empty;
    }
}
