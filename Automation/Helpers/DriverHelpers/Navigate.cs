namespace Automation.Helpers.DriverHelpers
{
    using Automation.Driver;
    using Automation.Helpers;
    using Automation.Helpers.Logger;

    public class Navigate
    {
        public static void ToUrl(string url)
        {
            LoggerSelenium.LogStart(System.Reflection.MethodBase.GetCurrentMethod().Name, url);

            DriverSingleton.Driver.Navigate().GoToUrl(url);

            LoggerSelenium.LogEnd(System.Reflection.MethodBase.GetCurrentMethod().Name, url);
        }

        public static void ToMiDashboard(string url = "")
        {
            LoggerSelenium.LogStart(System.Reflection.MethodBase.GetCurrentMethod().Name);

            DriverSingleton.Driver.Navigate().GoToUrl($"{TestContexts.BaseAddress}/{url}");

            LoggerSelenium.LogEnd(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public static void ToMiDashboardBooklets()
        {
            LoggerSelenium.LogStart(System.Reflection.MethodBase.GetCurrentMethod().Name);

            DriverSingleton.Driver.Navigate().GoToUrl($"{TestContexts.BaseAddress}/booklets");

            LoggerSelenium.LogEnd(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public static void ToMiDashboardReports()
        {
            LoggerSelenium.LogStart(System.Reflection.MethodBase.GetCurrentMethod().Name);

            DriverSingleton.Driver.Navigate().GoToUrl($"{TestContexts.BaseAddress}/reports");

            LoggerSelenium.LogEnd(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public static void ToMiDashboardWorkspace()
        {
            LoggerSelenium.LogStart(System.Reflection.MethodBase.GetCurrentMethod().Name);

            DriverSingleton.Driver.Navigate().GoToUrl($"{TestContexts.BaseAddress}/workspace");

            LoggerSelenium.LogEnd(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }
    }
}