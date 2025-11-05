namespace SparkliTwizzl.Trioxichor.Logging
{
    /// <summary>
    /// Simple logging wrapper interface.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Log level <see cref="LogLevel.Trace"/> is disabled in Release mode.
    /// Log level <see cref="LogLevel.Debug"/> is disabled in Release mode by default, but can be enabled if desired.
    /// </para>
    /// <para>
    /// Implementations should defer calling a message's <see cref="object.ToString()"/> method until the message needs to be logged for performance reasons.
    /// </para>
    /// </remarks>
    public interface ILogger
    {
        void Configure(LogConfig config);

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Debug"/>.
        /// </summary>
        /// <param name="message">Message to log.</param>
        void Debug( object message );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Debug"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="message">Message to log.</param>
        void Debug( object message, params object[] args );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Debug"/>.
        /// </summary>
        /// <param name="Exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void Debug( object message, Exception Exception );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Debug"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="Exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void Debug( object message, Exception Exception, params object[] args );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Debug"/>.
        /// </summary>
        /// <remarks>
        /// The message factory is only invoked if the message is actually logged,
        /// which can improve performance when the log level is disabled.
        /// </remarks>
        /// <param name="messageFactory">Function to generate the message to log.</param>
        void Debug( Func<string> messageFactory );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Error"/>.
        /// </summary>
        /// <param name="message">Message to log.</param>
        void Error( object message );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Error"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="message">Message to log.</param>
        void Error( object message, params object[] args );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Error"/>.
        /// </summary>
        /// <param name="Exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void Error( object message, Exception Exception );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Error"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="Exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void Error( object message, Exception Exception, params object[] args );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Error"/>.
        /// </summary>
        /// <remarks>
        /// The message factory is only invoked if the message is actually logged,
        /// which can improve performance when the log level is disabled.
        /// </remarks>
        /// <param name="messageFactory">Function to generate the message to log.</param>
        void Error(Func<string> messageFactory);

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Fatal"/>.
        /// </summary>
        /// <param name="message">Message to log.</param>
        void Fatal( object message );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Fatal"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="message">Message to log.</param>
        void Fatal( object message, params object[] args );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Fatal"/>.
        /// </summary>
        /// <param name="Exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void Fatal( object message, Exception Exception );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Fatal"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="Exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void Fatal( object message, Exception Exception, params object[] args );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Fatal"/>.
        /// </summary>
        /// <remarks>
        /// The message factory is only invoked if the message is actually logged,
        /// which can improve performance when the log level is disabled.
        /// </remarks>
        /// <param name="messageFactory">Function to generate the message to log.</param>
        void Fatal(Func<string> messageFactory);

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Info"/>.
        /// </summary>
        /// <param name="message">Message to log.</param>
        void Info( object message );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Info"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="message">Message to log.</param>
        void Info( object message, params object[] args );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Info"/>.
        /// </summary>
        /// <param name="Exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void Info( object message, Exception Exception );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Info"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="Exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void Info( object message, Exception Exception, params object[] args );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Info"/>.
        /// </summary>
        /// <remarks>
        /// The message factory is only invoked if the message is actually logged,
        /// which can improve performance when the log level is disabled.
        /// </remarks>
        /// <param name="messageFactory">Function to generate the message to log.</param>
        void Info(Func<string> messageFactory);

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Trace"/>.
        /// </summary>
        /// <param name="message">Message to log.</param>
        void Trace( object message );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Trace"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="message">Message to log.</param>
        void Trace( object message, params object[] args );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Trace"/>.
        /// </summary>
        /// <param name="Exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void Trace( object message, Exception Exception );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Trace"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="Exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void Trace( object message, Exception Exception, params object[] args );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Trace"/>.
        /// </summary>
        /// <remarks>
        /// The message factory is only invoked if the message is actually logged,
        /// which can improve performance when the log level is disabled.
        /// </remarks>
        /// <param name="messageFactory">Function to generate the message to log.</param>
        void Trace(Func<string> messageFactory);

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Warning"/>.
        /// </summary>
        /// <param name="message">Message to log.</param>
        void Warning( object message );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Warning"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="message">Message to log.</param>
        void Warning( object message, params object[] args );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Warning"/>.
        /// </summary>
        /// <param name="Exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void Warning( object message, Exception Exception );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Warning"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="Exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void Warning( object message, Exception Exception, params object[] args );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Warning"/>.
        /// </summary>
        /// <remarks>
        /// The message factory is only invoked if the message is actually logged,
        /// which can improve performance when the log level is disabled.
        /// </remarks>
        /// <param name="messageFactory">Function to generate the message to log.</param>
        void Warning(Func<string> messageFactory);
    }
}
