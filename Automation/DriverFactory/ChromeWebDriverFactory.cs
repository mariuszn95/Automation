namespace Automation.DriverFactory
{
    using System;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    public class ChromeWebDriverFactory : IWebDriverFactory
    {
        private IWebDriver driver;

        public IWebDriver GetDriver()
        {
            ////var options = this.GetOptions();
            ////this.driver = new ChromeDriver(options as ChromeOptions);

            var options = new ChromeOptions();
            options.AddArguments("--no-sandbox"); // Bypass OS security model, MUST BE THE VERY FIRST OPTION
            options.AddArguments("--headless");
            options.AddAdditionalCapability("useAutomationExtension", false);
            options.AddArguments("start-maximized"); // open Browser in maximized mode
            options.AddArguments("disable-infobars"); // disabling infobars
            options.AddArguments("--disable-extensions"); // disabling extensions
            options.AddArguments("--disable-gpu"); // applicable to windows os only
            options.AddArguments("--disable-dev-shm-usage"); // overcome limited resource problems

            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;

            this.driver = new ChromeDriver(chromeDriverService, options, TimeSpan.FromSeconds(600));
            return this.driver;
        }

        public DriverOptions GetOptions()
        {
            var options = new ChromeOptions();

            // chromeOptions.AddArguments("start-maximized"); // open Browser in maximized mode
            options.AddArguments("--disable-infobars"); // disabling infobars
            options.AddArguments("--disable-extensions"); // disabling extensions
            options.AddArguments("--disable-gpu"); // applicable to windows os only
            options.AddArguments("--disable-dev-shm-usage"); // overcome limited resource problems

            options.AddArguments("--no-sandbox"); // Bypass OS security model
            options.AddAdditionalCapability("useAutomationExtension", false); // prohibits from using extensions

            return options;
        }
    }
}