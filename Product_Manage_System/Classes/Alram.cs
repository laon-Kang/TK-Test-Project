using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Manage_System.Classes
{
    class Alram
    {
        /*
        [DllImport("QUvc_dll.dll")]
        public static extern unsafe bool Usb_Qu_write(byte Q_index, byte Q_type, byte* pQ_data);
        [DllImport("QUvc_dll.dll")]
        public static extern void Usb_Qu_Open();
        [DllImport("QUvc_dll.dll")]
        public static extern void Usb_Qu_Close();
        [DllImport("QUvc_dll.dll")]
        public static extern int Usb_Qu_Getstate();

        public static System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();

        unsafe public static void SetAlram(bool bError)
        {
            const byte C_lampoff = 0;
            const byte C_lampon = 1;
            const byte C_lampblink = 2;
            const byte C_D_not = 100;  //  // Don't care  // Do not change before state



            bool bchk = false;
            byte* bbb = stackalloc byte[6];

            if (bError)
            {
                bbb[0] = C_lampon;
                bbb[1] = C_lampblink;
                bbb[2] = C_D_not;
                bbb[3] = C_lampon;
                bbb[4] = C_lampblink;
                bbb[5] = 3; // sound select

            }
            else
            {
                bbb[0] = 0; //red
                bbb[1] = 0; //yellow
                bbb[2] = 1; //green
                bbb[3] = 0; //blue
                bbb[4] = 0; //white
                bbb[5] = 0; // sound select
            }
            bchk = Usb_Qu_write(0, 0, bbb);

            t1.Tick += new System.EventHandler(timer1_Tick);
            t1.Interval = 1000;
            t1.Start();
        }

        private static void timer1_Tick(object sender, EventArgs e)
        {
            clearAlram();

            t1.Tick -= new System.EventHandler(timer1_Tick);
            t1.Stop();
        }

        unsafe public static void clearAlram()
        {
            const byte C_lampoff = 0;


            bool bchk = false;


            byte* bbb = stackalloc byte[6];


            bbb[0] = C_lampoff;
            bbb[1] = C_lampoff;
            bbb[2] = C_lampoff;
            bbb[3] = C_lampoff;
            bbb[4] = C_lampoff;

            bbb[5] = 0; // sound off


            bchk = Usb_Qu_write(0, 0, bbb);
        }
        */
    }
}
