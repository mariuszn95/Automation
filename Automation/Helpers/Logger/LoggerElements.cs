namespace Automation.Helpers.Logger
{
    public class LoggerElements
    {
        private static readonly string Dashes = "----- ----- ";

        public static void LogEnd(params object[] values)
        {
            Logger.InternalLog($"{Dashes} End  - {Logger.ParseParamsToString(values)}");
        }

        public static void LogReturn(params object[] values)
        {
            Logger.InternalLog($"{Dashes}Return - {Logger.ParseParamsToString(values)}");
        }

        public static void LogStart(params object[] values)
        {
            Logger.InternalLog($"{Dashes}Start - {Logger.ParseParamsToString(values)}");
        }
    }
}