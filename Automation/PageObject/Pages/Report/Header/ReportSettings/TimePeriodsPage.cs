namespace Automation.PageObject.Pages.Report.Header.ReportSettings
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using Automation.Elements.Basic;
    using Automation.Helpers.Logger;
    using Automation.PageObject.Locators.Report.Header.ReportSettings;

    using NUnit.Framework;

    using OpenQA.Selenium;

    public class TimePeriodsPage : ReportSettingsPage
    {
        private Button DefaultView => new Button(TimePeriodsLocators.DefaultView);

        private Button MonthlyButton => new Button(TimePeriodsLocators.MonthlyButton);

        private Button YtdButton => new Button(TimePeriodsLocators.YtdButton);

        private Button MonthlyTimePeriodsUnselectedButton => new Button(TimePeriodsLocators.MonthlyTimePeriodsUnselectedButton);

        private Button YtdTimePeriodsUnselectedButton => new Button(TimePeriodsLocators.YtdTimePeriodsUnselectedButton);

        private Button Last13MonthsButton => new Button(TimePeriodsLocators.Last13MonthsButton);

        private Button CurrentYearButton => new Button(TimePeriodsLocators.CurrentYearButton);

        private Button CancelButton => new Button(TimePeriodsLocators.CancelButton);

        public TimePeriodsPage VerifyDefaultView()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Assert.AreEqual("Monthly", this.DefaultView.GetText());

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public TimePeriodsPage VerifyLayoutForMonthlyView()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Assert.IsTrue(this.MonthlyButton.IsVisible());
            Assert.IsTrue(this.YtdButton.IsVisible());
            Assert.IsTrue(this.ValidateMonthlyIsSelected());
            Assert.IsTrue(this.CancelButton.IsVisible());
            Assert.IsTrue(this.SubmitButton.IsVisible());
            Assert.IsTrue(this.XButton.IsVisible());
            Assert.IsTrue(this.Last13MonthsButton.IsVisible());
            Assert.IsTrue(this.CurrentYearButton.IsVisible());

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        private bool ValidateMonthlyIsSelected()
        {
            return this.MonthlyButton.GetAttribute("class").Contains("button--active");
        }

        public TimePeriodsPage ClickYtdButton()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.YtdButton.Click();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public TimePeriodsPage VerifyLayoutForYtdView()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Assert.IsTrue(this.MonthlyButton.IsVisible());
            Assert.IsTrue(this.YtdButton.IsVisible());
            Assert.IsTrue(this.ValidateYtdIsSelected());
            Assert.IsTrue(this.CancelButton.IsVisible());
            Assert.IsTrue(this.SubmitButton.IsVisible());

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        private bool ValidateYtdIsSelected()
        {
            return this.YtdButton.GetAttribute("class").Contains("button--active");
        }

        public TimePeriodsPage AddAtLeastOneTimePeriodFromMonthlyView(ref List<string> months)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.MonthlyButton.Click();

            var count = this.MonthlyTimePeriodsUnselectedButton.Count();
            var counter = new Random().Next(count / 3);
            for (var i = 0; i < counter; i++)
            {
                var randomTimePeriodNumber = new Random().Next(count - i);
                var item = this.MonthlyTimePeriodsUnselectedButton.GetText(randomTimePeriodNumber);
                this.MonthlyTimePeriodsUnselectedButton.Click(randomTimePeriodNumber);

                months.Add(item);
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public TimePeriodsPage AddAtLeastOneTimePeriodFromYtdView(ref List<string> months)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.YtdButton.Click();

            var count = this.YtdTimePeriodsUnselectedButton.Count();
            var counter = new Random().Next(count / 3);
            for (var i = 0; i < counter; i++)
            {
                var randomTimePeriodNumber = new Random().Next(count - i);
                var item = this.YtdTimePeriodsUnselectedButton.GetText(randomTimePeriodNumber);
                this.YtdTimePeriodsUnselectedButton.Click(randomTimePeriodNumber);

                months.Add(item);
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public TimePeriodsPage VerifyAddedTimeViewsOnReportSettings(List<string> months)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            foreach (var month in months)
            {
                var validateTimePeriodInReport =
                    new Label(By.XPath(
                            $"//*[@id='timePeriods-panel']//div[@class='applied-values__item-name' and contains(text(),'{month}')]"))
                        .IsVisible();

                Assert.IsTrue(validateTimePeriodInReport);
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }
    }
}