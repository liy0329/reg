using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using System.Threading;
using MTREG.common.bll;
using MTREG.medinsur.gzsyb.Entity;
using MTREG.common;
using MTREG.tools; 

namespace MTREG.medinsur.gzsyb.Util
{
    /// <summary>
    /// 自定义windows消息发送接收类（用于后台线程读取身份证信息）
    /// Wrtier:qinYangYang 2014/4/6
    /// </summary>
    public class CustomWindowsMessages
    {
        SysWriteLogs syswritelogs = new SysWriteLogs();

        //自定义的消息
        public const int USER = 0x500;
        public const int MYMESSAGE = USER + 1;
        
        ////自定义结构体
        //public struct My_lParam
        //{
        //    public int i;
        //    public string s;
        //}

        //发送消息API
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        //[DllImport("User32.dll", EntryPoint = "PostMessage")]
        private static extern int SendMessage(
            IntPtr hWnd, //信息发往的窗口句柄
            int Msg, //消息ID
            int wParam, //参数1
            ref  CardMsgsByStruct lParam
            );

        //获取窗体句柄的函数引入
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);


        /// <summary>
        /// 自定义发送Windows消息方法
        /// Writer:qinYangYang 2014/4/6
        /// </summary>

        public bool SendMessageInfo(ref int iPort)
        {
            CardMsgsByStruct carmsgInfo = new CardMsgsByStruct();
            IntPtr ptr = FindWindow(null, "门诊挂号");//获取接收消息的窗体句柄，这个地方有一点我们要注意Form1必须唯一，否则windows无法将消息正确发送
            bool rlts = false;
            string errInfo = "";
            
            CardMsgs _carmsgInfo = new CardMsgs();
            _carmsgInfo.NPort = iPort;
            int rlt = -1;
            Monitor.Enter(this);
            rlt = GetIdCardInfo.XzSFZdkq(ref _carmsgInfo, out errInfo);
            Monitor.Exit(this);
            if (rlt==0)
            {
                if (!string.IsNullOrEmpty(_carmsgInfo.Name) && !string.IsNullOrEmpty(_carmsgInfo.Sex) && !string.IsNullOrEmpty(_carmsgInfo.Born) && !string.IsNullOrEmpty(_carmsgInfo.Address) && !string.IsNullOrEmpty(_carmsgInfo.IdCarNo))
                {
                    carmsgInfo.Name = _carmsgInfo.Name.Trim();
                    carmsgInfo.Sex = _carmsgInfo.Sex.Trim();
                    carmsgInfo.Born = _carmsgInfo.Born.Trim();
                    carmsgInfo.Address = _carmsgInfo.Address.Trim();
                    carmsgInfo.IdCarNo = _carmsgInfo.IdCarNo.Trim();
                    SendMessage(ptr, MYMESSAGE, 1, ref carmsgInfo);//发送消息 
                    rlts = true;
                }
            }
            else if (rlt == 65 || rlt == 128 || rlt == 129)
            {
                iPort = _carmsgInfo.NPort;
                rlts = false;
            }

            else
            {
                SysWriteLogs.writeLogs1("读取身份证", DateTime.Now, errInfo);
                carmsgInfo.ErrInfo = errInfo;
                SendMessage(ptr, USER + 2, 1, ref carmsgInfo);//发送消息
                rlts = true;
            }
             return rlts;
            }
          
           
        }

    }

