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
    public partial class FormMSG : Form
    {
        string msg = string.Empty;
        public int state = -1; 
        public FormMSG()
        {
            InitializeComponent();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            state = DialogResult.OK.GetHashCode(); 
            this.Close();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public FormMSG(String msg, int state)
        {
            InitializeComponent();

            this.msg = msg;

            closeBtn.Visible = false;
            int msgState = state;
            switch (msgState)
            {
                case MsgBoxLevel.MSG_OK:
                    OkBtn.Visible = true;
                    yesBtn.Visible = false;
                    noBtn.Visible = false;
                    break;
                case MsgBoxLevel.MSG_YES_NO:
                    OkBtn.Visible = false;
                    yesBtn.Visible = true;
                    noBtn.Visible = true;
                    break;
                case MsgBoxLevel.MSG_OK_CANCLE:
                    break;
                case MsgBoxLevel.MSG_RETRY_STOP_CANCLE:
                    break;
            }
        }

        public FormMSG(String msg, string Type, bool bAlram)
        {
            InitializeComponent();

            this.msg = msg;

            if (Type.Equals("YN"))
            {
                OkBtn.Text = "     예";
                closeBtn.Text = "     아니오";
            }
            else if (Type.Equals("OK"))
            {
                closeBtn.Visible = false;
            }
        }

        private void FormMSG_Load(object sender, EventArgs e)
        {
            try
            {
                Bitmap bm = new Bitmap(1, 1);
                Graphics gaphic = Graphics.FromImage(bm);
                Brush textColor = Brushes.Black;

                StringBuilder sb = new StringBuilder();

                string msgBuf = string.Empty;
                //bool bContinue = true;
                int line = 0;
                for (int i = 0; i < msg.Length; i++)
                {
                    msgBuf += msg[i];
                    SizeF tSize = gaphic.MeasureString(msgBuf, msgTextBox.Font);
                    if (tSize.Width > 400)
                    {
                        line++;
                        msgBuf += "\r\n";
                        sb.Append(msgBuf);
                        msgBuf = "";
                    }
                }

                if (2 - line > 0)
                {
                    for (int i = 0; i < (2 - line); i++)
                    {
                        sb.Append("\r\n");
                    }
                }
                sb.Append(msgBuf);

                msgTextBox.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 버튼 이미지 변경 이벤트
        // MouseHover, MouseLeave 시 버튼의 이미지 변경
        private void ButtonImageChange(string _menuName, string type)
        {
            try
            {
                Image img = Image.FromFile(@"Image\\" + _menuName + type + ".jpg");

                if (_menuName == "OkBtn")
                {
                    OkBtn.BackgroundImage = img;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }        

        private void okBtn_MouseHover(object sender, EventArgs e)
        {
            ButtonImageChange("OkBtn", "Hover");
        }

        private void okBtn_MouseLeave(object sender, EventArgs e)
        {
            ButtonImageChange("OkBtn", "Leave");
        }

        private void yesBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            state = DialogResult.Yes.GetHashCode();
            this.Close();
        }

        private void noBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            state = DialogResult.No.GetHashCode();
            this.Close();
        }
    }
}
