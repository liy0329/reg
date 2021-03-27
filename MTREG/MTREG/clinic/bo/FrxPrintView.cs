using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using MTREG.clinic.bll;
using MTHIS.common;
using MTHIS.db;
using MTHIS.chklist;
using System.Drawing.Printing;
using MTHIS.tools;
using MTREG.common;
using MTREG.medinsur.hdyb;
using MTREG.medinsur.hdyb.bll;
using MTREG.medinsur.hdyb.bo;
using MTREG.medinsur.hdsch.bll;
using MTREG.medinsur.hsdryb.bll;
using MTREG.medinsur.hsdryb.bo;
using MTHIS.main.bll;
using MTHIS.common;
using MTREG.medinsur.sjzsyb.bll;
using MTREG.medinsur.sjzsyb.bean;

namespace MTREG.clinic.bo
{
    class FrxPrintView
    {
        BllFrxPrintInvoice bllFrxPrintInvoice = new BllFrxPrintInvoice();
        public FrxPrintView() { }
        FastReport.Preview.PreviewControl previewCtrl;
        public FrxPrintView(FastReport.Preview.PreviewControl previewCtrl)
        {
            this.previewCtrl = previewCtrl;
        }
        /// <summary>
        /// 这个方法用的多了懒得改直接跳转到新方法
        /// </summary>
        /// <param name="clinic_invoice_id"></param>
        /// <param name="patientypeKeyname"></param>
        public void printInvoice(string id, string clinic_invoice_id)
        {
            clinicInvoice(id, clinic_invoice_id);
        }
        public void printInvoice2(string id, string clinic_invoice_id)
        {
            clinicInvoice(id, clinic_invoice_id);
        }
        //自费lyj
        public void ZFprintInvoice(string id, string clinic_invoice_id)
        {
            ZFclinicInvoice(id, clinic_invoice_id);
        }
        public int ZFclinicInvoice(string id, string clinic_invoice_id)
        {
            string sql1 = "select clinic_invoice.invoice,clinic_invoice.exedep_id,clinic_invoice.fee,clinic_invoice.chargeby as jsr,clinic_invoice.chargedate,register.name as sickname,register.sex,bas_depart.name as org,bas_patienttype.`name` AS paytype from bas_depart,register,clinic_invoice,bas_patienttype where bas_depart.id=register.depart_id AND bas_patienttype.id = clinic_invoice.bas_patienttype_id and clinic_invoice.regist_id=register.id and clinic_invoice.id=" + clinic_invoice_id;
            DataTable dt1 = BllMain.Db.Select(sql1).Tables[0];
            string sql = @"select clinic_costdet.name,clinic_costdet.Spec,clinic_costdet.num,clinic_costdet.fee,clinic_costdet.exedep_id,bas_depart.name as ksmc,clinic_costdet.chargedate from clinic_costdet
                            INNER JOIN bas_depart on bas_depart.id = clinic_costdet.exedep_id where clinic_cost_id in (" + id + ");";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            double zfyamt = DataTool.Getdouble(dt1.Rows[0]["fee"].ToString());
            string fph = dt1.Rows[0]["invoice"].ToString().Trim();
            string sex = dt1.Rows[0]["sex"].ToString().Trim();
            if (sex == "M")
            {
                sex = "男";
            }
            else if (sex == "W")
            {
                sex = "女";
            }
            else
            {
                sex = "";
            }
            string in_zfc1 = "|";
            in_zfc1 += ProgramGlobal.HspName + "|";
            in_zfc1 += "中医院|";
            in_zfc1 += dt1.Rows[0]["org"].ToString().Trim() + "|";
            in_zfc1 += fph + "|";
            in_zfc1 += dt1.Rows[0]["sickname"].ToString().Trim() + "|";
            in_zfc1 += sex + "|";
            in_zfc1 += dt1.Rows[0]["paytype"].ToString().Trim() + "|";

            in_zfc1 += RMB_DX.Convert(zfyamt) + "|";
            in_zfc1 += zfyamt + "|";

            in_zfc1 += ProgramGlobal.Nickname + "|";//收费员
            //in_zfc1 += Convert.ToDateTime(dt1.Rows[0]["chargedate"].ToString()).ToString("yyyy") + "|";
            //in_zfc1 += Convert.ToDateTime(dt1.Rows[0]["chargedate"].ToString()).ToString("MM") + "|";
            //in_zfc1 += Convert.ToDateTime(dt1.Rows[0]["chargedate"].ToString()).ToString("dd") + "|";
            // 修改不用会员卡结算的时间，用实际扣钱的时间   孔修改 2020-07-1           
            in_zfc1 += Convert.ToDateTime(dt.Rows[0]["chargedate"].ToString()).ToString("yyyy") + "|";
            in_zfc1 += Convert.ToDateTime(dt.Rows[0]["chargedate"].ToString()).ToString("MM") + "|";
            in_zfc1 += Convert.ToDateTime(dt.Rows[0]["chargedate"].ToString()).ToString("dd") + "|";
            double zfy = 0;
            int fpts = 24;//
            int fps = 1;
            if (dt.Rows.Count % fpts == 0)
            {
                fps = dt.Rows.Count / fpts;
            }
            else
            {
                fps = dt.Rows.Count / fpts + 1;
            }
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
                    string Guige = dt.Rows[i]["Spec"].ToString().Trim();
                    Guige = System.Text.RegularExpressions.Regex.Replace(Guige, "[()*|<>&']", "");
                    string Sl = dt.Rows[i]["num"].ToString().Split('.')[0];
                    string Je = dt.Rows[i]["fee"].ToString().Trim();
                    zfy += double.Parse(Je);
                    if (Guige == "")
                    {
                        in_zfc_fy1 += "|" + Xmmc + "|" + Sl + "|" + Je + "|" + dt1.Rows[0]["paytype"].ToString().Trim() + "|";
                    }
                    else
                    {
                        in_zfc_fy1 += "|" + Xmmc + "/" + Guige + "|" + Sl + "|" + Je + "|" + dt1.Rows[0]["paytype"].ToString().Trim() + "|";
                    }
                }
                //in_zfc1 += "|" + "|" + "";
                //if (true)
                //{
                in_zfc1 += "执行科室：" + dt.Rows[0]["ksmc"].ToString().Trim() + "|";
                //}
                if (in_zfc_fy1 != "")
                {
                    FrmDy mzzf = new FrmDy();
                    mzzf.in_zfc = in_zfc1;
                    mzzf.in_zfc_fy = in_zfc_fy1;
                    mzzf.hs_fy = fpts / 2;
                    mzzf.dy("mzzf");
                }
            }
            return 0;
        }


        /// <summary>
        /// 自费 处方 检查 发票打印（挂号发票重打）
        /// </summary>
        /// <returns></returns>
        public int clinicInvoice2(string id, string clinic_invoice_id)
        {
            string sql1 = "select clinic_invoice.invoice,clinic_invoice.fee,clinic_invoice.chargeby as jsr,clinic_invoice.chargedate,register.name as sickname,register.sex,bas_depart.name as org from bas_depart,register,clinic_invoice where bas_depart.id=register.depart_id  and clinic_invoice.regist_id=register.id and clinic_invoice.id=" + clinic_invoice_id;
            DataTable dt1 = BllMain.Db.Select(sql1).Tables[0];
            string sql = "select clinic_costdet.name,clinic_costdet.Spec,clinic_costdet.num,clinic_costdet.Fee from clinic_costdet where clinic_cost_id in (" + id + ");";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            double zfyamt = DataTool.Getdouble(dt1.Rows[0]["fee"].ToString());
            string fph = dt1.Rows[0]["invoice"].ToString().Trim();
            string sex = dt1.Rows[0]["sex"].ToString().Trim();
            if (sex == "M")
            {
                sex = "男";
            }
            else if (sex == "W")
            {
                sex = "女";
            }
            else
            {
                sex = "";
            }
            string in_zfc1 = "|";
            in_zfc1 += ProgramGlobal.HspName + "|";
            in_zfc1 += "|";
            in_zfc1 += dt1.Rows[0]["org"].ToString().Trim() + "|";
            in_zfc1 += fph + "|";
            in_zfc1 += dt1.Rows[0]["sickname"].ToString().Trim() + "|";
            in_zfc1 += sex + "|";

            in_zfc1 += RMB_DX.Convert(zfyamt) + "|";
            in_zfc1 += zfyamt + "|";

            in_zfc1 += dt1.Rows[0]["jsr"].ToString().Trim() + "|";//收费员
            in_zfc1 += Convert.ToDateTime(dt1.Rows[0]["chargedate"].ToString()).ToString("yyyy") + "|";
            in_zfc1 += Convert.ToDateTime(dt1.Rows[0]["chargedate"].ToString()).ToString("MM") + "|";
            in_zfc1 += Convert.ToDateTime(dt1.Rows[0]["chargedate"].ToString()).ToString("dd") + "|";
            double zfy = 0;
            int fpts = 24;//
            int fps = 1;
            if (dt.Rows.Count % fpts == 0)
            {
                fps = dt.Rows.Count / fpts;
            }
            else
            {
                fps = dt.Rows.Count / fpts + 1;
            }
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
                    string Guige = dt.Rows[i]["Spec"].ToString().Trim();
                    Guige = System.Text.RegularExpressions.Regex.Replace(Guige, "[()*|<>&']", "");
                    string Sl = dt.Rows[i]["num"].ToString().Split('.')[0];
                    string Je = dt.Rows[i]["Fee"].ToString().Trim();
                    zfy += double.Parse(Je);
                    if (Guige == "")
                    {
                        in_zfc_fy1 += "|" + Xmmc + "|" + Sl + "|" + Je + "|";
                    }
                    else
                    {
                        in_zfc_fy1 += "|" + Xmmc + "/" + Guige + "|" + Sl + "|" + Je + "|";
                    }
                }
                in_zfc1 += "|" + "|" + "|";
                if (in_zfc_fy1 != "")
                {
                    FrmDy mzzf = new FrmDy();
                    mzzf.in_zfc = in_zfc1;
                    mzzf.in_zfc_fy = in_zfc_fy1;
                    mzzf.hs_fy = fpts / 2;
                    mzzf.dy("mzzf");
                }
            }
            return 0;
        }
        /// <summary>
        /// 医保 处方 检查 发票打印（挂号发票重打）
        /// </summary>
        /// <returns></returns>
        public int clinicInvoice(string id, string clinic_invoice_id)
        {

            
            #region
            //门诊住院记录
            BllClinicCostManage bllClinicCostManage = new BllClinicCostManage();
            DataTable dtInfo0 = bllClinicCostManage.getInvoiceInfo(clinic_invoice_id);
            //获取门诊住院号
            string mzzyh = dtInfo0.Rows[0]["regbill"].ToString();
            string mzfph = dtInfo0.Rows[0]["invoice"].ToString();

            
            
            //根据门诊住院号获取医保类型//医保统筹支付//个人账户支付AKC779,AKC780,AKC255,AKC754,AKC253,AKC087
            string sql11 = "select * from sjz_yb_jsxx  LEFT JOIN sybmzjl ON sjz_yb_jsxx.AKC190 = sybmzjl.AKC190 where sjz_yb_jsxx.AAE072=" + mzfph;
            DataTable yblx = BllMain.Db.Select(sql11).Tables[0];
            //获取社会保障号
            string sqlBZH = "SELECT healthcard FROM register WHERE billcode=" + mzzyh;
            DataTable shbzh = BllMain.Db.Select(sqlBZH).Tables[0];
            //DataTable dtInfo0 = bllFrxPrintInvoice.getRegInvoiceInfo(clinic_invoice_id);
            //string sql1 = "select clinic_invoice.invoice,clinic_invoice.exedep_id,clinic_invoice.fee,clinic_invoice.chargeby as jsr,clinic_invoice.chargedate,register.name as sickname,register.sex,bas_depart.name as org from bas_depart,register,clinic_invoice where bas_depart.id=register.depart_id  and clinic_invoice.regist_id=register.id and clinic_invoice.invoice=" + clinic_invoice_id;
            //DataTable dt1 = BllMain.Db.Select(sql1).Tables[0];
            string sql = @"SELECT
	                        clinic_costdet. NAME,
	                        clinic_costdet.Spec,
	                        clinic_costdet.num,
	                        clinic_costdet.Fee,
	                        clinic_costdet.exedep_id,
	                        bas_depart. NAME AS ksmc,
	                        cost_insuritem.ratioself AS ratioself,
	                        cost_insuritem.limituse AS limituse,
                            cost_insuritem.itemfrom AS itemfrom
                        FROM
	                        clinic_costdet
                        INNER JOIN bas_depart ON bas_depart.id = clinic_costdet.exedep_id
                        LEFT JOIN cost_insurcross ON clinic_costdet.item_id = cost_insurcross.item_id
                        LEFT JOIN cost_insuritem ON cost_insuritem.id = cost_insurcross.cost_insuritem_id
                            where clinic_cost_id in (" + id + ");";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            double zfyamt = DataTool.Getdouble(dtInfo0.Rows[0]["realfee"].ToString());
            double mxamt = 0;
            for (int i = 0; i < dt.Rows.Count; i++ )
            {
                mxamt += Double.Parse(dt.Rows[i]["Fee"].ToString());
            }
            if (mxamt.ToString("0.00") != zfyamt.ToString("0.00"))
            {
                if (MessageBox.Show("明细费用与总费用不符，总费用：" + zfyamt + ",明细费用合计：" + mxamt + "", "", MessageBoxButtons.OKCancel) == DialogResult.No)
                {
                    return 0;
                }
            }
            //增加打印次数
            string sql1 = " UPDATE clinic_invoice SET print = print+1 WHERE clinic_invoice.invoice = " + DataTool.addFieldBraces(clinic_invoice_id);
            BllMain.Db.Update(sql1);

            string fph = dtInfo0.Rows[0]["invoice"].ToString().Trim();
            string sex = dtInfo0.Rows[0]["sex"].ToString().Trim();
            //if (sex == "M")
            //{
            //    sex = "男";
            //}
            //else if (sex == "W")
            //{
            //    sex = "女";
            //}
            //else
            //{
            //    sex = "";
            //}
            string in_zfc1 = "|";
            in_zfc1 += ProgramGlobal.HspName + "|";//井陉中医院
            in_zfc1 += yblx.Rows[0]["AKC778"] + "|";//类型
            in_zfc1 += dtInfo0.Rows[0]["dptname"].ToString().Trim() + "|";//妇产科
            in_zfc1 += yblx.Rows[0]["AAE072"] + "|";//流水号
            in_zfc1 += dtInfo0.Rows[0]["regname"].ToString().Trim() + "|";//姓名
            in_zfc1 += sex + "|";//性别
            in_zfc1 += yblx.Rows[0]["AKC779"].ToString() + "|";//医保类型
            in_zfc1 += shbzh.Rows[0]["healthcard"].ToString() + "|";//社会保障号
            in_zfc1 += RMB_DX.Convert(zfyamt) + "|";//大写
            in_zfc1 += zfyamt + "|";//￥
            in_zfc1 += yblx.Rows[0]["AKC780"].ToString() + "|";//医保统筹支付
            in_zfc1 += yblx.Rows[0]["AKC255"].ToString() + "|";//个人账户支付
            in_zfc1 += yblx.Rows[0]["AKC754"].ToString() + "|";//个人自付  //Convert.ToDateTime(dt1.Rows[0]["chargedate"].ToString()).ToString("MM") + "|";
            in_zfc1 += yblx.Rows[0]["AKC253"].ToString() + "|";//个人自费//Convert.ToDateTime(dt1.Rows[0]["chargedate"].ToString()).ToString("dd") + "|";
            in_zfc1 += yblx.Rows[0]["AKC087"].ToString() + "|";//个人账户余额
            in_zfc1 += yblx.Rows[0]["AKC781"].ToString() + "|";//起付标准累计
            in_zfc1 += yblx.Rows[0]["AKC782"].ToString() + "|";//统筹累计支付
            in_zfc1 += "|";
            in_zfc1 += "基本统筹支付:" + yblx.Rows[0]["AKC766"].ToString() + "|";//大病统筹累计
            in_zfc1 += "补助统筹支付:" + yblx.Rows[0]["AKC707"].ToString() + "|"; //大病统筹支付
            in_zfc1 += "大病统筹支付:" + yblx.Rows[0]["AKC706"].ToString() + "|";//大病自付

            in_zfc1 += "|";//起付标准自付
            if (yblx.Rows[0]["BAC081"].ToString().Trim() == "1")
            {
                in_zfc1 += "基本提高支付:" + yblx.Rows[0]["CKAA20"].ToString() + "|";
                in_zfc1 += "大病提高支付:" + yblx.Rows[0]["CKAA27"].ToString() + "|";
                in_zfc1 += "医疗救助支付:" + yblx.Rows[0]["BKE151"].ToString() + "|";
                in_zfc1 += "医疗救助补充支付:" + yblx.Rows[0]["CKAA40"].ToString() + "|";
            }
            else
            {
                in_zfc1 += "||||";
            }

            double zfy = 0;
            int fpts = 24;//
            int fps = 1;
            if (dt.Rows.Count % fpts == 0)
            {
                fps = dt.Rows.Count / fpts;
            }
            else
            {
                fps = dt.Rows.Count / fpts + 1;
            }
            List<String[]> list_mx = new List<String[]>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                
                if (i == dt.Rows.Count)
                {
                    break;
                }
                string Xmmc = dt.Rows[i]["name"].ToString().Trim();
                Xmmc = System.Text.RegularExpressions.Regex.Replace(Xmmc, "[()*|<>&']", "");
                
                string Guige = dt.Rows[i]["Spec"].ToString().Trim();
                Guige = System.Text.RegularExpressions.Regex.Replace(Guige, "[()*|<>&']", "");
                string Sl = dt.Rows[i]["num"].ToString().Split('.')[0];
                string Je = Double.Parse(dt.Rows[i]["fee"].ToString().Trim()).ToString("0.00");
                double Zf = Double.Parse(dt.Rows[i]["ratioself"].ToString().Trim());
                string type = "医保";
                if (Zf == 1)
                {
                    type = "自费";
                }
                else if (Zf < 1 && Zf > 0)
                {

                    //type += "[乙" + (Zf) * 100 + "%]";
                    type += "[乙]";
                }
                else if (Zf == 0)
                {
                    type += "[甲]";
                }
                string Xz = "";
                if (!String.IsNullOrEmpty(dt.Rows[i]["limituse"].ToString()))
                {
                    Xz = dt.Rows[i]["limituse"].ToString().Trim().Substring(6, 1);
                }
                string itemfrom = dt.Rows[i]["itemfrom"].ToString().Trim();
                if (Xz == "0" && itemfrom == "DRUG")
                {
                    type = "医保[自费]";
                }
                zfy += double.Parse(Je);
                
                if (Guige == "")
                {
                    String[] mx = new String[]{Xmmc,Sl,Je,type};
                    list_mx.Add(mx);
                }
                else
                {
                    String[] mx = new String[] { Xmmc +"/"+ Guige, Sl, Je, type };
                    list_mx.Add(mx);
                }
            }

            in_zfc1 += "|";
            in_zfc1 += "执行科室：" + dt.Rows[0]["ksmc"].ToString().Trim() + "|";
            in_zfc1 += ProgramGlobal.Nickname + "|";//收款人cyjsYs
            //结算时间
            in_zfc1 += DateTime.Parse(yblx.Rows[0]["AAE040"].ToString()).ToString("yyyy") + "|" + DateTime.Parse(yblx.Rows[0]["AAE040"].ToString()).ToString("MM") + "|" + DateTime.Parse(yblx.Rows[0]["AAE040"].ToString()).ToString("dd") + "|";

            in_zfc1 += yblx.Rows[0]["AKC788"].ToString() + "|";
            in_zfc1 += "石家庄市医保(WH02)" + "|";
            in_zfc1 += yblx.Rows[0]["AKC792"].ToString() + "|";
            if (yblx.Rows[0]["aka130"].ToString() == "15")
            {
                in_zfc1 += yblx.Rows[0]["AKC141"].ToString() + "|";
            }
            else
            {
                in_zfc1 += "|";
            }
            //}
            if (list_mx != null)
            {
                FrmDy mzzf = new FrmDy();
                mzzf.in_zfc = in_zfc1;
                mzzf.List_mx = list_mx;
                mzzf.hs_fy = fpts / 2;
                mzzf.dy("mzyb");
            }


            
            #endregion
            #region old
