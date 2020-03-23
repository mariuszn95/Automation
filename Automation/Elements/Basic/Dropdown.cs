namespace Automation.Elements.Basic
{
    using System.Reflection;

    using Automation.Helpers.Logger;

    using OpenQA.Selenium;

    internal class Dropdown : BasicElement
    {
        public Dropdown(By locator)
            : base(locator)
        {
        }

        public void SelectValue(string value)
        {
            LoggerElements.LogStart(MethodBase.GetCurrentMethod().Name, this.MainLocator, value);

            if (value != null)
            {
                this.ElementHelpers.Click(this.MainLocator);
            }

            LoggerElements.LogEnd(MethodBase.GetCurrentMethod().Name, this.MainLocator, value);
        }

        public string GetValue()
        {
            LoggerElements.LogReturn(MethodBase.GetCurrentMethod().Name, this.MainLocator);

            return this.ElementHelpers.GetValue(this.MainLocator);
        }

        public string GetText()
        {
            LoggerElements.LogReturn(MethodBase.GetCurrentMethod().Name, this.MainLocator);

            return this.ElementHelpers.GetText(this.MainLocator);
        }

        public string GetTextByJs()
        {
            LoggerElements.LogReturn(MethodBase.GetCurrentMethod().Name, this.MainLocator);

            return this.ElementHelpers.GetTextByJs(this.MainLocator);
        }

        public void Click()
        {
            LoggerElements.LogStart(MethodBase.GetCurrentMethod().Name, this.MainLocator);

            this.ElementHelpers.Click(this.MainLocator);

            LoggerElements.LogEnd(MethodBase.GetCurrentMethod().Name, this.MainLocator);
        }
    }
}