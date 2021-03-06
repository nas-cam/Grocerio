using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GrocerioModels;
using GrocerioModels.Enums.Store;
using GrocerioModels.Filters.Store;
using GrocerioModels.Requests.Store;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace GrocerioDesktop.Stores
{
    public partial class frmStores : Form
    {
        readonly APIService _storeService = new APIService("Stores");
        readonly APIService _productService = new APIService("Products");
        public frmStores()
        {
            InitializeComponent();
        }

        private void FrmStores_Load(object sender, EventArgs e)
        {
            BindDataGrid(null);
            BindLists();
        }

        private void BtnSearchStores_Click(object sender, EventArgs e)
        {
            BindDataGrid(null);
        }

        private async void BindDataGrid(object search)
        {
            var body = new StoreFilters()
            {
                AccountId = APIService.LoginData.AccountId,
                CetgoryIds = new List<int>(),
                Membership = 0,
                SearchTerm = txtSearchStores.Text,
                Types = new List<GrocerioModels.Enums.Product.Type>()
            };

            var result = await _storeService.SepcifiedPost<List<GrocerioModels.Store.Model.StoreModel>>(body, "ReceiveStores");
            dgvSearchStores.DataSource = result;
        }

        private async void BindLists()
        {
            var storeMembership = Enum.GetValues(typeof(GrocerioModels.Enums.Store.Membership));
            foreach (var item in storeMembership)
            {
                lstStoreMembership.Items.Add(item);
            }

            lstStoreMembership.DataSource = Enum.GetValues(typeof(GrocerioModels.Enums.Store.Membership));

            var products = await _productService.Get<List<GrocerioModels.Product.Product>>(null);
            lstStoreProducts.DataSource = products;

            lstStoreProducts.DisplayMember = "Name";
            lstStoreProducts.ValueMember = "Id";
        }
        private void ClearData()
        {
            txtStoreName.Text = "";
            txtStoreAddress.Text = "";
            txtStoreCity.Text = "";
            txtStoreDescription.Text = "";
            txtStoreImageLink.Text = "";
            txtStoreUniqueNumber.Text = "";
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateStoreForm())
                {

                    List<GrocerioModels.Store.NewStoreProductItem> productList = new List<GrocerioModels.Store.NewStoreProductItem>();

                    if (lstStoreProducts.SelectedItems.Count > 0)
                    {
                        foreach (GrocerioModels.Product.Product item in lstStoreProducts.SelectedItems)
                        {
                            productList.Add(new GrocerioModels.Store.NewStoreProductItem
                            {
                                ProductId = item.Id,
                                Price = new Random().Next(1, 10)
                            });
                        }
                    }

                    if (string.IsNullOrEmpty(lblStoreId.Text))
                    {
                        var body = new InsertStoreRequest()
                        {
                            Address = txtStoreAddress.Text,
                            City = txtStoreCity.Text,
                            Membership = (GrocerioModels.Enums.Store.Membership)lstStoreMembership.SelectedValue,
                            UniqueStoreNumber = Int32.Parse(txtStoreUniqueNumber.Text),
                            Name = txtStoreName.Text,
                            Description = txtStoreDescription.Text,
                            ImageLink = txtStoreImageLink.Text,
                            ProductItems = productList

                        };
                        if (body == null)
                        {
                            Load += FrmStores_Load;
                        }
                        else
                            await _storeService.Insert<InsertStoreRequest>(body);
                    }

                    BindDataGrid(null);
                    ClearData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Unhandled error", MessageBoxButtons.OK);
            }
        }

        public bool ValidateStoreForm()
        {
            if (String.IsNullOrWhiteSpace(txtStoreName.Text))
            {
                MessageBox.Show("Store name is required");
                return false;
            }

            if (txtStoreName.Text.Length < 3 || txtStoreName.Text.Length > 15)
            {
                MessageBox.Show("Store name requires 3-15 characters");
                return false;
            }
            if (String.IsNullOrWhiteSpace(txtStoreAddress.Text))
            {
                MessageBox.Show("Store address is required ");
                return false; ;
            }

            if (txtStoreAddress.Text.Length < 5 || txtStoreAddress.Text.Length > 30)
            {
                MessageBox.Show("Store address requires 5-30 characters");
                return false; ;
            }
            if (String.IsNullOrWhiteSpace(txtStoreImageLink.Text))
            {
                MessageBox.Show("Store image link field is required!");
                return false; ;
            }

            if (lstStoreMembership.SelectedValue == null)
            {
                MessageBox.Show("Membership field is required");
                return false; ;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(txtStoreUniqueNumber.Text, "[^0-9]") || String.IsNullOrEmpty(txtStoreUniqueNumber.Text))
            {
                MessageBox.Show("Store unique field is only for numbers.");
                return false; ;
            }
            if (txtStoreDescription.Text.Length < 5 || txtStoreDescription.Text.Length > 30)
            {
                MessageBox.Show("Store description field is required");
                return false; ;
            }

            if (String.IsNullOrWhiteSpace(txtStoreDescription.Text))
            {
                MessageBox.Show("Store description field is required");
                return false; ;
            }

            if (String.IsNullOrWhiteSpace(txtStoreCity.Text))
            {
                MessageBox.Show("Store city field is required");
                return false; ;
            }

            if (lstStoreProducts.SelectedItems.Count < 1)
            {
                MessageBox.Show("At least one product has to be selected");
                return false; ;
            }

            return true;
        }
    }
}
