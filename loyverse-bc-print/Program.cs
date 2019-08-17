using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using POSCoreElements;

namespace loyverse_bc_print
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string systemConfigFile = "loyversebcprinter.ini";
            LogWriter writer = LogWriter.Instance;
            GlobalVariables.Logger = writer;
            GlobalVariables.Logger.WriteToInfoLog("<<<< Launching the application >>>>");

            GlobalVariables.ConfigPath = Application.StartupPath + "\\Data\\";
            GlobalVariables.Logger.WriteToInfoLog(string.Format("Data Directory Path: {0}", GlobalVariables.ConfigPath));

            if (File.Exists(GlobalVariables.ConfigPath + "\\" + systemConfigFile))
            {
                GlobalVariables.Ini = new IniFile(GlobalVariables.ConfigPath + "\\" + systemConfigFile);
                GlobalVariables.Logger.WriteToInfoLog("ini file loaded: " + GlobalVariables.ConfigPath + "\\" + systemConfigFile);
            }
            else
            {
                GlobalVariables.Logger.WriteToErrorLog("Cannot find the configuration file [loyversebcprinter.ini]", GlobalVariables.ConfigPath + "\\" + systemConfigFile);
            }

            GlobalVariables.SqliteDB = new SQLiteDataBaseManager(GlobalVariables.ConfigPath + "loyverse-data", "", "", "");
            GlobalVariables.SqliteDB.CompactDB();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmInventory());
        }
    }
}
