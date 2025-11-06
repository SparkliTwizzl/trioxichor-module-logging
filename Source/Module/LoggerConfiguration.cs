namespace SparkliTwizzl.Trioxichor.Logging
{
    public sealed class LoggerConfiguration
    {
        /// <summary>
        /// Log level coloration to use for console logging, if enabled.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Default color map:
        /// </para>
        /// <para>
        /// • <see cref="LogLevel.Trace"/> → <see cref="ConsoleColor.Blue"/>
        /// </para>
        /// <para>
        /// • <see cref="LogLevel.Debug"/> → <see cref="ConsoleColor.Cyan"/>
        /// </para>
        /// <para>
        /// • <see cref="LogLevel.Info"/> → <see cref="ConsoleColor.Green"/>
        /// </para>
        /// <para>
        /// • <see cref="LogLevel.Warning"/> → <see cref="ConsoleColor.Yellow"/>
        /// </para>
        /// <para>
        /// • <see cref="LogLevel.Error"/> → <see cref="ConsoleColor.Red"/>
        /// </para>
        /// <para>
        /// • <see cref="LogLevel.Fatal"/> → <see cref="ConsoleColor.Magenta"/>
        /// </para>
        /// </remarks>
        public Dictionary<LogLevel, ConsoleColor> LogLevelColorMap { get; set; } = new()
        {
            [ LogLevel.Trace ] = ConsoleColor.Blue,
            [ LogLevel.Debug ] = ConsoleColor.Cyan,
            [ LogLevel.Info ] = ConsoleColor.Green,
            [ LogLevel.Warning ] = ConsoleColor.Yellow,
            [ LogLevel.Error ] = ConsoleColor.Red,
            [ LogLevel.Fatal ] = ConsoleColor.Magenta,
        };

        /// <summary>
        /// Logging framework to use.
        /// </summary>
        /// <remarks>
        /// By default, NLog is used.
        /// </remarks>
        public LogFramework LogFramework { get; set; } = LogFramework.NLog;

        /// <summary>
        /// List of log targets to write log messages to.
        /// </summary>
        /// <remarks>
        /// By default, only console logging is enabled.
        /// </remarks>
        public List<LogTarget> LogTargets { get; set; } = new()
        {
            new() { Type = LogTargetType.Console },
        };

        /// <summary>
        /// Minimum <see cref="LogLevel"/> to enable.
        /// Messages at this level and above will be written to logs.
        /// </summary>
        public LogLevel MinimumLogLevel { get; set; } =
#if DEBUG
            LogLevel.Debug;
#else
            LogLevel.Info;
#endif
    }
}
