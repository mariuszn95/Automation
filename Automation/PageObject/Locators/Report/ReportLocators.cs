namespace Automation.PageObject.Locators.Report
{
    using OpenQA.Selenium;

    public class ReportLocators
    {
        public static readonly By CloseDashboardTab = By.CssSelector(".nav-link .bs-remove-tab");
        public static readonly By FirstDashboardReportTabTitle = By.CssSelector(".nav-link span");
        public static readonly By DashboardReportTabLocatorCount = By.CssSelector(".nav-tabs li");
        public static readonly By Spinner = By.CssSelector("spinner .lds-roller");
        public static readonly By CollapseAllLevelsLink = By.XPath(@"//div[contains(text(),'Collapse All Levels')]");
        public static readonly By ExpandNextLevelLink = By.XPath(@"//div[contains(text(),'Expand Next Level')]");
        public static readonly By ValueTypeColumnLabels = By.XPath(@"//td/div/table");
        public static readonly By SortColumnLabels = By.XPath(@"//a[contains(@bs-report-action,'sortOnColumn') and (contains(text(),'v') or (contains(text(),'u')))]/preceding-sibling::*");
        public static readonly By SortColumnSigns = By.XPath(@"//a[contains(@bs-report-action,'sortOnColumn') and (contains(text(),'v') or (contains(text(),'u')))]");
        public static readonly By DrillDownCollapse = By.XPath(@"//a[contains(@bs-report-action,'drillDownValues')][contains(text(),'-')]");
        public static readonly By DrillDownExpand = By.XPath(@"//a[contains(@bs-report-action,'drillDownValues')][contains(text(),'+')]");
        public static readonly By ReportRowElements = By.CssSelector("#oReportDiv tr");
        public static readonly By RestItems = By.CssSelector("bs-rest-items .rest_items__title");
        public static readonly By RestItemsLoadRemainingItems = By.CssSelector("bs-rest-items .rest_items__item:last-child");
        public static readonly By NextPage = By.CssSelector(".paging-container button:last-child");
        public static readonly By PreviousPage = By.CssSelector(".paging-container button:first-child");
        public static readonly By CurrentPageInput = By.XPath("//*[@class='paging-container']//*[@class='paging-container__input']");
        public static readonly By CurrentPageLabel = By.XPath("//*[@class='paging-container']//*[@class='paging-container__label']");
        public static readonly By LastPageNumber = By.CssSelector(".paging-container .paging-container__label a");
    }
}