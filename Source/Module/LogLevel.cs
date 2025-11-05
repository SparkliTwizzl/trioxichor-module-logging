namespace SparkliTwizzl.Trioxichor.Logging
{
    /// <summary>
    /// Logging severity levels.
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// The most verbose and detailed logs.
        /// May contain sensitive data.
        /// Disabled by default.
        /// This level should never be enabled in production.
        /// </summary>
        Trace = 0,

        /// <summary>
        /// Logs used to aid in development.
        /// Should primarily be used for debugging.
        /// Has no long-term value.
        /// Disabled in Release mode by default.
        /// </summary>
        Debug = 1,

        /// <summary>
        /// Logs for tracking general application flow.
        /// Should have long-term value.
        /// Should not be used for detailed debugging.
        /// </summary>
        Info = 2,

        /// <summary>
        /// Logs that indicate abnormal or unexpected behavior which did not prevent an action from continuing.
        /// </summary>
        Warning = 3,

        /// <summary>
        /// Logs that indicate that execution of an action failed, but the application can recover.
        /// Should not be used for application-wide failures.
        /// </summary>
        Error = 4,

        /// <summary>
        /// Logs that indicate a catastrophic failure, such as an application or system crash.
        /// Should only be used for unrecoverable failures.
        /// </summary>
        Fatal = 5,

        /// <summary>
        /// Used to disable writing messages from a logging category.
        /// </summary>
        None = 6,
    }
}
