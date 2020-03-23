namespace Automation.PageObject.MotherShip.Reports
{
    using System;

    using Automation.Models;
    using Automation.PageObject.Entities;
    using Automation.PageObject.Pages;

    public class ReportsMotherShip
    {
        public static DataLoadStatus DataLoadStatus = new DataLoadStatus(DefaultDataLoadStatusDate);

        private static readonly DateTime DefaultDataLoadStatusDate = DateTime.Now;

        public static ReportsEntity CreateReportEntity(string name, string title, string code, PoVEntity pov, string date, string singleTimeView = null, bool thirteenMonths = false)
        {
            var report = new ReportsEntity
            {
                Name = thirteenMonths == false ? name : $"{name} 13m",
                Title = thirteenMonths == false ? title : $"{title} 13m",
                Code = code,
                PoV = pov,
                Date = date,
                SingleTimeView = singleTimeView,
                ThirteenMonths = thirteenMonths,
            };

            return report;
        }

        public static void SetDataLoadStatuses(DataLoadStatusPage page)
        {
            DataLoadStatus.MyClient = string.IsNullOrEmpty(page.MyClient)
                ? DefaultDataLoadStatusDate
                : DateTime.Parse(page.MyClient);

            DataLoadStatus.MyContributionOuPc = string.IsNullOrEmpty(page.MyContributionOuPc)
                ? DefaultDataLoadStatusDate
                : DateTime.Parse(page.MyContributionOuPc);

            DataLoadStatus.MyContributionRmIcTeam = string.IsNullOrEmpty(page.MyContributionRmIcTeam)
                ? DefaultDataLoadStatusDate
                : DateTime.Parse(page.MyContributionRmIcTeam);

            DataLoadStatus.MySales = string.IsNullOrEmpty(page.MySales)
                ? DefaultDataLoadStatusDate
                : DateTime.Parse(page.MySales);

            DataLoadStatus.MyTrend = string.IsNullOrEmpty(page.MyTrend)
                ? DefaultDataLoadStatusDate
                : DateTime.Parse(page.MyTrend);
        }
    }
}