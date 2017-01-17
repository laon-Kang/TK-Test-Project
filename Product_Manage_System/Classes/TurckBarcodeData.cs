using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DEFINES; 

namespace Product_Manage_System
{
    class TurckBarcodeData
    {
        private string      propertyType    = String.Empty;           // 자산유형 변수 
        private string      propertyPurpose = String.Empty;        // 자산목적 변수 
        private string      company         = String.Empty;                // 회사구분 변수 
        private string      competency      = String.Empty;             // 제품구분 변수 
        private string      identNumber     = String.Empty;            // 제품번호 변수 (고유) 
        private string      productCode     = String.Empty;            // 제품코드 (일련번호)
        private string      barcodeData     = String.Empty;            // 바코드 string 변수 
        private int         barcodeDataLength = 0;      // 바코드 길이 변수 
        private int         identLength     = 0;            // 제품번호 길이 변수 

        public string GetPropertyType()
        {
            return propertyType;
        }

        public string GetPropertyPurpose()
        {
            return propertyPurpose;
        }

        public string GetCompany()
        {
            return company;
        }

        public string GetCompetency()
        {
            return competency;
        }

        public string GetIdentNumber()
        {
            return identNumber;
        }
        public string GetProductCode()
        {
            return productCode; 
        }
        public string GetData()
        {
            return barcodeData;
        }

        public void SetData(string data)
        {
            if( data != null)
            {
                barcodeData = string.Empty;
                barcodeData = data;
                barcodeDataLength = barcodeData.Length;
            }
        }

        public void SetPropertyType(string propertyType)
        {
            this.propertyType = propertyType;
        }

        public void SetPropertyPurpose(string data)
        {
            if (data == null) return;
            propertyPurpose = string.Empty;
            propertyPurpose = data; 
        }
        public void SetCompany(string data)
        {
            if (data == null) return;
            company = string.Empty;
            company = data; 
        }
        public void SetCompetency(string data)
        {
            if (data == null) return;
            competency = string.Empty;
            competency = data; 
        }

        public void SetIdentNumber(string data)
        {
            if (data == null) return;
            identNumber = string.Empty;
            identNumber = data; 
        }
        public void SetProductCode(string data)
        {
            if (data == null) return;
            productCode = string.Empty;
            productCode = data;
        }
        public bool Decodable()
        {
            if (barcodeDataLength < 0) return false;
            char[] delimiters = { '-', ',', '.' };
            //string sentence = "F-D-T-SS-1003241";
            string[] wordsSplit = barcodeData.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            int cnt = 0; 
            cnt = wordsSplit.Length;
            if (cnt != Constants.BARCODEDATA_DIVISION_MAX) return false;
      
            for (int i = 0; i < wordsSplit.Length; i++ )
            {
                switch(i)
                {
                    case Constants.PROPERTY_TYPE:
                    case Constants.PROPERTY_PURPOSE:
                    case Constants.COMPANY:
                        if (wordsSplit[i].Length != 1) return false;
                        break; 

                    case Constants.COMPETENCY:
                        if (wordsSplit[i].Length != 2) return false;
                        break;
                    case Constants.PRODUCT_CODE:
                        if (wordsSplit[i].Length < 5) return false;
                        break; 
                    case Constants.IDENT_NUMBER:
                        if (wordsSplit[i].Length < 5) return false;
                        break;
                }
            }
            return true; 
        }

        public void Decode()
        {
            char[] delimiters = { '-', ',', '.' };
            //string sentence = "F-D-T-SS-1003241";
            string[] wordsSplit = barcodeData.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < wordsSplit.Length; i++)
            {
                switch (i)
                {
                    case Constants.PROPERTY_TYPE:
                        SetPropertyType(wordsSplit[i]);
                        break;
                    case Constants.PROPERTY_PURPOSE:
                        SetPropertyPurpose(wordsSplit[i]);
                        break;
                    case Constants.COMPANY:
                        SetCompany(wordsSplit[i]);
                        break;
                    case Constants.COMPETENCY:
                        SetCompetency(wordsSplit[i]);
                        break;
                    case Constants.PRODUCT_CODE:
                        SetProductCode(wordsSplit[i]);
                        break; 
                    case Constants.IDENT_NUMBER:
                        SetIdentNumber(wordsSplit[i]);
                        break;
                }
            }
        }

    }
}
