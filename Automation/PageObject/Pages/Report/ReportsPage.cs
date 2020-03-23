namespace Automation.PageObject.Pages.Report
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Automation.Elements.Basic;
    using Automation.Helpers;
    using Automation.Helpers.DriverHelpers;
    using Automation.Helpers.Logger;
    using Automation.PageObject.Locators.Report;
    using Automation.PageObject.Pages.Report.Header;

    using NUnit.Framework;

    using OpenQA.Selenium;

    public class ReportsPage : ReportsElements
    {
        private readonly ElementHelpers elementHelpers;
        private readonly ReportsActions reportsActions;

        public ReportsPage()
        {
            this.elementHelpers = new ElementHelpers();
            this.reportsActions = new ReportsActions();
            this.Verify = new ReportsVerify();
        }

        public ReportsVerify Verify { get; set; }

        public void CloseDashboardTab()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.DashboardTabCloseButton.ClickByJs();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public ReportsPage ClickLoadNextItems()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Wait.ForRollerOnReportsToGoAway();
            var restItems = this.elementHelpers.FindElement(ReportLocators.RestItems, false);
            if (restItems != null)
            {
                this.elementHelpers.MouseOverJs(restItems);
                this.RestItemsLoadRemainingItems.ClickByJs();
                Wait.ForRollerOnReportsToGoAway();
            }

            var maxPageCount = int.Parse(this.CurrentPageLabel.GetText());
            if (restItems != null)
            {
                Assert.Greater(maxPageCount, 1);
            }
            else
            {
                Assert.AreEqual(maxPageCount, 1);
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public ReportsPage GoToNextPage()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            var startPage = this.CurrentPageInput.GetValue();
            this.NextPage.Click();
            Wait.ForRollerOnReportsToGoAway();

            var endPage = this.CurrentPageInput.GetValue();
            Assert.AreEqual(int.Parse(startPage) + 1, int.Parse(endPage));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public ReportsPage GoToPreviousPage()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            var startPage = this.CurrentPageInput.GetValue();
            this.PreviousPage.Click();
            Wait.ForRollerOnReportsToGoAway();

            var endPage = this.CurrentPageInput.GetValue();
            Assert.AreEqual(int.Parse(startPage) - 1, int.Parse(endPage));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public ReportsPage GoToLastPage()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            var lastPage = int.Parse(this.CurrentPageLabel.GetText());
            this.LastPageNumber.ClickByJs();
            Wait.ForRollerOnReportsToGoAway();
            var currentPage = int.Parse(this.CurrentPageInput.GetValue());
            Assert.AreEqual(currentPage, lastPage);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
            return this;
        }

        public ReportsPage GoToPage(string pageNumber = "2")
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, pageNumber);

            this.reportsActions.NavigateToPage(pageNumber);

            Assert.AreEqual(pageNumber, this.CurrentPageInput.GetValue());
            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, pageNumber);
            return this;
        }

        public void CollapseAll()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            if (this.CollapseAllActive())
            {
                Wait.ForRollerOnReportsToGoAway();
                this.CollapseAllLevelsLink.Click();
                Wait.ForRollerOnReportsToGoAway();

                var isActive = this.CollapseAllActive();

                Assert.IsFalse(isActive);
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public void ExpandNextLevel(int numberOfExpandClicks = 1)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, numberOfExpandClicks);

            // number of times to click expand next level limited in argument.
            // Expanding till possible causes out of memory exception in IE after several clicks, marked as exceptional usage of report, story: DVSZBI2-15858
            for (var i = 0; i < numberOfExpandClicks && this.ExpandButtonActive(); i++)
            {
                this.ExpandNextLevelLink.Click();
                Wait.ForRollerOnReportsToGoAway();
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, numberOfExpandClicks);
        }

        public void CheckExpandNextCollapseAll()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.CollapseAll();
            this.ExpandNextLevel();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public void CheckDrillDownCollapse()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            var rowCount = this.GetReportRowElementsCount();
            while (this.DrillDownCollapse.Count() > 0)
            {
                this.DrillDownCollapse.Click();
                Wait.ForRollerOnReportsToGoAway();
                var rowCountAfterDrillDownClick = this.GetReportRowElementsCount();
                Assert.Less(rowCountAfterDrillDownClick, rowCount);
                rowCount = rowCountAfterDrillDownClick;
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public void CheckDrillDownExpand()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            while (this.DrillDownExpand.Count() > 0 && this.DrillDownCollapse.Count() < 13)
            {
                var rowCount = this.GetReportRowElementsCount();
                this.DrillDownExpand.Click();
                Wait.ForRollerOnReportsToGoAway();
                var rowCountAfterDrillDownClick = this.GetReportRowElementsCount();
                Assert.Greater(rowCountAfterDrillDownClick, rowCount);
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public int GetReportRowElementsCount()
        {
            LoggerPage.LogReturn(MethodBase.GetCurrentMethod().Name);

            return this.ReportRowElements.Count();
        }

        public void CheckSorting()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Wait.ForRollerOnReportsToGoAway();

            var sortColumnsCount = Math.Min(this.SortingLocators.Count(), 3);

            for (var i = 1; i <= sortColumnsCount; i++)
            {
                var button = new Button(By.XPath($"(//span/following-sibling::a[@bs-report-action])[{i}]"));
                for (var j = 0; j < 2; j++)
                {
                    button.Click();
                    Assert.AreEqual(j == 0 ? "u" : "t", button.GetText(), "Sorting does not work");
                }
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public int GetRandomColumnNumberToSort()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            int columnNumber;
            do
            {
                columnNumber = new Random().Next(0, this.SortColumnSigns.Count() + 1);
            }
            while (this.reportsActions.ValidateSortedColumn(columnNumber));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return columnNumber;
        }

        public int GetDefaultSortedColumn()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            var result = 0;
            for (var columnNumber = 0; columnNumber < this.SortColumnLabels.Count(); columnNumber++)
            {
                if (this.ValidateSortColumnLabel(columnNumber))
                {
                    if (new ReportsHeaderElements().ReportTitle.GetText().Contains("13m") && result == 0)
                    {
                        result++;
                        continue;
                    }

                    result = columnNumber;
                    break;
                }
            }

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return result;
        }

        private bool ValidateSortColumnLabel(int columnNumber)
        {
            LoggerPage.LogReturn(MethodBase.GetCurrentMethod().Name);

            var sortColumnLabel = this.SortColumnLabels.GetText(columnNumber);

            var reportDate = this.GetCurrentReportDate();

            if (reportDate.Contains(sortColumnLabel))
            {
                return true;
            }

            switch (sortColumnLabel)
            {
                case "CM":
                case "Overall Trg Achv%":
                case "Gross Sales in mCHF":
                    return true;
                default:
                    return false;
            }
        }

        private string GetCurrentReportDate()
        {
            var reportDate = new ReportsHeaderPage().OrganizationUnitAndDate.GetText(1);

            var month = reportDate.Substring(0, 3);
            var year = string.Empty;
            if (reportDate.Count(char.IsWhiteSpace) >= 2)
            {
                int index = reportDate.IndexOf(' ');
                index = reportDate.IndexOf(' ', index + 1);
                year = reportDate.Substring(index - 2, 2);
            }

            if (reportDate.Count(char.IsWhiteSpace) == 1)
            {
                year = reportDate.Substring(6, 2);
            }

            return $"{month} {year}";
        }

        public void SortColumn(int columnNumber)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, columnNumber);

            this.SortColumnSigns.Click(columnNumber);
            this.Verify.SortedColumn(columnNumber);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, columnNumber);
        }

        private bool CollapseAllActive()
        {
            LoggerPage.LogReturn(MethodBase.GetCurrentMethod().Name);

            return this.CollapseAllLevelsLink.IsLinkActive();
        }

        private bool ExpandButtonActive()
        {
            LoggerPage.LogReturn(MethodBase.GetCurrentMethod().Name);

            return this.ExpandNextLevelLink.IsLinkActive();
        }
    }
}