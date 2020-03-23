namespace Automation.PageObject.Pages.MiDashboardHeader.Navigation
{
    using System.Reflection;

    using Automation.Helpers.DriverHelpers;
    using Automation.Helpers.Logger;
    using Automation.PageObject.MotherShip.Reports.MyContribution;

    public class MyContribution
    {
        private readonly ReportsMenuPage reportsPage;

        public MyContribution()
        {
            this.reportsPage = new ReportsMenuPage();
        }

        public Report.ReportsPage IcScorecard()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyContributionMotherShip.IcScorecard().Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new Report.ReportsPage();
        }

        public Report.ReportsPage IcScorecard13M()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.IcScorecard();
            Wait.ForRollerOnReportsToGoAway();
            this.reportsPage.ClickThirteenMonthsButton();
            Wait.ForRollerOnReportsToGoAway();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new Report.ReportsPage();
        }

        public Report.ReportsPage ManagedCif()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyContributionMotherShip.ManagedCif().Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new Report.ReportsPage();
        }

        public Report.ReportsPage ManagedCifForIc()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyContributionMotherShip.ManagedCifForIc().Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new Report.ReportsPage();
        }

        public Report.ReportsPage MyContributionRmScorecard13M()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.RmScorecard();
            Wait.ForRollerOnReportsToGoAway();
            this.reportsPage.ClickThirteenMonthsButton();
            Wait.ForRollerOnReportsToGoAway();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new Report.ReportsPage();
        }

        public Report.ReportsPage OrganizationalBreakdown()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyContributionMotherShip.OrganizationalBreakdown().Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new Report.ReportsPage();
        }

        public Report.ReportsPage OrganizationalBreakdown13M()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.OrganizationalBreakdown();
            Wait.ForRollerOnReportsToGoAway();
            this.reportsPage.ClickThirteenMonthsButton();
            Wait.ForRollerOnReportsToGoAway();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new Report.ReportsPage();
        }

        public Report.ReportsPage RmList()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyContributionMotherShip.RmList().Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new Report.ReportsPage();
        }

        public Report.ReportsPage LineManagerRmList()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyContributionMotherShip.LineManagerRmList().Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new Report.ReportsPage();
        }

        public Report.ReportsPage LineManagerIcList()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyContributionMotherShip.LineManagerIcList().Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new Report.ReportsPage();
        }

        public Report.ReportsPage RmScorecard()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyContributionMotherShip.RmScorecard().Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new Report.ReportsPage();
        }

        public Report.ReportsPage SourceReport()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyContributionMotherShip.SourceReport().Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new Report.ReportsPage();
        }

        public Report.ReportsPage SourceReport13M()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.SourceReport();
            Wait.ForRollerOnReportsToGoAway();
            this.reportsPage.ClickThirteenMonthsButton();
            Wait.ForRollerOnReportsToGoAway();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new Report.ReportsPage();
        }

        public Report.ReportsPage TeamPcScorecard()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyContributionMotherShip.TeamPcScorecard().Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new Report.ReportsPage();
        }

        public Report.ReportsPage TeamPcScorecard13M()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.TeamPcScorecard();
            Wait.ForRollerOnReportsToGoAway();
            this.reportsPage.ClickThirteenMonthsButton();
            Wait.ForRollerOnReportsToGoAway();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new Report.ReportsPage();
        }

        public Report.ReportsPage TeamPcSourceReport()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyContributionMotherShip.TeamPcSourceReport().Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new Report.ReportsPage();
        }

        public Report.ReportsPage TeamPcSourceReport13M()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.TeamPcSourceReport();
            Wait.ForRollerOnReportsToGoAway();
            this.reportsPage.ClickThirteenMonthsButton();
            Wait.ForRollerOnReportsToGoAway();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new Report.ReportsPage();
        }
    }
}