namespace Automation.Elements.Basic
{
    using System.Reflection;

    using Automation.Helpers.DriverHelpers;
    using Automation.Helpers.Logger;

    using OpenQA.Selenium;

    internal class Button : BasicElement
    {
        public Button(By locator)
            : base(locator)
        {
        }

        public void Click(int index = 0)
        {
            LoggerElements.LogStart(MethodBase.GetCurrentMethod().Name, this.MainLocator, index);

            this.ElementHelpers.Click(this.MainLocator, index);

            LoggerElements.LogEnd(MethodBase.GetCurrentMethod().Name, this.MainLocator, index);
        }

        public void ClickByJs()
        {
            LoggerElements.LogStart(MethodBase.GetCurrentMethod().Name, this.MainLocator);

            Wait.StandardWait();

            this.ElementHelpers.ClickByJs(this.MainLocator);

            LoggerElements.LogEnd(MethodBase.GetCurrentMethod().Name, this.MainLocator);
        }

        public string GetAttribute(string attributeName, int index = 0)
        {
            LoggerElements.LogReturn(MethodBase.GetCurrentMethod().Name, this.MainLocator, attributeName, index);

            return this.ElementHelpers.GetAttribute(this.MainLocator, attributeName, index);
        }

        public string GetCssValue(string propertyName)
        {
            LoggerElements.LogReturn(MethodBase.GetCurrentMethod().Name, this.MainLocator, propertyName);

            return this.ElementHelpers.GetCssValue(this.MainLocator, propertyName);
        }

        public string GetText(int index = 0)
        {
            LoggerElements.LogReturn(MethodBase.GetCurrentMethod().Name, this.MainLocator, index);

            return this.ElementHelpers.GetText(this.MainLocator, index);
        }

        public bool IsLinkActive()
        {
            LoggerElements.LogReturn(MethodBase.GetCurrentMethod().Name, this.MainLocator);

            return this.ElementHelpers.IsLinkActive(this.MainLocator);
        }

        public void MouseOver()
        {
            LoggerElements.LogStart(MethodBase.GetCurrentMethod().Name, this.MainLocator);

            this.ElementHelpers.MouseOverJs(this.ElementHelpers.FindElement(this.MainLocator));

            LoggerElements.LogEnd(MethodBase.GetCurrentMethod().Name, this.MainLocator);
        }
    }
}