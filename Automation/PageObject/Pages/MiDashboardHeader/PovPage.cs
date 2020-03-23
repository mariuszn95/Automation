namespace Automation.PageObject.Pages.MiDashboardHeader
{
    using System;
    using System.Globalization;
    using System.Reflection;

    using Automation.Elements.Basic;
    using Automation.Helpers;
    using Automation.Helpers.DriverHelpers;
    using Automation.Helpers.Logger;
    using Automation.PageObject.Entities;
    using Automation.PageObject.Locators.MiDashboardHeader;

    using NUnit.Framework;

    using OpenQA.Selenium;

    public class PovPage
    {
        private readonly ElementHelpers elementHelpers = new ElementHelpers();

        private string povDropdowns = string.Empty;

        public string PovDropdownsLocator
        {
            set
            {
                this.povDropdowns = $@"//ul[@aria-labelledby='dropdownContentTop']//span[contains(text(),'{value}')]";
            }
        }

        private Button OrganizationUnitValue => new Button(PovLocators.OrganizationUnitValue);

        private Input OrganizationUnitSearchInput => new Input(By.CssSelector(".search-input"));

        private Button OrganizationUnitSearchResult => new Button(By.CssSelector(".tree-nav ul li.oe_search-result"));

        private Button BusinessGroupLabel => new Button(PovLocators.BusinessGroupLabel);

        private Button BusinessGroupValue => new Button(PovLocators.BusinessGroupValue);

        private Button BusinessFunctionLabel => new Button(PovLocators.BusinessFunctionLabel);

        private Button BusinessFunctionValue => new Button(PovLocators.BusinessFunctionValue);

        private Button CurrencyLabel => new Button(PovLocators.CurrencyLabel);

        private Button CurrencyValue => new Button(PovLocators.CurrencyValue);

        private Button DateLabel => new Button(PovLocators.DateLabel);

        private Button DateValue => new Button(PovLocators.DateValue);

        private Button Lock => new Button(By.XPath(@"//mi-business-view-lock"));

        private Button PovDropdowns => new Button(By.XPath(this.povDropdowns));

        public PovPage ChangeBusinessFunctionTo(string dropdownValue)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, dropdownValue);

            this.BusinessFunctionLabel.Click();
            this.PovDropdownsLocator = dropdownValue;
            Wait.ForElement(By.XPath(this.povDropdowns), DriverConsts.TenSecInMilliseconds);
            this.PovDropdowns.ClickByJs();
            Wait.ForRollersToGoAway();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, dropdownValue);

            return this;
        }

        public MiDashboardPage ChangeBusinessGroupTo(string dropdownValue)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, dropdownValue);

            this.BusinessGroupLabel.ClickByJs();
            Wait.ForRollersToGoAway();
            this.PovDropdownsLocator = dropdownValue;
            this.PovDropdowns.Click();
            Wait.ForRollersToGoAway();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, dropdownValue);

            return new MiDashboardPage();
        }

        public PovPage ChangeCurrencyTo(string dropdownValue)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, dropdownValue);

            this.CurrencyLabel.Click();
            this.PovDropdownsLocator = dropdownValue;
            this.PovDropdowns.Click();
            Wait.ForRollersToGoAway();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, dropdownValue);

            return this;
        }

        public PovPage ChangeDateTo(DateTime date)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, date);

            string monthName = date.ToString("MMMM", CultureInfo.GetCultureInfo("en-us"));

            this.DateLabel.Click();
            new Button(By.XPath(@"//button[@class='current']")).Click();
            new Button(By.XPath($@"//td/span[contains(text(),'{date.Year}')]")).Click();
            new Button(By.XPath($@"//td/span[contains(text(),'{monthName}')]")).Click();
            new Button(By.XPath($@"//td[@class='ng-star-inserted']//span[text()='{date.Day}' and not(@class='is-other-month')]")).Click();

            Wait.ForRollerOnReportsToGoAway();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, date);

            return this;
        }

        public PovPage ChangeDayTo(int date)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, date);

            this.DateLabel.Click();
            var day = new Button(
                By.XPath($@"//td[@class='ng-star-inserted']//span[text()='{date}' and not(@class='is-other-month')]"));
            day.Click();

            Wait.ForRollerOnReportsToGoAway();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, date);

            return this;
        }

        public MiDashboardPage ChangeOrganizationUnitTo(string dropdownValue)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, dropdownValue);

            Wait.ForRollersToGoAway();
            this.OrganizationUnitValue.Click();
            this.OrganizationUnitSearchInput.Clear();
            this.OrganizationUnitSearchInput.EnterValueByJs(dropdownValue);

            // Wait.ForElement(this.OrganizationUnitSearchResult);
            this.OrganizationUnitSearchResult.WaitForIt();
            this.OrganizationUnitSearchResult.Click();
            Wait.ForRollersToGoAway();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, dropdownValue);

            return new MiDashboardPage();
        }

        public bool IsUnlocked()
        {
            return bool.Parse(this.elementHelpers.GetAttribute(PovLocators.LockButton, "ng-reflect-is-unlocked"));
        }

        public PovPage LockPov()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            if (this.IsUnlocked())
            {
                this.Lock.Click();
                Wait.ForRollersOnWidgetsToGoAway();
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public MiDashboardPage SetPoV(PoVEntity pov)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            if (!this.ComparePov(pov))
            {
                this.ChangePov(pov);
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new MiDashboardPage();
        }

        public bool ComparePov(PoVEntity pov)
        {
            return this.CompareOrganizationUnit(pov.OrganizationUnitNo) && this.CompareBusinessGroup(pov.BusinessGroup)
                                                                   && this.CompareBusinessFunction(pov.BusinessFunction);
        }

        public void ChangePov(PoVEntity pov)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.ChangeOrganizationUnitToIfNeeded(pov.OrganizationUnitNo);
            this.ChangeBusinessGroupToIfNeeded(pov.BusinessGroup);
            this.ChangeBusinessFunctionToIfNeeded(pov.BusinessFunction);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public void ChangeOrganizationUnitToIfNeeded(string organizationUnit)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, organizationUnit);

            if (!this.CompareOrganizationUnit(organizationUnit))
            {
                this.ChangeOrganizationUnitTo(organizationUnit);
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, organizationUnit);
        }

        public void ChangeBusinessGroupToIfNeeded(string businessGroup)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, businessGroup);

            if (!this.CompareBusinessGroup(businessGroup))
            {
                this.ChangeBusinessGroupTo(businessGroup);
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, businessGroup);
        }

        public void ChangeBusinessFunctionToIfNeeded(string businessFunction)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, businessFunction);

            if (!this.CompareBusinessFunction(businessFunction))
            {
                this.ChangeBusinessFunctionTo(businessFunction);
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, businessFunction);
        }

        public PovPage UnlockPov()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            if (!this.IsUnlocked())
            {
                this.Lock.Click();
                Wait.ForRollersOnWidgetsToGoAway();
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public PovPage VerifyOrganizationUnit(string organizationUnitNo)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, organizationUnitNo);

            Wait.StandardWait();
            Assert.IsTrue(this.OrganizationUnitValue.GetText().Contains(organizationUnitNo));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, organizationUnitNo);

            return this;
        }

        public PovPage VerifyBusinessFunction(string businessFunction)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, businessFunction);

            Wait.StandardWait();
            Assert.IsTrue(this.BusinessFunctionValue.GetText().Equals(businessFunction));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, businessFunction);

            return this;
        }

        public PovPage VerifyBusinessGroup(string businessGroup)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, businessGroup);

            Wait.StandardWait();
            Assert.IsTrue(this.BusinessGroupValue.GetText().Equals(businessGroup));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, businessGroup);

            return this;
        }

        public PovPage VerifyCurrency(string currency)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, currency);

            Wait.StandardWait();
            Assert.IsTrue(this.CurrencyValue.GetText().Equals(currency));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, currency);

            return this;
        }

        public PovPage VerifyDate(DateTime date)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, date);

            Wait.StandardWait();

            var currentDate = this.DateValue.GetText();

            var firstDot = currentDate.IndexOf(".", StringComparison.Ordinal) + 1;
            var lastDot = currentDate.LastIndexOf(".", StringComparison.Ordinal);

            Assert.IsTrue(date.ToString("dd").Equals(currentDate.Substring(0, 2)));
            Assert.IsTrue(date.ToString("MM").Equals(currentDate.Substring(firstDot, lastDot - firstDot)));
            Assert.IsTrue(date.ToString("yyyy").Equals(currentDate.Substring(6, 4)));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, date);

            return this;
        }

        public PovPage VerifyPovLocked()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Assert.IsTrue(!this.IsUnlocked());

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public PovPage VerifyPovValueColor(By labelName, string color)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Assert.IsTrue(this.elementHelpers.GetCssValue(labelName, "color").Equals(color));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public string GetOrganizationUnit()
        {
            LoggerPage.LogReturn(MethodBase.GetCurrentMethod().Name);

            return this.OrganizationUnitValue.GetText();
        }

        public string GetOrganizationUnitNo()
        {
            LoggerPage.LogReturn(MethodBase.GetCurrentMethod().Name);

            var organizationUnitValue = this.GetOrganizationUnit();

            var leftBracket = organizationUnitValue.IndexOf("(", StringComparison.Ordinal) + 1;
            var rightBracket = organizationUnitValue.LastIndexOf(")", StringComparison.Ordinal);

            return organizationUnitValue.Substring(leftBracket, rightBracket - leftBracket);
        }

        public string GetBusinessGroup()
        {
            LoggerPage.LogReturn(MethodBase.GetCurrentMethod().Name);

            return this.BusinessGroupValue.GetText();
        }

        public string GetBusinessFunction()
        {
            LoggerPage.LogReturn(MethodBase.GetCurrentMethod().Name);

            return this.BusinessFunctionValue.GetText();
        }

        public string GetCurrency()
        {
            LoggerPage.LogReturn(MethodBase.GetCurrentMethod().Name);

            return this.CurrencyValue.GetText();
        }

        private bool CompareBusinessFunction(string businessFunction)
        {
            return this.GetBusinessFunction().Contains(businessFunction);
        }

        private bool CompareBusinessGroup(string businessGroup)
        {
            return this.GetBusinessGroup().Contains(businessGroup);
        }

        private bool CompareOrganizationUnit(string organizationUnitNo)
        {
            return this.GetOrganizationUnit().Contains(organizationUnitNo);
        }
    }
}