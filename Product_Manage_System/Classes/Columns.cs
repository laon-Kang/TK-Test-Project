using System;
using System.Collections.Generic;

using System.Text;

namespace Product_Manage_System
{
    class TABLES
    {
        public const string TB_USER_INFO = "TB_USER_INFO";
        public const string TB_USER_ROLE = "TB_USER_ROLE";
        public const string TB_COMMON_GROUP_CODE = "TB_COMMON_GROUP_CODE";
        public const string TB_COMMON_CODE = "TB_COMMON_CODE";
        public const string TB_COMPANY_INFO = "TB_COMPANY_INFO";
        public const string TB_PRODUCT_INFO = "TB_PRODUCT_INFO";
        public const string TB_PRODUCT_HISTORY = "TB_PRODUCT_HISTORY";
        public const string TB_BOX_INFO = "TB_BOX_INFO";
        public const string TB_BOX_SERIAL_NO = "TB_BOX_SERIAL_NO";
    }

    class RESULT
    {
        public const string PASS = "True";
        public const string FAIL = "False";
    }

    /// <summary>
    /// 이상현
    /// </summary>
    class PRODUCT_TYPE
    {
        public const string PROPERTY_TYPE_CODE = "PROPERTY_TYPE_CODE";
        public const string PROPERTY_PURPOSE_CODE = "PROPERTY_PURPOSE_CODE";
        public const string COMPANY_CODE = "COMPANY_CODE";
        public const string COMPETENCY_CODE = "COMPETENCY_CODE";
    }


    class COLUMNS
    {
        public struct TB_USER_INFO
        {
            public const string USER_ID = "USER_ID";
            public const string USER_NAME = "USER_NAME";
            public const string COMPANY_CODE = "COMPANY_CODE";
            public const string TEAM_CODE = "TEAM_CODE";
            public const string POST_CODE = "POST_CODE";
            public const string PHONE_NUMBER = "PHONE_NUMBER";
            public const string CREATE_BY = "CREATE_BY";
            public const string CREATE_DATE = "CREATE_DATE";
            public const string UPDATE_BY = "UPDATE_BY";
            public const string UPDATE_DATE = "UPDATE_DATE";
            public const string USE_YN = "USE_YN";
        }

        public struct TB_USER_ROLE
        {
            public const string USER_ID = "USER_ID";
            public const string USER_PASSWORD = "USER_PASSWORD";
            public const string USER_FINGERPRINT = "USER_FINGERPRINT";
            public const string USER_BARCODE = "USER_BARCODE";
            public const string AUTHORITY_CODE = "AUTHORITY_CODE";
            public const string USE_YN = "USE_YN";
        }

        public struct TB_COMMON_GROUP_CODE
        {
            public const string COMMON_GROUP_CODE = "COMMON_GROUP_CODE";
            public const string COMMON_GROUP_NAME = "COMMON_GROUP_NAME";
            public const string CREATE_BY = "CREATE_BY";
            public const string CREATE_DATE = "CREATE_DATE";
            public const string UPDATE_BY = "UPDATE_BY";
            public const string UPDATE_DATE = "UPDATE_DATE";
            public const string USE_YN = "USE_YN";
        }

        public struct TB_COMMON_CODE
        {
            public const string COMMON_CODE = "COMMON_CODE";
            public const string COMMON_NAME = "COMMON_NAME";
            public const string COMMON_GROUP_CODE = "COMMON_GROUP_CODE";
            public const string CREATE_BY = "CREATE_BY";
            public const string CREATE_DATE = "CREATE_DATE";
            public const string UPDATE_BY = "UPDATE_BY";
            public const string UPDATE_DATE = "UPDATE_DATE";
            public const string USE_YN = "USE_YN";
        }

        public struct TB_COMPANY_INFO
        {
            public const string COMPANY_CODE = "COMPANY_CODE";
            public const string COMPANY_NAME = "COMPANY_NAME";
            public const string COMPANY_ADDR = "COMPANY_ADDR";
            public const string TEL_NUMBER = "TEL_NUMBER";
            public const string CREATE_BY = "CREATE_BY";
            public const string CREATE_DATE = "CREATE_DATE";
            public const string UPDATE_BY = "UPDATE_BY";
            public const string UPDATE_DATE = "UPDATE_DATE";
            public const string USE_YN_CODE = "USE_YN_CODE";
        }
        
