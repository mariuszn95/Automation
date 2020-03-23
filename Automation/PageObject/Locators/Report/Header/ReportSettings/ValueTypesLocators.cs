namespace Automation.PageObject.Locators.Report.Header.ReportSettings
{
    using OpenQA.Selenium;

    internal class ValueTypesLocators : ReportSettingsLocators
    {
        public static readonly By SearchValueTypeInput = By.XPath("//h3[contains(text(), 'Value Types')]/../..//*[@class='value-picker__input']");
        public static readonly By SearchResultCheckboxes = By.CssSelector("div.value-picker__items > div");
        public static readonly By SearchResultUncheckedCheckboxes = By.XPath("//h3[contains(text(), 'Value Types in Report')]/../..//span[contains(@class,'checkbox__toggle') and not(contains(@class,'checkbox__toggle--checked'))]/../input");
        public static readonly string SelectedValueTypes = "//h3[contains(text(),'Value Types in Report')]/..//bs-applied-values//div[contains(@ng-reflect-klass, 'applied-values__item')]";
        public static readonly By FooterHint = By.XPath("//*[contains(@class, 'footer__hint')]/strong");
    }
}