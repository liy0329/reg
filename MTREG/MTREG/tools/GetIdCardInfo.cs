using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTREG.ihsp.bo;
using MTREG.common.bll;
using MTREG.common;

namespace MTREG.tools
{
    class GetIdCardInfo
    {
        /// <summary>
        /// 寻找读卡器
        /// </summary>
        public static bool Xzdkq(CardMsgs carmsgs)
        {

            string stmp;
            uint[] iBaud = new uint[1];
            int i = CardInterface.FindReader();

            if (i > 0)
            {
                if (i > 1000)
                {
                    stmp = Convert.ToString(i);
                    stmp = "  读卡器连接在USB " + stmp;
                    carmsgs.Message = stmp;
                    carmsgs.NPort = i;
                    return true;

                }
                else
                {
                    carmsgs.Message = "读卡器连接失败";
                    return false;
                }
            }
            else
            {
                carmsgs.Message = "  没有找到读卡器";
                return false;
            }

        }


        /// <summary>
        /// 获取信息
        /// </summary>
        public static bool Hqxx(CardMsgs carmsgs, int nPort)
        {
            //string stmp;
            byte[] pucIIN = new byte[4];
            byte[] pucSN = new byte[8];
            if (CardInterface.SetMaxRFByte(nPort) == 0)
            {
                if (CardInterface.StartFindIDCard(nPort, carmsgs) == 0)
                {
                    return true;
                }
                else
                {
                    carmsgs.Message1 = "获取身份证信息失败";
                    return false;
                }

            }
            else
            {
                carmsgs.Message1 = "获取身份证信息失败";
                return false;
            }
        }

        #region 寻找身份证读卡器 读取身份证信息

        /// <summary>
        /// 寻找身份证读卡器  读取身份证信息
        /// Writer:qinYangYang 2014/4/6
        /// </summary>
        /// <param name="carmsgInfo">身份证信息</param>
        /// <param name="errInfo">错误信息</param>
        /// <returns>0: 身份读取成功 65,128,129空身份证 其它读取失败</returns>
        public static int XzSFZdkq(ref CardMsgs carmsgInfo, out string errInfo)
        {

            //carmsgInfo = new CardMsgs();
            errInfo = "";
            string stmp;
            uint[] iBaud = new uint[1];
            int i = 0;
            if (carmsgInfo.NPort < 1000)
            {

                i = CardInterface.FindReader();
            }
            else
            {
                i = carmsgInfo.NPort;
            }

            if (i > 0)
            {
                if (i > 1000)
                {
                    carmsgInfo.NPort = i;
                    string openportmsg = "";
                    if (!(CardInterface.OpenPort1(carmsgInfo.NPort, out openportmsg) == 0))
                    {

                        errInfo = "打开端口失败" + openportmsg;
                        return -1;
                    }
                    int ret_tm = GetIdCardInfo.HQSFZXX(carmsgInfo, carmsgInfo.NPort, out openportmsg);
                    // SysWriteLogs.writeLogs1("身份证", DateTime.Now, openportmsg + ret_tm.ToString());
                    errInfo = openportmsg;
                    return ret_tm;

                }
                errInfo = "读卡器连接失败 (iPort < 1000)";
                return -1;
            }
            errInfo = "没有找到读卡器(iPort<0)";
            return -1;
        }

        #endregion

        #region 获取身份证信息

        /// <summary>
        /// 获取身份证信息
        /// </summary>
        /// <param name="carmsgs"></param>
        /// <param name="nPort"></param>
        /// <param name="errInfo"></param>
        /// <returns></returns>
        public static int HQSFZXX(CardMsgs carmsgs, int nPort, out string errInfo)
        {
            SysWriteLogs syswritelogs = new SysWriteLogs();
            errInfo = "";
            try
            {
                byte[] pucIIN = new byte[4];
                byte[] pucSN = new byte[8];
                if (CardInterface.SetMaxRFByte(nPort) == 0)
                {
                    int errNum = CardInterface.StartFindIDCard(nPort, carmsgs);
                    if (errNum != 0)
                    {
                        errInfo = "获取身份证信息失败[" + errNum.ToString() + "]";
                        return errNum;
                    }
                    return errNum;
                }
                else
                {
                    //carmsgs.Message1 = "获取身份证信息失败";
                    errInfo = "获取身份证信息失败[设置射频适配器]";
                    return -1;
                }
            }
            catch (Exception ex)
            {
                errInfo = "获取身份证信息失败,ex为：" + ex.ToString();
                return -1;
            }
        }

        #endregion
    }
}
