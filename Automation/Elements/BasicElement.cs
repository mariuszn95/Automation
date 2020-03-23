namespace Automation.Elements
{
    using System.Reflection;

    using Automation.Helpers;
    using Automation.Helpers.DriverHelpers;
    using Automation.Helpers.Logger;

    using OpenQA.Selenium;

    internal class BasicElement
    {
        public BasicElement(By locator)
        {
            this.MainLocator = locator;
        }

        protected ElementHelpers ElementHelpers => new ElementHelpers();

        public By MainLocator { get; }

        public int Count()
        {
            LoggerElements.LogReturn(MethodBase.GetCurrentMethod().Name, this.MainLocator);

            return this.ElementHelpers.FindElements(this.MainLocator).Count;
        }

        public bool IsVisible()
        {
            LoggerElements.LogReturn(MethodBase.GetCurrentMethod().Name, this.MainLocator);

            return this.IsElementPresent() && this.ElementHelpers.FindElement(this.MainLocator).Displayed;
        }

        public bool IsActive()
        {
            LoggerElements.LogReturn(MethodBase.GetCurrentMethod().Name, this.MainLocator);

            return this.ElementHelpers.FindElement(this.MainLocator).Enabled;
        }

        public IWebElement GetIfAvaiable()
        {
            LoggerElements.LogReturn(MethodBase.GetCurrentMethod().Name, this.MainLocator);

            return this.ElementHelpers.FindElement(this.MainLocator, false);
        }

        public bool IsReadOnly()
        {
            LoggerElements.LogReturn(MethodBase.GetCurrentMethod().Name, this.MainLocator);

            return this.IsVisible() && !this.IsActive();
        }

        public void WaitForIt()
        {
            LoggerElements.LogStart(MethodBase.GetCurrentMethod().Name, this.MainLocator);

            Wait.ForElement(this.MainLocator);

            LoggerElements.LogEnd(MethodBase.GetCurrentMethod().Name, this.MainLocator);
        }

        private bool IsElementPresent()
        {
            LoggerElements.LogReturn(MethodBase.GetCurrentMethod().Name, this.MainLocator);

            return this.ElementHelpers.IsElementPresent(this.MainLocator);
        }
    }
}