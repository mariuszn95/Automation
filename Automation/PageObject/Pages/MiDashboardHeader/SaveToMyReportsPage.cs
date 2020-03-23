namespace Automation.PageObject.Pages.MiDashboardHeader
{
    using System.Reflection;

    using Automation.Elements.Basic;
    using Automation.Helpers.DriverHelpers;
    using Automation.Helpers.Logger;
    using Automation.PageObject.Locators.MiDashboardHeader;

    using NUnit.Framework;

    public class SaveToMyReportsPage
    {
        private Input ReportNameInput => new Input(SaveToMyReportsLocators.ReportNameInput);

        private Label ErrorMessage => new Label(SaveToMyReportsLocators.ErrorMessage);

        private Checkbox ReportNameContainsNoCidCheckBox => new Checkbox(SaveToMyReportsLocators.ReportNameContainsNoCidCheckBox);

        private Button SubmitButton => new Button(SaveToMyReportsLocators.SubmitButton);

        public SaveToMyReportsPage CheckReportNameContainsNoCidCheckBox()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Wait.ForDocumentLoaded();
            this.ReportNameContainsNoCidCheckBox.Check();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public ReportsMenuPage ClickSubmit()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.SubmitButton.ClickByJs();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsMenuPage();
        }

        public SaveToMyReportsPage TryClickSubmit()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.SubmitButton.ClickByJs();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public SaveToMyReportsPage VerifyProposedName(string reportName)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, reportName);

            Assert.AreEqual(reportName, this.ReportNameInput.GetValue());

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, reportName);

            return this;
        }

        public SaveToMyReportsPage VerifyErrorMessage(string errorMessage)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, errorMessage);

            Assert.AreEqual(errorMessage, this.ErrorMessage.GetText());

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, errorMessage);

            return this;
        }

        public SaveToMyReportsPage ChangeReportNameTo(string newName)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, newName);

            this.ReportNameInput.EnterValueByJs(newName);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, newName);

            return this;
        }
    }
}