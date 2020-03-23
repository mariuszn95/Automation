namespace Automation.PageObject.Locators.MiDashboardHeader
{
    using OpenQA.Selenium;

    public class MiDashboardHeaderLocators
    {
        public static readonly By UserAvatar = By.CssSelector(".dashboard-header__user-info div");

        public static readonly By Username = By.CssSelector(".dashboard-header__user-info span");

        public static readonly By ReportWorkspaceIcon = By.XPath("//*[contains(@class, 'bn-grid-white')]/..");

        public static readonly By HomeIcon = By.XPath("//*[contains(@class, 'bn-home-white')]/..");

        public static readonly By Reports =
            By.XPath(@"//div[@class='dashboard-header']//span[contains(text(),'Reports')]");

        public static readonly By MySavedReports =
            By.XPath(@"//div[@class='dashboard-header']//span[contains(text(),'My Saved Reports')]");

        public static readonly By SavedReports = By.CssSelector(".header__cluster-box__cluster li");

        public static readonly By EditButton = By.CssSelector(".scrollable .header__edit-button");

        public static readonly By SelectAllCheckBox = By.CssSelector(@".modal-content .edit-saved-reports__select-all");

        public static readonly By DeleteSelectedReportsButton = By.CssSelector(".modal-content .delete");

        public static readonly By Booklets = By.XPath(@"//span[contains(text(),'Booklets')]");

        public static readonly By Logo = By.CssSelector(".dashboard-header__menu-row .img-logo");

        public static readonly By DataLoadStatus = By.XPath("//*[contains(@class, 'bn-calendar-white')]/..");

        public static readonly By Documents = By.XPath("//*[contains(@class, 'bn-large-file-stack-white')]/..");

        public static readonly By Support = By.XPath("//*[contains(@class, 'bn-icons-small-info-white')]/..");

        public static readonly By Menu = By.CssSelector("mi-reports-menu");
    }
}