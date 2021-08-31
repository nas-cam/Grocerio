using GrocerioModels.Filters.Store;
using GrocerioModels.Report;
using GrocerioModels.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GrocerioDesktop.Reports
{
    public partial class frmReports : Form
    {
        APIService _reportService = new APIService("Reports");
        APIService _storeService = new APIService("Stores");
        private PremiumReportModel premium;
        private BasicReportModel basic;
        public frmReports()
        {
            InitializeComponent();
        }

        private async void frmReports_Load(object sender, EventArgs e)
        {
            var body = new StoreFilters()
            {
                AccountId = APIService.LoginData.AccountId,
                CetgoryIds = new List<int>(),
                Membership = 0,
                SearchTerm = txtSearchStoresReport.Text,
                Types = new List<GrocerioModels.Enums.Product.Type>()
            };

            var result = await _storeService.SepcifiedPost<List<GrocerioModels.Store.Model.StoreModel>>(body, "ReceiveStores");
            dgvStoreReport.DataSource = result;
        }
        private async void BtnSearchStores_Click(object sender, EventArgs e)
        {
            var body = new StoreFilters()
            {
                AccountId = APIService.LoginData.AccountId,
                CetgoryIds = new List<int>(),
                Membership = 0,
                SearchTerm = txtSearchStoresReport.Text,
                Types = new List<GrocerioModels.Enums.Product.Type>()
            };

            var result = await _storeService.SepcifiedPost<List<GrocerioModels.Store.Model.StoreModel>>(body, "ReceiveStores");
            dgvStoreReport.DataSource = result;
        }

        private async void dgvStoreReport_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = dgvStoreReport.Rows[e.RowIndex].Cells[0].Value;

            var store = await _storeService.GetStoreById<Store>(id);
            lblRepStoreMembership.Text = store.Membership.ToString();
            lblRepStoreId.Text = id.ToString();
        }

        private async void btnCreateStoreReport_Click(object sender, EventArgs e)
        {
            var isBasic = String.Equals(lblRepStoreMembership.Text, "Basic");
            var isStoreSelected = !String.IsNullOrWhiteSpace(lblRepStoreId.Text);

            if (String.IsNullOrEmpty(txtReportName.Text))
            {
                MessageBox.Show("Enter a report name");
                return;
            }

            if (isStoreSelected)
            {

                var report = new ReportParameters
                {
                    StoreId = Int32.Parse(lblRepStoreId.Text),
                    From = dtpFrom.Value,
                    To = dtpTo.Value,
                    Name = txtReportName.Text
                };

                if (isBasic)
                {
                    var retVal = await _reportService.CreateReport<BasicReportModel>(report, isBasic);


                    lblStoreName.Text = retVal.StoreName;
                    lblTopProduct.Text = retVal.TopProduct;
                    lblRevenue.Text = retVal.Revenue.ToString();
                    lblProductsSold.Text = retVal.ProductsSold.ToString();
                    lblProductsReturned.Text = retVal.ProductsReturned.ToString();
                    lblCurrentCartEntries.Text = retVal.CurrentCartEntries.ToString();
                    lblCurrentTrackingEntries.Text = retVal.CurrentTrackingEntries.ToString();
                    basic = retVal;
                }

                else
                {
                    var retVal = await _reportService.CreateReport<PremiumReportModel>(report, isBasic);
                    lblStoreName.Text = retVal.StoreName;
                    lblTopProduct.Text = retVal.TopProduct;
                    lblRevenue.Text = retVal.Revenue.ToString();
                    lblProductsSold.Text = retVal.ProductsSold.ToString();
                    lblProductsReturned.Text = retVal.ProductsReturned.ToString();
                    lblCurrentCartEntries.Text = retVal.CurrentCartEntries.ToString();
                    lblCurrentTrackingEntries.Text = retVal.CurrentTrackingEntries.ToString();
                    lblMostPopularCategory.Text = retVal.MostPopularCategory.ToString();
                    lblProductType.Text = retVal.MostPopularProductType.ToString();
                    lblPopularAddress.Text = retVal.MostPopularClientAddress.ToString();
                    lblReturnReason.Text = retVal.MainReturnReason.ToString();
                    lblSuccessRate.Text = retVal.SuccessRate.ToString();
                    premium = retVal;
                }

                ReloadDataGrids();
            }
            else
            {
                MessageBox.Show("Please select the store from the list");
            }

        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            var isBasic = String.Equals(lblRepStoreMembership.Text, "Basic");

            if (isBasic)
                await _reportService.SaveBasicReport<BasicReportModel>(basic);

            else
                await _reportService.SavePremiumReport<PremiumReportModel>(premium);


            ReloadDataGrids();
        }
        private async void ReloadDataGrids()
        {
            var basicData = await _reportService.GetAllBasicReports<List<ReportRecord>>(Int32.Parse(lblRepStoreId.Text));
            dgvBasicReports.DataSource = basicData;

            var premiumData = await _reportService.GetAllPremiumReports<List<ReportRecord>>(Int32.Parse(lblRepStoreId.Text));
            dgvPremiumReports.DataSource = premiumData;
        }
    }
}


