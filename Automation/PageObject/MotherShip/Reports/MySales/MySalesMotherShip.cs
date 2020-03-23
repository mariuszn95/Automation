namespace Automation.PageObject.MotherShip.Reports.MySales
{
    using System;

    using Automation.PageObject.Entities;
    using Automation.PageObject.MotherShip;
    using Automation.PageObject.MotherShip.Reports;

    public class MySalesMotherShip
    {
        public static string GetReportDateString(DateTime date)
        {
            return date.ToString("dd.MM.yyyy");
        }

        public static ReportsEntity AssetClassBreakdown()
        {
            var report = ReportsMotherShip.CreateReportEntity(
                "Asset Class Breakdown",
                "My Sales - Asset Class Breakdown",
                "PRP105k",
                PoVMotherShip.PwmcManagerA449958(),
                GetReportDateString(ReportsMotherShip.DataLoadStatus.MySales),
                "Monthly");
            report.Cluster = "My Sales";
            return report;
        }

        public static ReportsEntity AssetClassBreakdown13Months()
        {
            var report = AssetClassBreakdown();
            report.Code = "PRP105A";
            report.Name = $"{AssetClassBreakdown().Name} 13m";
            report.Title = $"{AssetClassBreakdown().Title} 13m";
            report.ThirteenMonths = false;
            report.Vt = "Gross Sales (F3010)";
            report.Currency = "kCHF";
            return report;
        }

        public static ReportsEntity CifList()
        {
            return new ReportsEntity
            {
                Code = "PRP701",
                Cluster = "My Sales",
                Name = "CIF List",
                Title = "My Sales - CIF List",
                PoV = PoVMotherShip.PwmcController20326(),
                Date = GetReportDateString(ReportsMotherShip.DataLoadStatus.MySales),
            };
        }

        public static ReportsEntity OrganizationalBreakdown()
        {
            return new ReportsEntity
            {
                Code = "PRP104K",
                Cluster = "My Sales",
                Name = "Organizational Breakdown",
                Title = "My Sales - Organizational Breakdown",
                PoV = PoVMotherShip.PwmcController20326(),
                Date = GetReportDateString(ReportsMotherShip.DataLoadStatus.MySales),
                SingleTimeView = "Monthly",
            };
        }

        public static ReportsEntity OrganizationalBreakdown13M()
        {
            return new ReportsEntity
            {
                Code = "PRP104a",
                Cluster = "My Sales",
                Name = "Organizational Breakdown 13m",
                Title = "My Sales - Organizational Breakdown 13m",
                PoV = PoVMotherShip.PwmcController20326(),
                Date = GetReportDateString(ReportsMotherShip.DataLoadStatus.MySales),
                SingleTimeView = "Monthly",
            };
        }

        public static ReportsEntity RmList()
        {
            return new ReportsEntity
                       {
                           Cluster = "My Sales",
                           Code = "PRP702",
                           Name = "RM List",
                           Title = "My Sales - RM List",
                           PoV = PoVMotherShip.PwmcController20326(),
                           Date = GetReportDateString(ReportsMotherShip.DataLoadStatus.MySales),
                       };
        }

        public static ReportsEntity TransactionList()
        {
            return new ReportsEntity
                       {
                           Code = "PRP710",
                           Cluster = "My Sales",
                           Name = "Transaction List",
                           Title = "My Sales - Transaction List",
                           PoV = PoVMotherShip.PwmcManager20326(),
                           Date = GetReportDateString(ReportsMotherShip.DataLoadStatus.MySales),
                           SingleTimeView = "Monthly",
                       };
        }

        public static ReportsEntity ProductList()
        {
            return new ReportsEntity
                       {
                           Code = "PRP707",
                           Cluster = "My Sales",
                           Name = "Product List",
                           Title = "My Sales - Product List",
                           PoV = PoVMotherShip.PwmcManagerA405523(),
                           Date = GetReportDateString(ReportsMotherShip.DataLoadStatus.MySales),
                       };
        }
    }
}