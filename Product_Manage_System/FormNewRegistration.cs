using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DEFINES;

namespace Product_Manage_System
{
    public partial class FormNewRegistration : Form
    {

        public FormNewRegistration()
        {
            InitializeComponent();
        }

        public void disconnectScanner()
        {
            try
            {
                if (Hscanner.IsOpen)
                    Hscanner.Close();
            }
            catch (Exception ex)
            {
                FormMSG msgEx2 = new FormMSG(ex.Message, MsgBoxLevel.MSG_OK);
                msgEx2.ShowDialog();
            }
        }

        private void connectScanner()
        {
            try
            {
                if (Hscanner.IsOpen)
                {
                    Hscanner.Close();
                }

                Hscanner.PortName = Config.SCANNER_PORT;
                Hscanner.BaudRate = Int32.Parse(Config.SCANNER_BAUD);

                Hscanner.Open();
            }
            catch (Exception ex)
            {
                FormMSG msgEx2 = new FormMSG(ex.Message, MsgBoxLevel.MSG_OK);
                msgEx2.ShowDialog();
            }
        }

        private void FormpRoductAdd_Load(object sender, EventArgs e)
        {
            ///스캐너 오픈
            connectScanner();

            ///데이터 초기화
            InitData();
        }

        public void oninit(bool binit)
        {
            if (binit)
            {
                ///스캐너 오픈
                connectScanner();

                ///데이터 초기화
                InitData();
            }
        }

        private void InitData()
        {
            try
            {
                cbInitData(PRODUCT_TYPE.PROPERTY_TYPE_CODE, ref cbPROPERTY_TYPE);
                cbInitData(PRODUCT_TYPE.PROPERTY_PURPOSE_CODE, ref cbPROPERTY_PURPOSE);
                cbInitData(PRODUCT_TYPE.COMPANY_CODE, ref cbCOMPANY);
                cbInitData(PRODUCT_TYPE.COMPETENCY_CODE, ref cbCOMPETENCY);

                cbInitData(PRODUCT_TYPE.COMPETENCY_CODE, ref cbBoxCOMPETENCY);

                cbProductLabelSize.Items.Add("1");
                cbProductLabelSize.Items.Add("2");
                cbProductLabelSize.Items.Add("3");
                cbProductLabelSize.Items.Add("4");
                cbProductLabelSize.Items.Add("5");
                cbProductLabelSize.Text = "3";
            }
            catch (Exception ex)
            {
                FormMSG msgEx2 = new FormMSG(ex.Message, MsgBoxLevel.MSG_OK);
                msgEx2.ShowDialog();
            }
        }

        private void cbInitData(string sType, ref ComboBox cb)
        {
            try
            {
                DataTable dt = null;
                ///PROPERTY_TYPE_CODE
                if (DBMan.selectCommonCodeByGroupCode(sType, out dt))
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ComboBoxItem item = new ComboBoxItem();
                        item.Name = row[COLUMNS.TB_COMMON_CODE.COMMON_NAME].ToString();
                        item.Value = row[COLUMNS.TB_COMMON_CODE.COMMON_CODE].ToString();
                        item.Tag = row;

                        cb.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                FormMSG msgEx2 = new FormMSG(ex.Message, MsgBoxLevel.MSG_OK);
                msgEx2.ShowDialog();
            }
        }

        private void cbCOMPANY_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCOMPANY.Text = ((DataRow)((ComboBoxItem)cbCOMPANY.SelectedItem).Tag)[COLUMNS.TB_COMMON_CODE.COMMON_CODE].ToString();
        }

