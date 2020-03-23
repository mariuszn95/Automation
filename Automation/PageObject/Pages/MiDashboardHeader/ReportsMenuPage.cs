namespace Automation.PageObject.Pages.MiDashboardHeader
{
    using System.Reflection;

    using Automation.Elements.Basic;
    using Automation.Helpers.DriverHelpers;
    using Automation.Helpers.Logger;
    using Automation.PageObject.Locators.MiDashboardHeader;
    using Automation.PageObject.Locators.Report;
    using Automation.PageObject.Pages.MiDashboardHeader.Navigation;

    using OpenQA.Selenium;

    public class ReportsMenuPage
    {
        public MyClient MyClient => new MyClient();

        public MyContribution MyContribution => new MyContribution();

        public MySales MySales => new MySales();

        public MyTrend MyTrend => new MyTrend();

        private Button ReportsMenuButton => new Button(MiDashboardHeaderLocators.Reports);

        private Button ThirteenMonthsButton => new Button(ReportHeaderLocators.ThirteenMonthsButton);

        internal void Open(string reportName, string cluster = null)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, reportName, cluster);

            this.ReportsMenuButton.ClickByJs();
            Wait.ForElement(MiDashboardHeaderLocators.Menu);
            var report = new Button(cluster == null
                ? By.XPath($@"//div[@class='dashboard-header']//li[contains(text(),'{reportName}')]")
                : By.XPath($@"//h2[contains(text(),'{cluster}')]/..//li[contains(text(),'{reportName}')]"));
            report.ClickByJs();

            Wait.ForRollerOnReportsToGoAway();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, reportName, cluster);
        }

        internal void ClickThirteenMonthsButton()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.ThirteenMonthsButton.Click();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        internal void OpenThirteenMonths(string thirteenMonthsReportName, string cluster = null)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, thirteenMonthsReportName, cluster);

            var reportName = thirteenMonthsReportName.Remove(thirteenMonthsReportName.Length - 4);
            this.Open(reportName, cluster);
            this.ClickThirteenMonthsButton();
            Wait.ForRollerOnReportsToGoAway();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, thirteenMonthsReportName, cluster);
        }
    }
}