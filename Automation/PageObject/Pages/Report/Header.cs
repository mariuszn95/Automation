namespace Automation.PageObject.Pages.Report
{
    using System.Reflection;

    using Automation.Elements.Basic;
    using Automation.Helpers.DriverHelpers;
    using Automation.Helpers.Logger;
    using Automation.PageObject.Entities;
    using Automation.PageObject.Pages.MiDashboardHeader;
    using Automation.PageObject.Pages.Report.Header;
    using Automation.PageObject.Pages.Report.Header.ReportSettings;

    using NUnit.Framework;

    using OpenQA.Selenium;

    public class ReportsHeaderPage : ReportsHeaderElements
    {
        public ReportsHeaderPage()
        {
            this.Verify = new ReportsHeaderVerify();
        }

        public ReportsHeaderVerify Verify { get; set; }

        public ReportsPage HeaderWithoutAnyCustomizationOption(ReportsEntity reportData)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.Verify.Title(reportData.Title);
            this.Verify.OrganizationUnit(reportData.PoV.OrganizationUnit);
            Assert.IsFalse(this.SingleVtButton.IsVisible());
            Assert.IsFalse(this.SingleTimeView.IsVisible());
            Assert.IsFalse(this.CurrencyLabel.IsVisible());

            Assert.IsFalse(this.CurrentlyManagedCifsButton.IsVisible());
            Assert.IsFalse(this.PreviouslyManagedCifsButton.IsVisible());

            if (reportData.ThirteenMonths)
            {
                this.ThirteenMonthsButton.IsVisible();
            }
            else
            {
                Assert.IsFalse(this.ThirteenMonthsButton.IsVisible());
            }

            Assert.IsFalse(this.FiltersButton.IsVisible());
            Assert.IsTrue(this.ReloadButton.IsVisible());
            Assert.IsTrue(this.ExcelButton.IsVisible());
            Assert.IsTrue(this.PdfButton.IsVisible());
            Assert.IsTrue(this.SaveButton.IsVisible());

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage HeaderWithSingleTimeViewAndAnyMultiOption(ReportsEntity reportData)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.Verify.Title(reportData.Title);
            this.Verify.OrganizationUnit(reportData.PoV.OrganizationUnit);
            Assert.IsFalse(this.SingleVtButton.IsVisible());
            Assert.IsTrue(this.SingleTimeView.IsVisible());
            Assert.IsFalse(this.CurrencyLabel.IsVisible());

            Assert.IsFalse(this.CurrentlyManagedCifsButton.IsVisible());
            Assert.IsFalse(this.PreviouslyManagedCifsButton.IsVisible());
            Assert.IsTrue(this.FiltersButton.IsVisible());
            Assert.IsTrue(this.ReloadButton.IsVisible());
            Assert.IsTrue(this.ExcelButton.IsVisible());
            Assert.IsTrue(this.PdfButton.IsVisible());
            Assert.IsTrue(this.SaveButton.IsVisible());

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage HeaderWithSingleVTsAndSingleTimeViewAndNoAttributes(ReportsEntity reportData)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.Verify.Title(reportData.Title);
            this.Verify.OrganizationUnit(reportData.PoV.OrganizationUnit);
            this.Verify.VtSelection(reportData.Vt);
            Assert.IsTrue(this.SingleTimeView.IsVisible());
            this.Verify.Currency(reportData.Currency);

            Assert.IsFalse(this.CurrentlyManagedCifsButton.IsVisible());
            Assert.IsFalse(this.PreviouslyManagedCifsButton.IsVisible());
            Assert.IsFalse(this.FiltersButton.IsVisible());
            Assert.IsTrue(this.ReloadButton.IsVisible());
            Assert.IsTrue(this.ExcelButton.IsVisible());
            Assert.IsTrue(this.PdfButton.IsVisible());
            Assert.IsTrue(this.SaveButton.IsVisible());

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage HeaderWithSingleVTsAndNoMultiOption(ReportsEntity reportData)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.Verify.Title(reportData.Title);
            this.Verify.OrganizationUnit(reportData.PoV.OrganizationUnit);
            this.Verify.VtSelection(reportData.Vt);
            Assert.IsFalse(this.SingleTimeView.IsVisible());
            this.Verify.Currency(reportData.Currency);

            Assert.IsFalse(this.CurrentlyManagedCifsButton.IsVisible());
            Assert.IsFalse(this.PreviouslyManagedCifsButton.IsVisible());
            Assert.IsFalse(this.FiltersButton.IsVisible());
            Assert.IsTrue(this.ReloadButton.IsVisible());
            Assert.IsTrue(this.ExcelButton.IsVisible());
            Assert.IsTrue(this.PdfButton.IsVisible());
            Assert.IsTrue(this.SaveButton.IsVisible());

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage HeaderWithSingleVTsAndAnyMultiOption(ReportsEntity reportData)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.Verify.Title(reportData.Title);
            this.Verify.OrganizationUnit(reportData.PoV.OrganizationUnit);
            this.Verify.VtSelection(reportData.Vt);
            Assert.IsFalse(this.SingleTimeView.IsVisible());
            Assert.IsTrue(this.CurrencyLabel.IsVisible());

            Assert.IsFalse(this.CurrentlyManagedCifsButton.IsVisible());
            Assert.IsFalse(this.PreviouslyManagedCifsButton.IsVisible());
            Assert.IsTrue(this.FiltersButton.IsVisible());
            Assert.IsTrue(this.ReloadButton.IsVisible());
            Assert.IsTrue(this.ExcelButton.IsVisible());
            Assert.IsTrue(this.PdfButton.IsVisible());
            Assert.IsTrue(this.SaveButton.IsVisible());

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage HeaderWithNoSingleVtsAndNoSingleTimeViewAndAnyMultiOption(ReportsEntity reportData)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.Verify.Title(reportData.Title);
            this.Verify.OrganizationUnit(reportData.PoV.OrganizationUnit);
            Assert.IsFalse(this.SingleVtButton.IsVisible());
            Assert.IsFalse(this.SingleTimeView.IsVisible());
            Assert.IsFalse(this.CurrencyLabel.IsVisible());

            Assert.IsFalse(this.CurrentlyManagedCifsButton.IsVisible());
            Assert.IsFalse(this.PreviouslyManagedCifsButton.IsVisible());
            Assert.IsTrue(this.FiltersButton.IsVisible());
            Assert.IsTrue(this.ReloadButton.IsVisible());
            Assert.IsTrue(this.ExcelButton.IsVisible());
            Assert.IsTrue(this.PdfButton.IsVisible());
            Assert.IsTrue(this.SaveButton.IsVisible());

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage HeaderManagedCiFs(ReportsEntity reportData)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.Verify.Title(reportData.Title);
            this.Verify.OrganizationUnit(reportData.PoV.OrganizationUnit);
            Assert.IsFalse(this.SingleVtButton.IsVisible());
            Assert.IsFalse(this.SingleTimeView.IsVisible());
            Assert.IsFalse(this.CurrencyLabel.IsVisible());

            Assert.IsTrue(this.CurrentlyManagedCifsButton.IsVisible());
            Assert.IsTrue(this.PreviouslyManagedCifsButton.IsVisible());
            Assert.IsTrue(this.FiltersButton.IsVisible());
            Assert.IsTrue(this.ReloadButton.IsVisible());
            Assert.IsTrue(this.ExcelButton.IsVisible());
            Assert.IsTrue(this.PdfButton.IsVisible());
            Assert.IsTrue(this.SaveButton.IsVisible());

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage HeaderNnaTrendReports(ReportsEntity reportData)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.Verify.Title(reportData.Title);
            this.Verify.OrganizationUnit(reportData.PoV.OrganizationUnit);
            Assert.IsFalse(this.SingleVtButton.IsVisible());
            Assert.IsTrue(this.SingleTimeView.IsVisible());
            Assert.IsTrue(this.CurrencyLabel.IsVisible());

            Assert.IsFalse(this.CurrentlyManagedCifsButton.IsVisible());
            Assert.IsFalse(this.PreviouslyManagedCifsButton.IsVisible());
            Assert.IsFalse(this.FiltersButton.IsVisible());
            Assert.IsTrue(this.ReloadButton.IsVisible());
            Assert.IsTrue(this.ExcelButton.IsVisible());
            Assert.IsTrue(this.PdfButton.IsVisible());
            Assert.IsTrue(this.SaveButton.IsVisible());

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage HeaderNnaTrendYtdOverview(ReportsEntity reportData)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.Verify.Title(reportData.Title);
            this.Verify.OrganizationUnit(reportData.PoV.OrganizationUnit);
            Assert.IsFalse(this.SingleVtButton.IsVisible());
            Assert.IsTrue(this.SingleTimeView.IsVisible());
            Assert.IsTrue(this.CurrencyLabel.IsVisible());

            Assert.IsFalse(this.CurrentlyManagedCifsButton.IsVisible());
            Assert.IsFalse(this.PreviouslyManagedCifsButton.IsVisible());
            Assert.IsFalse(this.FiltersButton.IsVisible());
            Assert.IsTrue(this.ReloadButton.IsVisible());
            Assert.IsTrue(this.ExcelButton.IsVisible());
            Assert.IsTrue(this.PdfButton.IsVisible());
            Assert.IsTrue(this.SaveButton.IsVisible());

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsPage HeaderProfitabilityTopEams(ReportsEntity reportData)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.Verify.Title(reportData.Title);
            this.Verify.OrganizationUnit(reportData.PoV.OrganizationUnit);
            Assert.IsFalse(this.SingleVtButton.IsVisible());
            Assert.IsTrue(this.SingleTimeView.IsVisible());
            Assert.IsFalse(this.CurrencyLabel.IsVisible());

            Assert.IsFalse(this.CurrentlyManagedCifsButton.IsVisible());
            Assert.IsFalse(this.PreviouslyManagedCifsButton.IsVisible());
            Assert.IsFalse(this.FiltersButton.IsVisible());
            Assert.IsTrue(this.ReloadButton.IsVisible());
            Assert.IsTrue(this.ExcelButton.IsVisible());
            Assert.IsTrue(this.PdfButton.IsVisible());
            Assert.IsTrue(this.SaveButton.IsVisible());

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportsPage();
        }

        public ReportsHeaderPage ClickThirteenMonths()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.ThirteenMonthsButton.Click();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public ReportsHeaderPage ClickCurrentlyManagedCifs()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.CurrentlyManagedCifsButton.Click();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public ReportsHeaderPage ClickPreviouslyManagedCifs()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.PreviouslyManagedCifsButton.Click();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public ReportsPage SaveReport(string newName)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, newName);

            var saveToMyReportsPage = new SaveToMyReportsPage();

            this.SaveButton.Click();
            saveToMyReportsPage.CheckReportNameContainsNoCidCheckBox();
            saveToMyReportsPage.ChangeReportNameTo(newName);
            saveToMyReportsPage.ClickSubmit();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, newName);

            return new ReportsPage();
        }

        public ReportsHeaderPage ChangeTimeViewTo(string timeView)
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name, timeView);

            this.SingleTimeView.Click();
            new Button(By.XPath($"//div[contains(text(),'{timeView}')]")).Click();
            Wait.ForRollerOnReportsToGoAway();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name, timeView);

            return this;
        }

        public string GetTimeView()
        {
            LoggerPage.LogReturn(MethodBase.GetCurrentMethod().Name);

            return this.SingleTimeView.GetValue();
        }

        public string ChangeVtAndGetNewValue()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            string selectedVt = this.SingleVtButton.GetText();

            this.SingleVtButton.Click();
            Button newVtLocator = new Button(By.XPath($"//div[contains(text(),'{selectedVt}')]//following-sibling::div"));
            string newVtName = newVtLocator.GetText();
            newVtLocator.Click();
            Wait.ForRollerOnReportsToGoAway();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return newVtName;
        }

        public void ClickReloadButton()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Wait.ForRollerOnReportsToGoAway();
            this.ReloadButton.ClickByJs();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);
        }

        public SaveToMyReportsPage ClickSaveIcon()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.SaveButton.Click();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new SaveToMyReportsPage();
        }

        public ReportsHeaderPage CollapseTimeView()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.SingleTimeView.Click();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public ReportsHeaderPage ExpandTimeView()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            this.SingleTimeView.Click();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return this;
        }

        public ReportSettingsPage ClickCustomizeTheReportButton()
        {
            LoggerPage.LogStart(MethodBase.GetCurrentMethod().Name);

            Wait.ForRollerOnReportsToGoAway();

            this.FiltersButton.Click();

            LoggerPage.LogEnd(MethodBase.GetCurrentMethod().Name);

            return new ReportSettingsPage();
        }
    }
}