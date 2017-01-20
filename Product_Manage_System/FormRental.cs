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
//using Microsoft.Speech;
//using Microsoft.Speech.Synthesis;

namespace Product_Manage_System
{
    public partial class FormRental : Form
    {
        private TurckBarcodeData _barcodedata;
        public delegate void barcodeDel(string scanData);

        //SpeechSynthesizer ts = new SpeechSynthesizer();

        public FormRental()
        {
            InitializeComponent();
        }

        // Form Load 이벤트
        // Form Load 시 리스트 데이터 조회
        private void FormRental_Load(object sender, EventArgs e)
        {
            this.tbProductName.Text = string.Empty;
            this.tbProductCode.Text = string.Empty;

            this.setDataGridView();

            tbProductName.Text = string.Empty;

            _barcodedata = new TurckBarcodeData();

            try
            {
                Config.connectScaner(ref barcodeSerialPort);
            }
            catch (Exception ex)
            {
                FormMSG msgEx2 = new FormMSG(ex.Message, MsgBoxLevel.MSG_OK);
                msgEx2.ShowDialog();
            }
        }

        private void setInputData(string _productCode, string _identNumber)
        {
            try
            {
                this.tbProductCode.Text = _productCode;
                this.tbInputIdentNumber.Text = _identNumber;
            }
            catch (Exception ex)
            {
                FormMSG msgEx2 = new FormMSG(ex.Message, MsgBoxLevel.MSG_OK);
                msgEx2.ShowDialog();
            }
        }

        // Product Table 조회
        // 입력값 : 제품명, 제품코드 입력값 없을 경우 전체조회
        // 상단 그리드 : TB_PRODUCT_INFO, 하단그리드 : TB_PRODUCT_HISTORY			
        private void setDataGridView()
        {
            DataTable dtList = null;

            // Product Info 조회
            try
            {
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
                        rowItem.Cells[11].Value = row[COLUMNS.TB_PRODUCT_INFO.BOX_NAME].ToString();
                        rowItem.Cells[12].Value = row[COLUMNS.TB_PRODUCT_INFO.BOX_NUMBER].ToString();
                        rowItem.Tag = row;

                        dgListInfo.Rows.Add(rowItem);
                    }
                }

                // Product History 조회
                if (DBMan.SelectProductRentalList(tbProductName.Text, tbProductCode.Text, Common.strUSER_ID, "RT", "", false, false, out dtList))
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
            catch (Exception ex)
            {
                FormMSG msgEx2 = new FormMSG(ex.Message, MsgBoxLevel.MSG_OK);
                msgEx2.ShowDialog();
            }
        }

