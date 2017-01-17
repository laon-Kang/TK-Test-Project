using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Net.Sockets;
using System.Xml;

namespace Product_Manage_System
{
    class Common
    {
        public static String strUserName = String.Empty;
        public static String strUserID = String.Empty;

        public static System.IO.Ports.Parity getParity(string Parity)
        {
            System.IO.Ports.Parity ret = System.IO.Ports.Parity.None;

            switch (Parity)
            {
                case "None":
                    ret = System.IO.Ports.Parity.None;
                    break;
                case "Odd":
                    ret = System.IO.Ports.Parity.Odd;
                    break;
                case "Even":
                    ret = System.IO.Ports.Parity.Even;
                    break;
                case "Mark":
                    ret = System.IO.Ports.Parity.Mark;
                    break;
                case "Space":
                    ret = System.IO.Ports.Parity.Space;
                    break;
            }
            return ret;
        }

        public static byte[] byteArrayPlusByteArray(byte[] ins, byte[] ins2)
        {
            if (ins == null || ins2 == null)
                return null;

            byte[] ch = new byte[ins.Length + ins2.Length];

            int k = 0;
            for (int i = 0; i < ins.Length; i++)
            {
                ch[k++] = ins[i];
            }
            for (int i = 0; i < ins2.Length; i++)
            {
                ch[k++] = ins2[i];
            }
            return ch;
        }

        public static byte[] byteArrayToByteArray(byte[] ins, int s, int e)
        {
            try
            {
                if (ins == null)
                    return null;

                if (e <= 0)
                    return null;

                byte[] ch = new byte[e];

                int k = 0;
                for (int i = s; i < s + e; i++)
                {
                    ch[k++] = ins[i];
                }

                return ch;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
