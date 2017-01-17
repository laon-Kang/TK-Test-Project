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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        //************************************************************************//
        // Title     : Form Load                                                  //
        // Event     : XML의 정보를 Config에 저장                                 //
        // Parameter : Default                                                    //
        //************************************************************************//
        private void FormLogin_Load(object sender, EventArgs e)
        {
            try
            {
                Config.LoadXML(Application.StartupPath + "\\xmlConfig.xml");
            }
            catch (Exception ex)
            {
                FormMSG msgEx = new FormMSG(ex.Message, "OK", true);
                msgEx.ShowDialog();
            }
        }

        //************************************************************************//
        // Title     : Form Close                                                 //
        // Event     : 닫기 버튼 클릭 이벤트                                      //
        // Parameter : Default                                                    //
        //************************************************************************//
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //************************************************************************//
        // Title     : 로그인 버튼 클릭                                           //
        // Event     : ID, PW 유무 체크, ID, PW 일치 체크                         //
        // Parameter : Default                                                    //
        //************************************************************************//
        private void loginOk_Click(object sender, EventArgs e)
        {
            try
            {
                string stemp = Config.SERVER_URL;
                Config.SERVER_URL = "ADSD";
                
                // ID, PW 유무 체크
                if (tbId.TextLength == 0)
                {
                    FormMSG msgForm = new FormMSG("ID 를 입력하세요.", "OK", true);
                    msgForm.ShowDialog();
                    tbId.Focus();
                    return;
                }
                if (tbPw.TextLength == 0)
                {
                    FormMSG msgForm = new FormMSG("PW 를 입력하세요.", "OK", true);
                    msgForm.ShowDialog();
                    tbPw.Focus();
                    return;
                }

                if (!DBMan.CreateConnection(Config.DBCONNECTION))
                {
                    MessageBox.Show("db cocnnection fail");
                }

                // ID, PW 일치 체크
                DataTable dtUser = null;
                if (DBMan.LoginOffline(tbId.Text, tbPw.Text, out dtUser))
                {
                    if (dtUser.Rows.Count > 0)
                    {
                        Common.strUserName = dtUser.Rows[0][COLUMNS.TB_USER_INFO_ROLE_JOIN.USER_NAME].ToString();

                        this.Hide();

                        FormMain formMain = new FormMain();

                        formMain.tbUserId.Text = dtUser.Rows[0][COLUMNS.TB_USER_INFO_ROLE_JOIN.USER_ID].ToString();
                        formMain.tbAuthorityCode.Text = dtUser.Rows[0][COLUMNS.TB_USER_INFO_ROLE_JOIN.AUTHORITY_CODE].ToString();
                        formMain.tbMenuName.Text = "LMRental";
                        formMain.lbUserName.Text = dtUser.Rows[0][COLUMNS.TB_USER_INFO_ROLE_JOIN.USER_NAME].ToString();
                        

                        formMain.ShowDialog();

                        this.Show();
                    }
                    else
                    {
                        FormMSG msgForm = new FormMSG("사용자 ID 또는 PW 가 일치하지 않습니다.", "OK", true);
                        msgForm.ShowDialog();
                    }
                }
                else
                {
                    FormMSG msgForm = new FormMSG("사용자 인증 실패.", "OK", true);
                    msgForm.ShowDialog();
                }

                tbPw.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //************************************************************************//
        // Title     : tbPw KeyDown                                               //
        // Event     : 페스워드 입력창 KeyDown Event(Enter)                       //
        // Parameter : Default                                                    //
        //************************************************************************//
        private void tbPw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLoginOk.PerformClick();
            }
        }
        
        //************************************************************************//
        // Title     : Form Closing                                               //
        // Event     : Form Closing 전처리 이벤트                                 //
        // Parameter : Default                                                    //
        //************************************************************************//
        // 폼 Close 이벤트 전처리
        // DB연결을 해제한다
        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DBMan.CloseConnection();
        }

        //************************************************************************//
        // Title     : 버튼 이미지 변경                                           //
        // Event     : Mouse Hover, Mouse Leave 버튼 이미지 변경 이벤트           //
        // Parameter : _buttonName - 버튼명,                                      //
        //             _type       - 이벤트 타입 (Hover, Leave)                   //
        //************************************************************************//
        private void ButtonImageChange(string _menuName, string type)
        {
            try
            {
                Image img = Image.FromFile(@"Image\\" + _menuName + type + ".jpg");

                if (_menuName == "CloseBtn")
                {
                    CloseBtn.BackgroundImage = img;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 로그인 버튼 이미지 변경
        private void loginOk_MouseHover(object sender, EventArgs e)
        {
            ButtonImageChange("LoginBtn", "Hover");
        }

        private void loginOk_MouseLeave(object sender, EventArgs e)
        {
            ButtonImageChange("LoginBtn", "Leave");
        }

        // 닫기 버튼 이미지 변경
        private void CloseBtn_MouseHover(object sender, EventArgs e)
        {
            ButtonImageChange("CloseBtn", "Hover");
        }

        private void CloseBtn_MouseLeave(object sender, EventArgs e)
        {
            ButtonImageChange("CloseBtn", "Leave");
        }        
    }
}