//            //门诊住院记录
//            BllClinicCostManage bllClinicCostManage = new BllClinicCostManage();
//            DataTable dtInfo0 = bllClinicCostManage.getInvoiceInfo(clinic_invoice_id);
//            //获取门诊住院号
//            string mzzyh = dtInfo0.Rows[0]["regbill"].ToString();
//            //根据门诊住院号获取医保类型//医保统筹支付//个人账户支付AKC779,AKC780,AKC255,AKC754,AKC253,AKC087
//            string sql11 = "select * from sjz_yb_jsxx  LEFT JOIN sybmzjl ON sjz_yb_jsxx.AKC190 = sybmzjl.AKC190 where sjz_yb_jsxx.AKC190=" + mzzyh;
//            DataTable yblx = BllMain.Db.Select(sql11).Tables[0];
//            //获取社会保障号
//            string sqlBZH = "SELECT healthcard FROM register WHERE billcode=" + mzzyh;
//            DataTable shbzh = BllMain.Db.Select(sqlBZH).Tables[0];
//            //DataTable dtInfo0 = bllFrxPrintInvoice.getRegInvoiceInfo(clinic_invoice_id);
//            //string sql1 = "select clinic_invoice.invoice,clinic_invoice.exedep_id,clinic_invoice.fee,clinic_invoice.chargeby as jsr,clinic_invoice.chargedate,register.name as sickname,register.sex,bas_depart.name as org from bas_depart,register,clinic_invoice where bas_depart.id=register.depart_id  and clinic_invoice.regist_id=register.id and clinic_invoice.invoice=" + clinic_invoice_id;
//            //DataTable dt1 = BllMain.Db.Select(sql1).Tables[0];
//            string sql = @"SELECT
//	                        clinic_costdet. NAME,
//	                        clinic_costdet.Spec,
//	                        clinic_costdet.num,
//	                        clinic_costdet.Fee,
//	                        clinic_costdet.exedep_id,
//	                        bas_depart. NAME AS ksmc,
//	                        cost_insuritem.ratioself AS ratioself,
//	                        cost_insuritem.limituse AS limituse,
//                            cost_insuritem.itemfrom AS itemfrom
//                        FROM
//	                        clinic_costdet
//                        INNER JOIN bas_depart ON bas_depart.id = clinic_costdet.exedep_id
//                        LEFT JOIN cost_insurcross ON clinic_costdet.item_id = cost_insurcross.item_id
//                        LEFT JOIN cost_insuritem ON cost_insuritem.id = cost_insurcross.cost_insuritem_id
//                            where clinic_cost_id in (" + id + ");";
//            DataTable dt = BllMain.Db.Select(sql).Tables[0];
//            double zfyamt = DataTool.Getdouble(dtInfo0.Rows[0]["realfee"].ToString());
//            string fph = dtInfo0.Rows[0]["invoice"].ToString().Trim();
//            string sex = dtInfo0.Rows[0]["sex"].ToString().Trim();
//            //if (sex == "M")
//            //{
//            //    sex = "男";
//            //}
//            //else if (sex == "W")
//            //{
//            //    sex = "女";
//            //}
//            //else
//            //{
//            //    sex = "";
//            //}
//            string in_zfc1 = "|";
//            in_zfc1 += ProgramGlobal.HspName + "|";//井陉中医院
//            in_zfc1 += yblx.Rows[0]["AKC778"] + "|";//类型
//            in_zfc1 += dtInfo0.Rows[0]["dptname"].ToString().Trim() + "|";//妇产科
//            in_zfc1 += yblx.Rows[0]["AAE072"] + "|";//流水号
//            in_zfc1 += dtInfo0.Rows[0]["regname"].ToString().Trim() + "|";//姓名
//            in_zfc1 += sex + "|";//性别
//            in_zfc1 += yblx.Rows[0]["AKC779"].ToString() + "|";//医保类型
//            in_zfc1 += shbzh.Rows[0]["healthcard"].ToString() + "|";//社会保障号
//            in_zfc1 += RMB_DX.Convert(zfyamt) + "|";//大写
//            in_zfc1 += zfyamt + "|";//￥
//            in_zfc1 += yblx.Rows[0]["AKC780"].ToString() + "|";//医保统筹支付
//            in_zfc1 += yblx.Rows[0]["AKC255"].ToString() + "|";//个人账户支付
//            in_zfc1 += yblx.Rows[0]["AKC754"].ToString() + "|";//个人自付  //Convert.ToDateTime(dt1.Rows[0]["chargedate"].ToString()).ToString("MM") + "|";
//            in_zfc1 += yblx.Rows[0]["AKC253"].ToString() + "|";//个人自费//Convert.ToDateTime(dt1.Rows[0]["chargedate"].ToString()).ToString("dd") + "|";
//            in_zfc1 += yblx.Rows[0]["AKC087"].ToString() + "|";//个人账户余额
//            in_zfc1 += yblx.Rows[0]["AKC781"].ToString() + "|";//起付标准累计
//            in_zfc1 += yblx.Rows[0]["AKC782"].ToString() + "|";//统筹累计支付
//            in_zfc1 += "|";
//            in_zfc1 += "基本统筹支付:" + yblx.Rows[0]["AKC766"].ToString() + "|";//大病统筹累计
//            in_zfc1 += "补助统筹支付:" + yblx.Rows[0]["AKC707"].ToString() + "|"; //大病统筹支付
//            in_zfc1 += "大病统筹支付:" + yblx.Rows[0]["AKC706"].ToString() + "|";//大病自付

