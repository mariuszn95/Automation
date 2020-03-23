namespace Automation.Helpers.DriverHelpers
{
    using Automation.Driver;
    using Automation.Helpers.Logger;
    using Automation.PageObject.Pages;
    using Automation.PageObject.Pages.Report;

    public class Actions
    {
        private readonly MiDashboardPage miDashboardPage;

        public Actions()
        {
            this.miDashboardPage = new MiDashboardPage();
        }

        public static void ClearCookies()
        {
            LoggerSelenium.LogStart(System.Reflection.MethodBase.GetCurrentMethod().Name);

            DriverSingleton.Driver.Manage().Cookies.DeleteAllCookies();

            LoggerSelenium.LogEnd(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public static void ClearCookiesAndCloseBrowser()
        {
            LoggerSelenium.LogStart(System.Reflection.MethodBase.GetCurrentMethod().Name);

            DriverSingleton.Driver.Manage().Cookies.DeleteAllCookies();
            DriverSingleton.Dispose();

            LoggerSelenium.LogEnd(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public static string GetCurrentUrl()
        {
            LoggerSelenium.LogReturn(System.Reflection.MethodBase.GetCurrentMethod().Name);

            return DriverSingleton.Driver.Url;
        }

        public static void Refresh()
        {
            LoggerSelenium.LogStart(System.Reflection.MethodBase.GetCurrentMethod().Name);

            DriverSingleton.Driver.Navigate().Refresh();
            Wait.ForDocumentLoaded();

            LoggerSelenium.LogEnd(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public void ClearStorage()
        {
            LoggerSelenium.LogStart(System.Reflection.MethodBase.GetCurrentMethod().Name);

            JsExecutor.ClearSessionStorage();
            Wait.FromSeconds(1);

            LoggerSelenium.LogEnd(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public void OpenMiDashboardPage()
        {
            LoggerSelenium.LogStart(System.Reflection.MethodBase.GetCurrentMethod().Name);

            Navigate.ToMiDashboard();
            this.miDashboardPage.WaitForMiDashboardLoaded();

            LoggerSelenium.LogEnd(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public void OpenReportsPage()
        {
            LoggerSelenium.LogStart(System.Reflection.MethodBase.GetCurrentMethod().Name);

            Navigate.ToMiDashboardReports();
            this.miDashboardPage.WaitForMiDashboardLoaded();

            LoggerSelenium.LogEnd(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public void CloseAllOpenedReports()
        {
            Navigate.ToMiDashboardReports();

            while (new ReportsPage().DashboardTabCloseButton.Count() > 0)
            {
                new ReportsPage().CloseDashboardTab();
            }
        }
    }
}