namespace Automation.PageObject.Locators.MiDashboardHeader
{
    using OpenQA.Selenium;

    public class PovLocators
    {
        public static readonly By BusinessFunctionLabel = By.XPath(@"//h5[contains(text(),'Business Function')]");

        public static readonly By BusinessFunctionValue = By.CssSelector(".businessFunction span");

        public static readonly By BusinessGroupLabel = By.XPath(@"//h5[contains(text(),'Business Group')]");

        public static readonly By BusinessGroupValue = By.CssSelector(".businessGroup span");

        public static readonly By CurrencyLabel = By.CssSelector(".currency h5");

        public static readonly By CurrencyValue = By.CssSelector(".currency span");

        public static readonly By DateLabel = By.XPath(@"//mi-date-picker/div/h5");

        public static readonly By DateValue = By.CssSelector(".date-picker .date-picker_content");

        public static readonly By LockButton = By.XPath(@"//mi-business-view-lock");

        public static readonly By OrganizationUnitLabel = By.XPath(@"//h5[contains(text(),'Organization Unit')]");

        public static readonly By OrganizationUnitValue = By.CssSelector(@"mi-content-top .oe-description");
    }
}