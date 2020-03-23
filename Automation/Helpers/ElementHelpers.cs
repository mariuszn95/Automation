namespace Automation.Helpers
{
    using System;
    using System.Collections.ObjectModel;
    using System.Reflection;

    using Automation.Driver;
    using Automation.Helpers.DriverHelpers;
    using Automation.Helpers.Logger;

    using OpenQA.Selenium;

    public class ElementHelpers
    {
        // ReSharper disable once UnusedMember.Local
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Code Quality", "IDE0052:Remove unread private members", Justification = "Pending")]
        private readonly IWebDriver driver = DriverSingleton.Driver;

        public static string GetCursorValue(By locator)
        {
            LoggerSelenium.LogReturn(MethodBase.GetCurrentMethod().Name, locator);

            Wait.StandardWait();

            return DriverSingleton.Driver.FindElement(locator).GetCssValue("cursor");
        }

        public static void Clear(By locator)
        {
            LoggerSelenium.LogStart(MethodBase.GetCurrentMethod().Name, locator);

            Wait.StandardWait();
            DriverSingleton.Driver.FindElement(locator).Clear();

            LoggerSelenium.LogEnd(MethodBase.GetCurrentMethod().Name, locator);
        }

        public bool DisabledByJs(By locator, int index = 0)
        {
            LoggerSelenium.LogReturn(MethodBase.GetCurrentMethod().Name, locator, index);

            return JsExecutor.Disabled(locator, index);
        }

        public void SendKeys(By locator, string value)
        {
            LoggerSelenium.LogStart(MethodBase.GetCurrentMethod().Name, locator, value);

            Wait.StandardWait();
            DriverSingleton.Driver.FindElement(locator).SendKeys(value);

            LoggerSelenium.LogEnd(MethodBase.GetCurrentMethod().Name, locator, value);
        }

        public string GetValue(By locator)
        {
            LoggerSelenium.LogReturn(MethodBase.GetCurrentMethod().Name, locator);

            Wait.StandardWait();

            return JsExecutor.Value(locator);
        }

        public bool IsLinkActive(By locator)
        {
            LoggerSelenium.LogReturn(MethodBase.GetCurrentMethod().Name, locator);

            Wait.StandardWait();

            return DriverSingleton.Driver.FindElement(locator).GetCssValue("cursor").Equals("pointer");
        }

        public string GetCssValue(By locator, string propertyName)
        {
            LoggerSelenium.LogReturn(MethodBase.GetCurrentMethod().Name, locator);

            Wait.StandardWait();

            return DriverSingleton.Driver.FindElement(locator).GetCssValue(propertyName);
        }

        public string GetAttribute(By locator, string attributeName, int index = 0)
        {
            LoggerSelenium.LogReturn(MethodBase.GetCurrentMethod().Name, locator, attributeName, index);

            Wait.StandardWait();

            return DriverSingleton.Driver.FindElements(locator)[index].GetAttribute(attributeName);
        }

        public ReadOnlyCollection<IWebElement> FindElementsInReport(By locator)
        {
            LoggerSelenium.LogReturn(MethodBase.GetCurrentMethod().Name, locator);

            Wait.StandardWait();
            Wait.ForRollerOnReportsToGoAway();

            return this.FindElements(locator);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By locator)
        {
            LoggerSelenium.LogReturn(MethodBase.GetCurrentMethod().Name, locator);

            Wait.StandardWait();

            return DriverSingleton.Driver.FindElements(locator);
        }

        public string GetTextByJs(By locator)
        {
            LoggerSelenium.LogReturn(MethodBase.GetCurrentMethod().Name, locator);

            Wait.StandardWait();

            return JsExecutor.InnerText(locator);
        }

        public IWebElement FindElement(By locator, bool elementRequired = true)
        {
            LoggerSelenium.LogStart(MethodBase.GetCurrentMethod().Name, locator, elementRequired);

            Wait.StandardWait();

            IWebElement element = null;

            try
            {
                if (elementRequired)
                {
                    Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
                }

                element = DriverSingleton.Driver.FindElement(locator);
            }
            catch (Exception)
            {
                if (elementRequired)
                {
                    Console.WriteLine($"Element not found: {locator}");
                    throw;
                }
            }

            LoggerSelenium.LogEnd(MethodBase.GetCurrentMethod().Name, locator, elementRequired);

            return element;
        }

        public bool SelectedByJs(By locator, int index = 0)
        {
            LoggerSelenium.LogReturn(MethodBase.GetCurrentMethod().Name, locator, index);

            return JsExecutor.Selected(locator, index);
        }

        public void SendKeysByJs(By locator, string value)
        {
            LoggerSelenium.LogStart(MethodBase.GetCurrentMethod().Name, locator, value);

            Wait.StandardWait();

            JsExecutor.SendKeys(locator, value);
            JsExecutor.CallEventOnElement(locator);

            LoggerSelenium.LogEnd(MethodBase.GetCurrentMethod().Name, locator, value);
        }

        public void Click(By locator, int index = 0)
        {
            LoggerSelenium.LogStart(MethodBase.GetCurrentMethod().Name, locator);

            Wait.StandardWait();

            DriverSingleton.Driver.FindElements(locator)[index].Click();

            LoggerSelenium.LogEnd(MethodBase.GetCurrentMethod().Name, locator);
        }

        public void Click(IWebElement element)
        {
            LoggerSelenium.LogStart(MethodBase.GetCurrentMethod().Name);

            Wait.StandardWait();

            element.Click();

            LoggerSelenium.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public string GetText(By locator, int index = 0)
        {
            LoggerSelenium.LogReturn(MethodBase.GetCurrentMethod().Name, locator);

            Wait.StandardWait();

            Wait.ForRollerOnReportsToGoAway();

            return DriverSingleton.Driver.FindElements(locator)[index].Text;
        }

        public void ClickByJs(By locator, int index = 0, int scroll = -90)
        {
            LoggerSelenium.LogStart(MethodBase.GetCurrentMethod().Name, locator, index);

            JsExecutor.ScrollIntoView(locator);
            JsExecutor.ScrollBy(scroll);
            JsExecutor.Click(locator, index);

            LoggerSelenium.LogEnd(MethodBase.GetCurrentMethod().Name, locator, index);
        }

        public void ScrollElementByJs(By locator, int scroll)
        {
            LoggerSelenium.LogStart(MethodBase.GetCurrentMethod().Name);

            JsExecutor.ScrollElementBy(locator, scroll);

            LoggerSelenium.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public bool IsElementPresent(By locator)
        {
            LoggerSelenium.LogReturn(MethodBase.GetCurrentMethod().Name, locator);

            Wait.StandardWait();

            try
            {
                DriverSingleton.Driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void MouseOverJs(IWebElement element)
        {
            LoggerSelenium.LogStart(MethodBase.GetCurrentMethod().Name, element);

            Wait.StandardWait();

            JsExecutor.MouseOver(element);

            LoggerSelenium.LogEnd(MethodBase.GetCurrentMethod().Name, element);
        }

        public string GetPageTitle()
        {
            LoggerElements.LogReturn(MethodBase.GetCurrentMethod().Name);

            Wait.StandardWait();

            return DriverSingleton.Driver.Title;
        }
    }
}