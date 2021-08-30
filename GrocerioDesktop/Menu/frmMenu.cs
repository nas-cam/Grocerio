using GrocerioDesktop.Categories;
using GrocerioDesktop.Products;
using GrocerioDesktop.Reports;
using GrocerioDesktop.ReturnReasons;
using GrocerioDesktop.Stores;
using GrocerioDesktop.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GrocerioDesktop.Menu
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
        }
      
        private void StoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            frmStores form = new frmStores
            {
                MdiParent = this
            };

            form.Show();
        }
        private void CategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            FrmCategories form = new FrmCategories
            {
                MdiParent = this
            };
            form.Show();
        }

        private void ProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            frmProducts form = new frmProducts
            {
                MdiParent = this
            };
            form.Show();
        }

        private void ReturnReasonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            frmReturnReasons form = new frmReturnReasons
            {
                MdiParent = this
            };
            form.Show();
        }

        private void UsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            frmUsers form = new frmUsers
            {
                MdiParent = this
            };
            form.Show();

        }

        private void ReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            frmReports form = new frmReports
            {
                MdiParent = this
            };
            form.Show();

        }
    }
}
