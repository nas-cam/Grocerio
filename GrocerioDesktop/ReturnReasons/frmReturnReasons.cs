using GrocerioModels.Enums.General;
using GrocerioModels.Requests.ReturnReason;
using GrocerioModels.Response;
using GrocerioModels.ReturnReason;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GrocerioDesktop.ReturnReasons
{
    public partial class frmReturnReasons : Form
    {
        APIService _returnReasonsService = new APIService("ReturnReasons");
        

        public frmReturnReasons()
        {
            InitializeComponent();
        }

        private async void frmReturnReasons_Load(object sender, EventArgs e)
        {
            var result = await _returnReasonsService.Get<List<ReturnReasonModel>>(null);
            dgvReturnReasons.DataSource = result;

            lstboxSeriousness.DataSource = Enum.GetValues(typeof(Priority));
           
            
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblId.Text))
            {
                var reason = new InsertReturnReasonRequest()
                {
                    Reason = txtReason.Text,
                    Seriousness = (Priority)lstboxSeriousness.SelectedIndex
                };
                await _returnReasonsService.Insert<InsertReturnReasonRequest>(reason);
            }
            else
            {
                var reason = new ReturnReasonModel()
                {   
                    Id=Int32.Parse(lblId.Text),
                    Reason = txtReason.Text,
                    Seriousness = (Priority)lstboxSeriousness.SelectedIndex,
                   
                };
                await _returnReasonsService.UpdateT<InsertReturnReasonRequest>(Int32.Parse(lblId.Text), reason, "UpdateReturnReason");
            }

            this.Controls.Clear();
            InitializeComponent();
            frmReturnReasons_Load(e, e);
        }

        private async void dgvReturnReasons_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = dgvReturnReasons.Rows[e.RowIndex].Cells[0].Value;

            var reason = await _returnReasonsService.GetById<ReturnReasonModel>(id);

            lblId.Text = id.ToString();
            txtReason.Text = reason.Reason;
            lstboxSeriousness.SelectedItem = reason.Seriousness;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("POruka?", "Title?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var id = Int32.Parse(lblId.Text);
                var returnString = _returnReasonsService.Delete<StringResponse>(id, "RemoveReturnReason").ToString();

                this.Controls.Clear();
                InitializeComponent();
                frmReturnReasons_Load(e, e);
            }
        }
    }
}
