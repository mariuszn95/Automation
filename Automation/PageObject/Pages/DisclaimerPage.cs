namespace Automation.PageObject.Pages
{
    using System.Reflection;

    using Automation.Elements.Basic;
    using Automation.Helpers;
    using Automation.Helpers.DriverHelpers;
    using Automation.Helpers.Logger;
    using Automation.PageObject.Locators;

    using NUnit.Framework;

    using OpenQA.Selenium;

    public class DisclaimerPage
    {
        private readonly ElementHelpers elementHelpers = new ElementHelpers();

        private Label Disclaimer => new Label(DisclaimerLocators.Disclaimer);

        private Label DisclaimerTitle => new Label(DisclaimerLocators.DisclaimerTitle);

        private Label DisclaimerDescription => new Label(DisclaimerLocators.DisclaimerDescription);

        private Button Links => new Button(DisclaimerLocators.Links);

        private Label Messages => new Label(DisclaimerLocators.Messages);

        private Label DisclaimerFooterQuestion => new Label(DisclaimerLocators.DisclaimerFooterQuestion);

        private Button Accept => new Button(DisclaimerLocators.Accept);

        public void AcceptDisclaimerIfNotAcceptedYet()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Wait.StandardWait();

            Wait.Until(d => d.FindElement(By.CssSelector("mi-root > router-outlet")));

            if (this.Disclaimer.GetIfAvaiable() != null)
            {
                this.Accept.Click();
            }

            Wait.ForDocumentLoaded();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public void VerifyApplicationTitle(string title)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Assert.AreEqual(title, this.elementHelpers.GetPageTitle());

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public void VerifyThatDisclaimerIsAvaiable()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Assert.IsTrue(this.Disclaimer.GetIfAvaiable() != null);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public void VerifyLinks()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Assert.IsTrue(this.Links.GetAttribute("href").Equals("https://my.csintra.net/NASApp/MyPolicies/MyPoliciesServlet?command=File&action=view&docId=599936"));
            Assert.IsTrue(this.Links.GetAttribute("href", 1).Equals("https://my.csintra.net/NASApp/MyPolicies/MyPoliciesServlet?command=File&action=view&docId=595020"));
            Assert.IsTrue(this.Links.GetAttribute("href", 2).Equals("https://my.csintra.net/NASApp/MyPolicies/MyPoliciesServlet?command=File&action=view&docId=601239"));
            Assert.IsTrue(this.Links.GetAttribute("href", 3).Equals("https://my.csintra.net/NASApp/MyPolicies/MyPoliciesServlet?command=File&action=view&docId=461626"));
            Assert.IsTrue(this.Links.GetAttribute("href", 4).Equals("https://my.csintra.net/NASApp/MyPolicies/MyPoliciesServlet?command=File&action=view&docId=462592"));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public void VerifyMessages()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Assert.IsTrue(this.DisclaimerTitle.GetText().Equals("M&BIS Portal - Access to sensitive data"));
            Assert.IsTrue(this.DisclaimerDescription.GetText().Equals("You are starting an application which allows access to and exporting of a high number of records containing client identifying data. To ensure the protection of client data please adhere to the following guidelines:"));
            Assert.IsTrue(this.Links.GetText().Equals("Client Data Confidentiality, Data Protection and Privacy (GP-00087)"));
            Assert.IsTrue(this.Messages.GetText().Equals("This policy sets forth principles that must generally be complied with processing personal data, in particular when transferring such data."));
            Assert.IsTrue(this.Links.GetText(1).Equals("Client Data Confidentiality Switzerland Supplement to Client Data Confidentiality/ Data Protection/Privacy (GP-00087-S02)"));
            Assert.IsTrue(this.Messages.GetText(1).Equals("This policy ensures compliance with Swiss legislation on Swiss banking confidentiality."));
            Assert.IsTrue(this.Links.GetText(2).Equals("Information Security (GP-00040)"));
            Assert.IsTrue(this.Messages.GetText(2).Equals("This policy covers roles and responsibilities with regards to all information stored, processed, transmitted, accessed or printed by or on behalf of Credit Suisse."));
            Assert.IsTrue(this.Links.GetText(3).Equals("IT Acceptable Use (GP-00276)"));
            Assert.IsTrue(this.Messages.GetText(3).Equals("This policy sets out the principles and instructions to follow for acceptable and appropriate use of information technology hardware, software, systems, applications, data, facilities, networks and telecommunications equipment based on information security control objectives and requirements to protect Credit Suisse IT information assets."));
            Assert.IsTrue(this.Links.GetText(4).Equals("Information Ownership, Classification and Handling (GP-00277)"));
            Assert.IsTrue(this.Messages.GetText(4).Equals("This policy sets out the control objectives and minimum standards for the ownership, classification and handling of all forms of information. These are necessary to ensure that are right level of information security protection is applied to the information managed by Credit Suisse."));
            Assert.IsTrue(this.DisclaimerFooterQuestion.GetText().Equals("Please note: Any activity on the application will be logged. Are you sure you want to proceed?"));

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }
    }
}