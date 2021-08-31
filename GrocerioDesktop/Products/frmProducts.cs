using GrocerioModels.Product;
using GrocerioModels.Requests.Product;
using GrocerioModels.Response.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GrocerioDesktop.Products
{
    public partial class frmProducts : Form
    {
        APIService _productService = new APIService("Products");
        APIService _categoriesService = new APIService("Categories");
        public frmProducts()
        {
            InitializeComponent();
        }
        private void frmProducts_Load(object sender, EventArgs e)
        {
            BindDataGrid(null);
            BindListData();
        }

        private async void btnSaveProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateProductForm())
                {
                    if (string.IsNullOrEmpty(lblIdValue.Text))
                    {
                        var body = new InsertProductRequest()
                        {
                            CategoryId = lstCategories.SelectedIndex,
                            Description = txtProductDesc.Text,
                            ImageLink = txtImgLink.Text,
                            Name = txtProductName.Text,
                            ProductType = (GrocerioModels.Enums.Product.Type)lstProductType.SelectedIndex
                        };

                        await _productService.Insert<InsertProductResponse>(body);
                    }
                    else
                    {
                        var body = new EditProductRequest()
                        {
                            ProductId = Int32.Parse(lblIdValue.Text),
                            Name = txtProductName.Text,
                            Description = txtProductDesc.Text,
                            ImageLink = txtImgLink.Text,
                            CategoryId = (int)lstCategories.SelectedValue,
                            ProductType = (GrocerioModels.Enums.Product.Type)lstProductType.SelectedValue
                        };

                        await _productService.Update<InsertProductResponse>(Int32.Parse(lblIdValue.Text), body, "EditProduct");
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
        private async void dgvProducts_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = dgvProducts.Rows[e.RowIndex].Cells[0].Value;

            var product = await _productService.GetById<Product>(id);

            lblIdValue.Text = id.ToString();
            txtProductName.Text = product.Name;
            txtProductDesc.Text = product.Description;
            txtImgLink.Text = product.ImageLink;
            lstCategories.SelectedValue = product.CategoryId;
            lstProductType.SelectedValue = (GrocerioModels.Enums.Product.Type) product.ProductType;
        }


        private async void BindDataGrid(object search)
        {
            var result = await _productService.Get<List<GrocerioModels.Product.Product>>(search);
            dgvProducts.DataSource = result;
        }

        private async void BindListData()
        {
            List<GrocerioModels.Category.Category> categories = await _categoriesService.Get<List<GrocerioModels.Category.Category>>(null);

            categories.Add(new GrocerioModels.Category.Category
            {
                Id = -1,
                Name = "-- Select Category --"
            });
           
            lstCategories.DataSource = categories;
            lstCategories.ValueMember = "Id";
            lstCategories.DisplayMember = "Name";

            List<GrocerioModels.Category.Category> categoriesForSearch = await _categoriesService.Get<List<GrocerioModels.Category.Category>>(null);

            categoriesForSearch.Add(new GrocerioModels.Category.Category
            {
                Id = -1,
                Name = "-- Select Category --"
            });


            lstCategorySearch.DataSource = categoriesForSearch;
            lstCategorySearch.ValueMember = "Id";
            lstCategorySearch.DisplayMember = "Name";


            var productTypes = await _productService.Get<List<ProructTypeItem>>(null, "GetProductTypes");

            productTypes.Add(new ProructTypeItem
            {
                TypeName = "-- Select Product Type --"
            });


            lstProductType.DataSource = productTypes;
            lstProductType.ValueMember = "Type";
            lstProductType.DisplayMember = "TypeName";


            var productTypesForSearch = await _productService.Get<List<ProructTypeItem>>(null, "GetProductTypes");

            productTypesForSearch.Add(new ProructTypeItem
            {
                TypeName = "-- Select Product Type --"
            });


            lstProductTypeSearch.DataSource = productTypesForSearch;
            lstProductTypeSearch.ValueMember = "Type";
            lstProductTypeSearch.DisplayMember = "TypeName";
        }

        private void ClearData()
        {
            lblIdValue.Text = "";
            txtProductName.Text = "";
            txtProductDesc.Text = "";
            txtImgLink.Text = "";
            lstCategories.SelectedIndex = 0;
            lstProductType.SelectedIndex = 0;
        }

        private void btnSearchProducts_Click(object sender, EventArgs e)
        {
            var body = "";

            if (!String.IsNullOrEmpty(txtSearchProducts.Text))
                body = "searchTerm=" + txtSearchProducts.Text;

            if (lstCategorySearch.SelectedIndex > 0)
            {
                if (!String.IsNullOrEmpty(body))
                    body += "&";

                body += "categoryId=" + lstCategorySearch.SelectedValue;
            }

            if (lstProductTypeSearch.SelectedIndex > 0)
            {
                if (!String.IsNullOrEmpty(body))
                    body += "&";

                body += "productType=" + lstProductTypeSearch.SelectedValue;
            }


            BindDataGrid(body);
        }

        private void btnClearSearchBox_Click(object sender, EventArgs e)
        {
            txtSearchProducts.Text = "";
            lstProductTypeSearch.SelectedIndex = 0;
            lstCategorySearch.SelectedIndex = 0;
        }

        private void btnClearProductDetails_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        public bool ValidateProductForm()
        {
            if (String.IsNullOrWhiteSpace(txtProductName.Text) || txtProductName.Text.Length < 3 && txtProductName.Text.Length > 15)
            {
                MessageBox.Show("Product name field requires 3-15 characters.");
                return false;
            }

            if (String.IsNullOrWhiteSpace(txtImgLink.Text))
            {
                MessageBox.Show("Product image link field is required.");
                return false; ;
            }
            if (lstCategories.SelectedIndex == 0)
            {
                MessageBox.Show("Category field is required");
                return false; ;
            }
            if (String.IsNullOrWhiteSpace(txtProductDesc.Text) || (txtProductDesc.Text.Length < 5 && txtProductDesc.Text.Length > 30))
            {
                MessageBox.Show("Store description field is required");
                return false; ;
            }
            if (lstProductType.SelectedIndex == 0)
            {
                MessageBox.Show("Product type field is required");
                return false; ;
            }

            return true;
        }
    }
}
