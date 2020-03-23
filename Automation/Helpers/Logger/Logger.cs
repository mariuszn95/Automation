namespace Automation.Helpers.Logger
{
    using System;

    using AventStack.ExtentReports.Utils;

    public static class Logger
    {
        public static void Log(params object[] values)
        {
            Log(string.Format(ParseParamsToString(values)));
        }

        public static void Log(string message)
        {
            Console.WriteLine($"{DateTime.Now} : ***** {message}");
        }

        internal static void InternalLog(string message)
        {
            Console.WriteLine($"{DateTime.Now} : {message}");
        }

        internal static string ParseParamsToString(params object[] values)
        {
            string message = string.Empty;

            foreach (var value in values)
            {
                if (!message.IsNullOrEmpty())
                {
                    message += ", ";
                }

                message += value;
            }

            return message;
        }
    }
}