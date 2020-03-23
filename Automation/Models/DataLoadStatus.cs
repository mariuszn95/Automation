namespace Automation.Models
{
    using System;

    public class DataLoadStatus
    {
        public DataLoadStatus(DateTime date)
        {
            this.MyClient = date;
            this.MyContributionRmIcTeam = date;
            this.MyContributionOuPc = date;
            this.MySales = date;
            this.MyTrend = date;
        }

        public DateTime MyClient { get; set; }

        public DateTime MyContributionRmIcTeam { get; set; }

        public DateTime MyContributionOuPc { get; set; }

        public DateTime MySales { get; set; }

        public DateTime MyTrend { get; set; }
    }
}