using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using MTREG.medinsur.gysyb.bo;

namespace MTREG.medinsur.gysyb.bll
{
    class ReadCardYb
    {
        //打开读卡器
        [DllImport("SGZ_SSSReader.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int SGZ_IFD_Open(int iReaderPort, Int32[] iReaderhandle, StringBuilder iERRInfo);

        //获取PSAM卡编号
        [DllImport("SGZ_SSSReader.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int SGZ_SAM_ReadNmuber(int iReaderPort, StringBuilder iOutFileData, StringBuilder iERRInfo);

        //获取用户密码
        [DllImport("SGZ_SSSReader.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int SGZ_IFD_GetPIN(int iReaderHandle, int iDevType, StringBuilder szPasswd, StringBuilder iERRInfo);

        //获取社保卡信息
        [DllImport("SGZ_SSSReader.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int SGZ_ICC_ReadCardInfo(int iReaderHandle, int iDevType, string szPasswd, string iInputFileAddr, StringBuilder iOutFileData, StringBuilder iERRInfo);

        //关闭读卡器
        [DllImport("SGZ_SSSReader.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int SGZ_IFD_Close(int iReaderHandle, StringBuilder iERRInfo);

        /// <summary>
        /// 打开读卡器
        /// </summary>
        /// <returns></returns>
        public static bool dkdkq(StringBuilder iERRInfo, Int32[] iReaderhandle)
        {
            int iReaderPort = 100;
            iReaderhandle[0] = 1024;
            int ret = SGZ_IFD_Open(iReaderPort, iReaderhandle, iERRInfo);
            if (ret != 0)
            {
                //          Tool.SysWriteLogs.writeLogs("Eorr", Convert.ToDateTime(BillSysBase.currDate()), "打开读卡器 错误信息：" + iERRInfo.ToString());
                return false;
            }
            else
            {

                return true;
            }

        }
        /// <summary>
        /// 获取PSAM卡编号
        /// </summary>
        public static bool hqPSAMkbh(int iReaderHandle, StringBuilder iOutFileData, StringBuilder iERRInfo)
        {
            //StringBuilder iERRInfo = new StringBuilder();
            int ret = SGZ_SAM_ReadNmuber(iReaderHandle, iOutFileData, iERRInfo);
            if (ret != 0)
            {
                //            Tool.SysWriteLogs.writeLogs("Eorr", Convert.ToDateTime(BillSysBase.currDate()), "获取PSAM卡编号 错误信息：" + iERRInfo.ToString());
                return false;
            }
            else
            {
                return true;
            }

        }
        /// <summary>
        /// 获取用户密码
        /// </summary>
        public static bool hqyhmm(int iReaderHandle, StringBuilder szPasswd, StringBuilder iERRInfo)
        {
            int iDevType = 100;
            int ret = SGZ_IFD_GetPIN(iReaderHandle, iDevType, szPasswd, iERRInfo);
            if (ret != 0)
            {
                //              Tool.SysWriteLogs.writeLogs("Eorr", Convert.ToDateTime(BillSysBase.currDate()), "获取用户密码 错误信息：" + iERRInfo.ToString());
                return false;
            }
            else
            {
                return true;
            }

        }
        /// <summary>
        /// 获取社保卡信息
        /// </summary>
        /// <returns></returns>
        public static bool hqsbkxx(int iReaderHandle, int iCardType, string iPassword, StringBuilder iOutFileData, StringBuilder iERRInfo)
        {

            string iInputFileAddr = "MF|EF05|07|$MF|EF06|01|$";
            int ret = SGZ_ICC_ReadCardInfo(iReaderHandle, iCardType, iPassword, iInputFileAddr, iOutFileData, iERRInfo);
            if (ret != 0)
            {
                //             Tool.SysWriteLogs.writeLogs("Eorr", Convert.ToDateTime(BillSysBase.currDate()), "获取社保卡信息 错误信息：" + iERRInfo.ToString());
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 关闭读卡器
        /// </summary>
        /// <returns></returns>
        public static bool gbdkq(int iReaderHandle, StringBuilder iERRInfo)
        {
            int ret = SGZ_IFD_Close(iReaderHandle, iERRInfo);
            if (ret != 0)
            {
                //               Tool.SysWriteLogs.writeLogs("Eorr", Convert.ToDateTime(BillSysBase.currDate()), "获取社保卡信息 错误信息：" + iERRInfo.ToString());
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ReadCard(ReadYbCard_entity readcard, int iCardType)
        {
            Int32[] iReaderhandle = new Int32[1];
            StringBuilder iERRInfo = new StringBuilder(2048);
            StringBuilder iOutFileData = new StringBuilder(2048);
            StringBuilder szPasswd = new StringBuilder(2048);
            ////打开读卡器
            if (!dkdkq(iERRInfo, iReaderhandle))
            {
                readcard.IERRInfo = iERRInfo.ToString();
                return false;
            }
            readcard.IReaderhandle = iReaderhandle[0].ToString();
            ////获得psamk编号
            if (!hqPSAMkbh(iReaderhandle[0], iOutFileData, iERRInfo))
            {
                readcard.IERRInfo = iERRInfo.ToString();
                return false;
            }
            Bjq.bjqts("g");
            readcard.PSAMkh = iOutFileData.ToString();//处理成功时返回PSAM卡编号
            ////获取密码
            if (!hqyhmm(iReaderhandle[0], szPasswd, iERRInfo))
            {
                readcard.IERRInfo = iERRInfo.ToString();
                return false;
            }
            readcard.SzPasswd = szPasswd.ToString();
            if (iCardType.ToString().Equals("1"))
            {
                return true;
            }
            ////获取社保卡信息
            if (!hqsbkxx(iReaderhandle[0], iCardType, readcard.SzPasswd, iOutFileData, iERRInfo))
            {
                readcard.IERRInfo = iERRInfo.ToString();
                return false;
            }
            readcard.cardId = iOutFileData.ToString().Split('|')[2];////社保卡卡号
            readcard.Icd_Id = iOutFileData.ToString().Split('|')[5];////身份证号
            if (!gbdkq(iReaderhandle[0], iERRInfo))
            {
                readcard.IERRInfo = iERRInfo.ToString();
                return false;
            }
            return true;
        }
    }
}
