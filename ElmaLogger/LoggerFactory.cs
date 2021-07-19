using ElmaLogger.Contract;

namespace ElmaLogger
{
    public static class LoggerFactory
    {
        public static IElmaLogger Create()
            => new ElmaLogger();
        
        public static IElmaLogger Create(string methodName)
            => new ElmaLogger(methodName);
        
        public static IElmaLogger Create(object context)
            => new ElmaLogger(context);
        
        public static IElmaLogger Create(string methodName, object context)
            => new ElmaLogger(methodName, context);
    }
}