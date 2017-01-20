using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEFINES
{
    static class Constants
    {
        public const int BARCODEDATA_DIVISION_MAX = 6;
        public const int PROPERTY_TYPE = 0;
        public const int PROPERTY_PURPOSE = 1;
        public const int COMPANY = 2;
        public const int COMPETENCY = 3;
        public const int IDENT_NUMBER = 4;
        public const int PRODUCT_CODE = 5;

        public const int BOX_BARCODEDATA_DIVISION_MAX = 2;
        public const int BOX_DATA = 0;
        public const int BOX_IDENT_NUMBER = 1;

        public const int PRODUCT_BARCODE = 0;
        public const int BOX_BARCODE = 1;
    }

    static class AlramLevel
    {
        public const int SUMMARY_ALRAM = 0;
        public const int MESSAGEBOX_OK_ALRAM = 1;
        public const int MESSAGEBOX_YES_NO_ALRAM = 2;
        public const int MESSAGEBOX_OK_CANCLE_ALRAM = 3;
        public const int MESSAGEBOX_RETRY_STOP_CANCLE_ALRAM = 4;
    }

    static class MsgBoxLevel
    {
        public const int MSG_OK = 0;
        public const int MSG_YES_NO = 1;
        public const int MSG_OK_CANCLE = 2;
        public const int MSG_RETRY_STOP_CANCLE = 3;
    }
}
