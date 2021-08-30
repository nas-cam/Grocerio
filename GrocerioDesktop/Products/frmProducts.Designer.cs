
namespace GrocerioDesktop.Products
{
    partial class frmProducts
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
            System.Windows.Forms.Label lblProductId;
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClearProductDetails = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstProductType = new System.Windows.Forms.ComboBox();
            this.lstCategories = new System.Windows.Forms.ComboBox();
            this.btnSaveProduct = new System.Windows.Forms.Button();
            this.lblIdValue = new System.Windows.Forms.Label();
            this.txtProductDesc = new System.Windows.Forms.TextBox();
            this.txtImgLink = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lstProductTypeSearch = new System.Windows.Forms.ComboBox();
            this.lstCategorySearch = new System.Windows.Forms.ComboBox();
            this.btnClearSearchBox = new System.Windows.Forms.Button();
            this.txtSearchProducts = new System.Windows.Forms.TextBox();
            this.btnSearchProducts = new System.Windows.Forms.Button();
            lblProductId = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProductId
            // 
            lblProductId.AutoSize = true;
            lblProductId.Location = new System.Drawing.Point(41, 34);
            lblProductId.Name = "lblProductId";
            lblProductId.Size = new System.Drawing.Size(25, 23);
            lblProductId.TabIndex = 0;
            lblProductId.Text = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Image Link";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Description";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(391, 445);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Product Type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(58, 445);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Category";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClearProductDetails);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lstProductType);
            this.groupBox1.Controls.Add(this.lstCategories);
            this.groupBox1.Controls.Add(this.btnSaveProduct);
            this.groupBox1.Controls.Add(this.lblIdValue);
            this.groupBox1.Controls.Add(this.txtProductDesc);
            this.groupBox1.Controls.Add(this.txtImgLink);
            this.groupBox1.Controls.Add(this.txtProductName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(lblProductId);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(12, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(496, 531);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product details";
            // 
            // btnClearProductDetails
            // 
            this.btnClearProductDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClearProductDetails.Location = new System.Drawing.Point(167, 459);
            this.btnClearProductDetails.Name = "btnClearProductDetails";
            this.btnClearProductDetails.Size = new System.Drawing.Size(143, 49);
            this.btnClearProductDetails.TabIndex = 18;
            this.btnClearProductDetails.Text = "Clear";
            this.btnClearProductDetails.UseVisualStyleBackColor = true;
            this.btnClearProductDetails.Click += new System.EventHandler(this.btnClearProductDetails_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 219);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 23);
            this.label7.TabIndex = 16;
            this.label7.Text = "Product Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 23);
            this.label1.TabIndex = 15;
            this.label1.Text = "Category";
            // 
            // lstProductType
            // 
            this.lstProductType.FormattingEnabled = true;
            this.lstProductType.Location = new System.Drawing.Point(167, 216);
            this.lstProductType.Name = "lstProductType";
            this.lstProductType.Size = new System.Drawing.Size(302, 31);
            this.lstProductType.Sorted = true;
            this.lstProductType.TabIndex = 4;
            // 
            // lstCategories
            // 
            this.lstCategories.FormattingEnabled = true;
            this.lstCategories.Location = new System.Drawing.Point(167, 168);
            this.lstCategories.Name = "lstCategories";
            this.lstCategories.Size = new System.Drawing.Size(302, 31);
            this.lstCategories.Sorted = true;
            this.lstCategories.TabIndex = 3;
            // 
            // btnSaveProduct
            // 
            this.btnSaveProduct.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSaveProduct.Location = new System.Drawing.Point(319, 459);
            this.btnSaveProduct.Name = "btnSaveProduct";
            this.btnSaveProduct.Size = new System.Drawing.Size(150, 46);
            this.btnSaveProduct.TabIndex = 7;
            this.btnSaveProduct.Text = "Save";
            this.btnSaveProduct.UseVisualStyleBackColor = true;
            this.btnSaveProduct.Click += new System.EventHandler(this.btnSaveProduct_Click);
            // 
            // lblIdValue
            // 
            this.lblIdValue.AutoSize = true;
            this.lblIdValue.Location = new System.Drawing.Point(167, 34);
            this.lblIdValue.Name = "lblIdValue";
            this.lblIdValue.Size = new System.Drawing.Size(0, 23);
            this.lblIdValue.TabIndex = 14;
            // 
            // txtProductDesc
            // 
            this.txtProductDesc.Location = new System.Drawing.Point(167, 264);
            this.txtProductDesc.Multiline = true;
            this.txtProductDesc.Name = "txtProductDesc";
            this.txtProductDesc.Size = new System.Drawing.Size(302, 176);
            this.txtProductDesc.TabIndex = 5;
            // 
            // txtImgLink
            // 
            this.txtImgLink.Location = new System.Drawing.Point(167, 119);
            this.txtImgLink.Name = "txtImgLink";
            this.txtImgLink.Size = new System.Drawing.Size(302, 30);
            this.txtImgLink.TabIndex = 2;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(167, 76);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(302, 30);
            this.txtProductName.TabIndex = 1;
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(527, 38);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.RowTemplate.Height = 29;
            this.dgvProducts.Size = new System.Drawing.Size(926, 851);
            this.dgvProducts.TabIndex = 7;
            this.dgvProducts.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvProducts_RowHeaderMouseClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.lstProductTypeSearch);
            this.groupBox3.Controls.Add(this.lstCategorySearch);
            this.groupBox3.Controls.Add(this.btnClearSearchBox);
            this.groupBox3.Controls.Add(this.txtSearchProducts);
            this.groupBox3.Controls.Add(this.btnSearchProducts);
            this.groupBox3.Location = new System.Drawing.Point(12, 573);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(496, 316);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Search";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 164);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 20);
            this.label9.TabIndex = 17;
            this.label9.Text = "Product Type";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Category";
            // 
            // lstProductTypeSearch
            // 
            this.lstProductTypeSearch.FormattingEnabled = true;
            this.lstProductTypeSearch.Location = new System.Drawing.Point(13, 190);
            this.lstProductTypeSearch.Name = "lstProductTypeSearch";
            this.lstProductTypeSearch.Size = new System.Drawing.Size(456, 28);
            this.lstProductTypeSearch.Sorted = true;
            this.lstProductTypeSearch.TabIndex = 11;
            // 
            // lstCategorySearch
            // 
            this.lstCategorySearch.FormattingEnabled = true;
            this.lstCategorySearch.Location = new System.Drawing.Point(13, 113);
            this.lstCategorySearch.Name = "lstCategorySearch";
            this.lstCategorySearch.Size = new System.Drawing.Size(456, 28);
            this.lstCategorySearch.Sorted = true;
            this.lstCategorySearch.TabIndex = 10;
            // 
            // btnClearSearchBox
            // 
            this.btnClearSearchBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClearSearchBox.Location = new System.Drawing.Point(177, 238);
            this.btnClearSearchBox.Name = "btnClearSearchBox";
            this.btnClearSearchBox.Size = new System.Drawing.Size(143, 49);
            this.btnClearSearchBox.TabIndex = 10;
            this.btnClearSearchBox.Text = "Clear";
            this.btnClearSearchBox.UseVisualStyleBackColor = true;
            this.btnClearSearchBox.Click += new System.EventHandler(this.btnClearSearchBox_Click);
            // 
            // txtSearchProducts
            // 
            this.txtSearchProducts.Location = new System.Drawing.Point(13, 26);
            this.txtSearchProducts.Multiline = true;
            this.txtSearchProducts.Name = "txtSearchProducts";
            this.txtSearchProducts.Size = new System.Drawing.Size(456, 50);
            this.txtSearchProducts.TabIndex = 3;
            // 
            // btnSearchProducts
            // 
            this.btnSearchProducts.Location = new System.Drawing.Point(326, 238);
            this.btnSearchProducts.Name = "btnSearchProducts";
            this.btnSearchProducts.Size = new System.Drawing.Size(143, 49);
            this.btnSearchProducts.TabIndex = 4;
            this.btnSearchProducts.Text = "Search";
            this.btnSearchProducts.UseVisualStyleBackColor = true;
            this.btnSearchProducts.Click += new System.EventHandler(this.btnSearchProducts_Click);
            // 
            // frmProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1465, 902);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Name = "frmProducts";
            this.Text = "frmProducts";
            this.Load += new System.EventHandler(this.frmProducts_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSaveProduct;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Label lblIdValue;
        private System.Windows.Forms.TextBox txtProductDesc;
        private System.Windows.Forms.TextBox txtImgLink;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.ComboBox lstCategories;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox lstCategorySearch;
        private System.Windows.Forms.Button btnClearSearchBox;
        private System.Windows.Forms.TextBox txtSearchProducts;
        private System.Windows.Forms.Button btnSearchProducts;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox lstProductType;
        private System.Windows.Forms.Button btnClearProductDetails;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox lstProductTypeSearch;
    }
}