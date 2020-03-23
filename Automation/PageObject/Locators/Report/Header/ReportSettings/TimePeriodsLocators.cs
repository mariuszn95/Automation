namespace Automation.PageObject.Locators.Report.Header.ReportSettings
{
    using OpenQA.Selenium;

    internal class TimePeriodsLocators : ReportSettingsLocators
    {
        public static readonly By DefaultView = By.CssSelector("button.time-period-picker__button--active");
        public static readonly By MonthlyButton = By.XPath(@"//button[contains(text(),'Monthly')]");
        public static readonly By YtdButton = By.XPath(@"//button[contains(text(),'YTD')]");
        public static readonly By MonthlyTimePeriodsUnselectedButton = By.XPath(@"//button[contains(text(),'Monthly') and (contains(@class,'time-period-picker__button--active')) ]/../../..//div[contains(@class,'date-item') and not(contains(@class,'selected') or contains(@class,'disabled'))]");
        public static readonly By YtdTimePeriodsUnselectedButton = By.XPath(@"//button[contains(text(),'YTD') and (contains(@class,'time-period-picker__button--active')) ]/../../..//div[contains(@class,'date-item') and not(contains(@class,'selected') or contains(@class,'disabled'))]");
        public static readonly By Last13MonthsButton = By.XPath(@"//button[contains(text(),'Last 13 months')]");
        public static readonly By CurrentYearButton = By.XPath(@"//button[contains(text(),'Current year')]");
    }
}