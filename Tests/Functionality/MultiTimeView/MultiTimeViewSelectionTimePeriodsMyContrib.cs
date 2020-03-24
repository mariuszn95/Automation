namespace Tests.Functionality.MultiTimeView
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    using Automation.Helpers.Extensions;
    using Automation.PageObject.Entities;
    using Automation.PageObject.MotherShip.Reports;
    using Automation.PageObject.MotherShip.Reports.MyContribution;

    using NUnit.Framework;

    public class MultiTimeViewSelectionTimePeriodsMyContrib : FunctionalityBase
    {
        private readonly ReportsEntity randomReport = RandomReport();

        [Test]
        public void Test([Values(null)] ReportsEntity report)
        {
            this.SetUp(ref report, this.randomReport);

            var date = ReportsMotherShip.DataLoadStatus.MyContributionRmIcTeam;

            List<string> months = new List<string>
            {
                date.AddMonths(-1).ToString("MMM yy", CultureInfo.GetCultureInfo("en-us")),
                date.ToString("MMM yy", CultureInfo.GetCultureInfo("en-us")),
                $"{date.ToString("MMM yy", CultureInfo.GetCultureInfo("en-us"))} YTD",
            };

            this.Report
                .Verify.TimeViewsOnReport(months);
            this.Header
                .ClickCustomizeTheReportButton()
                .ClickTimePeriods()
                .VerifyDefaultView()
                .VerifyTimeViewsOnAppliedValues(months)
                .ClickYtdButton()
                .ClickCancelButton();
            this.Pov.ChangeDateTo(RandomData.Date());
            this.Pov.ChangeDateTo(RandomData.Date(date.AddMonths(-12), date));
            this.Header
                .ClickCustomizeTheReportButton()
                .ClickTimePeriods()
                .AddAtLeastOneTimePeriodFromMonthlyView(ref months)
                .VerifyTimeViewsOnAppliedValues(months)
                .ClickYtdButton()
                .VerifyTimeViewsOnCalendar(months)
                .ClickSubmitButton();
        }

        private static ReportsEntity RandomReport()
        {
            var listOfReports = new List<ReportsEntity>
            {
                MyContributionMotherShip.ManagedCif(),
                MyContributionMotherShip.ManagedCifForIc(),
                MyContributionMotherShip.RmList(),
            };

            return listOfReports[new Random().Next(listOfReports.Count)];
        }
    }
}