        // Product Info List 클릭 이벤트
        // 대여 입력폼에 데이터 입력
        private void dgListInfo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Select_Product_InputData();
        }

        private void Select_Product_InputData()
        {
            DataGridViewRow dr = dgListInfo.SelectedRows[0];

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
        }

        // 대여버튼 클릭 이벤트
        // 대여 입력폼의 데이터 DB에 저장
        private void RentalBtn_Click(object sender, EventArgs e)
        {
            RentalProduct();
        }

        private void RentalProduct()
        {
            if (tbInputProductName.TextLength == 0)
            {
                this.stIco.BackgroundImage = Image.FromFile(@"Image\\stIcoyellow.jpg");

                this.tbMessage.ForeColor = Color.Yellow;
                this.tbMessage.Text = "제품이 선택되지 않았습니다.";

                return;
            }

            DataTable dtProduct = new DataTable();
            dtProduct.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.IDENT_NUMBER);
            dtProduct.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_CODE);
            dtProduct.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_NAME);
            dtProduct.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.PROPERTY_TYPE_CODE);
            dtProduct.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.PROPERTY_PURPOSE_CODE);
            dtProduct.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.COMPANY_CODE);
            dtProduct.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.COMPETENCY_CODE);
            dtProduct.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.USER_ID);
            dtProduct.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_STATUS_CODE);
            dtProduct.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.NOTE);
            dtProduct.Columns.Add(COLUMNS.TB_PRODUCT_HISTORY.USE_YN);

            DataRow rowProduct = dtProduct.NewRow();
            rowProduct[COLUMNS.TB_PRODUCT_HISTORY.IDENT_NUMBER] = tbInputIdentNumber.Text;
            rowProduct[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_CODE] = tbInputProductCode.Text;
            rowProduct[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_NAME] = tbInputProductName.Text;
            rowProduct[COLUMNS.TB_PRODUCT_HISTORY.PROPERTY_TYPE_CODE] = tbInputPropertyTypeCode.Text;
            rowProduct[COLUMNS.TB_PRODUCT_HISTORY.PROPERTY_PURPOSE_CODE] = tbInputPropertyPurposeCode.Text;
            rowProduct[COLUMNS.TB_PRODUCT_HISTORY.COMPANY_CODE] = tbInputCompanyCode.Text;
            rowProduct[COLUMNS.TB_PRODUCT_HISTORY.COMPETENCY_CODE] = tbInputCompetencyCode.Text;
            rowProduct[COLUMNS.TB_PRODUCT_HISTORY.USER_ID] = Common.strUSER_ID;
            rowProduct[COLUMNS.TB_PRODUCT_HISTORY.NOTE] = tbInputNote.Text;
            rowProduct[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_STATUS_CODE] = "RT";
            rowProduct[COLUMNS.TB_PRODUCT_HISTORY.USE_YN] = "1";

            if (DBMan.InsertProductHistory(rowProduct))
            {
                //ts.SetOutputToDefaultAudioDevice();
                //ts.Speak(tbInputProductName.Text + "제품 대여가 정상처리 되었습니다.");

                CancelBtn.PerformClick();
                setDataGridView();
            }
            else
            {
                //ts.SetOutputToDefaultAudioDevice();
                //ts.Speak(tbInputProductName.Text + "제품 대여가 실패했습니다.");

                FormMSG msgF = new FormMSG("제품 대여 실패", "OK", true);

                msgF.ShowDialog();
            }
        }

        // 조회버튼 클릭 이벤트
        // 입력값 있을 시 입력값 기준 조회
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            setDataGridView();
        }

        // 검색버튼 실행 이벤트
        // 제품명 텍스트 박스 에서 엔터 입력
        private void tbProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchBtn.PerformClick();
            }
        }

        // 검색버튼 실행 이벤트
        // 제품코드 텍스트 박스 에서 엔터 입력
        private void tbIdentNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchBtn.PerformClick();
            }
        }

        // 취소버튼 클릭 이벤트
        // 대여 입력 폼 초기화
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Clear_Product_InputData();
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
            tbInputNote.Text = "";
        }

        private void RecevieScanData(string data)
        {
            try
            {
                //string strTemp = "F-D-T-PS-000002-2578112";
                int dataType;
                _barcodedata.SetData(data);
                dataType = _barcodedata.GetBarcodeDataType();
                if (_barcodedata.Decodable(dataType))
                {
                    _barcodedata.Decode(dataType);
                }

                if (tbInputProductCode.Text == _barcodedata.GetProductCode() && ( tbInputIdentNumber.Text == _barcodedata.GetIdentNumber()))
                {
                    RentalProduct();
                    Clear_Product_InputData();
                }
                else
                {
                    setInputData(_barcodedata.GetProductCode(), _barcodedata.GetIdentNumber());
                    setDataGridView();

                    if (dgListInfo.RowCount > 0)
                    {
                        Select_Product_InputData();
                    }
                    else
                    {
                        this.tbMessage.ForeColor = Color.Yellow;
                        this.tbMessage.Text = "제품이 선택되지 않았습니다.";

                        //ts.SetOutputToDefaultAudioDevice();
                        //ts.Speak("제품이 선택되지 않았습니다.");

                        this.stIco.BackgroundImage = Image.FromFile(@"Image\\stIcoyellow.jpg");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void barcodeSerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string _strBarcode = sp.ReadExisting();

            this.BeginInvoke(new barcodeDel(this.RecevieScanData), _strBarcode);
        }

        // 버튼 이미지 변경 이벤트
        // MouseHover, MouseLeave 시 버튼의 이미지 변경
        private void ButtonImageChange(string _menuName, string _eventtype)
        {
            try
            {
                Image img = Image.FromFile(@"Image\\" + _menuName + _eventtype + ".jpg");

                if (_menuName == "RentalBtn")
                {
                    RentalBtn.BackgroundImage = img;
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

        private void RentalBtn_MouseHover(object sender, EventArgs e)
        {
            ButtonImageChange("RentalBtn", "Hover");
        }

        private void RentalBtn_MouseLeave(object sender, EventArgs e)
        {
            ButtonImageChange("RentalBtn", "Leave");
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
        
        private void FormRental_FormClosing(object sender, FormClosingEventArgs e)
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
                FormMSG msgEx2 = new FormMSG(ex.Message, MsgBoxLevel.MSG_OK);
                msgEx2.ShowDialog();
            }
        }
    }
}
