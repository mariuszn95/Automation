namespace Automation.TestFixtures
{
    using Automation.Driver;
    using Automation.Helpers;
    using Automation.Helpers.DriverHelpers;
    using Automation.PageObject.Locators.MiDashboardHeader;
    using Automation.PageObject.Pages.Report;

    using NUnit.Framework;
    using NUnit.Framework.Interfaces;

    using OpenQA.Selenium;

    public class TearDownBase
    {
        public void TearDownDashboardTestFixture()
        {
            VerifyExpectedErrorOccurred();

            TestStatus status = TestContext.CurrentContext.Result.Outcome.Status;

            if (status == TestStatus.Failed)
            {
                this.CaptureScreenshot();
                this.CaptureDom();
                DriverSingleton.Dispose();
            }
            else
            {
                CloseAllOpenedReports();
            }

            TestRetryCounter.SetPreviousTestName();
        }

        public void CaptureScreenshot()
        {
            Screenshots.Capture(
                TestContext.CurrentContext.Test.FullName.Replace("\"", string.Empty).Substring(22),
                TestContexts.ArtifactsPath);
        }

        public void CaptureDom()
        {
            Dom.Capture(
                TestContext.CurrentContext.Test.FullName.Replace("\"", string.Empty).Substring(22),
                TestContexts.ArtifactsPath);
        }

        private static void CloseAllOpenedReports()
        {
            Navigate.ToMiDashboardReports();

            while (new ReportsPage().DashboardTabCloseButton.Count() > 1)
            {
                new ReportsPage().CloseDashboardTab();
            }
        }

        private static void VerifyExpectedErrorOccurred()
        {
            ElementHelpers elementHelpers = new ElementHelpers();

            var disclaimer = elementHelpers.FindElement(By.CssSelector("mi-disclaimer"), false);
            var error = elementHelpers.FindElement(By.XPath("//div[contains(text(),'An error occured while processing your request')]"), false);
            var reportsMenuButton = elementHelpers.FindElement(MiDashboardHeaderLocators.Reports).GetCssValue("cursor").Equals("default");
            var maintenanceInfo = elementHelpers.FindElement(By.XPath("//div[contains(text(),'An error occurred. Please try again. If the problem continues, contact application administrator.')]"), false);
            var maintenanceUrl = Actions.GetCurrentUrl().Contains("maintenance");
            if (disclaimer != null)
            {
                Helpers.Logger.Logger.Log("*******************************************");
                Helpers.Logger.Logger.Log("********** A disclaimer occured  **********");
                Helpers.Logger.Logger.Log("*******************************************");
            }

            if (error != null)
            {
                Helpers.Logger.Logger.Log("********************************************************************");
                Helpers.Logger.Logger.Log("********** An error occured while processing your request **********");
                Helpers.Logger.Logger.Log("********************************************************************");
            }

            if (reportsMenuButton)
            {
                Helpers.Logger.Logger.Log("********************************************");
                Helpers.Logger.Logger.Log("********** Reports are not loaded **********");
                Helpers.Logger.Logger.Log("********************************************");
            }

            if (maintenanceInfo != null)
            {
                Helpers.Logger.Logger.Log("***********************************************************************************************************************");
                Helpers.Logger.Logger.Log("********** An error occurred. Please try again. If the problem continues, contact application administrator. **********");
                Helpers.Logger.Logger.Log("***********************************************************************************************************************");
            }

            if (maintenanceUrl)
            {
                Helpers.Logger.Logger.Log("**********************************************");
                Helpers.Logger.Logger.Log("********** Maintenance Url appeared **********");
                Helpers.Logger.Logger.Log("**********************************************");
            }
        }
 }
}