using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GrocerioDesktop.Menu;
using GrocerioModels.Filters.Store;
using GrocerioModels.Login;


namespace GrocerioDesktop.Login
{
    public partial class frmLogin : Form
    {
        APIService _service = new APIService("Login");
        public frmLogin()
        {
            InitializeComponent();
        }        

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            APIService.Username = txtUsername.Text;
            APIService.Password = txtPassword.Text;
            try
            {
                await _service.GetLoginData<LoginResponse>();
        
                this.Hide();
                var form = new frmMenu();
                form.Show();
            }
            catch (Exception ex)
            {
   
            }
        }
    }
}

