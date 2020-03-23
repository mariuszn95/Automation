namespace Automation.PageObject.Locators.Report.Header.ReportSettings
{
    using OpenQA.Selenium;

    internal class AttributesLocators : ReportSettingsLocators
    {
        public static readonly By SearchAttributeInput = By.XPath("//h3[contains(text(), 'Attributes')]/../..//*[@class='value-picker__input']");
        public static readonly By SearchResultCheckboxes = By.XPath("//h3[contains(text(), 'Attributes')]/../..//*[contains(@class,'value-picker__item ')]");
        public static readonly string SelectedAttributes = "//h3[contains(text(),'Attributes in Report')]/..//bs-applied-values//div[contains(@ng-reflect-klass, 'applied-values__item')]";
        public static readonly By SignsInAttributeReportSettings = By.XPath("//h3[contains(text(), 'Attributes in Report')]/..//*[contains(@class,'applied-values__button--narrow')]/i[contains(@class,'fa') and not(contains(@class,'applied-values__arrow--disabled'))]");
    }
}