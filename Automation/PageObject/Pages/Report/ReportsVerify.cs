namespace Automation.PageObject.Pages.Report
{
    using System.Collections.Generic;
    using System.Reflection;

    using Automation.Elements.Basic;
    using Automation.Helpers.DriverHelpers;
    using Automation.Helpers.Logger;
    using Automation.PageObject.Locators.Report;

    using NUnit.Framework;

    using OpenQA.Selenium;

    public class ReportsVerify : ReportsElements
    {
        private readonly ReportsActions reportsActions;

        public ReportsVerify()
        {
            this.reportsActions = new ReportsActions();
        }

        public ReportsPage DashboardTabTitle(string title)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, title);

            Assert.AreEqual(title, this.FirstDashboardReportTabTitle.GetText());

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, title);

            return new ReportsPage();
        }

        public void NumberOfOpenReports(int count)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, count);

            Assert.AreEqual(this.NumberOfOpenReportsLabel.Count(), count);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, count);
        }

        public ReportsPage ReportReloaded()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Wait.ForElement(ReportLocators.Spinner);
            Wait.ForRollerOnReportsToGoAway();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage ReportHasOnePageOnly()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.CurrentPage(1);

            var maxPage = int.Parse(this.CurrentPageLabel.GetText());
            Assert.AreEqual(maxPage, 1);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage CurrentPage(int expectedPageNumber)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, expectedPageNumber);

            var currentPage = int.Parse(this.CurrentPageInput.GetValue());
            Assert.AreEqual(expectedPageNumber, currentPage);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, expectedPageNumber);
            return new ReportsPage();
        }

        public ReportsPage ReportHasMoreThanOnePage()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            var page = int.Parse(this.CurrentPageLabel.GetText());
            Assert.Greater(page, 1);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage SwitchToOutOfRangePage(string inputText = "0")
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, inputText);

            var currentPage = this.CurrentPageInput.GetValue();

            this.reportsActions.NavigateToPage(inputText);

            Assert.AreNotEqual(inputText, currentPage);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, inputText);

            return new ReportsPage();
        }

        public void SortedColumn(int columnNumber)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, columnNumber);

            Assert.IsTrue(this.reportsActions.ValidateSortedColumn(columnNumber));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, columnNumber);
        }

        public ReportsHeaderPage AddedTimeViews(List<string> months)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Wait.ForRollerOnReportsToGoAway();

            var valueTypeCountColumns = this.ValueTypeColumnLabels.Count();

            foreach (var month in months)
            {
                var timeViewCountColumns =
                    new Button(By.XPath(
                            $"//a[contains(@bs-report-action,'sortOnColumn') and (contains(text(),'v') or (contains(text(),'u')))]/preceding-sibling::span[contains(text(),'{month}')]"))
                        .Count();
                Assert.IsTrue(valueTypeCountColumns == timeViewCountColumns ||
                              valueTypeCountColumns * 2 == timeViewCountColumns ||
                              valueTypeCountColumns * 3 == timeViewCountColumns ||
                              valueTypeCountColumns * 4 == timeViewCountColumns);
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsHeaderPage();
        }

        public void AddedValueTypes(List<string> valueTypes)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Wait.ForRollerOnReportsToGoAway();

            foreach (var valueType in valueTypes)
            {
                var valueTypeColumn = new Label(By.XPath($"//table/tbody/tr/td[contains(text(),'{valueType}')]"))
                    .IsVisible();
                var valueTypeColumnAnother =
                    new Label(By.XPath($"//table/tbody/tr/td//span[contains(text(),'{valueType}')]"))
                        .IsVisible();
                Assert.IsTrue(valueTypeColumn || valueTypeColumnAnother);
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public void DefaultAttributesInReport(string reportTitle)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Wait.ForRollerOnReportsToGoAway();

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
        }

        private static void AttributeIsVisible(string attributeName)
        {
            Assert.IsTrue(
                new Label(By.XPath($"//table/tbody/tr/td//*[contains(text(),'{attributeName}')]")).IsVisible());
        }

        public ReportsPage AddedAttributesOnReport(List<string> attributes)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Wait.ForRollerOnReportsToGoAway();

            foreach (var attribute in attributes)
            {
                Assert.IsTrue(
                    new Label(By.XPath($"//table/tbody/tr/td//*[contains(text(),'{attribute}')]")).IsVisible());
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public void OrderAttributes(List<string> attributes)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Wait.ForRollerOnReportsToGoAway();

            for (int i = 0; i < attributes.Count; i++)
            {
                var attribute = attributes[i];
                Assert.IsTrue(new Label(By.XPath($"//table/tbody/tr/td[{i + 2}]//*[contains(text(),'{attribute}')]"))
                    .IsVisible());
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }
    }
}