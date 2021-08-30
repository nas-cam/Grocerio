
namespace GrocerioDesktop.ReturnReasons
{
    partial class frmReturnReasons
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.dgvReturnReasons = new System.Windows.Forms.DataGridView();
            this.lblId = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstboxSeriousness = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnReasons)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Reason";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Seriousness";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(151, 80);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(241, 83);
            this.txtReason.TabIndex = 7;
            // 
            // dgvReturnReasons
            // 
            this.dgvReturnReasons.AllowUserToAddRows = false;
            this.dgvReturnReasons.AllowUserToDeleteRows = false;
            this.dgvReturnReasons.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvReturnReasons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReturnReasons.GridColor = System.Drawing.SystemColors.Control;
            this.dgvReturnReasons.Location = new System.Drawing.Point(485, 25);
            this.dgvReturnReasons.Name = "dgvReturnReasons";
            this.dgvReturnReasons.ReadOnly = true;
            this.dgvReturnReasons.RowHeadersWidth = 51;
            this.dgvReturnReasons.RowTemplate.Height = 29;
            this.dgvReturnReasons.Size = new System.Drawing.Size(574, 670);
            this.dgvReturnReasons.TabIndex = 8;
            this.dgvReturnReasons.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvReturnReasons_RowHeaderMouseClick);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(241, 46);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(0, 20);
            this.lblId.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(298, 219);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 49);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(151, 219);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 50);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstboxSeriousness);
            this.groupBox1.Controls.Add(this.txtReason);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblId);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(22, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 301);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Return Reasons";
            // 
            // lstboxSeriousness
            // 
            this.lstboxSeriousness.FormattingEnabled = true;
            this.lstboxSeriousness.ItemHeight = 20;
            this.lstboxSeriousness.Location = new System.Drawing.Point(151, 169);
            this.lstboxSeriousness.Name = "lstboxSeriousness";
            this.lstboxSeriousness.Size = new System.Drawing.Size(241, 44);
            this.lstboxSeriousness.TabIndex = 12;
            // 
            // frmReturnReasons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 718);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvReturnReasons);
            this.Name = "frmReturnReasons";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReturnReasons";
            this.Load += new System.EventHandler(this.frmReturnReasons_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnReasons)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.DataGridView dgvReturnReasons;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstboxSeriousness;
    }
}