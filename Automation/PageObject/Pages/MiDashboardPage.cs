namespace Automation.PageObject.Pages
{
    using System.Collections.ObjectModel;
    using System.Reflection;

    using Automation.Elements.Basic;
    using Automation.Helpers;
    using Automation.Helpers.DriverHelpers;
    using Automation.Helpers.Extensions;
    using Automation.Helpers.Logger;
    using Automation.PageObject.Locators.MiDashboardHeader;
    using Automation.PageObject.Pages.MiDashboardHeader;
    using Automation.PageObject.Pages.Report;
    using Automation.PageObject.Pages.Report.Header;

    using NUnit.Framework;

    using OpenQA.Selenium;

    public enum Icon
    {
        Enabled,

        Disabled,
    }

    public class MiDashboardPage : PovPage
    {
        private readonly ElementHelpers elementHelpers;

        private readonly MiDashboardHeaderPage miDashboardHeaderPage;

        private readonly By homePageRoller = By.CssSelector("mi-layout > mi-spinner .lds-roller");

        private readonly By dashboardHeader = By.CssSelector(".dashboard-header");

        public MiDashboardPage()
        {
            this.elementHelpers = new ElementHelpers();
            this.miDashboardHeaderPage = new MiDashboardHeaderPage();
        }

        public ReportsMenuPage Reports => new ReportsMenuPage();

        public void CheckWidgetTitleNotAllowed(string widgetTitle)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Assert.IsTrue(
                ElementHelpers.GetCursorValue(By.XPath($"//div[contains(text(),'{widgetTitle}')]"))
                    .Equals("not-allowed"));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public ReportsPage ClickWidgetTitle(string widgetTitle)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, widgetTitle);

            var widgetTitleButton = new Button(By.XPath($"//div[contains(text(),'{widgetTitle}')]"));
            widgetTitleButton.ClickByJs();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, widgetTitle);

            return new ReportsPage();
        }

        public void VerifyThatThereAreNoSavedReportsAndIfTheyAreThenDeleteThem()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            if (this.miDashboardHeaderPage.MySavedReports.IsLinkActive())
            {
                this.miDashboardHeaderPage.MySavedReportsPage.DeleteAllSavedReports();
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public void VerifyThatThereAreSavedReportsAndIfTheyAreNotThenAddThem()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            if (!this.miDashboardHeaderPage.MySavedReports.IsLinkActive())
            {
                this.OpenAnyReport();
                new ReportsHeaderPage()
                    .ClickSaveIcon()
                    .CheckReportNameContainsNoCidCheckBox()
                    .ClickSubmit();
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public MiDashboardPage OpenAnyReport()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            var report = RandomData.GetReport();

            this.SetPoV(report.PoV);
            this.OpenReport(report.Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new MiDashboardPage();
        }

        public ReportsPage OpenReport(string reportName, string cluster = null)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, reportName, cluster);

            Navigate.ToMiDashboardReports();

            if (ValidateReportAlreadyOpened(reportName, cluster))
            {
                return new ReportsPage();
            }

            this.OpenReportNext(reportName, cluster);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, reportName, cluster);

            return new ReportsPage();
        }

        private static bool ValidateReportAlreadyOpened(string reportName, string cluster)
        {
            var title = cluster == "My Trend" ? $"NNA Trend - {reportName}" : $"{cluster} - {reportName}";

            return new ReportsHeaderElements().ReportTitle.GetIfAvaiable() != null && title.Equals(new ReportsHeaderElements().ReportTitle.GetText());
        }

        public ReportsPage OpenReportNext(string reportName, string cluster = null)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, reportName, cluster);

            if (reportName.Contains("13m"))
            {
                this.Reports.OpenThirteenMonths(reportName, cluster);
            }
            else
            {
                this.Reports.Open(reportName, cluster);
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, reportName, cluster);

            return new ReportsPage();
        }

        public ReportsPage OpenMySavedReport(string reportName)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, reportName);

            this.miDashboardHeaderPage.MySavedReportsPage.Open(reportName);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, reportName);

            return new ReportsPage();
        }

        public DataLoadStatusPage OpenDataLoadStatus()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            new Button(By.CssSelector(".bn-calendar-white")).Click();
            Wait.Until(d => d.FindElement(By.XPath("//article/section[2]")));
            ReadOnlyCollection<IWebElement> dataLoadStatuscells = this.elementHelpers.FindElements(By.CssSelector(".font__size--small"));

            if (dataLoadStatuscells.Count < 10)
            {
                Wait.FromSeconds(8);
                dataLoadStatuscells = this.elementHelpers.FindElements(By.CssSelector(".font__size--small"));
            }

            DataLoadStatusPage page = new DataLoadStatusPage(
                dataLoadStatuscells[1].Text,
                dataLoadStatuscells[2].Text,
                dataLoadStatuscells[3].Text,
                dataLoadStatuscells[5].Text,
                dataLoadStatuscells[7].Text);

            new Button(By.XPath(@"//*[@class='fas fa-times']")).Click();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return page;
        }

        public void VerifyApplicationTitle(string title)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Assert.AreEqual(title, this.elementHelpers.GetPageTitle());

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public void VerifyBookletsOpened()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Assert.IsTrue(Actions.GetCurrentUrl().Contains($"{TestContexts.BaseAddress}/booklets"));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public MiDashboardPage VerifyReportsOpened()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Assert.IsTrue(Actions.GetCurrentUrl().Contains($"{TestContexts.BaseAddress}/reports"));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public MiDashboardPage VerifyWidgetsOpened()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Assert.IsTrue(Actions.GetCurrentUrl().Contains(TestContexts.BaseAddress));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public MiDashboardPage WaitForDashboardTopBarLoaded()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(this.dashboardHeader));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public MiDashboardPage WaitForMiDashboardLoaded()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.WaitForHomePageLoaded();
            this.miDashboardHeaderPage.Reports.WaitForIt();
            Wait.Until(d => d.FindElement(MiDashboardHeaderLocators.Reports).GetCssValue("cursor").Equals("pointer"));
            Assert.IsTrue(this.miDashboardHeaderPage.Reports.IsLinkActive());
            Assert.IsTrue(Actions.GetCurrentUrl().Contains(TestContexts.BaseAddress));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public MiDashboardPage WaitForHomePageLoaded()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Wait.ForElementToLeave(this.homePageRoller, DriverConsts.ThreeMinInMilliseconds);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }
    }
}