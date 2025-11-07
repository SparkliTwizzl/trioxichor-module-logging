namespace SparkliTwizzl.Trioxichor.Logging
{
    /// <summary>Logging severity levels.</summary>
    public enum LogLevel
    {
        /// <summary>The most verbose and detailed logs.</summary>
        /// <remarks>
        /// <para>Disabled by default.</para>
        /// <para>May contain sensitive data.</para>
        /// <para>This level should never be enabled in production.</para>
        /// </remarks>
        Trace = 0,

        /// <summary>Logs used to aid in development.</summary>
        /// <remarks>
        /// <para>Disabled in Release mode by default.</para>
        /// <para>Should primarily be used for debugging.</para>
        /// <para>Messages should have no long-term value.</para>
        /// </remarks>
        Debug = 1,

        /// <summary>Logs for tracking general application flow.</summary>
        /// <remarks>
        /// <para>Messages should have long-term value.</para>
        /// <para>Should not be used for detailed debugging.</para>
        /// </remarks>
        Info = 2,

        /// <summary>Logs that indicate abnormal or unexpected behavior which did not prevent an action from continuing.</summary>
        Warning = 3,

        /// <summary>Logs that indicate that execution of an action failed, but the application can recover.</summary>
        /// <remarks>
        /// <para>Should not be used for application-wide failures.</para>
        /// </remarks>
        Error = 4,

        /// <summary>Logs that indicate a catastrophic failure, such as an application or system crash.</summary>
        /// <remarks>
        /// <para>Should only be used for unrecoverable failures.</para>
        /// </remarks>
        Fatal = 5,

        /// <summary>Used to disable writing messages from a logging category.</summary>
        /// <remarks>
        /// <para>Not used for writing log messages.</para>
        /// </remarks>
        None = 6,
    }
}
