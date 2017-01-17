using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;
using DEFINES;
using Product_Manage_System.Classes;

namespace Product_Manage_System
{
    public partial class FormReturn : Form
    {
        private TurckBarcodeData _barcodedata;

        public FormReturn()
        {
            InitializeComponent();
        }

        private void FormReturn_Load(object sender, EventArgs e)
        {
            this.tbProductName.Text = string.Empty;
            this.tbProductCode.Text = string.Empty;

            this.setDataGridView();

            _barcodedata = new TurckBarcodeData();

            try
            {
                Config.connectScaner(ref barcodeSerialPort);
            }
            catch (Exception ex)
            {
                FormMSG msgEx2 = new FormMSG(ex.Message, true);
                msgEx2.ShowDialog();
            }
        }

        private void setInputData(string _productCode, string _identNumber)
        {
            this.tbProductCode.Text = _productCode;
            this.tbInputIdentNumber.Text = _identNumber;
        }

        // Product Table 조회
        // 입력값 : 제품명, 제품코드 입력값 없을 경우 전체조회
        // 상단 그리드 : TB_PRODUCT_INFO, 하단그리드 : TB_PRODUCT_HISTORY			
        private void setDataGridView()
        {
            DataTable dtList = null;

            // Product Info 조회
            if (DBMan.SelectProductInfoList(tbProductName.Text, tbProductCode.Text, false, out dtList))
            {
                dgListInfo.Rows.Clear();

                foreach (DataRow row in dtList.Rows)
                {
                    DataGridViewRow rowItem = new DataGridViewRow();
                    rowItem.CreateCells(dgListInfo);

                    rowItem.Cells[0].Value = row[COLUMNS.TB_PRODUCT_INFO.PROPERTY_TYPE_NAME].ToString();
                    rowItem.Cells[1].Value = row[COLUMNS.TB_PRODUCT_INFO.PROPERTY_TYPE_CODE].ToString();
                    rowItem.Cells[2].Value = row[COLUMNS.TB_PRODUCT_INFO.PROPERTY_PURPOSE_NAME].ToString();
                    rowItem.Cells[3].Value = row[COLUMNS.TB_PRODUCT_INFO.PROPERTY_PURPOSE_CODE].ToString();
                    rowItem.Cells[4].Value = row[COLUMNS.TB_PRODUCT_INFO.COMPANY_NAME].ToString();
                    rowItem.Cells[5].Value = row[COLUMNS.TB_PRODUCT_INFO.COMPANY_CODE].ToString();
                    rowItem.Cells[6].Value = row[COLUMNS.TB_PRODUCT_INFO.COMPETENCY_NAME].ToString();
                    rowItem.Cells[7].Value = row[COLUMNS.TB_PRODUCT_INFO.COMPETENCY_CODE].ToString();
                    rowItem.Cells[8].Value = row[COLUMNS.TB_PRODUCT_INFO.IDENT_NUMBER].ToString();
                    rowItem.Cells[9].Value = row[COLUMNS.TB_PRODUCT_INFO.PRODUCT_CODE].ToString();
                    rowItem.Cells[10].Value = row[COLUMNS.TB_PRODUCT_INFO.PRODUCT_NAME].ToString();

                    rowItem.Tag = row;

                    dgListInfo.Rows.Add(rowItem);
                }

                //if ( dgListInfo.RowCount > 0 )
                //{
                //    string msg = string.Empty;

                //    if(tbProductName.Text.Length > 0)
                //    {
                //        msg += "제품명 : " + tbProductName.Text;
                //    }

                //    if (tbProductCode.Text.Length > 0)
                //    {
                //        msg += "제품코드 : " + tbProductCode.Text;
                //    }

                //    if (tbProductName.Text.Length > 0 || tbProductCode.Text.Length > 0)
                //    {
                //        msg += "의 ";
                //    }

                //    this.tbMessage.ForeColor = Color.Green;
                //    this.tbMessage.Text = "데모목록 조회가 정상처리 되었습니다.";

                //    this.stIco.BackgroundImage = Image.FromFile(@"Image\\stIcoGreen.jpg");
                //}
            }
            
            // Product History 조회
            if (DBMan.SelectProductRentalList(tbProductName.Text, tbProductCode.Text, tbUserId.Text, "", tbInputIdentNumber.Text, false, false, out dtList))
            {
                dgListUser.Rows.Clear();

                foreach (DataRow row in dtList.Rows)
                {
                    DataGridViewRow rowItem = new DataGridViewRow();
                    rowItem.CreateCells(dgListUser);

                    rowItem.Cells[0].Value = row[COLUMNS.TB_PRODUCT_HISTORY.PROPERTY_TYPE_NAME].ToString();
                    rowItem.Cells[1].Value = row[COLUMNS.TB_PRODUCT_HISTORY.PROPERTY_TYPE_CODE].ToString();
                    rowItem.Cells[2].Value = row[COLUMNS.TB_PRODUCT_HISTORY.PROPERTY_PURPOSE_NAME].ToString();
                    rowItem.Cells[3].Value = row[COLUMNS.TB_PRODUCT_HISTORY.PROPERTY_PURPOSE_CODE].ToString();
                    rowItem.Cells[4].Value = row[COLUMNS.TB_PRODUCT_HISTORY.COMPANY_NAME].ToString();
                    rowItem.Cells[5].Value = row[COLUMNS.TB_PRODUCT_HISTORY.COMPANY_CODE].ToString();
                    rowItem.Cells[6].Value = row[COLUMNS.TB_PRODUCT_HISTORY.COMPETENCY_NAME].ToString();
                    rowItem.Cells[7].Value = row[COLUMNS.TB_PRODUCT_HISTORY.COMPETENCY_CODE].ToString();
                    rowItem.Cells[8].Value = row[COLUMNS.TB_PRODUCT_HISTORY.IDENT_NUMBER].ToString();
                    rowItem.Cells[9].Value = row[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_CODE].ToString();
                    rowItem.Cells[10].Value = row[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_NAME].ToString();
                    rowItem.Cells[11].Value = row[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_RENTAL_TIME].ToString();
                    rowItem.Cells[12].Value = row[COLUMNS.TB_PRODUCT_HISTORY.NOTE].ToString();

                    rowItem.Tag = row;

                    dgListUser.Rows.Add(rowItem);
                }
            }
        }

