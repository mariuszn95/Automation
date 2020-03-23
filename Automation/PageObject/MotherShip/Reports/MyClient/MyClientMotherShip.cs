namespace Automation.PageObject.MotherShip.Reports.MyClient
{
    using System;
    using System.Globalization;

    using Automation.PageObject.Entities;
    using Automation.PageObject.MotherShip;
    using Automation.PageObject.MotherShip.Reports;

    public class MyClientMotherShip
    {
        public static string GetReportDateString(DateTime date)
        {
            return date.ToString("MMM yyyy", CultureInfo.GetCultureInfo("en-us"));
        }

        public static ReportsEntity CifList()
        {
            return new ReportsEntity
            {
                Code = "CRP301",
                Cluster = "My Client",
                Title = "My Client - CIF List",
                Name = "CIF List",
                PoV = PoVMotherShip.PwmcController20326(),
                Date = GetReportDateString(ReportsMotherShip.DataLoadStatus.MyClient),
            };
        }

        public static ReportsEntity ClientGroupList()
        {
            return new ReportsEntity
            {
                Code = "CRP265",
                Cluster = "My Client",
                Title = "My Client - Client Group List",
                Name = "Client Group List",
                PoV = PoVMotherShip.PwmcControllerA405523(),
                Date = GetReportDateString(ReportsMotherShip.DataLoadStatus.MyClient),
                Vt = "Direct revenues (E6010)",
            };
        }

        public static ReportsEntity ClientGroupList13Months()
        {
            var report = ClientGroupList();
            report.Code = $"{ClientGroupList().Code}A";
            report.Name = $"{ClientGroupList().Name} 13m";
            report.Title = $"{ClientGroupList().Title} 13m";
            report.ThirteenMonths = false;
            return report;
        }

        public static ReportsEntity ClientList()
        {
            return new ReportsEntity
            {
                Code = "CRP303",
                Cluster = "My Client",
                Title = "My Client - Client List",
                Name = "Client List",
                PoV = PoVMotherShip.PwmcControllerA405523(),
                Date = GetReportDateString(ReportsMotherShip.DataLoadStatus.MyClient),
                Vt = "Direct revenues (E6010)",
                Currency = "CHF",
            };
        }

        public static ReportsEntity KeyFigures()
        {
            return new ReportsEntity
            {
                Code = "CRP262",
                Cluster = "My Client",
                Title = "My Client - Key Figures",
                Name = "Key Figures",
                PoV = PoVMotherShip.PwmcController20326(),
                Date = GetReportDateString(ReportsMotherShip.DataLoadStatus.MyClient),
                ThirteenMonths = true,
            };
        }

        public static ReportsEntity KeyFigures13Months()
        {
            var report = KeyFigures();
            report.Code = $"{KeyFigures().Code}A";
            report.Name = $"{KeyFigures().Name} 13m";
            report.Title = $"{KeyFigures().Title} 13m";
            report.ThirteenMonths = false;
            return report;
        }

        public static ReportsEntity ClientProfile()
        {
            return new ReportsEntity
            {
                Code = "CRP272",
                Cluster = "My Client",
                Title = "My Client - Client Profile",
                Name = "Client Profile",
                PoV = PoVMotherShip.PwmcController29894(),
                Date = GetReportDateString(ReportsMotherShip.DataLoadStatus.MyClient),
                ThirteenMonths = false,
            };
        }

        public static ReportsEntity OrganizationalBreakdown()
        {
            return new ReportsEntity
            {
                Code = "CRP204",
                Cluster = "My Client",
                Title = "My Client - Organizational Breakdown",
                Name = "Organizational Breakdown",
                PoV = PoVMotherShip.PwmcController20326(),
                Date = GetReportDateString(ReportsMotherShip.DataLoadStatus.MyClient),
                Vt = "Direct revenues (E6010)",
                Currency = "kCHF",
                ThirteenMonths = true,
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

        public static ReportsEntity Profitability()
        {
            return new ReportsEntity()
            {
                Code = "CRP206",
                Cluster = "My Client",
                Name = "Profitability",
                Title = "My Client - Profitability",
                Date = $"{GetReportDateString(ReportsMotherShip.DataLoadStatus.MyClient)}",
                PoV = PoVMotherShip.PwmcManager20326(),
                ThirteenMonths = true,
            };
        }

        public static ReportsEntity Profitability13Months()
        {
            var report = Profitability();
            report.Name = $"{Profitability().Name} 13m";
            report.Title = $"{Profitability().Title} 13m";
            report.Code = $"{Profitability().Code}A";
            report.ThirteenMonths = false;
            return report;
        }

        public static ReportsEntity ProfitabilityTopEams()
        {
            return new ReportsEntity()
            {
                Code = "CRP286",
                Cluster = "My Client",
                Name = "Profitability Top EAMs",
                Title = "My Client - Profitability Top EAMs, selected by Direct revenues (E6010)",
                Date = $"{GetReportDateString(ReportsMotherShip.DataLoadStatus.MyClient)}",
                PoV = PoVMotherShip.ExternalAssetManager91320(),
            };
        }

        public static ReportsEntity RmList()
        {
            return new ReportsEntity
            {
                Code = "CRP302",
                Cluster = "My Client",
                Title = "My Client - RM List",
                Name = "RM List",
                PoV = PoVMotherShip.PwmcController20326(),
                Date = GetReportDateString(ReportsMotherShip.DataLoadStatus.MyClient),
            };
        }

        public static ReportsEntity ServiceBreakdown()
        {
            return new ReportsEntity
            {
                Code = "CRP205",
                Cluster = "My Client",
                Title = "My Client - Service Breakdown",
                Name = "Service Breakdown",
                PoV = PoVMotherShip.PwmcController20326(),
                Date = GetReportDateString(ReportsMotherShip.DataLoadStatus.MyClient),
                Vt = "Direct revenues (E6010)",
                Currency = "kCHF",
                ThirteenMonths = true,
            };
        }

        public static ReportsEntity ServiceBreakdown13Months()
        {
            var report = ServiceBreakdown();
            report.Code = $"{ServiceBreakdown().Code}A";
            report.Name = $"{ServiceBreakdown().Name} 13m";
            report.Title = $"{ServiceBreakdown().Title} 13m";
            report.ThirteenMonths = false;
            return report;
        }

        public static ReportsEntity Stt()
        {
            return new ReportsEntity
            {
                Code = "CRP241",
                Cluster = "My Client",
                Title = "My Client - Special Tariffs Terms",
                Name = "STT",
                PoV = PoVMotherShip.PwmcController20326(),
                Date = GetReportDateString(ReportsMotherShip.DataLoadStatus.MyClient),
                ThirteenMonths = false,
            };
        }

        public static ReportsEntity TopBottom()
        {
            return new ReportsEntity
            {
                Cluster = "My Client",
                Code = "CRP211",
                Title = "My Client - Top-Bottom",
                Name = "Top-Bottom",
                PoV = PoVMotherShip.PwmcController20326(),
                Date = GetReportDateString(ReportsMotherShip.DataLoadStatus.MyClient),
                Vt = "Direct revenues (E6010)",
                Currency = "CHF",
            };
        }

        public static ReportsEntity VolumeAndGrowth()
        {
            return new ReportsEntity
            {
                Code = "CRP261",
                Cluster = "My Client",
                Title = "My Client - Volume & Growth",
                Name = "Volume & Growth",
                PoV = PoVMotherShip.PwmcController20326(),
                Date = GetReportDateString(ReportsMotherShip.DataLoadStatus.MyClient),
                ThirteenMonths = true,
            };
        }

        public static ReportsEntity VolumeAndGrowth13Months()
        {
            var report = VolumeAndGrowth();
            report.Code = $"{VolumeAndGrowth().Code}A";
            report.Name = $"{VolumeAndGrowth().Name} 13m";
            report.Title = $"{VolumeAndGrowth().Title} 13m";
            report.ThirteenMonths = false;
            return report;
        }

        public static ReportsEntity EamList()
        {
            return new ReportsEntity
            {
                Code = "CRP384",
                Cluster = "My Client",
                Title = "My Client - EAM List",
                Name = "EAM List",
                PoV = PoVMotherShip.ExternalAssetManagController11029(),
                Date = GetReportDateString(ReportsMotherShip.DataLoadStatus.MyClient),
            };
        }

        public static ReportsEntity EamAndEndClientList()
        {
            return new ReportsEntity
            {
                Code = "CRP282",
                Cluster = "My Client",
                Title = "My Client - EAM & End-Client List",
                Name = "EAM & End-Client List",
                PoV = PoVMotherShip.ExternalAssetManagController11029(),
                Date = GetReportDateString(ReportsMotherShip.DataLoadStatus.MyClient),
            };
        }

        public static ReportsEntity EamAndEndClientList13M()
        {
            {
                var report = EamAndEndClientList();
                report.Code = $"{EamAndEndClientList().Code}A";
                report.Name = $"{EamAndEndClientList().Name} 13m";
                report.Title = $"{EamAndEndClientList().Title} 13m";
                report.ThirteenMonths = false;
                return report;
            }
        }
    }
}