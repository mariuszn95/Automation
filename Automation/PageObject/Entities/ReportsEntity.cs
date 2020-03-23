namespace Automation.PageObject.Entities
{
    using System;

    using Automation.Helpers.Extensions;

    public class ReportsEntity
    {
        public string Title { get; set; }

        public string Date { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public PoVEntity PoV { get; set; }

        public string RightFooter
        {
            get
            {
                return $"User: {Environment.UserName} {DateTime.Today.DayOfWeek} {DateExtensions.CurrentMonth} {DateExtensions.CurrentDay}, {DateTime.Today.Year}";
            }
        }

        public string Url { get; set; }

        public WidgetsEntity Widget { get; set; }

        public string Vt { get; set; }

        public string SingleTimeView { get; set; }

        public bool ThirteenMonths { get; set; }

        public string Currency { get; set; }

        public string TitleTab { get; set; }

        public string Cluster { get; set; }

        public string OrganizationUnitSign { get; set; } = string.Empty;

        public string LeftFooter(bool isNna = false)
        {
            if (isNna)
            {
                return $"{this.PoV.BusinessGroup} {this.OrganizationUnitSign}/ {this.PoV.BusinessFunctionShort} {this.Code.ToUpper()} CONFIDENTIAL Daily flows - not to be reconciled with monthly data.";
            }

            return $"{this.PoV.BusinessGroup} {this.OrganizationUnitSign}/ {this.PoV.BusinessFunctionShort} {this.Code.ToUpper()} CONFIDENTIAL";
        }
    }
}