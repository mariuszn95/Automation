namespace Automation.DriverFactory
{
    using OpenQA.Selenium;

    public interface IWebDriverFactory
    {
        IWebDriver GetDriver();

        DriverOptions GetOptions();
    }
}