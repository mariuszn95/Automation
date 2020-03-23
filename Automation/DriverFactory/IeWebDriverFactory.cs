namespace Automation.DriverFactory
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.IE;

    public class IeWebDriverFactory : IWebDriverFactory
    {
        private IWebDriver driver;

        public IWebDriver GetDriver()
        {
            var options = this.GetOptions();
            this.driver = new InternetExplorerDriver(options as InternetExplorerOptions);
            return this.driver;
        }

        public DriverOptions GetOptions()
        {
            var options = new InternetExplorerOptions
                              {
                                  UnhandledPromptBehavior = UnhandledPromptBehavior.Accept,
                                  IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                                  EnablePersistentHover = true,
                              };

            return options;
        }
    }
}