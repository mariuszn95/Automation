namespace Automation.Helpers
{
    using System.Reflection;

    using Automation.Driver;
    using Automation.Helpers.Logger;

    using OpenQA.Selenium;

    internal class JsExecutor
    {
        public static void ClearSessionStorage()
        {
            LoggerSelenium.LogStart(MethodBase.GetCurrentMethod().Name);
            ExecuteScript("sessionStorage.clear()");

            LoggerSelenium.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public static void CallEventOnElement(By locator)
        {
            LoggerSelenium.LogStart(MethodBase.GetCurrentMethod().Name, locator);

            // ExecuteScript($@"arguments[0].dispatchEvent(new Event('input')", locator);
            // ExecuteScript($@"arguments[0].dispatchEvent(new Event('change')", locator);
            ExecuteScript(
                @"
                var createEvent = function ieEventPolyfill(eventName) {
                    var event = document.createEvent('Event');
                    event.initEvent(eventName, true, true);
                    return event;
                }
                arguments[0].dispatchEvent(createEvent('keyup'));
                arguments[0].dispatchEvent(createEvent('input'));",
                locator);

            LoggerSelenium.LogEnd(MethodBase.GetCurrentMethod().Name, locator);
        }

        public static void Click(By locator, int index = 0)
        {
            LoggerSelenium.LogStart(MethodBase.GetCurrentMethod().Name, locator, index);

            ExecuteScript("arguments[0].click()", locator, index);

            LoggerSelenium.LogEnd(MethodBase.GetCurrentMethod().Name, locator, index);
        }

        public static bool Disabled(By locator, int index = 0)
        {
            LoggerSelenium.LogReturn(MethodBase.GetCurrentMethod().Name, locator, index);

            return ExecuteScript($"return arguments[0].disabled", locator, index).Equals(true);
        }

        public static bool DocumentComplete()
        {
            LoggerSelenium.LogReturn(MethodBase.GetCurrentMethod().Name);

            return ExecuteScript("return document.readyState").Equals("complete");
        }

        public static string InnerText(By locator)
        {
            LoggerSelenium.LogReturn(MethodBase.GetCurrentMethod().Name, locator);

            return (string)ExecuteScript("return arguments[0].innerText.trim()", locator);
        }

        public static void MouseOver(IWebElement element)
        {
            LoggerSelenium.LogStart(MethodBase.GetCurrentMethod().Name, element);

            ExecuteScript(
                @"
                if (document.createEvent) {
                    var evObj = document.createEvent('MouseEvents');
                    evObj.initEvent('mouseover', true, false);
                    arguments[0].dispatchEvent(evObj);
                } else if (document.createEventObject) {
                    arguments[0].fireEvent('onmouseover');
                }",
                element);

            LoggerSelenium.LogEnd(MethodBase.GetCurrentMethod().Name, element);
        }

        public static void ScrollBy(int y)
        {
            LoggerSelenium.LogStart(MethodBase.GetCurrentMethod().Name, y);

            ExecuteScript($"window.scrollBy(0, {y})");

            LoggerSelenium.LogEnd(MethodBase.GetCurrentMethod().Name, y);
        }

        public static void ScrollElementBy(By locator, int y)
        {
            LoggerSelenium.LogStart(MethodBase.GetCurrentMethod().Name, locator, y);

            ExecuteScript($"arguments[0].scrollTop = {y}", locator);

            LoggerSelenium.LogEnd(MethodBase.GetCurrentMethod().Name, locator, y);
        }

        public static void ScrollIntoView(By locator)
        {
            LoggerSelenium.LogStart(MethodBase.GetCurrentMethod().Name, locator);

            ExecuteScript("arguments[0].scrollIntoView()", locator);

            LoggerSelenium.LogEnd(MethodBase.GetCurrentMethod().Name, locator);
        }

        public static bool Selected(By locator, int index = 0)
        {
            LoggerSelenium.LogReturn(MethodBase.GetCurrentMethod().Name, locator, index);

            return ExecuteScript($"return arguments[0].checked", locator, index).Equals(true);
        }

        public static void SendKeys(By locator, string value)
        {
            LoggerSelenium.LogStart(MethodBase.GetCurrentMethod().Name, locator, value);

            ExecuteScript($"arguments[0].value = '{value}'", locator);

            LoggerSelenium.LogEnd(MethodBase.GetCurrentMethod().Name, locator, value);
        }

        public static string Value(By locator)
        {
            LoggerSelenium.LogReturn(MethodBase.GetCurrentMethod().Name, locator);

            return (string)ExecuteScript("return arguments[0].value", locator);
        }

        private static object ExecuteScript(string script)
        {
            LoggerSelenium.LogReturn(MethodBase.GetCurrentMethod().Name, script);

            return ((IJavaScriptExecutor)DriverSingleton.Driver).ExecuteScript(script);
        }

        private static object ExecuteScript(string script, By locator, int index = 0)
        {
            LoggerSelenium.LogReturn(MethodBase.GetCurrentMethod().Name, script, locator);

            return ((IJavaScriptExecutor)DriverSingleton.Driver).ExecuteScript(
                script, DriverSingleton.Driver.FindElements(locator)[index]);
        }

        private static void ExecuteScript(string script, IWebElement element)
        {
            LoggerSelenium.LogReturn(MethodBase.GetCurrentMethod().Name, script, element);

            ((IJavaScriptExecutor)DriverSingleton.Driver).ExecuteScript(script, element);

            LoggerSelenium.LogEnd(MethodBase.GetCurrentMethod().Name, script, element);
        }
    }
}