        // SIMON Login DataTable
        public struct TB_USER_INFO_ROLE_JOIN
        {
            public const string USER_ID = "USER_ID";
            public const string USER_NAME = "USER_NAME";
            public const string COMPANY_CODE = "COMPANY_CODE";
            public const string TEAM_CODE = "TEAM_CODE";
            public const string POST_CODE = "POST_CODE";
            public const string PHONE_NUMBER = "PHONE_NUMBER";
            public const string USER_PASSWORD = "USER_PASSWORD";
            public const string USER_FINGERPRINT = "USER_FINGERPRINT";
            public const string USER_BARCODE = "USER_BARCODE";
            public const string AUTHORITY_CODE = "AUTHORITY_CODE";
            public const string CREATE_BY = "CREATE_BY";
            public const string CREATE_DATE = "CREATE_DATE";
            public const string UPDATE_BY = "UPDATE_BY";
            public const string UPDATE_DATE = "UPDATE_DATE";
            public const string USE_YN = "USE_YN";
        }

        // SIMON Rental Product List DataTable
        public struct TB_PRODUCT_INFO
        {
            public const string IDENT_NUMBER = "IDENT_NUMBER";
            public const string PRODUCT_NAME = "PRODUCT_NAME";
            public const string PRODUCT_CODE = "PRODUCT_CODE";
            public const string PROPERTY_TYPE_CODE = "PROPERTY_TYPE_CODE";
            public const string PROPERTY_TYPE_NAME = "PROPERTY_TYPE_NAME";
            public const string PROPERTY_PURPOSE_CODE = "PROPERTY_PURPOSE_CODE";
            public const string PROPERTY_PURPOSE_NAME = "PROPERTY_PURPOSE_NAME";
            public const string COMPANY_CODE = "COMPANY_CODE";
            public const string COMPANY_NAME = "COMPANY_NAME";
            public const string COMPETENCY_CODE = "COMPETENCY_CODE";
            public const string COMPETENCY_NAME = "COMPETENCY_NAME";
            public const string BOX_NAME = "BOX_NAME";
            public const string BOX_NUMBER = "BOX_NUMBER";
            public const string BOX_COMPETENCY_CODE = "BOX_COMPETENCY_CODE";
            public const string BOX_COMPETENCY_NAME = "BOX_COMPETENCY_NAME";
            public const string CREATE_BY = "CREATE_BY";
            public const string CREATE_DATE = "CREATE_DATE";
            public const string UPDATE_BY = "UPDATE_BY";
            public const string UPDATE_DATE = "UPDATE_DATE";
            public const string USE_YN = "USE_YN";
        }

        // SIMON Rental Product History List DataTable
        public struct TB_PRODUCT_HISTORY
        {
            public const string IDENT_NUMBER = "IDENT_NUMBER";
            public const string PRODUCT_NAME = "PRODUCT_NAME";
            public const string PRODUCT_CODE = "PRODUCT_CODE";
            public const string PROPERTY_TYPE_CODE = "PROPERTY_TYPE_CODE";
            public const string PROPERTY_TYPE_NAME = "PROPERTY_TYPE_NAME";
            public const string PROPERTY_PURPOSE_CODE = "PROPERTY_PURPOSE_CODE";
            public const string PROPERTY_PURPOSE_NAME = "PROPERTY_PURPOSE_NAME";
            public const string COMPANY_CODE = "COMPANY_CODE";
            public const string COMPANY_NAME = "COMPANY_NAME";
            public const string COMPETENCY_CODE = "COMPETENCY_CODE";
            public const string COMPETENCY_NAME = "COMPETENCY_NAME";
            public const string USER_ID = "USER_ID";
            public const string NOTE = "NOTE";
            public const string PRODUCT_RENTAL_TIME = "PRODUCT_RENTAL_TIME";
            public const string PRODUCT_RETURN_TIME = "PRODUCT_RETURN_TIME";
            public const string PRODUCT_SAMPLE_RENTAL_TIME = "PRODUCT_SAMPLE_RENTAL_TIME";
            public const string PRODUCT_SAMPLE_RETURN_TIME = "PRODUCT_SAMPLE_RETURN_TIME";
            public const string PRODUCT_STATUS_CODE = "PRODUCT_STATUS_CODE";
            public const string PRODUCT_STATUS_NAME = "PRODUCT_STATUS_NAME";
            public const string BOX_NAME = "BOX_NAME";      // 박스이름 대한 정보 입력 ( 17.1.20) 
            public const string BOX_NUMBER = "BOX_NUMBER";  // 박스번호 대한 정보 입력 ( 17.1.20) 
            public const string USE_YN = "USE_YN";
            
        }