        // 조회버튼 클릭 이벤트
        // 입력값 있을 시 입력값 기준 조회
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            setDataGridView();
        }

        private void tbProductCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchBtn.PerformClick();
            }
        }

        private void tbProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchBtn.PerformClick();
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Clear_Product_InputData();
        }

        private void ReturnBtn_Click(object sender, EventArgs e)
        {
            ReturnProduct();
            Clear_Product_InputData();
        }

        private void dgListUser_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Select_Product_InputData();
        }

        private void dgListUser_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ReturnProduct();
            Clear_Product_InputData();
        }

        private void ReturnProduct()
        {
            if (tbInputProductName.TextLength == 0)
            {
                this.tbMessage.ForeColor = Color.Yellow;
                this.tbMessage.Text = "반납 제품이 선택되지 않았습니다.";

                this.stIco.BackgroundImage = Image.FromFile(@"Image\\stIcoYellow.jpg");
                return;
            }
            DataGridViewRow dr = dgListUser.SelectedRows[0];
            DataTable dt = new DataTable();

            dt.TableName = TABLES.TB_USER_ROLE;
            dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.IDENT_NUMBER);
            dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.PRODUCT_CODE);
            dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.PRODUCT_NAME);
            dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.PROPERTY_TYPE_CODE);
            dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.PROPERTY_TYPE_NAME);
            dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.PROPERTY_PURPOSE_CODE);
            dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.PROPERTY_PURPOSE_NAME);
            dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.COMPANY_CODE);
            dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.COMPANY_NAME);
            dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.COMPETENCY_CODE);
            dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.COMPETENCY_NAME);
            dt.Columns.Add(COLUMNS.TB_PRODUCT_INFO.USE_YN);
            DataRow rowProduct = dt.NewRow();

            // ident number , product code, product name 
            rowProduct[COLUMNS.TB_PRODUCT_INFO.IDENT_NUMBER] = dr.Cells[8].Value.ToString();
            rowProduct[COLUMNS.TB_PRODUCT_INFO.PRODUCT_CODE] = dr.Cells[9].Value.ToString();
            rowProduct[COLUMNS.TB_PRODUCT_INFO.PRODUCT_NAME] = dr.Cells[10].Value.ToString();
            // rowProduct[COLUMNS.TB_PRODUCT_INFO.USE_YN] = 1;

            if (DBMan.ReturnProductInfo(rowProduct))
            {
                //btnCancel.PerformClick();
                setDataGridView();
            }
            else
            {
                FormMSG msgF = new FormMSG("제품 반납 실패", "OK", true);
                msgF.ShowDialog();
            }
        }

        private void Clear_Product_InputData()
        {
            tbInputProductName.Text = "";
            tbInputProductCode.Text = "";
            tbInputIdentNumber.Text = "";
            tbInputPropertyTypeName.Text = "";
            tbInputPropertyTypeCode.Text = "";
            tbInputPropertyPurposeName.Text = "";
            tbInputPropertyPurposeCode.Text = "";
            tbInputCompanyName.Text = "";
            tbInputCompanyCode.Text = "";
            tbInputCompetencyName.Text = "";
            tbInputCompetencyCode.Text = "";
            tbReturnDate.Text = "";
            tbInputNote.Text = "";
        }

        private void Select_Product_InputData()
        {
            DataGridViewRow dr = dgListUser.SelectedRows[0];

            tbInputProductName.Text = dr.Cells[10].Value.ToString();
            tbInputProductCode.Text = dr.Cells[9].Value.ToString();
            tbInputIdentNumber.Text = dr.Cells[8].Value.ToString();
            tbInputPropertyTypeName.Text = dr.Cells[0].Value.ToString();
            tbInputPropertyTypeCode.Text = dr.Cells[1].Value.ToString();
            tbInputPropertyPurposeName.Text = dr.Cells[2].Value.ToString();
            tbInputPropertyPurposeCode.Text = dr.Cells[3].Value.ToString();
            tbInputCompanyName.Text = dr.Cells[4].Value.ToString();
            tbInputCompanyCode.Text = dr.Cells[5].Value.ToString();
            tbInputCompetencyName.Text = dr.Cells[6].Value.ToString();
            tbInputCompetencyCode.Text = dr.Cells[7].Value.ToString();
            tbReturnDate.Text = dr.Cells[11].Value.ToString();
            tbInputNote.Text = dr.Cells[12].Value.ToString();
        }

        // 버튼 이미지 변경 이벤트
        // MouseHover, MouseLeave 시 버튼의 이미지 변경
        private void ButtonImageChange(string _menuName, string _eventtype)
        {
            try
            {
                Image img = Image.FromFile(@"Image\\" + _menuName + _eventtype + ".jpg");

                if (_menuName == "ReturnBtn")
                {
                    ReturnBtn.BackgroundImage = img;
                }
                else if (_menuName == "CancelBtn")
                {
                    CancelBtn.BackgroundImage = img;
                }
                else if (_menuName == "SearchBtn")
                {
                    SearchBtn.BackgroundImage = img;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReturnBtn_MouseHover(object sender, EventArgs e)
        {
            ButtonImageChange("ReturnBtn", "Hover");
        }

        private void ReturnBtn_MouseLeave(object sender, EventArgs e)
        {
            ButtonImageChange("ReturnBtn", "Leave");
        }

        private void CancelBtn_MouseHover(object sender, EventArgs e)
        {
            ButtonImageChange("CancelBtn", "Hover");
        }

        private void CancelBtn_MouseLeave(object sender, EventArgs e)
        {
            ButtonImageChange("CancelBtn", "Leave");
        }

        private void SearchBtn_MouseHover(object sender, EventArgs e)
        {
            ButtonImageChange("SearchBtn", "Hover");
        }

        private void SearchBtn_MouseLeave(object sender, EventArgs e)
        {
            ButtonImageChange("SearchBtn", "Leave");
        }

        public delegate void barcodeDel(string scanData);
        private void barcodeSerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string _strBarcode = sp.ReadExisting();

            this.BeginInvoke(new barcodeDel(this.RecevieScanData), _strBarcode);
        }

        private void RecevieScanData(string data)
        {
            string strTemp = "F-D-T-PS-000002-2578112";
            _barcodedata.SetData(strTemp);
            if (_barcodedata.Decodable())
            {
                _barcodedata.Decode();
            }
            
            if (tbInputProductCode.Text == _barcodedata.GetProductCode())
            {
                ReturnProduct();
                Clear_Product_InputData();
            }
            else
            {
                setInputData(_barcodedata.GetProductCode(), _barcodedata.GetIdentNumber());
                setDataGridView();

                if (dgListUser.RowCount > 0)
                {
                    Select_Product_InputData();
                }
                else 
                {
                    this.tbMessage.ForeColor = Color.Yellow;
                    this.tbMessage.Text = "반납 제품이 선택되지 않았습니다.";
                    
                    this.stIco.BackgroundImage = Image.FromFile(@"Image\\stIcoYellow.jpg");
                    return;
                }
            }
        }

        private void FormReturn_FormClosing(object sender, FormClosingEventArgs e)
        {
            barcodeSerialPort.Close();
        }

        public void DisConnectScaner()
        {
            try
            {
                Config.disconnectScanner(ref barcodeSerialPort);
            }
            catch (Exception ex)
            {
                FormMSG msgEx2 = new FormMSG(ex.Message, true);
                msgEx2.ShowDialog();
            }
        }
    }
}
