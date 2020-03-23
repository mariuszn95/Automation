namespace Automation.PageObject.Locators.MiDashboardHeader
{
    using OpenQA.Selenium;

    public class SaveToMyReportsLocators
    {
        public static readonly By ErrorMessage = By.CssSelector(@"mi-save-dialog .save-dialog__error-msg span");
        public static readonly By ReportNameContainsNoCidCheckBox = By.CssSelector(@".checkbox");
        public static readonly By ReportNameInput = By.CssSelector(@".save-dialog__report-name-input");
        public static readonly By ReportNameInputClear = By.CssSelector(@".save-dialog__report-name-input");
        public static readonly By SubmitButton = By.CssSelector(@".save-dialog__button--submit");
    }
}