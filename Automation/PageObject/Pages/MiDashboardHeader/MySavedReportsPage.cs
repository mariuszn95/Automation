namespace Automation.PageObject.Pages.MiDashboardHeader
{
    using System.Collections.Generic;
    using System.Reflection;

    using Automation.Elements;
    using Automation.Elements.Basic;
    using Automation.Helpers.DriverHelpers;
    using Automation.Helpers.Logger;
    using Automation.PageObject.Locators.MiDashboardHeader;

    using NUnit.Framework;

    using OpenQA.Selenium;

    public class MySavedReportsPage
    {
        private BasicElement Menu => new BasicElement(MiDashboardHeaderLocators.Menu);

        private Button MySavedReportsMenuButton => new Button(MiDashboardHeaderLocators.MySavedReports);

        private Button SavedReports => new Button(MiDashboardHeaderLocators.SavedReports);

        private Button EditButton => new Button(MiDashboardHeaderLocators.EditButton);

        private Button SelectAllCheckBox => new Button(MiDashboardHeaderLocators.SelectAllCheckBox);

        private Checkbox FirstReportFromListToDelete => new Checkbox(By.CssSelector(@"ng-component li"));

        private Button DeleteSelectedReportsButton => new Button(MiDashboardHeaderLocators.DeleteSelectedReportsButton);

        public void Open(string reportName)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.MySavedReportsMenuButton.ClickByJs();
            Wait.ForElement(MiDashboardHeaderLocators.Menu);
            var report = new Button(By.XPath($@"//div[@class='dashboard-header']//li[contains(text(),'{reportName}')]"));
            report.ClickByJs();
            Wait.ForRollerOnReportsToGoAway();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public MySavedReportsPage ClickEditButton()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.EditButton.Click();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public MySavedReportsPage DeleteAllSavedReports()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.MySavedReportsMenuButton.ClickByJs();
            Wait.ForElement(MiDashboardHeaderLocators.Menu);
            this.ClickEditButton();
            this.SelectAllCheckBox.Click();
            this.DeleteSelectedReportsButton.Click();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public MySavedReportsPage DeleteLastSavedReport()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.FirstReportFromListToDelete.Check();
            this.DeleteSelectedReportsButton.Click();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public MySavedReportsPage VerifyDeletedSavedReport(string reportName)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            if (!this.MySavedReportsMenuButton.IsLinkActive())
            {
                return this;
            }

            this.MySavedReportsMenuButton.Click();
            Assert.IsFalse(new BasicElement(By.XPath($@"//mi-sub-menu//li[contains(text(),'{reportName}')]")).IsVisible());

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public void VerifyOrderSavedReports(List<string> savedReports)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            for (var i = 0; i < savedReports.Count; i++)
            {
                Assert.AreEqual(
                    savedReports[i], this.SavedReports.GetText(savedReports.Count - i - 1));
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public MySavedReportsPage VerifySavedReport(string reportName)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            if (!this.Menu.IsVisible())
            {
                this.MySavedReportsMenuButton.ClickByJs();
            }

            Wait.ForElement(MiDashboardHeaderLocators.Menu);
            Wait.ForElement(By.XPath($@"//div[@class='dashboard-header']//li[contains(text(),'{reportName}')]"));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public void VerifySavedReportsNotExist()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Assert.IsFalse(this.MySavedReportsMenuButton.IsLinkActive());

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }
    }
}