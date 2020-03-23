namespace Automation.Elements.Basic
{
    using System.Reflection;

    using Automation.Helpers.Logger;

    using OpenQA.Selenium;

    internal class Input : BasicElement
    {
        public Input(By locator)
            : base(locator)
        {
        }

        public void EnterValue(string value)
        {
            LoggerElements.LogStart(MethodBase.GetCurrentMethod().Name, this.MainLocator, value);

            if (value != null)
            {
                this.ElementHelpers.SendKeys(this.MainLocator, value);
            }

            LoggerElements.LogEnd(MethodBase.GetCurrentMethod().Name, this.MainLocator, value);
        }

        public void EnterValueByJs(string value)
        {
            LoggerElements.LogStart(MethodBase.GetCurrentMethod().Name, this.MainLocator, value);

            if (value != null)
            {
                this.ElementHelpers.SendKeysByJs(this.MainLocator, value);
            }

            LoggerElements.LogEnd(MethodBase.GetCurrentMethod().Name, this.MainLocator, value);
        }

        public string GetValue()
        {
            LoggerElements.LogReturn(MethodBase.GetCurrentMethod().Name, this.MainLocator);

            return this.ElementHelpers.FindElement(this.MainLocator).GetAttribute("value");
        }

        public void Clear()
        {
            LoggerElements.LogStart(MethodBase.GetCurrentMethod().Name, this.MainLocator);

            this.ElementHelpers.FindElement(this.MainLocator).Clear();

            LoggerElements.LogEnd(MethodBase.GetCurrentMethod().Name, this.MainLocator);
        }
    }
}