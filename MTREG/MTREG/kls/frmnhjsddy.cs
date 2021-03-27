using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.gzsyb.Report_form;
using MTREG.medinsur.gzsyb.Util;
using MTHIS.main.bll;
using MTREG.medinsur.gzsyb;
using MTHIS.common;

namespace MTREG.medinsur.gzsyb
{
    public partial class frmnhjsddy : Form
    {
        public frmnhjsddy()
        {
            InitializeComponent();
        }
        //Common_Util util = new Common_Util();
        public frmnhzy sourse;
        public frmnhzy_fj sourse_fj;
        CrystalReport_Fpdy report1 = new CrystalReport_Fpdy();
        CrystalReport_Fpdy_fj report2 = new CrystalReport_Fpdy_fj();

        public DataSet zyjsdy(string zyh)
        {
            //string sql = "select * from insur_gzsnhzyinfo where hiszyh='" + zyh + "'";
            string sql = "select insur_gzsnhzyinfo.* from insur_gzsnhzyinfo,inhospital"
                + " where inhospital.id = insur_gzsnhzyinfo.ihsp_id"
                + " and inhospital.ihspcode='" + zyh + "'";
            return BllMain.Db.Select(sql);
        }
        public DataSet zyjsdyhis(string zyh)
        {
            //string sql = "select ihsp_info.homephone as h_tel,inhospital.indate as zyjlrysj,inhospital.outdate as zyjlcysj,inhospital.Clinicdiagn as mzzd,"
            //+ " ihsp_account.invoice as fph,ihsp_account.chargedate as balanceat,'' as turncode from inhospital, ihsp_info, ihsp_account "
            //+ " where inhospital.id=ihsp_info.ihsp_id and inhospital.id=ihsp_account.ihsp_id and ihsp_info.registkind='IHSP'"
            //+ "and ihsp_account.status='SETT' and inhospital.ihspcode='" + zyh + "'";
            string sql = "SELECT"
	                + " ihsp_info.homephone AS h_tel,"
	                + " inhospital.ihspcode,"
	                + " inhospital.indate AS zyjlrysj,"
	                + " inhospital.outdate AS zyjlcysj,"
	                + " inhospital.outdiagn AS mzzd,"
	                + " insur_gzsnhryinfo.inpatientsn AS inpatientsn,"
	                + " inhospital.ihspdiagn AS zyjlryzd,"
	                + " ihsp_account.invoice AS fph,"
	                + " ihsp_account.chargedate AS balanceat,"
	                + " insur_gzsnhryinfo.turncode AS turncode"
                    + " FROM"
	                + " inhospital,ihsp_account,ihsp_info,insur_gzsnhryinfo"
	                + " WHERE"
	                + " inhospital.id = ihsp_info.ihsp_id"
                    + " AND inhospital.id = ihsp_account.ihsp_id"
                    + " AND inhospital.id = insur_gzsnhryinfo.mtzyjliid"
                    + " AND ihsp_info.registkind = 'IHSP'"
                    + " AND ihsp_account. STATUS = 'SETT'"
                    + " AND inhospital.ihspcode = '" + zyh + "'";
            return BllMain.Db.Select(sql);
        }
        
