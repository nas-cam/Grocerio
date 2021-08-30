
namespace GrocerioDesktop.Stores
{
    partial class frmStores
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
            this.dgvSearchStores = new System.Windows.Forms.DataGridView();
            this.txtSearchStores = new System.Windows.Forms.TextBox();
            this.BtnSearchStores = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblProducts = new System.Windows.Forms.Label();
            this.lstStoreProducts = new System.Windows.Forms.ListBox();
            this.lstStoreMembership = new System.Windows.Forms.ComboBox();
            this.txtStoreDescription = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtStoreCity = new System.Windows.Forms.TextBox();
            this.txtStoreUniqueNumber = new System.Windows.Forms.TextBox();
            this.txtStoreImageLink = new System.Windows.Forms.TextBox();
            this.txtStoreAddress = new System.Windows.Forms.TextBox();
            this.txtStoreName = new System.Windows.Forms.TextBox();
            this.btnClearFormData = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStoreId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstStoreMembershipSearch = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchStores)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSearchStores
            // 
            this.dgvSearchStores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearchStores.Location = new System.Drawing.Point(575, 312);
            this.dgvSearchStores.Name = "dgvSearchStores";
            this.dgvSearchStores.RowHeadersWidth = 51;
            this.dgvSearchStores.RowTemplate.Height = 29;
            this.dgvSearchStores.Size = new System.Drawing.Size(733, 664);
            this.dgvSearchStores.TabIndex = 0;
            // 
            // txtSearchStores
            // 
            this.txtSearchStores.Location = new System.Drawing.Point(21, 47);
            this.txtSearchStores.Multiline = true;
            this.txtSearchStores.Name = "txtSearchStores";
            this.txtSearchStores.Size = new System.Drawing.Size(635, 49);
            this.txtSearchStores.TabIndex = 1;
            // 
            // BtnSearchStores
            // 
            this.BtnSearchStores.Location = new System.Drawing.Point(513, 128);
            this.BtnSearchStores.Name = "BtnSearchStores";
            this.BtnSearchStores.Size = new System.Drawing.Size(143, 49);
            this.BtnSearchStores.TabIndex = 2;
            this.BtnSearchStores.Text = "Search";
            this.BtnSearchStores.UseVisualStyleBackColor = true;
            this.BtnSearchStores.Click += new System.EventHandler(this.BtnSearchStores_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblProducts);
            this.groupBox1.Controls.Add(this.lstStoreProducts);
            this.groupBox1.Controls.Add(this.lstStoreMembership);
            this.groupBox1.Controls.Add(this.txtStoreDescription);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtStoreCity);
            this.groupBox1.Controls.Add(this.txtStoreUniqueNumber);
            this.groupBox1.Controls.Add(this.txtStoreImageLink);
            this.groupBox1.Controls.Add(this.txtStoreAddress);
            this.groupBox1.Controls.Add(this.txtStoreName);
            this.groupBox1.Controls.Add(this.btnClearFormData);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblStoreId);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(496, 808);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Store details";
            // 
            // lblProducts
            // 
            this.lblProducts.AutoSize = true;
            this.lblProducts.Location = new System.Drawing.Point(12, 371);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(66, 20);
            this.lblProducts.TabIndex = 18;
            this.lblProducts.Text = "Products";
            // 
            // lstStoreProducts
            // 
            this.lstStoreProducts.FormattingEnabled = true;
            this.lstStoreProducts.ItemHeight = 20;
            this.lstStoreProducts.Location = new System.Drawing.Point(171, 371);
            this.lstStoreProducts.Name = "lstStoreProducts";
            this.lstStoreProducts.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstStoreProducts.Size = new System.Drawing.Size(302, 144);
            this.lstStoreProducts.TabIndex = 7;
            // 
            // lstStoreMembership
            // 
            this.lstStoreMembership.FormattingEnabled = true;
            this.lstStoreMembership.Location = new System.Drawing.Point(171, 229);
            this.lstStoreMembership.Name = "lstStoreMembership";
            this.lstStoreMembership.Size = new System.Drawing.Size(302, 28);
            this.lstStoreMembership.TabIndex = 4;
            // 
            // txtStoreDescription
            // 
            this.txtStoreDescription.Location = new System.Drawing.Point(171, 530);
            this.txtStoreDescription.Multiline = true;
            this.txtStoreDescription.Name = "txtStoreDescription";
            this.txtStoreDescription.Size = new System.Drawing.Size(306, 176);
            this.txtStoreDescription.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 530);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 20);
            this.label9.TabIndex = 16;
            this.label9.Text = "Description";
            // 
            // txtStoreCity
            // 
            this.txtStoreCity.Location = new System.Drawing.Point(171, 322);
            this.txtStoreCity.Name = "txtStoreCity";
            this.txtStoreCity.Size = new System.Drawing.Size(302, 27);
            this.txtStoreCity.TabIndex = 6;
            // 
            // txtStoreUniqueNumber
            // 
            this.txtStoreUniqueNumber.Location = new System.Drawing.Point(171, 277);
            this.txtStoreUniqueNumber.Name = "txtStoreUniqueNumber";
            this.txtStoreUniqueNumber.Size = new System.Drawing.Size(302, 27);
            this.txtStoreUniqueNumber.TabIndex = 5;
            // 
            // txtStoreImageLink
            // 
            this.txtStoreImageLink.Location = new System.Drawing.Point(171, 175);
            this.txtStoreImageLink.Name = "txtStoreImageLink";
            this.txtStoreImageLink.Size = new System.Drawing.Size(302, 27);
            this.txtStoreImageLink.TabIndex = 3;
            // 
            // txtStoreAddress
            // 
            this.txtStoreAddress.Location = new System.Drawing.Point(171, 123);
            this.txtStoreAddress.Name = "txtStoreAddress";
            this.txtStoreAddress.Size = new System.Drawing.Size(302, 27);
            this.txtStoreAddress.TabIndex = 2;
            // 
            // txtStoreName
            // 
            this.txtStoreName.Location = new System.Drawing.Point(171, 78);
            this.txtStoreName.Name = "txtStoreName";
            this.txtStoreName.Size = new System.Drawing.Size(302, 27);
            this.txtStoreName.TabIndex = 1;
            // 
            // btnClearFormData
            // 
            this.btnClearFormData.Location = new System.Drawing.Point(169, 732);
            this.btnClearFormData.Name = "btnClearFormData";
            this.btnClearFormData.Size = new System.Drawing.Size(150, 46);
            this.btnClearFormData.TabIndex = 9;
            this.btnClearFormData.Text = "Clear";
            this.btnClearFormData.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(327, 732);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 46);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 280);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "Unique store number";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Membership";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Image link";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 329);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "City";
            // 
            // lblStoreId
            // 
            this.lblStoreId.AutoSize = true;
            this.lblStoreId.Location = new System.Drawing.Point(171, 36);
            this.lblStoreId.Name = "lblStoreId";
            this.lblStoreId.Size = new System.Drawing.Size(0, 20);
            this.lblStoreId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lstStoreMembershipSearch);
            this.groupBox2.Controls.Add(this.txtSearchStores);
            this.groupBox2.Controls.Add(this.BtnSearchStores);
            this.groupBox2.Location = new System.Drawing.Point(575, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(733, 256);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Membership";
            // 
            // lstStoreMembershipSearch
            // 
            this.lstStoreMembershipSearch.FormattingEnabled = true;
            this.lstStoreMembershipSearch.Location = new System.Drawing.Point(21, 149);
            this.lstStoreMembershipSearch.Name = "lstStoreMembershipSearch";
            this.lstStoreMembershipSearch.Size = new System.Drawing.Size(456, 28);
            this.lstStoreMembershipSearch.TabIndex = 3;
            // 
            // frmStores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1320, 994);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvSearchStores);
            this.Name = "frmStores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmStores";
            this.Load += new System.EventHandler(this.FrmStores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchStores)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSearchStores;
        private System.Windows.Forms.TextBox txtSearchStores;
        private System.Windows.Forms.Button BtnSearchStores;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtStoreDescription;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtStoreCity;
        private System.Windows.Forms.TextBox txtStoreUniqueNumber;
        private System.Windows.Forms.TextBox txtStoreImageLink;
        private System.Windows.Forms.TextBox txtStoreAddress;
        private System.Windows.Forms.TextBox txtStoreName;
        private System.Windows.Forms.Button btnClearFormData;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblStoreId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox lstStoreMembership;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox lstStoreMembershipSearch;
        private System.Windows.Forms.Label lblProducts;
        private System.Windows.Forms.ListBox lstStoreProducts;
    }
}