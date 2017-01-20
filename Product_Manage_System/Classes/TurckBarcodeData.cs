using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DEFINES;

namespace Product_Manage_System
{
    class TurckBarcodeData
    {
        private string propertyType = String.Empty;           // 자산유형 변수 
        private string propertyPurpose = String.Empty;        // 자산목적 변수 
        private string company = String.Empty;                // 회사구분 변수 
        private string competency = String.Empty;             // 제품구분 변수 
        private string identNumber = String.Empty;            // 제품번호 변수 (고유) 
        private string productCode = String.Empty;            // 제품코드 (일련번호)
        private string barcodeData = String.Empty;            // 바코드 string 변수 
        private int barcodeDataLength = 0;      // 바코드 길이 변수 
        private int identLength = 0;            // 제품번호 길이 변수 


        private bool isBoxBarcode = false;
        private string boxIdentNumber = String.Empty;            // 박스 제품번호 변수 고유
        private string boxData = String.Empty;            // 박스 제품번호 변수 고유

        public string GetBoxData()
        {
            return boxData;
        }
        public string GetBoxIdentNumber()
        {
            return boxIdentNumber;
        }
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
            if (data != null)
            {
                barcodeData = string.Empty;
                barcodeData = data;
                barcodeDataLength = barcodeData.Length;
            }
        }
        public void SetBoxData(string boxdata)
        {
            this.boxData = boxdata;
        }
        public void SetBoxIdentNumber(string boxnumber)
        {
            this.boxIdentNumber = boxnumber;
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
            productCode += data;
        }
        public void SetProductCode(string data, string devisionData)
        {
            if (data == null) return;
            productCode += devisionData;
            productCode += data;
        }

        public int GetBarcodeDataType()
        {
            if (barcodeDataLength < 0) return -1;
            char[] delimiters = { '-', ',', '.' };
            string[] wordsSplit = barcodeData.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            int cnt = 0;
            cnt = wordsSplit.Length;
            int datatype = -1;

            if (cnt >= Constants.BARCODEDATA_DIVISION_MAX) datatype = Constants.PRODUCT_BARCODE;
            else if (cnt == Constants.BOX_BARCODEDATA_DIVISION_MAX) datatype = Constants.BOX_BARCODE;

            return datatype;
        }
        public bool Decodable(int type)
        {
            if (barcodeDataLength < 0) return false;
            if (type < 0) return false;
            char[] delimiters = { '-', ',', '.' };
            //string sentence = "F-D-T-SS-1003241";
            string[] wordsSplit = barcodeData.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            int cnt = 0;
            cnt = wordsSplit.Length;
            int dataType = type;

            // 제품 바코드 디코드 가능한지 확인 
            if (dataType == Constants.PRODUCT_BARCODE)
            {
                if (cnt < Constants.BARCODEDATA_DIVISION_MAX) return false;
                for (int i = 0; i < wordsSplit.Length; i++)
                {
                    switch (i)
                    {
                        case Constants.PROPERTY_TYPE:
                        case Constants.PROPERTY_PURPOSE:
                        case Constants.COMPANY:
                            if (wordsSplit[i].Length != 1) return false;
                            break;

                        case Constants.COMPETENCY:
                            if (wordsSplit[i].Length != 2) return false;
                            break;

                        case Constants.IDENT_NUMBER:
                            if (wordsSplit[i].Length < 2) return false;
                            break;
                        case Constants.PRODUCT_CODE:
                            if (wordsSplit[i].Length < 0) return false;
                            break;
                    }
                }
            }
            // 박스 바코드 디코드 가능한지 확인 
            else if (dataType == Constants.BOX_BARCODE)
            {
                if (cnt != Constants.BOX_BARCODEDATA_DIVISION_MAX) return false;
                for (int i = 0; i < wordsSplit.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            if (wordsSplit[i].ToString() != "BOX")
                            {
                                isBoxBarcode = false;
                                return false;
                            }
                            break;
                        case 1:
                            if (wordsSplit[i].Length < 5)
                            {
                                isBoxBarcode = false;
                                return false;
                            }
                            break;
                    }
                }
            }

            return true;
        }

        public void Decode(int type)
        {
            char[] delimiters = { '-', ',', '.' };
            //string sentence = "F-D-T-SS-1003241";
            string[] wordsSplit = barcodeData.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            int dataType = type;

            if (dataType == Constants.PRODUCT_BARCODE)
            {
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
                        case Constants.IDENT_NUMBER:
                            SetIdentNumber(wordsSplit[i]);
                            break;
                        case Constants.PRODUCT_CODE:
                            SetProductCode(wordsSplit[i]);
                            break;
                    }
                    if (i > Constants.PRODUCT_CODE)
                    {
                        SetProductCode(wordsSplit[i], "-");
                    }
                }
            }

            else if (dataType == Constants.BOX_BARCODE)
            {
                for (int i = 0; i < wordsSplit.Length; i++)
                {
                    switch (i)
                    {
                        case Constants.BOX_DATA:
                            SetBoxData(wordsSplit[i]);
                            break;
                        case Constants.BOX_IDENT_NUMBER:
                            SetBoxIdentNumber(wordsSplit[i]);
                            break;
                    }
                }
            }

        }

    }
}
