namespace Automation.PageObject.Pages.MiDashboardHeader
{
    using Automation.Elements.Basic;

    using NUnit.Framework;

    using OpenQA.Selenium;

    public class DocumentsPage
    {
        private Label DocumentsMenu => new Label(By.CssSelector(".list-of-documents"));

        private Button DocumentsMenuItems => new Button(By.XPath("//*[@class='list-of-documents']/li/a[1]"));

        private Button CloseButton => new Button(By.CssSelector("mi-sub-menu .sub-menu__close-button"));

        public void VerifyDocumentsLinks()
        {
            this.DocumentsMenu.WaitForIt();
            Assert.IsTrue(this.DocumentsMenuItems.GetText().Equals("Quick Reference Guide"));
            Assert.IsTrue(this.DocumentsMenuItems.GetAttribute("href").Equals("https://zu-sharepoint.csintra.net/pb/business_information_tools_community/portal/User%20Documentation/M_BIS_Portal_Guide_ENGLISH.pdf"));
            Assert.IsTrue(this.DocumentsMenuItems.GetText(1).Equals("Report Descriptions"));
            Assert.IsTrue(this.DocumentsMenuItems.GetAttribute("href", 1).Equals("https://zu-sharepoint.csintra.net/pb/business_information_tools_community/portal/User%20Documentation/BI%20Report%20Descriptions%20EN.pdf"));
            Assert.IsTrue(this.DocumentsMenuItems.GetText(2).Equals("Reporting Guidelines"));
            Assert.IsTrue(this.DocumentsMenuItems.GetAttribute("href", 2).Equals("https://zu-sharepoint.csintra.net/pb/business_information_tools_community/portal/User%20Documentation/BI_Style_Guidelines.pdf"));
            Assert.IsTrue(this.DocumentsMenuItems.GetText(3).Equals("Scope"));
            Assert.IsTrue(this.DocumentsMenuItems.GetAttribute("href", 3).Equals("https://zu-sharepoint.csintra.net/pb/business_information_tools_community/portal/User%20Documentation/BI_Scope_Documentation.pdf"));
            Assert.IsTrue(this.DocumentsMenuItems.GetText(4).Equals("Value Types Description (MyPrimus)"));
            Assert.IsTrue(this.DocumentsMenuItems.GetAttribute("href", 4).Equals("https://myprimus.csintra.net/#/ValueTypesDescription/search="));
            this.CloseButton.Click();
        }
    }
}