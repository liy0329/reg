using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MTREG.medinsur.sjzsyb.bll
{
    public class Mifare
    {
        public static int ReaderHandle = 0;
        //[DllImport("HD300_V1.dll")]
        [DllImport(@".\dll\SSSE32.dll", EntryPoint = "ICC_Reader_Open")]
        // public static extern IntPtr CT_open(System.Text.StringBuilder name, UInt32 param1, Byte param2);
        //打开端口
        public static extern int ICC_Reader_Open(System.Text.StringBuilder dev_Name);
        [DllImport(@".\dll\SSSE32.dll", EntryPoint = "ICC_PosBeep")]
        //蜂鸣器
        public static extern int ICC_PosBeep(int ReaderHandle, char time);
        [DllImport(@".\dll\SSSE32.dll", EntryPoint = "ICC_Reader_Close")]
        //关闭端口
        public static extern int ICC_Reader_Close(int ReaderHandle);
        //初始化
        [DllImport(@".\dll\SSSE32.dll", EntryPoint = "PICC_Reader_Request")]
        public static extern int PICC_Reader_Request(int ReaderHandle);
        //防冲突
        [DllImport(@".\dll\SSSE32.dll", EntryPoint = "PICC_Reader_anticoll")]
        public static extern int PICC_Reader_anticoll(int ReaderHandle, byte[] UID);
        //选择卡
        [DllImport(@".\dll\SSSE32.dll", EntryPoint = "PICC_Reader_Select")]
        public static extern int PICC_Reader_Select(int ReaderHandle, byte[] cardtype);


        /// <summary>
        /// 打开端口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OpenPoint()
        {
            //String usb = "USB1";
            System.Text.StringBuilder usb = new System.Text.StringBuilder("USB1", 200);
             ReaderHandle = ICC_Reader_Open(usb);
            char ss = (char)5;
            ICC_PosBeep(ReaderHandle, ss);
             
        }
        /// <summary>
        /// 关闭端口
        /// </summary>
        public void ClosePoint()
        {
            ICC_Reader_Close(ReaderHandle);
        }
        /// <summary>
        /// 下载密钥
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DownKey()
        {
            int i = ICC_Reader_Close(ReaderHandle);
        }
        /// <summary>
        /// 寻卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public string FindCard()
        {

            int st;
            String da = "";
            st = PICC_Reader_Request(ReaderHandle);
            byte[] temp = new byte[4];
            st = PICC_Reader_anticoll(ReaderHandle, temp);
            for (int i = 0; i < 4; i++)
            {
                da = da + Convert.ToString(temp[i], 16).PadLeft(2,'0').ToUpper();
            }
            
            byte[] temp1 = { 0x41 };
            st = PICC_Reader_Select(ReaderHandle, temp1);
            if (st < 0 && da == "00000000")
            {
                MessageBox.Show("读取门诊卡失败！请重试");
            }
            return da;
        }
    }
}