        public DataSet yjk2(string zyh)
        {
            string sql = "select sum(ihsp_payinadv.payfee) as amt from ihsp_payinadv,inhospital where ihsp_payinadv.ihsp_id=inhospital.id and inhospital.ihspcode='" + zyh + "'";
            return BllMain.Db.Select(sql);
        }
        private void find_btn_Click(object sender, EventArgs e)
        {
            string hiszyh = text_jsd.Text;
            frmnhzy data = new frmnhzy();
            frmnhzy_fj data_fj = new frmnhzy_fj();
            DataTable zydynh = zyjsdy(hiszyh).Tables[0];
            DataTable zydyhis = zyjsdyhis(hiszyh).Tables[0];
            //DataTable zyjl = nhzyjl(hiszyh).Tables[0];
            DataTable yjk = yjk2(hiszyh).Tables[0];
            if (zydynh.Rows.Count == 0)
            {
                return;
            }
            data.Address = zydynh.Rows[0]["address"].ToString();
            data.Age = (int.Parse(DateTime.Now.ToString().Substring(0, 4)) - int.Parse(zydynh.Rows[0]["birthday"].ToString().Substring(0, 4))).ToString();
            data.Bcje = zydynh.Rows[0]["startMoney"].ToString();
            double nhbx = Convert.ToDouble(zydynh.Rows[0]["calculateMoney"].ToString());
            double mzbz = 0;
            if (zydynh.Rows[0]["YFmedicalAid"].ToString() != "")
                mzbz = Convert.ToDouble(zydynh.Rows[0]["YFmedicalAid"].ToString());
            double cxbz = 0;
            if (zydynh.Rows[0]["CXmedicalAid"].ToString() != "")
                cxbz = Convert.ToDouble(zydynh.Rows[0]["CXmedicalAid"].ToString());
            double dbbx = 0;
            if (zydynh.Rows[0]["CIICalculateMoney"].ToString() != "")
                dbbx = Convert.ToDouble(zydynh.Rows[0]["CIICalculateMoney"].ToString());
            double csbz = 0;
            if (zydynh.Rows[0]["ChinaCharityPay"].ToString() != "")
                csbz = Convert.ToDouble(zydynh.Rows[0]["ChinaCharityPay"].ToString());
            double jsbz = 0;
            if (zydynh.Rows[0]["FamilyPlanningWaiver"].ToString() != "")
                jsbz = Convert.ToDouble(zydynh.Rows[0]["FamilyPlanningWaiver"].ToString());
            double zbx = nhbx + mzbz + cxbz + dbbx + csbz + jsbz;
            money mm = new money(zbx);
            data.Bcbchj = zbx.ToString("0.00");
            data.Bcjedx = mm.Convert();
            data.Bcjg = "贵州省骨科医院";
            data.Bclx = zydynh.Rows[0]["redeemtypename"].ToString();
            data.Bkbfy = (double.Parse(zydynh.Rows[0]["totalcosts"].ToString()) - double.Parse(zydynh.Rows[0]["enablemoney"].ToString())).ToString("0.00");
            data.Bzfyde = zydynh.Rows[0]["fundpaymoney"].ToString() == "0" ? "" : zydynh.Rows[0]["fundpaymoney"].ToString();
            data.Clcxzf = zydynh.Rows[0]["materialmoney"].ToString() == "0" ? "" : zydynh.Rows[0]["materialmoney"].ToString();
            data.Cyrq = zydyhis.Rows[0]["zyjlcysj"].ToString().Split(' ')[0];
            data.Bcrq = zydyhis.Rows[0]["balanceat"].ToString().Split(' ')[0];
            data.Cyzd = zydyhis.Rows[0]["mzzd"].ToString();
            data.Dbybpf = zydynh.Rows[0]["personalpaymoney"].ToString() == "0" ? "" : (double.Parse(zydynh.Rows[0]["totalcosts"].ToString()) - double.Parse(zydynh.Rows[0]["personalpaymoney"].ToString())).ToString("0.00");
            data.Fph = zydyhis.Rows[0]["fph"].ToString();
            data.Grsx = zydynh.Rows[0]["identityname"].ToString();
            string yfmedicalaid = zydynh.Rows[0]["yfmedicalaid"].ToString();
            if (yfmedicalaid == "")
            {
                yfmedicalaid = "0";
            }
            string cxmedicalaid = zydynh.Rows[0]["cxmedicalaid"].ToString();
            if (cxmedicalaid == "")
            {
                cxmedicalaid = "0";
            }
            data.Grzfje = zydynh.Rows[0]["personalpaymoney"].ToString(); //(double.Parse(zydynh.Rows[0]["totalcosts"].ToString()) - double.Parse(zydynh.Rows[0]["calculatemoney"].ToString()) - double.Parse(yfmedicalaid) - double.Parse(cxmedicalaid)).ToString();
            data.Hzname = zydynh.Rows[0]["name"].ToString();
            data.Hzxm = zydynh.Rows[0]["mastername"].ToString();
            data.Jjsjbcje = zydynh.Rows[0]["calculateMoney"].ToString();
            data.Jyjg = "贵州省骨科医院";
            data.Kbfy = zydynh.Rows[0]["enablemoney"].ToString();
            
            data.Mzjxje = (double.Parse(yfmedicalaid) + double.Parse(cxmedicalaid)).ToString();
            data.Qfx = zydynh.Rows[0]["startmoney"].ToString();
            data.Ryrq = zydyhis.Rows[0]["zyjlrysj"].ToString().Split(' ')[0];
            data.Sex = zydynh.Rows[0]["sexname"].ToString();
            
            data.Sfzz = "否";
            string zzdh = zydyhis.Rows[0]["turncode"].ToString();
            if (zzdh != "")
            {
                data.Sfzz = "是";
            }
            data.Tbtgbce = zydynh.Rows[0]["anlagernmoney"].ToString();
            data.Tel = zydyhis.Rows[0]["h_tel"].ToString();
            data.Ylzh = zydynh.Rows[0]["bookno"].ToString();
            data.Yycdje = zydynh.Rows[0]["hospassumemoney"].ToString();
            data.Yyfy = zydynh.Rows[0]["curryeartotal"].ToString();
            data.Zdjb = "否";
            if (zydynh.Rows[0]["iscii"].ToString()!="" && zydynh.Rows[0]["iscii"].ToString()!="0")
               data.Zdjb = "是";
            data.Zfy = zydynh.Rows[0]["totalcosts"].ToString();
            data.Zlfs = "";
            data.Zycs = zydynh.Rows[0]["curryearredeemcount"].ToString();
            data.Yyfy = zydynh.Rows[0]["curryeartotal"].ToString();
            data.Bcje = zydynh.Rows[0]["curryearreddemmoney"].ToString();
            data.Fpbc = "0.00";
            data.Zyh = zydyhis.Rows[0]["ihspcode"].ToString();
            data.Dbbxhgfy = Getdouble( zydynh.Rows[0]["ciieligiblecosts"].ToString()).ToString("0.00");
            data.Dbqfx = Getdouble(zydynh.Rows[0]["ciistartmoney"].ToString()).ToString("0.00");
            data.Dbybpf = Getdouble(zydynh.Rows[0]["ciicalculatemoney"].ToString()).ToString("0.00");
            data.Csbc =  zydynh.Rows[0]["chinacharitypay"].ToString();
            data.Jsbc = zydynh.Rows[0]["familyplanningwaiver"].ToString();
            data.Jsgs = zydynh.Rows[0]["calculationmethod"].ToString();
            data.Cxyfbz = cxmedicalaid;
            data.Mzyfbz = yfmedicalaid;
            
            DataTable datafpdy = zydyfp2(hiszyh);
            double ypf2 = 0; //药品费
            double clf2 = 0; //材料费
            double jcf2 = 0;//检查费
            double zlf2 = 0;//治疗费
            String cwf2 = "";//床位费
            String hlf2 = "";//护理费
            double hyf2 = 0;//化验费
            double zcf2 = 0;//诊查费
            double ssf2 = 0;//手术费
            double qt2 = 0;//其他
            for (int i = 0; i < datafpdy.Rows.Count; i++)
            {
                if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("床位费"))
                {
                    cwf2 = datafpdy.Rows[i]["Amt"].ToString();//床位费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("诊查费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("会诊"))
                {
                    zcf2 += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//诊查费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("材料费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("其它材料") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("影像材料"))
                {
                    clf2 += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//诊查费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("氧疗费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("治疗费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("物理治疗") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("中医治疗") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("中医康复") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("输血费"))
                {
                    zlf2 += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//治疗费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("护理费"))
                {
                    hlf2 = datafpdy.Rows[i]["Amt"].ToString();//护理费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("手术费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("麻醉"))
                {
                    ssf2 += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//手术费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("化验费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("免疫") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("病理") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("心肌酶"))
                {
                    hyf2 += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//化验费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("西药") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("药店购药") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("中成药") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("中草药"))
                {
                    ypf2 += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//西药费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("检查费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("喉镜") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("放射费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("CT") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("胃镜") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("核磁") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("多普勒") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("内窥镜") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("心电") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("彩超") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("脑彩超") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("脑地形图") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("A超") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("X光") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("镜检") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("喉镜") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("核医学费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("TCD") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("骨密度") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("机电图") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("B超") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("X光") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("多普勒"))
                {
                    if (!datafpdy.Rows[i]["Amt"].ToString().Equals(""))
                    {
                        jcf2 += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//检查费
                        continue;
                    }
                }
                else
                {
                    qt2 += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//其他
                    continue;
                }

            }
            data.Ypf = Getdouble(ypf2.ToString()).ToString("0.00");
            data.Clf = Getdouble(clf2.ToString()).ToString("0.00");
            data.Jcf = Getdouble(jcf2.ToString()).ToString("0.00");
            data.Zlf = Getdouble(zlf2.ToString()).ToString("0.00");
            data.Cwf = Getdouble(cwf2).ToString("0.00");
            data.Hlf = Getdouble(hlf2).ToString("0.00");
            data.Hyf = Getdouble(hyf2.ToString()).ToString("0.00");
            data.Zhenlf = Getdouble(zcf2.ToString()).ToString("0.00");
            data.Ssf = Getdouble(ssf2.ToString()).ToString("0.00");
            data.Qtf = Getdouble(qt2.ToString()).ToString("0.00");
            sourse = data;
            Preview();
            //加载附件数据
            data_fj.Yljg = "贵州省骨科医院";
            data_fj.Jb = "三级甲等";
            data_fj.Jzxlh = zydyhis.Rows[0]["inpatientsn"].ToString();
            data_fj.Jsbh = zydyhis.Rows[0]["inpatientsn"].ToString();
            data_fj.Rysj = DateTime.Parse(zydyhis.Rows[0]["zyjlrysj"].ToString()).ToString("yyyy年MM月dd日");
            data_fj.Cysj = DateTime.Parse(zydyhis.Rows[0]["zyjlcysj"].ToString()).ToString("yyyy年MM月dd日");
            data_fj.Ts = DateTime.Parse(zydyhis.Rows[0]["zyjlrysj"].ToString()).Subtract(DateTime.Parse(zydyhis.Rows[0]["zyjlcysj"].ToString())).Days.ToString();
            data_fj.Zyh = hiszyh;
            data_fj.Grbh = zydynh.Rows[0]["memberno"].ToString();
            data_fj.Hzname = zydynh.Rows[0]["name"].ToString();
            data_fj.Sex = zydynh.Rows[0]["sexname"].ToString();
            data_fj.Csny = zydynh.Rows[0]["birthday"].ToString();
            data_fj.Jtdz = zydynh.Rows[0]["address"].ToString();
            data_fj.Rylb = "";
            data_fj.Bxlb = "新农合";
            data_fj.Ryzd = zydyhis.Rows[0]["zyjlryzd"].ToString();
            data_fj.Ryxz = "";
            data_fj.Yfje = yjk.Rows[0]["amt"].ToString();
            data_fj.Cyzd = zydyhis.Rows[0]["mzzd"].ToString();
            data_fj.Bcqfx = zydynh.Rows[0]["startmoney"].ToString();
            data_fj.Bcjsfy = zydynh.Rows[0]["totalcosts"].ToString();
            data_fj.Bcjzhgfy=zydynh.Rows[0]["enablemoney"].ToString();
            data_fj.Tczfzf= zydynh.Rows[0]["calculateMoney"].ToString();
            data_fj.Tszhzf="";
            data_fj.Etlbzhzf="";
            data_fj.Nczdjbmzjz=zydynh.Rows[0]["yfmedicalaid"].ToString();
            data_fj.Dbbxpf=zydynh.Rows[0]["ciicalculatemoney"].ToString();
            data_fj.Jsfz=zydynh.Rows[0]["familyplanningwaiver"].ToString();
            data_fj.Mzjz="";
            data_fj.Dbzcxeyycdfy=zydynh.Rows[0]["hospassumemoney"].ToString();
            double dbz=0,tczf=0,tszhzf=0,etlb=0,zdjb=0;
            if(data_fj.Dbzcxeyycdfy!="")
                dbz=double.Parse(data_fj.Dbzcxeyycdfy);
             if(data_fj.Tczfzf!="")
                tczf=double.Parse(data_fj.Tczfzf);
             if(data_fj.Tszhzf!="")
                tszhzf=double.Parse(data_fj.Tszhzf);
             if(data_fj.Etlbzhzf!="")
                etlb=double.Parse(data_fj.Etlbzhzf);
              if(data_fj.Nczdjbmzjz!="")
                zdjb=double.Parse(data_fj.Nczdjbmzjz);
              double bxje = dbz + tczf + tszhzf + etlb + zdjb;
            data_fj.Bcjzgryzff = (double.Parse(data_fj.Bcjsfy)-bxje).ToString("0.00");
              double dbpf=0,jsfz=0,mzjz=0;
             if(data_fj.Dbbxpf!="")
                dbpf=double.Parse(data_fj.Dbbxpf);
             if(data_fj.Jsfz!="")
                jsfz=double.Parse(data_fj.Jsfz);
              if(data_fj.Mzjz!="")
                mzjz=double.Parse(data_fj.Mzjz);
              double bcje = dbpf + jsfz + mzjz;
              data_fj.Bcgrsjzffy = (double.Parse(data_fj.Bcjzgryzff) - bcje).ToString("0.00");


            //费用明细
            String cwf = "";//床位费 
            double zcf = 0;//诊查费
            double jcf = 0;//检查费
            double zlf = 0;//治疗费
            String hlf = "";//护理费
            String ssf = "";//手术费
            double hyf = 0;//化验费
            String xyf = "";//西药费
            String zcy = "";//中成药
            String cy = "";//中草药
            double qt = 0;//其他
            String sxf = "";//输血费
            datafpdy = zydyfp(hiszyh);
            for (int i = 0; i < datafpdy.Rows.Count; i++)
            {
                if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("床位费"))
                {
                    cwf = datafpdy.Rows[i]["Amt"].ToString();//床位费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("诊查费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("会诊"))
                {
                    zcf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//诊查费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("治疗费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("物理治疗") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("中医治疗") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("中医康复"))
                {
                    zlf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//治疗费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("护理费"))
                {
                    hlf = datafpdy.Rows[i]["Amt"].ToString();//护理费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("手术费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("麻醉"))
                {
                    ssf = datafpdy.Rows[i]["Amt"].ToString();//手术费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("化验费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("免疫") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("病理") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("心肌酶"))
                {
                    hyf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//化验费
                    continue;
                }
                if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("西药") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("药店购药"))
                {
                    xyf = datafpdy.Rows[i]["Amt"].ToString();//西药费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("中成药"))
                {
                    zcy = datafpdy.Rows[i]["Amt"].ToString();//中成药
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("中草药"))
                {
                    cy = datafpdy.Rows[i]["Amt"].ToString();//中草药
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("检查费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("喉镜") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("放射费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("CT") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("胃镜") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("核磁") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("多普勒") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("内窥镜") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("心电") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("彩超") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("脑彩超") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("脑地形图") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("A超") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("X光") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("镜检") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("喉镜") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("核医学费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("TCD") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("骨密度") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("机电图") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("B超") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("X光") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("多普勒"))
                {
                    if (!datafpdy.Rows[i]["Amt"].ToString().Equals(""))
                    {
                        jcf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//检查费
                        continue;
                    }
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("输血费"))
                {
                    sxf = datafpdy.Rows[i]["Amt"].ToString();//输血费
                    continue;
                }
                else
                {
                    qt += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//其他
                    continue;
                }

            }
            data_fj.Cwf = Getdouble(cwf).ToString("0.00");
            data_fj.Zcf = Getdouble(zcf.ToString()).ToString("0.00");
            data_fj.Jcf = Getdouble(jcf.ToString()).ToString("0.00");
            data_fj.Zlf = Getdouble(zlf.ToString()).ToString("0.00");
            data_fj.Hlf = Getdouble(hlf).ToString("0.00");
            data_fj.Ssf = Getdouble(ssf).ToString("0.00");
            data_fj.Hyf = Getdouble(hyf.ToString()).ToString("0.00");
            data_fj.Xy = Getdouble(xyf).ToString("0.00");
            data_fj.Zcy = Getdouble(zcy).ToString("0.00");
            data_fj.Cy = Getdouble(cy).ToString("0.00");
            data_fj.Qt = Getdouble(qt.ToString()).ToString("0.00");
            data_fj.Sxf = Getdouble(sxf).ToString("0.00");
            data_fj.Yyzfy = getZfy(hiszyh);
            sourse_fj = data_fj;
            Preview_fj();
        }

        private void frmnhjsddy_Load(object sender, EventArgs e)
        {

        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            report1.PrintToPrinter(1, false, 0, 0);
        }
        /// <summary>
        /// 预览方法
        /// </summary>
        public void Preview()
        {
            List<frmnhzy> list = new List<frmnhzy>();
            list.Add(sourse);

            if (list.Count > 0)
            {
                report1.SetDataSource(list);

                crystalReportViewer1.ReportSource = report1;
            }
        }

        /// <summary>
        /// 预览方法--附件
        /// </summary>
        public void Preview_fj()
        {
            List<frmnhzy_fj> list = new List<frmnhzy_fj>();
            list.Add(sourse_fj);

            if (list.Count > 0)
            {
                report2.SetDataSource(list);

                crystalReportViewer2.ReportSource = report2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            report2.PrintToPrinter(1, false, 0, 0);
        }

        /// <summary>
        /// 住院打印发票
        /// </summary>
        /// <returns></returns>
        public DataTable zydyfp(String hiszyh)
        {
            //String sql = "SELECT zyfplb.name AS Xmlb, sum(amt) AS Amt"
            //        + "  FROM mtzyjlstuff,zyfplb,mtzyjl where mtzyjlstuff.mtprod=zyfplb.iid and mtzyjl.iid =mtzyjlstuff.mtzyjl and mtzyjl.zyjlzyh=" + hiszyh + " group  BY zyfplb.name ";
            string sql = "SELECT cost_itemtype.name as Xmlb"
                        + " ,sum(ihsp_costdet.realfee) as Amt"
                        + " FROM ihsp_costdet"
                        + " left join cost_itemtype on cost_itemtype.id=ihsp_costdet.itemtype_id"
                        + " left join inhospital on inhospital.id=ihsp_costdet.ihsp_id"
                        + " where ihsp_costdet.settled='Y'"
                        + " and inhospital.ihspcode =" + DataTool.addFieldBraces(hiszyh)
                        + " GROUP BY cost_itemtype.id";
            return BllMain.Db.Select(sql).Tables[0];
        }
        public DataTable zydyfp2(String hiszyh)
        {
            //String sql = "SELECT zyfplb.name AS Xmlb, sum(amt) AS Amt"
            //        + "  FROM mtzyjlstuff,projecttype zyfplb,mtzyjl where mtzyjlstuff.projecttype=zyfplb.iid and mtzyjl.iid =mtzyjlstuff.mtzyjl and mtzyjl.zyjlzyh=" + hiszyh + " group  BY zyfplb.name ";
            string sql = "SELECT cost_itemtype1.name as Xmlb"
                        + " ,sum(ihsp_costdet.realfee) as Amt"
                        + " FROM ihsp_costdet"
                        + " left join cost_itemtype1 on cost_itemtype1.id=ihsp_costdet.itemtype1_id"
                        + " left join inhospital on inhospital.id=ihsp_costdet.ihsp_id"
                        + " where ihsp_costdet.settled='Y'"
                        + " and inhospital.ihspcode =" + DataTool.addFieldBraces(hiszyh)
                        + " GROUP BY cost_itemtype1.id";
            return BllMain.Db.Select(sql).Tables[0];
        }

        /// <summary>
        /// 总费用
        /// </summary>
        /// <param name="mtzyjliid"></param>
        /// <returns></returns>
        public string getZfy(string hiszyh)
        {
            string sql = " SELECT"
                                   + " sum(realfee) as Amt"
                                   + " FROM"
                                   + " ihsp_costdet,inhospital"
                                   + " where "
                                   + " inhospital.id = ihsp_costdet.ihsp_id"
                                   + " and ihsp_costdet.charged in ('RREC', 'RET','CHAR')  and settled='Y'"
                                   + " and inhospital.ihspcode =" + DataTool.addFieldBraces(hiszyh);

            //string sql = "select COALESCE(sum(amt),0)  AS Amt from mtzyjlstuff,mtzyjl where mtzyjl.iid = mtzyjlstuff.mtzyjl and mtzyjl.zyjlzyh='" +hiszyh+"'";
            DataTable dt1 = BllMain.Db.Select(sql).Tables[0];
            string hisfy = "0";
            try
            {
                hisfy = dt1.Rows[0]["Amt"].ToString();
            }
            catch (Exception)
            {
            }
            return hisfy;
        }
        /// <summary>
        /// 根据传过来的字符串返回double
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public double Getdouble(String str)
        {
            double ret = 0;
            try
            {
                ret = Convert.ToDouble(str.Trim());

            }
            catch
            {
                ret = 0;
            }
            return Math.Round(ret, 3);

            //if ("".Equals(str))
            //{
            //    return 0;
            //}
            //else
            //{
            //    if (yzsz(str))
            //    {
            //        return double.Parse(str);
            //    }
            //    return 0;
            //}

        }
    }
}
