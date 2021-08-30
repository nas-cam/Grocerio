using GrocerioModels.Requests.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GrocerioDesktop.Users
{
    public partial class frmUsers : Form
    {
        APIService _userService = new APIService("Users");
        bool usersLocked = false;
        bool selectedUserActive = false;
        public frmUsers()
        {
            InitializeComponent();
        }

        private async void frmUsers_Load(object sender, EventArgs e)
        {
            var users = await _userService.Get<List<GrocerioModels.Users.User>>(null);
            dgvUsers.DataSource = users;
            if (users.Count > 0)
            {
                usersLocked = users[0].Locked;
                btnLockUsers.Text = usersLocked ? "Unlock all users" : "Lock all users";
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string query = "";

            if (!String.IsNullOrEmpty(txtFirstName.Text))
                query += "FirstName=" + txtFirstName.Text + "&";

            if (!String.IsNullOrEmpty(txtLastName.Text))
                query += "LastName=" + txtLastName.Text + "&";

            if (!String.IsNullOrEmpty(txtUsername.Text))
                query += "Username=" + txtUsername.Text;

            var filter = await _userService.Get<List<GrocerioModels.Users.User>>(query);
            dgvUsers.DataSource = filter;
        }

        private async void dgvUsers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = dgvUsers.Rows[e.RowIndex].Cells[0].Value;
            var user = await _userService.GetUserById<GrocerioModels.Users.User>(id);
            lblId.Text = id.ToString();
            selectedUserActive = user.Active;
        }

        private  void btnLockUsers_Click(object sender, EventArgs e)
        {
           var Locked=  _userService.HandleLock(!usersLocked).ToString();
            this.Controls.Clear();
            InitializeComponent();
            frmUsers_Load(e, e);
        }

        private void btnChangeActivity_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblId.Text))
            {
               var response = _userService.ChangeUserActivity(Int32.Parse(lblId.Text), !selectedUserActive);
            }
            this.Controls.Clear();
            InitializeComponent();
            frmUsers_Load(e, e);
        }
    }
}
