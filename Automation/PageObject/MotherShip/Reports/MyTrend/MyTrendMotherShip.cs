namespace Automation.PageObject.MotherShip.Reports.MyTrend
{
    using System;
    using System.Globalization;

    using Automation.Helpers.Extensions;
    using Automation.PageObject.Entities;
    using Automation.PageObject.MotherShip;
    using Automation.PageObject.MotherShip.Reports;

    public class MyTrendMotherShip
    {
        public static ReportsEntity CifList()
        {
            return new ReportsEntity
            {
                Code = "DTR701",
                Cluster = "My Trend",
                Name = "CIF List",
                Title = "NNA Trend - CIF List",
                PoV = PoVMotherShip.PwmcController20326(),
                Date = GetReportDateCifListString(ReportsMotherShip.DataLoadStatus.MyTrend),
            };
        }

        public static ReportsEntity RmList()
        {
            return new ReportsEntity
            {
                Code = "DTR705",
                Cluster = "My Trend",
                Name = "RM List",
                Title = "NNA Trend - RM List",
                PoV = PoVMotherShip.PwmcController20326(),
                Date = GetReportDateOverviewString(ReportsMotherShip.DataLoadStatus.MyTrend),
            };
        }

        public static ReportsEntity OrganizationalBreakdownOverview()
        {
            return new ReportsEntity()
            {
                Cluster = "My Trend",
                Code = "DTR106",
                Name = "Organizational Breakdown Overview",
                Title = "NNA Trend - Organizational Breakdown Overview",
                PoV = PoVMotherShip.PwmcController20504(),
                Date = GetReportDateOverviewString(ReportsMotherShip.DataLoadStatus.MyTrend),
                Vt = "Client NNA (B5801)",
                SingleTimeView = "Weekly",
                Currency = "mCHF",
            };
        }

        public static ReportsEntity OrganizationalBreakdown()
        {
            return new ReportsEntity()
            {
                Cluster = "My Trend",
                Code = "DTR103",
                Name = "Organizational Breakdown",
                Title = "NNA Trend - Organizational Breakdown",
                PoV = PoVMotherShip.PwmcController20504(),
                Date = GetReportDateOverviewString(ReportsMotherShip.DataLoadStatus.MyTrend),
                SingleTimeView = "Weekly",
                Currency = "kCHF",
            };
        }

        public static ReportsEntity Overview()
        {
            return new ReportsEntity()
            {
                Cluster = "My Trend",
                Code = "DTR102",
                Name = "Overview",
                Title = "NNA Trend - Overview",
                PoV = PoVMotherShip.PwmcControllerA449958(),
                Date = GetReportDateOverviewString(ReportsMotherShip.DataLoadStatus.MyTrend),
                SingleTimeView = "Weekly",
                Currency = "kCHF",
            };
        }

        public static ReportsEntity YtdOverview()
        {
            return new ReportsEntity()
                       {
                           Cluster = "My Trend",
                           Code = "DTR104",
                           Name = "YTD Overview",
                           Title = "NNA Trend - YTD Overview",
                           PoV = PoVMotherShip.PwmcControllerA625957(),
                           Date = GetReportDateYtdOverviewString(ReportsMotherShip.DataLoadStatus.MyTrend),
                           SingleTimeView = "Weekly",
                           Currency = "kCHF",
                       };
        }

        public static ReportsEntity YtdOverview13Months()
        {
            var report = YtdOverview();
            report.Code = $"{YtdOverview().Code}A";
            report.Name = $"{YtdOverview().Name} 13m";
            report.Title = $"{YtdOverview().Title} 13m";
            report.ThirteenMonths = false;
            return report;
        }

        public static string GetReportDateCifListString(DateTime date)
        {
            return date.ToString("dd.MM.yyyy");
        }

        public static string GetReportDateOverviewString(DateTime date)
        {
            int week = date.GetWeekOfTheYear();
            DateTime weekStartDate = DateExtensions.GetFirstDateOfWeek(date.Year, week);

            return $@"Week {week} {date.Year} ({weekStartDate:dd.MM.yyyy} - {weekStartDate.AddDays(6):dd.MM.yyyy})";
        }

        public static string GetReportDateYtdOverviewString(DateTime date)
        {
            return $@"{date.ToString("MMM yyyy", CultureInfo.GetCultureInfo("en-us"))}, Trend Date: {date:dd.MM.yyyy}";
        }
    }
}