namespace Automation.PageObject.Locators
{
    using OpenQA.Selenium;

    public class DisclaimerLocators
    {
        public static readonly By Disclaimer = By.CssSelector("mi-disclaimer");
        public static readonly By DisclaimerTitle = By.XPath("//*[contains(@class,'disclaimer__introduction')]/h3");
        public static readonly By DisclaimerDescription = By.XPath("//*[contains(@class,'disclaimer__introduction')]/p");
        public static readonly By Links = By.XPath("//*[contains(@class,'disclaimer__policy')]//a");
        public static readonly By Messages = By.XPath("//*[contains(@class,'disclaimer__policy')]//p");
        public static readonly By DisclaimerFooterQuestion = By.XPath("//*[contains(@class,'disclaimer__container')]/p");
        public static readonly By Accept = By.CssSelector(".disclaimer__button");
    }
}