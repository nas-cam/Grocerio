
namespace GrocerioDesktop.Dashboard
{
    partial class frmDashboard
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
            this.dgvStoreAnalytics = new System.Windows.Forms.DataGridView();
            this.StoreAnalytics = new System.Windows.Forms.GroupBox();
            this.dgvProductAnalytics = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvCategoryAnalytics = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvProductTypeAnalytics = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStoreAnalytics)).BeginInit();
            this.StoreAnalytics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductAnalytics)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoryAnalytics)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductTypeAnalytics)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvStoreAnalytics
            // 
            this.dgvStoreAnalytics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStoreAnalytics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStoreAnalytics.Location = new System.Drawing.Point(3, 23);
            this.dgvStoreAnalytics.Name = "dgvStoreAnalytics";
            this.dgvStoreAnalytics.RowHeadersWidth = 51;
            this.dgvStoreAnalytics.RowTemplate.Height = 29;
            this.dgvStoreAnalytics.Size = new System.Drawing.Size(828, 369);
            this.dgvStoreAnalytics.TabIndex = 1;
            // 
            // StoreAnalytics
            // 
            this.StoreAnalytics.Controls.Add(this.dgvStoreAnalytics);
            this.StoreAnalytics.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StoreAnalytics.Location = new System.Drawing.Point(12, 81);
            this.StoreAnalytics.Name = "StoreAnalytics";
            this.StoreAnalytics.Size = new System.Drawing.Size(834, 395);
            this.StoreAnalytics.TabIndex = 4;
            this.StoreAnalytics.TabStop = false;
            this.StoreAnalytics.Text = "Store Analytics";
            // 
            // dgvProductAnalytics
            // 
            this.dgvProductAnalytics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductAnalytics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductAnalytics.Location = new System.Drawing.Point(3, 23);
            this.dgvProductAnalytics.Name = "dgvProductAnalytics";
            this.dgvProductAnalytics.RowHeadersWidth = 51;
            this.dgvProductAnalytics.RowTemplate.Height = 29;
            this.dgvProductAnalytics.Size = new System.Drawing.Size(845, 369);
            this.dgvProductAnalytics.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvProductAnalytics);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(872, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(851, 395);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Product Analytics";
            // 
            // dgvCategoryAnalytics
            // 
            this.dgvCategoryAnalytics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategoryAnalytics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCategoryAnalytics.Location = new System.Drawing.Point(3, 23);
            this.dgvCategoryAnalytics.Name = "dgvCategoryAnalytics";
            this.dgvCategoryAnalytics.RowHeadersWidth = 51;
            this.dgvCategoryAnalytics.RowTemplate.Height = 29;
            this.dgvCategoryAnalytics.Size = new System.Drawing.Size(822, 407);
            this.dgvCategoryAnalytics.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvCategoryAnalytics);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(15, 498);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(828, 433);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Category Analytics";
            // 
            // dgvProductTypeAnalytics
            // 
            this.dgvProductTypeAnalytics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductTypeAnalytics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductTypeAnalytics.Location = new System.Drawing.Point(3, 23);
            this.dgvProductTypeAnalytics.Name = "dgvProductTypeAnalytics";
            this.dgvProductTypeAnalytics.RowHeadersWidth = 51;
            this.dgvProductTypeAnalytics.RowTemplate.Height = 29;
            this.dgvProductTypeAnalytics.Size = new System.Drawing.Size(845, 407);
            this.dgvProductTypeAnalytics.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvProductTypeAnalytics);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox4.Location = new System.Drawing.Point(872, 495);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(851, 433);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Product Type Analytics";
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1727, 955);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.StoreAnalytics);
            this.Name = "frmDashboard";
            this.Text = "frmDashboard";
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStoreAnalytics)).EndInit();
            this.StoreAnalytics.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductAnalytics)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoryAnalytics)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductTypeAnalytics)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvStoreAnalytics;
        private System.Windows.Forms.GroupBox StoreAnalytics;
        private System.Windows.Forms.DataGridView dgvProductAnalytics;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvCategoryAnalytics;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvProductTypeAnalytics;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}