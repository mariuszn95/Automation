namespace Automation.PageObject.Pages.Report
{
    using System.Reflection;

    using Automation.Helpers.DriverHelpers;
    using Automation.Helpers.Logger;

    internal class ReportsActions : ReportsElements
    {
        internal void NavigateToPage(string pageNumber)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.CurrentPageInput.EnterValueByJs(pageNumber);
            Wait.ForRollerOnReportsToGoAway();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        internal bool ValidateSortedColumn(int columnNumber)
        {
            LoggerPage.LogReturn(MethodBase.GetCurrentMethod().Name, columnNumber);

            return this.SortColumnSigns.GetText(columnNumber) == "u";
        }
    }
}