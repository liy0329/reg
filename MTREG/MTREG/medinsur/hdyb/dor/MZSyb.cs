using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTHIS.main.bll;
using MTREG.medinsur.hdyb.bll;
using MTREG.medinsur.hdyb.clinic.bo;
using MTHIS.tools;
using MTHIS.common;
using MTREG.medinsur.hdyb.dor;
using MTREG.clinic.bo;
using MTREG.common.bll;
using MTREG.medinsur.sjzsyb.bean;
using MTREG.medinsur.sjzsyb.bll;
using MTREG.medinsur.hdyb.bo;
using MTREG.common;
using MTREG.clinic.bll;

namespace MTREG.medinsur.hdyb.dor
{
    public class MZSyb
    {
        InsurInfo insurinfo = new InsurInfo();
        BllItemcrossSJZ bllItemcrossSJZ = new BllItemcrossSJZ();
        SjzybInterface sjzybInterface = new SjzybInterface();
        JKDB jkdb = new JKDB();
        YBCJ yw1 = new YBCJ();
        //读疾病药品对照信息
        public bool ypdzxx(ref string err_mesg, Mzybdk mzybdk, DataGridView dgvfy, string ww)
        {
            #region
            int dgvcount = dgvfy.Rows.Count;//自动收费
            if (ww == "1")//手动收费
            {
                dgvcount = dgvfy.Rows.Count - 1;
            }
            //调用读疾病药品对照信息
            YBCJ_IN yw_in_djbypdzxx = new YBCJ_IN();
            yw_in_djbypdzxx.Yw = "BB31ZK06";
            yw_in_djbypdzxx.Ybcjbz = "0";
            yw_in_djbypdzxx.Ylzh = mzybdk.Grbh;
            yw_in_djbypdzxx.Hisjl = mzybdk.Grbh;
            for (int i = 0; i < dgvcount; i++)
            {
                #region
                try
                {
                    string mtprodiid = dgvfy.Rows[i].Cells["item_id"].Value.ToString().Trim();

                    string xmbm = "select standcode as xmbm,name as xmmc from bas_item where id = " + mtprodiid + "  ";
                    DataTable dt = BllMain.Db.Select(xmbm).Tables[0];
                    string ybbm = dt.Rows[0]["xmbm"].ToString().Trim();
                    if (string.IsNullOrEmpty(ybbm))
                    {
                        ybbm = "999999999";
                    }
                    yw_in_djbypdzxx.Rc = mzybdk.Jbbm + "|" + ybbm;
                    int opt_djbypdzxx = yw1.ybcjhs(yw_in_djbypdzxx);
                    if (opt_djbypdzxx != 0)
                    {
                        err_mesg += "药品与疾病对照出错: " + dt.Rows[0]["xmmc"].ToString().Trim() + yw_in_djbypdzxx.Mesg + "\r\n";
                        continue;
                    }
                    else
                    {
                        if (yw_in_djbypdzxx.Cc.Split('|')[0] == "0")
                        {
                            err_mesg += "项目: " + dt.Rows[0]["xmmc"].ToString().Trim() + " 不在疾病目录里，按自费处理!\r\n";
                            continue;
                        }
                    }
                }
                catch
                { continue; }
                #endregion
            }
            if (!string.IsNullOrEmpty(err_mesg))
            {
                return false;
            }
            return true;
            #endregion
        }
        public bool ybyjs(mz_dk mzybdk, string register_id, string ysname, string ksname, string blbcard, ClinicInvoice clinicInvoice, double[] yb)
        {

            string nowDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string ryrq = nowDateTime;
            string fph = clinicInvoice.Invoice;
            string ys = ysname;
            string ks = ksname;
            string ickh = mzybdk.DK_OUT.AKC020;
            string xm = mzybdk.DK_OUT.AAC003;
            string grbh = mzybdk.DK_OUT.AAC001;
            string yllb = mzybdk.AKA130;//
            string[] jbbm = mzybdk.AKC193.Split(',');
            string[] jbmc = mzybdk.AKC140.Split(',');
            string jbr = ProgramGlobal.Nickname;
            string dqrq = nowDateTime;
            string netdep = "";
            string netdoc = "";
            string mesg = "";
            try
            {
                 netdep = bllItemcrossSJZ.getDepCode(register_id);
                 netdoc = bllItemcrossSJZ.getDocCode(register_id);
            }catch(  Exception ex)
            {
                mesg += "没有查询到对应的医保医生或科室！";
            }

            string ypsql = @"SELECT
	                            register.billcode AS AKC190,
	                            clinic_costdet.id AS AKC220,
	                            clinic_costdet.rcpdate AS AKC221,
	                            bas_item.hiscode AS AKC515,
	                            clinic_costdet. NAME AS AKC516,
	                            cost_insurcross.insurcode AS AKC222,
	                            cost_insurcross.insurname AS AKC223,
	                            bas_item.itemfrom AS AKC224,
	                            clinic_costdet.prc AS AKC225,
	                            clinic_costdet.num AS AKC226,
	                            clinic_costdet.fee AS AKC227,
	                            (SELECT BKF050 FROM contrast_doc WHERE contrast_doc.bas_doctor_id = clinic_costdet.doctor_id GROUP BY BKF050) AS BKF050,
	                            (SELECT AKF001 FROM contrast_dep WHERE contrast_dep.bas_depart_id = clinic_costdet.depart_id GROUP BY AKF001) AS BKF040,
	                            clinic_costdet.unit AS BKA076,
                            	bas_item.pkgunit AS CKAA08,
                            	bas_item.pkgcount AS CKAA09,
                                cost_insuritem.AKA068,
                                cost_insuritem.AKA068II ,
                                cost_insuritem.limitprc
                            FROM
                            	clinic_costdet
                            LEFT JOIN register ON register.id = clinic_costdet.regist_id
                            LEFT JOIN cost_itemtype ON cost_itemtype.id = clinic_costdet.itemtype_id
                            LEFT JOIN bas_item ON bas_item.id = clinic_costdet.item_id
                            LEFT JOIN cost_insurcross ON cost_insurcross.item_id = bas_item.id
                            LEFT JOIN cost_insuritem ON cost_insurcross.cost_insuritem_id = cost_insuritem.id
                            WHERE
	                            clinic_costdet.insursync = 'N'
                            AND clinic_costdet.charged IN ('OO')
	                        AND clinic_costdet.id in (" + clinicInvoice.Clinic_costdet_ids + ")";
            DataTable zyjlds = BllMain.Db.Select(ypsql).Tables[0];
            //预结算
            SJZYB_IN<Mzyjs_IN> yb_in_yjs = new SJZYB_IN<Mzyjs_IN>();
            
            yb_in_yjs.INPUT = new List<Mzyjs_IN>();
            yb_in_yjs.KC21XML = new sjzsyb.bean.KC21();
            yb_in_yjs.KC22XML = new List<sjzsyb.bean.KC22>();

            Mzyjs_IN dom = new Mzyjs_IN();
            dom.AAC001 = grbh;
            yb_in_yjs.INPUT.Add(dom);


            decimal zfy = 0; //总费用
            string ybmzh = zyjlds.Rows[0]["AKC190"].ToString() + "_" + DateTime.Now.ToString("mmss");
            foreach (DataRow dr in zyjlds.Rows)
            {
                try
                {
                    sjzsyb.bean.KC22 kc22 = new sjzsyb.bean.KC22();
                    kc22.AKC190 = ybmzh;  //dr["AKC190"].ToString().Trim();
                    kc22.AKC220 = dr["AKC220"].ToString().Trim();
                    kc22.AKC221 = Convert.ToDateTime(dr["AKC221"].ToString().Trim()).ToString("yyyyMMddHHmmss");
                    kc22.AKC515 = dr["AKC515"].ToString().Trim();
                    kc22.AKC516 = dr["AKC516"].ToString().Trim();
                    kc22.AKC222 = dr["AKC222"].ToString().Trim();
                    kc22.AKC223 = dr["AKC223"].ToString().Trim();
                    if (dr["AKC224"].ToString().Trim().ToUpper().Equals("DRUG"))
                    {
                        dr["AKC224"] = "1";
                    }
                    else if (dr["AKC224"].ToString().Trim().ToUpper().Equals("COST"))
                    {
                        dr["AKC224"] = "2";
                    }
                    else if (dr["AKC224"].ToString().Trim().ToUpper().Equals("STUFF"))
                    {
                        dr["AKC224"] = "3";
                    }
                    kc22.AKC224 = dr["AKC224"].ToString().Trim();
                    kc22.AKC225 = dr["AKC225"].ToString().Trim();
                    kc22.AKC226 = dr["AKC226"].ToString().Trim();
                    kc22.AKC227 = Double.Parse(dr["AKC227"].ToString().Trim()).ToString("0.00");
                    kc22.AKC378 = DateTime.Now.ToString("yyyyMMddHHmmss") + dr["AKC220"].ToString().Trim();
                    kc22.BKF050 = dr["BKF050"].ToString().Trim();
                    kc22.BKF040 = dr["BKF040"].ToString().Trim();
                    kc22.BKA076 = dr["BKA076"].ToString().Trim();
                    kc22.AKA067 = dr["BKA076"].ToString().Trim();
                    kc22.CKAA08 = dr["CKAA08"].ToString().Trim();
                    kc22.CKAA09 = dr["CKAA09"].ToString().Trim();
                    yb_in_yjs.KC22XML.Add(kc22);
                    zfy += Decimal.Parse(kc22.AKC227);

                    if (String.IsNullOrEmpty(kc22.AKC223))
                    {
                        mesg += "名称：" + kc22.AKC516 + "，院内编码：" + kc22.AKC515 + ",未对照" + "\r\n";
                    }

                    //if ((kc22.AKC224 != "1" && dr["limitprc"].ToString() != "0") && (Double.Parse(kc22.AKC225) > Double.Parse(dr["AKA068II"].ToString())))
                    //    mesg += "名称：" + kc22.AKC516 + "，院内编码：" + kc22.AKC515 + ",属于" + (dr["limitprc"].ToString() == "2" ? "限额" : "限价") + "项目，当前单价：" + kc22.AKC225 + ",限价：" + dr["AKA068II"].ToString() + "\r\n";
                    //if ((kc22.AKC224 == "1" && dr["limitprc"].ToString() != "0") && (Double.Parse(kc22.AKC225) > Double.Parse(dr["AKA068"].ToString())))
                    //    mesg += "名称：" + kc22.AKC516 + "，院内编码：" + kc22.AKC515 + ",属于" + (dr["limitprc"].ToString() == "2" ? "限额" : "限价") + "项目，当前单价：" + kc22.AKC225 + ",限价：" + dr["AKA068II"].ToString() + "\r\n";

                    //string sql_up = "update clinic_costdet set AKC378 = " + DataTool.addFieldBraces(kc22.AKC378) + " where id = " + DataTool.addFieldBraces(kc22.AKC220);
                    //BllMain.Db.Update(sql_up);
                }
                catch (Exception e)
                {
                    mesg += e + "\r\n";
                }
            }
            if (!string.IsNullOrEmpty(mesg))
            {

                FrmMesg frmmesg = new FrmMesg();
                frmmesg.StartPosition = FormStartPosition.CenterScreen;
                frmmesg.In_mesg = mesg;
                frmmesg.ShowDialog();
                if (frmmesg.Falg == false)
                {
                    return false;
                }
            }

            yb_in_yjs.KC21XML.AKC190 = ybmzh;
            yb_in_yjs.KC21XML.AKA130 = yllb;
            yb_in_yjs.KC21XML.AKC192 = Convert.ToDateTime(ryrq).ToString("yyyyMMddHHmmss");
            yb_in_yjs.KC21XML.AKC193 = jbbm[0];
            yb_in_yjs.KC21XML.AKC196 = jbbm[0];//
            yb_in_yjs.KC21XML.AAE011 = jbr;
            yb_in_yjs.KC21XML.AAE036 = Convert.ToDateTime(dqrq).ToString("yyyyMMddHHmmss");
            yb_in_yjs.KC21XML.AKC008 = ys;
            yb_in_yjs.KC21XML.AKC025 = ks;
            yb_in_yjs.KC21XML.AKC140 = jbmc[0];
            yb_in_yjs.KC21XML.AKC141 = jbmc[0];//
            yb_in_yjs.KC21XML.AKC031 = zyjlds.Rows[0]["AKC190"].ToString();
            yb_in_yjs.KC21XML.BKF040 = netdep;
            yb_in_yjs.KC21XML.BKF050 = netdoc;
            if (!String.IsNullOrEmpty(blbcard))
                yb_in_yjs.KC21XML.AKC031 = blbcard;

            for (int i = 1; i <= jbbm.Length; i++)
            {
                yb_in_yjs.KC21XML.KC33XML += "<KC33ROW>"
                                     + "<AKC190>" + ybmzh + "</AKC190>"//门诊（住院）号
                                     + "<BKE150>" + i + "</BKE150>"//诊断顺序
                                     + "<AKC221>" + DateTime.Now.ToString("yyyyMMddHHmmss") + "</AKC221>"//确诊日期
                                     + "<AKA120>" + jbbm[i - 1] + "</AKA120>"//诊断编码
                                     + "<AKA121>" + jbmc[i - 1] + "</AKA121>"//诊断名称
                                     + "<AAE013></AAE013>"//备注
                                     + "</KC33ROW>";
            }

            yb_in_yjs.AAC001 = "0";
            yb_in_yjs.AKC190 = ybmzh;
            yb_in_yjs.AKC020 = mzybdk.DK_OUT.AKC020;
            yb_in_yjs.MSGNO = "1107";
            yb_in_yjs.AKA130 = yllb;


            zyjs_OUT yb_out_yjs = new zyjs_OUT();
            int ret = sjzybInterface.mzyjs(yb_in_yjs, ref  yb_out_yjs);
            if (ret == -1)
            {
                SysWriteLogs.writeLogs1("Erorr", DateTime.Now, "姓名：" + xm + " 预结算失败医保信息 " + yb_out_yjs.ERRORMSG);
                MessageBox.Show(yb_out_yjs.ERRORMSG + "预结算失败");
                return false;
            }
            //读取门诊卡余额
            string balance = "";
            Mifare dk = new Mifare();
            Member member = new Member();
            dk.OpenPoint();
            string fareuid = dk.FindCard();
            dk.ClosePoint();
            member.Mzfare = fareuid;
            member.Cardstat = MemberCardStat.YES.ToString();
            BillMember billMember = new BillMember();
            DataTable dt_hsp = billMember.memberSearch(member, "", "");
            if (dt_hsp.Rows.Count > 0)
            {
                balance = dt_hsp.Rows[0]["balance"].ToString();
            }
            else
            {
                MessageBox.Show("读取门诊卡失败！请重试。");
                return false;
            }
            //预结算显示
            Frm_MzCxJs ybyjs = new Frm_MzCxJs();
            ybyjs.Js_out = yb_out_yjs;
            ybyjs.balance = balance;
            ybyjs.StartPosition = FormStartPosition.CenterScreen;
            ybyjs.ShowDialog();
            if (ybyjs.Flag == false)
            {
                MessageBox.Show("预结算成功，没有结算");
                return false;
            }
            yb[0] = DataTool.Getdouble(yb_out_yjs.AKC255);//yb[0] 账户支付
            yb[1] = DataTool.Getdouble(yb_out_yjs.AKC087);//yb[1]账户余额
            yb[3] = DataTool.Getdouble(yb_out_yjs.AKC261);//yb[3]现金支付
            yb[2] = DataTool.Getdouble(yb_out_yjs.AKC780);//yb[2]医保报销

            return true;
        }
        /// <summary>
        /// 门诊结算
        /// </summary>
        /// <param name="mzybdk"></param>
        /// <param name="register_id"></param>
        /// <param name="ysname"></param>
        /// <param name="ksname"></param>
        /// <param name="clinicInvoice"></param>
        /// <param name="yb"></param>
        /// <returns></returns>
        public bool ybjs(mz_dk mzybdk, string register_id, string ysname, string ksname, string blbcard, ClinicInvoice clinicInvoice, double[] yb)
        {

            string nowDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string ryrq = nowDateTime;
            string fph = clinicInvoice.Invoice;
            string ys = ysname;
            string ks = ksname;
            string ickh = mzybdk.DK_OUT.AKC020;
            string xm = mzybdk.DK_OUT.AAC003;
            string grbh = mzybdk.DK_OUT.AAC001;
            string yllb = mzybdk.AKA130;//
            string[] jbbm = mzybdk.AKC193.Split(',');
            string[] jbmc = mzybdk.AKC140.Split(',');
            string jbr = ProgramGlobal.Nickname;
            string dqrq = nowDateTime;

            string netdep = bllItemcrossSJZ.getDepCode(register_id);
            string netdoc = bllItemcrossSJZ.getDocCode(register_id);

            string ypsql = @"SELECT
	                            register.billcode AS AKC190,
	                            clinic_costdet.id AS AKC220,
	                            clinic_costdet.rcpdate AS AKC221,
	                            bas_item.hiscode AS AKC515,
	                            clinic_costdet. NAME AS AKC516,
	                            cost_insurcross.insurcode AS AKC222,
	                            cost_insurcross.insurname AS AKC223,
	                            bas_item.itemfrom AS AKC224,
	                            clinic_costdet.prc AS AKC225,
	                            clinic_costdet.num AS AKC226,
	                            clinic_costdet.fee AS AKC227,
	                            (SELECT BKF050 FROM contrast_doc WHERE contrast_doc.bas_doctor_id = clinic_costdet.doctor_id GROUP BY BKF050) AS BKF050,
	                            (SELECT AKF001 FROM contrast_dep WHERE contrast_dep.bas_depart_id = clinic_costdet.depart_id GROUP BY AKF001) AS BKF040,
	                            clinic_costdet.unit AS BKA076,
                            	bas_item.pkgunit AS CKAA08,
                            	bas_item.pkgcount AS CKAA09,
                                cost_insuritem.AKA068,
                                cost_insuritem.AKA068II ,
                                cost_insuritem.limitprc
                            FROM
                            	clinic_costdet
                            LEFT JOIN register ON register.id = clinic_costdet.regist_id
                            LEFT JOIN cost_itemtype ON cost_itemtype.id = clinic_costdet.itemtype_id
                            LEFT JOIN bas_item ON bas_item.id = clinic_costdet.item_id
                            LEFT JOIN cost_insurcross ON cost_insurcross.item_id = bas_item.id
                            LEFT JOIN cost_insuritem ON cost_insurcross.cost_insuritem_id = cost_insuritem.id
                            WHERE
	                            clinic_costdet.insursync = 'N'
                            AND clinic_costdet.charged IN ('OO')
	                        AND clinic_costdet.id in (" + clinicInvoice.Clinic_costdet_ids + ")";
            DataTable zyjlds = BllMain.Db.Select(ypsql).Tables[0];
            //预结算
            SJZYB_IN<DBNull> yb_in_yjs = new SJZYB_IN<DBNull>();
            yb_in_yjs.KC21XML = new sjzsyb.bean.KC21();
            yb_in_yjs.KC22XML = new List<sjzsyb.bean.KC22>();
            string ybmzh = zyjlds.Rows[0]["AKC190"].ToString()+"_"+DateTime.Now.ToString("mmss");
            decimal zfy = 0; //总费用
            string mesg = "";
            foreach (DataRow dr in zyjlds.Rows)
            {
                try
                {
                    sjzsyb.bean.KC22 kc22 = new sjzsyb.bean.KC22();
                    kc22.AKC190 = ybmzh;
                    kc22.AKC220 = dr["AKC220"].ToString().Trim();
                    kc22.AKC221 = Convert.ToDateTime(dr["AKC221"].ToString().Trim()).ToString("yyyyMMddHHmmss");
                    kc22.AKC515 = dr["AKC515"].ToString().Trim();
                    kc22.AKC516 = dr["AKC516"].ToString().Trim();
                    kc22.AKC222 = dr["AKC222"].ToString().Trim();
                    kc22.AKC223 = dr["AKC223"].ToString().Trim();
                    if (dr["AKC224"].ToString().Trim().ToUpper().Equals("DRUG"))
                    {
                        dr["AKC224"] = "1";
                    }
                    else if (dr["AKC224"].ToString().Trim().ToUpper().Equals("COST"))
                    {
                        dr["AKC224"] = "2";
                    }
                    else if (dr["AKC224"].ToString().Trim().ToUpper().Equals("STUFF"))
                    {
                        dr["AKC224"] = "3";
                    }
                    kc22.AKC224 = dr["AKC224"].ToString().Trim();
                    kc22.AKC225 = dr["AKC225"].ToString().Trim();
                    kc22.AKC226 = dr["AKC226"].ToString().Trim();
                    kc22.AKC227 = Double.Parse(dr["AKC227"].ToString().Trim()).ToString("0.00");
                    kc22.AKC378 = DateTime.Now.ToString("yyyyMMddHHmmss") + dr["AKC220"].ToString().Trim();
                    kc22.BKF050 = dr["BKF050"].ToString().Trim();
                    kc22.BKF040 = dr["BKF040"].ToString().Trim();
                    kc22.BKA076 = dr["BKA076"].ToString().Trim();
                    kc22.AKA067 = dr["BKA076"].ToString().Trim();
                    kc22.CKAA08 = dr["CKAA08"].ToString().Trim();
                    kc22.CKAA09 = dr["CKAA09"].ToString().Trim();
                    yb_in_yjs.KC22XML.Add(kc22);
                    zfy += Decimal.Parse(kc22.AKC227);
                    //string sql_up = "update clinic_costdet set AKC378 = " + DataTool.addFieldBraces(kc22.AKC378) + " where id = " + DataTool.addFieldBraces(kc22.AKC220);
                    //BllMain.Db.Update(sql_up);
                }
                catch (Exception e)
                {
                    mesg += e + "\r\n";
                }
            }

            
            yb_in_yjs.KC21XML.AKC190 = ybmzh;
            yb_in_yjs.KC21XML.AKA130 = yllb;
            yb_in_yjs.KC21XML.AKC192 = Convert.ToDateTime(ryrq).ToString("yyyyMMddHHmmss");
            yb_in_yjs.KC21XML.AKC193 = jbbm[0];
            yb_in_yjs.KC21XML.AKC196 = jbbm[0];//
            yb_in_yjs.KC21XML.AAE011 = jbr;
            yb_in_yjs.KC21XML.AAE036 = Convert.ToDateTime(dqrq).ToString("yyyyMMddHHmmss");
            yb_in_yjs.KC21XML.AKC008 = ys;
            yb_in_yjs.KC21XML.AKC025 = ks;
            yb_in_yjs.KC21XML.AKC140 = jbmc[0];
            yb_in_yjs.KC21XML.AKC141 = jbmc[0];//
            yb_in_yjs.KC21XML.AKC031 = zyjlds.Rows[0]["AKC190"].ToString();
            yb_in_yjs.KC21XML.BKF040 = netdep;
            yb_in_yjs.KC21XML.BKF050 = netdoc;
            if (!String.IsNullOrEmpty(blbcard))
                yb_in_yjs.KC21XML.AKC031 = blbcard;

            for (int i = 1; i <= jbbm.Length; i++)
            {
                yb_in_yjs.KC21XML.KC33XML += "<KC33ROW>"
                                     + "<AKC190>" + ybmzh + "</AKC190>"//门诊（住院）号
                                     + "<BKE150>" + i + "</BKE150>"//诊断顺序
                                     + "<AKC221>" + DateTime.Now.ToString("yyyyMMddHHmmss") + "</AKC221>"//确诊日期
                                     + "<AKA120>" + jbbm[i - 1] + "</AKA120>"//诊断编码
                                     + "<AKA121>" + jbmc[i - 1] + "</AKA121>"//诊断名称
                                     + "<AAE013></AAE013>"//备注
                                     + "</KC33ROW>";
            }
            yb_in_yjs.AAC001 = "0";
            yb_in_yjs.AKC190 = ybmzh;
            yb_in_yjs.AKC020 = mzybdk.DK_OUT.AKC020;
            yb_in_yjs.MSGNO = "1107";
            yb_in_yjs.AKA130 = yllb;


            zyjs_OUT yb_out_yjs = new zyjs_OUT();
            //int ret = sjzybInterface.mzyjs(yb_in_yjs, ref  yb_out_yjs);
            //if (ret == -1)
            //{
            //    SysWriteLogs.writeLogs1("Erorr", DateTime.Now, "姓名：" + xm + " 预结算失败医保信息 " + yb_out_yjs.ERRORMSG);
            //    MessageBox.Show(yb_out_yjs.ERRORMSG + "预结算失败");
            //    return false;
            //}
            SJZYB_IN<DK_IN> yb_in_dk = new SJZYB_IN<DK_IN>();
            SjzybInterface sjzybInterface = new SjzybInterface();
            yb_in_dk.INPUT = new List<DK_IN>();
            DK_IN dk = new DK_IN();
            DK_OUT yb_out_dk = new DK_OUT();
            dk.BKA130 = yllb;
            yb_in_dk.INPUT.Add(dk);
            yb_in_dk.MSGNO = "1401";
            yb_in_dk.AAC001 = "0";
            //dk_out.sfcf = "0";
            int ret = sjzybInterface.DK(yb_in_dk, ref yb_out_dk);
            if (ret == -1)
            {
                MessageBox.Show(yb_out_dk.ERRORMSG, "提示信息");
                return false;
            }

            //结算
            SJZYB_IN<mzjs_IN> yb_in_mzjs = new SJZYB_IN<mzjs_IN>();
            yb_in_mzjs.INPUT = new List<mzjs_IN>();
            yb_in_mzjs.KC21XML = new sjzsyb.bean.KC21();
            yb_in_mzjs.KC22XML = new List<sjzsyb.bean.KC22>();
            yb_in_mzjs.KC21XML = yb_in_yjs.KC21XML;
            yb_in_mzjs.KC22XML = yb_in_yjs.KC22XML;
            mzjs_IN mzjs = new mzjs_IN();
            mzjs.AAC001 = grbh;
            mzjs.AAE072 = fph;
            mzjs.AKC190 = ybmzh;
            mzjs.AKC264 = zfy.ToString();
            yb_in_mzjs.INPUT.Add(mzjs);

            yb_in_mzjs.AAC001 = "0";
            yb_in_mzjs.AKC190 = ybmzh;
            yb_in_mzjs.AKC020 = mzybdk.DK_OUT.AKC020;
            yb_in_mzjs.MSGNO = "1108";
            yb_in_mzjs.AKA130 = yllb;

            zyjs_OUT yb_out_mzjs = new zyjs_OUT();
            int rets = sjzybInterface.mzjs(yb_in_mzjs, ref yb_out_mzjs);
            if (rets == -1)
            {
                SysWriteLogs.writeLogs1("Erorr", DateTime.Now, "姓名：" + xm + " 结算失败医保信息 " + yb_out_mzjs.ERRORMSG);
                MessageBox.Show(yb_out_mzjs.ERRORMSG + "结算失败");
                return false;
            }


            yb[0] = DataTool.Getdouble(yb_out_mzjs.AKC255);//yb[0] 账户支付
            yb[1] = DataTool.Getdouble(yb_out_mzjs.AKC087);//yb[1]账户余额
            yb[3] = DataTool.Getdouble(yb_out_mzjs.AKC261);//yb[3]现金支付
            yb[2] = DataTool.Getdouble(yb_out_mzjs.AKC780);//yb[2]医保报销

            string sql_yb = "";
            sql_yb += "UPDATE register SET healthcard = '" + ickh + "' ,insurcode = '" + grbh + "',insuregcode = '" + ybmzh + "'  WHERE id = " + register_id + " ;";

            js_sql jsxx = new js_sql();
            jsxx.js = yb_out_mzjs;
            jsxx.AAE072 = yb_in_mzjs.INPUT[0].AAE072;
            jsxx.AKC190 = yb_in_mzjs.AKC190;
            jsxx.BKC111 = "";
            jsxx.AKC193 = yb_in_mzjs.KC21XML.AKC193;
            jsxx.MSGID = yb_in_mzjs.MSGID;
            jsxx.REFMSGID = yb_out_mzjs.REFMSGID;
            jsxx.AKA130 = yb_in_mzjs.AKA130;
            jsxx.registkind = "CLIN";
            jsxx.id = BillSysBase.nextId("sjz_yb_jsxx");
            jsxx.ihspaccount_id = clinicInvoice.Id;
            sql_yb += objk<js_sql>.getsql(jsxx);
            Yb_hospital clin = new Yb_hospital();
            sql_yb += clin.add_Sybmzjl(yb_in_yjs.KC21XML);
            if (BllMain.Db.Update(sql_yb) == -1)
            {
                MessageBox.Show("结算成功,HIS更新失败！");
            }
            return true;
        }

