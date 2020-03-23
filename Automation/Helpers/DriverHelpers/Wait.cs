namespace Automation.Helpers.DriverHelpers
{
    using System;
    using System.Threading;

    using Automation.Driver;
    using Automation.Helpers.Logger;
    using Automation.PageObject.Locators.Report;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

    public class Wait
    {
        public static void StandardWait()
        {
            ForDocumentLoaded();
            ForElementToLeave(By.CssSelector(".startup-roller"), DriverConsts.ThreeMinInMilliseconds);
            ForElementToLeave(By.CssSelector("mi-layout > mi-spinner .lds-roller"), DriverConsts.ThreeMinInMilliseconds);
        }

        public static void ForDocumentLoaded()
        {
            LoggerSelenium.LogStart(System.Reflection.MethodBase.GetCurrentMethod().Name);

            var wait = SetWaitTime(DriverConsts.ThreeMinInMilliseconds);
            wait.Until(d => JsExecutor.DocumentComplete());

            LoggerSelenium.LogEnd(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public static void ForElement(By locator, int milliseconds = DriverConsts.TwoMinInMilliseconds)
        {
            LoggerSelenium.LogStart(System.Reflection.MethodBase.GetCurrentMethod().Name, locator, milliseconds);

            StandardWait();

            WebDriverWait wait = new WebDriverWait(
                DriverSingleton.Driver,
                TimeSpan.FromMilliseconds(milliseconds));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Until(ExpectedConditions.ElementExists(locator));

            LoggerSelenium.LogEnd(System.Reflection.MethodBase.GetCurrentMethod().Name, locator, milliseconds);
        }

        public static void ForElementToLeave(By locator, int milliseconds = DriverConsts.TwoMinInMilliseconds)
        {
            LoggerSelenium.LogStart(System.Reflection.MethodBase.GetCurrentMethod().Name, locator, milliseconds);

            IWebElement element = null;

            string startTime = DateTime.Now.ToString("yyyyMMdd-HHmmss");

            DateTime endTime = DateTime.Now.AddMilliseconds(milliseconds);
            while (DateTime.Now < endTime)
            {
                try
                {
                    element = DriverSingleton.Driver.FindElement(locator);
                }
                catch (NoSuchElementException)
                {
                    // This is an expected exception
                    return;
                }
            }

            if (element != null)
            {
                string endTime2 = DateTime.Now.ToString("yyyyMMdd-HHmmss");
                Logger.Log(startTime);
                Logger.Log(endTime2);

                throw new Exception($"Element still found! {locator}");
            }

            LoggerSelenium.LogEnd(System.Reflection.MethodBase.GetCurrentMethod().Name, locator, milliseconds);
        }

        public static void ForRollerOnReportsToGoAway()
        {
            LoggerSelenium.LogStart(System.Reflection.MethodBase.GetCurrentMethod().Name);

            ForDocumentLoaded();
            ForElementToLeave(ReportLocators.Spinner, DriverConsts.FourMinInMilliseconds);

            LoggerSelenium.LogEnd(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public static void ForRollersOnWidgetsToGoAway()
        {
            LoggerSelenium.LogStart(System.Reflection.MethodBase.GetCurrentMethod().Name);

            ForDocumentLoaded();
            ForElementToLeave(
                By.CssSelector(@"div[class='spinner--overlay'] div[class='lds-roller']"),
                DriverConsts.ThreeMinInMilliseconds);

            LoggerSelenium.LogEnd(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public static void ForRollersToGoAway()
        {
            LoggerSelenium.LogStart(System.Reflection.MethodBase.GetCurrentMethod().Name);

            ForDocumentLoaded();
            ForElementToLeave(By.CssSelector(@"div[class='lds-roller'] [style='display:block']"));

            LoggerSelenium.LogEnd(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public static void FromSeconds(int time)
        {
            Thread.Sleep((int)(TimeSpan.FromSeconds(time).TotalSeconds * 1000));
        }

        public static void Until(Func<IWebDriver, bool> condition)
        {
            LoggerSelenium.LogStart(System.Reflection.MethodBase.GetCurrentMethod().Name);

            var wait = new WebDriverWait(DriverSingleton.Driver, new TimeSpan(0, 0, DriverConsts.Twenty));
            wait.Until(condition);

            LoggerSelenium.LogEnd(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public static void Until(Func<IWebDriver, IWebElement> condition)
        {
            LoggerSelenium.LogStart(System.Reflection.MethodBase.GetCurrentMethod().Name);

            WebDriverWait wait = new WebDriverWait(DriverSingleton.Driver, TimeSpan.FromSeconds(DriverConsts.Twenty));
            wait.Until(condition);

            LoggerSelenium.LogEnd(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private static WebDriverWait SetWaitTime(int milliseconds)
        {
            LoggerSelenium.LogReturn(System.Reflection.MethodBase.GetCurrentMethod().Name, milliseconds);

            return new WebDriverWait(DriverSingleton.Driver, TimeSpan.FromMilliseconds(milliseconds));
        }
    }
}