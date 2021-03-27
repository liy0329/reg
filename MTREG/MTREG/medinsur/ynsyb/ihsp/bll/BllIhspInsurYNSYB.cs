using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTREG.medinsur.ynsyb.bo;
using MTREG.medinsur.ynsyb.bll;
using MTHIS.common;
using System.Windows.Forms;
using MTREG.common;
using MTHIS.main.bll;
using System.Data;

namespace MTREG.medinsur.ynsyb.ihsp.bll
{
    class BllIhspInsurYNSYB
    {
        YNSYB ynsyb = new YNSYB();
        /// <summary>
        /// 冲正交易
        /// </summary>
        /// <param name="grbh"></param>
        /// <param name="jylsh"></param>
        /// <param name="jylx"></param>
        /// <returns></returns>
        public int czjy(string grbh,string jylsh,string jylx)
        {
            Czjy_in czjy_in = new Czjy_in();
            czjy_in.Jylbdm = "99";
            czjy_in.Grbh = grbh;
            czjy_in.Bczjylsh = jylsh;
            czjy_in.Bczjylxdm = jylx;
            czjy_in.Czy = ProgramGlobal.Username;
            int res = ynsyb.czjy(czjy_in);
            return res;
        }
        public int insurReg(GetEmpInfo_out getEmpInfo_out ,string ihsp_id,string ihspCode,string inDate)
        {
            Dj_in dj_in = new Dj_in();
            dj_in.Jylbdm = "01";
            dj_in.Grbh = getEmpInfo_out.Grbh;
            dj_in.Ddbh = ProgramGlobal.InsurHspCode;
            dj_in.Zyh = ihspCode;
            dj_in.Yllb = getEmpInfo_out.MediType;
            dj_in.Ryrq = Convert.ToDateTime(inDate).ToString("yyyy-MM-dd");
            dj_in.Jbr = ProgramGlobal.Username;
            dj_in.Xgspbh = getEmpInfo_out.ApproCode;//相关审批编号
            Dj_out dj_out = new Dj_out();
            int opstat = ynsyb.dj(dj_in, dj_out);
            if (opstat != 0)
            {
                MessageBox.Show(dj_out.ErrorMessage, "错误信息");
                return -1;
            }
            getEmpInfo_out.Jylsh = dj_out.Jylsh;
            getEmpInfo_out.Zycs = dj_out.Zycs;
            getEmpInfo_out.Qfx = dj_out.Qfx;
            //姓名|性别|身份证号|出身日期|人员类别编码|人员类别名称|单位名称|单位编号|统筹区号|区域编号|职工居民标志|医保参数1名称|医保参数1值|医保参数2名称|医保参数2值|医保参数3名称|医保参数3值|医保参数4名称|医保参数4值|医保参数5名称|医保参数5值|医保参数6名称|医保参数6值
            //|个人编号|卡号（无卡人员为空）|账户余额|封锁标志|封锁类型|
            //医疗类别|审批类别|审批编号|疾病编码|疾病名称|项目编码|项目名称|交易流水号(医保登记函数返回)|住院次数|起付线
            string reginfoXml = "<info>";
            reginfoXml += "<Xm>" + getEmpInfo_out.Xm + "</Xm>";
            reginfoXml += "<Xb>" + getEmpInfo_out.Xb + "</Xb>";
            reginfoXml += "<Sfzh>" + getEmpInfo_out.Sfzh + "</Sfzh>";
            reginfoXml += "<Csrq>" + getEmpInfo_out.Csrq + "</Csrq>";
            reginfoXml += "<Rylbbm>" + getEmpInfo_out.Rylbbm + "</Rylbbm>";
            reginfoXml += "<Rylbmc>" + getEmpInfo_out.Rylbmc + "</Rylbmc>";
            reginfoXml += "<Dwmc>" + getEmpInfo_out.Dwmc + "</Dwmc>";
            reginfoXml += "<Dwbh>" + getEmpInfo_out.Dwbh + "</Dwbh>";
            reginfoXml += "<Tcqh>" + getEmpInfo_out.Tcqh + "</Tcqh>";
            reginfoXml += "<Qybh>" + getEmpInfo_out.Qybh + "</Qybh>";
            reginfoXml += "<Zgjmbz>" + getEmpInfo_out.Zgjmbz + "</Zgjmbz>";
            reginfoXml += "<Ybcsmc1>" + getEmpInfo_out.Ybcsmc1 + "</Ybcsmc1>";
            reginfoXml += "<Ybcsz1>" + getEmpInfo_out.Ybcsz1 + "</Ybcsz1>";
            reginfoXml += "<Ybcsmc2>" + getEmpInfo_out.Ybcsmc2 + "</Ybcsmc2>";
            reginfoXml += "<Ybcsz2>" + getEmpInfo_out.Ybcsz2 + "</Ybcsz2>";
            reginfoXml += "<Ybcsmc3>" + getEmpInfo_out.Ybcsmc3 + "</Ybcsmc3>";
            reginfoXml += "<Ybcsz3>" + getEmpInfo_out.Ybcsz3 + "</Ybcsz3>";
            reginfoXml += "<Ybcsmc4>" + getEmpInfo_out.Ybcsmc4 + "</Ybcsmc4>";
            reginfoXml += "<Ybcsz4>" + getEmpInfo_out.Ybcsz4 + "</Ybcsz4>";
            reginfoXml += "<Ybcsmc5>" + getEmpInfo_out.Ybcsmc5 + "</Ybcsmc5>";
            reginfoXml += "<Ybcsz5>" + getEmpInfo_out.Ybcsz5 + "</Ybcsz5>";
            reginfoXml += "<Ybcsmc6>" + getEmpInfo_out.Ybcsmc6 + "</Ybcsmc6>";
            reginfoXml += "<Ybcsz6>" + getEmpInfo_out.Ybcsz6 + "</>Ybcsz6";
            reginfoXml += "<Grbh>" + getEmpInfo_out.Grbh + "</Grbh>";
            reginfoXml += "<Kh>" + getEmpInfo_out.Kh + "</Kh>";
            reginfoXml += "<Zhye>" + getEmpInfo_out.Zhye + "</Zhye>";
            reginfoXml += "<Fsbz>" + getEmpInfo_out.Fsbz + "</Fsbz>";
            reginfoXml += "<Fslx>" + getEmpInfo_out.Fslx + "</Fslx>";
            reginfoXml += "<MediType>" + getEmpInfo_out.MediType + "</MediType>";
            reginfoXml += "<ApproType>" + getEmpInfo_out.ApproType + "</ApproType>";
            reginfoXml += "<ApproCode>" + getEmpInfo_out.ApproCode + "</ApproCode>";
            reginfoXml += "<DiseaseCode>" + getEmpInfo_out.DiseaseCode + "</DiseaseCode>";
            reginfoXml += "<DiseaseName>" + getEmpInfo_out.DiseaseName + "</DiseaseName>";
            reginfoXml += "<ApItemCode>" + getEmpInfo_out.ApItemCode + "</ApItemCode>";
            reginfoXml += "<ApItemName>" + getEmpInfo_out.ApItemName + "</ApItemName>";
            reginfoXml += "<Jylsh>" + getEmpInfo_out.Jylsh + "</Jylsh>";
            reginfoXml += "<Zycs>" + getEmpInfo_out.Zycs + "</Zycs>";
            reginfoXml += "<Qfx>" + getEmpInfo_out.Qfx + "</Qfx>";
            reginfoXml += "</info>";
            string ihsp_insurinfo_id = BillSysBase.nextId("ihsp_insurinfo");
            string sql = "insert into ihsp_insurinfo ("
                       + " id"
                       + ",ihsp_id"
                //+ ",midsettinfo"
                       + ",registinfo"
                       + ",opstat) values ("
                       + DataTool.addFieldBraces(ihsp_insurinfo_id)
                       + "," + DataTool.addFieldBraces(ihsp_id)
                //+ ","+
                       + "," + DataTool.addFieldBraces(reginfoXml)
                       + "," + DataTool.addFieldBraces("REG")
                       + ");";
            int res = BllMain.Db.Update(sql);
            if (res != 0)
            {
                czjy(getEmpInfo_out.Grbh,getEmpInfo_out.Jylsh,"01");                
                MessageBox.Show("插入本地His库出错，医保登记失败！");
                return -2;
            }
            return 0;
        }
        /// <summary>
        /// 读取云南省医保登记信息
        /// </summary>
        /// <param name="ihspid"></param>
        /// <returns></returns>
        public DataTable readIhspRegInfo(string ihspid)
        {
            string sql = "select registinfo from ihsp_insurinfo where ihsp_id = " + DataTool.addFieldBraces(ihspid);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            string reginfo = dt.Rows[0]["registinfo"].ToString();
            System.IO.StringReader sr = new System.IO.StringReader(reginfo);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            return ds.Tables["info"];
        }
        /// <summary>
        /// 读取云南省医保信息
        /// </summary>
        /// <returns></returns>
        public DataTable readIhspSettInfo(string ihsp_id)
        {
            string sql = "select registinfo,settinfo from ihsp_insurinfo where ihsp_id = " + DataTool.addFieldBraces(ihsp_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            string reginfo = dt.Rows[0]["settinfo"].ToString();
            System.IO.StringReader sr = new System.IO.StringReader(reginfo);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            return ds.Tables["info"];
        }
        /// <summary>
        /// 更新住院信息
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <param name="departName"></param>
        /// <param name="diseaseCode"></param>
        /// <param name="diseaseNameIn"></param>
        /// <param name="getEmpInfo_out"></param>
        /// <returns></returns>
        public int reNewRegInfo(string ihsp_id,string departName, string diseaseCode, string diseaseNameIn,GetEmpInfo_out getEmpInfo_out)
        {
            DataTable dt = readIhspRegInfo(ihsp_id);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("该患者没有医保登记信息！请检查");
                return -1;
            }
            //姓名|性别|身份证号|出身日期|人员类别编码|人员类别名称|单位名称|单位编号|统筹区号|区域编号|职工居民标志|医保参数1名称|医保参数1值|医保参数2名称|医保参数2值|医保参数3名称|医保参数3值|医保参数4名称|医保参数4值|医保参数5名称|医保参数5值|医保参数6名称|医保参数6值
            //|个人编号|卡号（无卡人员为空）|账户余额|封锁标志|封锁类型|
            //医疗类别|审批类别|审批编号|疾病编码|疾病名称|项目编码|项目名称|交易流水号(医保登记函数返回)|住院次数|起付线
            string grbh = getEmpInfo_out.Grbh;
            string jylsh = dt.Rows[0]["Jylsh"].ToString();
            Gxjzxx_in gxjzxx_in = new Gxjzxx_in();
            gxjzxx_in.Jylbdm = "05";
            gxjzxx_in.Grbh = grbh;
            gxjzxx_in.Ddbh = ProgramGlobal.InsurHspCode;
            gxjzxx_in.Jylsh = jylsh;
            gxjzxx_in.Gxbz = "1100011010";
            gxjzxx_in.Yllb = getEmpInfo_out.MediType+"|";//医疗类别
            gxjzxx_in.Ks = departName + "|";//科室
            gxjzxx_in.Qzjbbm = diseaseCode + "|";//确诊疾病编码
            gxjzxx_in.Ryjbmc = diseaseNameIn + "|";//入院疾病名称
            gxjzxx_in.Jbr = ProgramGlobal.Username + "|";
            int ops = ynsyb.gxjzxx(gxjzxx_in);
            if (ops != 0)
            {
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 更新出院信息
        /// </summary>
        /// <returns></returns>
        public int reNewOutHspInfo(string ihsp_id)
        {
            DataTable dt = readIhspRegInfo(ihsp_id);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("该患者没有医保登记信息！请检查");
                return -1;
            }
            //姓名|性别|身份证号|出身日期|人员类别编码|人员类别名称|单位名称|单位编号|统筹区号|区域编号|职工居民标志|医保参数1名称|医保参数1值|医保参数2名称|医保参数2值|医保参数3名称|医保参数3值|医保参数4名称|医保参数4值|医保参数5名称|医保参数5值|医保参数6名称|医保参数6值
            //|个人编号|卡号（无卡人员为空）|账户余额|封锁标志|封锁类型|
            //医疗类别|审批类别|审批编号|疾病编码|疾病名称|项目编码|项目名称|交易流水号(医保登记函数返回)|住院次数|起付线
            string grbh = dt.Rows[0]["Grbh"].ToString();
            string jylsh = dt.Rows[0]["Jylsh"].ToString();
            Gxjzxx_in gxjzxx_in = new Gxjzxx_in();
            gxjzxx_in.Jylbdm = "05";
            gxjzxx_in.Grbh = grbh;
            gxjzxx_in.Ddbh = ProgramGlobal.InsurHspCode;
            gxjzxx_in.Jylsh = jylsh;
            gxjzxx_in.Gxbz = "0001001001";
            gxjzxx_in.Cyrq = "";//出院日期
            gxjzxx_in.Cyjbmc = "";//出院疾病名称
            gxjzxx_in.Cyyy = "";//出院原因
            gxjzxx_in.Jbr = ProgramGlobal.Username + "|";
            int ops = ynsyb.gxjzxx(gxjzxx_in);
            if (ops != 0)
            {
                return -1;
            }
            return 0;
        }
        public int costTransfer(string ihsp_id, string patientType_id ,string zyh,StringBuilder msg)
        {
            DataTable dt = readIhspRegInfo(ihsp_id);
            if (dt.Rows.Count == 0)
                return -1;
            //姓名|性别|身份证号|出身日期|人员类别编码|人员类别名称|单位名称|单位编号|统筹区号|区域编号|职工居民标志|医保参数1名称|医保参数1值|医保参数2名称|医保参数2值|医保参数3名称|医保参数3值|医保参数4名称|医保参数4值|医保参数5名称|医保参数5值|医保参数6名称|医保参数6值
            //|个人编号|卡号（无卡人员为空）|账户余额|封锁标志|封锁类型|
            //医疗类别|审批类别|审批编号|疾病编码|疾病名称|项目编码|项目名称|交易流水号(医保登记函数返回)|住院次数|起付线
            string grbh = dt.Rows[0]["Grbh"].ToString();
            string jylsh = dt.Rows[0]["Jylsh"].ToString();
            string xgspbh = dt.Rows[0]["Xgspbh"].ToString();//相关审批编号
            Qdmxxmdj_in qdmxxmdj_in = new Qdmxxmdj_in();
            Qdmxxmdj_out qdmxxmdj_out = new Qdmxxmdj_out();
            qdmxxmdj_in.Jylbdm = "07";
            qdmxxmdj_in.Grbh = grbh;
            qdmxxmdj_in.Ddbh = ProgramGlobal.InsurHspCode;
            Cfmxlr_in cfmxlr_in = new Cfmxlr_in();
            Cfmxlr_out cfmxlr_out = new Cfmxlr_out();
            cfmxlr_in.Jylbdm = "06";
            cfmxlr_in.Grbh = grbh;
            cfmxlr_in.Ddbh = ProgramGlobal.InsurHspCode;
            cfmxlr_in.Jylsh = jylsh;//交易流水号
            string unTransfor = "";//处方明细录入函数调用失败
            string unSync = "";//函数调用成功，更新His标志失败
            string sql = " select"
                       + " ihsp_costdet.id"//处方内序号
                       + ",ihsp_costdet.standcode"//医院内码
                       + ",cost_insuritem.insurcode as insurcode"//医保编码
                       + ",bas_item.name as itemname"//项目名称
                       + ",insur_itemtype.insurcode as costtype"//费用类别
                       + ",ihsp_costdet.prc"
                       + ",ihsp_costdet.num"
                       + ",ihsp_costdet.realfee"
                       + ",ihsp_costdet.unit"
                       + ",ihsp_costdet.spec"
                       + ",ihsp_costdet.costexdate"
                       + ",bas_doctor.name as dctname"
                       + ",bas_depart.name as dptname"
                       + ",bas_doctor.practicecode"//职业证书号
                       + " from ihsp_costdet "
                       + " left join bas_doctor on bas_doctor.id = ihsp_costdet.diagndoctor_id"
                       + " left join bas_depart on bas_depart.id = ihsp_costdet.diagndep_id"
                       + " left join bas_item on bas_item.id = ihsp_costdet.item_id "
                       + " left join cost_insuritem on ihsp_costdet.standcode =cost_insuritem.standcode and cost_insuritem.cost_insurtype_id = "
                       + " (select id from cost_insurtype where keyname = " + DataTool.addFieldBraces(CostInsurtypeKeyname.YNSYB.ToString()) + ")"
                       + " left join insur_itemtype on ihsp_costdet.itemtype_id = insur_itemtype.id and insur_itemtype.cost_insurtype_id = "
                       + " (select id from cost_insurtype where keyname = " + DataTool.addFieldBraces(CostInsurtypeKeyname.YNSYB.ToString()) + ")"
                       + " where ihsp_costdet.ihsp_id = " + DataTool.addFieldBraces(ihsp_id) + " and ihsp_costdet.insursync = 'N'";
            DataTable Costdet = BllMain.Db.Select(sql).Tables[0];
            for (int i = 0; i < Costdet.Rows.Count; i++)
            {
                string ihsp_costdet_id = Costdet.Rows[i]["id"].ToString();
                string cfh = "";//处方号
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
                cfmxlr_in.Cfnxh = ihsp_costdet_id;//处方内序号
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
                cfmxlr_in.Kfrq = Costdet.Rows[i]["costexdate"].ToString();//开方日期
                cfmxlr_in.Kfks = Costdet.Rows[i]["dptname"].ToString();//开方科室
                cfmxlr_in.Kfys = Costdet.Rows[i]["dctname"].ToString();//开方医生
                cfmxlr_in.Xgspbh = xgspbh;//相关审批编号
                cfmxlr_in.Ysbm = Costdet.Rows[i]["practicecode"].ToString();//医师编码
                int ops = ynsyb.cfmxlr(cfmxlr_in, cfmxlr_out);
                if (ops != 0)
                {
                    unTransfor += "[住院号:" + zyh + "-ihsp_costdet_id:" + ihsp_costdet_id + "-" + Costdet.Rows[i]["itemname"].ToString() + "]-" + cfmxlr_out.ErrorMessage + " 处方明细录入出错 | ";
                    continue;
                }
                string sql_upd = "update ihsp_costdet set insursync = 'Y' where id = " + ihsp_costdet_id + ";";
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
                          + DataTool.addFieldBraces(insur_costdet_id) + "," + DataTool.addFieldBraces("") + "," + DataTool.addFieldBraces("ihsp_costdet_id") + ","
                          + DataTool.addFieldBraces(cfmxlr_out.Jylsh) + "," + DataTool.addFieldBraces(costdetXML);
                ops = BllMain.Db.Update(sql_upd);
                if (ops != 0)
                {
                    unSync += "[住院号:" + zyh + "-ihsp_costdet_id:" + ihsp_costdet_id + "-" + Costdet.Rows[i]["itemname"].ToString() + "]-" + " 更新His库标志失败 | ";
                    continue;
                }
            }
            if (unTransfor != "")
            {
                MessageBox.Show("部分条目上传失败:" + unTransfor + "|部分条目更新His标志失败:" + unSync);
                return -1;
            }
            if (unSync != "")
            {
                MessageBox.Show("部分条目更新His标志失败:" + unSync + "请退方重传");
                return -2;
            }
            return 0;
        }
        /// <summary>
        /// 预结算
        /// </summary>
        /// <param name="getEmpInfo_out"></param>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public int preSettle(GetEmpInfo_out getEmpInfo_out,string zyh,string ihsp_id)
        {
            DataTable dt = readIhspRegInfo(ihsp_id);
            if (dt.Rows.Count == 0)
            {
                return -1;
            }
            //姓名|性别|身份证号|出身日期|人员类别编码|人员类别名称|单位名称|单位编号|统筹区号|区域编号|职工居民标志|医保参数1名称|医保参数1值|医保参数2名称|医保参数2值|医保参数3名称|医保参数3值|医保参数4名称|医保参数4值|医保参数5名称|医保参数5值|医保参数6名称|医保参数6值
            //|个人编号|卡号（无卡人员为空）|账户余额|封锁标志|封锁类型|
            //医疗类别|审批类别|审批编号|疾病编码|疾病名称|项目编码|项目名称|交易流水号(医保登记函数返回)|住院次数|起付线
            string grbh = dt.Rows[0]["Grbh"].ToString();
            string jylsh = dt.Rows[0]["Jylsh"].ToString();
            string xgspbh = dt.Rows[0]["Xgspbh"].ToString();//相关审批编号
            Yjs_in yjs_in = new Yjs_in();
            Yjs_out yjs_out = new Yjs_out();
            yjs_in.Jylbdm = "09";
            yjs_in.Grbh = getEmpInfo_out.Grbh;
            yjs_in.Ddbh = ProgramGlobal.InsurHspCode;
            yjs_in.Jylsh = jylsh;//交易流水号
            yjs_in.Cfjzsj = "";
            yjs_in.Kzfje = "";//卡支付金额
            yjs_in.Qfxzfje = "";//起付线支付金额
            int res = ynsyb.yjs(yjs_in, yjs_out);
            if (res != 0)
            {
                MessageBox.Show("预结算失败:" + yjs_out.ErrorMessage, "错误信息");
                return -1;
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
            getEmpInfo_out.Zfy = zfy;
            getEmpInfo_out.Xj = xj;
            getEmpInfo_out.Tczf = tczf;
            getEmpInfo_out.Zhzf = zh;
            //交易流水号|总费用|统筹|账户|现金|大病理赔|照顾人员补助|公务员补助|解放前工作人员补助|起付线|住院次数|起付线剩余
            //|结算时间|包干标注|包干结余|全自费金额|智能审核疑点信息
            string midsett = lsh + "|" + zfy + "|" + tc + "|" + zh + "|" + xj + "|" + dblp + "|" + zgrybz + "|" + gwybz + "|" + jfqgzrybz
                      + "|" + qfx + "|" + zycs + "|" + qfxsy + "|" + jssj + "|" + bgbz + "|" + bgjy + "|" + qzfje + "|" + znshydxx;
            string sql = "update ihsp_insurinfo set midsettinfo = " + DataTool.addFieldBraces(midsett) + "where ihsp_id =" + DataTool.addFieldBraces(ihsp_id);
            BllMain.Db.Update(sql);
            return 0;
        }
        /// <summary>
        /// 结算
        /// </summary>
        /// <param name="getEmpInfo_out"></param>
        /// <param name="invoiceCode"></param>
        /// <param name="ihspId"></param>
        /// <returns></returns>
        public int settle(GetEmpInfo_out getEmpInfo_out,string invoiceCode,string ihspId)
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
            int res = ynsyb.js(js_in, js_out);
            if (res != 0)
            {
                MessageBox.Show("结算失败:" + js_out.ErrorMessage + "错误信息");
                return -1;
            }

            string jylsh = js_out.Jylsh;
            string zfy = js_out.Zfy;
            string tc = js_out.Tc;
            string zh = js_out.Zh;
            string xj = js_out.Xj;
            string dblp = js_out.Dblp;
            string zgrybz = js_out.Zgrybz;
            string gwybz = js_out.Gwybz;
            string jfqgzrybz = js_out.Jfqgzrybz;
            string qfx = js_out.Qfx;
            string zycs = js_out.Zycs;
            string qfxsy = js_out.Qfxsy;
            string jssj = js_out.Jssj;
            string bgbz = js_out.Bgbz;
            string bgjy = js_out.Bgjy;
            string qzfje = js_out.Qzfje;
            string znshydxx = js_out.Znshydxx;
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
            string sql = "update ihsp_insurinfo set opstat = 'SETT', settinfo =" + DataTool.addFieldBraces(settinfoXml) + "where ihsp_id = " + DataTool.addFieldBraces(ihspId) + ";";
            sql += "update inhospital set insurstat = 'SETT' where id = " + DataTool.addFieldBraces(ihspId)+";";
            res = BllMain.Db.Update(sql);
            if (res != 0)
            {
                MessageBox.Show("插入HIS库失败");
                czjy(getEmpInfo_out.Grbh,getEmpInfo_out.Jylsh,"10");
            }
            return 0;
        }
        /// <summary>
        /// 结算召回
        /// </summary>
        /// <param name="ihspId"></param>
        /// <param name="invoiceCode"></param>
        /// <returns></returns>
        public int retSettle(string ihspId,string invoiceCode)
        {
            DataTable dt = readIhspRegInfo(ihspId);
            if(dt.Rows.Count==0)
            {
                return -1;
            }
            //姓名|性别|身份证号|出身日期|人员类别编码|人员类别名称|单位名称|单位编号|统筹区号|区域编号|职工居民标志|医保参数1名称|医保参数1值|医保参数2名称|医保参数2值|医保参数3名称|医保参数3值|医保参数4名称|医保参数4值|医保参数5名称|医保参数5值|医保参数6名称|医保参数6值
            //|个人编号|卡号（无卡人员为空）|账户余额|封锁标志|封锁类型|
            //医疗类别|审批类别|审批编号|疾病编码|疾病名称|项目编码|项目名称|交易流水号(医保登记函数返回)|住院次数|起付线
            
            string grbh = dt.Rows[0]["Grbh"].ToString();
            string jylsh0 = dt.Rows[0]["Jylsh"].ToString();
            Jszh_in jszh_in = new Jszh_in();
            Jszh_out jszh_out = new Jszh_out();
            jszh_in.Jylbdm = "11";
            jszh_in.Grbh = grbh;//个人编号
            jszh_in.Ddbh = ProgramGlobal.InsurHspCode;
            jszh_in.Jylsh = jylsh0;
            jszh_in.Jbr = ProgramGlobal.Username;
            jszh_in.Fph = invoiceCode;
            int ops = ynsyb.jszh(jszh_in,jszh_out);
            if(ops !=0)
            {
                MessageBox.Show("退结算失败:"+jszh_out.ErrorMessage,"错误信息");
                return -1;
            }
            string jylsh = jszh_out.Jylsh;
            string zfy = jszh_out.Zfy;
            string tc = jszh_out.Tc;
            string zh = jszh_out.Zh;
            string xj = jszh_out.Xj;
            string dblp = jszh_out.Dblp;
            string zgrybz = jszh_out.Zgrybz;
            string gwybz = jszh_out.Gwybz;
            string jfqgzrybz = jszh_out.Jfqgzrybz;
            string qfx = jszh_out.Qfx;
            string zycs = jszh_out.Zycs;
            string qfxsy = jszh_out.Qfxsy;
            return 0;
        }
        /// <summary>
        /// 入院回退/无费退院
        /// </summary>
        /// <returns></returns>
        public int ryht(string ihsp_id)
        {
            DataTable dt = readIhspRegInfo(ihsp_id);
            if(dt.Rows.Count==0)
            {
                MessageBox.Show("无该患者医保信息，请检查！");
                return -1;
            }
            //姓名|性别|身份证号|出身日期|人员类别编码|人员类别名称|单位名称|单位编号|统筹区号|区域编号|职工居民标志|医保参数1名称|医保参数1值|医保参数2名称|医保参数2值|医保参数3名称|医保参数3值|医保参数4名称|医保参数4值|医保参数5名称|医保参数5值|医保参数6名称|医保参数6值
            //|个人编号|卡号（无卡人员为空）|账户余额|封锁标志|封锁类型|
            //医疗类别|审批类别|审批编号|疾病编码|疾病名称|项目编码|项目名称|交易流水号(医保登记函数返回)|住院次数|起付线
            string grbh = dt.Rows[0]["Grbh"].ToString();
            string jylsh = dt.Rows[0]["Jylsh"].ToString();
            Wfty_in wfty_in = new Wfty_in();
            wfty_in.Jylbdm = "16";
            wfty_in.Grbh = grbh;
            wfty_in.Jylsh = jylsh;
            wfty_in.Ddbh = ProgramGlobal.InsurHspCode;
            int ops = ynsyb.wfty(wfty_in);
            if(ops !=0)
            {
                MessageBox.Show("无费退院失败:" + wfty_in.ErrorMessage,"错误信息");
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 未结算处方清除
        /// </summary>
        /// <returns></returns>
        public int deleteRcp(string ihsp_id)
        {
            DataTable dt = readIhspRegInfo(ihsp_id);
            if (dt.Rows.Count == 0)
            {
                return -1;
            }
            //姓名|性别|身份证号|出身日期|人员类别编码|人员类别名称|单位名称|单位编号|统筹区号|区域编号|职工居民标志|医保参数1名称|医保参数1值|医保参数2名称|医保参数2值|医保参数3名称|医保参数3值|医保参数4名称|医保参数4值|医保参数5名称|医保参数5值|医保参数6名称|医保参数6值
            //|个人编号|卡号（无卡人员为空）|账户余额|封锁标志|封锁类型|
            //医疗类别|审批类别|审批编号|疾病编码|疾病名称|项目编码|项目名称|交易流水号(医保登记函数返回)|住院次数|起付线
            string grbh = dt.Rows[0]["Grbh"].ToString();
            string jylsh = dt.Rows[0]["Jylsh"].ToString();
            Wjscfqcjy_in wjscfqcjy_in = new Wjscfqcjy_in();
            wjscfqcjy_in.Jylbdm = "98";
            wjscfqcjy_in.Grbh = grbh;
            wjscfqcjy_in.Jylsh = jylsh;
            wjscfqcjy_in.Yybm = ProgramGlobal.InsurHspCode;
            YNSYB ynsyb = new YNSYB();
            int ops = ynsyb.wjscfqcjy(wjscfqcjy_in);
            if(ops != 0)
            {
                MessageBox.Show("删除费用失败:" + wjscfqcjy_in.ErrorMessage,"错误信息");
                return -1;
            }
            string sql_upd = "update ihsp_costdet set insursync = 'N' where ihsp_id = " + DataTool.addFieldBraces(ihsp_id) + ";";
            sql_upd += "delete from insur_costdet where ihsp_costdet_id in (select id from ihsp_costdet where ihsp_id = "+ DataTool.addFieldBraces(ihsp_id)+")";
            ops = BllMain.Db.Update(sql_upd);
            if(ops != 0)
            {
                czjy(wjscfqcjy_in.Grbh,wjscfqcjy_in.Jylsh,"98"); 
                MessageBox.Show("删除费用失败，请重试！");
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 处方明细退方
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <param name="costdetIds"></param>退方费用明细IDs
        /// <param name="errorItems"></param>退方失败项目名称s
        /// <returns></returns>
        public int deleteRcpdet(string ihsp_id,string costdetIds,ref string errorItems)
        {
            DataTable dt = readIhspRegInfo(ihsp_id);
            if (dt.Rows.Count == 0)
            {
                return -1;
            }
            string sql = "select ihsp_costdet.id,ihsp_costdet.name,ihsp_costdet.num,ihsp_costdet.fee,insur_costdet.insur_costed_id ";
            DataTable dtcostdet = BllMain.Db.Select(sql).Tables[0];
            //姓名|性别|身份证号|出身日期|人员类别编码|人员类别名称|单位名称|单位编号|统筹区号|区域编号|职工居民标志|医保参数1名称|医保参数1值|医保参数2名称|医保参数2值|医保参数3名称|医保参数3值|医保参数4名称|医保参数4值|医保参数5名称|医保参数5值|医保参数6名称|医保参数6值
            //|个人编号|卡号（无卡人员为空）|账户余额|封锁标志|封锁类型|
            //医疗类别|审批类别|审批编号|疾病编码|疾病名称|项目编码|项目名称|交易流水号(医保登记函数返回)|住院次数|起付线
            string grbh = dt.Rows[0]["Grbh"].ToString();
            Cfmxtf_in cfmxtf_in = new Cfmxtf_in();
            cfmxtf_in.Jylbdm = "08";
            cfmxtf_in.Grbh = grbh;
            cfmxtf_in.Ddbh = ProgramGlobal.InsurHspCode;
            int n = 0;
            for(int i=0;i<dtcostdet.Rows.Count;i++)
            {
                cfmxtf_in.Jylsh = dtcostdet.Rows[i]["insur_costed_id"].ToString();
                cfmxtf_in.Tcsl = dtcostdet.Rows[i]["num"].ToString();
                cfmxtf_in.Tcje = dtcostdet.Rows[i]["fee"].ToString();
                Cfmxtf_out cfmxtf_out = new Cfmxtf_out();
                int ops = ynsyb.cfmxtf(cfmxtf_in,cfmxtf_out);
                if (ops != 0)
                {
                    if (n == 0)
                    {
                        errorItems += dtcostdet.Rows[i]["name"].ToString();
                    }
                    else
                    {
                        errorItems += "," + dtcostdet.Rows[i]["name"].ToString();
                    }
                    n++;
                }
                string ihsp_costdet_id = dtcostdet.Rows[i]["id"].ToString();
                string sql_upd = "update ihsp_costdet set insursync = 'N' where id = " + DataTool.addFieldBraces(ihsp_costdet_id) + ";";
                sql_upd += "delete from insur_costdet where ihsp_costdet_id =" + DataTool.addFieldBraces(ihsp_costdet_id)+";";
                ops = BllMain.Db.Update(sql_upd);
                if (ops != 0)
                {
                    czjy(grbh, cfmxtf_in.Jylsh, "08");
                    if (n == 0)
                    {
                        errorItems += dtcostdet.Rows[i]["name"].ToString();
                    }
                    else
                    {
                        errorItems += "," + dtcostdet.Rows[i]["name"].ToString();
                    }
                    n++;
                }
            }
            return 0;
        }
    }
}
