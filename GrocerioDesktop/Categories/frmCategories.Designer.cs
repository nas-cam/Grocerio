
namespace GrocerioDesktop.Categories
{
    partial class FrmCategories
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
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.gbAddCategory = new System.Windows.Forms.GroupBox();
            this.btnClearCategoryDetails = new System.Windows.Forms.Button();
            this.lblId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnSaveCategory = new System.Windows.Forms.Button();
            this.txtImgLink = new System.Windows.Forms.TextBox();
            this.lblImageLink = new System.Windows.Forms.Label();
            this.txtDescCat = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtNameCat = new System.Windows.Forms.TextBox();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.btnSearchCategories = new System.Windows.Forms.Button();
            this.txtSearchCategories = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClearSearchBox = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.gbAddCategory.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCategories
            // 
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AllowUserToDeleteRows = false;
            this.dgvCategories.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.Location = new System.Drawing.Point(523, 25);
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.ReadOnly = true;
            this.dgvCategories.RowHeadersWidth = 51;
            this.dgvCategories.RowTemplate.Height = 29;
            this.dgvCategories.Size = new System.Drawing.Size(712, 907);
            this.dgvCategories.TabIndex = 0;
            this.dgvCategories.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCategories_RowHeaderMouseClick);
            // 
            // gbAddCategory
            // 
            this.gbAddCategory.Controls.Add(this.btnClearCategoryDetails);
            this.gbAddCategory.Controls.Add(this.lblId);
            this.gbAddCategory.Controls.Add(this.label1);
            this.gbAddCategory.Controls.Add(this.BtnSaveCategory);
            this.gbAddCategory.Controls.Add(this.txtImgLink);
            this.gbAddCategory.Controls.Add(this.lblImageLink);
            this.gbAddCategory.Controls.Add(this.txtDescCat);
            this.gbAddCategory.Controls.Add(this.lblDescription);
            this.gbAddCategory.Controls.Add(this.txtNameCat);
            this.gbAddCategory.Controls.Add(this.lblCategoryName);
            this.gbAddCategory.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gbAddCategory.Location = new System.Drawing.Point(12, 12);
            this.gbAddCategory.Name = "gbAddCategory";
            this.gbAddCategory.Size = new System.Drawing.Size(496, 370);
            this.gbAddCategory.TabIndex = 2;
            this.gbAddCategory.TabStop = false;
            this.gbAddCategory.Text = "Category details";
            // 
            // btnClearCategoryDetails
            // 
            this.btnClearCategoryDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClearCategoryDetails.Location = new System.Drawing.Point(177, 295);
            this.btnClearCategoryDetails.Name = "btnClearCategoryDetails";
            this.btnClearCategoryDetails.Size = new System.Drawing.Size(143, 49);
            this.btnClearCategoryDetails.TabIndex = 5;
            this.btnClearCategoryDetails.Text = "Clear";
            this.btnClearCategoryDetails.UseVisualStyleBackColor = true;
            this.btnClearCategoryDetails.Click += new System.EventHandler(this.btnClearCategoryDetails_Click);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(181, 47);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(0, 23);
            this.lblId.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Id";
            // 
            // BtnSaveCategory
            // 
            this.BtnSaveCategory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveCategory.Location = new System.Drawing.Point(326, 295);
            this.BtnSaveCategory.Name = "BtnSaveCategory";
            this.BtnSaveCategory.Size = new System.Drawing.Size(143, 49);
            this.BtnSaveCategory.TabIndex = 4;
            this.BtnSaveCategory.Text = "Save";
            this.BtnSaveCategory.UseVisualStyleBackColor = true;
            this.BtnSaveCategory.Click += new System.EventHandler(this.BtnSaveCategory_Click);
            // 
            // txtImgLink
            // 
            this.txtImgLink.Location = new System.Drawing.Point(181, 157);
            this.txtImgLink.Name = "txtImgLink";
            this.txtImgLink.Size = new System.Drawing.Size(289, 30);
            this.txtImgLink.TabIndex = 2;
            // 
            // lblImageLink
            // 
            this.lblImageLink.AutoSize = true;
            this.lblImageLink.Location = new System.Drawing.Point(13, 157);
            this.lblImageLink.Name = "lblImageLink";
            this.lblImageLink.Size = new System.Drawing.Size(94, 23);
            this.lblImageLink.TabIndex = 4;
            this.lblImageLink.Text = "Image Link";
            // 
            // txtDescCat
            // 
            this.txtDescCat.Location = new System.Drawing.Point(181, 228);
            this.txtDescCat.Name = "txtDescCat";
            this.txtDescCat.Size = new System.Drawing.Size(289, 30);
            this.txtDescCat.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(13, 228);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(96, 23);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description";
            // 
            // txtNameCat
            // 
            this.txtNameCat.Location = new System.Drawing.Point(181, 91);
            this.txtNameCat.Name = "txtNameCat";
            this.txtNameCat.Size = new System.Drawing.Size(289, 30);
            this.txtNameCat.TabIndex = 1;
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Location = new System.Drawing.Point(13, 91);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(56, 23);
            this.lblCategoryName.TabIndex = 0;
            this.lblCategoryName.Text = "Name";
            // 
            // btnSearchCategories
            // 
            this.btnSearchCategories.Location = new System.Drawing.Point(326, 109);
            this.btnSearchCategories.Name = "btnSearchCategories";
            this.btnSearchCategories.Size = new System.Drawing.Size(143, 49);
            this.btnSearchCategories.TabIndex = 4;
            this.btnSearchCategories.Text = "Search";
            this.btnSearchCategories.UseVisualStyleBackColor = true;
            this.btnSearchCategories.Click += new System.EventHandler(this.btnSearchCategories_Click);
            // 
            // txtSearchCategories
            // 
            this.txtSearchCategories.Location = new System.Drawing.Point(13, 38);
            this.txtSearchCategories.Multiline = true;
            this.txtSearchCategories.Name = "txtSearchCategories";
            this.txtSearchCategories.Size = new System.Drawing.Size(456, 50);
            this.txtSearchCategories.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClearSearchBox);
            this.groupBox1.Controls.Add(this.txtSearchCategories);
            this.groupBox1.Controls.Add(this.btnSearchCategories);
            this.groupBox1.Location = new System.Drawing.Point(12, 427);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(496, 179);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // btnClearSearchBox
            // 
            this.btnClearSearchBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClearSearchBox.Location = new System.Drawing.Point(177, 109);
            this.btnClearSearchBox.Name = "btnClearSearchBox";
            this.btnClearSearchBox.Size = new System.Drawing.Size(143, 49);
            this.btnClearSearchBox.TabIndex = 10;
            this.btnClearSearchBox.Text = "Clear";
            this.btnClearSearchBox.UseVisualStyleBackColor = true;
            this.btnClearSearchBox.Click += new System.EventHandler(this.btnClearSearchBox_Click);
            // 
            // FrmCategories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 990);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbAddCategory);
            this.Controls.Add(this.dgvCategories);
            this.Name = "FrmCategories";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCategories";
            this.Load += new System.EventHandler(this.FrmCategories_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.gbAddCategory.ResumeLayout(false);
            this.gbAddCategory.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.GroupBox gbAddCategory;
        private System.Windows.Forms.Button BtnSaveCategory;
        private System.Windows.Forms.TextBox txtImgLink;
        private System.Windows.Forms.Label lblImageLink;
        private System.Windows.Forms.TextBox txtDescCat;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtNameCat;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnSearchCategories;
        private System.Windows.Forms.TextBox txtSearchCategories;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClearCategoryDetails;
        private System.Windows.Forms.Button btnClearSearchBox;
    }
}