//            in_zfc1 += "|";//起付标准自付
//            if (yblx.Rows[0]["BAC081"].ToString().Trim() == "1")
//            {
//                in_zfc1 += "基本提高支付:" + yblx.Rows[0]["CKAA20"].ToString() + "|";
//                in_zfc1 += "大病提高支付:" + yblx.Rows[0]["CKAA27"].ToString() + "|";
//                in_zfc1 += "医疗救助支付:" + yblx.Rows[0]["BKE151"].ToString() + "|";
//                in_zfc1 += "医疗救助补充支付:" + yblx.Rows[0]["CKAA40"].ToString() + "|";
//            }
//            else
//            {
//                in_zfc1 += "||||";
//            }

//            double zfy = 0;
//            int fpts = 24;//
//            int fps = 1;
//            if (dt.Rows.Count % fpts == 0)
//            {
//                fps = dt.Rows.Count / fpts;
//            }
//            else
//            {
//                fps = dt.Rows.Count / fpts + 1;
//            }
//            for (int m = 0; m < fps; m++)
//            {
//                string in_zfc_fy1 = "";
//                for (int i = fpts * m; i < fpts * (m + 1); i++)
//                {
//                    if (i == dt.Rows.Count)
//                    {
//                        break;
//                    }
//                    string Xmmc = dt.Rows[i]["name"].ToString().Trim();
//                    Xmmc = System.Text.RegularExpressions.Regex.Replace(Xmmc, "[()*|<>&']", "");
//                    string Guige = dt.Rows[i]["Spec"].ToString().Trim();
//                    Guige = System.Text.RegularExpressions.Regex.Replace(Guige, "[()*|<>&']", "");
//                    string Sl = dt.Rows[i]["num"].ToString().Split('.')[0];
//                    string Je = Double.Parse(dt.Rows[i]["fee"].ToString().Trim()).ToString("0.00");
//                    double Zf = Double.Parse(dt.Rows[i]["ratioself"].ToString().Trim());
//                    string type = "医保";
//                    if (Zf == 1)
//                    {
//                        type += "[自费]";
//                    }
//                    else if (Zf < 1 && Zf > 0)
//                    {

