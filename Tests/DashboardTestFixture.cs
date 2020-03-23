namespace Tests
{
    using Automation.Helpers.DriverHelpers;
    using Automation.PageObject.Entities;
    using Automation.PageObject.Pages;
    using Automation.PageObject.Pages.MiDashboardHeader;
    using Automation.PageObject.Pages.Report;
    using Automation.TestFixtures;

    using NUnit.Framework;

    using Tests.Constants;

    [TestFixture]
    [Category(TestType.Regression)]
    public class DashboardTestFixture
    {
        private readonly TestFixtureBase testFixtureBase;

        public DashboardTestFixture()
        {
            this.Actions = new Actions();
            this.Footer = new ReportsFooterPage();
            this.Header = new ReportsHeaderPage();
            this.MiDashboardHeader = new MiDashboardHeaderPage();
            this.MiDashboard = new MiDashboardPage();
            this.Pov = new PovPage();
            this.Report = new ReportsPage();
            this.testFixtureBase = new TestFixtureBase();
        }

        protected Actions Actions { get; set; }

        protected ReportsFooterPage Footer { get; set; }

        protected ReportsHeaderPage Header { get; set; }

        protected MiDashboardHeaderPage MiDashboardHeader { get; }

        protected MiDashboardPage MiDashboard { get; }

        protected PovPage Pov { get; set; }

        protected ReportsPage Report { get; set; }

        public ReportsEntity ReportData { get; set; }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.testFixtureBase.OneTimeTearDown.ClearCookies();
            this.ReportData = null;
        }

        [SetUp]
        public void SetUpDashboardTestFixture()
        {
            this.testFixtureBase.SetUp.SetUpDashboardTestFixture(this.ReportData);
        }

        [TearDown]
        public void TearDownDashboardTestFixture()
        {
            this.testFixtureBase.TearDown.TearDownDashboardTestFixture();
        }
    }
}