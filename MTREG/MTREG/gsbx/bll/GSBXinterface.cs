using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Cache;
using System.Xml.Serialization;
using System.Web.Services.Description;
using zhongluyiyuan.Util;
using System.Data;
using MTREG.gsbx1;
using zhongluyiyuan.gsbx;
using System.Xml;
using MTHIS.tools;
using MTREG.common.bll;
namespace zhongluyiyuan.gsbx.bll
{
    class GSBXinterface 
    {
        SendHisControllerImplService webServ = new SendHisControllerImplService();
        public GSBX_OUT request(GSBX_IN in1)
        {
            GSBX_OUT out1 = new GSBX_OUT();
            string[] log = new string[6];


                log[0] = DateTime.Now.ToString("yyyy-MM-dd");

            log[1] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "==>【" + in1.Log_name + "】开始----------------------------------------------------------------------------";
            log[2] = "		      【In-PostData】\r\n" + in1.YwData;
            log[3] = "		      【In-DecodeData】\r\n" + Base64.decodebase64(in1.YwData);
            string outString = "";
            try
            {
                
                if (in1.YwName == "login")
                {
                    outString = webServ.login(in1.YwData);
                }
                else if (in1.YwName == "logout")
                {
                    outString = webServ.logout(in1.YwData);
                }
                else if (in1.YwName == "getInjuryByNameAndId")
                {
                    outString = webServ.getInjuryByNameAndId(in1.YwData);
                }
                else if (in1.YwName == "register")
                {
                    outString = webServ.register(in1.YwData);
                }
                else if (in1.YwName == "regundo")
                {
                    outString = webServ.regundo(in1.YwData);
                }
                else if (in1.YwName == "sendAdviceInfo")
                {
                    outString = webServ.sendAdviceInfo(in1.YwData);
                }
                else if (in1.YwName == "sendMedInfo")
                {
                    outString = webServ.sendMedInfo(in1.YwData);
                }
                else if (in1.YwName == "invalidData")
                {
                    outString = webServ.invalidData(in1.YwData);
                }
                else if (in1.YwName == "discharge")
                {
                    outString = webServ.discharge(in1.YwData);
                }
                else if (in1.YwName == "dischargeRollback")
                {
                    outString = webServ.dischargeRollback(in1.YwData);
                }
                else if (in1.YwName == "leaveHos")
                {
                    outString = webServ.leaveHos(in1.YwData);
                }
                else if (in1.YwName == "leaveHosUndo")
                {
                    outString = webServ.leaveHosUndo(in1.YwData);
                }
                else if (in1.YwName == "getAuditData")
                {
                    outString = webServ.getAuditData(in1.YwData);
                }
                else if (in1.YwName == "sendCure")
                {
                    outString = webServ.sendCure(in1.YwData);
                }
                else if (in1.YwName == "revokeCure")
                {
                    outString = webServ.revokeCure(in1.YwData);
                }
                else if (in1.YwName == "getCure")
                {
                    outString = webServ.getCure(in1.YwData);
                }
                else if (in1.YwName == "getReport")
                {
                    outString = webServ.getReport(in1.YwData);
                }
                else if (in1.YwName == "getJSSheet")
                {
                    outString = webServ.getJSSheet(in1.YwData);
                }
                else if (in1.YwName == "getReportBatch")
                {
                    outString = webServ.getReportBatch(in1.YwData);
                }
                else if (in1.YwName == "getCureBatch")
                {
                    outString = webServ.getCureBatch(in1.YwData);
                }
                else if (in1.YwName == "getPerDetail")
                {
                    outString = webServ.getPerDetail(in1.YwData);
                }

                StringReader StrStream = new StringReader(Base64.decodebase64(outString));
                DataSet ds_init = new DataSet();
                ds_init.ReadXml(new StringReader(StrStream.ReadToEnd()));
                out1.Ds = ds_init;
            }
            
            catch (WebException ex)
            {
                out1.Message = ex.Message;
                out1.State = "2";
            }
            log[4] = "		      【Out-PostData】\r\n" + outString;
            log[5] = "		      【Out-DecodeData】\r\n" + Base64.decodebase64(outString);
            SysWriteLogs.writeLogs1("工伤日志", DateTime.Now,string.Join("\r\n", log));

            return out1;
        }
    }
}
