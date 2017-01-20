using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DEFINES;

namespace Product_Manage_System
{
    class AlramMessageEvent
    {
        int _state;
        string _showText;
        static string _tempStr = "";
        static FormMSG msg;
        DialogResult dlgResult; 

        public static string Show(int state, string text)
        {
            new AlramMessageEvent(state, text);
            return _tempStr; 
        }
        public static string Show(int state, string text, out int status)
        {
            new AlramMessageEvent(state, text);
            status = msg.state;
            return _tempStr; 
        }
        
        AlramMessageEvent(int state, string text)
        {
            _tempStr = "";
            
            switch (state)
            {
                case AlramLevel.SUMMARY_ALRAM:
                    _tempStr = text;
                    break;
                case AlramLevel.MESSAGEBOX_OK_ALRAM:
                    msg = new FormMSG(text, MsgBoxLevel.MSG_OK);
                    msg.ShowDialog();
                    dlgResult = msg.DialogResult;
                    break;
                case AlramLevel.MESSAGEBOX_YES_NO_ALRAM:
                    msg = new FormMSG(text, MsgBoxLevel.MSG_YES_NO);
                    msg.ShowDialog();
                    break;
                case AlramLevel.MESSAGEBOX_OK_CANCLE_ALRAM:
                    msg = new FormMSG(text, MsgBoxLevel.MSG_OK_CANCLE);
                    msg.ShowDialog();
                    break;
                case AlramLevel.MESSAGEBOX_RETRY_STOP_CANCLE_ALRAM:
                    msg = new FormMSG(text, MsgBoxLevel.MSG_RETRY_STOP_CANCLE);
                    msg.ShowDialog();
                    break;
            }
        }
    }
}
