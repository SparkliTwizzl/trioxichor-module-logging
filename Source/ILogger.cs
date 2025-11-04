namespace SparkliTwizzl.Trioxichor.Logging
{
    /// <summary>
    /// Simple, minimal logging wrapper interface.
    /// Implementations should avoid throwing from logging methods.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
		/// Log a message with level <see cref="LogLevel.Debug"/>.
		/// </summary>
        /// <param name="message">Message to log.</param>
        void Debug( string message );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Debug"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="message">Message to log.</param>
        void Debug( string message, params object[] args );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Debug"/>.
        /// </summary>
        /// <param name="exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void Debug( string message, Exception? exception );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Debug"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void Debug( string message, Exception? exception, params object[] args );

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
        void Error( string message );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Error"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="message">Message to log.</param>
        void Error( string message, params object[] args );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Error"/>.
        /// </summary>
        /// <param name="exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void Error( string message, Exception? exception );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Error"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void Error( string message, Exception? exception, params object[] args );

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
        void Fatal( string message );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Fatal"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="message">Message to log.</param>
        void Fatal( string message, params object[] args );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Fatal"/>.
        /// </summary>
        /// <param name="exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void Fatal( string message, Exception? exception );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Fatal"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void Fatal( string message, Exception? exception, params object[] args );

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
        void Info( string message );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Info"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="message">Message to log.</param>
        void Info( string message, params object[] args );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Info"/>.
        /// </summary>
        /// <param name="exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void Info( string message, Exception? exception );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Info"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void Info( string message, Exception? exception, params object[] args );

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
        void Trace( string message );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Trace"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="message">Message to log.</param>
        void Trace( string message, params object[] args );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Trace"/>.
        /// </summary>
        /// <param name="exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void Trace( string message, Exception? exception );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Trace"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void Trace( string message, Exception? exception, params object[] args );

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
        void Warning( string message );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Warning"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="message">Message to log.</param>
        void Warning( string message, params object[] args );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Warning"/>.
        /// </summary>
        /// <param name="exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void Warning( string message, Exception? exception );

        /// <summary>
        /// Log a message with level <see cref="LogLevel.Warning"/>.
        /// </summary>
        /// <param name="args">List of arguments to format the message with.</param>
        /// <param name="exception">Exception to log.</param>
        /// <param name="message">Message to log.</param>
        void Warning( string message, Exception? exception, params object[] args );

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
