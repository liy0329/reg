using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTHIS.common;
using MTREG.medinsur.ynsyb.bo;
using System.Windows.Forms;
using MTHIS.main.bll;
using System.Data;
using MTREG.common;
using MTREG.medinsur.ynsyb.bll;

namespace MTREG.medinsur.ynsyb.clinic.bll
{
    class BllClinInsurYNSYB
    {

        YNSYB ynsyb = new YNSYB();
        public int clinPreSett(GetEmpInfo_out getEmpInfo_out,string zyh,string clinic_costdet_ids,string departName,string[] yb)
        {
            //数据传输
            Dj_in dj_in = new Dj_in();
            dj_in.Jylbdm = "01";
            dj_in.Grbh = getEmpInfo_out.Grbh;
            dj_in.Ddbh = ProgramGlobal.InsurHspCode;
            dj_in.Zyh = BillSysBase.currDate();//----
            dj_in.Yllb = getEmpInfo_out.MediType;
            dj_in.Ryrq = Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd");
            dj_in.Jbr = ProgramGlobal.Username;
            dj_in.Xgspbh = getEmpInfo_out.ApproCode;//相关审批编号
            Dj_out dj_out = new Dj_out();
            int opstat = ynsyb.dj(dj_in, dj_out);
            if (opstat != 0)
            {
                MessageBox.Show(dj_out.ErrorMessage, "错误信息");
                return 1;
            }
            getEmpInfo_out.Jylsh = dj_out.Jylsh;
            getEmpInfo_out.Zycs = dj_out.Zycs;
            getEmpInfo_out.Qfx = dj_out.Qfx;
            Gxjzxx_in gxjzxx_in = new Gxjzxx_in();
            gxjzxx_in.Jylbdm = "05";
            gxjzxx_in.Grbh = dj_in.Grbh;
            gxjzxx_in.Ddbh = ProgramGlobal.InsurHspCode;
            gxjzxx_in.Jylsh = dj_out.Jylsh;
            gxjzxx_in.Gxbz = "0100011110";
            gxjzxx_in.Ks = departName + "|";//科室
            gxjzxx_in.Qzjbbm = getEmpInfo_out.DiseaseCode + "|";//确诊疾病编码
            gxjzxx_in.Ryjbmc = getEmpInfo_out.DiseaseName + "|";//入院疾病名称
            gxjzxx_in.Cyjbmc = getEmpInfo_out.DiseaseName + "|";//出院疾病名称
            gxjzxx_in.Jbr = ProgramGlobal.Username + "|";
            int opstat1 = ynsyb.gxjzxx(gxjzxx_in);
            if (opstat1 != 0)
            {
                MessageBox.Show(gxjzxx_in.ErrorMessage + "更新就诊信息失败！", "提示信息");
                return 2;
            }
            Qdmxxmdj_in qdmxxmdj_in = new Qdmxxmdj_in();
            Qdmxxmdj_out qdmxxmdj_out = new Qdmxxmdj_out();
            qdmxxmdj_in.Jylbdm = "07";
            qdmxxmdj_in.Grbh = getEmpInfo_out.Grbh;
            qdmxxmdj_in.Ddbh = ProgramGlobal.InsurHspCode;
            Cfmxlr_in cfmxlr_in = new Cfmxlr_in();
            Cfmxlr_out cfmxlr_out = new Cfmxlr_out();
            cfmxlr_in.Jylbdm = "06";
            cfmxlr_in.Grbh = getEmpInfo_out.Grbh;
            cfmxlr_in.Ddbh = ProgramGlobal.InsurHspCode;
            cfmxlr_in.Jylsh = dj_out.Jylsh;//交易流水号
            string unTransfor = "";//处方明细录入函数调用失败
            string unSync = "";//函数调用成功，更新His标志失败
            string sql = " select"
                       + " clinic_cost.billcode"//处方号
                       + ",clinic_costdet.clinic_rcpdetail_id"//处方内序号
                       + ",clinic_costdet.standcode"//医院内码
                       + ",cost_insuritem.insurcode as insurcode"//医保编码
                       + ",bas_item.name as itemname"//项目名称
                       + ",insur_itemtype.insurcode as costtype"//费用类别
                       + ",clinic_costdet.prc"
                       + ",clinic_costdet.num"
                       + ",clinic_costdet.realfee"
                       + ",clinic_costdet.unit"
                       + ",clinic_costdet.spec"
                       + ",clinic_cost.rcpdate"
                       + ",bas_doctor.name as dctname"
                       + ",bas_depart.name as dptname"
                       + ",bas_doctor.practicecode"//职业证书号
                       + " from clinic_costdet left join clinic_cost on clinic_cost.id = clinic_costdet.clinic_cost_id"
                       + " left join bas_doctor on bas_doctor.id = clinic_costdet.doctor_id"
                       + " left join bas_depart on bas_depart.id = clinic_costdet.depart_id"
                       + " left join bas_item on bas_item.id = clinic_costdet.item_id "
                       + " left join cost_insuritem on clinic_costdet.standcode =cost_insuritem.standcode and cost_insuritem.cost_insurtype_id = "
                       + " (select id from cost_insurtype where keyname = " + DataTool.addFieldBraces(CostInsurtypeKeyname.YNSYB.ToString()) + ")"
                       + " left join insur_itemtype on clinic_costdet.itemtype_id = insur_itemtype.id and insur_itemtype.cost_insurtype_id = "
                       + " (select id from cost_insurtype where keyname = " + DataTool.addFieldBraces(CostInsurtypeKeyname.YNSYB.ToString()) + ")"
                       + " where clinic_costdet.id in (" + clinic_costdet_ids + ") and clinic_costdet.insursync = 'N'";
            DataTable Costdet = BllMain.Db.Select(sql).Tables[0];
            for (int i = 0; i < Costdet.Rows.Count; i++)
            {
                string clinic_costdet_id = Costdet.Rows[i]["id"].ToString();
                string cfh = Costdet.Rows[i]["billcode"].ToString();//处方号
                string ybbm = Costdet.Rows[i]["insurcode"].ToString();//医保编码
                if (ybbm.Equals(""))
                {
                    ybbm = "9999999999";
                }
                string fylb = Costdet.Rows[i]["costtype"].ToString();//费用类别
                string yydj = Costdet.Rows[i]["prc"].ToString();//单价
                qdmxxmdj_in.Ybbh = ybbm;
                qdmxxmdj_in.Fylb = fylb;
                qdmxxmdj_in.Yydj = yydj;
                //int res = ynsyb.qdmxxmdj(qdmxxmdj_in,qdmxxmdj_out);
                //if(res != 0)
                //{
                //    mesg += "[门诊号:" +zyh+"-处方号:" + cfh + "-"+ Costdet.Rows[i]["itemname"].ToString()+"]-" + qdmxxmdj_out.ErrorMessage + " 确定明细项目单价出错 | ";
                //    continue;
                //}
                cfmxlr_in.Cfh = cfh;//处方号
                cfmxlr_in.Cfnxh = Costdet.Rows[i]["clinic_rcpdetail_id"].ToString();//处方内序号
                cfmxlr_in.Yynm = Costdet.Rows[i]["standcode"].ToString();//医院内码
                cfmxlr_in.Ybbm = ybbm;
                cfmxlr_in.Xmmc = Costdet.Rows[i]["itemname"].ToString();//项目名称
                cfmxlr_in.Fylb = fylb;//费用类别
                cfmxlr_in.Dj = yydj;//单价
                cfmxlr_in.Sl = Costdet.Rows[i]["num"].ToString();//数量
                cfmxlr_in.Je = Costdet.Rows[i]["realfee"].ToString();//金额
                cfmxlr_in.Dw = Costdet.Rows[i]["unit"].ToString();//单位
                cfmxlr_in.Gg = Costdet.Rows[i]["spec"].ToString();//规格
                cfmxlr_in.Jx = "";//剂型
                cfmxlr_in.Kfrq = Costdet.Rows[i]["rcpdate"].ToString();//开方日期
                cfmxlr_in.Kfks = Costdet.Rows[i]["dptname"].ToString();//开方科室
                cfmxlr_in.Kfys = Costdet.Rows[i]["dctname"].ToString();//开方医生
                cfmxlr_in.Xgspbh = getEmpInfo_out.ApproCode;//相关审批编号
                cfmxlr_in.Ysbm = Costdet.Rows[i]["practicecode"].ToString();//医师编码
                int ops = ynsyb.cfmxlr(cfmxlr_in, cfmxlr_out);
                if (ops != 0)
                {
                    unTransfor += "[门诊号:" + zyh + "-clinic_costdet_id:" + clinic_costdet_id + "-" + Costdet.Rows[i]["itemname"].ToString() + "]-" + cfmxlr_out.ErrorMessage + " 处方明细录入出错 | ";
                    continue;
                }
                string sql_upd = "update clinic_costdet set insursync = 'Y' where id = " + clinic_costdet_id + ";";
                string costdetXML = "info";
                costdetXML += "Jylsh" + cfmxlr_out.Jylsh + "/Jylsh";
                costdetXML += "Sjdj" + cfmxlr_out.Sjdj + "/Sjdj";
                costdetXML += "Xmdj" + cfmxlr_out.Xmdj + "/Xmdj";
                costdetXML += "Sph" + cfmxlr_out.Sph + "/Sph";
                costdetXML += "Zlfy" + cfmxlr_out.Zlfy + "/Zlfy";
                costdetXML += "Zffy" + cfmxlr_out.Zffy + "/Zffy";
                costdetXML += "Cfje" + cfmxlr_out.Cfje + "/Cfje";
                costdetXML += "Znshydxx" + cfmxlr_out.Znshydxx + "/Znshydxx";
                costdetXML += "ErrorMessage" + cfmxlr_out.ErrorMessage + "/ErrorMessage";
                costdetXML += "/info";
                string insur_costdet_id = BillSysBase.nextId("insur_costdet");
                sql_upd += "insert into insur_costdet (id,clinic_costdet_id,ihsp_costdet_id,insur_costed_id,costdetinfo) values ( "
                          + DataTool.addFieldBraces(insur_costdet_id) + "," + DataTool.addFieldBraces(clinic_costdet_id)+","+DataTool.addFieldBraces("")+","
                          + DataTool.addFieldBraces(cfmxlr_out.Jylsh) + "," + DataTool.addFieldBraces(costdetXML);
                ops = BllMain.Db.Update(sql_upd);
                if (ops != 0)
                {
                    unSync += "[门诊号:" + zyh + "-clinic_costdet_id:" + clinic_costdet_id + "-" + Costdet.Rows[i]["itemname"].ToString() + "]-" + " 更新His库标志失败 | ";
                    continue;
                }
            }
            if (unTransfor != "")
            {
                MessageBox.Show("部分条目上传失败:" + unTransfor + "|部分条目更新His标志失败:" + unSync);
                return 4;
            }
            if (unSync != "")
            {
                MessageBox.Show("部分条目更新His标志失败:" + unSync + "请退方重传");
                return 5;
            }
            //预结算
            Yjs_in yjs_in = new Yjs_in();
            Yjs_out yjs_out = new Yjs_out();
            yjs_in.Jylbdm = "09";
            yjs_in.Grbh = getEmpInfo_out.Grbh;
            yjs_in.Ddbh = ProgramGlobal.InsurHspCode;
            yjs_in.Jylsh = dj_out.Jylsh;//交易流水号
            yjs_in.Cfjzsj = "";
            yjs_in.Kzfje = "";//卡支付金额
            yjs_in.Qfxzfje = "";//起付线支付金额
            int res = ynsyb.yjs(yjs_in, yjs_out);
            if (res != 0)
            {
                MessageBox.Show("预结算失败:" + yjs_out.ErrorMessage, "错误信息");
                return 3;
            }
            string lsh = yjs_out.Jylsh;
            string zfy = yjs_out.Zfy;
            string tc = yjs_out.Tc;
            string zh = yjs_out.Zh;
            string xj = yjs_out.Xj;
            string dblp = yjs_out.Dblp;
            string zgrybz = yjs_out.Zgrybz;
            string gwybz = yjs_out.Gwybz;
            string jfqgzrybz = yjs_out.Jfqgzrybz;
            string qfx = yjs_out.Qfx;
            string zycs = yjs_out.Zycs;
            string qfxsy = yjs_out.Qfxsy;
            string jssj = yjs_out.Jssj;
            string bgbz = yjs_out.Bgbz;
            string bgjy = yjs_out.Bgjy;
            string qzfje = yjs_out.Qzfje;
            string znshydxx = yjs_out.Znshydxx;
            string tczf = (DataTool.stringToDouble(tc) + DataTool.stringToDouble(dblp)).ToString();
            yb[0] = zfy;
            yb[1] = xj;
            yb[2] = tczf;
            yb[3] = zh;
            return 0;
        }
        public int settle(GetEmpInfo_out getEmpInfo_out,string invoiceCode,string invoiceId)
        { 
               Js_in js_in = new Js_in();
               Js_out js_out = new Js_out();
               js_in.Jylbdm = "10";
               js_in.Grbh = getEmpInfo_out.Grbh;
               js_in.Ddbh = ProgramGlobal.InsurHspCode;
               js_in.Jylsh = getEmpInfo_out.Jylsh;
               js_in.Cfjzsj = "";
               js_in.Fph = invoiceCode;
               js_in.Jslx = "1";//结算类型
               js_in.Jbr = ProgramGlobal.Username;
               js_in.Kzfje = "";//卡支付金额
               js_in.Qfxzfje = "";//起付线支付金额
               int res = ynsyb.js(js_in,js_out);
               if(res != 0)
               {
                   MessageBox.Show("结算失败:"+js_out.ErrorMessage + "错误信息");
                   return -1;
               }
               //交易流水号（结算ID）| 总费用|统筹|账户|现金|大病理赔|照顾人员补助|公务员补助|解放前工作人员补助|起付线|住院次数|起付线剩余|结算时间|包干标准|包干结余|全自费金额|只能审核疑点信息
               string settinfoXml = "<info>";
               settinfoXml += "<Jylsh>" + js_out.Jylsh + "</Jylsh>";
               settinfoXml += "<Zfy>" + js_out.Zfy + "</Zfy>";
               settinfoXml += "<Tc>" + js_out.Tc + "</Tc>";
               settinfoXml += "<Zh>" + js_out.Zh + "</Zh>";
               settinfoXml += "<Xj>" + js_out.Xj + "</Xj>";
               settinfoXml += "<Dblp>" + js_out.Dblp + "</Dblp>";
               settinfoXml += "<Zgrybz>" + js_out.Zgrybz + "</Zgrybz>";
               settinfoXml += "<Gwybz>" + js_out.Gwybz + "</Gwybz>";
               settinfoXml += "<Jfqgzrybz>" + js_out.Jfqgzrybz + "</Jfqgzrybz>";
               settinfoXml += "<Qfx>" + js_out.Qfx + "</Qfx>";
               settinfoXml += "<Zycs>" + js_out.Zycs + "</Zycs>";
               settinfoXml += "<Qfxsy>" + js_out.Qfxsy + "</Qfxsy>";
               settinfoXml += "<Jssj>" + js_out.Jssj + "</Jssj>";
               settinfoXml += "<Bgbz>" + js_out.Bgbz + "</Bgbz>";
               settinfoXml += "<Bgjy>" + js_out.Bgjy + "</Bgjy>";
               settinfoXml += "<Qzfje>" + js_out.Qzfje + "</Qzfje>";
               settinfoXml += "<Znshydxx>" + js_out.Znshydxx + "</Znshydxx>";
               settinfoXml += "</info>";
 
            //姓名|性别|身份证号|出身日期|人员类别编码|人员类别名称|单位名称|单位编号|统筹区号|区域编号|职工居民标志|医保参数1名称|医保参数1值|医保参数2名称|医保参数2值|医保参数3名称|医保参数3值|医保参数4名称|医保参数4值|医保参数5名称|医保参数5值|医保参数6名称|医保参数6值
            //|个人编号|卡号（无卡人员为空）|账户余额|封锁标志|封锁类型|
            //医疗类别|审批类别|审批编号|疾病编码|疾病名称|项目编码|项目名称|交易流水号(医保登记函数返回)|住院次数|起付线
            string registXml = "<info>";
            registXml += "<Xm>" + getEmpInfo_out.Xm + "</Xm>";
            registXml += "<Xb>" + getEmpInfo_out.Xb+ "</Xb>";
            registXml += "<Sfzh>" + getEmpInfo_out.Sfzh+ "</Sfzh>";
            registXml += "<Csrq>" + getEmpInfo_out.Csrq+ "</Csrq>";
            registXml += "<Rylbbm>" + getEmpInfo_out.Rylbbm+ "</Rylbbm>";
            registXml += "<Rylbmc>" + getEmpInfo_out.Rylbmc+ "</Rylbmc>";
            registXml += "<Dwmc>" + getEmpInfo_out.Dwmc+ "</Dwmc>";
            registXml += "<Dwbh>" + getEmpInfo_out.Dwbh+ "</Dwbh>";
            registXml += "<Tcqh>" + getEmpInfo_out.Tcqh+ "</Tcqh>";
            registXml += "<Qybh>" + getEmpInfo_out.Qybh+ "</Qybh>";
            registXml += "<Zgjmbz>" + getEmpInfo_out.Zgjmbz+ "</Zgjmbz>";
            registXml += "<Ybcsmc1>" + getEmpInfo_out.Ybcsmc1+ "</Ybcsmc1>";
            registXml += "<Ybcsz1>" + getEmpInfo_out.Ybcsz1+ "</Ybcsz1>";
            registXml += "<Ybcsmc2>" + getEmpInfo_out.Ybcsmc2+ "</Ybcsmc2>";
            registXml += "<Ybcsz2>" + getEmpInfo_out.Ybcsz2+ "</Ybcsz2>";
            registXml += "<Ybcsmc3>" + getEmpInfo_out.Ybcsmc3+ "</Ybcsmc3>";
            registXml += "<Ybcsz3>" + getEmpInfo_out.Ybcsz3+ "</Ybcsz3>";
            registXml += "<Ybcsmc4>" + getEmpInfo_out.Ybcsmc4+ "</Ybcsmc4>";
            registXml += "<Ybcsz4>" + getEmpInfo_out.Ybcsz4+ "</Ybcsz4>";
            registXml += "<Ybcsmc5>" + getEmpInfo_out.Ybcsmc5+ "</Ybcsmc5>";
            registXml += "<Ybcsz5>" + getEmpInfo_out.Ybcsz5+ "</Ybcsz5>";
            registXml += "<Ybcsmc6>" + getEmpInfo_out.Ybcsmc6+ "</Ybcsmc6>";
            registXml += "<Ybcsz6>" + getEmpInfo_out.Ybcsz6+ "</>Ybcsz6";
            registXml += "<Grbh>" + getEmpInfo_out.Grbh+ "</Grbh>";
            registXml += "<Kh>" + getEmpInfo_out.Kh+ "</Kh>";
            registXml += "<Zhye>" + getEmpInfo_out.Zhye+ "</Zhye>";
            registXml += "<Fsbz>" + getEmpInfo_out.Fsbz+ "</Fsbz>";
            registXml += "<Fslx>" + getEmpInfo_out.Fslx+ "</Fslx>";
            registXml += "<MediType>" + getEmpInfo_out.MediType+ "</MediType>";
            registXml += "<ApproType>" + getEmpInfo_out.ApproType+ "</ApproType>";
            registXml += "<ApproCode>" + getEmpInfo_out.ApproCode+ "</ApproCode>";
            registXml += "<DiseaseCode>" + getEmpInfo_out.DiseaseCode+ "</DiseaseCode>";
            registXml += "<DiseaseName>" + getEmpInfo_out.DiseaseName+ "</DiseaseName>";
            registXml += "<ApItemCode>" + getEmpInfo_out.ApItemCode + "</ApItemCode>";
            registXml += "<ApItemName>" + getEmpInfo_out.ApItemName + "</ApItemName>";
            registXml += "<Jylsh>" + getEmpInfo_out.Jylsh + "</Jylsh>";
            registXml += "<Zycs>" + getEmpInfo_out.Zycs + "</Zycs>";
            registXml += "<Qfx>" + getEmpInfo_out.Qfx + "</Qfx>";
            registXml += "</info>";
            string clinic_insurinfo_id = BillSysBase.nextId("clinic_insurinfo");
            string sql = "insert into clinic_insurinfo ("
                       + " id"
                       + ",clinic_invoice_id"
                       //+ ",midsettinfo"
                       + ",registinfo"
                       + ",settinfo"
                       + ",opstat) values ("
                       + DataTool.addFieldBraces(clinic_insurinfo_id)
                       + ","+DataTool.addFieldBraces(invoiceId)
                     //+ ","+
                       + "," + DataTool.addFieldBraces(registXml)
                       + "," + DataTool.addFieldBraces(settinfoXml)
                       + "," + DataTool.addFieldBraces("SETT")
                       + ");";
            res = BllMain.Db.Update(sql);
            if (res != 0)
            {
                MessageBox.Show("插入HIS医保信息信息出错");
                //Jszh_in jszh_in = new Jszh_in();
                //Jszh_out jszh_out = new Jszh_out();
                //jszh_in.Jylbdm = "11";
                //jszh_in.Grbh = getEmpInfo_out.Grbh;
                //jszh_in.Ddbh = ProgramGlobal.InsurHspCode;
                //jszh_in.Jylsh = jylsh;
                //jszh_in.Fph = invoiceCode;
                //jszh_in.Jbr = ProgramGlobal.Username;
                //res = ynsyb.jszh(jszh_in, jszh_out);
                //if (ops == 0)
                //{
                //    MessageBox.Show("退结算成功！");
                //}
                res = deleteData(getEmpInfo_out,"10");
                if (res != 0)
                {
                    return res;
                }
                return 1;
            }
            return 0;
        }
        /// <summary>
        /// 读取云南省医保信息
        /// </summary>
        /// <returns></returns>
        public DataTable readClinSettInfo(string invoice_id)
        {
            string sql = "select settinfo from clinic_insurinfo where clinic_invoice_id = " + DataTool.addFieldBraces(invoice_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            string reginfo = dt.Rows[0]["settinfo"].ToString();
            System.IO.StringReader sr = new System.IO.StringReader(reginfo);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            return ds.Tables["info"];
        }
        /// <summary>
        /// 医保退费
        /// </summary>
        /// <returns></returns>
        public int settleBack(string invoiceId,string invoiceCode,GetEmpInfo_out getEmpInfo_out)
        {
            DataTable dt = readClinSettInfo(invoiceId);
            if(dt.Rows.Count == 0)
            {
                 MessageBox.Show("未找到改医保结算信息，请检查");
                return -1;
            }
            string jylsh = dt.Rows[0]["Jylsh"].ToString();
            Jszh_in jszh_in = new Jszh_in();
            Jszh_out jszh_out = new Jszh_out();
            jszh_in.Jylbdm = "11";
            jszh_in.Grbh = getEmpInfo_out.Grbh;
            jszh_in.Ddbh = ProgramGlobal.InsurHspCode;
            jszh_in.Jylsh = jylsh;
            jszh_in.Fph = invoiceCode;
            jszh_in.Jbr = ProgramGlobal.Username;
            int ops = ynsyb.jszh(jszh_in,jszh_out);
            if(ops != 0)
            {
                 MessageBox.Show("结算召回失败:"+jszh_out.ErrorMessage,"错误信息");
                return -2;
            }
            //sql = "update clinic_insurinfo set opstat = ";
            Wjscfqcjy_in wjscfqcjy_in = new Wjscfqcjy_in();
            wjscfqcjy_in.Jylbdm = "98";
            wjscfqcjy_in.Grbh = getEmpInfo_out.Grbh;
            wjscfqcjy_in.Jylsh = jylsh;
            wjscfqcjy_in.Yybm = ProgramGlobal.InsurHspCode;
            ops = ynsyb.wjscfqcjy(wjscfqcjy_in);
            if(ops!=0)
            {
                MessageBox.Show("费用删除失败:"+wjscfqcjy_in.ErrorMessage,"错误信息");
            }
            return 0;
        }
        public int deleteRcp(GetEmpInfo_out getEmpInfo_out)
        {
            Wjscfqcjy_in wjscfqcjy_in = new Wjscfqcjy_in();
            wjscfqcjy_in.Jylbdm = "98";
            wjscfqcjy_in.Grbh = getEmpInfo_out.Grbh;
            wjscfqcjy_in.Jylsh = getEmpInfo_out.Jylsh;
            wjscfqcjy_in.Yybm = ProgramGlobal.InsurHspCode;
            int ops = ynsyb.wjscfqcjy(wjscfqcjy_in);
            if (ops != 0) 
            {
                return -1;
            }
            Wfty_in wfty_in = new Wfty_in();
            wfty_in.Jylbdm = "16";
            wfty_in.Grbh = getEmpInfo_out.Grbh;
            wfty_in.Jylsh = getEmpInfo_out.Jylsh;
            wfty_in.Ddbh = ProgramGlobal.InsurHspCode;
            ynsyb.wfty(wfty_in);

            return 0;
        }
        public int deleteData(GetEmpInfo_out getEmpInfo_out,string jylx)
        {
            Czjy_in czjy_in = new Czjy_in();
            czjy_in.Jylbdm = "99";
            czjy_in.Grbh = getEmpInfo_out.Grbh;
            czjy_in.Bczjylsh = getEmpInfo_out.Jylsh;
            czjy_in.Bczjylxdm = jylx;
            czjy_in.Czy = ProgramGlobal.Username;
            int res = ynsyb.czjy(czjy_in);
            if (res == 0)
            {
                MessageBox.Show(czjy_in.ErrorMessage, "错误信息");
                return -3;
            }
            return 0;
        }
    }
}
