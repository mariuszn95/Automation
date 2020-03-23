namespace Automation.Elements.Basic
{
    using System.Reflection;

    using Automation.Helpers.DriverHelpers;
    using Automation.Helpers.Logger;

    using OpenQA.Selenium;

    internal class Checkbox : BasicElement
    {
        public Checkbox(By locator)
            : base(locator)
        {
        }

        public void SetValue(bool? value)
        {
            LoggerElements.LogStart(MethodBase.GetCurrentMethod().Name, this.MainLocator, value);

            if (value != null)
            {
                if (value == true)
                {
                    this.Check();
                }
                else
                {
                    this.Uncheck();
                }
            }

            LoggerElements.LogEnd(MethodBase.GetCurrentMethod().Name, this.MainLocator, value);
        }

        public void Check()
        {
            LoggerElements.LogStart(MethodBase.GetCurrentMethod().Name, this.MainLocator);

            if (!this.IsChecked())
            {
                this.Click();
            }

            LoggerElements.LogEnd(MethodBase.GetCurrentMethod().Name, this.MainLocator);
        }

        public void CheckByJsForAttribute(int index = 0)
        {
            LoggerElements.LogStart(MethodBase.GetCurrentMethod().Name, this.MainLocator, index);

            Wait.StandardWait();

            if (!this.IsCheckedByJsForAttribute(index))
            {
                this.ClickByJsForAttribute(index);
            }

            LoggerElements.LogEnd(MethodBase.GetCurrentMethod().Name, this.MainLocator, index);
        }

        public void CheckByJsForVt(int index = 0)
        {
            LoggerElements.LogStart(MethodBase.GetCurrentMethod().Name, this.MainLocator, index);

            if (!this.IsCheckedByJsForVt(index))
            {
                this.ClickByJsForVt(index);
            }

            LoggerElements.LogEnd(MethodBase.GetCurrentMethod().Name, this.MainLocator, index);
        }

        public void CheckByJsForVtYtdPtd(int index = 0)
        {
            LoggerElements.LogStart(MethodBase.GetCurrentMethod().Name, this.MainLocator, index);

            Wait.StandardWait();

            if (!this.IsCheckedByJsForVtYtdPtd(index))
            {
                this.ClickByJsForVtYtdPtd(index);
            }

            LoggerElements.LogEnd(MethodBase.GetCurrentMethod().Name, this.MainLocator, index);
        }

        public void Uncheck()
        {
            LoggerElements.LogStart(MethodBase.GetCurrentMethod().Name, this.MainLocator);

            if (this.IsChecked())
            {
                this.Click();
            }

            LoggerElements.LogEnd(MethodBase.GetCurrentMethod().Name, this.MainLocator);
        }

        public void UncheckByJsVtYtdPtd(int index = 0)
        {
            LoggerElements.LogStart(MethodBase.GetCurrentMethod().Name, this.MainLocator, index);

            Wait.StandardWait();

            if (this.IsCheckedByJsForVtYtdPtd(index))
            {
                this.ClickByJsForVtYtdPtd(index);
            }

            LoggerElements.LogEnd(MethodBase.GetCurrentMethod().Name, this.MainLocator, index);
        }

        public bool IsChecked()
        {
            LoggerElements.LogReturn(MethodBase.GetCurrentMethod().Name, this.MainLocator);

            return this.ElementHelpers.FindElement(this.MainLocator).Selected;
        }

        public bool IsCheckedByJs(int index = 0)
        {
            LoggerElements.LogReturn(MethodBase.GetCurrentMethod().Name, this.MainLocator, index);

            Wait.StandardWait();

            return this.ElementHelpers.SelectedByJs(this.MainLocator, index);
        }

        private bool IsCheckedByJsForAttribute(int index = 0)
        {
            LoggerElements.LogReturn(MethodBase.GetCurrentMethod().Name, this.MainLocator, index);

            return this.ElementHelpers.SelectedByJs(By.XPath("//h3[contains(text(), 'Attributes')]/../..//*[contains(@class,'value-picker__item ')]/label/input"), index);
        }

        private bool IsCheckedByJsForVt(int index = 0)
        {
            LoggerElements.LogReturn(MethodBase.GetCurrentMethod().Name, this.MainLocator, index);

            return this.ElementHelpers.SelectedByJs(By.XPath("//h3[contains(text(), 'Value Types')]/../..//*[contains(@class,'value-picker__item ')]/label/input"), index);
        }

        private bool IsCheckedByJsForVtYtdPtd(int index = 0)
        {
            LoggerElements.LogReturn(MethodBase.GetCurrentMethod().Name, this.MainLocator, index);

            return this.ElementHelpers.SelectedByJs(By.CssSelector("bs-checkbox [class='checkbox__input']"), index);
        }

        public void Click(int index = 0)
        {
            LoggerElements.LogStart(MethodBase.GetCurrentMethod().Name, this.MainLocator, index);

            this.ElementHelpers.Click(this.MainLocator, index);

            LoggerElements.LogEnd(MethodBase.GetCurrentMethod().Name, this.MainLocator, index);
        }

        private void ClickByJs(int index = 0)
        {
            LoggerElements.LogStart(MethodBase.GetCurrentMethod().Name, this.MainLocator, index);

            this.ElementHelpers.ClickByJs(this.MainLocator, index);

            LoggerElements.LogEnd(MethodBase.GetCurrentMethod().Name, this.MainLocator, index);
        }

        private void ClickByJsForAttribute(int index = 0)
        {
            LoggerElements.LogStart(MethodBase.GetCurrentMethod().Name, this.MainLocator, index);

            this.ElementHelpers.ClickByJs(By.XPath("//h3[contains(text(), 'Attributes')]/../..//*[contains(@class,'value-picker__item ')]/label/input"), index);

            LoggerElements.LogEnd(MethodBase.GetCurrentMethod().Name, this.MainLocator, index);
        }

        private void ClickByJsForVt(int index = 0)
        {
            LoggerElements.LogStart(MethodBase.GetCurrentMethod().Name, this.MainLocator, index);

            this.ElementHelpers.ClickByJs(By.XPath("//h3[contains(text(), 'Value Types')]/../..//*[contains(@class,'value-picker__item ')]/label/input"), index, 0);

            LoggerElements.LogEnd(MethodBase.GetCurrentMethod().Name, this.MainLocator, index);
        }

        private void ClickByJsForVtYtdPtd(int index = 0)
        {
            LoggerElements.LogStart(MethodBase.GetCurrentMethod().Name, this.MainLocator, index);

            this.ElementHelpers.ClickByJs(By.CssSelector("bs-checkbox :nth-child(2)"), index);

            LoggerElements.LogEnd(MethodBase.GetCurrentMethod().Name, this.MainLocator, index);
        }

        public string GetText(int index = 0)
        {
            LoggerElements.LogReturn(MethodBase.GetCurrentMethod().Name, this.MainLocator, index);

            return this.ElementHelpers.GetText(this.MainLocator, index);
        }

        public bool Disabled(int index = 0)
        {
            LoggerElements.LogReturn(MethodBase.GetCurrentMethod().Name, this.MainLocator, index);

            return this.ElementHelpers.DisabledByJs(this.MainLocator, index);
        }
    }
}