using GrocerioModels.Requests.Category;
using GrocerioModels.Response.Category;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrocerioDesktop.Categories
{
    public partial class FrmCategories : Form
    {
        private readonly APIService _categoriesService = new APIService("categories");
       
        public FrmCategories()
        {
            InitializeComponent();
        }

        private void FrmCategories_Load(object sender, EventArgs e)
        {
            BindDataGrid(null);
        }

        private async void BtnSaveCategory_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(lblId.Text))
            {
                var body = new InsertCategoryRequest()
                {
                    Name = txtNameCat.Text,
                    Description = txtDescCat.Text,
                    ImageLink = txtImgLink.Text
                };
                await _categoriesService.Insert<InsertCategoryResponse>(body);
            }
            else
            {
                var body = new EditCategoryRequest()
                {
                    CategoryId= Int32.Parse(lblId.Text),
                    Name = txtNameCat.Text,
                    Description = txtDescCat.Text,
                    ImageLink = txtImgLink.Text
                };
                await _categoriesService.Update<InsertCategoryResponse>(Int32.Parse(lblId.Text),body,"EditCategory");
            }

            ClearFields();
            BindDataGrid(null);
        }

        private async void dgvCategories_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = dgvCategories.Rows[e.RowIndex].Cells[0].Value;
            var category = await _categoriesService.GetById<GrocerioModels.Category.Category>(id);

            lblId.Text = id.ToString();
            txtNameCat.Text = category.Name;
            txtDescCat.Text = category.Description;
            txtImgLink.Text = category.ImageLink;
        }


        private async void BindDataGrid(object search)
        {
            var result = await _categoriesService.Get<List<GrocerioModels.Category.Category>>(search);
            dgvCategories.DataSource = result;
        }

        private void ClearFields()
        {
            lblId.Text = "";
            txtNameCat.Text = "";
            txtDescCat.Text = "";
            txtImgLink.Text = "";
        }

        private void btnSearchCategories_Click(object sender, EventArgs e)
        {
            var body = "";

            if (!String.IsNullOrEmpty(txtSearchCategories.Text))
                body = "searchTerm=" + txtSearchCategories.Text;

            BindDataGrid(body);
        }

        private void btnClearCategoryDetails_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnClearSearchBox_Click(object sender, EventArgs e)
        {
            txtSearchCategories.Text = "";
            BindDataGrid(null);
        }
    }
}
