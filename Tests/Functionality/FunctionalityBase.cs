namespace Tests.Functionality
{
    using Automation.PageObject.Entities;
    using NUnit.Framework;

    using Tests.Constants;

    [Category(TestType.Functionality)]
    public class FunctionalityBase : DashboardTestFixture
    {
        public void SetUp(ref ReportsEntity report, ReportsEntity randomReport)
        {
            if (report == null)
            {
                report = randomReport;
            }

            this.MiDashboard
                .SetPoV(report.PoV)
                .OpenReport(report.Name, report.Cluster);
        }

        public void SetUpNext(ref ReportsEntity report, ReportsEntity randomReport)
        {
            if (report == null)
            {
                report = randomReport;
            }

            this.MiDashboard
                .SetPoV(report.PoV)
                .OpenReportNext(report.Name, report.Cluster);
        }
    }
}