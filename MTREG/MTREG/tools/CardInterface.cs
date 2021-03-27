using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using MTREG.ihsp.bo;
using MTREG.common;

namespace MTREG.tools
{
    class CardInterface
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct IDCardData
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string Name; //姓名   
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
            public string Sex;   //性别
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
            public string Nation; //名族
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
            public string Born; //出生日期
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 72)]
            public string Address; //住址
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 38)]
            public string IDCardNo; //身份证号
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string GrantDept; //发证机关
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
            public string UserLifeBegin; // 有效开始日期
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
            public string UserLifeEnd;  // 有效截止日期
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 38)]
            public string reserved; // 保留
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
            public string PhotoFileName; // 照片路径
        }
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_FindReader", CharSet = CharSet.Ansi)]
        public static extern int Syn_FindReader();
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_OpenPort", CharSet = CharSet.Ansi)]
        public static extern int Syn_OpenPort(int iPort);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SetMaxRFByte", CharSet = CharSet.Ansi)]
        public static extern int Syn_SetMaxRFByte(int iPort, byte ucByte, int iIfOpen);
        /*************************身份证卡类函数 ***************************/
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_StartFindIDCard", CharSet = CharSet.Ansi)]
        public static extern int Syn_StartFindIDCard(int iPort, ref byte pucIIN, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_SelectIDCard", CharSet = CharSet.Ansi)]
        public static extern int Syn_SelectIDCard(int iPort, ref byte pucSN, int iIfOpen);
        [DllImport("SynIDCardAPI.dll", EntryPoint = "Syn_ReadMsg", CharSet = CharSet.Ansi)]
        public static extern int Syn_ReadMsg(int iPortID, int iIfOpen, ref IDCardData pIDCardData);


        /// <summary>
        /// 寻找读卡器
        /// </summary>
        /// <returns></returns>
        public static int FindReader()
        {
            try
            {
                return Syn_FindReader();
            }
            catch (Exception e)
            { }
            return -1;
        }

        public static int OpenPort1(int nPort, out string msg)
        {
            msg = "";
            int ret = -1;
            try
            {
                ret = Syn_OpenPort(nPort);
            }
            catch (Exception ex)
            {
                msg = ex.ToString();
                ret = -1;
            }
            return ret;
        }

        /// <summary>
        /// 打开端口
        /// </summary>
        /// <returns></returns>
        public static int OpenPort(int nPort)
        {

            int ret = -1;
            try
            {
                ret = Syn_OpenPort(nPort);
            }
            catch (Exception ex)
            {

                ret = -1;
            }
            return ret;
        }
        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="nPort"></param>
        /// <returns></returns>
        public static int SetMaxRFByte(int nPort)
        {
            return Syn_SetMaxRFByte(nPort, 80, 0);
        }
        public static int StartFindIDCard(int nPort, CardMsgs carmsgs)
        {
            IDCardData cardMsg = new IDCardData();
            int nRet = -1;
            byte[] pucIIN = new byte[4];
            byte[] pucSN = new byte[8];

            nRet = Syn_StartFindIDCard(nPort, ref pucIIN[0], 0);
            if (nRet != 0)
                return nRet;

            nRet = Syn_SelectIDCard(nPort, ref pucSN[0], 0);
            if (nRet != 0)
                return nRet;

            nRet = Syn_ReadMsg(nPort, 0, ref cardMsg);
            if (nRet != 0)
                return nRet;

            carmsgs.Name = cardMsg.Name;  //姓名  
            carmsgs.Sex = cardMsg.Sex;  //性别
            carmsgs.Nation = cardMsg.Nation;//民族
            carmsgs.Born = cardMsg.Born; //出生日期
            carmsgs.Address = cardMsg.Address; //地址
            carmsgs.IdCarNo = cardMsg.IDCardNo; //身份证号
         
            return nRet;

        }
    }
}