//                        type += "[乙" + (1 - Zf) * 100 + "%]";
//                    }
//                    else if (Zf == 0)
//                    {
//                        type += "[甲]";
//                    }
//                    string Xz = "";
//                    if (!String.IsNullOrEmpty(dt.Rows[i]["limituse"].ToString()))
//                    {
//                        Xz = dt.Rows[i]["limituse"].ToString().Trim().Substring(6, 1);
//                    }
//                    string itemfrom = dt.Rows[i]["itemfrom"].ToString().Trim();
//                    if (Xz == "0" && itemfrom == "DRUG")
//                    {
//                        type = "医保[自费]";
//                    }
//                    zfy += double.Parse(Je);
//                    if (Guige == "")
//                    {
//                        in_zfc_fy1 += "|" + Xmmc + "|" + Sl + "|" + Je + "|" + type + "|";
//                    }
//                    else
//                    {
//                        in_zfc_fy1 += "|" + Xmmc + "/" + Guige + "|" + Sl + "|" + Je + "|" + type + "|";
//                    }
//                }
//                //in_zfc1 += "|" + "|" + "|";
//                //if (true)
//                //{
//                in_zfc1 += "|";
//                in_zfc1 += "执行科室：" + dt.Rows[0]["ksmc"].ToString().Trim() + "|";
//                in_zfc1 += ProgramGlobal.Nickname + "|";//收款人cyjsYs
//                //结算时间
//                in_zfc1 += DateTime.Parse(yblx.Rows[0]["AAE040"].ToString()).ToString("yyyy") + "|" + DateTime.Parse(yblx.Rows[0]["AAE040"].ToString()).ToString("MM") + "|" + DateTime.Parse(yblx.Rows[0]["AAE040"].ToString()).ToString("dd") + "|";

//                in_zfc1 += yblx.Rows[0]["AKC788"].ToString() + "|";
//                in_zfc1 += "石家庄市医保(WH02)" + "|";
//                in_zfc1 += yblx.Rows[0]["AKC792"].ToString() + "|";
//                if (yblx.Rows[0]["aka130"].ToString() == "15")
//                {
//                    in_zfc1 += yblx.Rows[0]["AKC141"].ToString() + "|";
//                }
//                else
//                {
//                    in_zfc1 += "|";
//                }
//                //}
//                if (in_zfc_fy1 != "")
//                {
//                    FrmDy mzzf = new FrmDy();
//                    mzzf.in_zfc = in_zfc1;
//                    mzzf.in_zfc_fy = in_zfc_fy1;
//                    mzzf.hs_fy = fpts / 2;
//                    mzzf.dy("mzyb");
//                }

