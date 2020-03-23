namespace Automation.PageObject.Pages.Report
{
    using Automation.Elements.Basic;
    using Automation.PageObject.Locators.Report;

    using OpenQA.Selenium;

    public class ReportsElements
    {
        internal Button DashboardTabCloseButton => new Button(ReportLocators.CloseDashboardTab);

        internal Label FirstDashboardReportTabTitle => new Label(ReportLocators.FirstDashboardReportTabTitle);

        internal Label NumberOfOpenReportsLabel => new Label(ReportLocators.DashboardReportTabLocatorCount);

        internal Label ReportRowElements => new Label(ReportLocators.ReportRowElements);

        internal Button CollapseAllLevelsLink => new Button(ReportLocators.CollapseAllLevelsLink);

        internal Button ExpandNextLevelLink => new Button(ReportLocators.ExpandNextLevelLink);

        internal Label ValueTypeColumnLabels => new Label(ReportLocators.ValueTypeColumnLabels);

        internal Label SortColumnLabels => new Label(ReportLocators.SortColumnLabels);

        internal Button SortColumnSigns => new Button(ReportLocators.SortColumnSigns);

        internal Button DrillDownCollapse => new Button(ReportLocators.DrillDownCollapse);

        internal Button DrillDownExpand => new Button(ReportLocators.DrillDownExpand);

        internal Button SortingLocators => new Button(By.CssSelector("span + a[bs-report-action]"));

        internal Button RestItemsLoadRemainingItems => new Button(ReportLocators.RestItemsLoadRemainingItems);

        internal Input CurrentPageInput => new Input(ReportLocators.CurrentPageInput);

        internal Label CurrentPageLabel => new Label(ReportLocators.CurrentPageLabel);

        internal Button PreviousPage => new Button(ReportLocators.PreviousPage);

        internal Button NextPage => new Button(ReportLocators.NextPage);

        internal Button LastPageNumber => new Button(ReportLocators.LastPageNumber);
    }
}