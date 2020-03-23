namespace Automation.PageObject.Pages.MiDashboardHeader.Navigation
{
    using System.Reflection;

    using Automation.Helpers.DriverHelpers;
    using Automation.Helpers.Logger;
    using Automation.PageObject.MotherShip.Reports.MySales;

    public class MySales
    {
        private readonly ReportsMenuPage reportsPage;

        public MySales()
        {
            this.reportsPage = new ReportsMenuPage();
        }

        public Report.ReportsPage AssetClassBreakdown()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MySalesMotherShip.AssetClassBreakdown().Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new Report.ReportsPage();
        }

        public Report.ReportsPage AssetClassBreakdown13M()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.AssetClassBreakdown();
            Wait.ForRollerOnReportsToGoAway();
            this.reportsPage.ClickThirteenMonthsButton();
            Wait.ForRollerOnReportsToGoAway();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new Report.ReportsPage();
        }

        public Report.ReportsPage CifList()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MySalesMotherShip.CifList().Name, "My Sales");

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new Report.ReportsPage();
        }

        public Report.ReportsPage OrganizationalBreakdown()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MySalesMotherShip.OrganizationalBreakdown().Name, "My Sales");

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new Report.ReportsPage();
        }

        public Report.ReportsPage OrganizationalBreakdown13M()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MySalesMotherShip.OrganizationalBreakdown13M().Name, "My Sales");

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new Report.ReportsPage();
        }

        public Report.ReportsPage RmList()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MySalesMotherShip.RmList().Name, "My Sales");

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new Report.ReportsPage();
        }

        public Report.ReportsPage TransactionList()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MySalesMotherShip.TransactionList().Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new Report.ReportsPage();
        }

        public Report.ReportsPage ProductList()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MySalesMotherShip.ProductList().Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new Report.ReportsPage();
        }
    }
}