namespace Automation.DriverFactory
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Edge;

    public class EdgeWebDriverFactory : IWebDriverFactory
    {
        private IWebDriver driver;

        public IWebDriver GetDriver()
        {
            var options = this.GetOptions();
            this.driver = new EdgeDriver(options as EdgeOptions);
            return this.driver;
        }

        public DriverOptions GetOptions()
        {
            var options = new EdgeOptions();
            options.PageLoadStrategy = PageLoadStrategy.Eager;
            return options;
        }
    }
}