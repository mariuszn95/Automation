namespace Automation.Helpers.Logger
{
    public class LoggerTestContexts
    {
        private static readonly string Dashes = "----- TestContexts ----- ";

        public static void LogEnd(string message)
        {
            Logger.InternalLog($"{Dashes} End  - {message}");
        }

        public static void LogReturn(string message)
        {
            Logger.InternalLog($"{Dashes}Return - {message}");
        }

        public static void LogStart(string message)
        {
            Logger.InternalLog($"{Dashes}Start - {message}");
        }
    }
}