using GrocerioModels.Analytics.Category;
using GrocerioModels.Analytics.Product;
using GrocerioModels.Analytics.ProductType;
using GrocerioModels.Analytics.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace GrocerioDesktop.Dashboard
{
    public partial class frmDashboard : Form
    {
        APIService _dashboardService =new APIService("Analytics");
        public frmDashboard()
        {
            InitializeComponent();
        }

        private async void frmDashboard_Load(object sender, EventArgs e)
        {
           
            var storeData = await _dashboardService.GetStoreAnalytics<StoreAnalytics>(10);
            dgvStoreAnalytics.DataSource = storeData.Stores.ToArray();
            

            var productData = await _dashboardService.GetProductAnalytics<ProductAnalytics>(10);
            dgvProductAnalytics.DataSource = productData.Products.ToArray();

            var categoryData = await _dashboardService.GetCategoryAnalytics<CategoryAnalytics>(10);
            dgvCategoryAnalytics.DataSource = categoryData.Categories.ToArray();

            var productTypeData = await _dashboardService.GetProductTypeAnalytics<ProductTypeAnalytics>(10);
            dgvProductTypeAnalytics.DataSource = productTypeData.Types.ToArray();

        }
    }
}
