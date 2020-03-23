namespace Automation.PageObject.Locators.Report
{
    using OpenQA.Selenium;

    internal class ReportHeaderLocators
    {
        public static readonly By ReportTitle = By.CssSelector(".root-container dt");
        public static readonly By OrganizationUnitAndDate = By.CssSelector(".root-container dd");
        public static readonly By SingleVtButton = By.CssSelector(".indicator-selection__button  span");
        public static readonly By SingleVtList = By.ClassName("indicator-selection__dropdown");
        public static readonly By SingleVtListItem = By.ClassName("indicator-selection__item");
        public static readonly By SingleVtSearchInput = By.ClassName("indicator-selection__input");
        public static readonly By SingleVtSelectedItem = By.CssSelector(".indicator-selection__item:first-child");
        public static readonly By SingleTimeView = By.CssSelector("button.time-view-selection__button");
        public static readonly By Currency = By.CssSelector(@".report-header__basic-info span");
        public static readonly By CurrentlyManagedCifsButton = By.XPath(@"//div[@class='float-right']//button[contains(text(),'Currently Managed CIFs')]");
        public static readonly By PreviouslyManagedCifsButton = By.XPath(@"//div[@class='float-right']//button[contains(text(),'Previously Managed CIFs')]");
        public static readonly By ThirteenMonthsButton = By.CssSelector(".float-right .bn-bar-chart");
        public static readonly By FiltersButton = By.CssSelector(".float-right .bn-filters");
        public static readonly By ReloadButton = By.CssSelector(".float-right .bn-refresh");
        public static readonly By ExcelButton = By.CssSelector(".float-right .bn-file-xls");
        public static readonly By PdfButton = By.CssSelector(".float-right .bn-file-pdf");
        public static readonly By SaveButton = By.CssSelector(".float-right .bn-save");
    }
}