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
    public partial class FormMain : Form
    {
        FormRental childRentalForm = null;      
        FormReturn childReturnForm = null;      
        FormHistory childHistoryForm = null;    
        FormNewRegistration childNewRegistrationForm = null;

        public FormMain()
        {
            InitializeComponent();
        }

        //************************************************************************//
        // Title     : MainForm Load                                              //
        // Event     : MainForm Load 시 자식 폼 호출                              //
        // Parameter : Default                                                    //
        //************************************************************************//
        private void FormMain_Load(object sender, EventArgs e)
        {
            lbUserName.Text = Common.strUSER_NAME;

            SetLeftMenuButton();

            // Event     : 현제 선택된 왼쪽 메뉴 버튼 이미지 변경
            // Parameter : 메뉴 명
            //           , 이벤트 타입 (Hover, Leave)
            //           , 이벤트 호출 타입 (L : 폼 로드 시, B : 버튼 클릭 시)
            LMButtonImageChange(Common.strMENU_NAME, "Hover", "L");


            ChildFormLoad(Common.strMENU_NAME);
        }

        //************************************************************************//
        // Title     : 화면 권한관리                                              //
        // Event     : 화면 권한관리 이벤트                                       //
        // Parameter : Admin, User                                                //
        //************************************************************************//
        private void SetLeftMenuButton()
        {
            if (Common.strAUTHORITY_CODE == "Admin")
            {
                LMNewRegistration.Visible = true;
                LMDisposal.Visible = true;
            }
            else 
            {
                LMNewRegistration.Visible = false;
                LMDisposal.Visible = false;
            }
        }

        //************************************************************************//
        // Title     : 바코드 시리얼 포트 초기화                                  //
        // Event     : 폼 호출시 이전 바코드 시리얼 포트 초기화                   //
        // Parameter : Default                                                    //
        //************************************************************************//
        private void SerialPortReset()
        {
            if (childRentalForm != null)
            {
                childRentalForm.DisConnectScaner();
            }

            if (childReturnForm != null)
            {
                childReturnForm.DisConnectScaner();
            }
        }

        //************************************************************************//
        // Title     : Left Menu 버튼클릭                                         //
        // Event     : 선택된 화면을 불러온다                                     //
        // Parameter : Default                                                    //
        //************************************************************************//
        private void LMHome_Click(object sender, EventArgs e)
        {
            Common.strMENU_NAME = "LMHome";

            ChildFormLoad(Common.strMENU_NAME);
        }

        private void LMRental_Click(object sender, EventArgs e)
        {
            Common.strMENU_NAME = "LMRental";

            ChildFormLoad(Common.strMENU_NAME);
        }

        private void LMReturn_Click(object sender, EventArgs e)
        {
            Common.strMENU_NAME = "LMReturn";

            ChildFormLoad(Common.strMENU_NAME);
        }

        private void LMRentalSample_Click(object sender, EventArgs e)
        {
            Common.strMENU_NAME = "LMRentalSample";

            ChildFormLoad(Common.strMENU_NAME);
        }

        private void LMReturnSample_Click(object sender, EventArgs e)
        {
            Common.strMENU_NAME = "LMReturnSample";

            ChildFormLoad(Common.strMENU_NAME);
        }

        private void LMHistory_Click(object sender, EventArgs e)
        {
            Common.strMENU_NAME = "LMHistory";

            ChildFormLoad(Common.strMENU_NAME);
        }

        private void LMNewRegistration_Click(object sender, EventArgs e)
        {
            Common.strMENU_NAME = "LMNewRegistration";

            ChildFormLoad(Common.strMENU_NAME);
        }

        private void LMDisposal_Click(object sender, EventArgs e)
        {
            Common.strMENU_NAME = "LMDisposal";

            ChildFormLoad(Common.strMENU_NAME);
        }

        //************************************************************************//
        // Title     : 자식폼 호출                                                //
        // Event     : tbMenuName의 텍스트값을 읽어와 각 화면을 호출              //
        // Parameter : 메뉴 명 == 폼 명                                           //
        //************************************************************************//
        private void ChildFormLoad(string _menuName)
        {
            ChildFormClose(_menuName);

            // 홈 폼 호출
            if (_menuName == "LMHome")
            {
                // 홈 폼 호출시 생성된 폼이 없다면 폼 생성
                childRentalForm = new FormRental();
                
                childRentalForm.TopLevel = false;

                SerialPortReset();
                childRentalForm.Show();

                this.mainPanel.Controls.Clear();
                this.mainPanel.Controls.Add(childRentalForm);
            }
            // 대여 폼 호출
            else if (_menuName == "LMRental")
            {
                childRentalForm = new FormRental();
                
                childRentalForm.TopLevel = false;

                SerialPortReset();
                childRentalForm.Show();

                this.mainPanel.Controls.Clear();
                this.mainPanel.Controls.Add(childRentalForm);
            }
            // 반납 폼 호출
            else if (_menuName == "LMReturn")
            {
                childReturnForm = new FormReturn();

                childReturnForm.TopLevel = false;

                SerialPortReset();
                childReturnForm.Show();

                this.mainPanel.Controls.Clear();
                this.mainPanel.Controls.Add(childReturnForm);
            }
            // 샘플대여 폼 호출
            else if (_menuName == "LMRentalSample")
            {
                childRentalForm = new FormRental();
                
                childRentalForm.TopLevel = false;
            

                SerialPortReset();
                childRentalForm.Show();

                this.mainPanel.Controls.Clear();
                this.mainPanel.Controls.Add(childRentalForm);
            }
            // 샘플반납 폼 호출
            else if (_menuName == "LMReturnSample")
            {
                childRentalForm = new FormRental();
                
                childRentalForm.TopLevel = false;
              

                SerialPortReset();
                childRentalForm.Show();

                this.mainPanel.Controls.Clear();
                this.mainPanel.Controls.Add(childRentalForm);
            }
            // 이력 폼 호출
            else if (_menuName == "LMHistory")
            {
                childHistoryForm = new FormHistory();
                
                childHistoryForm.TopLevel = false;
                childHistoryForm.tbUserId.Text = this.tbUserId.Text;

                childHistoryForm.Show();

                this.mainPanel.Controls.Clear();
                this.mainPanel.Controls.Add(childHistoryForm);
            }
            // 신규등록 폼 호출
            else if (_menuName == "LMNewRegistration")
            {
                childNewRegistrationForm = new FormNewRegistration();

                childNewRegistrationForm.TopLevel = false;
                childNewRegistrationForm.tbUserId.Text = this.tbUserId.Text;

                SerialPortReset();
                childNewRegistrationForm.Show();

                this.mainPanel.Controls.Clear();
                this.mainPanel.Controls.Add(childNewRegistrationForm);
            }
            // 폐기 폼 호출
            else if (_menuName == "LMDisposal")
            {
                childRentalForm = new FormRental();
                
                childRentalForm.TopLevel = false;
              

                SerialPortReset();
                childRentalForm.Show();

                this.mainPanel.Controls.Clear();
                this.mainPanel.Controls.Add(childRentalForm);
            }

            LMButtonImageClear();
            LMButtonImageChange(Common.strMENU_NAME, "Hover", "L");
        }

        private void ChildFormClose(string _menuName)
        {
            // 홈 폼 호출
            if (_menuName != "LMHome")
            {
                // 홈 폼 호출시 생성된 폼이 없다면 폼 생성
                if (childRentalForm != null)
                {
                    childRentalForm.Close();
                }
            }
            
            // 대여 폼 호출
            if (_menuName != "LMRental")
            {
                if (childRentalForm != null)
                {
                    childRentalForm.Close();
                }
            }
            // 반납 폼 호출
            if (_menuName != "LMReturn")
            {
                if (childReturnForm != null)
                {
                    childReturnForm.Close();
                }

            }
            // 샘플대여 폼 호출
            if (_menuName != "LMRentalSample")
            {
                if (childRentalForm != null)
                {
                    childRentalForm.Close();
                }
            }
            // 샘플반납 폼 호출
            if (_menuName != "LMReturnSample")
            {
                if (childRentalForm != null)
                {
                    childRentalForm.Close();
                }
            }
            // 이력 폼 호출
            if (_menuName != "LMHistory")
            {
                if (childHistoryForm != null)
                {
                    childHistoryForm.Close();
                }
            }
            // 신규등록 폼 호출
            if (_menuName != "LMNewRegistration")
            {
                if (childNewRegistrationForm != null)
                {
                    childNewRegistrationForm.Close();
                }
            }
            // 폐기 폼 호출
            if (_menuName != "LMDisposal")
            {
                if (childRentalForm != null)
                {
                    childRentalForm.Close();
                }
            }
        }

        //************************************************************************//
        // Title     : 닫기버튼 클릭                                              //
        // Event     : 메인 폼을 닫은 후 로그인 폼으로 돌아간다                   //
        // Parameter : Default                                                    //
        //************************************************************************//
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //************************************************************************//
        // Title     : 버튼 이미지 변경                                           //
        // Event     : MouseHover, MouseLeave 시 버튼의 이미지 변경               //
        // Parameter : _menuName,                                                 //
        //           , _eventType,                                                //
        //************************************************************************//
        // MouseHover, MouseLeave 시 버튼의 이미지 변경
        private void LMButtonImageChange(string _menuName, string _eventtype, string _loadChk)
        {
            try
            {
                Image img = Image.FromFile(@"Image\\" + _menuName + _eventtype + ".jpg");

                if (_menuName == Common.strMENU_NAME && _eventtype == "Leave" && _loadChk == "B")
                {
                    return;
                }

                if (_menuName == "LMHome")
                {
                    LMHome.BackgroundImage = img;
                }
                else if (_menuName == "LMRental")
                {
                    LMRental.BackgroundImage = img;
                }
                else if (_menuName == "LMReturn")
                {
                    LMReturn.BackgroundImage = img;
                }
                else if (_menuName == "LMRentalSample")
                {
                    LMRentalSample.BackgroundImage = img;
                }
                else if (_menuName == "LMReturnSample")
                {
                    LMReturnSample.BackgroundImage = img;
                }
                else if (_menuName == "LMHistory")
                {
                    LMHistory.BackgroundImage = img;
                }
                else if (_menuName == "LMNewRegistration")
                {
                    LMNewRegistration.BackgroundImage = img;
                }
                else if (_menuName == "LMDisposal")
                {
                    LMDisposal.BackgroundImage = img;
                }
                else if (_menuName == "CloseBtn")
                {
                    CloseBtn.BackgroundImage = img;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 버튼 이미지 변경 이벤트
        // 버튼 이미지 초기화
        private void LMButtonImageClear()
        {
            LMHome.BackgroundImage = Image.FromFile(@"Image\\LMHomeLeave.jpg");
            LMRental.BackgroundImage = Image.FromFile(@"Image\\LMRentalLeave.jpg");
            LMReturn.BackgroundImage = Image.FromFile(@"Image\\LMReturnLeave.jpg");
            LMRentalSample.BackgroundImage = Image.FromFile(@"Image\\LMRentalSampleLeave.jpg");
            LMReturnSample.BackgroundImage = Image.FromFile(@"Image\\LMReturnSampleLeave.jpg");
            LMHistory.BackgroundImage = Image.FromFile(@"Image\\LMHistoryLeave.jpg");
            LMNewRegistration.BackgroundImage = Image.FromFile(@"Image\\LMNewRegistrationLeave.jpg");
            LMDisposal.BackgroundImage = Image.FromFile(@"Image\\LMDisposalLeave.jpg");
        }

        private void LMHome_MouseHover(object sender, EventArgs e)
        {
            LMButtonImageChange("LMHome", "Hover", "B");
        }

        private void LMHome_MouseLeave(object sender, EventArgs e)
        {
            LMButtonImageChange("LMHome", "Leave", "B");
        }

        private void LMRental_MouseHover(object sender, EventArgs e)
        {
            LMButtonImageChange("LMRental", "Hover", "B");
        }

        private void LMRental_MouseLeave(object sender, EventArgs e)
        {
            LMButtonImageChange("LMRental", "Leave", "B");
        }

        private void LMReturn_MouseHover(object sender, EventArgs e)
        {
            LMButtonImageChange("LMReturn", "Hover", "B");
        }

        private void LMReturn_MouseLeave(object sender, EventArgs e)
        {
            LMButtonImageChange("LMReturn", "Leave", "B");
        }

        private void LMRentalSample_MouseHover(object sender, EventArgs e)
        {
            LMButtonImageChange("LMRentalSample", "Hover", "B");
        }

        private void LMRentalSample_MouseLeave(object sender, EventArgs e)
        {
            LMButtonImageChange("LMRentalSample", "Leave", "B");
        }

        private void LMReturnSample_MouseHover(object sender, EventArgs e)
        {
            LMButtonImageChange("LMReturnSample", "Hover", "B");
        }

        private void LMReturnSample_MouseLeave(object sender, EventArgs e)
        {
            LMButtonImageChange("LMReturnSample", "Leave", "B");
        }

        private void LMHistory_MouseHover(object sender, EventArgs e)
        {
            LMButtonImageChange("LMHistory", "Hover", "B");
        }

        private void LMHistory_MouseLeave(object sender, EventArgs e)
        {
            LMButtonImageChange("LMHistory", "Leave", "B");
        }

        private void LMNewRegistration_MouseHover(object sender, EventArgs e)
        {
            LMButtonImageChange("LMNewRegistration", "Hover", "B");
        }

        private void LMNewRegistration_MouseLeave(object sender, EventArgs e)
        {
            LMButtonImageChange("LMNewRegistration", "Leave", "B");
        }

        private void LMDisposal_MouseHover(object sender, EventArgs e)
        {
            LMButtonImageChange("LMDisposal", "Hover", "B");
        }

        private void LMDisposal_MouseLeave(object sender, EventArgs e)
        {
            LMButtonImageChange("LMDisposal", "Leave", "B");
        }

        private void CloseBtn_MouseHover(object sender, EventArgs e)
        {
            LMButtonImageChange("CloseBtn", "Hover", "B");
        }

        private void CloseBtn_MouseLeave(object sender, EventArgs e)
        {
            LMButtonImageChange("CloseBtn", "Leave", "B");
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SerialPortReset();
        }
    }
}
