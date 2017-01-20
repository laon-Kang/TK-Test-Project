using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace Product_Manage_System
{
    class USBPrinter
    {

        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
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
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

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

        public static bool checkPrinter(string szPrinterName)
        {
            Int32 dwError = 0;
            IntPtr hPrinter = new IntPtr(0);
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                bSuccess = true;
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        private static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
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
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        public static bool SendFileToPrinter(string szPrinterName, string szFileName)
        {
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

            br.Close();
            fs.Close();
            return bSuccess;
        }
        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            //dwCount = szString.Length;

            char[] cs = szString.ToCharArray();
            dwCount = 0;
            foreach (char c in cs)
            {
                if ((int)c > 128)
                    dwCount += 2;
                else
                    dwCount++;
            }

            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }

        public static bool SendStringZPL(string szPrinterName, string CodeNo, string batchNo, string productName, string BoxUnit
                                         , string qty, string expireDate, string NOW, string barcode, string ORder_id, string remark, string boxNo)
        {
            StringBuilder labelData = new StringBuilder();

            try
            {

                labelData.Append("^XA");

                labelData.Append("^SEE:UHANGUL.DAT^FS");
                labelData.Append("^CW1,E:KFONT3.FNT^FS");

                labelData.Append("^FO20,50^GB760,600,3^FS");
                labelData.Append("^FO20,135^GB760,0,3^FS");
                labelData.Append("^FO20,220^GB760,0,3^FS");
                labelData.Append("^FO20,305^GB760,0,3^FS");
                labelData.Append("^FO20,390^GB760,0,3^FS");
                labelData.Append("^FO20,560^GB760,0,3^FS");

                labelData.Append("^FO20,475^GB760,0,3^FS");

                labelData.Append("^FO170,50^GB0,510,3^FS");
                labelData.Append("^FO350,50^GB0,85,3^FS");
                labelData.Append("^FO480,50^GB0,85,3^FS");
                labelData.Append("^FO350,220^GB0,85,3^FS");
                labelData.Append("^FO458,305^GB0,85,3^FS");

                labelData.Append("^FO650,220^GB0,340,3^FS");

                labelData.Append("^FO25,70^CI26^A1N,50,30^FDCODE No.^FS");
                labelData.Append("^FO180,80^A0,40,50^FD" + CodeNo + "^FS");
                labelData.Append("^FO360,70^CI28^A1N,40,20^FDBATCH NO^FS");
                labelData.Append("^FO500,80^A0,40,50^FD" + batchNo + "^FS");

                labelData.Append("^FO25,160^CI26^A1N,50,30^FD품 명^FS");
                labelData.Append("^FO180,170^A0,40,50^FD" + productName + "^FS");

                labelData.Append("^FO25,240^CI26^A1N,50,30^FD포장단위^FS");
                labelData.Append("^FO240,240^A0,40,50^FD" + BoxUnit + "^FS");

                labelData.Append("^FO360,240^CI26^A1N,50,30^FD수 량^FS");
                labelData.Append("^FO680,240^A0,40,50^FD" + qty + "^FS");

                labelData.Append("^FO25,325^CI26^A1N,50,30^FD사용기한^FS");
                labelData.Append("^FO190,330^A0,50,40^FD" + expireDate + "^FS");

                labelData.Append("^FO25,415^CI26^A1N,50,30^FD비  고^FS");
                labelData.Append("^FO180,410^A0,40,50^FD" + remark + "^FS");

                labelData.Append("^FO25,500^CI26^A1N,50,30^FD제조자^FS");
                labelData.Append("^FO180,495^CI26^A1N,50,30^FD화일약품주식회사^FS");

                labelData.Append("^FO25,590^CI26^A1N,50,30^FD경기도 안산시 단원구 산단로 67번길 156(목내동)^FS");

                labelData.Append("^FO25,690^BY2^BCN,80,N,N,N^FD" + barcode + "^FS");  // --> 바코드 Code 128A. barcode --> SSCC 128 코드 사용 
                barcode = barcode.Substring(2, 18);
                labelData.Append("^FO190,780^A0,30,20^FD(00)" + barcode + "^FS");  // --> 바코드 Code 128A. barcode --> SSCC 128 코드 사용 
                //  labelData.Append("^FO20,690^BY2,3,80,^BC,Y,N,N^FD>;" + barcode + "^FS");  // --> 바코드 Code 128C. barcode --> SSCC 128 코드 사용 
                //labelData.Append("^FO640,690^BXN,5,200,,,,@^FD>" + barcode + "^FS");  // 데이타 메트릭스 코드

                labelData.Append("^PQ1^FS");
                labelData.Append("^XZ");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return SendStringToPrinter(szPrinterName, labelData.ToString());
        }

        public static bool SendStringZPL_BOX(string szPrinterName, string BOX_NAME, string BOX_NUMBER, string COMPETENCY)
        {
            StringBuilder labelData = new StringBuilder();

            try
            {

                labelData.Append("^XA");

                labelData.Append("^SEE:UHANGUL.DAT^FS");
                labelData.Append("^CW1,E:KFONT3.FNT^FS");
                labelData.Append("^FO30,80^BXN,10,200,,,,@^FD" + BOX_NUMBER + "^FS");
                labelData.Append("^FO200,80^A0,50,40^FD" + BOX_NAME + "^FS");
                labelData.Append("^FO200,135^A0,40,30^FD" + COMPETENCY + "^FS");
                labelData.Append("^FO200,190^A0,40,30^FD" + BOX_NUMBER + "^FS");


                labelData.Append("^PQ1^FS");
                labelData.Append("^XZ");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return SendStringToPrinter(szPrinterName, labelData.ToString());
        }

        public static bool SendStringZPL_PRODUCT(string szPrinterName, string PRODUCT_NAME, string PRODUCT_BARCODE, string Size, string COMPETENCY)
        {
            StringBuilder labelData = new StringBuilder();

            try
            {

                labelData.Append("^XA");

                labelData.Append("^SEE:UHANGUL.DAT^FS");
                labelData.Append("^CW1,E:KFONT3.FNT^FS");
                if (Size == "1")
                {
                    labelData.Append("^FO30,30^BXN,3,200,,,,@^FD" + PRODUCT_BARCODE + "^FS");
                }

                if (Size == "2")
                {
                    labelData.Append("^FO30,30^BXN,4,200,,,,@^FD" + PRODUCT_BARCODE + "^FS");
                    labelData.Append("^FO130,40^A0,30,20^FD" + PRODUCT_NAME + "^FS");
                    labelData.Append("^FO130,80^A0,30,20^FD" + PRODUCT_BARCODE + "^FS");
                }

                if (Size == "3")
                {
                    labelData.Append("^FO30,20^BXN,5,200,,,,@^FD" + PRODUCT_BARCODE + "^FS");
                    labelData.Append("^FO150,20^A0,30,20^FD" + PRODUCT_NAME + "^FS");
                    labelData.Append("^FO150,50^A0,30,20^FD" + COMPETENCY + "^FS");
                    labelData.Append("^FO150,80^A0,30,20^FD" + PRODUCT_BARCODE + "^FS");
                }

                if (Size == "4")
                {
                    labelData.Append("^FO30,60^BXN,6,200,,,,@^FD" + PRODUCT_BARCODE + "^FS");
                    labelData.Append("^FO170,60^A0,40,30^FD" + PRODUCT_NAME + "^FS");
                    labelData.Append("^FO170,110^A0,30,20^FD" + COMPETENCY + "^FS");
                    labelData.Append("^FO170,140^A0,30,20^FD" + PRODUCT_BARCODE + "^FS");
                }

                if (Size == "5")
                {
                    labelData.Append("^FO30,80^BXN,8,200,,,,@^FD" + PRODUCT_BARCODE + "^FS");
                    labelData.Append("^FO200,80^A0,50,40^FD" + PRODUCT_NAME + "^FS");
                    labelData.Append("^FO200,135^A0,40,30^FD" + COMPETENCY + "^FS");
                    labelData.Append("^FO200,190^A0,40,30^FD" + PRODUCT_BARCODE + "^FS");
                }

                labelData.Append("^PQ1^FS");
                labelData.Append("^XZ");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return SendStringToPrinter(szPrinterName, labelData.ToString());
        }

        public static bool SendStringZPL(string szPrinterName, string productname, string pcode, string ext_date, string itemcount, string name, string barcode, string pbacode, string pbarcode_text, string mnufno) /*20150305 추가*/
        {
            StringBuilder labelData = new StringBuilder();

            labelData.Append("^XA");
            labelData.Append("^SEE:UHANGUL.DAT^FS");
            labelData.Append("^CW1,E:KFONT3.FNT^FS");
            labelData.Append("^FO20,20^GB680,600,3^FS");// 외곽 라인
            labelData.Append("^FO20,160^GB680,0,3^FS");// 가로 라인
            labelData.Append("^FO20,220^GB680,0,3^FS");// 가로 라인
            labelData.Append("^FO20,280^GB680,0,3^FS");// 가로 라인
            labelData.Append("^FO20,340^GB680,0,3^FS");// 가로 라인
            labelData.Append("^FO20,400^GB680,0,3^FS");// 가로 라인
            labelData.Append("^FO20,460^GB680,0,3^FS");// 가로 라인
            labelData.Append("^FO190,160^GB0,245,3^FS"); //품명 센터 라인
            labelData.Append("^FO410,220^GB0,185,3^FS");
            labelData.Append("^FO580,220^GB0,185,3^FS");
            labelData.Append("^FO50,40^A0N,25,20^BY1\r\n");
            labelData.Append("^BCN,80,N,N,N^FD>8" + barcode + "^FS");
            labelData.Append("^FO70,125^A0,30,20^FD" + barcode + "^FS");
            labelData.Append("^FO50,175^CI26^A1N,40,30^FD품  명^FS");
            labelData.Append("^FO250,175^CI26^A1N,40,30^FD" + productname + "^FS");
            labelData.Append("^FO40,235^CI26^A1N,40,30^FD제품코드^FS");
            labelData.Append("^FO210,235^A0,40,30^FD" + pcode + "^FS");
            labelData.Append("^FO430,235^CI26^A1N,40,30^FD제조번호^FS");
            labelData.Append("^FO600,235^A0,40,30^FD" + mnufno + "^FS");
            labelData.Append("^FO40,295^CI26^A1N,40,30^FD사용기한^FS");
            labelData.Append("^FO210,295^CI26^A1N,40,30^FD" + ext_date + "^FS");
            labelData.Append("^FO430,295^CI26^A1N,40,30^FD실 수량^FS");
            labelData.Append("^FO600,295^CI26^A1N,40,30^FD");
            labelData.Append(itemcount);
            labelData.Append("^FS");
            labelData.Append("^FO40,355^CI26^A1N,40,30^FD박스번호^FS"); //일련번호
            string n = barcode.Substring(10, 9);
            labelData.Append("^FO230,355^A0,40,30^FD" + n + "^FS");
            labelData.Append("^FO430,355^CI26^A1N,40,30^FD박스종류^FS");
            labelData.Append("^FO600,355^CI26^A1N,30,30^FD" + name + "박스 ^FS");
            //labelData.Append("^FO40,415^CI26^A1N,40,30^FD제조사^FS");
            //labelData.Append("^FO350,415^CI26^A1N,40,30^FD(주)비티오생명제약^FS");
            //labelData.Append("^FO150,485^A0N,25,20^BY2\r\n");
            //labelData.Append("^BCN,80,N,N,N^FD>8" + barcode + "^FS");
            ////^FO50,120^BXN,5,200,,,,@^FN1^FS
            //barcode = barcode.Substring(2, 18);
            //labelData.Append("^FO300,570^A0,30,20^FD(00)" + barcode + "^FS");
            //labelData.Append("^PQ1^FS");
            labelData.Append("^XZ");

            return SendStringToPrinter(szPrinterName, labelData.ToString());
        }



        public static bool SendStringZPL2(string szPrinterName, string barcode)
        {
            StringBuilder labelData = new StringBuilder();

            try
            {

                labelData.Append("^XA");

                labelData.Append("^FO25,690^BY2^BCN,80,N,N,N^FD" + barcode + "^FS");  // --> 바코드 Code 128A. barcode --> SSCC 128 코드 사용 
                barcode = barcode.Substring(2, barcode.Length - 2);
                labelData.Append("^FO190,780^A0,30,20^FD(00)" + barcode + "^FS");  // --> 바코드 Code 128A. barcode --> SSCC 128 코드 사용 

                labelData.Append("^PQ1^FS");
                labelData.Append("^XZ");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return SendStringToPrinter(szPrinterName, labelData.ToString());
        }

        public static string CR = "\r";

        public static bool SendStringBT200(string szPrinterName, string barcode)
        {
            StringBuilder labelData = new StringBuilder();

            try
            {

                labelData.Append("^Q50,3" + CR);
                labelData.Append("^W119" + CR);
                labelData.Append("^H5" + CR);
                labelData.Append("^P1" + CR);
                labelData.Append("^S4" + CR);
                labelData.Append("^R0" + CR);
                labelData.Append("^E25" + CR);
                labelData.Append("~HS03,19" + CR);
                labelData.Append("~R200" + CR);
                labelData.Append("^L" + CR);
                labelData.Append("BQ,50,50,2,10,220,0,3," + barcode + CR);  // --> 바코드 Code 128A. barcode --> SSCC 128 코드 사용 
                //labelData.Append("AW,50,100,6,2,0,0,SSCC - Serial Shipping Container Code (SSCC)" + CR);
                labelData.Append("E" + CR);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return SendStringToPrinter(szPrinterName, labelData.ToString());
        }

        public static bool SendDataZPL(string szPrinterName, string[] data)
        {
            StringBuilder labelData = new StringBuilder();

            labelData.Append("^XA");
            labelData.Append("^XFR:SAMPLE.GRF");
            for (int i = 0; i < data.Length; i++)
            {
                labelData.Append("^FN" + (i + 1).ToString() + "^FD" + data[i] + "^FS");
            }
            labelData.Append("^XZ");
            return SendStringToPrinter(szPrinterName, labelData.ToString());
        }

        public static bool SendStringZPL_text_BOX(string szPrinterName, string barcode, string EXP_POINT, string MNUFNO, string STD_CD, string EXP, string SERIAL,
                                                string PRODUCT_NAME, string PKG_BOX_UNIT_QTY, string PKG_MID_UNIT_QTY, string SERIAL_QTY)
        {
            StringBuilder labelData = new StringBuilder();

            labelData.Append("^XA");
            labelData.Append("^XFR:SAMPLE.GRF");
            labelData.Append("^FN1^FD" + barcode + "^FS");
            labelData.Append("^FN2^FD" + EXP_POINT + "^FS");
            labelData.Append("^FN3^FD" + MNUFNO + "^FS");
            labelData.Append("^FN4^FD" + STD_CD + "^FS");
            labelData.Append("^FN5^FD" + EXP + "^FS");
            labelData.Append("^FN6^FD" + MNUFNO + "^FS");
            labelData.Append("^FN7^FD" + SERIAL + "^FS");
            labelData.Append("^FN8^FD" + PRODUCT_NAME + "^FS");
            labelData.Append("^FN9^FD" + PKG_BOX_UNIT_QTY + "^FS");
            labelData.Append("^FN10^FD" + PKG_MID_UNIT_QTY + "^FS");
            labelData.Append("^FN11^FD" + SERIAL_QTY + "^FS");
            labelData.Append("^XZ");

            return SendStringToPrinter(szPrinterName, labelData.ToString());
        }
    }
}
