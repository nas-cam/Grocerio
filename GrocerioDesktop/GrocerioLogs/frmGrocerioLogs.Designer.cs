
namespace GrocerioDesktop.GrocerioLogs
{
    partial class frmGrocerioLogs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvGrocerioLogs = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrocerioLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGrocerioLogs
            // 
            this.dgvGrocerioLogs.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvGrocerioLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrocerioLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrocerioLogs.Location = new System.Drawing.Point(0, 0);
            this.dgvGrocerioLogs.Name = "dgvGrocerioLogs";
            this.dgvGrocerioLogs.RowHeadersWidth = 51;
            this.dgvGrocerioLogs.RowTemplate.Height = 29;
            this.dgvGrocerioLogs.Size = new System.Drawing.Size(1371, 922);
            this.dgvGrocerioLogs.TabIndex = 0;
            // 
            // frmGrocerioLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 922);
            this.Controls.Add(this.dgvGrocerioLogs);
            this.Name = "frmGrocerioLogs";
            this.Text = "frmGrocerioLogs";
            this.Load += new System.EventHandler(this.frmGrocerioLogs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrocerioLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGrocerioLogs;
    }
}