//            }
            #endregion
            #region
            //DataTable dtFrmurl = bllFrxPrintInvoice.getSysPrintFrmurl(SysPrintCodeid.CLIN_GZSYBFP.ToString());
            //if (dtFrmurl.Rows.Count <= 0)
            //{
            //    MessageBox.Show("找不到发票模板，打印失败！");
            //    return -1;
            //}
            //string invoiceRptPath = GlobalParams.reportDir + "\\" + dtFrmurl.Rows[0][0].ToString();
            //DataTable dtCostDet = bllFrxPrintInvoice.getInvoiceCostDets(clinic_invoice_id);//主要信息获取
            //DataTable dtInvoice = bllFrxPrintInvoice.getInvoice(clinic_invoice_id);//消费明细获取
            //DataTable dtInfo = new DataTable();
            //dtInfo.Columns.Add("invoice", typeof(string));      
            //dtInfo.Columns.Add("billcode", typeof(string));     
            //dtInfo.Columns.Add("hspname", typeof(string));
            //dtInfo.Columns.Add("rcpdepart", typeof(string));
            //dtInfo.Columns.Add("exedepart", typeof(string));
            //dtInfo.Columns.Add("patientname", typeof(string));
            //dtInfo.Columns.Add("sex", typeof(string));
            //dtInfo.Columns.Add("insurcode", typeof(string));


            //dtInfo.Columns.Add("insurpaytype", typeof(string));
            //dtInfo.Columns.Add("patienttype", typeof(string));
            //dtInfo.Columns.Add("dwmc", typeof(string));
            //dtInfo.Columns.Add("clinicdiagn", typeof(string));

            //dtInfo.Columns.Add("capamt", typeof(string));
            //dtInfo.Columns.Add("amt", typeof(string));          
            //dtInfo.Columns.Add("insurfee", typeof(string));
            //dtInfo.Columns.Add("accountfee", typeof(string));
            //dtInfo.Columns.Add("otherinsurfee", typeof(string));
            //dtInfo.Columns.Add("payfee", typeof(string));
            //dtInfo.Columns.Add("chargeby", typeof(string));    

            //dtInfo.Columns.Add("mzbzqfx", typeof(string));
            //dtInfo.Columns.Add("mzbzljzf", typeof(string));
            //dtInfo.Columns.Add("xfq", typeof(string));
            //dtInfo.Columns.Add("xfh", typeof(string));
            //dtInfo.Columns.Add("sbpayfee", typeof(string));
            //dtInfo.Columns.Add("chargedate", typeof(string));
            //dtInfo.Columns.Add("byxj", typeof(string));
            //dtInfo.Columns.Add("paytypename", typeof(string));
            //if (dtInvoice.Rows.Count == 0)
            //{
            //    MessageBox.Show("获取发票信息失败!");
            //    return -1;
            //}
            //DataRow row = dtInfo.NewRow();
            //row["invoice"] = "电脑票号： " + dtInvoice.Rows[0]["invoice"].ToString();
            //row["hspname"] = ProgramGlobal.HspName;
            //row["billcode"] = "NO:" + dtInvoice.Rows[0]["billcode"].ToString(); ;        
            //row["patientname"] = dtInvoice.Rows[0]["patientname"].ToString();
            //row["sex"] = dtInvoice.Rows[0]["sex"].ToString();
            //row["rcpdepart"] = "就诊科室： " + dtInvoice.Rows[0]["rcpdepart"].ToString();
            //row["chargeby"] = dtInvoice.Rows[0]["chargeby"].ToString();
            //row["chargedate"] = dtInvoice.Rows[0]["chargedate"].ToString();
            //row["exedepart"] = "执行科室：" + dtInvoice.Rows[0]["exedepart"].ToString();
            //row["capamt"] = RMB_DX.Convert(dtInvoice.Rows[0]["amt"].ToString());
            //row["amt"] = dtInvoice.Rows[0]["amt"].ToString();
            //row["clinicdiagn"] = "门诊诊断：" + dtInvoice.Rows[0]["clinicdiagn"].ToString();
            //row["paytypename"] = dtInvoice.Rows[0]["paytypename"].ToString(); ;
            //string patienttypeKeyname = dtInvoice.Rows[0]["patienttypekeyname"].ToString();
            //if(patienttypeKeyname.Equals(CostInsurtypeKeyname.GZSYB.ToString()))
            //{
            //    DataTable  fpxx=  bllFrxPrintInvoice.get_GZSMZ_InvoiceInfo(clinic_invoice_id);
            //    row["insurcode"] = fpxx.Rows[0]["aac001"].ToString();//个人编号
            //    double xfqbl = double.Parse(fpxx.Rows[0]["yka065"].ToString());
            //    double xfhbl = double.Parse(fpxx.Rows[0]["akc087"].ToString());
            //    double grzfbl = xfhbl + xfqbl;
            //    string Xfqfy = grzfbl.ToString("0.00");
            //    string Xfhfy = fpxx.Rows[0]["akc087"].ToString();
            //    row["xfq"] = "消费前：" + Xfqfy;// "消费前：";
            //    row["xfh"] = "消费后：" + Xfhfy;//"消费后：";
            //    row["mzbzqfx"] = "门诊补助起付线：" +  fpxx.Rows[0]["yka368"].ToString();// "门诊补助起付线：";
            //    row["mzbzljzf"] = "门诊补助累计支付：" + fpxx.Rows[0]["yke025"].ToString();//"门诊补助累计支付：";
            //    string yab139 = fpxx.Rows[0]["yab139"].ToString();
            //    switch (yab139)
            //        {
            //            case "9900":
            //                row["patienttype"] = "省直医保";
            //                break;
            //            case "9907":
            //                row["patienttype"] = "省老干";
            //                break;
            //            default:
            //                row["patienttype"] = "异地医保";
            //                break;                
            //        }    
            //    string mzlx = fpxx.Rows[0]["aka130"].ToString();
            //    if (mzlx == "18")
            //    {
            //         row["insurpaytype"] = "特殊门诊";
            //    }
            //    string Jbylbxjefy = fpxx.Rows[0]["yka248"].ToString();//"本次基本医疗报销:"
            //    string Gwybxjefy = fpxx.Rows[0]["yke030"].ToString();//"本次公务员报销:";
            //    string Dbylbxjefy = fpxx.Rows[0]["yka062"].ToString();//"本次大病医疗报销:";
            //    double double_jbtczf = DataTool.stringToDouble( Jbylbxjefy);//基本医疗报销
            //    double double_gwytczf = DataTool.stringToDouble( Gwybxjefy);//公务员报销
            //    double double_dbtczf = DataTool.stringToDouble( Dbylbxjefy);//大病医疗报销
            //    double double_grzhzf = xfqbl;//个人帐户支付
            //    double double_zje = DataTool.stringToDouble( dtInvoice.Rows[0]["amt"].ToString());//总金额
            //    double double_grzfje = double_zje - double_grzhzf - double_jbtczf - double_dbtczf - double_gwytczf;//个人支付金额
            //    row["insurfee"]  = Jbylbxjefy;//统筹支付金额
            //    row["accountfee"] = double_grzhzf.ToString("0.00");//个人账户支付
            //    row["payfee"] =  double_grzfje.ToString("0.00");//个人支付金额
            //    row["otherinsurfee"] = double_gwytczf.ToString("0.00");
            //    if(double_dbtczf>0)
            //    {
            //         row["otherinsurfee"]=  (double_gwytczf+double_dbtczf).ToString("0.00");
            //    }

            //}
            //else if(patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.GYSYB.ToString()))
            //{  
            //    DataTable fpxx = bllFrxPrintInvoice.get_GYSMZ_InvoiceInfo(clinic_invoice_id);
            //    double double_grzhzf = double.Parse(fpxx.Rows[0]["grzhzf"].ToString());//个人账户支付
            //    double double_grzhye = double.Parse(fpxx.Rows[0]["grzhye"].ToString());//个人账户余额
            //    double double_zhxfq = double_grzhzf + double_grzhye;
            //    string Xfqfy = double_zhxfq.ToString("0.00");  //消费前余额
            //    string Xfhfy = double_grzhye.ToString("0.00");  //账户余额
            //    row["insurcode"] = fpxx.Rows[0]["grbh"].ToString();
            //    row["xfq"] = "消费前：" + Xfqfy;// "消费前：";
            //    row["xfh"] = "消费后：" + Xfhfy;//"消费后：";
            //    row["mzbzqfx"] = "门诊补助起付线：" +  fpxx.Rows[0]["bndptmzylbzqfx"].ToString();// "门诊补助起付线：";
            //    row["mzbzljzf"] = "门诊补助累计支付：" +fpxx.Rows[0]["ptmzylbzlj"].ToString();//"门诊补助累计支付：";
            //    row["patienttype"] ="市医保";
            //    string bxlb = fpxx.Rows[0]["bxlb"].ToString();//保险类别
            //    string zflb = fpxx.Rows[0]["zflb"].ToString();//支付类别
            //    if (bxlb.Equals("7"))
            //    {
            //         row["insurpaytype"] = "工伤保险";
            //    }
            //    if (zflb.Equals("18"))
            //    {
            //         row["insurpaytype"] = "特殊门诊";
            //    }
            //    double double_jbtczf = double.Parse(fpxx.Rows[0]["jjtczf"].ToString());//基本统筹支付
            //    double double_dbtczf = double.Parse(fpxx.Rows[0]["detczf"].ToString());//大病基金支付
            //    double double_gwytczf = double.Parse(fpxx.Rows[0]["ylbzzf"].ToString());//公务员统筹
            //    double double_sbzf = double.Parse(fpxx.Rows[0]["sbpay"].ToString());//商保支付
            //    double double_zje = DataTool.stringToDouble( dtInvoice.Rows[0]["amt"].ToString());//总金额
            //    double double_grzfje = double_zje - double_grzhzf - double_jbtczf - double_dbtczf - double_gwytczf - double_sbzf;
            //    row["insurfee"]  = double_jbtczf.ToString("0.00");//统筹支付金额
            //    row["accountfee"] = double_grzhzf.ToString("0.00");//个人账户支付
            //    row["payfee"] =  double_grzfje.ToString("0.00");//个人支付金额
            //    row["otherinsurfee"] = double_gwytczf.ToString("0.00");//个人账户支付
            //    if(double_dbtczf>0)
            //    {
            //         row["otherinsurfee"]+=(double_gwytczf+double_dbtczf).ToString("0.00");
            //    }
            //    if (double_sbzf > 0)
            //    {
            //        row["sbpayfee"]= " 商保支付:"+double_sbzf.ToString("0.00");
            //    }
            //  }
            //else if(patienttypeKeyname.ToUpper().Trim().Equals(CostInsurtypeKeyname.SELFCOST.ToString()))
            //{

            //      row["insurpaytype"] = "";
            //      row["patienttype"] = "自费";
            //      for (int i = 0; i < dtCostDet.Rows.Count;i++ )
            //      {
            //            dtCostDet.Rows[i]["insurclass"] = "";
            //      }
            //    row["mzbzqfx"] = "";// "门诊补助起付线：";
            //    row["mzbzljzf"] = "";//"门诊补助累计支付：";
            //    row["xfq"] = "";// "消费前：";
            //    row["xfh"] = "";//"消费后"
            //    double double_zje = DataTool.stringToDouble( dtInvoice.Rows[0]["amt"].ToString());//总金额
            //    double double_grzfje = double_zje;
            //    row["insurfee"]  ="0.00";//统筹支付金额
            //    row["accountfee"] = "0.00";//个人账户支付
            //    row["payfee"] =  double_grzfje.ToString("0.00");//个人支付金额
            //    row["otherinsurfee"] ="0.00";//其它医保支付
            //}
            //double fee = 0;
            //for (int i = 0; i < dtCostDet.Rows.Count; i++)
            //{
            //    fee += double.Parse(dtCostDet.Rows[i]["fee"].ToString());
            //}
            //row["byxj"] = "本页小计：" + fee.ToString();
            //dtInfo.Rows.Add(row);
            //FastReport.Report invoiceReport = new FastReport.Report();
            //try
            //{


            //    invoiceReport.Load(invoiceRptPath);
            //    invoiceReport.RegisterData(dtCostDet, "CostDet");
            //    invoiceReport.RegisterData(dtInfo, "Info");
            //    print(dtFrmurl.Rows[0][0].ToString(), invoiceReport);
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show("打印失败！");
            //    return -1;
            //}
            #endregion
            return 0;
        }
        /// <summary>
        /// 发票分打（安执行科室）
        /// </summary>
        /// <returns></returns>
        public int printInvoice_ffp(string id, string clinic_invoice_id, string exe_id)
        {
            string sql1 = "select clinic_invoice.invoice,clinic_invoice.exedep_id,clinic_invoice.fee,clinic_invoice.chargeby as jsr,clinic_invoice.chargedate,register.name as sickname,register.sex,bas_depart.name as org from bas_depart,register,clinic_invoice where bas_depart.id=register.depart_id  and clinic_invoice.regist_id=register.id and clinic_invoice.id=" + clinic_invoice_id;
            DataTable dt1 = BllMain.Db.Select(sql1).Tables[0];
            string sql = @"select clinic_costdet.name,clinic_costdet.Spec,clinic_costdet.num,clinic_costdet.prc,clinic_costdet.exedep_id,bas_depart.name as ksmc from clinic_costdet
                            INNER JOIN bas_depart on bas_depart.id = clinic_costdet.exedep_id where clinic_costdet.clinic_cost_id in (" + id + ") and clinic_costdet.exedep_id = " + exe_id;
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            double zfyamt = 0;//DataTool.Getdouble(dt1.Rows[0]["fee"].ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                zfyamt += Convert.ToDouble(dt.Rows[i]["num"].ToString()) * Convert.ToDouble(dt.Rows[i]["prc"].ToString());
            }
            string fph = dt1.Rows[0]["invoice"].ToString().Trim();
            string sex = dt1.Rows[0]["sex"].ToString().Trim();
            if (sex == "M")
            {
                sex = "男";
            }
            else if (sex == "W")
            {
                sex = "女";
            }
            else
            {
                sex = "";
            }
            string in_zfc1 = "|";
            in_zfc1 += ProgramGlobal.HspName + "|";
            in_zfc1 += "|";
            in_zfc1 += dt1.Rows[0]["org"].ToString().Trim() + "|";
            in_zfc1 += fph + "|";
            in_zfc1 += dt1.Rows[0]["sickname"].ToString().Trim() + "|";
            in_zfc1 += sex + "|";

            in_zfc1 += RMB_DX.Convert(zfyamt) + "|";
            in_zfc1 += zfyamt + "|";

            in_zfc1 += ProgramGlobal.Nickname + "|";//收费员
            in_zfc1 += Convert.ToDateTime(dt1.Rows[0]["chargedate"].ToString()).ToString("yyyy") + "|";
            in_zfc1 += Convert.ToDateTime(dt1.Rows[0]["chargedate"].ToString()).ToString("MM") + "|";
            in_zfc1 += Convert.ToDateTime(dt1.Rows[0]["chargedate"].ToString()).ToString("dd") + "|";
            double zfy = 0;
            int fpts = 24;//
            int fps = 1;
            if (dt.Rows.Count % fpts == 0)
            {
                fps = dt.Rows.Count / fpts;
            }
            else
            {
                fps = dt.Rows.Count / fpts + 1;
            }
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
                    string Guige = dt.Rows[i]["Spec"].ToString().Trim();
                    Guige = System.Text.RegularExpressions.Regex.Replace(Guige, "[()*|<>&']", "");
                    string Sl = dt.Rows[i]["num"].ToString().Split('.')[0];
                    //string Je =Math.Round(Convert.ToDecimal(dt.Rows[i]["prc"].ToString().Trim()),2).ToString();
                    string Je = (Convert.ToDouble(dt.Rows[i]["num"].ToString()) * Convert.ToDouble(dt.Rows[i]["prc"].ToString())).ToString("0.00");
                    zfy += double.Parse(Je);
                    if (Guige == "")
                    {
                        in_zfc_fy1 += "|" + Xmmc + "|" + Sl + "|" + Je + "|" + "";
                    }
                    else
                    {
                        in_zfc_fy1 += "|" + Xmmc + "/" + Guige + "|" + Sl + "|" + Je + "|";
                    }
                }
                in_zfc1 += "|" + "|" + "|" + "执行科室：" + dt.Rows[0]["ksmc"].ToString().Trim();
                if (in_zfc_fy1 != "")
                {
                    FrmDy mzzf = new FrmDy();
                    mzzf.in_zfc = in_zfc1;
                    mzzf.in_zfc_fy = in_zfc_fy1;
                    mzzf.hs_fy = fpts / 2;
                    mzzf.dy("mzzf");
                }
            }
            return 0;
        }
        /// <summary>
        /// 门诊收费明细单  井陉县中医院手工收费使用
        /// </summary>
        /// <returns></returns>
        public int clinic_mzmx(string invoice_id)
        {

            DataTable dt_mx = bllFrxPrintInvoice.getoutpatientFeeDetailsinfoDets(invoice_id);//明细
            DataTable dt_info = bllFrxPrintInvoice.getoutpatientFeeDetailsinfo(invoice_id);//信息
            DataTable dtInfo = new DataTable();
            dtInfo.Columns.Add("name", typeof(string));//姓名
            dtInfo.Columns.Add("dh", typeof(string));//发票号
            dtInfo.Columns.Add("sfy", typeof(string));//收费员
            dtInfo.Columns.Add("shday", typeof(string));//收费日期
            dtInfo.Columns.Add("yfee", typeof(string));//应收金额
            dtInfo.Columns.Add("sfee", typeof(string));//实收金额
            dtInfo.Columns.Add("depart", typeof(string));//科室
            dtInfo.Columns.Add("doctor", typeof(string));//医生

            DataRow row = dtInfo.NewRow();
            row["name"] = dt_info.Rows[0]["sickname"].ToString();
            row["dh"] = dt_info.Rows[0]["invoice"].ToString();
            row["sfy"] = dt_info.Rows[0]["chargeby"].ToString();
            string day = dt_info.Rows[0]["chargedate"].ToString();
            row["shday"] = DateTime.Parse(day).ToString("yyyy-MM-dd");
            row["yfee"] = dt_info.Rows[0]["realfee"].ToString();
            row["sfee"] = dt_info.Rows[0]["realfee"].ToString();
            row["depart"] = dt_info.Rows[0]["depart"].ToString();
            row["doctor"] = dt_info.Rows[0]["doctor"].ToString();

            dtInfo.Rows.Add(row);
            PrintService ps = new PrintService();

            string s = ps.WriteTxt_mzxm(dtInfo, dt_mx);
            ps.StartPrint(s, "txt");


            return 0;
        }
        /// <summary>
        ///挂号打印
        /// </summary>
        /// <param name="clinic_invoice_id"></param>
        /// <param name="codeid"></param>
        /// <returns></returns>
        public int clinic_Reginvoice(string clinic_invoice_id)
        {
            DataTable dtFrmurl = bllFrxPrintInvoice.getSysPrintFrmurl("CLIN_GZSGKGH");
            if (dtFrmurl.Rows.Count <= 0)
            {
                MessageBox.Show("找不到发票模板，打印失败！");
                return -1;
            }
            string invoiceRptPath = GlobalParams.reportDir + "\\" + dtFrmurl.Rows[0][0].ToString();
            DataTable dtCostDet = bllFrxPrintInvoice.getCostDet(clinic_invoice_id);
            DataTable dtInfo0 = bllFrxPrintInvoice.getRegInvoiceInfo(clinic_invoice_id);
            DataTable dtInfo = new DataTable();
            dtInfo.Columns.Add("hspname", typeof(string));//医院名称
            dtInfo.Columns.Add("busino", typeof(string));//发票号
            dtInfo.Columns.Add("meditype", typeof(string));
            dtInfo.Columns.Add("patientname", typeof(string));//姓名
            dtInfo.Columns.Add("sex", typeof(string));//性别
            dtInfo.Columns.Add("patienttype", typeof(string));//医保类型
            dtInfo.Columns.Add("departname", typeof(string));
            dtInfo.Columns.Add("capamt", typeof(string));//大小合计
            dtInfo.Columns.Add("amt", typeof(string));//合计
            dtInfo.Columns.Add("insur", typeof(string));//医保统筹支付
            dtInfo.Columns.Add("selfacc", typeof(string));//个人账户支付
            dtInfo.Columns.Add("other", typeof(string));//其他医保支付
            dtInfo.Columns.Add("self", typeof(string));//个人支付金额
            dtInfo.Columns.Add("chargeby", typeof(string));
            dtInfo.Columns.Add("chargedate", typeof(string));
            dtInfo.Columns.Add("clinicroom", typeof(string));//诊室
            dtInfo.Columns.Add("regnum", typeof(string));//排队号码
            dtInfo.Columns.Add("prebalance", typeof(string));//消费前
            dtInfo.Columns.Add("aftbalance", typeof(string));//消费后
            dtInfo.Columns.Add("insurdata1", typeof(string));//医保门诊补助起付线
            dtInfo.Columns.Add("insurdata2", typeof(string));//医保门诊补助累计支付
            dtInfo.Columns.Add("hspcard", typeof(string));//就诊卡号
            dtInfo.Columns.Add("regbillcode", typeof(string));//门诊号
            dtInfo.Columns.Add("insurcode", typeof(string));//社会保障号
            dtInfo.Columns.Add("registerid", typeof(string));//业务流水号  
            dtInfo.Columns.Add("sftsmz", typeof(string));//特殊门诊、工伤信息
            dtInfo.Columns.Add("paytypename", typeof(string));//特殊门诊、工伤信息
            if (dtInfo0.Rows.Count == 0)
            {
                MessageBox.Show("获取发票信息失败!");
                return -1;
            }
            DataRow row = dtInfo.NewRow();
            row["hspname"] = ProgramGlobal.HspName;
            row["busino"] = dtInfo0.Rows[0]["invbillcode"].ToString();
            row["meditype"] = ProgramGlobal.HspKind.ToString();
            row["patientname"] = dtInfo0.Rows[0]["patientname"].ToString();
            row["sex"] = dtInfo0.Rows[0]["sex"].ToString();
            row["paytypename"] = dtInfo0.Rows[0]["paytypename"].ToString();
            //row["departname"] = dtInfo0.Rows[0]["departname"].ToString() + "   " + bllFrxPrintInvoice.getDoctorName(clinic_invoice_id);
            row["departname"] = dtInfo0.Rows[0]["departname"].ToString() + "   " + dtInfo0.Rows[0]["doctorname"].ToString();

            double d_amt = DataTool.Getdouble(dtInfo0.Rows[0]["amt"].ToString());
            row["capamt"] = RMB_DX.Convert(dtInfo0.Rows[0]["amt"].ToString());
            row["amt"] = dtInfo0.Rows[0]["amt"].ToString();

            row["chargeby"] = dtInfo0.Rows[0]["chargeby"].ToString();
            row["chargedate"] = dtInfo0.Rows[0]["chargedate"].ToString();
            row["clinicroom"] = dtInfo0.Rows[0]["clinicroom"].ToString();
            row["regnum"] = dtInfo0.Rows[0]["regnum"].ToString() + "号";

            row["hspcard"] = "就诊卡号：" + dtInfo0.Rows[0]["hspcard"].ToString();//就诊卡号
            row["regbillcode"] = "门诊号：" + dtInfo0.Rows[0]["regbillcode"].ToString();//门诊号
            row["registerid"] = dtInfo0.Rows[0]["registerid"].ToString();

            string patientType_id = dtInfo0.Rows[0]["patienttype_id"].ToString();
            BillClinicRcpCost bllClinicRcpCost = new BillClinicRcpCost();
            string keyname = bllClinicRcpCost.getPatienttypeKeyname(patientType_id);
            if (keyname.Equals(CostInsurtypeKeyname.SELFCOST.ToString()))
            {
                //自费
                row["self"] = dtInfo0.Rows[0]["amt"].ToString();
            }
            //else if (keyname.Equals(CostInsurtypeKeyname.GYSYB.ToString()))
            //{
            //    //---市医保---
            //    DataTable dtYbInfo = bllFrxPrintInvoice.getGysybRegInvoiceInfo(clinic_invoice_id);
            //    row["patienttype"] = "市医保";// dtInfo0.Rows[0]["patienttype"].ToString();
            //    row["insurdata1"] = "门诊补助起付线：" + dtYbInfo.Rows[0]["bndptmzylbzqfx"].ToString();//医保门诊补助起付线
            //    row["insurdata2"] = "门诊补助累计支付：" + dtYbInfo.Rows[0]["ptmzylbzlj"].ToString();//医保门诊补助累计支付
            //    //基本统筹支付
            //    double d_jbtczf = DataTool.Getdouble(dtYbInfo.Rows[0]["jjtczf"].ToString());
            //    //医疗补助支付
            //    double d_gwytczf = DataTool.Getdouble(dtYbInfo.Rows[0]["ylbzzf"].ToString());
            //    //大额补助支付
            //    double d_dbtczf = DataTool.Getdouble(dtYbInfo.Rows[0]["detczf"].ToString());
            //    //个人账户支付
            //    double d_grzhzf = DataTool.Getdouble(dtYbInfo.Rows[0]["grzhzf"].ToString());
            //    //本次个人账户支付后帐户余额
            //    double d_aftbalance = DataTool.Getdouble(dtYbInfo.Rows[0]["grzhye"].ToString());
            //    //支付前账户余额
            //    double d_prebalance = d_aftbalance + d_grzhzf;
            //    //个人支付金额
            //    double d_grzfje = d_amt - d_jbtczf - d_gwytczf - d_dbtczf - d_grzhzf;

            //    row["insur"] = d_jbtczf.ToString("0.00");
            //    row["selfacc"] = d_grzhzf.ToString("0.00");
            //    row["other"] = d_gwytczf.ToString("0.00");
            //    row["self"] = d_grzfje.ToString("0.00");
            //    row["prebalance"] = "消费前：" + d_prebalance.ToString("0.00");
            //    row["aftbalance"] = "消费后：" + d_aftbalance.ToString("0.00");

            //    //个人编号
            //    row["insurcode"] = dtYbInfo.Rows[0]["grbh"].ToString();
            //    //是否特殊门诊 是否工伤
            //    string zflb = dtYbInfo.Rows[0]["zflb"].ToString();
            //    string bxlb = dtYbInfo.Rows[0]["bxlb"].ToString();
            //    if (bxlb.Equals("7"))
            //    {
            //        row["sftsmz"] = "工伤保险";
            //    }
            //    if (zflb.Equals("18"))
            //    {
            //        row["sftsmz"] = "特殊门诊";
            //    }
            //}
            //else if (keyname.Equals(CostInsurtypeKeyname.GZSYB.ToString()))
            //{
            //    //---异地医保---
            //    DataTable dtYbInfo = bllFrxPrintInvoice.getGzsybRegInvoiceInfo(clinic_invoice_id);
            //    //医保类型
            //    string ybmc = "省直医保";
            //    string yba139 = dtYbInfo.Rows[0]["yab139"].ToString();
            //    if (yba139 != "9900")
            //    {
            //        ybmc = "异地医保";
            //    }
            //    row["patienttype"] = ybmc;
            //    //个人编号
            //    row["insurcode"] = dtYbInfo.Rows[0]["aac001"].ToString();
            //    //医保门诊补助起付线
            //    row["insurdata1"] = "门诊补助起付线：" + dtYbInfo.Rows[0]["yka368"].ToString();
            //    //医保门诊补助累计支付
            //    row["insurdata2"] = "门诊补助累计支付：" + dtYbInfo.Rows[0]["yke025"].ToString();

            //    //本次基本医疗报销金额
            //    double d_jbtczf = DataTool.Getdouble(dtYbInfo.Rows[0]["yka248"].ToString());
            //    //公务员报销金额
            //    double d_gwytczf = DataTool.Getdouble(dtYbInfo.Rows[0]["yke030"].ToString());
            //    //本次大病医疗报销金额
            //    double d_dbtczf = DataTool.Getdouble(dtYbInfo.Rows[0]["yka062"].ToString());
            //    //个人账户支付
            //    double d_grzhzf = DataTool.Getdouble(dtYbInfo.Rows[0]["yka065"].ToString());
            //    //本次个人账户支付后帐户余额
            //    double d_aftbalance = DataTool.Getdouble(dtYbInfo.Rows[0]["akc087"].ToString());
            //    //支付前账户余额
            //    double d_prebalance = d_aftbalance + d_grzhzf;
            //    //个人支付金额
            //    double d_grzfje = d_amt - d_jbtczf - d_gwytczf - d_dbtczf - d_grzhzf;

            //    row["insur"] = d_jbtczf.ToString("0.00");
            //    row["selfacc"] = d_grzhzf.ToString("0.00");
            //    row["other"] = d_gwytczf.ToString("0.00");
            //    row["self"] = d_grzfje.ToString("0.00");
            //    row["prebalance"] = "消费前：" + d_prebalance.ToString("0.00");
            //    row["aftbalance"] = "消费后：" + d_aftbalance.ToString("0.00");
            //}

            dtInfo.Rows.Add(row);
            FastReport.Report payTypeRpt = new FastReport.Report();
            try
            {
                payTypeRpt.Load(invoiceRptPath);
                payTypeRpt.RegisterData(dtCostDet, "CostDet");
                payTypeRpt.RegisterData(dtInfo, "Info");
                print("挂号发票.frx", payTypeRpt);
            }
            catch
            {
                MessageBox.Show("打印失败！");
                return -1;
            }
            //try
            //{
            //    payTypeRpt.Load(invoiceRptPath);
            //    payTypeRpt.RegisterData(dtCostDet, "CostDet");
            //    payTypeRpt.RegisterData(dtInfo, "Info");
            //    payTypeRpt.Preview = previewCtrl;
            //    if (payTypeRpt.Prepare())
            //    {
            //        payTypeRpt.ShowPrepared();
            //    }
            //}
            //catch(Exception e)
            //{
            //    MessageBox.Show(e+"预览失败！");
            //    return -1;
            //}
            return 0;
        }
        /// <summary>
        /// 直接打印
        /// </summary>
        /// <param name="rptName"></param>
        /// <param name="rpt"></param>
        /// <returns></returns>
        public int print(String rptName, FastReport.Report rpt)
        {
            Ini.INIClass(Ini.syspath);
            String printName = Ini.IniReadValue("reportprint", rptName);
            if (String.IsNullOrEmpty(printName))
            {
                FrmChanagePrinter frm = new FrmChanagePrinter(rptName);
                frm.ShowDialog();

                Ini.INIClass(Ini.syspath);
                printName = Ini.IniReadValue("reportprint", rptName);
            }
            if (String.IsNullOrEmpty(printName))
            {
                MessageBox.Show("没有指定打印机,无法打印");
                return -1;
            }
            if (!exists(printName))
            {
                FrmChanagePrinter frm = new FrmChanagePrinter(rptName);
                frm.ShowDialog();

                Ini.INIClass(Ini.syspath);
                printName = Ini.IniReadValue("reportprint", rptName);
            }
            rpt.PrintSettings.ShowDialog = false;
            rpt.PrintSettings.Printer = printName;
            rpt.Print();



            return 0;
        }





        private Boolean exists(string printerName)
        {
            foreach (string installedPrntName in PrinterSettings.InstalledPrinters)
            {
                if (installedPrntName == printerName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
