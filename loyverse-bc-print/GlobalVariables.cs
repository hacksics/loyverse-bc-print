using POSCoreElements;

namespace loyverse_bc_print
{
    public static class GlobalVariables
    {
        static string _cashierId = "CASHIER1";
        static string _terminalId = "TERMINAL1";
        static double _profitMargin = 20;
        static double _defaultQuantity = 12;
        static SQLiteDataBaseManager _pdMaster;
        static IniFile _ini;
        static int _roleId;
        static string _configPath;
        static LogWriter _logger;
        static string _shopName = "BUDDI";

        public static string ShopName
        {
            get
            {
                return _shopName;
            }
            set
            {
                _shopName = value;
            }
        }

        public static string TerminalId
        {
            get
            {
                return _terminalId;
            }
            set
            {
                _terminalId = value;
            }
        }

        public static double ProfitMargin
        {
            get
            {
                return _profitMargin;
            }
            set
            {
                _profitMargin = value;
            }
        }

        public static double DefaultQuantity
        {
            get
            {
                return _defaultQuantity;
            }
            set
            {
                _defaultQuantity = value;
            }
        }

        public static int RoleId
        {
            get
            {
                return _roleId;
            }
            set
            {
                _roleId = value;
            }
        }

        public static SQLiteDataBaseManager SqliteDB
        {
            get
            {
                return _pdMaster;
            }
            set
            {
                _pdMaster = value;
            }
        }

        public static IniFile Ini
        {
            get
            {
                return _ini;
            }
            set
            {
                _ini = value;
            }
        }

        public static string ConfigPath
        {
            get
            {
                return _configPath;
            }
            set
            {
                _configPath = value;
            }
        }

        public static LogWriter Logger
        {
            get
            {
                return _logger;
            }
            set
            {
                _logger = value;
            }
        }

    }
}
