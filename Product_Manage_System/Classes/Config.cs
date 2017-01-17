using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace Product_Manage_System
{
    class Config
    {
        private static DataSet dsConfig = new DataSet();

        public static void LoadXML(string filePath)
        {
            try
            {
                dsConfig.ReadXml(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void SaveXML(string filePath)
        {
            try
            {
                dsConfig.WriteXml(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string SERVER_URL
        {
            get { return dsConfig.Tables[0].Rows[0][COLUMNS.CONFIG.SERVER_URL].ToString(); }
            set { dsConfig.Tables[0].Rows[0][COLUMNS.CONFIG.SERVER_URL] = value; }
        }

        public static string DBCONNECTION
        {
            get { return dsConfig.Tables[0].Rows[0][COLUMNS.CONFIG.DBCONNECTION].ToString(); }
            set { dsConfig.Tables[0].Rows[0][COLUMNS.CONFIG.DBCONNECTION] = value; }
        }

        public static string ERRLOG_PATH
        {
            get { return dsConfig.Tables[0].Rows[0][COLUMNS.CONFIG.ERRLOG_PATH].ToString(); }
            set { dsConfig.Tables[0].Rows[0][COLUMNS.CONFIG.ERRLOG_PATH] = value; }
        }

        public static string WORKLOG_PATH
        {
            get { return dsConfig.Tables[0].Rows[0][COLUMNS.CONFIG.WORKLOG_PATH].ToString(); }
            set { dsConfig.Tables[0].Rows[0][COLUMNS.CONFIG.WORKLOG_PATH] = value; }
        }

        public static string SCANNER_PORT
        {
            get { return dsConfig.Tables[0].Rows[0][COLUMNS.CONFIG.SCANNER_PORT].ToString(); }
            set { dsConfig.Tables[0].Rows[0][COLUMNS.CONFIG.SCANNER_PORT] = value; }
        }

        public static string SCANNER_BAUD
        {
            get { return dsConfig.Tables[0].Rows[0][COLUMNS.CONFIG.SCANNER_BAUD].ToString(); }
            set { dsConfig.Tables[0].Rows[0][COLUMNS.CONFIG.SCANNER_BAUD] = value; }
        }

        public static string SCANNER_DATA
        {
            get { return dsConfig.Tables[0].Rows[0][COLUMNS.CONFIG.SCANNER_DATA].ToString(); }
            set { dsConfig.Tables[0].Rows[0][COLUMNS.CONFIG.SCANNER_DATA] = value; }
        }

        public static string SCANNER_PARITY
        {
            get { return dsConfig.Tables[0].Rows[0][COLUMNS.CONFIG.SCANNER_PARITY].ToString(); }
            set { dsConfig.Tables[0].Rows[0][COLUMNS.CONFIG.SCANNER_PARITY] = value; }
        }

        public static string SCANNER_STOP
        {
            get { return dsConfig.Tables[0].Rows[0][COLUMNS.CONFIG.SCANNER_STOP].ToString(); }
            set { dsConfig.Tables[0].Rows[0][COLUMNS.CONFIG.SCANNER_STOP] = value; }
        }

        public static bool connectScaner(ref System.IO.Ports.SerialPort sp)
        {
            bool bRet = false;

            try
            {
                if (sp.IsOpen)
                {
                    sp.Close();
                }

                sp.PortName = SCANNER_PORT;
                sp.BaudRate = Int32.Parse(SCANNER_BAUD);
                sp.DataBits = Int32.Parse(SCANNER_DATA);
                sp.Parity = Common.getParity(SCANNER_PARITY);

                sp.Open();

                if (sp.IsOpen)
                    bRet = true;

            }
            catch (Exception ex)
            {
                throw new Exception("SCANNER OPEN ERROR : " + ex.Message);
            }

            return bRet;
        }

        public static void disconnectScanner(ref System.IO.Ports.SerialPort sp)
        {
            try
            {
                if (sp.IsOpen)
                {
                    sp.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("SCANNER CLOSE ERROR : " + ex.Message);
            }
        }
    }
}
