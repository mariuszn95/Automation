namespace Automation.DriverFactory
{
    using Automation.Helpers;

    using OpenQA.Selenium;

    public class DriverFactoryBase
    {
        public static IWebDriver Get()
        {
            IWebDriver driver;

            var browser = TestContexts.Browser;

            switch (browser.ToLower())
            {
                case "ie":
                    driver = new IeWebDriverFactory().GetDriver();
                    break;
                case "chrome":
                    driver = new ChromeWebDriverFactory().GetDriver();
                    break;
                case "edge":
                    driver = new EdgeWebDriverFactory().GetDriver();
                    break;
                default:
                    driver = new IeWebDriverFactory().GetDriver();
                    break;
            }

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(TestContexts.BaseAddress);

            return driver;
        }
    }
}