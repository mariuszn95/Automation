namespace Tests.Functionality.MultiTimeView
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    using Automation.PageObject.Entities;
    using Automation.PageObject.MotherShip.Reports;
    using Automation.PageObject.MotherShip.Reports.MyContribution;
    using Automation.PageObject.MotherShip.Reports.ReportSettings;

    using NUnit.Framework;

    public class MultiTimeViewSelectionTimePeriodsMyContrib : FunctionalityBase
    {
        private readonly ReportsEntity randomReport = RandomReport();

        [Test]
        public void Test([Values(null)] ReportsEntity report)
        {
            this.SetUp(ref report, this.randomReport);

            List<string> months = TimePeriodsMotherShip.Actual();
            months.Add(ReportsMotherShip.DataLoadStatus.MyContributionRmIcTeam.AddMonths(-1).ToString("MMM yy", CultureInfo.GetCultureInfo("en-us")));
            months.Add(ReportsMotherShip.DataLoadStatus.MyContributionRmIcTeam.ToString("MMM yy", CultureInfo.GetCultureInfo("en-us")));
            months.Add($"{ReportsMotherShip.DataLoadStatus.MyContributionRmIcTeam.ToString("MMM yy", CultureInfo.GetCultureInfo("en-us"))} YTD");

            this.Report
                .Verify.AddedTimeViews(months);
            this.Header
                .ClickCustomizeTheReportButton()
                .ClickTimePeriods()
                .VerifyDefaultView()
                //.ClickCancelButton()
                .ClickYtdButton()
                .VerifyLayoutForYtdView()
                .AddAtLeastOneTimePeriodFromMonthlyView(ref months)
                .AddAtLeastOneTimePeriodFromYtdView(ref months)
                .ClickSubmitButton()
                .Verify.AddedTimeViews(months)
                .ClickCustomizeTheReportButton()
                .ClickTimePeriods()
                .VerifyAddedTimeViewsOnReportSettings(months);

            this.Header
                .ClickCustomizeTheReportButton()
                .ClickTimePeriods()
                .VerifyDefaultView()
                .VerifyLayoutForMonthlyView()
                .ClickYtdButton()
                .VerifyLayoutForYtdView()
                .AddAtLeastOneTimePeriodFromMonthlyView(ref months)
                .AddAtLeastOneTimePeriodFromYtdView(ref months)
                .ClickSubmitButton()
                .Verify.AddedTimeViews(months)
                .ClickCustomizeTheReportButton()
                .ClickTimePeriods()
                .VerifyAddedTimeViewsOnReportSettings(months);
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