namespace loyverse_bc_print
{
    partial class frmInventory
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExportToCSVAll = new System.Windows.Forms.Button();
            this.btnPrintAllBarcodes = new System.Windows.Forms.Button();
            this.btnExportToCSVNew = new System.Windows.Forms.Button();
            this.btnPrintNewBarcodes = new System.Windows.Forms.Button();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.btnEditItem = new System.Windows.Forms.Button();
            this.btnNewItem = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
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
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtVendorID = new System.Windows.Forms.TextBox();
            this.cmbDepartments = new System.Windows.Forms.ComboBox();
            this.lblMargin = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBC2 = new System.Windows.Forms.TextBox();
            this.txtStockQty = new System.Windows.Forms.TextBox();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.txtBuyingPrice = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1057, 54);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Loyverse Barcode Maker";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Crimson;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnExit.Location = new System.Drawing.Point(929, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(128, 54);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 54);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1057, 2);
            this.panel3.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(70)))));
            this.panel2.Controls.Add(this.btnExportToCSVAll);
            this.panel2.Controls.Add(this.btnPrintAllBarcodes);
            this.panel2.Controls.Add(this.btnExportToCSVNew);
            this.panel2.Controls.Add(this.btnPrintNewBarcodes);
            this.panel2.Controls.Add(this.btnDeleteItem);
            this.panel2.Controls.Add(this.btnEditItem);
            this.panel2.Controls.Add(this.btnNewItem);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(228, 620);
            this.panel2.TabIndex = 3;
            // 
            // btnExportToCSVAll
            // 
            this.btnExportToCSVAll.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnExportToCSVAll.FlatAppearance.BorderSize = 0;
            this.btnExportToCSVAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportToCSVAll.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToCSVAll.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExportToCSVAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportToCSVAll.Location = new System.Drawing.Point(0, 470);
            this.btnExportToCSVAll.Name = "btnExportToCSVAll";
            this.btnExportToCSVAll.Size = new System.Drawing.Size(225, 60);
            this.btnExportToCSVAll.TabIndex = 9;
            this.btnExportToCSVAll.Text = "  Export To CSV (All)";
            this.btnExportToCSVAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportToCSVAll.UseVisualStyleBackColor = false;
            this.btnExportToCSVAll.Click += new System.EventHandler(this.BtnExportToCSVAll_Click);
            // 
            // btnPrintAllBarcodes
            // 
            this.btnPrintAllBarcodes.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnPrintAllBarcodes.FlatAppearance.BorderSize = 0;
            this.btnPrintAllBarcodes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintAllBarcodes.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintAllBarcodes.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPrintAllBarcodes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintAllBarcodes.Location = new System.Drawing.Point(0, 404);
            this.btnPrintAllBarcodes.Name = "btnPrintAllBarcodes";
            this.btnPrintAllBarcodes.Size = new System.Drawing.Size(225, 60);
            this.btnPrintAllBarcodes.TabIndex = 8;
            this.btnPrintAllBarcodes.Text = "  Print All Barcodes";
            this.btnPrintAllBarcodes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintAllBarcodes.UseVisualStyleBackColor = false;
            this.btnPrintAllBarcodes.Click += new System.EventHandler(this.BtnPrintAllBarcodes_Click);
            // 
            // btnExportToCSVNew
            // 
            this.btnExportToCSVNew.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnExportToCSVNew.FlatAppearance.BorderSize = 0;
            this.btnExportToCSVNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportToCSVNew.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToCSVNew.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExportToCSVNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportToCSVNew.Location = new System.Drawing.Point(0, 338);
            this.btnExportToCSVNew.Name = "btnExportToCSVNew";
            this.btnExportToCSVNew.Size = new System.Drawing.Size(225, 60);
            this.btnExportToCSVNew.TabIndex = 7;
            this.btnExportToCSVNew.Text = "  Export To CSV (New)";
            this.btnExportToCSVNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportToCSVNew.UseVisualStyleBackColor = false;
            this.btnExportToCSVNew.Click += new System.EventHandler(this.BtnExportToCSVNew_Click);
            // 
            // btnPrintNewBarcodes
            // 
            this.btnPrintNewBarcodes.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnPrintNewBarcodes.FlatAppearance.BorderSize = 0;
            this.btnPrintNewBarcodes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintNewBarcodes.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintNewBarcodes.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPrintNewBarcodes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintNewBarcodes.Location = new System.Drawing.Point(0, 272);
            this.btnPrintNewBarcodes.Name = "btnPrintNewBarcodes";
            this.btnPrintNewBarcodes.Size = new System.Drawing.Size(225, 60);
            this.btnPrintNewBarcodes.TabIndex = 6;
            this.btnPrintNewBarcodes.Text = "  Print New Barcodes";
            this.btnPrintNewBarcodes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintNewBarcodes.UseVisualStyleBackColor = false;
            this.btnPrintNewBarcodes.Click += new System.EventHandler(this.BtnPrintNewBarcodes_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnDeleteItem.FlatAppearance.BorderSize = 0;
            this.btnDeleteItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDeleteItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteItem.Location = new System.Drawing.Point(0, 206);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(225, 60);
            this.btnDeleteItem.TabIndex = 5;
            this.btnDeleteItem.Text = "  Delete Item";
            this.btnDeleteItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteItem.UseVisualStyleBackColor = false;
            this.btnDeleteItem.Click += new System.EventHandler(this.BtnDeleteItem_Click);
            // 
            // btnEditItem
            // 
            this.btnEditItem.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnEditItem.FlatAppearance.BorderSize = 0;
            this.btnEditItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEditItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditItem.Location = new System.Drawing.Point(0, 140);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(225, 60);
            this.btnEditItem.TabIndex = 1;
            this.btnEditItem.Text = "  Edit Quantity";
            this.btnEditItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditItem.UseVisualStyleBackColor = false;
            this.btnEditItem.Click += new System.EventHandler(this.BtnEditItem_Click);
            // 
            // btnNewItem
            // 
            this.btnNewItem.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnNewItem.FlatAppearance.BorderSize = 0;
            this.btnNewItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnNewItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewItem.Location = new System.Drawing.Point(0, 74);
            this.btnNewItem.Name = "btnNewItem";
            this.btnNewItem.Size = new System.Drawing.Size(225, 60);
            this.btnNewItem.TabIndex = 0;
            this.btnNewItem.Text = "  New Item";
            this.btnNewItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewItem.UseVisualStyleBackColor = false;
            this.btnNewItem.Click += new System.EventHandler(this.BtnNewItem_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(70)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(228, 56);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(14, 620);
            this.panel4.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.rbBarcode);
            this.groupBox3.Controls.Add(this.rbDepartmentID);
            this.groupBox3.Controls.Add(this.rbVendorID);
            this.groupBox3.Controls.Add(this.rbDescription);
            this.groupBox3.Controls.Add(this.txtSearchItem);
            this.groupBox3.Controls.Add(this.lvStocks);
            this.groupBox3.Location = new System.Drawing.Point(248, 365);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(803, 306);
            this.groupBox3.TabIndex = 5;
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
            this.lvStocks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvStocks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lvStocks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvStocks.FullRowSelect = true;
            this.lvStocks.GridLines = true;
            this.lvStocks.Location = new System.Drawing.Point(6, 66);
            this.lvStocks.Name = "lvStocks";
            this.lvStocks.Size = new System.Drawing.Size(791, 233);
            this.lvStocks.TabIndex = 0;
            this.lvStocks.UseCompatibleStateImageBehavior = false;
            this.lvStocks.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Barcode";
            this.columnHeader1.Width = 92;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 139;
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
            this.columnHeader6.Width = 80;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Vendor";
            this.columnHeader7.Width = 80;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "BC";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtVendorID);
            this.groupBox1.Controls.Add(this.cmbDepartments);
            this.groupBox1.Controls.Add(this.lblMargin);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtBC2);
            this.groupBox1.Controls.Add(this.txtStockQty);
            this.groupBox1.Controls.Add(this.txtUnitPrice);
            this.groupBox1.Controls.Add(this.txtBuyingPrice);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Location = new System.Drawing.Point(248, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(803, 299);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(559, 220);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(225, 60);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "  Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // txtVendorID
            // 
            this.txtVendorID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtVendorID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtVendorID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtVendorID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVendorID.Location = new System.Drawing.Point(238, 60);
            this.txtVendorID.MaxLength = 4;
            this.txtVendorID.Name = "txtVendorID";
            this.txtVendorID.Size = new System.Drawing.Size(71, 31);
            this.txtVendorID.TabIndex = 2;
            this.txtVendorID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtVendorID_KeyDown_1);
            // 
            // cmbDepartments
            // 
            this.cmbDepartments.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbDepartments.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDepartments.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDepartments.FormattingEnabled = true;
            this.cmbDepartments.Items.AddRange(new object[] {
            "Men\'s Clothing",
            "Women\'s Clothing",
            "Accessories",
            "Shoes",
            "Baby Items",
            "Toys",
            "Kitchen Appliances",
            "Home Electronics",
            "Furniture"});
            this.cmbDepartments.Location = new System.Drawing.Point(238, 21);
            this.cmbDepartments.Name = "cmbDepartments";
            this.cmbDepartments.Size = new System.Drawing.Size(210, 33);
            this.cmbDepartments.TabIndex = 1;
            this.cmbDepartments.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbDepartments_KeyDown_1);
            // 
            // lblMargin
            // 
            this.lblMargin.AutoSize = true;
            this.lblMargin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMargin.Location = new System.Drawing.Point(408, 162);
            this.lblMargin.Name = "lblMargin";
            this.lblMargin.Size = new System.Drawing.Size(102, 25);
            this.lblMargin.TabIndex = 49;
            this.lblMargin.Text = "margin %";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(115, 252);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(92, 25);
            this.label8.TabIndex = 40;
            this.label8.Text = "Barcode";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(115, 213);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(92, 25);
            this.label6.TabIndex = 38;
            this.label6.Text = "Quantity";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(97, 176);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(110, 25);
            this.label5.TabIndex = 37;
            this.label5.Text = "Sale Price";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(96, 139);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(111, 25);
            this.label4.TabIndex = 36;
            this.label4.Text = "Cost Price";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(94, 102);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(113, 25);
            this.label3.TabIndex = 35;
            this.label3.Text = "Desciption";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(100, 63);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(107, 25);
            this.label2.TabIndex = 34;
            this.label2.Text = "Vendor ID";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(64, 24);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(143, 25);
            this.label9.TabIndex = 33;
            this.label9.Text = "Deparment ID";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBC2
            // 
            this.txtBC2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBC2.Location = new System.Drawing.Point(238, 249);
            this.txtBC2.MaxLength = 8;
            this.txtBC2.Name = "txtBC2";
            this.txtBC2.Size = new System.Drawing.Size(105, 31);
            this.txtBC2.TabIndex = 7;
            this.txtBC2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBC2_KeyPress);
            // 
            // txtStockQty
            // 
            this.txtStockQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockQty.Location = new System.Drawing.Point(238, 210);
            this.txtStockQty.MaxLength = 10;
            this.txtStockQty.Name = "txtStockQty";
            this.txtStockQty.Size = new System.Drawing.Size(154, 31);
            this.txtStockQty.TabIndex = 6;
            this.txtStockQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtStockQty_KeyDown);
            this.txtStockQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtStockQty_KeyPress);
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnitPrice.Location = new System.Drawing.Point(238, 173);
            this.txtUnitPrice.MaxLength = 10;
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.Size = new System.Drawing.Size(154, 31);
            this.txtUnitPrice.TabIndex = 5;
            this.txtUnitPrice.TextChanged += new System.EventHandler(this.TxtUnitPrice_TextChanged);
            this.txtUnitPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtUnitPrice_KeyDown);
            this.txtUnitPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtUnitPrice_KeyPress);
            // 
            // txtBuyingPrice
            // 
            this.txtBuyingPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuyingPrice.Location = new System.Drawing.Point(238, 136);
            this.txtBuyingPrice.MaxLength = 10;
            this.txtBuyingPrice.Name = "txtBuyingPrice";
            this.txtBuyingPrice.Size = new System.Drawing.Size(154, 31);
            this.txtBuyingPrice.TabIndex = 4;
            this.txtBuyingPrice.TextChanged += new System.EventHandler(this.TxtBuyingPrice_TextChanged);
            this.txtBuyingPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBuyingPrice_KeyDown);
            this.txtBuyingPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBuyingPrice_KeyPress);
            // 
            // txtDescription
            // 
            this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(238, 99);
            this.txtDescription.MaxLength = 20;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(330, 31);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtDescription_KeyDown);
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDescription_KeyPress);
            // 
            // frmInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(1057, 676);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmInventory_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNewItem;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.Button btnEditItem;
        private System.Windows.Forms.Button btnExportToCSVAll;
        private System.Windows.Forms.Button btnPrintAllBarcodes;
        private System.Windows.Forms.Button btnExportToCSVNew;
        private System.Windows.Forms.Button btnPrintNewBarcodes;
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
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblMargin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBC2;
        private System.Windows.Forms.TextBox txtStockQty;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.TextBox txtBuyingPrice;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ComboBox cmbDepartments;
        private System.Windows.Forms.TextBox txtVendorID;
        private System.Windows.Forms.Button btnSave;
    }
}

