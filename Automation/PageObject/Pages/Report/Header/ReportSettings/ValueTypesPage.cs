namespace Automation.PageObject.Pages.Report.Header.ReportSettings
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using Automation.Elements;
    using Automation.Elements.Basic;
    using Automation.Helpers;
    using Automation.Helpers.DriverHelpers;
    using Automation.Helpers.Extensions;
    using Automation.Helpers.Logger;
    using Automation.PageObject.Locators.Report.Header.ReportSettings;

    using NUnit.Framework;

    using OpenQA.Selenium;

    public class ValueTypesPage : ReportSettingsPage
    {
        private readonly ElementHelpers elementHelpers = new ElementHelpers();

        private Input SearchValueTypeInput => new Input(ValueTypesLocators.SearchValueTypeInput);

        private Checkbox SearchResultCheckboxes => new Checkbox(ValueTypesLocators.SearchResultCheckboxes);

        private Checkbox SearchResultUncheckedCheckboxes => new Checkbox(ValueTypesLocators.SearchResultUncheckedCheckboxes);

        private BasicElement SelectedValueTypes => new BasicElement(By.XPath(ValueTypesLocators.SelectedValueTypes));

        private Label FooterHint => new Label(ValueTypesLocators.FooterHint);

        public ValueTypesPage AddAtLeastOneValueType(ref List<string> valueTypes)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            var count = this.SearchResultCheckboxes.Count();
            var counter = new Random().Next(1, count / 10);
            for (var i = 0; i < counter; i++)
            {
                var randomValueTypeNumber = new Random().Next(1, count - i);
                var item = this.SearchResultCheckboxes.GetText(randomValueTypeNumber);
                this.SearchResultCheckboxes.Click(randomValueTypeNumber);

                valueTypes.Add(item);
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public ValueTypesPage UnselectYtdAndPtdOnOneValueType(ref int valueTypeNumber)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            var countSelectedValueTypes = this.SelectedValueTypes.Count();
            valueTypeNumber = new Random().Next(0, countSelectedValueTypes);

            new Checkbox(By.CssSelector(string.Empty)).UncheckByJsVtYtdPtd(valueTypeNumber * 2);
            new Checkbox(By.CssSelector(string.Empty)).UncheckByJsVtYtdPtd((valueTypeNumber * 2) + 1);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public ValueTypesPage VerifySubmitButtonNotAvailableAndErrorMessageAppeared(int valueTypeNumber)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Assert.AreEqual("true", this.SubmitButton.GetAttribute("disabled"));
            Assert.IsTrue(new Label(By.XPath($"{ValueTypesLocators.SelectedValueTypes}[{valueTypeNumber + 1}]"))
                .GetAttribute("class").Contains("applied-values__item-state--invalid"));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public ValueTypesPage SelectYtdOrPtdOnValueType(int valueTypeNumber)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            var ytdOrPtd = new Random().Next(0, 2);

            new Checkbox(By.CssSelector(string.Empty)).CheckByJsForVtYtdPtd((valueTypeNumber * 2) + ytdOrPtd);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public ValueTypesPage SelectYtdAndPtdOnOneValueType(ref List<string> valueType)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            var countSelectedValueTypes = this.SelectedValueTypes.Count();
            var valueTypeNumber = new Random().Next(0, countSelectedValueTypes);

            new Checkbox(By.CssSelector(string.Empty)).CheckByJsForVtYtdPtd(valueTypeNumber * 2);
            new Checkbox(By.CssSelector(string.Empty)).CheckByJsForVtYtdPtd((valueTypeNumber * 2) + 1);

            valueType.Add(
                new Label(By.XPath($"{ValueTypesLocators.SelectedValueTypes}[{valueTypeNumber + 1}]/div")).GetText());

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public ValueTypesPage VerifyValueTypeSortedAscending()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            var secondSearchResultText = this.SearchResultCheckboxes.GetText();
            var loopCounter = this.SearchResultCheckboxes.Count() / 10;
            for (int i = 1; i < loopCounter; i++)
            {
                var firstSearchResultText = secondSearchResultText;
                secondSearchResultText = this.SearchResultCheckboxes.GetText(i);
                if (secondSearchResultText != string.Empty)
                {
                    Assert.IsTrue(string.CompareOrdinal(firstSearchResultText, secondSearchResultText) < 0);
                }
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public ValueTypesPage VerifySearchForOneAndTwoCharacters()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            var countSearchResults = this.SearchResultCheckboxes.Count();

            this.SearchValueTypeInput.EnterValue(RandomData.RandomString(1));
            Assert.AreEqual(countSearchResults, this.SearchResultCheckboxes.Count());

            this.SearchValueTypeInput.Clear();
            this.SearchValueTypeInput.EnterValue(RandomData.RandomString(2));
            Assert.AreEqual(countSearchResults, this.SearchResultCheckboxes.Count());
            this.SearchValueTypeInput.Clear();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public ValueTypesPage VerifySearchForThreeCharacters()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            var countSearchResults = this.SearchResultCheckboxes.Count();

            this.SearchValueTypeInput.EnterValue(RandomData.RandomString(3));
            Assert.Greater(countSearchResults, this.SearchResultCheckboxes.Count());
            this.SearchValueTypeInput.Clear();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public ValueTypesPage SelectRandomValueType()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Wait.StandardWait();

            var count = this.SearchResultCheckboxes.Count() / 3;
            var counter = new Random().Next(1, count / 10);
            for (var i = 0; i < counter; i++)
            {
                var randomAttributeNumber = new Random().Next(1, count - i);
                this.SearchResultCheckboxes.CheckByJsForVt(randomAttributeNumber);
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public ValueTypesPage UnselectRandomValueType()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            var count = this.SelectedValueTypes.Count();
            var counter = new Random().Next(1, count);
            var valueType = new Label(By.XPath($"{ValueTypesLocators.SelectedValueTypes}[{counter}]")).GetText();
            this.SearchValueTypeInput.EnterValue(valueType);
            this.SearchResultCheckboxes.Click();
            this.SearchValueTypeInput.Clear();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public ValueTypesPage RemoveSelectedRandomValueType()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            var count = this.SelectedValueTypes.Count();
            var counter = new Random().Next(1, count);
            new Button(By.XPath(
                $"{ValueTypesLocators.SelectedValueTypes}[{counter}]//*[@class='applied-values__button']")).Click();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public ValueTypesPage Select100ValueTypes()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Wait.StandardWait();

            var index = 0;
            var yScroll = 170;

            var checkboxesToSelect = 100 - this.SelectedValueTypes.Count();

            for (var i = 11; i < checkboxesToSelect + 10; i++)
            {
                this.SearchResultCheckboxes.CheckByJsForVt(index);
                index++;
                if (i % 10 == 0)
                {
                    this.elementHelpers.ScrollElementByJs(By.CssSelector("div.value-picker__items"), yScroll);
                    yScroll += 340;
                }
            }

            while (this.SelectedValueTypes.Count() < 100)
            {
                this.SearchResultCheckboxes.CheckByJsForVt(index);
                index++;
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public ValueTypesPage VerifyMessageAfterSelecting100ValueTypes()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Assert.AreEqual("You can apply up to 100 Value Types to the report", this.FooterHint.GetText());

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public ValueTypesPage VerifyUncheckedCheckboxesCannotBeClickedAndGray()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            var count = this.SearchResultUncheckedCheckboxes.Count();
            var counter = new Random().Next(1, count / 10);
            for (var index = 0; index < counter; index++)
            {
                var randomValueTypeNumber = new Random().Next(1, count - index);
                Assert.IsTrue(this.SearchResultUncheckedCheckboxes.Disabled(randomValueTypeNumber));
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }
    }
}