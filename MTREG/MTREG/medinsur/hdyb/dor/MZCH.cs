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

using MTREG.medinsur.hdyb.bo;
namespace MTREG.medinsur.hdyb.dor
{
    class MZCH
    {
        InsurInfo insurinfo = new InsurInfo();
        JKDB jkdb = new JKDB();
        YBCJ yw1 = new YBCJ();
        public bool ypdzxx(ref string err_mesg, Mzybdk InsurInfo, DataGridView dgvfy, string ww)
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
            yw_in_djbypdzxx.Ylzh = InsurInfo.Grbh;
            yw_in_djbypdzxx.Hisjl = InsurInfo.Grbh;
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
                    yw_in_djbypdzxx.Rc = InsurInfo.Jbbm + "|" + ybbm;
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
                catch { continue; };
                #endregion
            }
            if (!string.IsNullOrEmpty(err_mesg))
            {
                return false;
            }
            return true;
            #endregion
        }
        //public bool ybjs(Mzybdk mzybdk, string ysname, string ksname, ClinicInvoice clinicInvoice, double[] yb)
        //{
        //    string ybmzh = DateTime.Now.ToString("yyMMddHHmmss") + "1";
        //    string nowDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //    string ryrq = nowDateTime;
        //    string fph = clinicInvoice.Invoice;
        //    string ys = ysname;
        //    string ks = ksname;
        //    string ickh = mzybdk.Ickh;
        //    string xm = mzybdk.Xm;
        //    string grbh = mzybdk.Grbh;
        //    string dwbh = mzybdk.Dwbh;
        //    string yllb = mzybdk.Yllb;//
        //    string jbbm = mzybdk.Jbbm;
        //    string jbmc = mzybdk.Jbmc;
        //    string jbr = ProgramGlobal.Username;
        //    string dqrq = nowDateTime;

        //    //更新	病人就诊信息KC21表
        //    string search_sql = "select count(*) from KC21 where AKC190='" + ybmzh + "'";
        //    string sql = "INSERT INTO KC21 (AKC190,CKC502,AAC003,AAC001,AAB001,AKA130,AKC192,AKC193,zkc274,zkc271,zkc272,AAE011,AAE036,CKC126) values ";
        //    sql += "('" + ybmzh + "','" + ickh + "','" + xm + "','" + grbh + "','" + dwbh + "','" + yllb + "','" + ryrq + "','" + jbbm + "','" + jbmc + "','" + ys + "','" + ks + "','" + jbr + "','" + dqrq + "',  0)";
        //    DataSet ds = jkdb.Select(search_sql);
        //    if (int.Parse(ds.Tables[0].Rows[0][0].ToString()) == 0)
        //    {
        //        jkdb.Update(sql);
        //    }

        //    string ypsql = "select clinic_costdet.clinic_cost_id as costid, clinic_costdet.id as stuffiid,clinic_costdet.standcode as sfxmdm,clinic_costdet.name as xmmc,insur_itemfrom.insurcode as itemfromcode,";
        //    ypsql += " clinic_costdet.Prc,clinic_costdet.Num as qty,clinic_costdet.Fee as amt,clinic_costdet.Spec,clinic_costdet.Unit as uom  ";
        //    ypsql += " from clinic_costdet left join insur_itemfrom on insur_itemfrom.itemtype_id=clinic_costdet.itemtype_id and insur_itemfrom.cost_insurtype_id=6 where clinic_costdet.id in ( " + clinicInvoice.Clinic_costdet_ids + ") ";
        //    DataTable zyjlds = BllMain.Db.Select(ypsql).Tables[0];
        //    string mesg = "";
        //    for (int i = 0; i < zyjlds.Rows.Count; i++)
        //    {

        //        string stuffiid = zyjlds.Rows[i]["stuffiid"].ToString().Trim();
        //        string cfh = zyjlds.Rows[i]["stuffiid"].ToString().Trim();
        //        string cfrq = nowDateTime;//
        //        string insurcode = zyjlds.Rows[i]["itemfromcode"].ToString();//药品/诊疗/床位费
        //        string sfxmdm = zyjlds.Rows[i]["sfxmdm"].ToString().Trim();
        //        if (string.IsNullOrEmpty(sfxmdm))
        //        {
        //            sfxmdm = "999999999";
        //        }
        //        string xmmc = zyjlds.Rows[i]["xmmc"].ToString().Trim();
        //        string lb = "2";
        //        string ypdj = "丙";
        //        string spbz = "";
        //        string yptsxx = "";

        //        YBCJ_IN yw_in_smldz = new YBCJ_IN();
        //        yw_in_smldz.Ybcjbz = "0";
        //        if (mzybdk.Sfck == "1")
        //        {
        //            yw_in_smldz.Ylzh = "0";
        //        }
        //        else
        //        {
        //            yw_in_smldz.Ylzh = grbh;
        //        }
        //        yw_in_smldz.Rc = sfxmdm;
        //        if (insurcode == ((int)InsurEnum.Yzc.YP).ToString())
        //        {
        //            lb = "1";
        //            yw_in_smldz.Yw = "BB31KA02";
        //            int opt_smldz = yw1.ybcjhs(yw_in_smldz);
        //            if (opt_smldz != 0)
        //            {
        //                mesg += "[对照药品失败：" + stuffiid + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
        //                continue;
        //            }
        //            string[] smldz_cc = yw_in_smldz.Cc.Split('|');
        //            if (smldz_cc[1] == "XX")
        //            {
        //                mesg += "[药品没有对码：" + stuffiid + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
        //                ypdj = "丙";
        //            }
        //        }
        //        //读取床位信息
        //        else if (insurcode == ((int)InsurEnum.Yzc.CWF).ToString())
        //        {
        //            lb = "3";
        //            yw_in_smldz.Yw = "BB31KA04";
        //            int opt_smldz = yw1.ybcjhs(yw_in_smldz);
        //            if (opt_smldz != 0)
        //            {
        //                mesg += "[对照床位失败：" + stuffiid + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
        //                continue;
        //            }
        //            string[] smldz_cc = yw_in_smldz.Cc.Split('|');
        //            if (smldz_cc[1] == "XX")
        //            {
        //                mesg += "[床位没有对码：" + stuffiid + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
        //                ypdj = "丙";
        //            }
        //        }
        //        //读取诊疗信息
        //        else if (insurcode == ((int)InsurEnum.Yzc.ZL).ToString())
        //        {
        //            yw_in_smldz.Yw = "BB31KA03";
        //            int opt_smldz = yw1.ybcjhs(yw_in_smldz);
        //            if (opt_smldz != 0)
        //            {
        //                mesg += "[对照诊疗失败：-" + stuffiid + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
        //                continue;
        //            }
        //            string[] smldz_cc = yw_in_smldz.Cc.Split('|');
        //            if (smldz_cc[1] == "XX")
        //            {
        //                mesg += "[诊疗没有对码：-" + stuffiid + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
        //                ypdj = "丙";

        //            }
        //        }
        //    }
        //    if (!string.IsNullOrEmpty(mesg))
        //    {

        //        FrmMesg frmmesg = new FrmMesg();
        //        frmmesg.StartPosition = FormStartPosition.CenterScreen;
        //        frmmesg.In_mesg = mesg;
        //        frmmesg.ShowDialog();
        //        if (frmmesg.Falg == false)
        //        {
        //            return false;
        //        }
        //    }
        //    for (int i = 0; i < zyjlds.Rows.Count; i++)
        //    {

        //        string stuffiid = zyjlds.Rows[i]["stuffiid"].ToString().Trim();
        //        string cfh = zyjlds.Rows[i]["stuffiid"].ToString().Trim();
        //        string cfrq = nowDateTime;//
        //        string insurcode = zyjlds.Rows[i]["itemfromcode"].ToString();//药品/诊疗/床位费
        //        string sfxmdm = zyjlds.Rows[i]["sfxmdm"].ToString().Trim();
        //        if (string.IsNullOrEmpty(sfxmdm))
        //        {
        //            sfxmdm = "999999999";
        //        }
        //        string xmmc = zyjlds.Rows[i]["xmmc"].ToString().Trim();
        //        string prc = zyjlds.Rows[i]["prc"].ToString().Trim();
        //        string qty = zyjlds.Rows[i]["qty"].ToString().Trim();
        //        string amt = zyjlds.Rows[i]["amt"].ToString().Trim();
        //        if (amt == "" || amt == null)
        //        {
        //            amt = "0";
        //        }
        //        string jsrq = nowDateTime; //
        //        string guige = zyjlds.Rows[i]["spec"].ToString().Trim();
        //        //string jixing = zyjlds.Rows[i]["jixing"].ToString().Trim();
        //        string uom = zyjlds.Rows[i]["uom"].ToString().Trim();
        //        string lb = "2";
        //        string ypdj = "丙";
        //        string spbz = "";
        //        string yptsxx = "";

        //        YBCJ_IN yw_in_smldz = new YBCJ_IN();
        //        yw_in_smldz.Ybcjbz = "0";
        //        if (mzybdk.Sfck == "1")
        //        {
        //            yw_in_smldz.Ylzh = "0";
        //        }
        //        else
        //        {
        //            yw_in_smldz.Ylzh = grbh;
        //        }
        //        yw_in_smldz.Rc = sfxmdm;
        //        if (insurcode == ((int)InsurEnum.Yzc.YP).ToString())
        //        {
        //            lb = "1";
        //            yw_in_smldz.Yw = "BB31KA02";
        //            int opt_smldz = yw1.ybcjhs(yw_in_smldz);
        //            if (opt_smldz != 0)
        //            {
        //                mesg += "[对照药品失败：" + stuffiid + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
        //                continue;
        //            }
        //            string[] smldz_cc = yw_in_smldz.Cc.Split('|');
        //            if (smldz_cc[1] == "XX")
        //            {
        //                mesg += "[药品没有对码：" + stuffiid + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
        //                ypdj = "丙";
        //            }
        //            else if (!string.IsNullOrEmpty(smldz_cc[0]))
        //            {
        //                ypdj = smldz_cc[0];
        //                if (smldz_cc[5] == "1")
        //                {
        //                    FormXzxypsp jyb = new FormXzxypsp();
        //                    jyb.Hzmc = xm;
        //                    jyb.Xmmc = xmmc;
        //                    jyb.Jyb = smldz_cc[0];
        //                    jyb.Xmbm = sfxmdm;
        //                    jyb.Xzxyysm = smldz_cc[6];
        //                    jyb.StartPosition = FormStartPosition.CenterScreen;
        //                    jyb.ShowDialog();
        //                    spbz = jyb.Xzxyysfkb;
        //                }
        //                try
        //                {
        //                    yptsxx = System.Text.RegularExpressions.Regex.Replace(smldz_cc[6], "['|<>&]", "");
        //                }
        //                catch { }
        //            }
        //        }
        //        //读取床位信息
        //        else if (insurcode == ((int)InsurEnum.Yzc.CWF).ToString())
        //        {
        //            lb = "3";
        //            yw_in_smldz.Yw = "BB31KA04";
        //            int opt_smldz = yw1.ybcjhs(yw_in_smldz);
        //            if (opt_smldz != 0)
        //            {
        //                mesg += "[对照床位失败：" + stuffiid + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
        //                continue;
        //            }
        //            string[] smldz_cc = yw_in_smldz.Cc.Split('|');
        //            if (smldz_cc[1] == "XX")
        //            {
        //                mesg += "[床位没有对码：" + stuffiid + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
        //                ypdj = "丙";
        //            }
        //            else if (!string.IsNullOrEmpty(smldz_cc[0]))
        //            {
        //                ypdj = smldz_cc[0];
        //            }
        //        }
        //        //读取诊疗信息
        //        else if (insurcode == ((int)InsurEnum.Yzc.ZL).ToString())
        //        {
        //            yw_in_smldz.Yw = "BB31KA03";
        //            int opt_smldz = yw1.ybcjhs(yw_in_smldz);
        //            if (opt_smldz != 0)
        //            {
        //                mesg += "[对照诊疗失败：-" + stuffiid + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
        //                continue;
        //            }
        //            string[] smldz_cc = yw_in_smldz.Cc.Split('|');
        //            if (smldz_cc[1] == "XX")
        //            {
        //                mesg += "[诊疗没有对码：-" + stuffiid + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
        //                ypdj = "丙";

        //            }
        //            else if (!string.IsNullOrEmpty(smldz_cc[0]))
        //            {
        //                ypdj = smldz_cc[0];
        //                if (smldz_cc[9] == "1")
        //                {
        //                    spbz = "3";
        //                }
        //            }
        //        }
        //        //类型1 药品，2诊疗 3床位费
        //        string _insert_sql = "insert into KC22 (AKC190,AKC220,AAE072,AKC221,AKC515,AKC223,AKC224,AKC225,AKC226,AKC227,AAE040,ZKA100,CKC126,CKC125,AKA065,ZKA101,CKC048) values ";
        //        _insert_sql += "('" + ybmzh + "','" + cfh + "','" + fph + "','" + cfrq + "','" + sfxmdm + "','" + xmmc + "','" + lb + "'," + prc + "," + qty + "," + amt + ",'" + jsrq + "','" + guige + "',0,0,'" + ypdj + "','" + uom + "','" + spbz + "')";
        //        if (jkdb.Update(_insert_sql) < 0)
        //        {
        //            MessageBox.Show("插入kc22费用表失败");
        //            SysWriteLogs.writeLogs1("Erorr", DateTime.Now, "姓名：" + xm + " 插入kc22费用表失败 sql" + _insert_sql);
        //            return false;
        //        }

        //    }
        //    String KC21_sql_ = "UPDATE KC21 SET AKC194 ='" + Convert.ToDateTime(ryrq).ToString("yyyy-MM-dd") + " 23:59:59' WHERE AKC190='" + ybmzh + "';";
        //    jkdb.Update(KC21_sql_);

        //    //预结算
        //    YBCJ_IN yw_in_zyjs = new YBCJ_IN();
        //    yw_in_zyjs.Yw = "BC311002";
        //    yw_in_zyjs.Ybcjbz = "1";
        //    if (mzybdk.Sfck == "1")
        //    {
        //        yw_in_zyjs.Ylzh = "0";
        //    }
        //    else
        //    {
        //        yw_in_zyjs.Ylzh = grbh;
        //    }
        //    yw_in_zyjs.Hisjl = zyjlds.Rows[0]["stuffiid"].ToString().Trim(); ;
        //    //个人编号|门诊住院号| 医疗类别|单据号|经办人|支付方式（账户支付或是现金支付）
        //    yw_in_zyjs.Rc = grbh + "|" + ybmzh + "|" + yllb + "|" + fph + "|" + ProgramGlobal.Username + "|0";
        //    int opt_zyyjs = yw1.ybcjhs(yw_in_zyjs);
        //    if (opt_zyyjs != 0)
        //    {
        //        SysWriteLogs.writeLogs1("Erorr", DateTime.Now, "姓名：" + xm + " 预结算失败医保信息 " + yw_in_zyjs.Mesg);
        //        MessageBox.Show(yw_in_zyjs.Mesg + "预结算失败");
        //        return false;
        //    }
        //    Frm_MzCxJs ybyjs = new Frm_MzCxJs();
        //    ybyjs.Ybcjbz = yw_in_zyjs.Ybcjbz;
        //    ybyjs.Yjsxx = yw_in_zyjs.Cc;
        //    ybyjs.StartPosition = FormStartPosition.CenterScreen;
        //    ybyjs.ShowDialog();
        //    if (ybyjs.Flag == false)
        //    {
        //        MessageBox.Show("预结算成功，没有结算");
        //        return false;
        //    }

        //    yw_in_zyjs.Yw = "CC311002";
        //    if (insurinfo.Sfck == "1")
        //    {
        //        yw_in_zyjs.Ylzh = "0";
        //    }
        //    else
        //    {
        //        yw_in_zyjs.Ylzh = grbh;
        //    }
        //    //个人编号|门诊住院号| 医疗类别|单据号|经办人|支付方式（账户支付或是现金支付）
        //    yw_in_zyjs.Rc = grbh + "|" + ybmzh + "|" + yllb + "|" + fph + "|" + ProgramGlobal.Username + "|" + ybyjs.Zffs;
        //    int opt_zyjs = yw1.ybcjhs(yw_in_zyjs);
        //    if (opt_zyjs != 0)
        //    {
        //        SysWriteLogs.writeLogs1("Erorr", DateTime.Now, "姓名：" + xm + " 结算失败医保信息 " + yw_in_zyjs.Mesg);
        //        MessageBox.Show(yw_in_zyjs.Mesg + "结算失败");
        //        return false;
        //    }
        //    string[] jsxx = yw_in_zyjs.Cc.Split('|');
        //    double ybbx_ = DataTool.Getdouble(jsxx[0]) - DataTool.Getdouble(jsxx[9]);
        //    string curdatetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:dd"); ;//获取服务器当前时间

        //    yb[0] = DataTool.Getdouble(jsxx[7]);//yb[0] 账户支付
        //    yb[1] = DataTool.Getdouble(jsxx[11]);//yb[1]账户余额
        //    yb[3] = DataTool.Getdouble(jsxx[9]);//yb[3]现金支付
        //    yb[2] = DataTool.Getdouble(jsxx[0]) - DataTool.Getdouble(jsxx[9]) - DataTool.Getdouble(jsxx[7]);//yb[2]医保报销

        //    string sql_yb = "insert into zlsyb_mzinfo (mtmzblstuffiid,xm,sfzh,qh,dwbh,dwmc,grbh,ickh,xb,csrq,jsqzhye,jshzhye,";
        //    sql_yb += "ybmzh,fph,jssj,ybzfy,grzhzf,ybbx,sfy,tp,grxjzf,bctczf,bcgwyzc,bcdbzf,pkjzzfhj,yllb,jswzsczfc,sfck) ";
        //    sql_yb += " values (" + zyjlds.Rows[0]["costid"].ToString().Trim() + ",'"
        //                          + mzybdk.Xm + "','"
        //                          + mzybdk.Sfzh + "','"
        //                          + mzybdk.Qh + "','"
        //                          + mzybdk.Dwbh + "','"
        //                          + mzybdk.Dwmc + "','"
        //                          + mzybdk.Grbh + "','"
        //                          + mzybdk.Ickh + "','"
        //                          + mzybdk.Xb + "','"
        //                          + mzybdk.Csrq + "',"
        //                          + mzybdk.Zhye + ","
        //                          + jsxx[11] + ",'"
        //                          + ybmzh + "','"
        //                          + fph + "','"
        //                          + curdatetime + "','"
        //                          + jsxx[0] + "','"
        //                          + jsxx[7] + "','"
        //                          + ybbx_ + "','"
        //                          + ProgramGlobal.Username + "','"
        //                          + "3" + "','"
        //                          + jsxx[9] + "','"
        //                          + jsxx[8] + "','"
        //                          + jsxx[10] + "','"
        //                          + jsxx[14] + "','"
        //                          + jsxx[22] + "','"
        //                          + yllb + "','"
        //                          + yw_in_zyjs.Cc + "','"
        //                          + mzybdk.Sfck + "');";
        //    if (BllMain.Db.Update(sql_yb) == -1)
        //    {
        //        MessageBox.Show("城乡结算成功,HIS更新失败！");
        //    }
        //    return true;
        //}
        public void jsdcd(string costid)
        {
            string sql_invoice = "select chargedate from clinic_invoice where id="+DataTool.addFieldBraces(costid);
            DataTable dt_invoice = BllMain.Db.Select(sql_invoice).Tables[0];
            string sql_djh = "select fph,grbh,ybmzh,sfck,xb,ybzfy,jssj,yllb from zlsyb_mzinfo where isactive=1 and mtmzblstuffiid in ( " + costid + ");";
            DataTable dt_djh = BllMain.Db.Select(sql_djh).Tables[0];
            if (dt_djh.Rows[0]["yllb"].ToString().Trim() == "11")
            {
                return;
            }
            double ybzfy = double.Parse(dt_djh.Rows[0]["ybzfy"].ToString());

            //调用打印函数
            YBCJ_IN yw_in_mzjsddy = new YBCJ_IN();
            yw_in_mzjsddy.Yw = "BB310002";
            yw_in_mzjsddy.Ybcjbz = "1";
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
            in_zfc1 += "邯郸市城乡居民医疗保险（门诊慢性病、特殊病）结算单|";
            in_zfc1 += "医疗机构：" + retdata[2] + "|";
            in_zfc1 += "门诊号：" + dt_djh.Rows[0]["ybmzh"].ToString().Trim() + "|";
            in_zfc1 += "入院(门诊)日期：" + Convert.ToDateTime(dt_invoice.Rows[0]["chargedate"].ToString().Trim()).ToString("yyyy-MM-dd") + "|";
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
            //in_zfc1 += "本次个人现金支付：|" + retdata[40] + "|";
            in_zfc1 += "本次个人现金支付：|" + DataTool.Getdouble(retdata[40]).ToString() + "|";
            in_zfc1 += "备注提示：" + retdata[42] + "|";
            in_zfc1 += "医保中心名称：" + retdata[0] + "|";
            in_zfc1 += "参保人签字：|";
            in_zfc1 += "经办人：" + retdata[26] + "|";
            in_zfc1 += "经办日期：" + Convert.ToDateTime(dt_djh.Rows[0]["jssj"].ToString().Trim()).ToString("yyyy-MM-dd");
            //调用打印
            //新加2019/5/5
            //FrmDy cxjsddy = new FrmDy();
            //cxjsddy.in_zfc = in_zfc1;
            //cxjsddy.dy("mzcxjsd");
        }
        public void fpcd(string costid)
        {
            string sql = "select clinic_costdet.name,clinic_costdet.Spec,clinic_costdet.num,clinic_costdet.Fee from clinic_costdet where clinic_invoice_id in (" + costid + ");";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            string sql_djh = "select fph, grbh, ybmzh,sfck,xb,ybzfy from zlsyb_mzinfo where isactive=1 and mtmzblstuffiid in ( " + costid + ");";
            DataTable dt_djh = BllMain.Db.Select(sql_djh).Tables[0];

            double ybzfy = double.Parse(dt_djh.Rows[0]["ybzfy"].ToString());
            //调用打印函数
            YBCJ_IN yw_in_mzjsddy = new YBCJ_IN();
            yw_in_mzjsddy.Yw = "BB310002";
            yw_in_mzjsddy.Ybcjbz = "1";
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
            in_zfc1 += "城乡居民医疗保险|";
            in_zfc1 += retdata[6] + "|";

            in_zfc1 += RMB_DX.Convert(dt_djh.Rows[0]["ybzfy"].ToString().Trim()) + "|";
            in_zfc1 += dt_djh.Rows[0]["ybzfy"].ToString().Trim() + "|";

            in_zfc1 += retdata[29] + "|";
            in_zfc1 += retdata[22] + "|";
            in_zfc1 += retdata[21] + "|";
            in_zfc1 += retdata[37] + "|";

            in_zfc1 += retdata[23] + "|";
            in_zfc1 += retdata[36] + "|";
            in_zfc1 += retdata[25] + "|";
            in_zfc1 += "   贫困救助支付合计:" + retdata[41] + "|";
            in_zfc1 += "本次符合基本医疗费用:" + retdata[33] + "    本年历次个人自付累计:" + retdata[32] + "    进入大病金额:" + retdata[38] + "    大病支付金额:" + retdata[39] + "|";

            in_zfc1 += "本年大病累计支付:" + retdata[34] + "        个人现金支付:" + retdata[40] + "        医保中心名称:" + retdata[0] + "|";

            in_zfc1 += "起付线支付:" + retdata[35] + "       备注提示：" + retdata[42] + "|";

            in_zfc1 += retdata[26] + "|";
            in_zfc1 += "参保人签字:|";
            in_zfc1 += retdata[27].Substring(0, 4) + "|";
            in_zfc1 += retdata[27].Substring(4, 2) + "|";
            in_zfc1 += retdata[27].Substring(6, 2) + "|";
            #endregion

            #region
            double zfy = 0;

            int fps = dt.Rows.Count / 12 + 1;
            for (int m = 0; m < fps; m++)
            {
                string in_zfc_fy1 = "";
                for (int i = 12 * m; i < 12 * (m + 1); i++)
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
                        in_zfc_fy1 += "|" + Xmmc + "|" + Sl + "|" + Je + "|城乡";
                    }
                    else
                    {
                        in_zfc_fy1 += "|" + Xmmc + "/" + Guige + "|" + Sl + "|" + Je + "|城乡";
                    }
                }
                if (in_zfc_fy1 != "")
                {
                    FrmDy chdy = new FrmDy();
                    chdy.in_zfc = in_zfc1;
                    chdy.in_zfc_fy = in_zfc_fy1;
                    chdy.hs_fy = 6;
                    chdy.dy("mzcx");
                }
            }
            #endregion

            if (!((zfy - ybzfy) < 0.01 || (zfy - ybzfy) > -0.01))
            {
                MessageBox.Show("项目明细表与城乡费用表费用不一致！");
                SysWriteLogs.writeLogs1("项目明细表与城乡费用表费用不一致", DateTime.Now, "其中医院费用：" + zfy + ", 城乡总费用：" + ybzfy.ToString() + ",  患者姓名：" + retdata[4] + " 收费员:" + ProgramGlobal.Username);

            }
        }
        public bool refund(string invoiceId, StringBuilder message, Label lbl)
        {
            string sql = "select zlsyb_mzinfo.mtmzblstuffiid,zlsyb_mzinfo.grbh,zlsyb_mzinfo.ybmzh,zlsyb_mzinfo.fph,zlsyb_mzinfo.sfck from zlsyb_mzinfo,clinic_Invoice where mzsyb_mzinfo.fph=clinic_Invoice.invoice and clinic_Invoice.id=" + invoiceId;
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
                yw_in_mzjsht.Ylzh = dt.Rows[0]["ybgrbh"].ToString().Trim();
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
