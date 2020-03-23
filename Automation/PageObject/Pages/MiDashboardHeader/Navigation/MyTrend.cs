namespace Automation.PageObject.Pages.MiDashboardHeader.Navigation
{
    using System.Reflection;

    using Automation.Helpers.Logger;
    using Automation.PageObject.MotherShip.Reports.MyTrend;
    using Automation.PageObject.Pages.MiDashboardHeader;

    public class MyTrend
    {
        private readonly ReportsMenuPage reportsPage;

        public MyTrend()
        {
            this.reportsPage = new ReportsMenuPage();
        }

        public Report.ReportsPage CifList()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyTrendMotherShip.CifList().Name, "My Trend");

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new Report.ReportsPage();
        }

        public Report.ReportsPage RmList()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyTrendMotherShip.RmList().Name, "My Trend");

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new Report.ReportsPage();
        }

        public Report.ReportsPage Overview()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyTrendMotherShip.Overview().Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new Report.ReportsPage();
        }

        public Report.ReportsPage OrganizationalBreakdownOverview()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyTrendMotherShip.OrganizationalBreakdownOverview().Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new Report.ReportsPage();
        }

        public Report.ReportsPage OrganizationalBreakdown()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyTrendMotherShip.OrganizationalBreakdown().Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new Report.ReportsPage();
        }

        public Report.ReportsPage YtdOverview()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyTrendMotherShip.YtdOverview().Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new Report.ReportsPage();
        }
    }
}