        public struct TB_BOX_INFO
        {
            public const string BOX_NUMBER = "BOX_NUMBER";
            public const string BOX_NAME = "BOX_NAME";
            public const string BOX_COMPETENCY = "BOX_COMPETENCY";
        }
        public struct TB_BOX_SERIAL_NO
        {
            public const string BOX_SERIAL_NO = "BOX_SERIAL_NO";
        }
        public struct CONFIG
        {
            public const string SERVER_URL = "SERVER_URL";
            public const string DBCONNECTION = "DBCONNECTION";
            public const string ERRLOG_PATH = "ERRLOG_PATH";
            public const string WORKLOG_PATH = "WORKLOG_PATH";
            public const string SAVE_IMAGE_PATH = "SAVE_IMAGE_PATH";
            public const string VISION_IP = "VISION_IP";
            public const string VISION_DATA_PORT = "VISION_DATA_PORT";
            public const string VISION_IMAGE_PORT = "VISION_IMAGE_PORT";
            public const string PRINTER_IP = "PRINTER_IP";
            public const string PRINTER_PORT = "PRINTER_PORT";
            public const string PLC_IP = "PLC_IP";
            public const string PLC_PORT = "PLC_PORT";
            public const string KEIDAS_IP = "KEIDAS_IP";
            public const string KEIDAS_PORT = "KEIDAS_PORT";
            public const string RFID_PORT = "RFID_PORT";
            public const string RFID_BAUD = "RFID_BAUD";
            public const string RFID_DATA = "RFID_DATA";
            public const string RFID_PARITY = "RFID_PARITY";
            public const string RFID_STOP = "RFID_STOP";
            public const string RFID_FLOW = "RFID_FLOW";
            public const string RFID_ANT = "RFID_ANT";
            public const string RFID_DISP_PORT = "RFID_DISP_PORT";
            public const string RFID_DISP_BAUD = "RFID_DISP_BAUD";
            public const string RFID_DISP_DATA = "RFID_DISP_DATA";
            public const string RFID_DISP_PARITY = "RFID_DISP_PARITY";
            public const string RFID_DISP_STOP = "RFID_DISP_STOP";
            public const string RFID_DISP_FLOW = "RFID_DISP_FLOW";
            public const string SCANNER_PORT = "SCANNER_PORT";
            public const string SCANNER_BAUD = "SCANNER_BAUD";
            public const string SCANNER_DATA = "SCANNER_DATA";
            public const string SCANNER_PARITY = "SCANNER_PARITY";
            public const string SCANNER_STOP = "SCANNER_STOP";
            public const string SCANNER_FLOW = "SCANNER_FLOW";
            public const string SCANNER_FOOTER = "SCANNER_FOOTER";
            public const string EJECT_USE = "EJECT_USE";
            public const string LABEL_USE = "LABEL_USE";
            public const string RFID_IP = "RFID_IP";

            public const string HANDSCANNER_PORT = "HANDSCANNER_PORT";
            public const string HANDSCANNER_BAUD = "HANDSCANNER_BAUD";
            public const string HANDSCANNER_DATA = "HANDSCANNER_DATA";
            public const string HANDSCANNER_PARITY = "HANDSCANNER_PARITY";
            public const string HANDSCANNER_STOP = "HANDSCANNER_STOP";

            /// <summary>
            /// 이상현
            /// </summary>
            public const string LABEL_PRINTER_NAME = "LABEL_PRINTER_NAME";
        }
    }
}
