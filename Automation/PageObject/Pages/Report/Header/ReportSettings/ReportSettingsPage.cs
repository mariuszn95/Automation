namespace Automation.PageObject.Pages.Report.Header.ReportSettings
{
    using System.Reflection;

    using Automation.Elements.Basic;
    using Automation.Helpers.Logger;
    using Automation.PageObject.Locators.Report.Header.ReportSettings;
    using Automation.PageObject.Pages.Report;

    public class ReportSettingsPage
    {
        private Button ValueTypesButton => new Button(ReportSettingsLocators.ValueTypesButton);

        private Button AttributesButton => new Button(ReportSettingsLocators.AttributesButton);

        private Button TimePeriodsButton => new Button(ReportSettingsLocators.TimePeriodsButton);

        internal Button XButton => new Button(ReportSettingsLocators.XButton);

        internal Button CancelButton => new Button(ReportSettingsLocators.CancelButton);

        internal Button SubmitButton => new Button(ReportSettingsLocators.SubmitButton);

        public ValueTypesPage ClickValueTypes()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.ValueTypesButton.Click();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ValueTypesPage();
        }

        public AttributesPage ClickAttributes()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.AttributesButton.Click();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new AttributesPage();
        }

        public TimePeriodsPage ClickTimePeriods()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.TimePeriodsButton.Click();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new TimePeriodsPage();
        }

        public ReportsPage ClickCancelButton()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.CancelButton.Click();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage ClickSubmitButton()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.SubmitButton.Click();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }
    }
}