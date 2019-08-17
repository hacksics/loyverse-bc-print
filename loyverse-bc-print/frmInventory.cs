using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loyverse_bc_print
{
    public partial class frmInventory : Form
    {
        DataTable _stockTable;
        string _stockMode = "NEW";

        public frmInventory()
        {
            InitializeComponent();
        }

        private void EnableTextFields()
        {
            txtBuyingPrice.Enabled = true;
            txtUnitPrice.Enabled = true;
            txtDescription.Enabled = true;
            txtStockQty.Enabled = true;
            txtVendorID.Enabled = true;
            txtBC2.Enabled = true;
            cmbDepartments.Enabled = true;
        }
        private void DisableTextFields()
        {
            txtBuyingPrice.Enabled = false;
            txtUnitPrice.Enabled = false;
            txtDescription.Enabled = false;
            txtVendorID.Enabled = false;
            txtBC2.Enabled = false;
            cmbDepartments.Enabled = false;
        }

        private void InitAddNewStock()
        {
            try
            {
                _stockMode = "INSERT";
                btnSave.Text = "Insert";
                btnSave.Enabled = true;
                EnableTextFields();
                cmbDepartments.SelectedIndex = 0;
                cmbDepartments.Focus();
                txtDescription.Text = "";
                txtBuyingPrice.Text = "0.00";
                txtUnitPrice.Text = "0.00";
                txtStockQty.Text = "0";
                AutoFillBc2();
            }
            catch (Exception ex)
            {
                GlobalVariables.Logger.WriteToWarnLog("Error in initializing New Stock add", ex.ToString());
            }
        }

        private void SaveStock()
        {

            try
            {
                string zDepartmentId = cmbDepartments.Text;
                string zVendorId = txtVendorID.Text;
                string zDescription = txtDescription.Text;
                double dCostPrice = Convert.ToDouble(txtBuyingPrice.Text);
                double dUnitPrice = Convert.ToDouble(txtUnitPrice.Text);
                double dStockQuantity = Convert.ToDouble(txtStockQty.Text);

                if (zDescription == "")
                {
                    txtDescription.Focus();
                    return;
                }
                if (dCostPrice == 0)
                {
                    txtBuyingPrice.Focus();
                    return;
                }
                if (dUnitPrice == 0)
                {
                    txtUnitPrice.Focus();
                    return;
                }
                if (dStockQuantity == 0)
                {
                    txtStockQty.Focus();
                    return;
                }
                //int iItemCode = Convert.ToInt32(txtBC2.Text);
                //int iDeptID = Convert.ToInt16(txtBC1.Text);
                string iItemCode = txtBC2.Text;
                if (_stockMode == "INSERT")
                {
                    AutoFillBc2();
                    txtBC2.Text = string.Format("{0:0000}", txtBC2.Text);
                    if (GlobalVariables.SqliteDB.AddNewStockItem(ref _stockTable, iItemCode, zDescription, zVendorId, dCostPrice,
                        dUnitPrice, dStockQuantity, zDepartmentId, 0, zDepartmentId))
                    {
                        ReDrawListView("");
                        AutoFillBc2();
                    }
                    else
                    {
                        GlobalVariables.Logger.WriteToWarnLog("Unable to add item to stock. Check the log file for more info","Error ocurred!");
                    }
                }
                else if (_stockMode == "UPDATE")
                {
                    if (GlobalVariables.SqliteDB.UpdateStockItem(ref _stockTable, iItemCode, zDescription, zVendorId, dCostPrice,
                        dUnitPrice, dStockQuantity, zDepartmentId, 0, zDepartmentId))
                    {
                        ReDrawListView("");
                    }
                    else
                    {
                        GlobalVariables.Logger.WriteToWarnLog("Unable to update stock. Check the log file for more info", "Error ocurred!");
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalVariables.Logger.WriteToWarnLog("Data Entry Error!" + ex);
                return;
            }
            InitAddNewStock();
        }

        private void InitUpdateStock()
        {
            _stockMode = "UPDATE";
            btnSave.Text = "Update";
            DisableTextFields();
            AutoFillDataControls();
        }

        private void DeleteStockItem()
        {
            string zBarCode = GetBarCode();
            if (zBarCode != "-1")
            {
                bool bOutPut;
                bOutPut = GlobalVariables.SqliteDB.SetStockToDeleted(zBarCode, ref _stockTable);

                if (bOutPut)
                {
                    ReDrawListView("");
                    InitAddNewStock();
                }
                else
                {
                    GlobalVariables.Logger.WriteToWarnLog("Unable to update stock. Check the log file for more info", "Error ocurred!");
                }
            }
            else
            {
                MessageBox.Show("Invalid Barcode!");
            }
        }

        private void AutoFillDataControls()
        {
            // fill the data controls based on listview item
            // if grid view is not selected, select the first item StockTable datatable
            string zBarCode = GetBarCode();
            if (zBarCode != "-1")
            {
                txtDescription.Text = lvStocks.SelectedItems[0].SubItems[1].Text;
                txtBuyingPrice.Text = lvStocks.SelectedItems[0].SubItems[2].Text;
                txtUnitPrice.Text = lvStocks.SelectedItems[0].SubItems[3].Text;
                txtStockQty.Text = lvStocks.SelectedItems[0].SubItems[4].Text;
                txtVendorID.Text = lvStocks.SelectedItems[0].SubItems[6].Text;
                cmbDepartments.SelectedItem = lvStocks.SelectedItems[0].SubItems[5].Text;
                txtBC2.Text = zBarCode;
            }

        }

        private string GetBarCode()
        {
            try
            {
                return lvStocks.SelectedItems[0].SubItems[0].Text;
            }
            catch (Exception ex)
            {
                GlobalVariables.Logger.WriteToWarnLog("Unable to get Barcode", ex.ToString());
                return "-1";
            }
        }

        private void AutoFillBc2()
        {
            int iBc2 = GlobalVariables.SqliteDB.GetNextItemCode();
            txtBC2.Text = string.Format("{0:0000}", iBc2);
        }

        private void ReDrawListView(string zFilterExpression)
        {
            try
            {
                GlobalVariables.Logger.WriteToInfoLog("List view redraw started!");
                lvStocks.Items.Clear();
                DataRow[] stockRow = _stockTable.Select(zFilterExpression, "Barcode DESC");
                //DataRow[] StockRow = StockTable.Select(zFilterExpression);
                lvStocks.BeginUpdate();
                for (int i = 0; i < stockRow.Length; i++)
                {
                    string zBarCode = string.Format("{0:000000}", stockRow[i]["Barcode"]);
                    ListViewItem lvItem = new ListViewItem(zBarCode, 0);
                    lvItem.SubItems.Add(stockRow[i]["Description"].ToString());
                    lvItem.SubItems.Add(string.Format("{0:0.00}", stockRow[i]["CostPrice"]));
                    lvItem.SubItems.Add(string.Format("{0:0.00}", stockRow[i]["UnitPrice"]));
                    lvItem.SubItems.Add(string.Format("{0:0.##}", stockRow[i]["StockQuantity"]));
                    lvItem.SubItems.Add(stockRow[i]["DepartmentID"].ToString());
                    lvItem.SubItems.Add(stockRow[i]["VendorID"].ToString());
                    lvItem.SubItems.Add(stockRow[i]["BCType"].ToString());

                    lvStocks.Items.AddRange(new[] { lvItem });
                }
                lvStocks.EndUpdate();
                GlobalVariables.Logger.WriteToInfoLog("List view redraw completed!");
            }
            catch (Exception ex)
            {
                GlobalVariables.Logger.WriteToWarnLog("Unable to show the List View", ex.ToString());
            }
        }

        private void StockTableInit()
        {
            _stockTable = new DataTable();
            _stockTable.Columns.Add("Barcode", typeof(int));
            _stockTable.Columns.Add("Description", typeof(string));
            _stockTable.Columns.Add("CostPrice", typeof(double));
            _stockTable.Columns.Add("UnitPrice", typeof(double));
            _stockTable.Columns.Add("StockQuantity", typeof(double));
            _stockTable.Columns.Add("DepartmentID", typeof(string));
            _stockTable.Columns.Add("VendorID", typeof(string));
            _stockTable.Columns.Add("BCType", typeof(int));
            _stockTable.Columns.Add("LastUpdate", typeof(string));
        }

        private void BtnNewItem_Click(object sender, EventArgs e)
        {
            InitAddNewStock();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveStock();
        }

        private void FrmInventory_Load(object sender, EventArgs e)
        {
            StockTableInit();
            GlobalVariables.SqliteDB.SMLoadStockTable(ref _stockTable);
            ReDrawListView("");
        }

        private void BtnEditItem_Click(object sender, EventArgs e)
        {
            InitUpdateStock();
        }

        private void BtnDeleteItem_Click(object sender, EventArgs e)
        {
            DeleteStockItem();
        }

        private void WriteStockFile(bool filetype)
        {
            string filename = string.Format("{0}-full-stocks.csv", DateTime.Now.ToString("yyyy-MM-dd"));
            List<string> stockList;
            if (filetype)
            {
                filename = string.Format("{0}-latest-stocks.csv", DateTime.Now.ToString("yyyy-MM-dd"));
                stockList = GenerateNewStocksFile();
            }
            else
            {
                stockList = GenerateStockFile();
            }           
            string[] stockArray = stockList.ToArray();
            int iRecordCout = stockList.Count;
            string zStockFile = GlobalVariables.ConfigPath  + filename;

            try
            {

                File.WriteAllLines(zStockFile, stockArray);
                GlobalVariables.Logger.WriteToInfoLog("File StockList.csv is generated in " + GlobalVariables.ConfigPath + "\nNumber of Records:" + iRecordCout);
                S3FileUploader s3FileUploaderObj = new S3FileUploader(GlobalVariables.Ini.IniReadValue("aws", "BucketName"),
                    GlobalVariables.Ini.IniReadValue("aws", "awsAccessKeyId"), GlobalVariables.Ini.IniReadValue("aws", "awsSecretAccessKey"));
                s3FileUploaderObj.UploadFile(filename, zStockFile);
                MessageBox.Show(@"Stocks file generated compled in "+ zStockFile, @"Operation Compled! Records: "+ iRecordCout.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                GlobalVariables.Logger.WriteToWarnLog("Unable to write the stock file in to: " + GlobalVariables.ConfigPath, ex.ToString());
            }
        }

        private List<string> GenerateStockFile()
        {
            List<string> stockList = new List<string>();
            foreach (DataRow row in _stockTable.Rows)
            {
                string zStockLine = string.Format("{0},{1},{2},{3},{4},{5},{6}", row["Barcode"], row["Description"],
                    row["UnitPrice"], row["StockQuantity"], row["VendorID"], row["DepartmentID"], row["BCType"]);
                stockList.Add(zStockLine);
            }
            return stockList;
        }

        private List<string> GenerateNewStocksFile()
        {
            DataTable newStockTable = TempStockTableInit();
            GlobalVariables.SqliteDB.SMLoadStockTableLatest(ref newStockTable);
            List<string> stockList = new List<string>();
            string csvHeader = string.Format("Handle,SKU,Name,Category,Sold by weight,Option 1 name,Option 1 value,Option 2 name, " +
                                             "Option 2 value,Option 3 name, Option 3 value, Cost, Barcode, SKU of included item, " +
                                             "Quantity of included item, Track stock, Available for sale [{0}], Price [{0}], In stock [{0}], Low stock [{0}]",
                                             GlobalVariables.ShopName);
            //string csvHeader = string.Format("SKU, Name, Category, Cost, Barcode, Track stock, Available for sale [{0}], Price [{0}], In stock [{0}], Low stock [{0}]", GlobalVariables.ShopName);

            stockList.Add(csvHeader);
            foreach (DataRow row in newStockTable.Rows)
            {
                //string formattedLine = string.Format("{0},{1},{2},{3},{0},Y,Y,{4},{5},0", row["Barcode"], row["Description"], row["DepartmentID"], row["CostPrice"], row["UnitPrice"], row["StockQuantity"]);
                string formattedLine = string.Format(",{0},{1},{2},,,,,,,,{3},{0},,,Y,Y,{4},{5},0", row["Barcode"], row["Description"], row["DepartmentID"], 
                                                     row["CostPrice"], row["UnitPrice"], row["StockQuantity"]);
                //string zStockLine = string.Format("{0},{1},{2},{3},{4},{5},{6}", row["Barcode"], row["Description"],
                //     row["UnitPrice"], row["StockQuantity"], row["VendorID"], row["DepartmentID"], row["BCType"]);
                stockList.Add(formattedLine);
            }
            return stockList;
        }

        private DataTable TempStockTableInit()
        {
            _stockTable = new DataTable();
            _stockTable.Columns.Add("Barcode", typeof(int));
            _stockTable.Columns.Add("Description", typeof(string));
            _stockTable.Columns.Add("CostPrice", typeof(double));
            _stockTable.Columns.Add("UnitPrice", typeof(double));
            _stockTable.Columns.Add("StockQuantity", typeof(double));
            _stockTable.Columns.Add("DepartmentID", typeof(string));
            _stockTable.Columns.Add("VendorID", typeof(string));
            _stockTable.Columns.Add("BCType", typeof(int));
            _stockTable.Columns.Add("LastUpdate", typeof(string));
            return _stockTable;
        }

        private void AutoCalculateUnitPrice()
        {
            try
            {
                double dCostPrice = Convert.ToDouble(txtBuyingPrice.Text);
                double dUnitPrice = dCostPrice * ((Convert.ToDouble(GlobalVariables.Ini.IniReadValue("stocks", "profit_margin")) + 100) / 100);
                dUnitPrice = Math.Round(dUnitPrice / 5.0) * 5;
                txtUnitPrice.Text = string.Format("{0:0.00}", dUnitPrice);
            }
            catch (Exception ex)
            {
                GlobalVariables.Logger.WriteToWarnLog("Unable to auto calculate Unit Price", ex.ToString());
            }
        }

        #region keypress events
        private void CmbDepartments_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && cmbDepartments.Text != "")
            {
                txtVendorID.Focus();
            }
        }
        private void TxtVendorID_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtVendorID.Text != "")
            {
                txtDescription.Focus();
            }
        }

        private void TxtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtDescription.Text != "")
            {
                txtBuyingPrice.Focus();
            }
        }

        private void TxtBuyingPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtBuyingPrice.Text != "")
            {
                txtUnitPrice.Focus();
            }
        }

        private void TxtUnitPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtUnitPrice.Text != "")
            {
                txtStockQty.Focus();
            }
        }

        private void TxtStockQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (cmbDepartments.Text == "")
            {
                MessageBox.Show(@"Fields Cannot be Empty!", @"ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbDepartments.Focus();
            }
            else if (txtVendorID.Text == "")
            {
                MessageBox.Show(@"Fields Cannot be Empty!", @"ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVendorID.Focus();
            }
            else if (txtDescription.Text == "")
            {
                MessageBox.Show(@"Fields Cannot be Empty!", @"ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDescription.Focus();
            }
            else if (txtBuyingPrice.Text == "")
            {
                MessageBox.Show(@"Fields Cannot be Empty!", @"ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBuyingPrice.Focus();
            }
            else if (txtUnitPrice.Text == "")
            {
                MessageBox.Show(@"Fields Cannot be Empty!", @"ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUnitPrice.Focus();
            }
            else if (txtStockQty.Text == "")
            {
                MessageBox.Show(@"Fields Cannot be Empty!", @"ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStockQty.Focus();
            }

            if (btnSave.Enabled && e.KeyCode == Keys.Enter)
            {
                SaveStock();
            }
        }

        private void TxtBuyingPrice_TextChanged(object sender, EventArgs e)
        {
            AutoCalculateUnitPrice();
        }

        private void TxtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double dCostPrice = Convert.ToDouble(txtBuyingPrice.Text);
                double dUnitPrice = Convert.ToDouble(txtUnitPrice.Text);
                double dMargin = ((dUnitPrice - dCostPrice) / dCostPrice) * 100;
                lblMargin.Text = string.Format("{0:0.##}", dMargin) + "%";
            }
            catch (Exception)
            {
                return;
            }
        }

        private void TxtBuyingPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void TxtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void TxtStockQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void TxtBC2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
               && !char.IsDigit(e.KeyChar)
               && !char.IsLetter(e.KeyChar)
               && !char.IsWhiteSpace(e.KeyChar)
               && e.KeyChar != '.' && e.KeyChar != '+' && e.KeyChar != '-'
               && e.KeyChar != '(' && e.KeyChar != ')' && e.KeyChar != '*'
               && e.KeyChar != '/')
            {
                e.Handled = true;
                return;
            }
            e.Handled = false;
        }

        #endregion

        private void BtnPrintNewBarcodes_Click(object sender, EventArgs e)
        {
            PrintLabels(true);
        }

        private void PrintLabels(bool buttonType)
        {
            frmLabelPrint lp = new frmLabelPrint(buttonType);
            lp.ShowDialog();
        }

        private void BtnPrintAllBarcodes_Click(object sender, EventArgs e)
        {
            PrintLabels(false);
        }

        private void BtnExportToCSVNew_Click(object sender, EventArgs e)
        {
            WriteStockFile(true);
        }

        private void BtnExportToCSVAll_Click(object sender, EventArgs e)
        {
            WriteStockFile(false);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
