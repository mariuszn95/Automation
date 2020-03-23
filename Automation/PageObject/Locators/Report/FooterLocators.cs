namespace Automation.PageObject.Locators.Report
{
    using OpenQA.Selenium;

    public class FooterLocators
    {
        public static readonly By LeftFooter = By.CssSelector(".footer-container .footer-container__left");
        public static readonly By CentreFooter = By.CssSelector(".footer-container .footer__image");
        public static readonly By RightFooter = By.CssSelector(".footer-container .footer-container__right");
    }
}