        public void jsdcd(string costid)
        {

            string sql_djh = "select fph,grbh,ybmzh,sfck,xb,ybzfy,jssj,yllb from zlsyb_mzinfo where isactive=1 and mtmzblstuffiid in ( " + costid + ");";
            DataTable dt_djh = BllMain.Db.Select(sql_djh).Tables[0];
            //if (dt_djh.Rows[0]["yllb"].ToString().Trim() == "11")
            //{
            //    return;
            //}
            double ybzfy = double.Parse(dt_djh.Rows[0]["ybzfy"].ToString());

            //调用打印函数
            YBCJ_IN yw_in_mzjsddy = new YBCJ_IN();
            yw_in_mzjsddy.Yw = "BB310002";
            yw_in_mzjsddy.Ybcjbz = "0";
            if (dt_djh.Rows[0]["sfck"].ToString().Trim() == "1")
            {
                yw_in_mzjsddy.Ylzh = "0";
            }
            else
            {
                yw_in_mzjsddy.Ylzh = dt_djh.Rows[0]["grbh"].ToString().Trim();
            }
            yw_in_mzjsddy.Hisjl = costid;
            yw_in_mzjsddy.Rc = dt_djh.Rows[0]["grbh"].ToString().Trim() + "|" + dt_djh.Rows[0]["ybmzh"].ToString().Trim() + "|" + dt_djh.Rows[0]["fph"].ToString().Trim() + "|" + ProgramGlobal.Username;
            int opt_mzjsddy = yw1.ybcjhs(yw_in_mzjsddy);
            if (opt_mzjsddy != 0)
            {
                MessageBox.Show(yw_in_mzjsddy.Mesg, "提示信息");
                return;
            }

            string gxdy = "update zlsyb_mzinfo set zyjsdyzfc='" + yw_in_mzjsddy.Cc + "' where mtmzblstuffiid = " + costid;
            BllMain.Db.Update(gxdy);
            string[] retdata = yw_in_mzjsddy.Cc.Split('|');

            #region
            string in_zfc1 = "|";
            in_zfc1 += "邯郸市职工居民医疗保险（门诊慢性病、特殊病）结算单|";
            in_zfc1 += "医疗机构：" + retdata[2] + "|";
            in_zfc1 += "门诊号：" + dt_djh.Rows[0]["ybmzh"].ToString().Trim() + "|";
            in_zfc1 += "入院(门诊)日期：" + Convert.ToDateTime(dt_djh.Rows[0]["jssj"].ToString().Trim()).ToString("yyyy-MM-dd") + "|";
            in_zfc1 += "个人编号：" + retdata[6] + "|";
            in_zfc1 += "姓名：" + retdata[4] + "|";
            in_zfc1 += "人员类别：" + retdata[5] + "|";
            if (retdata[28] == "13")
            {
                in_zfc1 += "医疗类别：|门诊慢性病|";
            }
            else if (retdata[28] == "15")
            {
                in_zfc1 += "医疗类别：|门诊特殊病|";
            }
            //in_zfc1 += "医疗类别：|" + retdata[28] + "|";
            in_zfc1 += "总费用：|" + dt_djh.Rows[0]["ybzfy"].ToString().Trim() + "|";
            in_zfc1 += "起付线标准：|" + retdata[35] + "|";
            in_zfc1 += "累计起付线：|" + retdata[36] + "|";
            in_zfc1 += "本年历次统筹支出：|" + retdata[30] + "|";
            in_zfc1 += "本次合规费用：|" + retdata[33] + "|";
            in_zfc1 += "本次统筹支付：|" + retdata[29] + "|";
            in_zfc1 += "本年大病历次合规金额：|" + retdata[32] + "|";
            in_zfc1 += "本年大病历次支付金额：|" + retdata[34] + "|";
            in_zfc1 += "本次大病合规金额：|" + retdata[38] + "|";
            in_zfc1 += "本次大病支付金额：|" + retdata[39] + "|";
            in_zfc1 += "其中贫困人口提高待遇部分分项|门诊起付线降低提高待遇|提高门诊报销比例提高待遇|门诊提高封顶线提高待遇|大病保险提高封顶线提高待遇|大病保险取消起付线提高待遇|贫困人口提高待遇部分合计|本年历次门诊医疗救助累计|本次门诊医疗救助支付|";
            double pkhj = DataTool.Getdouble(retdata[43]) + DataTool.Getdouble(retdata[44]) + DataTool.Getdouble(retdata[45]) + DataTool.Getdouble(retdata[47]) + DataTool.Getdouble(retdata[46]);
            double bxzfhj = DataTool.Getdouble(retdata[43]) + DataTool.Getdouble(retdata[44]) + DataTool.Getdouble(retdata[45]) + DataTool.Getdouble(retdata[47]) + DataTool.Getdouble(retdata[46]) + DataTool.Getdouble(retdata[48]) + DataTool.Getdouble(retdata[29]) + DataTool.Getdouble(retdata[39]);
            in_zfc1 += retdata[43] + "|" + retdata[44] + "|" + retdata[45] + "|" + retdata[47] + "|" + retdata[46] + "|" + pkhj.ToString() + "|" + retdata[49] + "|" + retdata[48] + "|";
            in_zfc1 += "报销支付合计：|" + bxzfhj.ToString() + "|";
            in_zfc1 += "本次个人现金支付：|" + retdata[40] + "|";
            in_zfc1 += "备注提示：" + retdata[42] + "|";
            in_zfc1 += "医保中心名称：" + retdata[0] + "|";
            in_zfc1 += "参保人签字：|";
            in_zfc1 += "经办人：" + retdata[26] + "|";
            in_zfc1 += "经办日期：" + Convert.ToDateTime(dt_djh.Rows[0]["jssj"].ToString().Trim()).ToString("yyyy-MM-dd");
            // 调用打印
            //  新加2019/5/5
            FrmDy cxjsddy = new FrmDy();
            cxjsddy.in_zfc = in_zfc1;
            cxjsddy.dy("mzcxjsd");
            //FrmDy ybdy = new FrmDy();
            //ybdy.in_zfc = in_zfc1;
            //ybdy.dy("mzyb");
        }
        public void fpcd(string costid)
        {
            //string sql = "select clinic_costdet.name,clinic_costdet.Spec,clinic_costdet.num,clinic_costdet.Fee from clinic_costdet where clinic_cost_id in ("+costid+");";
            string sql = "select clinic_costdet.name,clinic_costdet.Spec,clinic_costdet.num,clinic_costdet.Fee from clinic_costdet where clinic_invoice_id in (" + costid + ");";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            string sql_djh = "select fph, grbh, ybmzh,sfck,xb,ybzfy from zlsyb_mzinfo where isactive=1 and mtmzblstuffiid in ( " + costid + ");";
            DataTable dt_djh = BllMain.Db.Select(sql_djh).Tables[0];

            double ybzfy = double.Parse(dt_djh.Rows[0]["ybzfy"].ToString());
            //调用打印函数
            YBCJ_IN yw_in_mzjsddy = new YBCJ_IN();
            yw_in_mzjsddy.Yw = "BB310002";
            yw_in_mzjsddy.Ybcjbz = "0";
            if (dt_djh.Rows[0]["sfck"].ToString().Trim() == "1")
            {
                yw_in_mzjsddy.Ylzh = "0";
            }
            else
            {
                yw_in_mzjsddy.Ylzh = dt_djh.Rows[0]["grbh"].ToString().Trim();
            }
            yw_in_mzjsddy.Hisjl = costid;
            yw_in_mzjsddy.Rc = dt_djh.Rows[0]["grbh"].ToString().Trim() + "|" + dt_djh.Rows[0]["ybmzh"].ToString().Trim() + "|" + dt_djh.Rows[0]["fph"].ToString().Trim() + "|" + ProgramGlobal.Username;
            int opt_mzjsddy = yw1.ybcjhs(yw_in_mzjsddy);
            if (opt_mzjsddy != 0)
            {
                MessageBox.Show(yw_in_mzjsddy.Mesg, "提示信息");
                return;
            }
            string gxdy = "update zlsyb_mzinfo set zyjsdyzfc='" + yw_in_mzjsddy.Cc + "' where mtmzblstuffiid in ( " + costid + ");";
            BllMain.Db.Update(gxdy);
            string[] retdata = yw_in_mzjsddy.Cc.Split('|');

            #region
            string in_zfc1 = "|";
            in_zfc1 += retdata[2] + "|";
            in_zfc1 += "|";
            in_zfc1 += retdata[3] + "|";
            in_zfc1 += retdata[1] + "|";
            in_zfc1 += retdata[4] + "|";
            in_zfc1 += dt_djh.Rows[0]["xb"].ToString().Trim() + "|";
            in_zfc1 += "职工医保|";
            in_zfc1 += retdata[6] + "|";

            in_zfc1 += RMB_DX.Convert(dt_djh.Rows[0]["ybzfy"].ToString().Trim()) + "|";
            in_zfc1 += DataTool.Getdouble(dt_djh.Rows[0]["ybzfy"].ToString().Trim()).ToString() + "|";

            in_zfc1 += retdata[29] + "|";
            in_zfc1 += retdata[22] + "|";
            in_zfc1 += retdata[38] + "|";
            in_zfc1 += retdata[39] + "|";

            in_zfc1 += retdata[23] + "|";
            in_zfc1 += retdata[33] + "|";
            in_zfc1 += retdata[35] + "|";
            in_zfc1 += "     大病支付:" + retdata[34] + "|";

            in_zfc1 += "大病累计支付:" + retdata[36] + "           超大病支付:" + retdata[37] + "          公务员补助支付:" + retdata[24] + "|";
            in_zfc1 += "本次报销总额:" + retdata[40] + "                    医保中心名称:" + retdata[0] + "|";
            in_zfc1 += retdata[26] + "|";
            in_zfc1 += retdata[27].Substring(0, 4) + "|";
            in_zfc1 += retdata[27].Substring(4, 2) + "|";
            in_zfc1 += retdata[27].Substring(6, 2) + "|";
            #endregion

            #region
            double zfy = 0;
            int fpts = 12;
            int fps = dt.Rows.Count / fpts + 1;
            for (int m = 0; m < fps; m++)
            {
                string in_zfc_fy1 = "";
                for (int i = fpts * m; i < fpts * (m + 1); i++)
                {
                    if (i == dt.Rows.Count)
                    {
                        break;
                    }
                    string Xmmc = dt.Rows[i]["name"].ToString().Trim();
                    Xmmc = System.Text.RegularExpressions.Regex.Replace(Xmmc, "[()*|<>&']", "");
                    string Guige = dt.Rows[i]["spec"].ToString().Trim();
                    Guige = System.Text.RegularExpressions.Regex.Replace(Guige, "[()*|<>&']", "");
                    string Sl = dt.Rows[i]["num"].ToString().Split('.')[0];
                    string Je = dt.Rows[i]["fee"].ToString().Trim();
                    zfy += double.Parse(Je);
                    if (Guige == "")
                    {
                        in_zfc_fy1 += "|" + Xmmc + "|" + Sl + "|" + Je + "|医保";
                    }
                    else
                    {
                        in_zfc_fy1 += "|" + Xmmc + "/" + Guige + "|" + Sl + "|" + Je + "|医保";
                    }
                }
                if (in_zfc_fy1 != "")
                {
                    FrmDy ybdy = new FrmDy();
                    ybdy.in_zfc = in_zfc1;
                    ybdy.in_zfc_fy = in_zfc_fy1;
                    ybdy.hs_fy = 12;
                    ybdy.dy("mzyb");
                }
            }
            #endregion

            if (!((zfy - ybzfy) < 0.01 || (zfy - ybzfy) > -0.01))
            {
                MessageBox.Show("项目明细表与医保费用表费用不一致！");
                SysWriteLogs.writeLogs1("项目明细表与医保费用表费用不一致", DateTime.Now, "其中医院费用：" + zfy + ", 医保总费用：" + ybzfy.ToString() + ",  患者姓名：" + retdata[4] + " 收费员:" + ProgramGlobal.Username);

            }
        }
        public bool refmz(string AAE072, StringBuilder message)
        {
            string sql_sybdz = "SELECT * FROM sjz_yb_jsxx LEFT JOIN sybmzjl ON sybmzjl.AKC190 = sjz_yb_jsxx.AKC190 WHERE sjz_yb_jsxx.AAE072 = " + DataTool.addFieldBraces(AAE072);
            DataTable dt_sybdz = BllMain.Db.Select(sql_sybdz).Tables[0];
            if (dt_sybdz.Rows.Count <= 0)
            {
                MessageBox.Show("此人目前His没有结算信息，不能结算召回操作！", "提示信息");
                return false;
            }
            SJZYB_IN<DK_IN> yb_in_ryjbxxhzh = new SJZYB_IN<DK_IN>();
            yb_in_ryjbxxhzh.INPUT = new List<DK_IN>();
            DK_IN dk = new DK_IN();
            DK_OUT yb_out_ryjbxxhzh = new DK_OUT();
            dk.BKA130 = "11";
            yb_in_ryjbxxhzh.INPUT.Add(dk);
            //判断有卡无卡


            yb_in_ryjbxxhzh.AAC001 = "0";

            yb_in_ryjbxxhzh.MSGNO = "1401";
            int ret = sjzybInterface.DK(yb_in_ryjbxxhzh, ref yb_out_ryjbxxhzh);
            if (ret == -1)
            {
                message.Append(yb_out_ryjbxxhzh.ERRORMSG + ", 读医保API人员基本信息和帐户信息失败！");
                return false;
            }
            //结算回退
            SJZYB_IN<zyjszh_IN> yb_in_zyjsht = new SJZYB_IN<zyjszh_IN>();
            yb_in_zyjsht.INPUT = new List<zyjszh_IN>();
            zyjszh_IN zyjszh_in = new zyjszh_IN();
            zyjszh_OUT yb_out_zyjsht = new zyjszh_OUT();
            zyjszh_in.AAE072 = dt_sybdz.Rows[0]["AAE072"].ToString();
            zyjszh_in.AKC190 = dt_sybdz.Rows[0]["AKC190"].ToString();
            zyjszh_in.AKC281 = dt_sybdz.Rows[0]["MSGID"].ToString();
            yb_in_zyjsht.INPUT.Add(zyjszh_in);



            string yllb = dt_sybdz.Rows[0]["AKA130"].ToString().Trim();

            yb_in_zyjsht.AAC001 = "0";
            yb_in_zyjsht.AKC190 = dt_sybdz.Rows[0]["AKC190"].ToString();
            yb_in_zyjsht.AKC020 = yb_out_ryjbxxhzh.AKC020;
            yb_in_zyjsht.AKA130 = yllb;
            yb_in_zyjsht.MSGNO = "1202";

            int ret_zyjsht = sjzybInterface.mzjszh(yb_in_zyjsht, ref yb_out_zyjsht);
            if (yb_out_zyjsht.RETURNNUM == -1)
            {
                message.Append(yb_out_ryjbxxhzh.ERRORMSG);
                return false;
            }
            decimal AKC264 = 0;
            decimal AKC255 = 0;
            decimal AKC260 = 0;
            decimal AKC261 = 0;
            decimal AKC706 = 0;
            decimal AKC707 = 0;
            decimal AKC708 = 0;


            AKC264 = 0 - Decimal.Parse(dt_sybdz.Rows[0]["AKC264"].ToString());
            AKC255 = 0 - Decimal.Parse(dt_sybdz.Rows[0]["AKC255"].ToString());
            AKC260 = 0 - Decimal.Parse(dt_sybdz.Rows[0]["AKC260"].ToString());
            AKC261 = 0 - Decimal.Parse(dt_sybdz.Rows[0]["AKC261"].ToString());
            AKC706 = 0 - Decimal.Parse(dt_sybdz.Rows[0]["AKC706"].ToString());
            AKC707 = 0 - Decimal.Parse(dt_sybdz.Rows[0]["AKC707"].ToString());
            AKC708 = 0 - Decimal.Parse(dt_sybdz.Rows[0]["AKC708"].ToString());

            js_sql jsxx = new js_sql();
            jsxx.AAE072 = yb_in_zyjsht.INPUT[0].AAE072;
            jsxx.AKC190 = yb_in_zyjsht.AKC190;
            jsxx.BKC111 = "";
            jsxx.MSGID = yb_in_zyjsht.MSGID;
            jsxx.REFMSGID = yb_out_zyjsht.REFMSGID;
            jsxx.AKA130 = yb_in_zyjsht.AKA130;
            jsxx.id = BillSysBase.nextId("sjz_yb_jsxx");
            string sql_jsxx = " INSERT INTO sjz_yb_jsxx (id,AKA130,AKC190,AAE072,MSGID,REFMSGID,AKC264,AKC255,AKC260,AKC261,AKC706,AKC707,AKC708,AAE040)"
                            + " VALUES( "
                            + DataTool.addFieldBraces(jsxx.id)
                            + "," + DataTool.addFieldBraces(jsxx.AKA130)
                            + "," + DataTool.addFieldBraces(jsxx.AKC190)
                            + "," + DataTool.addFieldBraces(jsxx.AAE072)
                            + "," + DataTool.addFieldBraces(jsxx.MSGID)
                            + "," + DataTool.addFieldBraces(jsxx.REFMSGID)
                            + "," + DataTool.addFieldBraces(AKC264.ToString())
                            + "," + DataTool.addFieldBraces(AKC255.ToString())
                            + "," + DataTool.addFieldBraces(AKC260.ToString())
                            + "," + DataTool.addFieldBraces(AKC261.ToString())
                            + "," + DataTool.addFieldBraces(AKC706.ToString())
                            + "," + DataTool.addFieldBraces(AKC707.ToString())
                            + "," + DataTool.addFieldBraces(AKC708.ToString())
                            + "," + DataTool.addFieldBraces(DateTime.Now.ToString())
                            + " );";
            sql_jsxx += "UPDATE sjz_yb_jsxx SET iscurr = 'N' where akc190 = " + DataTool.addFieldBraces(jsxx.AKC190) + ";";
            BllMain.Db.Update(sql_jsxx);

            return true;
        }

