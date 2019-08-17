using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loyverse_bc_print
{
    public partial class frmLabelPrint : Form
    {
        DataTable _stockTable;
        public frmLabelPrint(bool isLatestRequired)
        {
            InitializeComponent();
            StockTableInit();
            if (isLatestRequired)
            {
                GlobalVariables.SqliteDB.SMLoadStockTableLatest(ref _stockTable);
            }
            else
            {
                GlobalVariables.SqliteDB.SMLoadStockTable(ref _stockTable);
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

        private bool ReDrawListView()
        {
            try
            {
                lvStocks.Items.Clear();
                DataRow[] stockRow = _stockTable.Select("", "LastUpdate DESC");
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
                return true;
            }
            catch (Exception ex)
            {
                GlobalVariables.Logger.WriteToWarnLog("Unable to show the List View", ex.ToString());
                return false;
            }
        }

        private void PrintSelectedRows(string templateName)
        {
            ListView.CheckedListViewItemCollection itemsToPrint = lvStocks.CheckedItems;
            int iBlock = 1;
            foreach (ListViewItem item in itemsToPrint)
            {
                TSCBarcode bc = new TSCBarcode(GlobalVariables.Ini.IniReadValue(templateName, "GLOBAL_Size_Width"), GlobalVariables.Ini.IniReadValue(templateName, "GLOBAL_Size_Height"),
                GlobalVariables.Ini.IniReadValue(templateName, "GLOBAL_Ref_XCord"), GlobalVariables.Ini.IniReadValue(templateName, "GLOBAL_Ref_YCord"),
                GlobalVariables.Ini.IniReadValue(templateName, "GLOBAL_Shop_Name"), GlobalVariables.Ini.IniReadValue(templateName, "GLOBAL_next_label"),
                GlobalVariables.Ini.IniReadValue(templateName, "GLOBAL_Labels_Per_Line"));
                bc.SetBcPrinter(GlobalVariables.Ini.IniReadValue(templateName, "GLOBAL_printer"), GlobalVariables.Ini.IniReadValue(templateName, "GLOBAL_print_speed"),
                    GlobalVariables.Ini.IniReadValue(templateName, "GLABAL_print_density"), GlobalVariables.Ini.IniReadValue(templateName, "GLOBAL_print_sensor"),
                    GlobalVariables.Ini.IniReadValue(templateName, "GLOBAL_print_vgap"));

                string zBarCode = item.SubItems[0].Text;
                string zDescription = item.SubItems[1].Text;
                string zPrice = GlobalVariables.Ini.IniReadValue(templateName, "GLOBAL_Currency") + " " + item.SubItems[3].Text;

                // TODO: this will print additional label to fit the rest of the line.
                int labelsPerLine = Convert.ToInt16(GlobalVariables.Ini.IniReadValue(templateName, "GLOBAL_Labels_Per_Line"));
                double dQuantity = Math.Round(Convert.ToDouble(item.SubItems[4].Text));
                double quantity = Math.Ceiling(dQuantity / labelsPerLine);
                GlobalVariables.Logger.WriteToInfoLog(string.Format("Label count: Labels Per Line={0}, Qty={1}, Lines={2}",
                                                      labelsPerLine, dQuantity, quantity));


                string zDepartment = item.SubItems[5].Text;
                string zVendor = item.SubItems[6].Text;
                if (GlobalVariables.Ini.IniReadValue(templateName, "PRODUCT_NAME_enable") == "YES")
                {
                    bc.PrintText(GlobalVariables.Ini.IniReadValue(templateName, "PRODUCT_NAME_x_pos"), GlobalVariables.Ini.IniReadValue(templateName, "PRODUCT_NAME_y_pos"),
                        GlobalVariables.Ini.IniReadValue(templateName, "PRODUCT_NAME_font_size"), GlobalVariables.Ini.IniReadValue(templateName, "PRODUCT_NAME_rotation"),
                        GlobalVariables.Ini.IniReadValue(templateName, "PRODUCT_NAME_font_style"), GlobalVariables.Ini.IniReadValue(templateName, "PRODUCT_NAME_font_underline"),
                        GlobalVariables.Ini.IniReadValue(templateName, "PRODUCT_NAME_font"), zDescription);
                }

                if (GlobalVariables.Ini.IniReadValue(templateName, "BARCODE_enable") == "YES")
                {
                    //TSCLIB_DLL.barcode(zXPos, zYPos, "128", "32", "1", "0", "2", "2", "1234567E");
                    bc.PrintBarcode(GlobalVariables.Ini.IniReadValue(templateName, "BARCODE_x_pos"), GlobalVariables.Ini.IniReadValue(templateName, "BARCODE_y_pos"),
                        GlobalVariables.Ini.IniReadValue(templateName, "BARCODE_font"), GlobalVariables.Ini.IniReadValue(templateName, "BARCODE_height"),
                        GlobalVariables.Ini.IniReadValue(templateName, "BARCODE_print_text"), GlobalVariables.Ini.IniReadValue(templateName, "BARCODE_rotation"),
                        GlobalVariables.Ini.IniReadValue(templateName, "BARCODE_nb1"), GlobalVariables.Ini.IniReadValue(templateName, "BARCODE_nb2"),
                        zBarCode);
                }
                if (GlobalVariables.Ini.IniReadValue(templateName, "BATCH_ID_enable") == "YES")
                {
                    bc.PrintText(GlobalVariables.Ini.IniReadValue(templateName, "BATCH_ID_x_pos"), GlobalVariables.Ini.IniReadValue(templateName, "BATCH_ID_y_pos"),
                        GlobalVariables.Ini.IniReadValue(templateName, "BATCH_ID_font_size"), GlobalVariables.Ini.IniReadValue(templateName, "BATCH_ID_rotation"),
                        GlobalVariables.Ini.IniReadValue(templateName, "BATCH_ID_font_style"), GlobalVariables.Ini.IniReadValue(templateName, "BATCH_ID_font_underline"),
                        GlobalVariables.Ini.IniReadValue(templateName, "BATCH_ID_font"), iBlock.ToString());
                }
                if (GlobalVariables.Ini.IniReadValue(templateName, "DATE_ID_enable") == "YES")
                {
                    string zDateID = "";
                    var now = DateTime.Now.DayOfYear;
                    var year = DateTime.Parse(DateTime.Now.ToString()).Year;
                    zDateID = now.ToString() + year.ToString();
                    bc.PrintText(GlobalVariables.Ini.IniReadValue(templateName, "DATE_ID_x_pos"), GlobalVariables.Ini.IniReadValue(templateName, "DATE_ID_y_pos"),
                        GlobalVariables.Ini.IniReadValue(templateName, "DATE_ID_font_size"), GlobalVariables.Ini.IniReadValue(templateName, "DATE_ID_rotation"),
                        GlobalVariables.Ini.IniReadValue(templateName, "DATE_ID_font_style"), GlobalVariables.Ini.IniReadValue(templateName, "DATE_ID_font_underline"),
                        GlobalVariables.Ini.IniReadValue(templateName, "DATE_ID_font"), zDateID);
                }
                if (GlobalVariables.Ini.IniReadValue(templateName, "DEPARTMENT_ID_enable") == "YES")
                {
                    bc.PrintText(GlobalVariables.Ini.IniReadValue(templateName, "DEPARTMENT_ID_x_pos"), GlobalVariables.Ini.IniReadValue(templateName, "DEPARTMENT_ID_y_pos"),
                        GlobalVariables.Ini.IniReadValue(templateName, "DEPARTMENT_ID_font_size"), GlobalVariables.Ini.IniReadValue(templateName, "DEPARTMENT_ID_rotation"),
                        GlobalVariables.Ini.IniReadValue(templateName, "DEPARTMENT_ID_font_style"), GlobalVariables.Ini.IniReadValue(templateName, "DEPARTMENT_ID_font_underline"),
                        GlobalVariables.Ini.IniReadValue(templateName, "DEPARTMENT_ID_font"), zDepartment);
                }
                if (GlobalVariables.Ini.IniReadValue(templateName, "PRICE_enable") == "YES")
                {
                    bc.PrintText(GlobalVariables.Ini.IniReadValue(templateName, "PRICE_x_pos"), GlobalVariables.Ini.IniReadValue(templateName, "PRICE_y_pos"),
                        GlobalVariables.Ini.IniReadValue(templateName, "PRICE_font_size"), GlobalVariables.Ini.IniReadValue(templateName, "PRICE_rotation"),
                        GlobalVariables.Ini.IniReadValue(templateName, "PRICE_font_style"), GlobalVariables.Ini.IniReadValue(templateName, "PRICE_font_underline"),
                        GlobalVariables.Ini.IniReadValue(templateName, "PRICE_font"), zPrice);
                }
                if (GlobalVariables.Ini.IniReadValue(templateName, "PRICE_SEPARATOR_enable") == "YES")
                {
                    //
                }
                if (GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_enable") == "YES")
                {
                    bc.PrintText(GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_x_pos"), GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_y_pos"),
                        GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_font_size"), GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_rotation"),
                        GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_font_style"), GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_font_underline"),
                        GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_font"), GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_text"));
                }
                if (GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_2_enable") == "YES")
                {


                    bc.PrintText(GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_2_x_pos"), GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_2_y_pos"),
                        GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_2_font_size"), GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_2_rotation"),
                        GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_2_font_style"), GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_2_font_underline"),
                        GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_2_font"), GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_2_text"));
                }
                if (GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_3_enable") == "YES")
                {
                    bc.PrintText(GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_3_x_pos"), GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_3_y_pos"),
                        GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_3_font_size"), GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_3_rotation"),
                        GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_3_font_style"), GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_3_font_underline"),
                        GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_3_font"), GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_3_text"));
                }
                if (GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_4_enable") == "YES")
                {
                    bc.PrintText(GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_4_x_pos"), GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_4_y_pos"),
                        GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_4_font_size"), GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_4_rotation"),
                        GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_4_font_style"), GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_4_font_underline"),
                        GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_4_font"), GlobalVariables.Ini.IniReadValue(templateName, "SHOP_NAME_4_text"));
                }
                if (GlobalVariables.Ini.IniReadValue(templateName, "VENDOR_ID_enable") == "YES")
                {
                    bc.PrintText(GlobalVariables.Ini.IniReadValue(templateName, "VENDOR_ID_x_pos"), GlobalVariables.Ini.IniReadValue(templateName, "VENDOR_ID_y_pos"),
                        GlobalVariables.Ini.IniReadValue(templateName, "VENDOR_ID_font_size"), GlobalVariables.Ini.IniReadValue(templateName, "VENDOR_ID_rotation"),
                        GlobalVariables.Ini.IniReadValue(templateName, "VENDOR_ID_font_style"), GlobalVariables.Ini.IniReadValue(templateName, "VENDOR_ID_font_underline"),
                        GlobalVariables.Ini.IniReadValue(templateName, "VENDOR_ID_font"), zVendor);
                }

                bc.SendToPrint(quantity);
                iBlock++;
            }
        }

        private void FrmLabelPrint_Load(object sender, EventArgs e)
        {
            ReDrawListView();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnBCType1Print_Click(object sender, EventArgs e)
        {
            PrintSelectedRows("barcode1");
        }

        private void BtnBCType2Print_Click(object sender, EventArgs e)
        {
            PrintSelectedRows("barcode2");
        }
    }
}
