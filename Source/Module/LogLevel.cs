namespace SparkliTwizzl.Trioxichor.Logging
{
    [Flags]
    public enum LogLevel
    {
        Fatal = 0x1,
        Error = 0x2,
        Warning = 0x4,
        Info = 0x8,
        Debug = 0x10,
        Trace = 0x20,
        All = Fatal | Error | Warning | Info | Debug | Trace,
    }
}
