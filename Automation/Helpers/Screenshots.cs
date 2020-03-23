namespace Automation.Helpers
{
    using System;

    using Automation.Driver;

    using OpenQA.Selenium;

    public class Screenshots
    {
#pragma warning disable CS0169 // The field 'Screenshots.date' is never used
        private static string date;
#pragma warning restore CS0169 // The field 'Screenshots.date' is never used

        private static string screenshotPath;

        public static string ScreenshotPath => screenshotPath;

        public static void Capture(string testName, string path)
        {
            try
            {
                screenshotPath = $"{path}\\{DateTime.Now.ToString("yyyyMMdd-HHmmss")}-{testName}.jpg";
                var screenshot = ((ITakesScreenshot)DriverSingleton.Driver).GetScreenshot();
                screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Jpeg);
            }
            catch (Exception e)
            {
                Console.WriteLine("Screenshot cannot be saved: {0}", e.Message);
            }
        }
    }
}