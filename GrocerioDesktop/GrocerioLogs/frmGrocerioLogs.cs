using GrocerioModels.Enums.General;
using GrocerioModels.Enums.Purchase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace GrocerioDesktop.GrocerioLogs
{
    public partial class frmGrocerioLogs : Form
    {
        APIService _logService = new APIService("Logs");
        public frmGrocerioLogs()
        {
            InitializeComponent();
        }

        private async void frmGrocerioLogs_Load(object sender, EventArgs e)
        {
            dgvGrocerioLogs.AutoGenerateColumns = true;
            var dataSet = await _logService.GetPurchaseLogs<List<GrocerioApi.Database.Entities.PurchaseLog>>(PurchaseState.All, 10, Sort.DESC);
            dgvGrocerioLogs.DataSource = dataSet;
        }
    }
}
