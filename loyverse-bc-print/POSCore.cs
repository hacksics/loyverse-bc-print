using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Xml;

/*
*
*
Added to barcodeit
*
*
*/

// INI File reader for configuration settings

// LogWrite

namespace POSCoreElements
{
    class PosCore
    {
    }

    // Wrapper for Dictionary class
    public class Dictionary<TKey1, TKey2, TValue> : Dictionary<KeyValuePair<TKey1, TKey2>, TValue>
    {
        private static KeyValuePair<TKey1, TKey2> CreateKey(TKey1 key1, TKey2 key2)
        {
            return new KeyValuePair<TKey1, TKey2>(key1, key2);
        }

        public void Add(TKey1 key1, TKey2 key2, TValue value)
        {
            try
            {
                Add(CreateKey(key1, key2), value);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex + key1.ToString() + key2);
            }
        }

        public TValue this[TKey1 key1, TKey2 key2]
        {
            get
            {
                return this[CreateKey(key1, key2)];
            }
            set
            {
                this[CreateKey(key1, key2)] = value;
            }
        }

        public bool ContainsKey(TKey1 key1, TKey2 key2)
        {
            return ContainsKey(CreateKey(key1, key2));
        }

        public bool TryGetValue(TKey1 key1, TKey2 key2, out TValue value)
        {
            return TryGetValue(CreateKey(key1, key2), out value);
        }
    }

    /// <summary>
    /// Triple key dictionary
    /// </summary>
    /// <typeparam name="TKey1">Key 1</typeparam>
    /// <typeparam name="TKey2">Key 2</typeparam>
    /// <typeparam name="TKey3">Key 3</typeparam>
    /// <typeparam name="TValue">Value</typeparam>
    public class Dictionary<TKey1, TKey2, TKey3, TValue> : Dictionary<KeyValuePair<TKey1, KeyValuePair<TKey2, TKey3>>, TValue>
    {
        private static KeyValuePair<TKey1, KeyValuePair<TKey2, TKey3>> CreateKey(TKey1 key1, TKey2 key2, TKey3 key3)
        {
            return new KeyValuePair<TKey1, KeyValuePair<TKey2, TKey3>>(key1, new KeyValuePair<TKey2, TKey3>(key2, key3));
        }

        public void Add(TKey1 key1, TKey2 key2, TKey3 key3, TValue value)
        {
            Add(CreateKey(key1, key2, key3), value);
        }

        public TValue this[TKey1 key1, TKey2 key2, TKey3 key3]
        {
            get
            {
                return this[CreateKey(key1, key2, key3)];
            }
            set
            {
                this[CreateKey(key1, key2, key3)] = value;
            }
        }

        public bool ContainsKey(TKey1 key1, TKey2 key2, TKey3 key3)
        {
            return ContainsKey(CreateKey(key1, key2, key3));
        }

        public bool TryGetValue(TKey1 key1, TKey2 key2, TKey3 key3, out TValue value)
        {
            return TryGetValue(CreateKey(key1, key2, key3), out value);
        }
    }


    public class IniParser
    {
        private readonly Hashtable _keyPairs = new Hashtable();
        private readonly string _iniFilePath;

        private struct SectionPair
        {
            public string Section;
            public string Key;
        }

        /// <summary>
        /// Opens the INI file at the given path and enumerates the values in the IniParser.
        /// </summary>
        /// <param name="iniPath">Full path to INI file.</param>
        public IniParser(string iniPath)
        {
            TextReader iniFile = null;
            string strLine = null;
            string currentRoot = null;
            string[] keyPair = null;

            _iniFilePath = iniPath;

            if (File.Exists(iniPath))
            {
                try
                {
                    iniFile = new StreamReader(iniPath);

                    strLine = iniFile.ReadLine();

                    while (strLine != null)
                    {
                        strLine = strLine.Trim().ToUpper();

                        if (strLine != "")
                        {
                            if (strLine.StartsWith("[") && strLine.EndsWith("]"))
                            {
                                currentRoot = strLine.Substring(1, strLine.Length - 2);
                            }
                            else
                            {
                                keyPair = strLine.Split(new[] { '=' }, 2);

                                SectionPair sectionPair;
                                string value = null;

                                if (currentRoot == null)
                                    currentRoot = "ROOT";

                                sectionPair.Section = currentRoot;
                                sectionPair.Key = keyPair[0];

                                if (keyPair.Length > 1)
                                    value = keyPair[1];

                                _keyPairs.Add(sectionPair, value);
                            }
                        }

                        strLine = iniFile.ReadLine();
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (iniFile != null)
                        iniFile.Close();
                }
            }
            else
                throw new FileNotFoundException("Unable to locate " + iniPath);

        }

        /// <summary>
        /// Returns the value for the given section, key pair.
        /// </summary>
        /// <param name="sectionName">Section name.</param>
        /// <param name="settingName">Key name.</param>
        public string GetSetting(string sectionName, string settingName)
        {
            SectionPair sectionPair;
            sectionPair.Section = sectionName.ToUpper();
            sectionPair.Key = settingName.ToUpper();

            return (string)_keyPairs[sectionPair];
        }

        /// <summary>
        /// Enumerates all lines for given section.
        /// </summary>
        /// <param name="sectionName">Section to enum.</param>
        public string[] EnumSection(string sectionName)
        {
            ArrayList tmpArray = new ArrayList();

            foreach (SectionPair pair in _keyPairs.Keys)
            {
                if (pair.Section == sectionName.ToUpper())
                    tmpArray.Add(pair.Key);
            }

            return (string[])tmpArray.ToArray(typeof(string));
        }

        /// <summary>
        /// Adds or replaces a setting to the table to be saved.
        /// </summary>
        /// <param name="sectionName">Section to add under.</param>
        /// <param name="settingName">Key name to add.</param>
        /// <param name="settingValue">Value of key.</param>
        public void AddSetting(string sectionName, string settingName, string settingValue)
        {
            SectionPair sectionPair;
            sectionPair.Section = sectionName.ToUpper();
            sectionPair.Key = settingName.ToUpper();

            if (_keyPairs.ContainsKey(sectionPair))
                _keyPairs.Remove(sectionPair);

            _keyPairs.Add(sectionPair, settingValue);
        }

        /// <summary>
        /// Adds or replaces a setting to the table to be saved with a null value.
        /// </summary>
        /// <param name="sectionName">Section to add under.</param>
        /// <param name="settingName">Key name to add.</param>
        public void AddSetting(string sectionName, string settingName)
        {
            AddSetting(sectionName, settingName, null);
        }

        /// <summary>
        /// Remove a setting.
        /// </summary>
        /// <param name="sectionName">Section to add under.</param>
        /// <param name="settingName">Key name to add.</param>
        public void DeleteSetting(string sectionName, string settingName)
        {
            SectionPair sectionPair;
            sectionPair.Section = sectionName.ToUpper();
            sectionPair.Key = settingName.ToUpper();

            if (_keyPairs.ContainsKey(sectionPair))
                _keyPairs.Remove(sectionPair);
        }

        /// <summary>
        /// Save settings to new file.
        /// </summary>
        /// <param name="newFilePath">New file path.</param>
        public void SaveSettings(string newFilePath)
        {
            ArrayList sections = new ArrayList();
            string tmpValue = "";
            string strToSave = "";

            foreach (SectionPair sectionPair in _keyPairs.Keys)
            {
                if (!sections.Contains(sectionPair.Section))
                    sections.Add(sectionPair.Section);
            }

            foreach (string section in sections)
            {
                strToSave += ("[" + section + "]\r\n");

                foreach (SectionPair sectionPair in _keyPairs.Keys)
                {
                    if (sectionPair.Section == section)
                    {
                        tmpValue = (string)_keyPairs[sectionPair];

                        if (tmpValue != null)
                            tmpValue = "=" + tmpValue;

                        strToSave += (sectionPair.Key + tmpValue + "\r\n");
                    }
                }

                strToSave += "\r\n";
            }

            try
            {
                TextWriter tw = new StreamWriter(newFilePath);
                tw.Write(strToSave);
                tw.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Save settings back to ini file.
        /// </summary>
        public void SaveSettings()
        {
            SaveSettings(_iniFilePath);
        }
    }

    // This is the LogWriter Class to write the log file 
    // This code is based on http://blog.bondigeek.com/2011/09/08/a-simple-c-thread-safe-logging-class/ 
    public class LogWriter
    {
        private static LogWriter _instance;
        private static Queue<Log> _logQueue;
        private static readonly string _logDir = Path.GetTempPath();
        private static readonly string _logFile = "POSInventory.log";
        private static readonly int _maxLogAge = int.Parse("1");
        private static readonly int _queueSize = int.Parse("1");
        private static DateTime _lastFlushed = DateTime.Now;


        /// <summary>
        /// Private constructor to prevent instance creation
        /// </summary>
        private LogWriter()
        {

        }

        /// <summary>
        /// An LogWriter instance that exposes a single instance
        /// </summary>
        public static LogWriter Instance
        {
            get
            {
                // If the instance is null then create one and init the Queue
                if (_instance == null)
                {
                    _instance = new LogWriter();
                    _logQueue = new Queue<Log>();

                    // Start with new line when starting the log
                    _logQueue.Enqueue(new Log("\n\n"));
                }

                return _instance;
            }
        }

        /// <summary>
        /// The single instance method that writes to the log file
        /// </summary>
        /// <param name="message">The message to write to the log</param>
        public void WriteToInfoLog(string message, [CallerFilePath] string file = "", [CallerMemberName] string member = "", [CallerLineNumber] int line = 0)
        {
            // Lock the queue while writing to prevent contention for the log file
            lock (_logQueue)
            {
                // Create the entry and push to the Queue
                Log logEntry = new Log("|INFO | " + message + "  (src:" + Path.GetFileName(file) + "[" + line + "])");
                _logQueue.Enqueue(logEntry);

                // If we have reached the Queue Size then flush the Queue
                if (_logQueue.Count >= _queueSize || DoPeriodicFlush())
                {
                    FlushLog();
                }
            }
        }
        public void WriteToWarnLog(string message, [CallerFilePath] string file = "", [CallerMemberName] string member = "", [CallerLineNumber] int line = 0)
        {
            // Lock the queue while writing to prevent contention for the log file
            lock (_logQueue)
            {
                // Create the entry and push to the Queue
                Log logEntry = new Log("|WARN | " + message + "  (src:" + Path.GetFileName(file) + "[" + line + "])");
                _logQueue.Enqueue(logEntry);

                // If we have reached the Queue Size then flush the Queue
                if (_logQueue.Count >= _queueSize || DoPeriodicFlush())
                {
                    FlushLog();
                }
            }
        }

        public void WriteToWarnLog(string message, string error)
        {


            // Lock the queue while writing to prevent contention for the log file
            lock (_logQueue)
            {
                // Create the entry and push to the Queue
                Log logEntry = new Log("|WARN | " + message + Environment.NewLine +
                    "Warning Msg {" + Environment.NewLine + "   " + error + Environment.NewLine + "}");
                _logQueue.Enqueue(logEntry);

                // If we have reached the Queue Size then flush the Queue
                if (_logQueue.Count >= _queueSize || DoPeriodicFlush())
                {
                    FlushLog();
                }
            }
            message = message + Environment.NewLine + "Do you want to continue? System may be unstable now";
            DialogResult dialogResult = MessageBox.Show(message, @"ERROR!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
            }
            else
            {
                Log logEntry = new Log("|ERROR| End user choose to exit from the application!");
                _logQueue.Enqueue(logEntry);

                if (_logQueue.Count >= _queueSize || DoPeriodicFlush())
                {
                    FlushLog();
                }
                Environment.Exit(1);
            }
        }

        public void WriteToErrorLog(string message, [CallerFilePath] string file = "", [CallerMemberName] string member = "", [CallerLineNumber] int line = 0)
        {
            // Lock the queue while writing to prevent contention for the log file
            lock (_logQueue)
            {
                // Create the entry and push to the Queue
                Log logEntry = new Log("|ERROR| " + message + "  (src:" + Path.GetFileName(file) + "[" + line + "])");
                _logQueue.Enqueue(logEntry);

                // If we have reached the Queue Size then flush the Queue
                if (_logQueue.Count >= _queueSize || DoPeriodicFlush())
                {
                    FlushLog();
                }

                MessageBox.Show(message, @"ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }

        public void WriteToErrorLog(string message, string error)
        {

            // Lock the queue while writing to prevent contention for the log file
            lock (_logQueue)
            {
                // Create the entry and push to the Queue
                Log logEntry = new Log("|ERROR| " + message + Environment.NewLine +
                    "Error Msg {" + Environment.NewLine + "   " + error + Environment.NewLine + "}");
                _logQueue.Enqueue(logEntry);

                // If we have reached the Queue Size then flush the Queue
                if (_logQueue.Count >= _queueSize || DoPeriodicFlush())
                {
                    FlushLog();
                }

                MessageBox.Show(message, @"ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }
        private bool DoPeriodicFlush()
        {
            TimeSpan logAge = DateTime.Now - _lastFlushed;
            if (logAge.TotalSeconds >= _maxLogAge)
            {
                _lastFlushed = DateTime.Now;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Flushes the Queue to the physical log file
        /// </summary>
        private void FlushLog()
        {
            while (_logQueue.Count > 0)
            {
                Log entry = _logQueue.Dequeue();
                string logPath = _logDir + entry.LogDate + "_" + _logFile;

                // This could be optimised to prevent opening and closing the file for each write
                using (FileStream fs = File.Open(logPath, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter log = new StreamWriter(fs))
                    {
                        log.WriteLine("{0}\t{1}", entry.LogTime, entry.Message);
                    }
                }
            }
        }
    }

    /// <summary>
    /// A Log class to store the message and the Date and Time the log entry was created
    /// </summary>
    public class Log
    {
        public string Message { get; set; }
        public string LogTime { get; set; }
        public string LogDate { get; set; }

        public Log(string message)
        {
            Message = message;
            LogDate = DateTime.Now.ToString("yyyy-MM-dd");
            LogTime = DateTime.Now.ToString("hh:mm:ss.fff tt");
        }
    }

    public class XMLDataLoader
    {
        /*
         * Load Categories and Vendors from XML file. The Categories name will be used in export file 
         * generated for loyverse
         * format: 
         * <data>
         *   <category>
         *     <category name="men"/>
         *     <category name="women"/>
         *   </category>
         *   <vendor>
         *     <vendor name="AAA"/>
         *   <vendor>
         * </data>
         */
        XmlReader reader = null;
        public XMLDataLoader(string filename)
        {
            try
            {
                reader = XmlReader.Create(filename);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        public ArrayList LoadCategories()
        {
            ArrayList categories = new ArrayList();
            try
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "category"))
                    {
                        if (reader.HasAttributes)
                            categories.Add(reader.GetAttribute("name"));
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return categories;
        }

        public ArrayList LoadVendors()
        {
            ArrayList vendors = new ArrayList();
            try
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "vendor"))
                    {
                        if (reader.HasAttributes)
                            vendors.Add(reader.GetAttribute("name"));
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return vendors;
        }
    }

    public class IniFile
    {
        public string Path;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
                 string key, string def, StringBuilder retVal,
            int size, string filePath);

        /// <summary>

        /// INIFile Constructor.

        /// </summary>

        /// <PARAM name="INIPath"></PARAM>

        public IniFile(string iniPath)
        {
            Path = iniPath;
        }
        /// <summary>

        /// Write Data to the INI File

        /// </summary>

        /// <PARAM name="Section"></PARAM>

        /// Section name

        /// <PARAM name="Key"></PARAM>

        /// Key Name

        /// <PARAM name="Value"></PARAM>

        /// Value Name

        public void IniWriteValue(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, Path);
        }

        /// <summary>

        /// Read Data Value From the Ini File

        /// </summary>

        /// <PARAM name="Section"></PARAM>

        /// <PARAM name="Key"></PARAM>

        /// <PARAM name="Path"></PARAM>

        /// <returns></returns>

        public string IniReadValue(string section, string key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, "", temp,
                                           255, Path);

            return temp.ToString();

        }
    }

}
