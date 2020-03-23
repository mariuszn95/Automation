namespace Automation.PageObject.Pages.MiDashboardHeader
{
    using Automation.Elements.Basic;

    using NUnit.Framework;

    using OpenQA.Selenium;

    public class SupportPage
    {
        private Label SupportMenu => new Label(By.CssSelector("mi-support"));

        private Label SupportMenuHeader => new Label(By.CssSelector(".support__header"));

        private Label SupportMenuMessage => new Label(By.CssSelector(".support__message"));

        private Label SupportMenuMessageLink => new Label(By.CssSelector(".support__message--link"));

        private Button CloseButton => new Button(By.CssSelector("mi-sub-menu .sub-menu__close-button"));

        public void VerifySupportLinks()
        {
            this.SupportMenu.WaitForIt();
            Assert.IsTrue(this.SupportMenuHeader.GetText().Equals("Support"));
            Assert.IsTrue(this.SupportMenuMessage.GetText().Equals("Please raise your support query through the M&BIS Interaction Platform here."));
            Assert.IsTrue(this.SupportMenuMessageLink.GetAttribute("href").Equals("https://zu-sharepoint.csintra.net/pb/mbis_ip/SiteAssets/index.aspx#/dashboard"));
            this.CloseButton.Click();
        }
    }
}