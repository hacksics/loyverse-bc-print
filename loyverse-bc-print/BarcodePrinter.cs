using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

//
//
//using Skiviez.UndiesClient.Domain;
//using Skiviez.Commons.WinForms;
//using Skiviez.Commons.Core;

// DEBUG
public class TSCLIB_DLL
{
    [DllImport("TSCLIB.dll", EntryPoint = "about")]
    public static extern int about();

    [DllImport("TSCLIB.dll", EntryPoint = "openport")]
    public static extern int openport(string printername);

    [DllImport("TSCLIB.dll", EntryPoint = "barcode")]
    public static extern int barcode(string x, string y, string type,
                string height, string readable, string rotation,
                string narrow, string wide, string code);

    [DllImport("TSCLIB.dll", EntryPoint = "clearbuffer")]
    public static extern int clearbuffer();

    [DllImport("TSCLIB.dll", EntryPoint = "closeport")]
    public static extern int closeport();

    [DllImport("TSCLIB.dll", EntryPoint = "downloadpcx")]
    public static extern int downloadpcx(string filename, string image_name);

    [DllImport("TSCLIB.dll", EntryPoint = "formfeed")]
    public static extern int formfeed();

    [DllImport("TSCLIB.dll", EntryPoint = "nobackfeed")]
    public static extern int nobackfeed();

    [DllImport("TSCLIB.dll", EntryPoint = "printerfont")]
    public static extern int printerfont(string x, string y, string fonttype,
                    string rotation, string xmul, string ymul,
                    string text);

    [DllImport("TSCLIB.dll", EntryPoint = "printlabel")]
    public static extern int printlabel(string set, string copy);

    [DllImport("TSCLIB.dll", EntryPoint = "sendcommand")]
    public static extern int sendcommand(string printercommand);

    [DllImport("TSCLIB.dll", EntryPoint = "setup")]
    public static extern int setup(string width, string height,
              string speed, string density,
              string sensor, string vertical,
              string offset);

    [DllImport("TSCLIB.dll", EntryPoint = "windowsfont")]
    public static extern int windowsfont(int x, int y, int fontheight,
                    int rotation, int fontstyle, int fontunderline,
                    string szFaceName, string content);

}
namespace loyverse_bc_print
{

    public class TSCBarcode
    {

        private readonly string _zShopName;

        private readonly string _zNextPos;

        private string _zBcPrinterName;

        private readonly string _zWidth;
        private readonly string _zHeight;
        private readonly string _zXCord;
        private readonly string _zYCord;

        private string _zPrintSpeed;
        private string _zPrintDensity;
        private string _zPrintSensorType;
        private string _zPrintVerticalGapHeight;
        private string _labelsPerLine;


        public TSCBarcode(string zWidth, string zHeight, string zXCord, string zYCord, string zShopName, string zNextPos, string labelsPerLine)
        {
            GlobalVariables.Logger.WriteToInfoLog(string.Format("Initializing the barcode printing: Width={0}, Height={1}, " +
                                                                "XCord={2}, YCord={3}, Shop Name={4}, Next Pos = {5}, Labels per Line={6}",
                                                                zWidth, zHeight, zXCord, zYCord, zShopName, zNextPos, labelsPerLine));
            _zWidth = zWidth;
            _zHeight = zHeight;
            _zXCord = zXCord;
            _zYCord = zYCord;
            _zShopName = zShopName;
            _zNextPos = zNextPos;
            _labelsPerLine = labelsPerLine;
        }

        public void SetBcPrinter(string zBcPrinterName, string zPrintSpeed, string zPrintDensity,
            string zPrintSensorType, string zPrintVerticalGapHeight)
        {
            _zBcPrinterName = zBcPrinterName;
            _zPrintSpeed = zPrintSpeed;
            _zPrintDensity = zPrintDensity;
            _zPrintSensorType = zPrintSensorType;
            _zPrintVerticalGapHeight = zPrintVerticalGapHeight;
            GlobalVariables.Logger.WriteToInfoLog(string.Format("Opening the printer: Name={0}, Speed={1}, Density={2}, Sensor={3}, Gap={4}",
                                                                zBcPrinterName, zPrintSpeed, zPrintDensity, zPrintSensorType, zPrintVerticalGapHeight));
            TSCLIB_DLL.openport(zBcPrinterName);
            TSCLIB_DLL.setup(_zWidth, _zHeight, zPrintSpeed, zPrintDensity, zPrintSensorType, zPrintVerticalGapHeight, "0");
            TSCLIB_DLL.clearbuffer();
        }


