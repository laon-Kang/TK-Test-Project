using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Threading;
          
namespace Product_Manage_System
{
    public delegate void SerialReceiveData(int length, byte[] data, DateTime updatetime);   // delegate declaration

    public interface SerialClientInterface
    {
        event SerialReceiveData SerialReceiveDataEvent;
    }

    class SerialComMan : SerialClientInterface
    {
        private SerialPort com;
        private string portName = "COM5";
        private Parity parity = Parity.None;
        private int baudRate = 9600;
        private StopBits stopBits = StopBits.One;
        private int dataBits = 8;

        public event SerialReceiveData SerialReceiveDataEvent;
        private Thread receiveThread;
        private byte[] comData;
        private byte footer;
        private string EndOfFrame;

        public SerialComMan()
        {

        }

        public bool connect()
        {
            try
            {
                if (baudRate == 0)
                    com = new SerialPort(portName);
                else
                    com = new SerialPort(portName, baudRate, parity, dataBits, stopBits);

                com.Handshake = Handshake.None;

                com.ReadTimeout = 0;
                com.WriteTimeout = 1000;

                com.Open();

                return true;

            }
            catch (IOException ex)
            {
                throw new Exception("Connect Fail : " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Connect Fail : " + ex.Message);
            }

        }

        public SerialPort getPort()
        {
            return com;
        }
        public void disconnect()
        {
            try
            {
                com.Close();
                if (receiveThread != null)
                {
                    receiveThread.Abort();
                    receiveThread = null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Disconnect Fail : " + ex.Message);
            }

        }

        public bool getConnected()
        {
            try
            {
                if (com != null)
                    return com.IsOpen;

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("getConnected Fail : " + ex.Message);
            }

        }

        void com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int dataLength = com.BytesToRead;
                byte[] data = new byte[dataLength];
                int nbrDataRead = com.Read(data, 0, dataLength);
                byte[] rdata;
                Int32 TotalReads;
                Int32 TotalBytesRead;

                byte PreviousByte;
                byte CurrentByte;

                if (dataLength < 2)
                    return;

                rdata = data;
                string dd = Encoding.ASCII.GetString(data, 0, dataLength);
                Console.WriteLine("Com Start " + dd + " " + nbrDataRead.ToString());
                //Common.writeLog("0", "BCD SCAN RAW DATA[" + dd + "]");
                int start = 0;

                if (comData != null)
                {
                    if (comData.Length > 0)
                    {
                        //rdata = new byte[comData.Length + dataLength];
                        rdata = Common.byteArrayPlusByteArray(comData, data);
                        dd = Encoding.ASCII.GetString(rdata, 0, rdata.Length);
                        Console.WriteLine("Com Add Start " + dd);
                        comData = null;
                    }
                }
                PreviousByte = 0;
                CurrentByte = 0;
                TotalReads = 0;
                TotalBytesRead = 0;
                for (int i = 0; i < rdata.Length; i++)
                {
                    PreviousByte = CurrentByte;
                    CurrentByte = rdata[TotalBytesRead];
                    TotalBytesRead += 1;

                    if (IsEndOfFrame(PreviousByte, CurrentByte))
                    {

                        byte[] cdata = Common.byteArrayToByteArray(rdata, start, i - (start + EndOfFrame.Length - 1));

                        //if (cdata.Length != 49)
                        //{
                        //    dd = Encoding.ASCII.GetString(cdata, 0, cdata.Length);
                        //    Console.WriteLine("Com Over ------- " + dd);
                        //}
                        if (SerialReceiveDataEvent != null)
                            SerialReceiveDataEvent(cdata.Length, cdata, DateTime.Now);

                        dd = Encoding.ASCII.GetString(cdata, 0, cdata.Length);
                        Console.WriteLine("Com Send ------- " + dd);

                        start = i + 1;

                    }
                }
                if (start < rdata.Length)
                {
                    comData = Common.byteArrayToByteArray(rdata, start, rdata.Length - start);
                    dd = Encoding.ASCII.GetString(comData, 0, comData.Length);
                    Console.WriteLine("Com Data Add--------- " + dd);
                }
                else
                {
                    comData = null;
                }
            }
            catch (Exception ee)
            {
                // abort the thread
                Console.WriteLine(string.Format("Com Error-------  {0}", ee.Message));
            }
        }

