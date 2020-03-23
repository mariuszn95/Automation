namespace Automation.PageObject.Locators.Report.Header.ReportSettings
{
    using OpenQA.Selenium;

    internal class ReportSettingsLocators
    {
        public static readonly By ValueTypesButton = By.CssSelector("#indicators");
        public static readonly By AttributesButton = By.CssSelector("#attributes");
        public static readonly By TimePeriodsButton = By.CssSelector("#timePeriods");
        public static readonly By XButton = By.CssSelector("button.settings__button--close");
        public static readonly By CancelButton = By.CssSelector("button.settings__button--cancel");
        public static readonly By SubmitButton = By.CssSelector("button.settings__button--submit");
    }
}