        public bool refund(string invoiceId, StringBuilder message, Label lbl)
        {
            // string sql = "select zlsyb_mzinfo.mtmzblstuffiid,zlsyb_mzinfo.grbh,zlsyb_mzinfo.ybmzh,zlsyb_mzinfo.fph,zlsyb_mzinfo.sfck from zlsyb_mzinfo,clinic_Invoice where mzsyb_mzinfo.fph=clinic_Invoice.invoice and clinic_Invoice.id=" + invoiceId;
            string sql = "select fph,ybmzh,mtmzblstuffiid,grbh,sfck from zlsyb_mzinfo where isactive=1 and mtmzblstuffiid = " + invoiceId.ToString().Trim();
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            string fph = dt.Rows[0]["fph"].ToString().Trim();
            //读人员基本信息和帐户信息
            YBCJ_IN yw_in_ryjbxxhzh = new YBCJ_IN();
            yw_in_ryjbxxhzh.Yw = "AA311012";
            yw_in_ryjbxxhzh.Ybcjbz = "0";
            if (dt.Rows[0]["sfck"].ToString().Trim() == "1")
            {
                yw_in_ryjbxxhzh.Ylzh = "0";
            }
            else
            {
                yw_in_ryjbxxhzh.Ylzh = dt.Rows[0]["grbh"].ToString().Trim();
            }
            yw_in_ryjbxxhzh.Ylzh = "0";
            yw_in_ryjbxxhzh.Rc = "";
            int opt_ryjbxxhzh = yw1.ybcjhs(yw_in_ryjbxxhzh);
            if (opt_ryjbxxhzh != 0)
            {
                message.Append(yw_in_ryjbxxhzh.Mesg + ", 读医保API人员基本信息和帐户信息失败！");
                return false;
            }
            string[] ryjbxxhzh_cc = yw_in_ryjbxxhzh.Cc.Split('|');
            //帐户余额
            string lnjz_s = ryjbxxhzh_cc[50];//历年结转
            double lnjz = 0;
            if (lnjz_s != null && lnjz_s != "")
                lnjz = double.Parse(lnjz_s);

            string bnzr_s = ryjbxxhzh_cc[51];//本年注入
            double bnzr = 0;
            if (bnzr_s != null && bnzr_s != "")
                bnzr = double.Parse(bnzr_s);

            string zhzc_s = ryjbxxhzh_cc[55]; //帐户支出
            double zhzc = 0;
            if (zhzc_s != null && zhzc_s != "")
                zhzc = double.Parse(zhzc_s);
            string zhye = (lnjz + bnzr - zhzc).ToString().Trim();
            lbl.Text = "退费前账户余额 ：" + zhye + "元";//账户余额
            lbl.Update();
            //判断住院状态
            if (ryjbxxhzh_cc[17] == "住院未结算" || ryjbxxhzh_cc[17] == "中途结算")
            {
                message.Append("此人目前为住院状态，不能进行结算回退操作！");
                return false;
            }

            //结算回退
            YBCJ_IN yw_in_mzjsht = new YBCJ_IN();
            yw_in_mzjsht.Yw = "DC311002";
            yw_in_mzjsht.Ybcjbz = "0";
            if (dt.Rows[0]["sfck"].ToString().Trim() == "1")
            {
                yw_in_mzjsht.Ylzh = "0";
            }
            else
            {
                yw_in_mzjsht.Ylzh = dt.Rows[0]["grbh"].ToString().Trim();
            }
            yw_in_mzjsht.Hisjl = invoiceId;
            yw_in_mzjsht.Rc = dt.Rows[0]["grbh"].ToString().Trim() + "|" + dt.Rows[0]["ybmzh"].ToString().Trim() + "|" + fph + "|" + ProgramGlobal.Username;
            int opt_mzjsht = yw1.ybcjhs(yw_in_mzjsht);
            if (opt_mzjsht != 0)
            {
                message.Append(yw_in_mzjsht.Mesg);
                return false;
            }
            lbl.Text = lbl.Text + "，退费后账户余额：" + yw_in_mzjsht.Cc.Split('|')[2] + " 元";
            lbl.Update();
            //修改his医保标志
            //string sql = "update  mtmzblstuff set ybsfsc =102  where iid=" + mtmzblstuff_iid + ";";
            //hisdb.Update(sql);
            string nowDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//服务器时间
            string sql_yb = "update zlsyb_mzinfo set cxsj = '" + nowDateTime + "', tfr = " + ProgramGlobal.User_id + "  where mtmzblstuffiid = " + dt.Rows[0]["mtmzblstuffiid"].ToString().Trim();
            BllMain.Db.Update(sql_yb);
            return true;
            #endregion
        }
    }
}