        public void setFooter(string EndOfFrameDelimiter)
        {
            if (EndOfFrameDelimiter == "<,>")
                EndOfFrame = ",";
            else if (EndOfFrameDelimiter == "<:>")
                EndOfFrame = ":";
            else if (EndOfFrameDelimiter == "<;>")
                EndOfFrame = ";";
            else if (EndOfFrameDelimiter == "<CR>")
                EndOfFrame = "\r";
            else if (EndOfFrameDelimiter == "<LF>")
                EndOfFrame += "\n";
            else if (EndOfFrameDelimiter == "<CR><LF>")
                EndOfFrame = "\r\n";
            else if (EndOfFrameDelimiter == "<LF><CR>")
            {
                EndOfFrame = "\n";
                EndOfFrame += "\r";
            }
            else if (EndOfFrameDelimiter == "<ETX>")
                EndOfFrame = Convert.ToString(3);
            else
                EndOfFrame = EndOfFrameDelimiter;
        }

        public bool IsEndOfFrame(byte PreviousByte, byte CurrentByte)
        {
            if (EndOfFrame.Length == 2)
            {
                if ((Convert.ToByte(EndOfFrame[0]) == PreviousByte) && (Convert.ToByte(EndOfFrame[1]) == CurrentByte))
                    return true;
            }

            else if (EndOfFrame.Length == 1)
            {
                if (Convert.ToByte(EndOfFrame[0]) == CurrentByte)
                    return true;
            }

            //Reaching Here Means The Terminator Was Not Found
            return false;

        }

        public void EventStart()
        {
            try
            {
                if (com != null)
                {
                    if (com.IsOpen)
                    {
                        com.DataReceived += new SerialDataReceivedEventHandler(com_DataReceived);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Event Start Fail " + ex.Message);
            }

        }

        public void EventStop()
        {
            try
            {
                if (com != null)
                {
                    if (com.IsOpen)
                    {
                        com.DataReceived -= new SerialDataReceivedEventHandler(com_DataReceived);
                    }
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Event Stop Fail");
            }
        }

        public void setport(string portname, string baudRate, string DataBit, string parity, string stopBits)
        {
            this.portName = portname;

            if (parity.Equals("Even"))
            {
                this.parity = Parity.Even;
            }
            if (parity.Equals("Mark"))
            {
                this.parity = Parity.Mark;
            }
            if (parity.Equals("None"))
            {
                this.parity = Parity.None;
            }
            if (parity.Equals("Odd"))
            {
                this.parity = Parity.Odd;
            }
            if (parity.Equals("Space"))
            {
                this.parity = Parity.Space;
            }

            this.dataBits = Convert.ToInt32(DataBit);
            this.baudRate = Convert.ToInt32(baudRate);


            if (stopBits.Equals("None"))
            {
                this.stopBits = StopBits.None;
            }
            if (stopBits.Equals("1"))
            {
                this.stopBits = StopBits.One;
            }
            if (stopBits.Equals("1.5"))
            {
                this.stopBits = StopBits.OnePointFive;
            }
            if (stopBits.Equals("2"))
            {
                this.stopBits = StopBits.Two;
            }

        }

        public void sendData(byte[] message)
        {
            try
            {
                if (com != null)
                    com.Write(message, 0, message.Length);
            }
            catch (Exception ex)
            {
                throw new Exception("Send Error " + ex.Message);
            }
        }

        public void sendData(string message)
        {
            try
            {
                if (com != null)
                {
                    int maxLen = com.WriteBufferSize;
                    if (maxLen > message.Length)
                    {
                        com.WriteLine(message);
                    }
                    else
                    {
                        string data = message;
                        int startPos = 0;
                        while (true)
                        {
                            if (startPos + maxLen < message.Length)
                            {
                                data = message.Substring(startPos + maxLen);
                                com.WriteLine(data);
                            }
                            else
                            {
                                data = message.Substring(startPos);
                                com.WriteLine(data);
                                break;
                            }
                            startPos = startPos + maxLen;
                        }
                    }
                }
                else
                {
                    throw new Exception("Com disconnected ");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Send Error " + ex.Message);
            }
        }
    }
}
