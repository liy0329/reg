using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data;
using System.Windows.Forms;
using MTHIS.main.bll;
using MTREG.medinsur.hdyb.bll;
using MTREG.medinsur.hdyb;
using MTHIS.common;
using MTREG.common;
using MTREG.medinsur.hdyb.bo;
using MTREG.common.bll;
using System;
using System.IO;
using System.Xml;
using MTREG.medinsur.sjzsyb.clinic.bo;
using MTREG.medinsur.sjzsyb.bll;


namespace MTREG.medinsur.hdyb.dor
{
    class Zyybfysc
    {
        Sjzsyb syb = new Sjzsyb();
        int sss = 0;
        YBCJ yw1 = new YBCJ();
        JKDB jkdb = new JKDB();
        /// <summary>
        /// 医保上传费用明细
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <param name="patienttypeid"></param>
        /// <param name="grbh"></param>
        /// <param name="zyh"></param>
        /// <param name="txt"></param>
        /// <returns></returns>
        public RetMsg ybscfymx(int ihsp_id, string patienttypeid, string grbh, string zyh, Label txt)
        {
            sss = 0;
            string mesg = "";
            RetMsg ret = new RetMsg();
            ret.Retint = true;
            string sql = "select * from ihsp_costdet where insursync = 'N' and ihsp_id = " + ihsp_id;
            string counts = BllMain.Db.Select(sql).Tables[0].Rows.Count.ToString().Trim();
            
            int flag = 1;
            while (flag > 0)
            {
                flag = scfymx(ihsp_id, counts,zyh,out mesg, txt);
                sss = sss + 50;
                //if (sss > 5 * int.Parse(counts))
                //{
                //    return ret;
                //}
                if (flag >= 50)
                {
                    Thread.Sleep(1000);
                }
                if (flag == -1)
                {
                    ret.Retint = false;
                    ret.Mesg = mesg;
                    return ret;
                }
                ret.Mesg += mesg;
            }
            int flag1 = 1;
            while (flag1 > 0)
            {
                flag1 = scfymx_at(ihsp_id, counts, zyh, out mesg);
                if (flag1 >= 50)
                {
                    Thread.Sleep(1000);
                }
                if (flag1 == -1)
                {
                    ret.Retint = false;
                    ret.Mesg = mesg;
                    return ret;
                }
                ret.Mesg += mesg;
            }
            return ret;
            
        }
        /// <summary>
        /// 医保费用上传
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <param name="counts"></param>
        /// <param name="zyh"></param>
        /// <param name="mesg"></param>
        /// <param name="txt"></param>
        /// <returns></returns>
        private int scfymx(int ihsp_id, string counts,string zyh , out string mesg, Label txt)
        {
            mesg = "";
            //string sql = "select cost_insurtype_id from bas_patienttype where id=" + DataTool.addFieldBraces(patienttypeid);
            //DataTable dt = BllMain.Db.Select(sql).Tables[0];
            //string insurtypeid = dt.Rows[0]["cost_insurtype_id"].ToString();
            string sql1 = "SELECT "
                            + " inhospital.ihspcode AS AKC190, "//门诊（住院）号，
                            + " ihsp_costdet.id AS AKC220, "//处方号
                            + " ihsp_costdet.chargedate AS AKC221, "//处方日期 YYYYMMDDHH24MISS
                            + " bas_item.hiscode AS AKC515, "//医院收费项目编码
                            + " ihsp_costdet.NAME AS AKC516, "//医院收费项目名称
                            + " cost_insurcross.insurcode AS AKC222, "//中心收费项目编码
                            + " cost_insurcross.insurname AS AKC223, "//中心收费项目名称
                            + " bas_item.itemfrom AS AKC224, "//药品/诊疗/床位费
                            + " ihsp_costdet.prc AS AKC225, "//单价
                            + " ihsp_costdet.num AS AKC226, "//数量
                            + " ihsp_costdet.fee AS AKC227, "//金额（单价*数量=金额）
                            + " '' AS BKF050, "//中心医师编码
                            + " bas_depart.hiscode AS BKF040, "//中心科室编码
                            + " ihsp_costdet.unit AS BKA076, "//销售单位
                            + " bas_item.pkgunit AS CKAA08, "//包装单位
                            + " bas_item.pkgcount AS CKAA09 "//包装单位基本单位换算比例
                        + " FROM "
	                        + " ihsp_costdet "
	                        + " LEFT JOIN inhospital ON inhospital.id = ihsp_costdet.ihsp_id "
	                        + " LEFT JOIN cost_itemtype ON cost_itemtype.id = ihsp_costdet.itemtype_id "
	                        + " LEFT JOIN bas_item ON bas_item.id = ihsp_costdet.item_id  "
	                        + " AND bas_item.standcode NOT IN ( '', '0' ) "
	                        + " LEFT JOIN cost_insurcross ON cost_insurcross.item_id = bas_item.id "
                            + " LEFT JOIN bas_depart ON bas_depart.id = ihsp_costdet.diagndep_id  "
                            + " where ihsp_costdet.ihsp_id=" + ihsp_id
                            + " and ihsp_costdet.insursync='N' "
                            + " and ihsp_costdet.charged in ('CHAR')"
                            + " and ihsp_costdet.ypspbz not in(-1)"
                            + " ORDER BY ihsp_costdet.id DESC limit 50";
            DataTable datatable = BllMain.Db.Select(sql1).Tables[0];

            int retnum = 0;
            retnum = datatable.Rows.Count;
            if (retnum == 0)
            {
                mesg += "";
                return retnum;
            }

            List<KC22> kc22List = new List<KC22>();
            int I = 0;
            foreach( DataRow dr in datatable.Rows )
            {
                txt.Text = "正在上传费用：" + (sss + I + 1).ToString() + "/" + counts;
                txt.Update();
                KC22 kc22 = new KC22();
                kc22.AKC190 = dr["AKC190"].ToString().Trim();
                kc22.AKC220 = dr["AKC220"].ToString().Trim();
                kc22.AKC221 = dr["AKC221"].ToString().Trim();
                kc22.AKC515 = dr["AKC515"].ToString().Trim();
                kc22.AKC222 = dr["AKC222"].ToString().Trim();
                kc22.AKC378 = dr["AKC220"].ToString().Trim();
                kc22.BKF050 = dr["BKF050"].ToString().Trim();
                kc22.BKF040 = dr["BKF040"].ToString().Trim();
                kc22.BKA076 = dr["BKA076"].ToString().Trim();
                kc22.AKA067 = dr["BKA076"].ToString().Trim();
                kc22.CKAA08 = dr["CKAA08"].ToString().Trim();
                kc22.CKAA09 = dr["CKAA09"].ToString().Trim();
                kc22List.Add(kc22);
                I++;
            }
            
            //string boby = objkXML<KC22>.getXML("KC22", kc22List );

            string msgid = BllItemcrossSJZ.getTradingStream(); //交易流水号
            Sjzsyb_IN syb_in = new Sjzsyb_IN();

            string sql_ybjl = "SELECT AAC001,AKC020,AKC190 FROM Sybzyjl  WHERE AKC190 = " + DataTool.addFieldBraces(zyh);
            DataTable dtybjl = BllMain.Db.Select(sql_ybjl).Tables[0];
            string grbh = dtybjl.Rows[0]["AAC001"].ToString().Trim();
            string iccode = dtybjl.Rows[0]["AKC020"].ToString().Trim();
            string sql_gxsfck = "select sfck from inhospital where id='" + ihsp_id + "'";
            DataSet ds_sfck = BllMain.Db.Select(sql_gxsfck);
            if (ds_sfck.Tables[0].Rows[0]["sfck"].ToString() == "1")
            {
                syb_in.Ylzh = "0";
            }
            else
            {
                syb_in.Ylzh = grbh;
            }
            syb_in.Yw = "1103";
            syb_in.Rc = syb_in.Request_head()
                        + "<AAE140>0</AAE140>"//险种类型 
                        + "<AAC001>" + syb_in.Ylzh + "</AAC001>"//患者识别信息 
                        + "<AKB020>" + ProgramGlobal.AKB020 + "</AKB020>"//定点医疗机构编码 
                        + "<AKC190>" + zyh + "</AKC190>"//门诊/住院流水号 
                        + "<AKC020>" + iccode + "</AKC020>"//社保卡号 
                        + "<AKA130>21</AKA130>"//
                        + "<MSGNO>1103</MSGNO>"//交易代码 
                        + "<MSGID>" + msgid + "</MSGID>"//发送方交易流水号 
                        + "<GRANTID>H001</GRANTID>"//授权码 ,东软提供，必录
                        + "<ORGMSGNO></ORGMSGNO>"//原交易代码 
                        + "<ORGMSGID></ORGMSGID>"//原发送方交易流水号 
                        + "<OPERID>" + ProgramGlobal.User_id + "</OPERID>"//操作员编号 
                        + "<OPERNAME>" + ProgramGlobal.Nickname + "</OPERNAME>"//操作员姓名 
                        + "<BATNO>" + ProgramGlobal.batno + "</BATNO>"//业务周期号 
                        + "<OPTTIME>" + DateTime.Now.ToString("yyyyMMddHHmmss") + "</OPTTIME>"//系统时间
                        + "<INPUT></INPUT>"
                            + "<KC22XML>"
                            //+ boby
                            + "</KC22XML>"
                        + syb_in.Request_foot();
            int opt_ryjbxxhzh = syb.ybcjhs(syb_in);


            StringReader sr = new StringReader(syb_in.Cc);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            
            DataTable dt2 = ds.Tables["RESPONSEDATA"];
            
            string ReturnMsg = "";

            int returnnum = Convert.ToInt32(dt2.Rows[0]["RETURNNUM"].ToString());
            if (returnnum == -1)//错误，业务出参中的errorMSG为错误信息
            {
                ReturnMsg = dt2.Rows[0]["ERRORMSG"].ToString();
                mesg += "住院号：" + zyh +  "错误信息 " + ReturnMsg;
                return -1;
            }
            foreach (DataRow dr in datatable.Rows)
            {
                string iid = "";
                iid = dr["AKC220"].ToString().Trim();
                string sql_ybsc = "update ihsp_costdet set insursync='Y' where id = " + iid.ToString() + ";";
                if (dr["BKA076"].ToString().Trim().Equals("套"))
                {
                    sql_ybsc += "UPDATE ihsp_costdet SET inset = 'N' WHERE id" + iid.ToString() + ";";
                }
                int z = BllMain.Db.Update(sql_ybsc);
            }



            mesg += "";
            return retnum;
        }
        /// <summary>
        /// 按套限价项目使用情况上传
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <param name="counts"></param>
        /// <param name="zyh"></param>
        /// <param name="mesg"></param>
        /// <returns></returns>
        public int scfymx_at(int ihsp_id, string counts, string zyh, out string mesg)
        {
            mesg = "";

            string sql1 = "SELECT "
                            + " ihsp_costdet.id AS AKC220, "//处方号
                            + " cost_insurcross.insurcode AS AKC222, "//中心收费项目编码
                            + " cost_insurcross.insurname AS AKC223, "//中心收费项目名称
                            + " ihsp_costdet.num AS AKC226, "//数量
                        + " FROM "
                            + " ihsp_costdet "
                            + " LEFT JOIN bas_item ON bas_item.id = ihsp_costdet.item_id  "
                            + " AND bas_item.standcode NOT IN ( '', '0' ) "
                            + " LEFT JOIN cost_insurcross ON cost_insurcross.item_id = bas_item.id "
                            + " where ihsp_costdet.ihsp_id=" + ihsp_id
                            + " and ihsp_costdet.charged in ('CHAR')"
                            + " and ihsp_costdet.ypspbz not in(-1)"
                            + " AND ihsp_costdet.inset NOT IN ('Y') "
                            + " AND bas_item.pkgunit IN ('套') "
                            + " ORDER BY ihsp_costdet.id DESC limit 50";
            DataTable datatable = BllMain.Db.Select(sql1).Tables[0];

            int retnum = 0;
            retnum = datatable.Rows.Count;
            if (retnum == 0)
            {
                mesg += "";
                return retnum;
            }
            string boby = "";
            string AKC222 = "";
            string AKC223 = "";
            string AKC226 = "";
            foreach (DataRow dr in datatable.Rows)
            {
                AKC222 = dr["AKC222"].ToString().Trim();
                AKC223 = dr["AKC223"].ToString().Trim();
                AKC226 = dr["AKC226"].ToString().Trim();

                boby += "<INROW>"
                        + "<AKC222>" + AKC222 + "</AKC222>"
                        + "<AKC223>" + AKC223 + "</AKC223>"
                        + "<CKAA11>" + AKC226 + "</CKAA11>"
                    + "</INROW>";
            }


            string msgid = BllItemcrossSJZ.getTradingStream(); //交易流水号
            Sjzsyb_IN syb_in = new Sjzsyb_IN();

            string sql_ybjl = "SELECT AAC001,AKC020,AKC190 FROM Sybzyjl  WHERE AKC190 = " + DataTool.addFieldBraces(zyh);
            DataTable dtybjl = BllMain.Db.Select(sql_ybjl).Tables[0];
            string grbh = dtybjl.Rows[0]["AAC001"].ToString().Trim();
            string iccode = dtybjl.Rows[0]["AKC020"].ToString().Trim();
            string sql_gxsfck = "select sfck from inhospital where id='" + ihsp_id + "'";
            DataSet ds_sfck = BllMain.Db.Select(sql_gxsfck);
            if (ds_sfck.Tables[0].Rows[0]["sfck"].ToString() == "1")
            {
                syb_in.Ylzh = "0";
            }
            else
            {
                syb_in.Ylzh = grbh;
            }
            syb_in.Yw = "1130";
            syb_in.Rc = syb_in.Request_head()
                        + "<AAE140>0</AAE140>"//险种类型 
                        + "<AAC001>" + syb_in.Ylzh + "</AAC001>"//患者识别信息 
                        + "<AKB020>" + ProgramGlobal.AKB020 + "</AKB020>"//定点医疗机构编码 
                        + "<AKC190>" + zyh + "</AKC190>"//门诊/住院流水号 
                        + "<AKC020>" + iccode + "</AKC020>"//社保卡号 
                        + "<AKA130>21</AKA130>"//
                        + "<MSGNO>1130</MSGNO>"//交易代码 
                        + "<MSGID>" + msgid + "</MSGID>"//发送方交易流水号 
                        + "<GRANTID>H001</GRANTID>"//授权码 ,东软提供，必录
                        + "<ORGMSGNO></ORGMSGNO>"//原交易代码 
                        + "<ORGMSGID></ORGMSGID>"//原发送方交易流水号 
                        + "<OPERID>" + ProgramGlobal.User_id + "</OPERID>"//操作员编号 
                        + "<OPERNAME>" + ProgramGlobal.Nickname + "</OPERNAME>"//操作员姓名 
                        + "<BATNO>" + ProgramGlobal.batno + "</BATNO>"//业务周期号 
                        + "<OPTTIME>" + DateTime.Now.ToString("yyyyMMddHHmmss") + "</OPTTIME>"//系统时间
                        + "<INPUT>"
                            + boby
                        + "</INPUT>"
                        + syb_in.Request_foot();
            int opt_ryjbxxhzh = syb.ybcjhs(syb_in);


            StringReader sr = new StringReader(syb_in.Cc);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);

            DataTable dt2 = ds.Tables["RESPONSEDATA"];

            string ReturnMsg = "";

            int returnnum = Convert.ToInt32(dt2.Rows[0]["RETURNNUM"].ToString());
            if (returnnum == -1)//错误，业务出参中的errorMSG为错误信息
            {
                ReturnMsg = dt2.Rows[0]["ERRORMSG"].ToString();
                mesg += "住院号：" + zyh + "错误信息 " + ReturnMsg;
                return -1;
            }
            foreach (DataRow dr in datatable.Rows)
            {
                string iid = "";
                iid = dr["AKC220"].ToString().Trim();
                string sql_ybsc = "UPDATE ihsp_costdet SET inset = 'N' WHERE id" + iid.ToString() + ";";
                int z = BllMain.Db.Update(sql_ybsc);
            }

            return retnum;
        }
    }
}