using POSCoreElements;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loyverse_bc_print
{
    public class SQLiteDataBaseManager
    {
        Dictionary<double, string, string> SotckItems;
        public SQLiteConnection DBCON;

        int ROW_NUMBER;

        DataTable ParkedBillData;
        int PARKED_BILL_NUMBER;

        public SQLiteDataBaseManager(string zDataSource, string zUID, string zPassword)
        {
            String dbConnection = String.Format("Data Source={0}", zDataSource);
            DBCON = new SQLiteConnection(dbConnection);
            DBCON.Open();

            ROW_NUMBER = 0;
            ParkedBillData = new DataTable();
            //InitializeParkedBillDataTable();
        }

        public SQLiteDataBaseManager(string zDataSource, string zDataBase, string zUID, string zPassword)
        {
            // Need to check the existance of DB and create if not available
            // This is for faster deployment of the application in different POS terminals
            if (File.Exists(zDataSource))
            {
                //MessageBox.Show(zDataSource);
                String dbConnection = String.Format("Data Source={0}", zDataSource);
                DBCON = new SQLiteConnection(dbConnection);
                DBCON.Open();
            }
            else
            {
                SQLiteConnection.CreateFile(zDataSource);
                String dbConnection = String.Format("Data Source={0}", zDataSource);
                DBCON = new SQLiteConnection(dbConnection);
                DBCON.Open();
            }

            SQLiteCommand CMD = DBCON.CreateCommand();
            CMD.CommandText = "CREATE TABLE IF NOT EXISTS stocks (" +
                              "ItemCode INTEGER PRIMARY KEY, " +
                              "Description TEXT NOT NULL, " +
                              "VendorID TEXT NOT NULL, " +
                              "CostPrice REAL NOT NULL, " +
                              "UnitPrice REAL NOT NULL, " +
                              "StockQuantity REAL NOT NULL, "+
                              "DepartmentID TEXT NOT NULL, "+
                              "BarcodeType INTEGER DEFAULT 0, "+
                              "LastUpdate TEXT NOT NULL, " +
                              "deleted INTEGER DEFAULT 0);";
            int iRowsUpdated = CMD.ExecuteNonQuery();

            ROW_NUMBER = 0;
            ParkedBillData = new DataTable();
            //InitializeParkedBillDataTable();
        }

        public void Unload()
        {
            DBCON.Close();
        }

        public void CompactDB()
        {
            try
            {
                SQLiteCommand CMD = DBCON.CreateCommand();
                CMD.CommandText = "vacuum;";
                int iRowsUpdated = CMD.ExecuteNonQuery();
                GlobalVariables.Logger.WriteToInfoLog(string.Format("Database Shirnk Successful: {0}", iRowsUpdated));
            }
            catch (Exception ex)
            {
                GlobalVariables.Logger.WriteToWarnLog(string.Format("Database Shirnk Error: {0}", ex.ToString()));
            }
        }

        private bool DataUpdate(string zQuery)
        {
            SQLiteCommand CMD = new SQLiteCommand(DBCON);
            CMD.CommandText = zQuery;
            GlobalVariables.Logger.WriteToInfoLog(string.Format("Data Update Query: {0}", zQuery));
            try
            {
                int iRowsUpdated = CMD.ExecuteNonQuery();
                GlobalVariables.Logger.WriteToInfoLog(string.Format("Date Update Successful: {0}", iRowsUpdated));
                return true;
            }
            catch (Exception ex)
            {
                GlobalVariables.Logger.WriteToWarnLog(string.Format("Date Update Error: {0}", ex.ToString()));
                return false;
            }
        }

        #region Stock Management - General
        public Dictionary<string, string> GetVendorList()
        {
            string zQuery = "SELECT DISTINCT(VendorID) from stocks ORDER BY VendorID";
            Dictionary<string, string> VendorList = new Dictionary<string, string>();

            try
            {
                GlobalVariables.Logger.WriteToInfoLog(string.Format("Loading Vendors: {0}", zQuery));

                SQLiteCommand CMD = new SQLiteCommand(DBCON);
                CMD.CommandText = zQuery;
                SQLiteDataReader Reader = CMD.ExecuteReader();
                int counter = 0;
                while (Reader.Read())
                {
                    GlobalVariables.Logger.WriteToInfoLog(string.Format("\tAdding vendors: {0}, {1}", Reader.GetValue(0), Reader.GetValue(1)));
                    VendorList.Add(String.Format("{0:00}", counter), Reader.GetValue(1).ToString());
                    counter++;
                }
                Reader.Close();
                return VendorList;
            }
            catch (Exception ex)
            {
                GlobalVariables.Logger.WriteToWarnLog(string.Format("Data Query Error: {0}", ex.ToString()));
            }
            return VendorList;
        }
        public int GetNextItemCode()
        {
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            int secondsSinceEpoch = (int)t.TotalSeconds;
            int iNextItemCode = Convert.ToInt32(((int)secondsSinceEpoch).ToString());
            // Create a Dictionary Code 
            /*
            Dictionary<string, int> yearCode = new Dictionary<string, int>();
            yearCode.Add("2016", 1);
            yearCode.Add("2017", 2);
            yearCode.Add("2018", 3);
            yearCode.Add("2019", 4);
            yearCode.Add("2020", 5);
            yearCode.Add("2021", 6);
            yearCode.Add("2022", 7);
            yearCode.Add("2023", 8);
            yearCode.Add("2024", 9);

            var year = DateTime.Parse(DateTime.Now.ToString()).Year;
            var now = DateTime.Now;
            string zDaysCode = yearCode[year.ToString()] + (now - new DateTime(year, 1, 1)).TotalDays.ToString("000");
            string zQuery = "select max(ItemCode) from stocks where ItemCode like '" + zDaysCode + "%' order by ItemCode";
            int iNextItemCode = (Convert.ToInt32(zDaysCode) * 1000) + 1;
            GlobalVariables.Logger.WriteToInfoLog(string.Format("System generated next barcode: {0}", iNextItemCode));
            int iLastItemCode = 0;
            try
            {
                SQLiteCommand CMD = new SQLiteCommand(DBCON);
                CMD.CommandText = zQuery;
                using (SQLiteDataReader Reader = CMD.ExecuteReader())
                {
                    if (Reader.HasRows == true)
                    {
                        while (Reader.Read())
                        {
                            iLastItemCode = Convert.ToInt32(Reader.GetValue(0));
                        }
                        iNextItemCode = iLastItemCode + 1;
                    }
                    else
                    {
                        iLastItemCode = iNextItemCode;
                        GlobalVariables.Logger.WriteToInfoLog(string.Format("Previous records not found for today"));
                    }
                }
                GlobalVariables.Logger.WriteToInfoLog(string.Format("Get Next Item Code: {0}, Query: {1}", iLastItemCode + 1, zQuery));
            }
            catch (Exception ex)
            {
                GlobalVariables.Logger.WriteToInfoLog(string.Format("Data Query Error: {0} therefore resetting to system generated barcode. Error: {1}", zQuery, ex));
            }

            if (iNextItemCode.ToString().Length != 7 && iLastItemCode != 0)
            {
                GlobalVariables.Logger.WriteToErrorLog(string.Format("Unable to generate stock number for date {0} counter {1}", zDaysCode, iNextItemCode), "");
            }
            */
            GlobalVariables.Logger.WriteToInfoLog(string.Format("GetNextItemCode:: {0}", iNextItemCode));
            return iNextItemCode;
        }

        #endregion

        #region Stock Management - DB Handle
        public bool SMLoadStockTable(ref DataTable Stocks)
        {
            string zQuery = "select ItemCode, DepartmentID, Description, CostPrice, UnitPrice, StockQuantity, VendorID, " +
                "BarcodeType, LastUpdate from stocks where deleted != '1' order by LastUpdate, DepartmentID, ItemCode";

            try
            {
                SQLiteCommand CMD = new SQLiteCommand(DBCON);
                CMD.CommandText = zQuery;
                SQLiteDataReader Reader = CMD.ExecuteReader();

                while (Reader.Read())
                {
                    // Compose Barcode
                    string zBarCode = Reader.GetValue(1).ToString() + String.Format("{0:0000}", Reader.GetValue(0));
                    if (Reader.GetValue(7).ToString() == "0")
                        zBarCode = Reader.GetValue(0).ToString();
                    Stocks.Rows.Add(zBarCode, Reader.GetValue(2).ToString(), String.Format("{0:0.00}", Reader.GetValue(3)),
                                    String.Format("{0:0.00}", Reader.GetValue(4)), Reader.GetValue(5).ToString(),
                                    Reader.GetValue(1).ToString(), Reader.GetValue(6).ToString(), Reader.GetValue(7).ToString(), Reader.GetValue(8).ToString());
                }
                Reader.Close();
                return true;
            }
            catch (Exception ex)
            {
                GlobalVariables.Logger.WriteToWarnLog(string.Format("Data Query {0}\nError: {1}", zQuery, ex.ToString()));
            }
            return false;
        }

        public bool SMLoadStockTableLatest(ref DataTable Stocks)
        {
            DateTime dateForQuery = DateTime.Now.AddDays(-1);
            string formattedDate = dateForQuery.ToString("yyyy-MM-dd");
            GlobalVariables.Logger.WriteToInfoLog(string.Format("Date format for query: {0}, [{1}]", formattedDate, dateForQuery));
           
            string zQuery = string.Format("select ItemCode, DepartmentID, Description, CostPrice, UnitPrice, StockQuantity, VendorID, " +
                "BarcodeType, LastUpdate from stocks where deleted != '1' and date(LastUpdate) >= '{0}' order by LastUpdate, DepartmentID, ItemCode", formattedDate);
            GlobalVariables.Logger.WriteToInfoLog(string.Format("select query: {0}", zQuery));

            try
            {
                SQLiteCommand CMD = new SQLiteCommand(DBCON);
                CMD.CommandText = zQuery;
                SQLiteDataReader Reader = CMD.ExecuteReader();

                while (Reader.Read())
                {
                    // Compose Barcode
                    string zBarCode = Reader.GetValue(1).ToString() + String.Format("{0:0000}", Reader.GetValue(0));
                    if (Reader.GetValue(7).ToString() == "0")
                        zBarCode = Reader.GetValue(0).ToString();
                    Stocks.Rows.Add(zBarCode, Reader.GetValue(2).ToString(), String.Format("{0:0.00}", Reader.GetValue(3)),
                                    String.Format("{0:0.00}", Reader.GetValue(4)), Reader.GetValue(5).ToString(),
                                    Reader.GetValue(1).ToString(), Reader.GetValue(6).ToString(), Reader.GetValue(7).ToString(), Reader.GetValue(8).ToString());
                }
                Reader.Close();
                return true;
            }
            catch (Exception ex)
            {
                GlobalVariables.Logger.WriteToWarnLog(string.Format("Data Query {0}\nError: {1}", zQuery, ex.ToString()));
            }
            return false;
        }

        public bool AddNewStockItem(ref DataTable Stocks, string iItemCode, string zDescription, string zVendorID,
            double dCostPrice, double dUnitPrice, double dStockQuantity, string iDepartmentID, int iBarcodeType, string zDeptName)
        {
            string zDateTime = DateTime.Now.ToString("yyyy-MM-dd ") + DateTime.Now.ToString("HH:mm:ss");
            string zSQL = String.Format("insert into stocks(ItemCode, Description, VendorID, CostPrice, UnitPrice, StockQuantity, DepartmentID, BarcodeType, LastUpdate, deleted) " +
                                    "values({0},@zDescription,@zVendorID,'{3}','{4}','{5}',@iDepartmentID,{7}, CURRENT_TIMESTAMP, 0)", iItemCode, zDescription, zVendorID, dCostPrice, dUnitPrice, dStockQuantity,
                                    iDepartmentID, iBarcodeType);
            try
            {
                SQLiteCommand CMD = new SQLiteCommand(DBCON);
                CMD.CommandText = zSQL;
                CMD.Parameters.Add(new SQLiteParameter("@zDescription", zDescription));
                CMD.Parameters.Add(new SQLiteParameter("@zVendorID", zVendorID));
                CMD.Parameters.Add(new SQLiteParameter("@iDepartmentID", iDepartmentID));
                GlobalVariables.Logger.WriteToInfoLog(string.Format("Data insert Query: {0}", zSQL));
                try
                {
                    int iRowsUpdated = CMD.ExecuteNonQuery();
                    GlobalVariables.Logger.WriteToInfoLog(string.Format("Date Update Successful: {0}", iRowsUpdated));
                    string zBarCode = String.Format("{0:00}", iDepartmentID) + String.Format("{0:0000}", iItemCode);
                    if (iBarcodeType == 0)
                        zBarCode = iItemCode.ToString();
                    Stocks.Rows.Add(zBarCode, zDescription, dCostPrice, dUnitPrice, dStockQuantity, iDepartmentID, zVendorID, iBarcodeType, zDateTime);
                    return true;
                }
                catch (Exception ex)
                {
                    GlobalVariables.Logger.WriteToWarnLog(string.Format("Date Update Error: {0}", ex.ToString()));
                    return false;
                }
            }
            catch (Exception ex)
            {
                GlobalVariables.Logger.WriteToWarnLog(string.Format("Data Query {0}\nError: {1}", zSQL, ex.ToString()));
            }

            return false;
        }

        public bool UpdateStockItem(ref DataTable Stocks, string iItemCode, string zDescription, string zVendorID,
            double dCostPrice, double dUnitPrice, double dStockQuantity, string iDepartmentID, int iBarcodeType, string zDeptName)
        {
            string zDateTime = DateTime.Now.ToString("yyyy-MM-dd ") + DateTime.Now.ToString("HH:mm:ss");
            string zSQL = String.Format("update stocks set StockQuantity = '{0}', LastUpdate = '{1}' where ItemCode = '{2}'",
                dStockQuantity, zDateTime, iItemCode);
            
            try
            {
                SQLiteCommand CMD = new SQLiteCommand(DBCON);
                CMD.CommandText = zSQL;     
                GlobalVariables.Logger.WriteToInfoLog(string.Format("Data Update Query: {0}", zSQL));
                int iRowsUpdated = CMD.ExecuteNonQuery();
                GlobalVariables.Logger.WriteToInfoLog(string.Format("Date Update Successful: {0}", iRowsUpdated));
                string zBarCode = String.Format("{0:00}", iDepartmentID) + String.Format("{0:0000}", iItemCode);
                if (iBarcodeType == 0)
                    zBarCode = iItemCode.ToString();
                DataRow[] StockRow = Stocks.Select("Barcode = '" + zBarCode + "'");
                StockRow[0]["Description"] = zDescription;
                StockRow[0]["CostPrice"] = dCostPrice;
                StockRow[0]["UnitPrice"] = dUnitPrice;
                StockRow[0]["StockQuantity"] = dStockQuantity;
                StockRow[0]["VendorID"] = zVendorID;
                StockRow[0]["BCType"] = iBarcodeType;
                StockRow[0]["LastUpdate"] = zDateTime;
                return true;
            }
            catch (Exception ex)
            {
                GlobalVariables.Logger.WriteToWarnLog(string.Format("Data Query {0}\nError: {1}", zSQL, ex.ToString()));
                return false;
            }
            
            return false;
        }

        public bool SetStockToDeleted(string zBarCode, ref DataTable Stocks)
        {
            string zSQL = String.Format("update stocks set deleted = '1' where ItemCode = '{0}'", zBarCode);
            if (DataUpdate(zSQL))
            {
                try
                {
                    DataRow[] StockRow = Stocks.Select("Barcode = '" + zBarCode + "'");
                    StockRow[0].Delete();
                    return true;
                }
                catch (Exception ex)
                {
                    GlobalVariables.Logger.WriteToWarnLog(string.Format("Data Query {0}\nError: {1}", zSQL, ex.ToString()));
                    return false;
                }
            }
            return false;
        }




        #endregion
    }
}
