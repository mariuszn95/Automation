namespace Automation.PageObject.Pages.MiDashboardHeader
{
    using System.Reflection;

    using Automation.Elements.Basic;
    using Automation.Helpers.Logger;
    using Automation.PageObject.Locators.MiDashboardHeader;

    using AventStack.ExtentReports.Utils;

    using NUnit.Framework;

    public class MiDashboardHeaderPage
    {
        public MySavedReportsPage MySavedReportsPage => new MySavedReportsPage();

        private Label UserAvatar => new Label(MiDashboardHeaderLocators.UserAvatar);

        private Label Username => new Label(MiDashboardHeaderLocators.Username);

        private Button ReportWorkspaceIcon => new Button(MiDashboardHeaderLocators.ReportWorkspaceIcon);

        private Button HomeIcon => new Button(MiDashboardHeaderLocators.HomeIcon);

        internal Button Reports => new Button(MiDashboardHeaderLocators.Reports);

        internal Button MySavedReports => new Button(MiDashboardHeaderLocators.MySavedReports);

        private Button Booklets => new Button(MiDashboardHeaderLocators.Booklets);

        private Label Logo => new Label(MiDashboardHeaderLocators.Logo);

        private Button DataLoadStatus => new Button(MiDashboardHeaderLocators.DataLoadStatus);

        private Button Documents => new Button(MiDashboardHeaderLocators.Documents);

        private Button Support => new Button(MiDashboardHeaderLocators.Support);

        public MiDashboardPage ClickReportIcon()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.ReportWorkspaceIcon.Click();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new MiDashboardPage();
        }

        public MiDashboardPage ClickHomeIcon()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.HomeIcon.Click();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new MiDashboardPage();
        }

        public MiDashboardPage ClickBooklets()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.Booklets.Click();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new MiDashboardPage();
        }

        public DocumentsPage ClickDocumentsButton()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.Documents.Click();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new DocumentsPage();
        }

        public SupportPage ClickSupportButton()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.Support.Click();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new SupportPage();
        }

        public void VerifyMiDashboardContainsAvatar()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Assert.IsTrue(this.UserAvatar.GetCssValue("background-image").Contains("url(\"https://bi2mbis-stbi-dev.csintra.net:6646/mi_dashboard_api/api/user?pid="));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public void VerifyThatUsernameIsNotEmpty()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Assert.IsFalse(this.Username.GetText().IsNullOrEmpty());

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public void VerifyReportWorkspaceIconIsUnderlined()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.ReportWorkspaceIcon.MouseOver();
            Assert.IsTrue(this.ReportWorkspaceIcon.GetAttribute("style").Contains("border-bottom-color: rgb(255, 255, 255);"));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public void VerifyReportWorkspaceIconIsVisible()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.ReportWorkspaceIcon.IsVisible();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public MiDashboardPage VerifyReportIconNotAllowed()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Assert.IsTrue(this.ReportWorkspaceIcon.GetCssValue("cursor").Equals("default"));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new MiDashboardPage();
        }

        public void VerifyHomeIconIsUnderlined()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.HomeIcon.MouseOver();
            Assert.IsTrue(this.HomeIcon.GetAttribute("style").Contains("border-bottom-color: rgb(255, 255, 255);"));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public void VerifyReportsIsUnderlined()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.Reports.MouseOver();
            Assert.IsTrue(this.Reports.GetAttribute("style").Contains("border-bottom-color: rgb(255, 255, 255);"));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public void VerifyReportsIsVisible()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.Reports.IsVisible();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public void VerifyMySavedReportsIsUnderlined()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.MySavedReports.MouseOver();
            Assert.IsTrue(this.MySavedReports.GetAttribute("style").Contains("border-bottom-color: rgb(255, 255, 255);"));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public void VerifyMySavedReportsIsVisible()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.MySavedReports.IsVisible();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public void VerifyBookletsIsUnderlined()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.Booklets.MouseOver();
            Assert.IsTrue(this.Booklets.GetAttribute("style").Contains("border-bottom-color: rgb(255, 255, 255);"));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public void VerifyBookletsIsVisible()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.Booklets.IsVisible();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public void VerifyApplicationLogo()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Assert.IsTrue(this.Logo.GetAttribute("src").Contains("assets/images/logo.svg"));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public void VerifyDataLoadStatusIsUnderlined()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.DataLoadStatus.MouseOver();
            Assert.IsTrue(this.DataLoadStatus.GetAttribute("style").Contains("border-bottom-color: rgb(255, 255, 255);"));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public void VerifyDataLoadStatusIsVisible()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.DataLoadStatus.IsVisible();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public void VerifyDocumentsIsUnderlined()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.Documents.MouseOver();
            Assert.IsTrue(this.Documents.GetAttribute("style").Contains("border-bottom-color: rgb(255, 255, 255);"));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public void VerifyDocumentsIsVisible()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.Documents.IsVisible();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public void VerifySupportIsUnderlined()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.Support.MouseOver();
            Assert.IsTrue(this.Support.GetAttribute("style").Contains("border-bottom-color: rgb(255, 255, 255);"));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public void VerifySupportIsVisible()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.Support.IsVisible();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }
    }
}