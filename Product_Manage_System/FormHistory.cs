using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Product_Manage_System
{
    public partial class FormHistory : Form
    {
        public FormHistory()
        {
            InitializeComponent();
        }

        private void FormHistory_Load(object sender, EventArgs e)
        {
            this.tbProductName.Text = string.Empty;
            this.tbProductCode.Text = string.Empty;

            tabChk.Text = "1";

            setDataGridView(false);
        }

        // 조회버튼 클릭 이벤트
        // 입력값 있을 시 입력값 기준 조회
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            TextBoxClear();

            if (tabChk.Text == "1")
            {
                setDataGridView(false);
            }
            else
            {
                setDataGridView(true);
            }

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

        private void OverallHistoryBtn_Click(object sender, EventArgs e)
        {
            tabChk.Text = "2";

            TextBoxClear();

            dgRentalList.Visible = false;
            dgSampleRentalList.Visible = false;

            tbInputNote.Visible = false;

            tbInputReturnDate.Visible = true;
            tbStatusName.Visible = true;
            tbInputToTNote.Visible = true;

            dgRentalList.Rows.Clear();
            dgSampleRentalList.Rows.Clear();

            this.BackgroundImage = Image.FromFile(@"Image\\HistoryBg2.jpg");

            dgOverallHistoryList.Visible = true;

            setDataGridView(true);
        }

        private void CurrentHistoryBtn_Click(object sender, EventArgs e)
        {
            tabChk.Text = "1";

            TextBoxClear();

            dgOverallHistoryList.Visible = false;

            tbInputReturnDate.Visible = false;
            tbStatusName.Visible = false;
            tbInputToTNote.Visible = false;

            tbInputNote.Visible = true;

            dgOverallHistoryList.Rows.Clear();

            this.BackgroundImage = Image.FromFile(@"Image\\HistoryBg1.jpg");

            dgRentalList.Visible = true;
            dgSampleRentalList.Visible = true;

            setDataGridView(false);
        }

        // Product Table 조회
        // 입력값 : 제품명, 제품코드 입력값 없을 경우 전체조회
        // 상단 그리드 : TB_PRODUCT_INFO, 하단그리드 : TB_PRODUCT_HISTORY			
        private void setDataGridView(bool _historyChk)
        {
            DataTable dtList = null;

            if (_historyChk == false)
            {
                // 대여목록 조회
                if (DBMan.SelectProductRentalList(tbProductName.Text, tbProductCode.Text, tbUserId.Text, "RT", "", _historyChk, false, out dtList))
                {
                    dgRentalList.Rows.Clear();

                    foreach (DataRow row in dtList.Rows)
                    {
                        DataGridViewRow rowItem = new DataGridViewRow();
                        rowItem.CreateCells(dgRentalList);

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
                        rowItem.Cells[12].Value = row[COLUMNS.TB_PRODUCT_HISTORY.BOX_NUMBER].ToString();
                        rowItem.Cells[13].Value = row[COLUMNS.TB_PRODUCT_HISTORY.BOX_NAME].ToString();
                        rowItem.Cells[14].Value = row[COLUMNS.TB_PRODUCT_HISTORY.NOTE].ToString();

                        rowItem.Tag = row;

                        dgRentalList.Rows.Add(rowItem);
                    }
                }

                // 샘플대여목록 조회
                if (DBMan.SelectProductRentalList(tbProductName.Text, tbProductCode.Text, tbUserId.Text, "ST", "", _historyChk, false, out dtList))
                {
                    dgSampleRentalList.Rows.Clear();

                    foreach (DataRow row in dtList.Rows)
                    {
                        DataGridViewRow rowItem = new DataGridViewRow();
                        rowItem.CreateCells(dgSampleRentalList);

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
                        rowItem.Cells[12].Value = row[COLUMNS.TB_PRODUCT_HISTORY.BOX_NUMBER].ToString();
                        rowItem.Cells[13].Value = row[COLUMNS.TB_PRODUCT_HISTORY.BOX_NAME].ToString();
                        rowItem.Cells[14].Value = row[COLUMNS.TB_PRODUCT_HISTORY.NOTE].ToString();

                        rowItem.Tag = row;

                        dgSampleRentalList.Rows.Add(rowItem);
                    }
                }
            }
            else
            {
                // 전채이력 조회
                if (DBMan.SelectProductRentalList(tbProductName.Text, tbProductCode.Text, tbUserId.Text, "", "", _historyChk, false, out dtList))
                {
                    dgOverallHistoryList.Rows.Clear();

                    foreach (DataRow row in dtList.Rows)
                    {
                        DataGridViewRow rowItem = new DataGridViewRow();
                        rowItem.CreateCells(dgOverallHistoryList);

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
                        rowItem.Cells[11].Value = row[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_STATUS_CODE].ToString();
                        rowItem.Cells[12].Value = row[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_STATUS_NAME].ToString();

                        if (row[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_STATUS_CODE].ToString() == "RT" || row[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_STATUS_CODE].ToString() == "RE")
                        {
                            rowItem.Cells[13].Value = row[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_RENTAL_TIME].ToString();
                            rowItem.Cells[14].Value = row[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_RETURN_TIME].ToString();
                        }
                        else
                        {
                            rowItem.Cells[13].Value = row[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_SAMPLE_RENTAL_TIME].ToString();
                            rowItem.Cells[14].Value = row[COLUMNS.TB_PRODUCT_HISTORY.PRODUCT_SAMPLE_RETURN_TIME].ToString();
                        }


                        rowItem.Cells[15].Value = row[COLUMNS.TB_PRODUCT_HISTORY.BOX_NUMBER].ToString();
                        rowItem.Cells[16].Value = row[COLUMNS.TB_PRODUCT_HISTORY.BOX_NAME].ToString();
                        rowItem.Cells[17].Value = row[COLUMNS.TB_PRODUCT_HISTORY.NOTE].ToString();

                        rowItem.Tag = row;

                        dgOverallHistoryList.Rows.Add(rowItem);
                    }
                }
            }
        }

        // 데이터그리드뷰 셀 클릭 이벤트
        // 각 그리드뷰 셀 클릭 시 상세정보 표기
        private void dgOverallHistoryList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgCellMouseClickEvent("dgOverallHistoryList");
        }

        private void dgRentalList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgCellMouseClickEvent("dgRentalList");
        }

        private void dgSampleRentalList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgCellMouseClickEvent("dgSampleRentalList");
        }

        private void dgCellMouseClickEvent(string _dgName)
        {
            if (_dgName == "dgOverallHistoryList")
            {
                DataGridViewRow dr = dgOverallHistoryList.SelectedRows[0];

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
                tbInputRentalDate.Text = dr.Cells[13].Value.ToString();
                tbInputReturnDate.Text = dr.Cells[14].Value.ToString();
                tbStatusName.Text = dr.Cells[12].Value.ToString();
                tbInputToTNote.Text = dr.Cells[15].Value.ToString();
            }
            else if (_dgName == "dgRentalList")
            {
                DataGridViewRow dr = dgRentalList.SelectedRows[0];

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
                tbInputRentalDate.Text = dr.Cells[11].Value.ToString();
                tbInputNote.Text = dr.Cells[12].Value.ToString();
            }
            else if (_dgName == "dgSampleRentalList")
            {
                DataGridViewRow dr = dgSampleRentalList.SelectedRows[0];

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
                tbInputRentalDate.Text = dr.Cells[11].Value.ToString();
                tbInputNote.Text = dr.Cells[12].Value.ToString();
            }
        }

        // 버튼 클릭 이벤트
        // 입력 폼 초기화
        private void TextBoxClear()
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
            tbInputRentalDate.Text = "";
            tbInputReturnDate.Text = "";
            tbStatusName.Text = "";
            tbInputToTNote.Text = "";
        }

        // 버튼 이미지 변경 이벤트
        // MouseHover, MouseLeave 시 버튼의 이미지 변경
        private void ButtonImageChange(string _menuName, string _eventtype)
        {
            try
            {
                Image img = Image.FromFile(@"Image\\" + _menuName + _eventtype + ".jpg");

                if (_menuName == "OverallHistoryBtn")
                {
                    OverallHistoryBtn.BackgroundImage = img;
                }
                else if (_menuName == "CurrentHistoryBtn")
                {
                    CurrentHistoryBtn.BackgroundImage = img;
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

        private void OverallHistoryBtn_MouseHover(object sender, EventArgs e)
        {
            ButtonImageChange("OverallHistoryBtn", "Hover");
        }

        private void OverallHistoryBtn_MouseLeave(object sender, EventArgs e)
        {
            ButtonImageChange("OverallHistoryBtn", "Leave");
        }

        private void CurrentHistoryBtn_MouseHover(object sender, EventArgs e)
        {
            ButtonImageChange("CurrentHistoryBtn", "Hover");
        }

        private void CurrentHistoryBtn_MouseLeave(object sender, EventArgs e)
        {
            ButtonImageChange("CurrentHistoryBtn", "Leave");
        }

        private void SearchBtn_MouseHover(object sender, EventArgs e)
        {
            ButtonImageChange("SearchBtn", "Hover");
        }

        private void SearchBtn_MouseLeave(object sender, EventArgs e)
        {
            ButtonImageChange("SearchBtn", "Leave");
        }
    }
}
