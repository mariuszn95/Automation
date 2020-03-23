namespace Automation.PageObject.Pages.Report.Header.ReportSettings
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using Automation.Elements;
    using Automation.Elements.Basic;
    using Automation.Helpers.Extensions;
    using Automation.Helpers.Logger;
    using Automation.PageObject.Locators.Report.Header.ReportSettings;

    using NUnit.Framework;

    using OpenQA.Selenium;

    public class AttributesPage : ReportSettingsPage
    {
        private Input SearchAttributeInput => new Input(AttributesLocators.SearchAttributeInput);

        private Checkbox SearchResultCheckboxes => new Checkbox(AttributesLocators.SearchResultCheckboxes);

        private BasicElement SelectedAttributes => new BasicElement(By.XPath(AttributesLocators.SelectedAttributes));

        private Button SignsInAttributeReportSettings => new Button(AttributesLocators.SignsInAttributeReportSettings);

        public AttributesPage VerifySearchForOneAndTwoCharacters()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            var countSearchResults = this.SearchResultCheckboxes.Count();

            this.SearchAttributeInput.EnterValue(RandomData.RandomString(1));
            Assert.AreEqual(countSearchResults, this.SearchResultCheckboxes.Count());

            this.SearchAttributeInput.Clear();
            this.SearchAttributeInput.EnterValue(RandomData.RandomString(2));
            Assert.AreEqual(countSearchResults, this.SearchResultCheckboxes.Count());
            this.SearchAttributeInput.Clear();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public AttributesPage VerifySearchForThreeCharacters()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            var countSearchResults = this.SearchResultCheckboxes.Count();

            this.SearchAttributeInput.EnterValue(RandomData.RandomString(3));
            Assert.Greater(countSearchResults, this.SearchResultCheckboxes.Count());
            this.SearchAttributeInput.Clear();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public AttributesPage VerifyDefaultAttributesInReportSettings(string reportTitle)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            switch (reportTitle)
            {
                case "My Client - CIF List":
                    AttributeIsVisible("CIF Number");
                    AttributeIsVisible("CIF Name");
                    break;
                case "My Client - Client Group List":
                    AttributeIsVisible("Client Number");
                    AttributeIsVisible("Client Name");
                    AttributeIsVisible("CIF Nr");
                    break;
                case "My Client - Client Group List 13m":
                    AttributeIsVisible("Client Number");
                    AttributeIsVisible("Client Name");
                    AttributeIsVisible("CIF Nr");
                    break;
                case "My Client - Client List":
                    AttributeIsVisible("Client Number");
                    AttributeIsVisible("Client Name");
                    break;
                case "My Client - RM List":
                    AttributeIsVisible("Last name, First name");
                    AttributeIsVisible("PID");
                    break;
                case "My Client - Top-Bottom":
                    AttributeIsVisible("CIF Nr");
                    AttributeIsVisible("CIF Name");
                    AttributeIsVisible("Segment");
                    break;
                case "My Contribution - Line Manager IC List":
                    AttributeIsVisible("Last Name, First Name");
                    AttributeIsVisible("Overall Trg Achv%");
                    break;
                case "My Contribution - Line Manager RM List":
                    AttributeIsVisible("Last Name, First Name");
                    AttributeIsVisible("Overall Trg Achv%");
                    break;
                case "My Contribution - Currently Managed CIFs":
                    AttributeIsVisible("Client Number");
                    AttributeIsVisible("Client Name");
                    break;
                case "My Sales - CIF List":
                    AttributeIsVisible("Client Number");
                    AttributeIsVisible("Client Name");
                    break;
                case "My Sales - Product List":
                    AttributeIsVisible("Product Name");
                    AttributeIsVisible("ISIN");
                    break;
                case "My Sales - RM List":
                    AttributeIsVisible("PID");
                    AttributeIsVisible("Last name, First name");
                    break;
                case "My Sales - Transaction List":
                    AttributeIsVisible("Effective Date");
                    AttributeIsVisible("Deal Reference Number");
                    AttributeIsVisible("ISIN");
                    AttributeIsVisible("Valor");
                    AttributeIsVisible("Product Name");
                    AttributeIsVisible("CIF Nr");
                    AttributeIsVisible("CIF Name");
                    break;
                case "NNA Trend - RM List":
                    AttributeIsVisible("PID");
                    AttributeIsVisible("Last name, First name");
                    break;
                default:
                    Logger.Log("Missing report in switch statement");
                    Assert.IsTrue(false);
                    break;
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        private static void AttributeIsVisible(string attributeName)
        {
            Assert.IsTrue(new Label(
                    By.XPath($"//h3[contains(text(), 'Attributes')]/..//*[contains(text(),'{attributeName}')]"))
                .IsVisible());
        }

        public AttributesPage VerifyAttributesSortedAscending()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            var secondSearchResultText = this.SearchResultCheckboxes.GetText();
            for (int i = 1; i < this.SearchResultCheckboxes.Count(); i++)
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

        public AttributesPage VerifyDefaultAttributesInSearchReportSettings(string reportTitle)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            switch (reportTitle)
            {
                case "My Client - CIF List":
                    AttributeIsChecked("CIF Number");
                    AttributeIsChecked("CIF Name");
                    break;
                case "My Client - Client Group List":
                    AttributeIsChecked("Client Number");
                    AttributeIsChecked("Client Name");
                    AttributeIsChecked("CIF Nr");
                    break;
                case "My Client - Client Group List 13m":
                    AttributeIsChecked("Client Number");
                    AttributeIsChecked("Client Name");
                    AttributeIsChecked("CIF Nr");
                    break;
                case "My Client - Client List":
                    AttributeIsChecked("Client Number");
                    AttributeIsChecked("Client Name");
                    break;
                case "My Client - RM List":
                    AttributeIsChecked("Last name, First name");
                    AttributeIsChecked("PID");
                    break;
                case "My Client - Top-Bottom":
                    AttributeIsChecked("CIF Nr");
                    AttributeIsChecked("CIF Name");
                    AttributeIsChecked("Segment");
                    break;
                case "My Contribution - Line Manager IC List":
                    AttributeIsChecked("Last Name, First Name");
                    AttributeIsChecked("Overall Trg Achv%");
                    break;
                case "My Contribution - Line Manager RM List":
                    AttributeIsChecked("Last Name, First Name");
                    AttributeIsChecked("Overall Trg Achv%");
                    break;
                case "My Contribution - Currently Managed CIFs":
                    AttributeIsChecked("Client Number");
                    AttributeIsChecked("Client Name");
                    break;
                case "My Sales - CIF List":
                    AttributeIsChecked("Client Number");
                    AttributeIsChecked("Client Name");
                    break;
                case "My Sales - Product List":
                    AttributeIsChecked("Product Name");
                    AttributeIsChecked("ISIN");
                    break;
                case "My Sales - RM List":
                    AttributeIsChecked("PID");
                    AttributeIsChecked("Last name, First name");
                    break;
                case "My Sales - Transaction List":
                    AttributeIsChecked("Effective Date");
                    AttributeIsChecked("Deal Reference Number");
                    AttributeIsChecked("ISIN");
                    AttributeIsChecked("Valor");
                    AttributeIsChecked("Product Name");
                    AttributeIsChecked("CIF Nr");
                    AttributeIsChecked("CIF Name");
                    break;
                case "NNA Trend - RM List":
                    AttributeIsChecked("PID");
                    AttributeIsChecked("Last name, First name");
                    break;
                default:
                    Logger.Log("Missing report in switch statement");
                    Assert.IsTrue(false);
                    break;
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        private static void AttributeIsChecked(string attributeName)
        {
            Assert.IsTrue(new Checkbox(By.XPath($"//bs-value-picker//*[contains(text(),'{attributeName}')]/../input"))
                .IsCheckedByJs());
        }

        public AttributesPage SelectRandomAttribute(ref List<string> attributes)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            var count = this.SearchResultCheckboxes.Count();
            var counter = new Random().Next(1, (count + 1) / 10);
            for (var i = 0; i < counter; i++)
            {
                var randomAttributeNumber = new Random().Next(1, count - i);
                var item = this.SearchResultCheckboxes.GetText(randomAttributeNumber);
                this.SearchResultCheckboxes.CheckByJsForAttribute(randomAttributeNumber);

                attributes.Add(item);
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public AttributesPage ChangeOrderSelectedAttributes(out List<string> attributes)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            attributes = new List<string>();

            var counter = new Random().Next(1, 5);
            for (int i = 0; i < counter; i++)
            {
                var signsToClickCount = this.SignsInAttributeReportSettings.Count();
                this.SignsInAttributeReportSettings.Click(new Random().Next(0, signsToClickCount));
            }

            var count = this.SelectedAttributes.Count();

            for (int attributeNumber = 0; attributeNumber < count; attributeNumber++)
            {
                attributes.Add(
                    new Label(By.XPath($"{AttributesLocators.SelectedAttributes}[{attributeNumber + 1}]/div"))
                        .GetText());
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }
    }
}