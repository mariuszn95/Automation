namespace Automation.Driver
{
    using System;
    using System.Diagnostics;

    using Automation.DriverFactory;
    using Automation.Helpers.Logger;

    using OpenQA.Selenium;

    public static class DriverSingleton
    {
        private static IWebDriver driver;

        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                {
                    InitializeDriver();
                }

                return driver;
            }

            private set
            {
                driver = value;
            }
        }

        public static void InitializeDriver()
        {
            try
            {
                Logger.Log("Initializing driver first try");
                driver = DriverFactoryBase.Get();
            }
            catch (Exception)
            {
                Logger.Log("Initializing driver second try");
                driver = DriverFactoryBase.Get();
            }
        }

        public static void Dispose()
        {
            driver.Quit();
            driver.Dispose();

            Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");
            foreach (var process in chromeDriverProcesses)
            {
                process.Kill();
            }

            Process[] ieDriverProcesses = Process.GetProcessesByName("IEDriverServer");
            foreach (var process in ieDriverProcesses)
            {
                process.Kill();
            }

            Process[] ieProcesses = Process.GetProcessesByName("iexplore");
            foreach (var process in ieProcesses)
            {
                process.Kill();
            }

            driver = null;
        }
    }
}