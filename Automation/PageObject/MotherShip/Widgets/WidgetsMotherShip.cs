namespace Automation.PageObject.MotherShip.Widgets
{
    using Automation.PageObject.Entities;

    public class WidgetsMotherShip
    {
        public static WidgetsEntity GrossMargin()
        {
            return new WidgetsEntity()
                       {
                           Title = "Gross margin (DC) on avg business volume",
                           VtValue = "Gross margin (DC) on avg business volume (O5314)",
                       };
        }

        // 1AE6D92A-D1EA-5ABF-ADB6-5428AA31E1D8     MyClient Org breakdown  CRP204  4   CONTROLLER  PWMC
        public static WidgetsEntity MyClientOrgBreakdownRsaCollaboration()
        {
            return new WidgetsEntity()
                       {
                           Title = "MyClient Org breakdown RSA collaboration",
                           VtValue = "RSA collaboration (E6072)",
                       };
        }

        public static WidgetsEntity Repurchases()
        {
            return new WidgetsEntity() { Title = "Repurchases", };
        }
    }
}