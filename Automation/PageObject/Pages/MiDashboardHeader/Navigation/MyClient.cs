namespace Automation.PageObject.Pages.MiDashboardHeader.Navigation
{
    using System.Reflection;

    using Automation.Helpers.DriverHelpers;
    using Automation.Helpers.Logger;
    using Automation.PageObject.MotherShip.Reports.MyClient;
    using Automation.PageObject.Pages.MiDashboardHeader;
    using Automation.PageObject.Pages.Report;

    public class MyClient
    {
        private readonly ReportsMenuPage reportsPage;

        public MyClient()
        {
            this.reportsPage = new ReportsMenuPage();
        }

        public ReportsPage CifList()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyClientMotherShip.CifList().Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage ClientGroupList()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyClientMotherShip.ClientGroupList().Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage ClientGroupList13M()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.ClientGroupList();
            Wait.ForRollerOnReportsToGoAway();
            this.reportsPage.ClickThirteenMonthsButton();
            Wait.ForRollerOnReportsToGoAway();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage ClientList()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyClientMotherShip.ClientList().Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage KeyFigures()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyClientMotherShip.KeyFigures().Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage ClientProfile()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyClientMotherShip.ClientProfile().Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage KeyFigures13M()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.KeyFigures();
            Wait.ForRollerOnReportsToGoAway();
            this.reportsPage.ClickThirteenMonthsButton();
            Wait.ForRollerOnReportsToGoAway();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage MyClientProfitability13M()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.Profitability();
            Wait.ForRollerOnReportsToGoAway();
            this.reportsPage.ClickThirteenMonthsButton();
            Wait.ForRollerOnReportsToGoAway();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage OrganizationalBreakdown()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyClientMotherShip.OrganizationalBreakdown().Name, MyClientMotherShip.OrganizationalBreakdown().Cluster);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage OrganizationalBreakdown13M()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.OrganizationalBreakdown();
            Wait.ForRollerOnReportsToGoAway();
            this.reportsPage.ClickThirteenMonthsButton();
            Wait.ForRollerOnReportsToGoAway();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage Profitability()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyClientMotherShip.Profitability().Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage ProfitabilityTopEams()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyClientMotherShip.ProfitabilityTopEams().Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage RmList()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyClientMotherShip.RmList().Name, MyClientMotherShip.RmList().Cluster);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage ServiceBreakdown()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyClientMotherShip.ServiceBreakdown().Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage ServiceBreakdown13M()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.ServiceBreakdown();
            Wait.ForRollerOnReportsToGoAway();
            this.reportsPage.ClickThirteenMonthsButton();
            Wait.ForRollerOnReportsToGoAway();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage Stt()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyClientMotherShip.Stt().Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage TopBottom()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyClientMotherShip.TopBottom().Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage VolumeAndGrowth()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyClientMotherShip.VolumeAndGrowth().Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage VolumeAndGrowth13M()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.VolumeAndGrowth();
            Wait.ForRollerOnReportsToGoAway();
            this.reportsPage.ClickThirteenMonthsButton();
            Wait.ForRollerOnReportsToGoAway();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage EamList()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyClientMotherShip.EamList().Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage EamAndEndClientList()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyClientMotherShip.EamAndEndClientList().Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage EamAndEndClientList13M()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.reportsPage.Open(MyClientMotherShip.EamAndEndClientList13M().Name);

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }
    }
}