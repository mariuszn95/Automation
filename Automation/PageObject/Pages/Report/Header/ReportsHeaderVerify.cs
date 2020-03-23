namespace Automation.PageObject.Pages.Report.Header
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Reflection;

    using Automation.Helpers;
    using Automation.Helpers.DriverHelpers;
    using Automation.Helpers.Logger;
    using Automation.PageObject.Entities;
    using Automation.PageObject.Locators.Report;
    using Automation.PageObject.Pages.Report;

    using NUnit.Framework;

    using OpenQA.Selenium;

    public class ReportsHeaderVerify : ReportsHeaderElements
    {
        private readonly ElementHelpers elementHelpers;

        public ReportsHeaderVerify()
        {
            this.elementHelpers = new ElementHelpers();
        }

        public ReportsPage ReportHeaderLeft(ReportsEntity reportData)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.Title(reportData.Title);

            Assert.AreEqual(reportData.PoV.OrganizationUnit, this.OrganizationUnitAndDate.GetText());

            this.ReportDate(reportData.Date);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public void Title(string title)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, title);

            Wait.ForRollerOnReportsToGoAway();

            Assert.AreEqual(title, this.ReportTitle.GetText());

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, title);
        }

        public ReportsPage ReportDate(string date)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, date);

            Wait.ForRollerOnReportsToGoAway();

            Assert.AreEqual(date, this.OrganizationUnitAndDate.GetText(1));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, date);

            return new ReportsPage();
        }

        public ReportsPage VtSelection(string vtValue)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, vtValue);

            Assert.AreEqual(vtValue, this.SingleVtButton.GetText());

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, vtValue);

            return new ReportsPage();
        }

        public ReportsPage SingleTimeViewSelection(string singleTimeView)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, singleTimeView);

            Wait.ForRollerOnReportsToGoAway();
            Assert.AreEqual(singleTimeView, this.SingleTimeView.GetTextByJs());

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, singleTimeView);

            return new ReportsPage();
        }

        public ReportsPage Currency(string currency)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, currency);

            Assert.IsTrue(this.CurrencyLabel.GetText().Contains(currency));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, currency);

            return new ReportsPage();
        }

        public void SingleVtSelection(string expectedVt)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, expectedVt);

            Wait.ForRollerOnReportsToGoAway();
            Assert.AreEqual(expectedVt, this.SingleVtButton.GetTextByJs());

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, expectedVt);
        }

        public void SingleVtSelectionFunctionalityClose()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.SingleVtSelectionCloseFunctionalityByClickOutside();
            this.SingleVtSelectionCloseFunctionalityByClickEsc();
            this.SingleVtSelectionCloseFunctionalityByClickVtSelectionButton();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        private void SingleVtSelectionCloseFunctionalityByClickOutside()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.SingleVtSelectionCloseFunctionalityBy(
                () => this.ReportTitle.Click());

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        private void SingleVtSelectionCloseFunctionalityByClickEsc()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.SingleVtSelectionCloseFunctionalityBy(
                () => this.elementHelpers.SendKeys(ReportHeaderLocators.SingleVtList, Keys.Escape));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        private void SingleVtSelectionCloseFunctionalityByClickVtSelectionButton()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.SingleVtSelectionCloseFunctionalityBy(
                () => this.SingleVtButton.Click());

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        private void SingleVtSelectionCloseFunctionalityBy(Action closeAction)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.SingleVtButton.Click();
            Assert.IsTrue(this.SingleVtList.IsVisible());
            closeAction();
            Assert.IsFalse(this.SingleVtList.IsVisible());

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public void SingleVtSelectionSearchResult()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.SingleVtButton.Click();
            ReadOnlyCollection<IWebElement> vtsBeforeSearch = this.elementHelpers.FindElements(ReportHeaderLocators.SingleVtListItem);
            this.elementHelpers.SendKeys(ReportHeaderLocators.SingleVtSearchInput, "mortgage");
            ElementHelpers.Clear(ReportHeaderLocators.SingleVtSearchInput);
            ReadOnlyCollection<IWebElement> vtsAfterSearch = this.elementHelpers.FindElements(ReportHeaderLocators.SingleVtListItem);
            this.SingleVtButton.Click();

            Assert.AreEqual(vtsBeforeSearch.Count, vtsAfterSearch.Count);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public void IfSelectedVtIsOnTopOfTheList(string expectedVt)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, expectedVt);

            this.SingleVtButton.Click();
            string selectedVt = this.SingleVtSelectedItem.GetTextByJs();
            this.SingleVtButton.Click();

            Assert.AreEqual(expectedVt, selectedVt);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, expectedVt);
        }

        public ReportsHeaderPage TimeViewAvailableValues(List<string> expectedTimeViewValues)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Assert.IsTrue(expectedTimeViewValues.SequenceEqual(this.GetTimeViewValues()), $"{expectedTimeViewValues} equals {this.GetTimeViewValues()}");

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsHeaderPage();
        }

        private List<string> GetTimeViewValues()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);
            var timeViewValues = new List<string>();
            var webElements = this.elementHelpers.FindElementsInReport(By.XPath("//button[@class='btn time-view-selection__button dropdown-toggle']/../div/div"));

            foreach (var webElement in webElements)
            {
                if (!string.IsNullOrEmpty(webElement.Text))
                {
                    timeViewValues.Add(webElement.Text);
                }
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return timeViewValues;
        }

        internal void OrganizationUnit(string organizationUnit)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, organizationUnit);

            Assert.AreEqual(organizationUnit, this.OrganizationUnitAndDate.GetText());

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, organizationUnit);
        }
    }
}