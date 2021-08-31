
using System.Windows.Forms;

namespace GrocerioDesktop.Reports
{
    partial class frmReports
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
            this.dgvStores = new System.Windows.Forms.DataGridView();
            this.btnCreateReport = new System.Windows.Forms.Button();
            this.btnSaveReport = new System.Windows.Forms.Button();
            this.btnDeleteReport = new System.Windows.Forms.Button();
            this.txtMembership = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvPremiumReports = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblSuccessRate = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblReturnReason = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblProductType = new System.Windows.Forms.Label();
            this.lblPopularAddress = new System.Windows.Forms.Label();
            this.lblMostPopularCategory = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvBasicReports = new System.Windows.Forms.DataGridView();
            this.lblProductsSold = new System.Windows.Forms.Label();
            this.lblCurrentTrackingEntries = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblProductsReturned = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCurrentCartEntries = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTopProduct = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblRevenue = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblStoreName = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReportName = new System.Windows.Forms.TextBox();
            this.btnCreateStoreReport = new System.Windows.Forms.Button();
            this.lblRepStoreMembership = new System.Windows.Forms.Label();
            this.lblRepStoreId = new System.Windows.Forms.Label();
            this.dgvStoreReport = new System.Windows.Forms.DataGridView();
            this.txtSearchStoresReport = new System.Windows.Forms.TextBox();
            this.BtnSearchStores = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStores)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPremiumReports)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasicReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStoreReport)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStores
            // 
            this.dgvStores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStores.Location = new System.Drawing.Point(6, 26);
            this.dgvStores.Name = "dgvStores";
            this.dgvStores.RowHeadersWidth = 51;
            this.dgvStores.RowTemplate.Height = 29;
            this.dgvStores.Size = new System.Drawing.Size(765, 237);
            this.dgvStores.TabIndex = 0;
            // 
            // btnCreateReport
            // 
            this.btnCreateReport.Location = new System.Drawing.Point(370, 314);
            this.btnCreateReport.Name = "btnCreateReport";
            this.btnCreateReport.Size = new System.Drawing.Size(136, 53);
            this.btnCreateReport.TabIndex = 1;
            this.btnCreateReport.Text = "Create Report";
            this.btnCreateReport.UseVisualStyleBackColor = true;
            // 
            // btnSaveReport
            // 
            this.btnSaveReport.Location = new System.Drawing.Point(512, 314);
            this.btnSaveReport.Name = "btnSaveReport";
            this.btnSaveReport.Size = new System.Drawing.Size(153, 53);
            this.btnSaveReport.TabIndex = 2;
            this.btnSaveReport.Text = "Save Report";
            this.btnSaveReport.UseVisualStyleBackColor = true;
            // 
            // btnDeleteReport
            // 
            this.btnDeleteReport.Location = new System.Drawing.Point(93, 314);
            this.btnDeleteReport.Name = "btnDeleteReport";
            this.btnDeleteReport.Size = new System.Drawing.Size(131, 53);
            this.btnDeleteReport.TabIndex = 3;
            this.btnDeleteReport.Text = "Delete Report";
            this.btnDeleteReport.UseVisualStyleBackColor = true;
            // 
            // txtMembership
            // 
            this.txtMembership.Location = new System.Drawing.Point(230, 314);
            this.txtMembership.Name = "txtMembership";
            this.txtMembership.Size = new System.Drawing.Size(36, 27);
            this.txtMembership.TabIndex = 0;
            this.txtMembership.TabStop = false;
            this.txtMembership.Visible = false;
            this.txtMembership.WordWrap = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvStores);
            this.groupBox1.Controls.Add(this.txtMembership);
            this.groupBox1.Controls.Add(this.btnSaveReport);
            this.groupBox1.Controls.Add(this.btnCreateReport);
            this.groupBox1.Controls.Add(this.btnDeleteReport);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(961, 1003);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtpTo);
            this.groupBox2.Controls.Add(this.dtpFrom);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtReportName);
            this.groupBox2.Controls.Add(this.btnCreateStoreReport);
            this.groupBox2.Controls.Add(this.lblRepStoreMembership);
            this.groupBox2.Controls.Add(this.lblRepStoreId);
            this.groupBox2.Controls.Add(this.dgvStoreReport);
            this.groupBox2.Controls.Add(this.txtSearchStoresReport);
            this.groupBox2.Controls.Add(this.BtnSearchStores);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(3, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1248, 989);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reports";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvPremiumReports);
            this.groupBox4.Controls.Add(this.btnSave);
            this.groupBox4.Controls.Add(this.lblSuccessRate);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.lblReturnReason);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.lblProductType);
            this.groupBox4.Controls.Add(this.lblPopularAddress);
            this.groupBox4.Controls.Add(this.lblMostPopularCategory);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Location = new System.Drawing.Point(9, 646);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1214, 312);
            this.groupBox4.TabIndex = 33;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Premium";
            // 
            // dgvPremiumReports
            // 
            this.dgvPremiumReports.AllowUserToAddRows = false;
            this.dgvPremiumReports.AllowUserToDeleteRows = false;
            this.dgvPremiumReports.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvPremiumReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPremiumReports.Location = new System.Drawing.Point(606, 52);
            this.dgvPremiumReports.Name = "dgvPremiumReports";
            this.dgvPremiumReports.ReadOnly = true;
            this.dgvPremiumReports.RowHeadersWidth = 51;
            this.dgvPremiumReports.RowTemplate.Height = 29;
            this.dgvPremiumReports.Size = new System.Drawing.Size(602, 254);
            this.dgvPremiumReports.TabIndex = 39;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(274, 247);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(250, 36);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "Save Report";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblSuccessRate
            // 
            this.lblSuccessRate.AutoSize = true;
            this.lblSuccessRate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSuccessRate.Location = new System.Drawing.Point(21, 255);
            this.lblSuccessRate.Name = "lblSuccessRate";
            this.lblSuccessRate.Size = new System.Drawing.Size(74, 28);
            this.lblSuccessRate.TabIndex = 38;
            this.lblSuccessRate.Text = "label12";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(21, 220);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 20);
            this.label16.TabIndex = 37;
            this.label16.Text = "Success Rate";
            // 
            // lblReturnReason
            // 
            this.lblReturnReason.AutoSize = true;
            this.lblReturnReason.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblReturnReason.Location = new System.Drawing.Point(258, 172);
            this.lblReturnReason.Name = "lblReturnReason";
            this.lblReturnReason.Size = new System.Drawing.Size(74, 28);
            this.lblReturnReason.TabIndex = 36;
            this.lblReturnReason.Text = "label12";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(167, 20);
            this.label13.TabIndex = 29;
            this.label13.Text = "Most Popular Category";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(21, 137);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(201, 20);
            this.label14.TabIndex = 30;
            this.label14.Text = "Most Popular Client Address";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(258, 137);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(151, 20);
            this.label15.TabIndex = 31;
            this.label15.Text = "Main Return Reason ";
            // 
            // lblProductType
            // 
            this.lblProductType.AutoSize = true;
            this.lblProductType.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblProductType.Location = new System.Drawing.Point(258, 78);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(74, 28);
            this.lblProductType.TabIndex = 35;
            this.lblProductType.Text = "label12";
            // 
            // lblPopularAddress
            // 
            this.lblPopularAddress.AutoSize = true;
            this.lblPopularAddress.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPopularAddress.Location = new System.Drawing.Point(21, 172);
            this.lblPopularAddress.Name = "lblPopularAddress";
            this.lblPopularAddress.Size = new System.Drawing.Size(74, 28);
            this.lblPopularAddress.TabIndex = 34;
            this.lblPopularAddress.Text = "label12";
            // 
            // lblMostPopularCategory
            // 
            this.lblMostPopularCategory.AutoSize = true;
            this.lblMostPopularCategory.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMostPopularCategory.Location = new System.Drawing.Point(21, 78);
            this.lblMostPopularCategory.Name = "lblMostPopularCategory";
            this.lblMostPopularCategory.Size = new System.Drawing.Size(74, 28);
            this.lblMostPopularCategory.TabIndex = 33;
            this.lblMostPopularCategory.Text = "label12";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(258, 41);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(193, 20);
            this.label19.TabIndex = 32;
            this.label19.Text = "Most popular product type";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvBasicReports);
            this.groupBox3.Controls.Add(this.lblProductsSold);
            this.groupBox3.Controls.Add(this.lblCurrentTrackingEntries);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.lblProductsReturned);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.lblCurrentCartEntries);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.lblTopProduct);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.lblRevenue);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.lblStoreName);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(9, 245);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1214, 382);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Basic Report";
            // 
            // dgvBasicReports
            // 
            this.dgvBasicReports.AllowUserToAddRows = false;
            this.dgvBasicReports.AllowUserToDeleteRows = false;
            this.dgvBasicReports.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvBasicReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBasicReports.Location = new System.Drawing.Point(606, 65);
            this.dgvBasicReports.Name = "dgvBasicReports";
            this.dgvBasicReports.ReadOnly = true;
            this.dgvBasicReports.RowHeadersWidth = 51;
            this.dgvBasicReports.RowTemplate.Height = 29;
            this.dgvBasicReports.Size = new System.Drawing.Size(602, 254);
            this.dgvBasicReports.TabIndex = 32;
            // 
            // lblProductsSold
            // 
            this.lblProductsSold.AutoSize = true;
            this.lblProductsSold.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblProductsSold.Location = new System.Drawing.Point(258, 159);
            this.lblProductsSold.Name = "lblProductsSold";
            this.lblProductsSold.Size = new System.Drawing.Size(74, 28);
            this.lblProductsSold.TabIndex = 28;
            this.lblProductsSold.Text = "label12";
            // 
            // lblCurrentTrackingEntries
            // 
            this.lblCurrentTrackingEntries.AutoSize = true;
            this.lblCurrentTrackingEntries.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentTrackingEntries.Location = new System.Drawing.Point(21, 352);
            this.lblCurrentTrackingEntries.Name = "lblCurrentTrackingEntries";
            this.lblCurrentTrackingEntries.Size = new System.Drawing.Size(74, 28);
            this.lblCurrentTrackingEntries.TabIndex = 31;
            this.lblCurrentTrackingEntries.Text = "label12";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Store Name";
            // 
            // lblProductsReturned
            // 
            this.lblProductsReturned.AutoSize = true;
            this.lblProductsReturned.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblProductsReturned.Location = new System.Drawing.Point(21, 255);
            this.lblProductsReturned.Name = "lblProductsReturned";
            this.lblProductsReturned.Size = new System.Drawing.Size(74, 28);
            this.lblProductsReturned.TabIndex = 30;
            this.lblProductsReturned.Text = "label12";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "Revenue";
            // 
            // lblCurrentCartEntries
            // 
            this.lblCurrentCartEntries.AutoSize = true;
            this.lblCurrentCartEntries.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentCartEntries.Location = new System.Drawing.Point(258, 255);
            this.lblCurrentCartEntries.Name = "lblCurrentCartEntries";
            this.lblCurrentCartEntries.Size = new System.Drawing.Size(74, 28);
            this.lblCurrentCartEntries.TabIndex = 29;
            this.lblCurrentCartEntries.Text = "label12";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(258, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 20);
            this.label7.TabIndex = 19;
            this.label7.Text = "Products Sold";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "Products Returned";
            // 
            // lblTopProduct
            // 
            this.lblTopProduct.AutoSize = true;
            this.lblTopProduct.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTopProduct.Location = new System.Drawing.Point(258, 65);
            this.lblTopProduct.Name = "lblTopProduct";
            this.lblTopProduct.Size = new System.Drawing.Size(74, 28);
            this.lblTopProduct.TabIndex = 27;
            this.lblTopProduct.Text = "label12";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(258, 220);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "Current Cart Entries";
            // 
            // lblRevenue
            // 
            this.lblRevenue.AutoSize = true;
            this.lblRevenue.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRevenue.Location = new System.Drawing.Point(21, 159);
            this.lblRevenue.Name = "lblRevenue";
            this.lblRevenue.Size = new System.Drawing.Size(74, 28);
            this.lblRevenue.TabIndex = 26;
            this.lblRevenue.Text = "label12";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 316);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(173, 20);
            this.label10.TabIndex = 22;
            this.label10.Text = "Current Tracking Entries";
            // 
            // lblStoreName
            // 
            this.lblStoreName.AutoSize = true;
            this.lblStoreName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStoreName.Location = new System.Drawing.Point(21, 65);
            this.lblStoreName.Name = "lblStoreName";
            this.lblStoreName.Size = new System.Drawing.Size(74, 28);
            this.lblStoreName.TabIndex = 24;
            this.lblStoreName.Text = "label12";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(258, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 20);
            this.label11.TabIndex = 23;
            this.label11.Text = "TopProduct";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "StoreId";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "From";
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(9, 190);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(250, 27);
            this.dtpTo.TabIndex = 6;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(9, 126);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(250, 27);
            this.dtpFrom.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(283, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Report Name";
            // 
            // txtReportName
            // 
            this.txtReportName.Location = new System.Drawing.Point(283, 126);
            this.txtReportName.Name = "txtReportName";
            this.txtReportName.Size = new System.Drawing.Size(250, 27);
            this.txtReportName.TabIndex = 4;
            // 
            // btnCreateStoreReport
            // 
            this.btnCreateStoreReport.Location = new System.Drawing.Point(283, 182);
            this.btnCreateStoreReport.Name = "btnCreateStoreReport";
            this.btnCreateStoreReport.Size = new System.Drawing.Size(250, 36);
            this.btnCreateStoreReport.TabIndex = 7;
            this.btnCreateStoreReport.Text = "Create Report";
            this.btnCreateStoreReport.UseVisualStyleBackColor = true;
            this.btnCreateStoreReport.Click += new System.EventHandler(this.btnCreateStoreReport_Click);
            // 
            // lblRepStoreMembership
            // 
            this.lblRepStoreMembership.AutoSize = true;
            this.lblRepStoreMembership.Location = new System.Drawing.Point(314, 209);
            this.lblRepStoreMembership.Name = "lblRepStoreMembership";
            this.lblRepStoreMembership.Size = new System.Drawing.Size(0, 20);
            this.lblRepStoreMembership.TabIndex = 7;
            this.lblRepStoreMembership.Visible = false;
            // 
            // lblRepStoreId
            // 
            this.lblRepStoreId.AutoSize = true;
            this.lblRepStoreId.Location = new System.Drawing.Point(92, 48);
            this.lblRepStoreId.Name = "lblRepStoreId";
            this.lblRepStoreId.Size = new System.Drawing.Size(0, 20);
            this.lblRepStoreId.TabIndex = 6;
            // 
            // dgvStoreReport
            // 
            this.dgvStoreReport.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvStoreReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStoreReport.Location = new System.Drawing.Point(615, 84);
            this.dgvStoreReport.Name = "dgvStoreReport";
            this.dgvStoreReport.RowHeadersWidth = 51;
            this.dgvStoreReport.RowTemplate.Height = 29;
            this.dgvStoreReport.Size = new System.Drawing.Size(602, 145);
            this.dgvStoreReport.TabIndex = 3;
            this.dgvStoreReport.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvStoreReport_RowHeaderMouseClick);
            // 
            // txtSearchStoresReport
            // 
            this.txtSearchStoresReport.Location = new System.Drawing.Point(615, 37);
            this.txtSearchStoresReport.Multiline = true;
            this.txtSearchStoresReport.Name = "txtSearchStoresReport";
            this.txtSearchStoresReport.Size = new System.Drawing.Size(453, 41);
            this.txtSearchStoresReport.TabIndex = 1;
            // 
            // BtnSearchStores
            // 
            this.BtnSearchStores.Location = new System.Drawing.Point(1074, 37);
            this.BtnSearchStores.Name = "BtnSearchStores";
            this.BtnSearchStores.Size = new System.Drawing.Size(143, 41);
            this.BtnSearchStores.TabIndex = 2;
            this.BtnSearchStores.Text = "Search";
            this.BtnSearchStores.UseVisualStyleBackColor = true;
            this.BtnSearchStores.Click += new System.EventHandler(this.BtnSearchStores_Click);
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 1018);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmReports";
            this.Text = "frmReports";
            this.Load += new System.EventHandler(this.frmReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStores)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPremiumReports)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasicReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStoreReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStores;
        private System.Windows.Forms.Button btnCreateReport;
        private System.Windows.Forms.Button btnSaveReport;
        private System.Windows.Forms.Button btnDeleteReport;
        private System.Windows.Forms.TextBox txtMembership;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvStoreReport;
        private System.Windows.Forms.TextBox txtSearchStoresReport;
        private System.Windows.Forms.Button BtnSearchStores;
        private System.Windows.Forms.Label lblRepStoreMembership;
        private System.Windows.Forms.Label lblRepStoreId;
        private System.Windows.Forms.TextBox txtReportName;
        private System.Windows.Forms.Button btnCreateStoreReport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblCurrentTrackingEntries;
        private System.Windows.Forms.Label lblProductsReturned;
        private System.Windows.Forms.Label lblCurrentCartEntries;
        private System.Windows.Forms.Label lblProductsSold;
        private System.Windows.Forms.Label lblTopProduct;
        private System.Windows.Forms.Label lblRevenue;
        private System.Windows.Forms.Label lblStoreName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblSuccessRate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblReturnReason;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblProductType;
        private System.Windows.Forms.Label lblPopularAddress;
        private System.Windows.Forms.Label lblMostPopularCategory;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvBasicReports;
        private DataGridView dgvPremiumReports;
    }
}