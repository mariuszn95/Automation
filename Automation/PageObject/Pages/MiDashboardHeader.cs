namespace Automation.PageObject.Pages
{
    using System.Reflection;

    using Automation.Helpers.Logger;
    using Automation.PageObject.Pages.MiDashboardHeader;

    using NUnit.Framework;

    public class DataLoadStatusPage : PovPage
    {
        private const char OE_FINAL_SEPARATOR = ' ';

        public DataLoadStatusPage(string myClient, string myContributionRmIcTeam, string myContributionOuPc, string mySales, string myTrend)
        {
            this.MyClient = myClient;
            this.MyContributionRmIcTeam = myContributionRmIcTeam;
            this.MyContributionOuPc = myContributionOuPc.Split(OE_FINAL_SEPARATOR).Length > 0 ? myContributionOuPc.Split(' ')[0] : string.Empty;
            this.MySales = mySales;
            this.MyTrend = myTrend;
        }

        public string MyClient { get; set; }

        public string MyContributionRmIcTeam { get; set; }

        public string MyContributionOuPc { get; set; }

        public string MySales { get; set; }

        public string MyTrend { get; set; }

        public DataLoadStatusPage VerifyMyClient()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Assert.That(this.MyClient, Is.Not.Null.Or.Empty);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public DataLoadStatusPage VerifyMyContributionRmIcTeam()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Assert.That(this.MyContributionRmIcTeam, Is.Not.Null.Or.Empty);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public DataLoadStatusPage VerifyMyContributionOuPc()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Assert.That(this.MyContributionOuPc, Is.Not.Null.Or.Empty);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public DataLoadStatusPage VerifyMySales()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Assert.That(this.MySales, Is.Not.Null.Or.Empty);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public DataLoadStatusPage VerifyMyTrend()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Assert.That(this.MyTrend, Is.Not.Null.Or.Empty);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }
    }
}
