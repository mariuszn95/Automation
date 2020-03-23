namespace Automation.Helpers
{
    using System;
    using System.IO;

    using Automation.Driver;

    public class Dom
    {
        private static string filePath;

        public static string FilePath => filePath;

        public static void Capture(string testName, string path)
        {
            try
            {
                filePath = $"{path}\\{DateTime.Now.ToString("yyyyMMdd-HHmmss")}-{testName}.html";
                string siteDom = DriverSingleton.Driver.PageSource;

                File.WriteAllText(filePath, siteDom);
            }
            catch (Exception e)
            {
                Console.WriteLine("Screenshot cannot be saved: {0}", e.Message);
            }
        }
    }
}