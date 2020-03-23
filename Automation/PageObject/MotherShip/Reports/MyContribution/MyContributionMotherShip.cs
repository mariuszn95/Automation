namespace Automation.PageObject.MotherShip.Reports.MyContribution
{
    using System;
    using System.Globalization;

    using Automation.Helpers;
    using Automation.PageObject.Entities;

    public class MyContributionMotherShip
    {
        public static string GetReportDateRmIcTeamString(DateTime date)
        {
            return date.ToString("MMM yyyy", CultureInfo.GetCultureInfo("en-us"));
        }

        public static string GetReportDateOuPcString(DateTime date)
        {
            return
                $"{date.ToString("MMM yyyy", CultureInfo.GetCultureInfo("en-us"))} OE FINAL";
        }

        public static ReportsEntity IcScorecard()
        {
            return new ReportsEntity
            {
                Code = "EPVIC303",
                Cluster = "My Contribution",
                Title = "My Contribution - IC Scorecard",
                Name = "IC Scorecard",
                PoV = PoVMotherShip.PwmcIcA154842(),
                Date = GetReportDateRmIcTeamString(ReportsMotherShip.DataLoadStatus.MyContributionRmIcTeam),
                ThirteenMonths = true,
                OrganizationUnitSign = "DC ",
            };
        }

        public static ReportsEntity IcScorecard13Months()
        {
            var report = IcScorecard();
            report.Code = $"{IcScorecard().Code}A";
            report.Name = $"{IcScorecard().Name} 13m";
            report.Title = $"{IcScorecard().Title} 13m";
            report.ThirteenMonths = false;
            return report;
        }

        public static ReportsEntity IcSourceReport()
        {
            return new ReportsEntity
            {
                Code = "EPVIC310",
                Cluster = "My Contribution",
                Title = "My Contribution - Source Report",
                Name = "Source Report",
                PoV = PoVMotherShip.PwmcIcA666135(),
                Date = GetReportDateRmIcTeamString(ReportsMotherShip.DataLoadStatus.MyContributionRmIcTeam),
                ThirteenMonths = true,
                Vt = "Inv. business revenue transaction-based (E8119)",
                SingleTimeView = "YTD",
                Currency = "kCHF",
                OrganizationUnitSign = "DC ",
            };
        }

        public static ReportsEntity IcSourceReport13Months()
        {
            var report = IcSourceReport();
            report.Code = $"{IcSourceReport().Code}A";
            report.Name = $"{IcSourceReport().Name} 13m";
            report.Title = $"{IcSourceReport().Title} 13m";
            report.ThirteenMonths = false;
            return report;
        }

        public static ReportsEntity ManagedCif()
        {
            return new ReportsEntity
            {
                Code = "EPV701",
                Cluster = "My Contribution",
                Name = "Managed CIF",
                Title = "My Contribution - Currently Managed CIFs",
                TitleTab = "My Contribution - Managed CIF",
                PoV = PoVMotherShip.PwmcManagerA449958(),
                Date = GetReportDateRmIcTeamString(ReportsMotherShip.DataLoadStatus.MyContributionRmIcTeam),
                OrganizationUnitSign = "DC ",
            };
        }

        public static ReportsEntity ManagedCifForIc()
        {
            return new ReportsEntity
            {
                Code = "EPVIC701",
                Cluster = "My Contribution",
                Name = "Managed CIF",
                Title = "My Contribution - Currently Managed CIFs",
                PoV = PoVMotherShip.PwmcIcA154842(),
                Date = GetReportDateRmIcTeamString(ReportsMotherShip.DataLoadStatus.MyContributionRmIcTeam),
                OrganizationUnitSign = "DC ",
            };
        }

        public static ReportsEntity OrganizationalBreakdown()
        {
            return new ReportsEntity
            {
                Cluster = "My Contribution",
                Name = "Organizational Breakdown",
                OrganizationUnitSign = "TF ",
                Title = "My Contribution - Organizational Breakdown",
                PoV = PoVMotherShip.PwmcController20326(),
                Date = GetReportDateOuPcString(ReportsMotherShip.DataLoadStatus.MyContributionOuPc),
                Vt = "Revenues after CoC/ACP (SUB) (E8774)",
                SingleTimeView = "YTD",
                Currency = "kCHF",
                ThirteenMonths = true,
                Code = "OPV404",
            };
        }

        public static ReportsEntity OrganizationalBreakdown13Months()
        {
            var report = OrganizationalBreakdown();
            report.Code = $"{OrganizationalBreakdown().Code}A";
            report.Name = $"{OrganizationalBreakdown().Name} 13m";
            report.Title = $"{OrganizationalBreakdown().Title} 13m";
            report.ThirteenMonths = false;
            return report;
        }

        public static ReportsEntity RmList()
        {
            return new ReportsEntity
            {
                Code = "OPV702",
                Cluster = "My Contribution",
                Name = "RM List",
                Title = "My Contribution - RM List",
                Date = GetReportDateOuPcString(ReportsMotherShip.DataLoadStatus.MyContributionOuPc),
                PoV = PoVMotherShip.PwmcController20326(),
                OrganizationUnitSign = "TF ",
            };
        }

        public static ReportsEntity LineManagerRmList()
        {
            return new ReportsEntity
            {
                Cluster = "My Contribution",
                Code = "EPV705",
                Name = "Line Manager RM List",
                Title = "My Contribution - Line Manager RM List",
                Date = GetReportDateOuPcString(ReportsMotherShip.DataLoadStatus.MyContributionOuPc),
                PoV = PoVMotherShip.PwmcTeamHead20601(),
                ThirteenMonths = false,
                OrganizationUnitSign = "TF ",
            };
        }

        public static ReportsEntity LineManagerIcList()
        {
            return new ReportsEntity
            {
                Cluster = "My Contribution",
                Code = "EPVIC705",
                Name = "Line Manager IC List",
                Title = "My Contribution - Line Manager IC List",
                Date = GetReportDateOuPcString(ReportsMotherShip.DataLoadStatus.MyContributionOuPc),
                PoV = PoVMotherShip.PwmcIcTeamHead21404(),
                ThirteenMonths = false,
                OrganizationUnitSign = "DC ",
            };
        }

        public static ReportsEntity RmScorecard()
        {
            return new ReportsEntity
                       {
                           Cluster = "My Contribution",
                           Code = "EPV303",
                           Name = "RM Scorecard",
                           OrganizationUnitSign = "DC ",
                           Title = "My Contribution - RM Scorecard",
                           Date = GetReportDateRmIcTeamString(ReportsMotherShip.DataLoadStatus.MyContributionRmIcTeam),
                           Url = $"{TestContexts.BaseAddress}/reports?oe=120046&bg=PC%20CH&bf=RM&currency=214&date=04.09.2019&code=epv303&title=My%20Contribution%20-%20RM%20Scorecard&performanceView=",
                           PoV = PoVMotherShip.PwmcManagerA154842(),
                           ThirteenMonths = true,
                       };
        }

        public static ReportsEntity RmScorecard13Months()
        {
            var report = RmScorecard();
            report.Code = $"{RmScorecard().Code}A";
            report.Name = $"{RmScorecard().Name} 13m";
            report.Title = $"{RmScorecard().Title} 13m";
            report.ThirteenMonths = false;
            return report;
        }

        public static ReportsEntity SourceReport()
        {
            return new ReportsEntity
            {
                Code = "EPV310",
                Cluster = "My Contribution",
                Name = "Source Report",
                Title = "My Contribution - Source Report",
                PoV = PoVMotherShip.PwmcManagerA154842(),
                Date = GetReportDateRmIcTeamString(ReportsMotherShip.DataLoadStatus.MyContributionRmIcTeam),
                Vt = "PWMC Non-deposit Revenues (E9016)",
                SingleTimeView = "YTD",
                Currency = "CHF",
                ThirteenMonths = true,
                OrganizationUnitSign = "DC ",
            };
        }

        public static ReportsEntity SourceReport13Months()
        {
            var report = SourceReport();
            report.Code = $"{SourceReport().Code}A";
            report.Name = $"{SourceReport().Name} 13m";
            report.Title = $"{SourceReport().Title} 13m";
            report.ThirteenMonths = false;
            return report;
        }

        public static ReportsEntity TeamPcScorecard()
        {
            return new ReportsEntity
            {
                Code = "OPV403",
                Cluster = "My Contribution",
                Name = "Team/PC Scorecard",
                Title = "My Contribution - Team/PC Scorecard",
                PoV = PoVMotherShip.PwmcController20326(),
                Date = GetReportDateOuPcString(ReportsMotherShip.DataLoadStatus.MyContributionOuPc),
                ThirteenMonths = true,
                OrganizationUnitSign = "TF ",
            };
        }

        public static ReportsEntity TeamPcScorecard13Months()
        {
            var report = TeamPcScorecard();
            report.Code = $"{TeamPcScorecard().Code}a";
            report.Name = $"{TeamPcScorecard().Name} 13m";
            report.Title = $"{TeamPcScorecard().Title} 13m";
            report.ThirteenMonths = false;
            return report;
        }

        public static ReportsEntity TeamPcSourceReport()
        {
            return new ReportsEntity
            {
                Code = "OPV410",
                Cluster = "My Contribution",
                Name = "Team/PC Source Report",
                Title = "My Contribution - Team/PC Source Report",
                PoV = PoVMotherShip.PwmcController20326(),
                Date = GetReportDateOuPcString(ReportsMotherShip.DataLoadStatus.MyContributionOuPc),
                ThirteenMonths = true,
            };
        }

        public static ReportsEntity TeamPcSourceReport13Months()
        {
            var report = TeamPcSourceReport();
            report.Code = $"{TeamPcSourceReport().Code}a";
            report.Name = $"{TeamPcSourceReport().Name} 13m";
            report.Title = $"{TeamPcSourceReport().Title} 13m";
            report.ThirteenMonths = false;
            return report;
        }
    }
}