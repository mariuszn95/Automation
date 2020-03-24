namespace Automation.Helpers.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Automation.PageObject.Entities;
    using Automation.PageObject.MotherShip.Reports.MyClient;
    using Automation.PageObject.MotherShip.Reports.MyContribution;
    using Automation.PageObject.MotherShip.Reports.MySales;
    using Automation.PageObject.MotherShip.Reports.MyTrend;

    public class RandomData
    {
        public static string GetCurrency()
        {
            List<string> currenciesList = new List<string> { "CHF", "USD", "EUR", "GBP", "AUD", "JPY" };

            return currenciesList[new Random().Next(currenciesList.Count)];
        }

        public static string GetCurrencyWithout(string currency)
        {
            List<string> currenciesList = new List<string> { "CHF", "USD", "EUR", "GBP", "AUD", "JPY" };
            currenciesList.Remove(currency);

            return currenciesList[new Random().Next(currenciesList.Count - 1)];
        }

        public static string GetOrganizationUnitNoWithout(string organizationUnit)
        {
            List<string> organizationUnitsList = new List<string>
                                                  {
                                                      "A405523",
                                                      "A449958",
                                                      "A625957",
                                                      "A154842",
                                                  };
            organizationUnitsList.Remove(organizationUnit);

            return organizationUnitsList[new Random().Next(organizationUnitsList.Count - 1)];
        }

        public static string GetBusinessGroupWithout(string businessGroup)
        {
            List<string> businessGroupsList = new List<string>
            {
                "PWMC",
                "PWMC Mortgage Center",
                "PWMC Mortgage Experts with CIF",
                "PWMC Floor Manager",
                "PWMC Entrepreneurs & Executives",
            };
            businessGroupsList.Remove(businessGroup);

            return businessGroupsList[new Random().Next(businessGroupsList.Count - 1)];
        }

        public static string GetBusinessFunctionWithout(string businessFunction)
        {
            List<string> businessFunctionList = new List<string>
            {
                "CONTROLLER",
                "BUSINESS_SUPPORT",
                "BUSINESS_AREA_HEAD",
                "DEPARTMENT_HEAD",
                "MA_REGION_HEAD",
                "PROFIT_CENTER_HEAD",
                "TEAM_HEAD",
                "RELATIONSHIP_MANAGER",
                "ACCOUNT_MANAGER",
                "PRODUCT_SPECIALIST_SALES",
                "IC_TEAM_HEAD",
                "INVESTMENT_CONSULTANT",
                "MARKET_HEAD",
                "SERVICE_SPECIALIST",
                "TEST_USER",
                "DIP_EXPERT",
                "TEST_USER_DASHBOARD",
            };
            businessFunctionList.Remove(businessFunction);

            return businessFunctionList[new Random().Next(businessFunctionList.Count - 1)];
        }

        public static DateTime Date(DateTime? startDateOptional = null, DateTime? endDateOptional = null)
        {
            var startDate = new DateTime(2012, 1, 1);
            var endDate = new DateTime(2027, 12, 31);

            if (startDateOptional.HasValue)
            {
                startDate = (DateTime)startDateOptional;
            }

            if (endDateOptional.HasValue)
            {
                endDate = (DateTime)endDateOptional;
            }
            
            var hoursInRange = endDate - startDate;
            TimeSpan daysInRange = new TimeSpan(0, new Random().Next(0, (int)hoursInRange.TotalMinutes), 0);
            DateTime newDate = startDate + daysInRange;

            return newDate;
        }

        public static ReportsEntity GetReport()
        {
            List<ReportsEntity> reports = new List<ReportsEntity>
                                       {
                                           MyClientMotherShip.CifList(),
                                           MyClientMotherShip.ClientGroupList(),
                                           MyClientMotherShip.ClientList(),
                                           MyClientMotherShip.KeyFigures(),
                                           MyClientMotherShip.KeyFigures13Months(),
                                           MyClientMotherShip.OrganizationalBreakdown(),
                                           MyClientMotherShip.OrganizationalBreakdown13Months(),
                                           MyClientMotherShip.Profitability(),
                                           MyClientMotherShip.Profitability13Months(),
                                           MyClientMotherShip.RmList(),
                                           MyClientMotherShip.ServiceBreakdown(),
                                           MyClientMotherShip.ServiceBreakdown13Months(),
                                           MyClientMotherShip.Stt(),
                                           MyClientMotherShip.TopBottom(),
                                           MyClientMotherShip.VolumeAndGrowth(),
                                           MyClientMotherShip.VolumeAndGrowth13Months(),
                                           MyContributionMotherShip.IcScorecard(),
                                           MyContributionMotherShip.IcScorecard13Months(),
                                           MyContributionMotherShip.LineManagerIcList(),
                                           MyContributionMotherShip.LineManagerRmList(),
                                           MyContributionMotherShip.ManagedCif(),
                                           MyContributionMotherShip.ManagedCifForIc(),
                                           MyContributionMotherShip.OrganizationalBreakdown(),
                                           MyContributionMotherShip.OrganizationalBreakdown13Months(),
                                           MyContributionMotherShip.RmList(),
                                           MyContributionMotherShip.RmScorecard(),
                                           MyContributionMotherShip.RmScorecard13Months(),
                                           MyContributionMotherShip.SourceReport(),
                                           MyContributionMotherShip.SourceReport13Months(),
                                           MyContributionMotherShip.TeamPcScorecard(),
                                           MyContributionMotherShip.TeamPcScorecard13Months(),
                                           MySalesMotherShip.AssetClassBreakdown(),
                                           MySalesMotherShip.CifList(),
                                           MySalesMotherShip.OrganizationalBreakdown(),
                                           MySalesMotherShip.ProductList(),
                                           MySalesMotherShip.RmList(),
                                           MySalesMotherShip.TransactionList(),
                                           MyTrendMotherShip.CifList(),
                                           MyTrendMotherShip.Overview(),
                                           MyTrendMotherShip.RmList(),
                                           MyTrendMotherShip.YtdOverview(),
                                       };

            return reports[new Random().Next(reports.Count)];
        }

        public static ReportsEntity GetReport13Months()
        {
            List<ReportsEntity> reports = new List<ReportsEntity>
                                       {
                                           MyClientMotherShip.KeyFigures13Months(),
                                           MyClientMotherShip.OrganizationalBreakdown13Months(),
                                           MyClientMotherShip.Profitability13Months(),
                                           MyClientMotherShip.ServiceBreakdown13Months(),
                                           MyClientMotherShip.VolumeAndGrowth13Months(),
                                           MyContributionMotherShip.IcScorecard13Months(),
                                           MyContributionMotherShip.OrganizationalBreakdown13Months(),
                                           MyContributionMotherShip.RmScorecard13Months(),
                                           MyContributionMotherShip.SourceReport13Months(),
                                           MyContributionMotherShip.TeamPcScorecard13Months(),
                                       };

            return reports[new Random().Next(reports.Count)];
        }

        public static ReportsEntity GetReportOneMonth()
        {
            List<ReportsEntity> reports = new List<ReportsEntity>
                                       {
                                           MyClientMotherShip.CifList(),
                                           MyClientMotherShip.ClientGroupList(),
                                           MyClientMotherShip.ClientList(),
                                           MyClientMotherShip.KeyFigures(),
                                           MyClientMotherShip.OrganizationalBreakdown(),
                                           MyClientMotherShip.Profitability(),
                                           MyClientMotherShip.RmList(),
                                           MyClientMotherShip.ServiceBreakdown(),
                                           MyClientMotherShip.Stt(),
                                           MyClientMotherShip.TopBottom(),
                                           MyClientMotherShip.VolumeAndGrowth(),
                                           MyContributionMotherShip.IcScorecard(),
                                           MyContributionMotherShip.LineManagerIcList(),
                                           MyContributionMotherShip.LineManagerRmList(),
                                           MyContributionMotherShip.ManagedCif(),
                                           MyContributionMotherShip.ManagedCifForIc(),
                                           MyContributionMotherShip.OrganizationalBreakdown(),
                                           MyContributionMotherShip.RmList(),
                                           MyContributionMotherShip.RmScorecard(),
                                           MyContributionMotherShip.SourceReport(),
                                           MyContributionMotherShip.TeamPcScorecard(),
                                           MySalesMotherShip.AssetClassBreakdown(),
                                           MySalesMotherShip.CifList(),
                                           MySalesMotherShip.OrganizationalBreakdown(),
                                           MySalesMotherShip.ProductList(),
                                           MySalesMotherShip.RmList(),
                                           MySalesMotherShip.TransactionList(),
                                           MyTrendMotherShip.CifList(),
                                           MyTrendMotherShip.Overview(),
                                           MyTrendMotherShip.RmList(),
                                           MyTrendMotherShip.YtdOverview(),
                                       };

            return reports[new Random().Next(reports.Count)];
        }

        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}