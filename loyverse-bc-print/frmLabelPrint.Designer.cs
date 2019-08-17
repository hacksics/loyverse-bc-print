namespace loyverse_bc_print
{
    partial class frmLabelPrint
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBCType2Print = new System.Windows.Forms.Button();
            this.btnBCType1Print = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbBarcode = new System.Windows.Forms.RadioButton();
            this.rbDepartmentID = new System.Windows.Forms.RadioButton();
            this.rbVendorID = new System.Windows.Forms.RadioButton();
            this.rbDescription = new System.Windows.Forms.RadioButton();
            this.txtSearchItem = new System.Windows.Forms.TextBox();
            this.lvStocks = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBCType2Print);
            this.groupBox1.Controls.Add(this.btnBCType1Print);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(911, 88);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // btnBCType2Print
            // 
            this.btnBCType2Print.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnBCType2Print.FlatAppearance.BorderSize = 0;
            this.btnBCType2Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBCType2Print.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBCType2Print.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBCType2Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBCType2Print.Location = new System.Drawing.Point(248, 16);
            this.btnBCType2Print.Name = "btnBCType2Print";
            this.btnBCType2Print.Size = new System.Drawing.Size(225, 60);
            this.btnBCType2Print.TabIndex = 54;
            this.btnBCType2Print.Text = "  Print Barcode 2";
            this.btnBCType2Print.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBCType2Print.UseVisualStyleBackColor = false;
            this.btnBCType2Print.Click += new System.EventHandler(this.BtnBCType2Print_Click);
            // 
            // btnBCType1Print
            // 
            this.btnBCType1Print.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnBCType1Print.FlatAppearance.BorderSize = 0;
            this.btnBCType1Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBCType1Print.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBCType1Print.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBCType1Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBCType1Print.Location = new System.Drawing.Point(17, 16);
            this.btnBCType1Print.Name = "btnBCType1Print";
            this.btnBCType1Print.Size = new System.Drawing.Size(225, 60);
            this.btnBCType1Print.TabIndex = 53;
            this.btnBCType1Print.Text = "  Print Barcode 1";
            this.btnBCType1Print.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBCType1Print.UseVisualStyleBackColor = false;
            this.btnBCType1Print.Click += new System.EventHandler(this.BtnBCType1Print_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Crimson;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnExit.Location = new System.Drawing.Point(777, 16);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(128, 60);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Close";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbBarcode);
            this.groupBox3.Controls.Add(this.rbDepartmentID);
            this.groupBox3.Controls.Add(this.rbVendorID);
            this.groupBox3.Controls.Add(this.rbDescription);
            this.groupBox3.Controls.Add(this.txtSearchItem);
            this.groupBox3.Controls.Add(this.lvStocks);
            this.groupBox3.Location = new System.Drawing.Point(12, 106);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(911, 482);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            // 
            // rbBarcode
            // 
            this.rbBarcode.AutoSize = true;
            this.rbBarcode.Checked = true;
            this.rbBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBarcode.Location = new System.Drawing.Point(320, 31);
            this.rbBarcode.Name = "rbBarcode";
            this.rbBarcode.Size = new System.Drawing.Size(90, 19);
            this.rbBarcode.TabIndex = 8;
            this.rbBarcode.TabStop = true;
            this.rbBarcode.Text = "BARCODE";
            this.rbBarcode.UseVisualStyleBackColor = true;
            // 
            // rbDepartmentID
            // 
            this.rbDepartmentID.AutoSize = true;
            this.rbDepartmentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDepartmentID.Location = new System.Drawing.Point(679, 31);
            this.rbDepartmentID.Name = "rbDepartmentID";
            this.rbDepartmentID.Size = new System.Drawing.Size(118, 19);
            this.rbDepartmentID.TabIndex = 7;
            this.rbDepartmentID.Text = "DEPARTMENT";
            this.rbDepartmentID.UseVisualStyleBackColor = true;
            // 
            // rbVendorID
            // 
            this.rbVendorID.AutoSize = true;
            this.rbVendorID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbVendorID.Location = new System.Drawing.Point(559, 31);
            this.rbVendorID.Name = "rbVendorID";
            this.rbVendorID.Size = new System.Drawing.Size(100, 19);
            this.rbVendorID.TabIndex = 6;
            this.rbVendorID.Text = "VENDOR ID";
            this.rbVendorID.UseVisualStyleBackColor = true;
            // 
            // rbDescription
            // 
            this.rbDescription.AutoSize = true;
            this.rbDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDescription.Location = new System.Drawing.Point(426, 31);
            this.rbDescription.Name = "rbDescription";
            this.rbDescription.Size = new System.Drawing.Size(117, 19);
            this.rbDescription.TabIndex = 5;
            this.rbDescription.Text = "DESCRIPTION";
            this.rbDescription.UseVisualStyleBackColor = true;
            // 
            // txtSearchItem
            // 
            this.txtSearchItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchItem.Location = new System.Drawing.Point(6, 19);
            this.txtSearchItem.Name = "txtSearchItem";
            this.txtSearchItem.Size = new System.Drawing.Size(286, 31);
            this.txtSearchItem.TabIndex = 4;
            // 
            // lvStocks
            // 
            this.lvStocks.CheckBoxes = true;
            this.lvStocks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lvStocks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvStocks.FullRowSelect = true;
            this.lvStocks.GridLines = true;
            this.lvStocks.Location = new System.Drawing.Point(6, 64);
            this.lvStocks.Name = "lvStocks";
            this.lvStocks.Size = new System.Drawing.Size(899, 412);
            this.lvStocks.TabIndex = 0;
            this.lvStocks.UseCompatibleStateImageBehavior = false;
            this.lvStocks.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Barcode";
            this.columnHeader1.Width = 140;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 250;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "CostPrice";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Sale Price";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Quantity";
            this.columnHeader5.Width = 80;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Dept";
            this.columnHeader6.Width = 110;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Vendor";
            this.columnHeader7.Width = 80;
            // 
            // frmLabelPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(936, 595);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLabelPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmLabelPrint";
            this.Load += new System.EventHandler(this.FrmLabelPrint_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbBarcode;
        private System.Windows.Forms.RadioButton rbDepartmentID;
        private System.Windows.Forms.RadioButton rbVendorID;
        private System.Windows.Forms.RadioButton rbDescription;
        private System.Windows.Forms.TextBox txtSearchItem;
        private System.Windows.Forms.ListView lvStocks;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnBCType2Print;
        private System.Windows.Forms.Button btnBCType1Print;
    }
}