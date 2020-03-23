namespace Automation.PageObject.Pages.Report.Header
{
    using Automation.Elements.Basic;
    using Automation.PageObject.Locators.Report;

    public class ReportsHeaderElements
    {
        internal Button ReportTitle => new Button(ReportHeaderLocators.ReportTitle);

        internal Label OrganizationUnitAndDate => new Label(ReportHeaderLocators.OrganizationUnitAndDate);

        internal Dropdown SingleVtButton => new Dropdown(ReportHeaderLocators.SingleVtButton);

        internal Dropdown SingleVtSelectedItem => new Dropdown(ReportHeaderLocators.SingleVtSelectedItem);

        internal Dropdown SingleVtList => new Dropdown(ReportHeaderLocators.SingleVtList);

        internal Dropdown SingleTimeView => new Dropdown(ReportHeaderLocators.SingleTimeView);

        internal Label CurrencyLabel => new Label(ReportHeaderLocators.Currency);

        internal Button CurrentlyManagedCifsButton => new Button(ReportHeaderLocators.CurrentlyManagedCifsButton);

        internal Button PreviouslyManagedCifsButton => new Button(ReportHeaderLocators.PreviouslyManagedCifsButton);

        internal Button ThirteenMonthsButton => new Button(ReportHeaderLocators.ThirteenMonthsButton);

        internal Button FiltersButton => new Button(ReportHeaderLocators.FiltersButton);

        internal Button ReloadButton => new Button(ReportHeaderLocators.ReloadButton);

        internal Button ExcelButton => new Button(ReportHeaderLocators.ExcelButton);

        internal Button PdfButton => new Button(ReportHeaderLocators.PdfButton);

        internal Button SaveButton => new Button(ReportHeaderLocators.SaveButton);
    }
}