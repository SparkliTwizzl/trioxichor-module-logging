namespace SparkliTwizzl.Trioxichor.Logging
{
    /// <summary>
    /// Simple logging wrapper interface.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Log level defaults to <see cref="LogLevel.Debug"/> in Debug mode and <see cref="LogLevel.Info"/> in Release mode unless manually configured.
    /// </para>
    /// <para>
    /// Implementations should defer calling a message's <see cref="object.ToString()"/> method until the message needs to be logged for performance reasons.
    /// </para>
    /// </remarks>
    public interface ILogger
    {
        /// <summary>
        /// Log a message with level <see cref="LogLevel.Debug"/>.
        /// </summary>
        /// <param name="message">Message to log.</param>
        void LogDebug( object message );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Debug"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="message">Message to log.</param>
        void LogDebug( object message, params object[] args );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Debug"/>.
        /// </summary>
        /// <param name="exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void LogDebug( Exception exception, object message );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Debug"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void LogDebug( Exception exception, object message, params object[] args );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Debug"/>.
        /// </summary>
        /// <remarks>
        /// Message factory is only invoked if the message is actually logged, which can improve performance when the log level is disabled.
        /// </remarks>
        /// <param name="messageFactory">Function to generate the message to log.</param>
        void LogDebug( Func<string> messageFactory );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Error"/>.
        /// </summary>
        /// <param name="message">Message to log.</param>
        void LogError( object message );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Error"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="message">Message to log.</param>
        void LogError( object message, params object[] args );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Error"/>.
        /// </summary>
        /// <param name="exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void LogError( Exception exception, object message );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Error"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void LogError( Exception exception, object message, params object[] args );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Error"/>.
        /// </summary>
        /// <remarks>
        /// Message factory is only invoked if the message is actually logged, which can improve performance when the log level is disabled.
        /// </remarks>
        /// <param name="messageFactory">Function to generate the message to log.</param>
        void LogError(Func<string> messageFactory);

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Fatal"/>.
        /// </summary>
        /// <param name="message">Message to log.</param>
        void LogFatal( object message );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Fatal"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="message">Message to log.</param>
        void LogFatal( object message, params object[] args );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Fatal"/>.
        /// </summary>
        /// <param name="exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void LogFatal( Exception exception, object message );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Fatal"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void LogFatal( Exception exception, object message, params object[] args );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Fatal"/>.
        /// </summary>
        /// <remarks>
        /// Message factory is only invoked if the message is actually logged, which can improve performance when the log level is disabled.
        /// </remarks>
        /// <param name="messageFactory">Function to generate the message to log.</param>
        void LogFatal(Func<string> messageFactory);

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Info"/>.
        /// </summary>
        /// <param name="message">Message to log.</param>
        void LogInfo( object message );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Info"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="message">Message to log.</param>
        void LogInfo( object message, params object[] args );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Info"/>.
        /// </summary>
        /// <param name="exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void LogInfo( Exception exception, object message );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Info"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void LogInfo( Exception exception, object message, params object[] args );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Info"/>.
        /// </summary>
        /// <remarks>
        /// Message factory is only invoked if the message is actually logged, which can improve performance when the log level is disabled.
        /// </remarks>
        /// <param name="messageFactory">Function to generate the message to log.</param>
        void LogInfo(Func<string> messageFactory);

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Trace"/>.
        /// </summary>
        /// <param name="message">Message to log.</param>
        void LogTrace( object message );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Trace"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="message">Message to log.</param>
        void LogTrace( object message, params object[] args );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Trace"/>.
        /// </summary>
        /// <param name="exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void LogTrace( Exception exception, object message );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Trace"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void LogTrace( Exception exception, object message, params object[] args );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Trace"/>.
        /// </summary>
        /// <remarks>
        /// Message factory is only invoked if the message is actually logged, which can improve performance when the log level is disabled.
        /// </remarks>
        /// <param name="messageFactory">Function to generate the message to log.</param>
        void LogTrace(Func<string> messageFactory);

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Warning"/>.
        /// </summary>
        /// <param name="message">Message to log.</param>
        void LogWarning( object message );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Warning"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="message">Message to log.</param>
        void LogWarning( object message, params object[] args );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Warning"/>.
        /// </summary>
        /// <param name="exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void LogWarning( Exception exception, object message );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Warning"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void LogWarning( Exception exception, object message, params object[] args );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Warning"/>.
        /// </summary>
        /// <remarks>
        /// Message factory is only invoked if the message is actually logged, which can improve performance when the log level is disabled.
        /// </remarks>
        /// <param name="messageFactory">Function to generate the message to log.</param>
        void LogWarning(Func<string> messageFactory);
    }
}