        private void cbCOMPETENCY_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCOMPETENCY.Text = ((DataRow)((ComboBoxItem)cbCOMPETENCY.SelectedItem).Tag)[COLUMNS.TB_COMMON_CODE.COMMON_CODE].ToString();
        }

        private void cbPROPERTY_PURPOSE_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPROPERTY_PURPOSE.Text = ((DataRow)((ComboBoxItem)cbPROPERTY_PURPOSE.SelectedItem).Tag)[COLUMNS.TB_COMMON_CODE.COMMON_CODE].ToString();
        }

        private void cbPROPERTY_TYPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPROPERTY_TYPE.Text = ((DataRow)((ComboBoxItem)cbPROPERTY_TYPE.SelectedItem).Tag)[COLUMNS.TB_COMMON_CODE.COMMON_CODE].ToString();
        }

        public delegate void updateLog(string scanData);
        private void Hscanner_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string readString = Hscanner.ReadExisting();
            readString = readString.Replace("Dm", "");
            readString = readString.Replace("\r", "");
            readString = readString.Replace("\n", "");

            this.BeginInvoke(new updateLog(this.RecevieScanData), readString);
        }

        string ProductId = string.Empty;
        string BoxNumber = string.Empty;
        private void RecevieScanData(string data)
        {
            try
            {
                if (data.Length > 4)
                {
                    if (data.Substring(0, 4) == "BOX-")
                    {
                        ///박스 바코드 스캐너
                        txtBoxNum.Text = data;
                        BoxNumber = data;
                        SearchBoxNum();
                    }
                    else
                    {
                        ///제품 스캐너
                        ProductId = data;
                        txtBarcode.Text = data;

                        ProductInfoSeach();
                    }
                }
            }
            catch (Exception ex)
            {
                FormMSG msgEx = new FormMSG(ex.Message, "OK", true);
                msgEx.ShowDialog();
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (txtBarcode.Text.Length > 0)
                {
                    RecevieScanData(txtBarcode.Text);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ProductInfoSeach();
        }

        private void ProductInfoSeach()
        {
            try
            {
                dgList.Rows.Clear();

                string PROPERTY_TYPE_CODE = string.Empty;
                string PROPERTY_PURPOSE_CODE = string.Empty;
                string COMPANY_CODE = string.Empty;
                string COMPETENCY_CODE = string.Empty;
                string IDENT_NUMBER = string.Empty;

                if (cbPROPERTY_TYPE.Text != "")
                    PROPERTY_TYPE_CODE = ((DataRow)((ComboBoxItem)cbPROPERTY_TYPE.SelectedItem).Tag)[COLUMNS.TB_COMMON_CODE.COMMON_CODE].ToString();

                if (cbPROPERTY_PURPOSE.Text != "")
                    PROPERTY_PURPOSE_CODE = ((DataRow)((ComboBoxItem)cbPROPERTY_PURPOSE.SelectedItem).Tag)[COLUMNS.TB_COMMON_CODE.COMMON_CODE].ToString();

                if (cbCOMPANY.Text != "")
                    COMPANY_CODE = ((DataRow)((ComboBoxItem)cbCOMPANY.SelectedItem).Tag)[COLUMNS.TB_COMMON_CODE.COMMON_CODE].ToString();

                if (cbCOMPETENCY.Text != "")
                    COMPETENCY_CODE = ((DataRow)((ComboBoxItem)cbCOMPETENCY.SelectedItem).Tag)[COLUMNS.TB_COMMON_CODE.COMMON_CODE].ToString();

                if (txtIDENT_NUMBER.Text != "")
                    IDENT_NUMBER = txtIDENT_NUMBER.Text.PadLeft(6, '0');


                DataTable dt = null;
                if (DBMan.selectProductInfo(txtProductName.Text, txtBarcode.Text,
                    PROPERTY_TYPE_CODE, PROPERTY_PURPOSE_CODE, COMPANY_CODE, COMPETENCY_CODE, IDENT_NUMBER,
                    txtBoxName.Text, txtBoxNum.Text, out dt))
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            DataGridViewRow rowItem = new DataGridViewRow();
                            rowItem.CreateCells(dgList);

                            rowItem.Cells[0].Value = row[COLUMNS.TB_PRODUCT_INFO.PRODUCT_NAME].ToString();
                            rowItem.Cells[1].Value = row[COLUMNS.TB_PRODUCT_INFO.PRODUCT_CODE].ToString();
                            rowItem.Cells[2].Value = row[COLUMNS.TB_PRODUCT_INFO.COMPANY_NAME].ToString();
                            rowItem.Cells[3].Value = row[COLUMNS.TB_PRODUCT_INFO.COMPETENCY_NAME].ToString();
                            rowItem.Cells[4].Value = row[COLUMNS.TB_PRODUCT_INFO.PROPERTY_PURPOSE_NAME].ToString();
                            rowItem.Cells[5].Value = row[COLUMNS.TB_PRODUCT_INFO.PROPERTY_TYPE_NAME].ToString();
                            rowItem.Cells[6].Value = row[COLUMNS.TB_PRODUCT_INFO.IDENT_NUMBER].ToString();
                            rowItem.Cells[7].Value = row[COLUMNS.TB_PRODUCT_INFO.BOX_NAME].ToString();
                            rowItem.Cells[8].Value = row[COLUMNS.TB_PRODUCT_INFO.BOX_NUMBER].ToString();
                            rowItem.Cells[9].Value = row[COLUMNS.TB_PRODUCT_INFO.BOX_COMPETENCY_CODE].ToString();
                            rowItem.Cells[10].Value = row[COLUMNS.TB_PRODUCT_INFO.BOX_COMPETENCY_NAME].ToString();

                            rowItem.Tag = row;

                            dgList.Rows.Add(rowItem);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FormMSG msgEx = new FormMSG(ex.Message, "OK", true);
                msgEx.ShowDialog();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbCOMPANY.Text == "")
            {
                FormMSG msgEx = new FormMSG("회사구분을 입력해 주세요.", "OK", true);
                msgEx.ShowDialog();
                return;
            }

            if (cbCOMPETENCY.Text == "")
            {
                FormMSG msgEx = new FormMSG("제품군 구분을 입력해 주세요.", "OK", true);
                msgEx.ShowDialog();
                return;
            }

            if (cbPROPERTY_PURPOSE.Text == "")
            {
                FormMSG msgEx = new FormMSG("자산구분을 입력해 주세요.", "OK", true);
                msgEx.ShowDialog();
                return;
            }

            if (cbPROPERTY_TYPE.Text == "")
            {
                FormMSG msgEx = new FormMSG("자산유형을 입력해 주세요.", "OK", true);
                msgEx.ShowDialog();
                return;
            }

            if (txtBarcode.Text == "")
            {
                FormMSG msgEx = new FormMSG("제품코드를 입력해 주세요.", "OK", true);
                msgEx.ShowDialog();
                return;
            }

            if (txtProductName.Text == "")
            {
                FormMSG msgEx = new FormMSG("제품명을 입력해 주세요.", "OK", true);
                msgEx.ShowDialog();
                return;
            }

            if (txtBoxNum.Text == "")
            {
                FormMSG msgEx = new FormMSG("박스번호를 입력해 주세요.", "OK", true);
                msgEx.ShowDialog();
                return;
            }

            if (txtBoxName.Text == "")
            {
                FormMSG msgEx = new FormMSG("박스명을 입력해 주세요.", "OK", true);
                msgEx.ShowDialog();
                return;
            }

            if (cbBoxCOMPETENCY.Text == "")
            {
                FormMSG msgEx = new FormMSG("박스제품군을 입력해 주세요.", "OK", true);
                msgEx.ShowDialog();
                return;
            }

            ///박스 검색
            if (!SearchBoxNum())
                return;


            ///제품 검색 후 DB 등록
            if (SearchProductInfo_Add())
            {
                printBoxLabel_PRODUCT();
            }
            else
            {
                ///DB등록에 실패 했으면
                FormMSG msgEx = new FormMSG("제품 등록에 실패 하였습니다.", "OK", true);
                msgEx.ShowDialog();
                return;
            }
        }

        private void btnBoxPrint_Click(object sender, EventArgs e)
        {
            if (txtBoxNum.Text != "")
            {
                ///재발행
                if (!SearchBoxNum())
                    return;

                ///박스 프린트
                FormMSG msgF = new FormMSG("[박스명 : " + txtBoxName.Text + "] 를 재발행 하시겠습니까?", "YN", false);
                if (msgF.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;

                printBoxLabel_Box();
            }
            else
            {
                FormMSG msgF = new FormMSG("박스 정보를 신규 등록 하시겠습니까?", "YN", false);
                if (msgF.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;

                if (txtBoxName.Text == "")
                {
                    FormMSG msgEx = new FormMSG("박스명을 입력해 주세요.", "OK", true);
                    msgEx.ShowDialog();
                    return;
                }

                if (cbBoxCOMPETENCY.Text == "")
                {
                    FormMSG msgEx = new FormMSG("박스제품군을 입력해 주세요.", "OK", true);
                    msgEx.ShowDialog();
                    return;
                }

                ///신규 박스 번호
                string BOX_SERIAL_NO = string.Empty;
                DBMan.selectBoxSeiral(out BOX_SERIAL_NO);

                if (BOX_SERIAL_NO == "")
                {
                    FormMSG msgEx = new FormMSG("박스 일련번호 로딩에 실패 하였습니다.", "OK", true);
                    msgEx.ShowDialog();
                    return;
                }

                long nBoxSerialNo = long.Parse(BOX_SERIAL_NO) + 1;
                DBMan.UpdateBoxSeiral(nBoxSerialNo.ToString());

                txtBoxNum.Text = "BOX-" + BOX_SERIAL_NO.PadLeft(6, '0');
                DBMan.InsertBoxInfo(txtBoxName.Text, txtBoxNum.Text, txtBoxCOMPETENCY.Text);

                ///박스 프린트
                printBoxLabel_Box();
            }
        }

        private bool SearchBoxNum()
        {
            bool bRt = false;

            try
            {
                if (txtBoxNum.Text != "")
                {
                    string BoxName = string.Empty;
                    string BoxCompetency = string.Empty;
                    DBMan.selectBoxInfo(txtBoxNum.Text, out BoxName, out BoxCompetency);

                    if (BoxName == "")
                    {
                        FormMSG msgEx = new FormMSG("박스 정보가 올바르지 않습니다.", "OK", true);
                        msgEx.ShowDialog();
                        return false;
                    }

                    txtBoxName.Text = BoxName;

                    string sCompentency = string.Empty;
                    foreach (ComboBoxItem item in cbBoxCOMPETENCY.Items)
                    {
                        DataRow row = (DataRow)item.Tag;
                        if (row[COLUMNS.TB_COMMON_CODE.COMMON_CODE].ToString() == BoxCompetency)
                        {
                            sCompentency = row[COLUMNS.TB_COMMON_CODE.COMMON_NAME].ToString();
                        }
                    }

                    if (sCompentency != "")
                    {
                        cbBoxCOMPETENCY.Text = sCompentency;
                        txtBoxCOMPETENCY.Text = BoxCompetency;
                    }
                    else
                    {
                        FormMSG msgEx = new FormMSG("박스제품군이 올바르지 않습니다.", "OK", true);
                        msgEx.ShowDialog();
                        return false;
                    }

                    return true;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                FormMSG msgEx = new FormMSG(ex.Message, "OK", true);
                msgEx.ShowDialog();
            }
            return bRt;
        }

        private bool SearchProductInfo_Add()
        {
            bool bRt = false;
            try
            {
                DataTable dt = null;
                if (DBMan.selectProductInfo(txtProductName.Text, txtBarcode.Text,
                    "", "", "", "", "",
                    "", "", out dt))
                {
                    if (dt.Rows.Count > 0)
                    {
                        /// 등록되어 있는 제품이 있는 경우
                        FormMSG msgF = new FormMSG("등록되어 있는 제품이 있습니다.\r\n신규 등록이 맞습니까?", "YN", false);
                        if (msgF.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                            return false;

                        long nMaxIdentiNum = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            long nNum = long.Parse(row[COLUMNS.TB_PRODUCT_INFO.IDENT_NUMBER].ToString());
                            if (nMaxIdentiNum < nNum)
                                nMaxIdentiNum = nNum;
                        }

                        txtIDENT_NUMBER.Text = (nMaxIdentiNum + 1).ToString().PadLeft(6, '0');

                        FormMSG msgX = new FormMSG("[IDENTI NUM : " + txtIDENT_NUMBER.Text + "] 신규 등록합니다.\r\n계속 하시겠습니까?", "YN", false);
                        if (msgX.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                            return false;
                    }
                    else
                    {
                        FormMSG msgF = new FormMSG("등록되어 있는 제품이 없습니다.\r\n신규 등록 할까요?", "YN", false);
                        if (msgF.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                            return false;

                        txtIDENT_NUMBER.Text = "000001";
                    }

                    string PROPERTY_TYPE_CODE = string.Empty;
                    string PROPERTY_PURPOSE_CODE = string.Empty;
                    string COMPANY_CODE = string.Empty;
                    string COMPETENCY_CODE = string.Empty;
                    string IDENT_NUMBER = string.Empty;

                    string BOX_COMPETENCY_CODE = string.Empty;

                    if (cbPROPERTY_TYPE.Text != "")
                        PROPERTY_TYPE_CODE = ((DataRow)((ComboBoxItem)cbPROPERTY_TYPE.SelectedItem).Tag)[COLUMNS.TB_COMMON_CODE.COMMON_CODE].ToString();

                    if (cbPROPERTY_PURPOSE.Text != "")
                        PROPERTY_PURPOSE_CODE = ((DataRow)((ComboBoxItem)cbPROPERTY_PURPOSE.SelectedItem).Tag)[COLUMNS.TB_COMMON_CODE.COMMON_CODE].ToString();

                    if (cbCOMPANY.Text != "")
                        COMPANY_CODE = ((DataRow)((ComboBoxItem)cbCOMPANY.SelectedItem).Tag)[COLUMNS.TB_COMMON_CODE.COMMON_CODE].ToString();

                    if (cbCOMPETENCY.Text != "")
                        COMPETENCY_CODE = ((DataRow)((ComboBoxItem)cbCOMPETENCY.SelectedItem).Tag)[COLUMNS.TB_COMMON_CODE.COMMON_CODE].ToString();

                    if (cbBoxCOMPETENCY.Text != "")
                        BOX_COMPETENCY_CODE = ((DataRow)((ComboBoxItem)cbBoxCOMPETENCY.SelectedItem).Tag)[COLUMNS.TB_COMMON_CODE.COMMON_CODE].ToString();

                    if (txtIDENT_NUMBER.Text != "")
                        IDENT_NUMBER = txtIDENT_NUMBER.Text.PadLeft(6, '0');

                    if (DBMan.InsertProductAdd(txtProductName.Text, txtBarcode.Text,
                    PROPERTY_TYPE_CODE, PROPERTY_PURPOSE_CODE, COMPANY_CODE, COMPETENCY_CODE, IDENT_NUMBER,
                    txtBoxName.Text, txtBoxNum.Text, BOX_COMPETENCY_CODE))
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                FormMSG msgEx = new FormMSG(ex.Message, "OK", true);
                msgEx.ShowDialog();
            }
            return bRt;
        }

        private void printBoxLabel_Box()
        {
            USBPrinter.SendStringZPL_BOX(Config.LABEL_PRINTER_NAME, txtBoxName.Text, txtBoxNum.Text, cbBoxCOMPETENCY.Text);
        }

        private void printBoxLabel_PRODUCT()
        {
            string Barcode = txtPROPERTY_TYPE.Text + "-" + txtPROPERTY_PURPOSE.Text + "-" + txtCOMPANY.Text + "-" +
                txtCOMPETENCY.Text + "-" + txtIDENT_NUMBER.Text + "-" + txtBarcode.Text;

            USBPrinter.SendStringZPL_PRODUCT(Config.LABEL_PRINTER_NAME, txtProductName.Text, Barcode, cbProductLabelSize.Text, cbCOMPETENCY.Text);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (cbCOMPANY.Text == "")
            {
                FormMSG msgEx = new FormMSG("회사구분을 입력해 주세요.", "OK", true);
                msgEx.ShowDialog();
                return;
            }

            if (cbCOMPETENCY.Text == "")
            {
                FormMSG msgEx = new FormMSG("제품군 구분을 입력해 주세요.", "OK", true);
                msgEx.ShowDialog();
                return;
            }

            if (cbPROPERTY_PURPOSE.Text == "")
            {
                FormMSG msgEx = new FormMSG("자산구분을 입력해 주세요.", "OK", true);
                msgEx.ShowDialog();
                return;
            }

            if (cbPROPERTY_TYPE.Text == "")
            {
                FormMSG msgEx = new FormMSG("자산유형을 입력해 주세요.", "OK", true);
                msgEx.ShowDialog();
                return;
            }

            if (txtBarcode.Text == "")
            {
                FormMSG msgEx = new FormMSG("제품코드를 입력해 주세요.", "OK", true);
                msgEx.ShowDialog();
                return;
            }

            if (txtProductName.Text == "")
            {
                FormMSG msgEx = new FormMSG("제품명을 입력해 주세요.", "OK", true);
                msgEx.ShowDialog();
                return;
            }

            if (txtBoxNum.Text == "")
            {
                FormMSG msgEx = new FormMSG("박스번호를 입력해 주세요.", "OK", true);
                msgEx.ShowDialog();
                return;
            }

            if (txtBoxName.Text == "")
            {
                FormMSG msgEx = new FormMSG("박스명을 입력해 주세요.", "OK", true);
                msgEx.ShowDialog();
                return;
            }

            ///박스 검색
            if (!SearchBoxNum())
                return;

            printBoxLabel_PRODUCT();
        }

        private void FormpRoductAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            disconnectScanner();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ViewClear();
        }

        private void ViewClear()
        {
            dgList.Rows.Clear();

            cbCOMPANY.Text = "";
            cbCOMPETENCY.Text = "";
            cbPROPERTY_PURPOSE.Text = "";
            cbPROPERTY_TYPE.Text = "";

            txtBarcode.Text = "";
            txtProductName.Text = "";

            txtIDENT_NUMBER.Text = "";

            txtBoxName.Text = "";
            txtBoxNum.Text = "";
            cbBoxCOMPETENCY.Text = "";

            txtCOMPANY.Text = "";
            txtCOMPETENCY.Text = "";
            txtPROPERTY_PURPOSE.Text = "";
            txtPROPERTY_TYPE.Text = "";
            txtBoxCOMPETENCY.Text = "";
        }

        private void cbCOMPANY_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbCOMPANY.Text == "")
                txtCOMPANY.Text = "";
        }

        private void cbCOMPETENCY_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbCOMPETENCY.Text == "")
                txtCOMPETENCY.Text = "";
        }

        private void cbPROPERTY_PURPOSE_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbPROPERTY_PURPOSE.Text == "")
                txtPROPERTY_PURPOSE.Text = "";
        }

        private void cbPROPERTY_TYPE_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbPROPERTY_TYPE.Text == "")
                txtPROPERTY_TYPE.Text = "";
        }

        private void cbBoxCOMPETENCY_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBoxCOMPETENCY.Text = ((DataRow)((ComboBoxItem)cbBoxCOMPETENCY.SelectedItem).Tag)[COLUMNS.TB_COMMON_CODE.COMMON_CODE].ToString();
        }

        private void cbBoxCOMPETENCY_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbBoxCOMPETENCY.Text == "")
                txtBoxCOMPETENCY.Text = "";
        }

        private void txtBoxNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (txtBoxNum.Text.Length > 0)
                {
                    RecevieScanData(txtBoxNum.Text);
                }
            }
        }

        private void dgList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgList.SelectedRows.Count > 0)
            {
                cbCOMPANY.Text = dgList.Rows[dgList.SelectedRows[0].Index].Cells[2].Value.ToString();
                cbCOMPETENCY.Text = dgList.Rows[dgList.SelectedRows[0].Index].Cells[3].Value.ToString();
                cbPROPERTY_PURPOSE.Text = dgList.Rows[dgList.SelectedRows[0].Index].Cells[4].Value.ToString();
                cbPROPERTY_TYPE.Text = dgList.Rows[dgList.SelectedRows[0].Index].Cells[5].Value.ToString();
                txtBarcode.Text = dgList.Rows[dgList.SelectedRows[0].Index].Cells[1].Value.ToString();
                txtProductName.Text = dgList.Rows[dgList.SelectedRows[0].Index].Cells[0].Value.ToString();
                txtIDENT_NUMBER.Text = dgList.Rows[dgList.SelectedRows[0].Index].Cells[6].Value.ToString();
                txtBoxName.Text = dgList.Rows[dgList.SelectedRows[0].Index].Cells[7].Value.ToString();
                txtBoxNum.Text = dgList.Rows[dgList.SelectedRows[0].Index].Cells[8].Value.ToString();
                txtBoxCOMPETENCY.Text = dgList.Rows[dgList.SelectedRows[0].Index].Cells[9].Value.ToString();

                string sCompentency = string.Empty;
                foreach (ComboBoxItem item in cbBoxCOMPETENCY.Items)
                {
                    DataRow row = (DataRow)item.Tag;
                    if (row[COLUMNS.TB_COMMON_CODE.COMMON_CODE].ToString() == txtBoxCOMPETENCY.Text)
                    {
                        sCompentency = row[COLUMNS.TB_COMMON_CODE.COMMON_NAME].ToString();
                    }
                }

                if (sCompentency != "")
                {
                    cbBoxCOMPETENCY.Text = sCompentency;
                }
            }
        }
    }
}
