namespace Automation.Elements.Basic
{
    using System.Reflection;

    using Automation.Helpers.Logger;

    using OpenQA.Selenium;

    internal class Label : BasicElement
    {
        public Label(By locator)
            : base(locator)
        {
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
    }
}