        public void PrintText(string zXPos, string zYPos, string zFontHeight, string zRotation, string zFontStyle,
            string zUnderLine, string zFont, string zTextToPrint)
        {
            int labelNo = 0;
            while (labelNo < Convert.ToInt16(_labelsPerLine))
            {
                TSCLIB_DLL.windowsfont(Convert.ToInt16(zXPos) + (labelNo * Convert.ToInt16(_zNextPos)), Convert.ToInt16(zYPos),
                                       Convert.ToInt16(zFontHeight), Convert.ToInt16(zRotation), Convert.ToInt16(zFontStyle),
                                       Convert.ToInt16(zUnderLine), zFont, zTextToPrint);
                labelNo++;
            }
        }


        public void PrintBarcode(string zXPos, string zYPos, string zFont, string zHeight, string zPrintText,
            string zRotation, string zNB1, string zNB2, string zBarcode)
        {
            int labelNo = 0;
            while (labelNo < Convert.ToInt16(_labelsPerLine))
            {
                GlobalVariables.Logger.WriteToInfoLog(string.Format("args: {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}",
                zXPos, zYPos, zFont, zHeight, zPrintText, zRotation, zNB1, zNB2, zBarcode));
                int xPos = Convert.ToInt16(zXPos) + (labelNo * Convert.ToInt16(_zNextPos));
                GlobalVariables.Logger.WriteToInfoLog(string.Format("args: {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}",
                xPos, zYPos, zFont, zHeight, zPrintText, zRotation, zNB1, zNB2, zBarcode));
                TSCLIB_DLL.barcode(xPos.ToString(), zYPos, zFont, zHeight, zPrintText, zRotation, zNB1, zNB2, zBarcode);
                labelNo++;
            }

        }

        public void PrintLogo(string zXPos, string zYPos, string zPCXName)
        {
            TSCLIB_DLL.downloadpcx("UL.PCX", "UL.PCX");
            TSCLIB_DLL.sendcommand("PUTPCX 224,8,\"UL.PCX\"");
            TSCLIB_DLL.sendcommand("PUTPCX 576,8,\"UL.PCX\"");
        }

        public void SendToPrint(double numberOfPrints)
        {
            TSCLIB_DLL.printlabel("1", numberOfPrints.ToString());
            TSCLIB_DLL.closeport();
        }
    }

    public class RawPrinterHelper
    {
        public static string ZPrinterName;

        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]


        public class Docinfoa
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] Docinfoa di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        internal static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            Docinfoa di = new Docinfoa();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = "My C#.NET RAW Document";
            di.pDataType = "RAW";

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            else
            {
                GlobalVariables.Logger.WriteToWarnLog("Unable to find printer", szPrinterName);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        public static bool SendFileToPrinter(string szFileName)
        {
            string szPrinterName = GetDefaultPrinterName();
            // Open the file.
            FileStream fs = new FileStream(szFileName, FileMode.Open);
            // Create a BinaryReader on the file.
            BinaryReader br = new BinaryReader(fs);
            // Dim an array of bytes big enough to hold the file's contents.
            Byte[] bytes = new Byte[fs.Length];
            bool bSuccess = false;
            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = Convert.ToInt32(fs.Length);
            // Read the contents of the file into the array.
            bytes = br.ReadBytes(nLength);
            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);
            fs.Close();
            return bSuccess;
        }
        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            //Debug.WriteLine(szString);
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            //dwCount = szString.Length;
            dwCount = (szString.Length + 1) * Marshal.SystemMaxDBCSCharSize;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }

        public static string GetDefaultPrinterName()
        {
            /*string zPrinterName = null;
            System.Drawing.Printing.PrinterSettings oPS = new System.Drawing.Printing.PrinterSettings();

            try
            {
                zPrinterName = oPS.PrinterName;
            }
            catch (System.Exception ex)
            {
                zPrinterName = "";
            }
            finally
            {
                oPS = null;
            }
            zPrinterName = "TSC TTP-244 Plus (Copy 1)";
             */
            return ZPrinterName;
        }
    }
}

