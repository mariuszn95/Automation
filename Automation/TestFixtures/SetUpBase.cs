namespace Automation.TestFixtures
{
    using Automation.Helpers;
    using Automation.Helpers.DriverHelpers;
    using Automation.Helpers.Logger;
    using Automation.PageObject.Entities;
    using Automation.PageObject.Pages;

    using NUnit.Framework;

    public class SetUpBase
    {
        private readonly Actions actions;
        private readonly DisclaimerPage disclaimerPage;

        public SetUpBase()
        {
            this.actions = new Actions();
            this.disclaimerPage = new DisclaimerPage();
            this.MiDashboardPage = new MiDashboardPage();
        }

        public MiDashboardPage MiDashboardPage { get; }

        public void SetUpDashboardTestFixture(ReportsEntity reportData = null)
        {
            this.actions.ClearStorage();

            try
            {
                this.OpenMiDashboardOnce();
            }
            catch
            {
                Logger.Log("Second try to log in into application");
                Navigate.ToMiDashboard();
                this.OpenMiDashboardOnce();
            }

            this.DataLoadStatusConfig();

            TestRetryCounter.SetCurrentTestNameAndCounter();
            Logger.Log(TestContext.CurrentContext.Test.ClassName);
            Logger.Log(TestContext.CurrentContext.Test.MethodName);
            TestRetryCounter.PrintRetryCounter();
            if (reportData != null)
            {
                Logger.Log($"Report Code: {reportData.Code}");
                Logger.Log($"Organization Unit: {reportData.PoV.OrganizationUnit}");
                Logger.Log($"Business Group: {reportData.PoV.BusinessGroup}");
                Logger.Log($"Business Function: {reportData.PoV.BusinessFunction}");
            }

            this.actions.OpenReportsPage();

            Wait.FromSeconds(1);
        }

        private void OpenMiDashboardOnce()
        {
            this.disclaimerPage.AcceptDisclaimerIfNotAcceptedYet();
            this.MiDashboardPage.WaitForMiDashboardLoaded();
        }

        private void DataLoadStatusConfig()
        {
            if (DataLoadStatusHelper.ConfigurationExists)
            {
                DataLoadStatusHelper.LoadConfiguration();
            }
            else
            {
                DataLoadStatusPage page = this.MiDashboardPage.OpenDataLoadStatus();
                DataLoadStatusHelper.SaveConfiguration(page);
            }
        }
    }
}