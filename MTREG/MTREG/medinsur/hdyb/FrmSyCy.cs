using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.hdyb.bll;
using MTHIS.main.bll;
using MTREG.ihsp.bll;
using MTREG.ihsp.bo;
using MTHIS.common;
using MTREG.medinsur.gzsyb.listitem;
using MTREG.common;
using MTREG.medinsur.hdyb.dor;
using MTREG.medinsur.gzsyb;
using MTREG.common.bll;
using MTHIS.db;


namespace MTREG.medinsur.hdyb
{
    public partial class FrmSyCy : Form
    {
        public FrmSyCy()
        {
            InitializeComponent();
        }
        YBCJ yw1 = new YBCJ();
        BllMain db = new BllMain();
        JKDB jkdb = new JKDB();
        BillIhspMan billIhspMan = new BillIhspMan();
        BillIhspAct billIhspAct = new BillIhspAct();
        BillCmbList billCmbList = new BillCmbList();
        BillIhspcost billIhspcost = new BillIhspcost();
        BllInsur bllInsur = new BllInsur();
        Ihspaccount ihspaccount = new Ihspaccount();

        private string zyh_;
        /// <summary>
        /// 住院号
        /// </summary>
        public string Zyh_
        {
            get { return zyh_; }
            set { zyh_ = value; }
        }
        private string ihsp_id;
        /// <summary>
        /// 住院记录id
        /// </summary>
        public string Ihsp_id
        {
            get { return ihsp_id; }
            set { ihsp_id = value; }
        }
        private string grbh_;
        /// <summary>
        /// 个人编号
        /// </summary>
        public string Grbh_
        {
            get { return grbh_; }
            set { grbh_ = value; }
        }
        private string jmylzh_;
        /// <summary>
        /// 居民医疗证号
        /// </summary>
        public string Jmylzh_
        {
            get { return jmylzh_; }
            set { jmylzh_ = value; }
        }
        private string account;
        /// <summary>
        /// 医疗付款方式
        /// </summary>
        public string Account
        {
            get { return account; }
            set { account = value; }
        }
        private string ylkfkfs;
        /// <summary>
        /// 医疗付款方式
        /// </summary>
        public string Ylkfkfs
        {
            get { return ylkfkfs; }
            set { ylkfkfs = value; }
        }
        private bool isck = false;
        /// <summary>
        /// 是否持卡
        /// </summary>
        public bool Isck
        {
            get { return isck; }
            set { isck = value; }
        }
        private string member_id = "";
        string invoicecode = "";//发票号
        string nextinvoicesql = "";//发票号sql

        private void FrmSyCy_Load(object sender, EventArgs e)
        {
            initButton();
            inityjk();
            initFklx();
            initCyyy();
            initYllb();
            initTpMge();
            this.yjkzfy.Text = cxyjkzfy(ihsp_id);
            if (Ini.IniReadValue2("pz", "ISXJHB") == "1")
            {
                this.fphtext.Text = "";
                this.fphtext.ReadOnly = false;
            }
            else
            {
                this.fphtext.ReadOnly = true;
                this.fphtext.Text = getNextZyFph();//获取当前发票号
            }
            cxfy();
        }
        /// <summary>
        /// 按钮
        /// </summary>
        public void initButton()
        {
            try
            {
                if (string.IsNullOrEmpty(ihsp_id))
                {
                    return;
                }
                string sql_nhflag = "select nhflag,status from inhospital where id= " + ihsp_id;
                DataTable dt_nhflag = BllMain.Db.Select(sql_nhflag).Tables[0];
                this.lb_hiszt.Text = dt_nhflag.Rows[0]["status"].ToString().Trim();
                this.lb_ybzt.Text = dt_nhflag.Rows[0]["nhflag"].ToString().Trim();
                if (dt_nhflag.Rows.Count == 0)
                {
                    return;
                }
                if (dt_nhflag.Rows[0]["nhflag"].ToString().Trim() == "1501")
                {
                    btn_jscd.Enabled = false;
                    btn_YbChScfy.Enabled = true;
                    btn_jsht.Enabled = false;
                    btn_yjs.Enabled = true;
                    btn_js.Enabled = false;
                    btnXfsj.Enabled = true;
                }
                else if (dt_nhflag.Rows[0]["nhflag"].ToString().Trim() == "1502")
                {
                    btn_jscd.Enabled = true;
                    btn_YbChScfy.Enabled = false;
                    btn_jsht.Enabled = true;
                    btn_yjs.Enabled = false;
                    btn_js.Enabled = false;
                    btnXfsj.Enabled = false;
                }
                else
                {
                    btn_jscd.Enabled = false;
                    btn_YbChScfy.Enabled = false;
                    btn_jsht.Enabled = false;
                    btn_yjs.Enabled = false;
                    btn_js.Enabled = false;
                    btnXfsj.Enabled = false;
                }
            }
            catch
            { }
        }
        //付款类型
        private void initFklx()
        {
            DataTable dtpt = billCmbList.payPaytypeList();
            if (dtpt.Rows.Count > 0)
            {
                this.cbx_fklx.ValueMember = "id";
                this.cbx_fklx.DisplayMember = "name";
                this.cbx_fklx.DataSource = dtpt;
                this.cbx_fklx.SelectedValue = "1";
            }
        }
        /// <summary>
        /// 预交款
        /// </summary>
        public void inityjk()
        {
            DataTable datatable = billIhspAct.payAccount(ihsp_id);
            label19.Text = label19.Text.Trim() + "   " + datatable.Rows.Count;
            dgvjs_yjk.DataSource = datatable;
            double paytotal = 0;
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                paytotal += double.Parse(DataTool.FormatData(datatable.Rows[i]["payfee"].ToString(), "2"));
            }
            this.yjkzfy.Text = DataTool.FormatData(paytotal.ToString(), "2");

        }
        /// <summary>
        /// 出院原因
        /// </summary>
        private void initCyyy()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("康复", "1"));
            items.Add(new ListItem("转院", "2"));
            items.Add(new ListItem("死亡", "3"));
            items.Add(new ListItem("其他", "7"));
            this.comboCyyy.DisplayMember = "Value";
            this.comboCyyy.ValueMember = "Text";
            this.comboCyyy.DataSource = items;
            comboCyyy.SelectedValue = "1";
        }
        /// <summary>
        /// 医疗类别
        /// </summary>
        private void initYllb()
        {
            List<ListItem> items = new List<ListItem>();
            //items.Add(new ListItem("普通住院", "21"));
            //items.Add(new ListItem("转入住院", "25"));
            //items.Add(new ListItem("困难企业住院", "26"));
            //items.Add(new ListItem("年终结算", "28"));
            //items.Add(new ListItem("年终结算后出院", "29"));
            //items.Add(new ListItem("顺产", "51"));
            //items.Add(new ListItem("剖腹产", "55"));

            items.Add(new ListItem("1", "顺产"));
            items.Add(new ListItem("2", "异位妊娠手术"));
            items.Add(new ListItem("3", "剖腹产"));
            items.Add(new ListItem("4", "怀孕2个月流产"));
            items.Add(new ListItem("5", "2个月以上6个月以下引产"));
            this.combocyjssslb.DisplayMember = "Text";
            this.combocyjssslb.ValueMember = "Value";
            this.combocyjssslb.DataSource = items;
        }
        /// <summary>
        /// 初始化界面信息
        /// </summary>
        private void initTpMge()
        {
            string sql = "select * from KC21 where AKC190= '" + zyh_ + "'";
            DataTable dt = jkdb.Select(sql).Tables[0];
            if (dt.Rows.Count == 0)
            {
                return;
            }
            string sql1 = "select inhospital.nhflag,inhospital.member_id,inhospital.sfck,inhospital.outdate as zyjlcysj,inhospital.bas_patienttype_id as zyjlylfkfs,sexList.name as sex from inhospital left join sys_dict as sexList on inhospital.sex=sexList.keyname and sexList.dicttype='bas_sex' and sexList.father_id<>0 where inhospital.id=" + ihsp_id;
            DataTable dt_cysj = BllMain.Db.Select(sql1).Tables[0];
            this.btn_sfck.Text = (dt_cysj.Rows[0]["sfck"].ToString().Trim() == "1") ? ("有卡") : ("无卡");
            this.textBox1.Text = dt_cysj.Rows[0]["sex"].ToString().Trim();
            //this.lbl_ylfkfs.Text = dt_cysj.Rows[0]["zyjlylfkfs"].ToString().Trim();
            //string sql3 = "select inhospital.outdiagn as cyzd,bas_depart.name as ks,bas_doctor.name as ys from inhospital left join bas_doctor on inhospital.doctor_id=bas_doctor.id  left join bas_depart on inhospital.depart_id=bas_depart.id"
            //    + " where inhospital.id=" + DataTool.addFieldBraces(ihsp_id);
            string sql3 = "select ihsp_diagnmes.diagnname as cyzd,bas_depart.name as ks,bas_doctor.name as ys from inhospital left join bas_doctor on inhospital.doctor_id=bas_doctor.id  left join bas_depart on inhospital.depart_id=bas_depart.id"
                + " left join ihsp_diagnmes on ihsp_diagnmes.ihsp_id=inhospital.id and ihsp_diagnmes.diagnKind='OUT' and ihsp_diagnmes.opkind='MAIN'"
                + " where inhospital.id=" + DataTool.addFieldBraces(ihsp_id);
            DataTable dt_cyjbmc = BllMain.Db.Select(sql3).Tables[0];
            string cysj = dt_cysj.Rows[0]["zyjlcysj"].ToString().Trim();
            this.cyjsCyrq.Text = cysj;
            member_id = dt_cysj.Rows[0]["member_id"].ToString();
            this.cyjsZyh.Text = dt.Rows[0]["AKC190"].ToString().Trim();
            this.cyjsXm.Text = dt.Rows[0]["AAC003"].ToString().Trim();
            this.CyjsKs.Text = dt_cyjbmc.Rows[0]["ks"].ToString().Trim();//dt.Rows[0]["zkc272"].ToString().Trim();
            this.cyjsGrbh.Text = dt.Rows[0]["AAC001"].ToString().Trim();
            //医疗证号等同个人编号
            jmylzh_ = dt.Rows[0]["AAC001"].ToString().Trim();
            this.cyjsYs.Text = dt_cyjbmc.Rows[0]["ys"].ToString().Trim();
            this.cyjsRyrq.Text = dt.Rows[0]["AKC192"].ToString().Trim();
            this.cyjsCyjb.Text = dt_cyjbmc.Rows[0]["cyzd"].ToString().Trim(); //dt.Rows[0]["zkc275"].ToString().Trim();
            //this.combocyjssslb.SelectedValue = dt.Rows[0]["AKA130"].ToString().Trim();
            this.cyjsBfh.Text = dt.Rows[0]["Cka040"].ToString().Trim();
            this.tbx_bch.Text = dt.Rows[0]["Cka041"].ToString().Trim();
            string sumFeeSql = "select sum(fee) as sumAmt from ihsp_costdet where  ihsp_costdet.charged in('RREC','RET','CHAR') and ihsp_id= " + ihsp_id;
            DataTable temSum = BllMain.Db.Select(sumFeeSql).Tables[0];
            hisFeeLable.Text = temSum.Rows[0]["sumAmt"].ToString().Trim();//his费用
            ybfy(this.cyjsZyh.Text.Trim());//城乡费用
            this.fymxcount();
            return;
        }
        /// <summary>
        /// 医保费用
        /// </summary>
        /// <param name="zyh"></param>
        private void ybfy(string zyh)
        {
            string sql = "select sum(AKC227) from KC22 where AKC190='" + zyh + "' and  CKC126=1";

            DataTable dt = jkdb.Select(sql).Tables[0];
            string amt = dt.Rows[0][0].ToString().Trim();
            this.labelYb.Text = amt;
        }
        /// <summary>
        /// 上传情况
        /// </summary>
        private void fymxcount()
        {

            string count1 = "select count(id) as zhs from ihsp_costdet where ihsp_id = " + ihsp_id;//_iid.ToString().Trim();
            string count2 = "select count(id) as yschs from ihsp_costdet where insursync = 'Y' and ihsp_id = " + ihsp_id;//+ _iid.ToString().Trim();
            string count3 = "select count(id) as syhs from ihsp_costdet where insursync ='N' and ihsp_id = " + ihsp_id;//_iid.ToString().Trim();


            DataTable dt_count1 = BllMain.Db.Select(count1).Tables[0];
            DataTable dt_count2 = BllMain.Db.Select(count2).Tables[0];
            DataTable dt_count3 = BllMain.Db.Select(count3).Tables[0];
            this.label_zg.Text = dt_count1.Rows[0]["zhs"].ToString().Trim();//总共
            this.label_sc.Text = dt_count2.Rows[0]["yschs"].ToString().Trim();//已上传
            this.label_sy.Text = dt_count3.Rows[0]["syhs"].ToString().Trim();//未上传

            string sql = "select count(*) as ysx_sc from KC22 where AKC190='" + zyh_ + "' and  CKC126=1";
            DataTable dt = jkdb.Select(sql).Tables[0];
            string ysx_sc = dt.Rows[0]["ysx_sc"].ToString().Trim();
            this.label_ysx.Text = ysx_sc;//已生效

        }
        /// <summary>
        /// 预交款总费用
        /// </summary>
        /// <param name="ihs_id"></param>
        /// <returns></returns>
        public String cxyjkzfy(string ihs_id)
        {
            String sql = " select COALESCE( sum(payfee),0) as amt from ihsp_payinadv where ihsp_id='" + ihsp_id + "' ";
            return BllMain.Db.Select(sql).Tables[0].Rows[0]["amt"].ToString().Trim(); //所有预交款
        }
        /// <summary>
        /// 获取发票
        /// </summary>
        /// <returns></returns>
        public String getNextZyFph()
        {

            string invoiceKind = billIhspAct.getInvoiceKind(this.ylkfkfs);
            if (invoiceKind == "")
            {
                return "1222222222222222";
            }
            if (!BillSysBase.currInvoice(ProgramGlobal.User_id.Trim().ToString(), invoiceKind, ref invoicecode, ref nextinvoicesql))
            {
                MessageBox.Show("发票已用完，不能进行收费！");
                return "";
            }
            int invoiceNum = billIhspAct.getInvoiceNum(invoiceKind, ProgramGlobal.User_id.Trim().ToString());
            if (invoiceNum < 10)
            {
                fpsy_label.Text = "当前发票号已不足10张，请尽快领取新的发票！如已领取，请忽略！";
            }
            else if (invoiceNum >= 10)
            {
                fpsy_label.Text = "";
            }
            return invoicecode;
        }
        /// <summary>
        /// 初始化费用
        /// </summary>
        private void cxfy()
        {
            string sql1 = "select inhospital.ihspcode as 住院号,ihsp_costdet.ypspbz as 药品审核,ihsp_costdet.yptsxx AS 药品提示信息,ihsp_costdet.ybxfdhje AS 负担后金额,ihsp_costdet.name as 项目名称,ihsp_costdet.prc as 单价"
                        + ",ihsp_costdet.num AS 数量,ihsp_costdet.fee AS 金额,ihsp_costdet.itemfrom AS 项目类别,ihsp_costdet.yblx AS 费用等级"
                        + ",(select hiscode from bas_item where ihsp_costdet.item_id=bas_item.id) as 医保编码,ihsp_costdet.ihsp_advdet_id AS 处方号"
                        + ",ihsp_costdet.costexdate AS 创建日期,ihsp_costdet.costexdate AS 开方日期, ihsp_costdet.insursync AS 是否上传"
                        + ",ihsp_costdet.item_id as prodiid,ihsp_costdet.id from ihsp_costdet,inhospital where inhospital.id=ihsp_costdet.ihsp_id and ihsp_costdet.charged in ('RET','RREC','CHAR') and inhospital.id=" + ihsp_id + " order by yptsxx desc";
            DataTable dtTmp = BllMain.Db.Select(sql1).Tables[0];
            if (dtTmp.Rows.Count == 0)
            {
                return;
            }
            this.dataGridView2.DataSource = dtTmp.DefaultView;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {

                if (dataGridView2.Rows[i].Cells["是否上传"].Value.ToString() == "N" || dataGridView2.Rows[i].Cells["是否上传"].Value.ToString() == "")
                    dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;//未上传黄色
                if ((dataGridView2.Rows[i].Cells["医保编码"].Value.ToString() == "") || (dataGridView2.Rows[i].Cells["医保编码"].Value.ToString() == "0"))
                    dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Red;//无编码红色
                if ((dataGridView2.Rows[i].Cells["药品提示信息"].Value.ToString() != "") && (!((dataGridView2.Rows[i].Cells["药品审核"].Value.ToString() == "1") || (dataGridView2.Rows[i].Cells["药品审核"].Value.ToString() == "2"))))
                    dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Cyan;//限制性青色
            }
        }

        private void btn_jscd_Click(object sender, EventArgs e)
        {
            lblFeeUpLoad.Text = "";
            this.dyfp(this.cyjsGrbh.Text.Trim(), this.cyjsZyh.Text.Trim(), ihsp_id);
        }
        public void dyfp(string strGrbh, string strZyh, string strZyjlid)
        {
            if (string.IsNullOrEmpty(strGrbh) || string.IsNullOrEmpty(strZyh) || string.IsNullOrEmpty(strZyjlid))
            {
                MessageBox.Show("发票参数获取失败!");
                return;
            }

            //结算打印
            YBCJ_IN yw_in_zyjsddy = new YBCJ_IN();
            yw_in_zyjsddy.Yw = "BB510002";
            yw_in_zyjsddy.Ybcjbz = "0";
            string sql_gxsfck = "select yllb,sfck,nhflag from inhospital where id='" + strZyjlid + "'";
            DataSet ds_sfck = BllMain.Db.Select(sql_gxsfck);
            if (ds_sfck.Tables[0].Rows[0]["nhflag"].ToString() != "1502")
            {
                MessageBox.Show("医保职工未结算，不可以打印发票！", "提示信息");
                return;
            }
            if (ds_sfck.Tables[0].Rows[0]["sfck"].ToString().Trim() == "1")
            {
                yw_in_zyjsddy.Ylzh = "0";
            }
            else
            {
                yw_in_zyjsddy.Ylzh = strGrbh;
            }
            string sql_cxybfph = "select fph,jssj,yyzfy from zlsyb_zyinfo where mzzyjliid=" + strZyjlid + ";";
            DataSet ds_ybfph = BllMain.Db.Select(sql_cxybfph);
            if (ds_ybfph.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("没有在‘zlsyb_zyinfo’表里找到此人结算信息！", "提示信息");
                return;
            }
            yw_in_zyjsddy.Hisjl = strZyh;
            //个人编号|门诊住院号|经办人
            yw_in_zyjsddy.Rc = strGrbh + "|" + strZyh + "|" + ProgramGlobal.Username;
            int opt_zyjsddy = yw1.ybcjhs(yw_in_zyjsddy);
            if (opt_zyjsddy != 0)
            {
                MessageBox.Show(yw_in_zyjsddy.Mesg, "提示信息");
                return;
            }
            string sql_insert_zyjsdy = "update zlsyb_zyinfo set zyjsdyzfc='" + yw_in_zyjsddy.Cc + "' where mzzyjliid='" + strZyjlid + "'";
            BllMain.Db.Update(sql_insert_zyjsdy);
            string[] zyjsddy_cc = yw_in_zyjsddy.Cc.Split('|');

            #region
            #region
            double cwf = 0;//床位费 
            double zcf = 0;//诊察费
            double jcf = 0;//检查费
            double hyf = 0;//化验费
            double zlf = 0;//治疗费
            double ssf = 0;//手术费
            double hlf = 0;//护理费
            double wsclf = 0;//卫生材料费
            double ypf = 0; //药品费
            double ysfwf = 0;//药事服务费
            double ybzlf = 0;//一般诊疗费
            double sxf = 0;//输血费
            double qtzyfy = 0;//其他住院收费

            DataTable datafpdy =zydyfp(strZyjlid);
            double hj = 0;
            for (int i = 0; i < datafpdy.Rows.Count; i++)
            {
                hj += DataTool.Getdouble(datafpdy.Rows[i]["Amt"].ToString().Trim());
                if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("床位费"))
                {
                    cwf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//床位费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("诊察费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("诊查费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("会诊"))
                {
                    zcf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//诊察费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("治疗费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("物理治疗") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("中医治疗") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("中医康复"))
                {
                    zlf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//治疗费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("护理费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("监护费"))
                {
                    hlf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//护理费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("手术费"))
                {
                    ssf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//手术费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("化验费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("免疫") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("病理") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("心肌酶"))
                {
                    hyf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//化验费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("卫生材料费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("材料费"))
                {
                    wsclf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//卫生材料费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("药品费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("西药费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("成药费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("草药费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("西药") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("中成药") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("中草药"))
                {
                    ypf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//药品费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("药事服务费"))
                {
                    ysfwf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//药事服务费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("一般诊疗费"))
                {
                    ybzlf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//一般诊疗费
                    continue;
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("检查费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("喉镜") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("放射费") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("CT") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("胃镜") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("核磁") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("多普勒") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("内窥镜") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("心电") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("彩超") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("脑彩超") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("脑地形图") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("A超") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("X光") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("镜检") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("喉镜") || datafpdy.Rows[i]["Xmlb"].ToString().Equals("核医学费"))
                {
                    if (!datafpdy.Rows[i]["Amt"].ToString().Equals(""))
                    {
                        jcf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//检查费
                        continue;
                    }
                }
                else if (datafpdy.Rows[i]["Xmlb"].ToString().Equals("输血费"))
                {
                    sxf += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//输血费
                    continue;
                }
                else
                {
                    qtzyfy += double.Parse(datafpdy.Rows[i]["Amt"].ToString());//其他住院收费
                    continue;
                }
            }

            DataTable Dygrxx = GetDygrxx(strZyjlid);
            hj = Math.Round(hj, 2);
            if (hj != DataTool.Getdouble(Dygrxx.Rows[0]["amt"].ToString()))
            {
                MessageBox.Show("项目类型之和【" + hj.ToString() + "】与病人费用总和【" + Dygrxx.Rows[0]["amt"].ToString() + "】不等！");
            }
            #endregion
            string in_zfc1 = "|";
            in_zfc1 += zyjsddy_cc[3] + "|";//定点医院名称
            in_zfc1 += "|";
            in_zfc1 += zyjsddy_cc[4] + "|";//科室
            in_zfc1 += zyjsddy_cc[2] + "|";//单据号
            in_zfc1 += zyjsddy_cc[1] + "|";//医院住院号
            in_zfc1 += zyjsddy_cc[8].Substring(0, 4) + "|" + zyjsddy_cc[8].Substring(4, 2) + "|" + zyjsddy_cc[8].Substring(6, 2) + "|";//入院日期
            in_zfc1 += zyjsddy_cc[9].Substring(0, 4) + "|" + zyjsddy_cc[9].Substring(4, 2) + "|" + zyjsddy_cc[9].Substring(6, 2) + "|";//出院日期
            in_zfc1 += zyjsddy_cc[10] + "|";//住院天数
            in_zfc1 += zyjsddy_cc[6] + "|";//患者姓名
            in_zfc1 += Dygrxx.Rows[0]["xb"].ToString().Trim() + "|";//患者性别
            in_zfc1 += "生育职工医保|";
            in_zfc1 += zyjsddy_cc[11] + "|";//个人编号
            in_zfc1 += "床位费|" + cwf.ToString("0.00") + "|医保|护理费|" + hlf.ToString("0.00") + "|医保|诊查费|" + zcf.ToString("0.00") + "|医保|";
            in_zfc1 += "卫生材料费|" + wsclf.ToString("0.00") + "|医保|检查费|" + jcf.ToString("0.00") + "|医保|药品费|" + ypf.ToString("0.00") + "|医保|";
            in_zfc1 += "化验费|" + hyf.ToString("0.00") + "|医保|药事服务费|" + ysfwf.ToString("0.00") + "|医保|治疗费|" + zlf.ToString("0.00") + "|医保|";
            in_zfc1 += "一般诊疗费|" + ybzlf.ToString("0.00") + "|医保|手术费|" + ssf.ToString("0.00") + "|医保|其他住院费用|" + qtzyfy.ToString("0.00") + "|医保|输血费|" + sxf.ToString("0.00") + "|医保|";
            money n = new money(DataTool.Getdouble(ds_ybfph.Tables[0].Rows[0]["yyzfy"].ToString().Trim()));//费用合计-大写
            in_zfc1 += n.Convert() + "|";//合计大写
            in_zfc1 += DataTool.Getdouble(ds_ybfph.Tables[0].Rows[0]["yyzfy"].ToString().Trim()).ToString("0.00") + "|";//合计

            string sql_amt = "";
            //if (Global.IniReadValue("BXFS", "isxjhb") == "1")
            //{
            //    sql_amt = "select sum(mtprecharge.amt) from mtprecharge where mtprecharge.mtzyjl='" + strZyjlid + "'";
            //}
            //else
            //{
            ///sql_amt = "select sum(mtprecharge.amt) from mtprecharge where mtprecharge.mtzyjl='" + strZyjlid + "' and mtprecharge.mtylfkfs in(select mtylfkfs.iid from mtylfkfs where mtylfkfs.tp=2) and mtprecharge.tp=0";
            //}
            sql_amt = "select COALESCE( sum(payfee),0) as sum from ihsp_payinadv where ihsp_id='" + ihsp_id + "'";
            DataTable dt_amt = BllMain.Db.Select(sql_amt).Tables[0];
            double amt_yj = 0;
            double amt_bj = 0;
            double amt_tf = 0;
            if (dt_amt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dt_amt.Rows[0]["sum"].ToString().Trim()))
                {
                    amt_yj = DataTool.Getdouble(dt_amt.Rows[0]["sum"].ToString());
                    in_zfc1 += amt_yj.ToString("0.00") + "|";//预缴金额
                }
                else
                {
                    in_zfc1 += "0|";//预缴金额
                }
            }
            else
            {
                in_zfc1 += "0|";//预缴金额
            }
            amt_tf = amt_yj - DataTool.Getdouble(zyjsddy_cc[17]);
            if (amt_tf < 0)
            {
                amt_bj = -amt_tf;
                amt_tf = 0;
            }
            in_zfc1 += amt_bj.ToString("0.00") + "|";//补缴金额
            in_zfc1 += amt_tf.ToString("0.00") + "|";//退费金额
            in_zfc1 += (DataTool.Getdouble(ds_ybfph.Tables[0].Rows[0]["yyzfy"].ToString().Trim()) - DataTool.Getdouble(zyjsddy_cc[17])).ToString() + "|";//医院垫支----（医院总费用-现金支付金额）
            in_zfc1 += "|";//医保统筹支付
            in_zfc1 += "|";//个人账户支付
            in_zfc1 += "|";//个人自付
            in_zfc1 += "|";//个人自费
            in_zfc1 += "|";//个人账户余额
            in_zfc1 += "|";//统筹累计支付
            in_zfc1 += "生育医疗费定额补偿金额:" + zyjsddy_cc[16] + "|";
            in_zfc1 += "个人现金支付:" + zyjsddy_cc[17] + "|";
            in_zfc1 += "医保中心名称:" + zyjsddy_cc[0] + "|";
            in_zfc1 += zyjsddy_cc[18] + "|";//经办人
            in_zfc1 += zyjsddy_cc[19].Substring(0, 4) + "|" + zyjsddy_cc[19].Substring(4, 2) + "|" + zyjsddy_cc[19].Substring(6, 2) + "|"; ;//结算日期
            FrmDy cxjsddy = new FrmDy();
            cxjsddy.in_zfc = in_zfc1;
            cxjsddy.dy("zysyyb");
            #endregion
            MessageBox.Show("打印发票成功！", "提示信息");
        }
        public DataTable zydyfp(String mtzyjl_iid)
        {
            //String sql = "select insur_itemfrom.name as xmlb,sum(fee) as amt from insur_itemfrom,ihsp_costdet where ihsp_costdet.ihsp_id=" + mtzyjl_iid + " and ihsp_costdet.itemtype_id=insur_itemfrom.itemtype_id  GROUP BY xmlb ";
            String sql = " select insur_itemfrom.name as xmlb,sum(fee ) as amt"
                       + " from ihsp_costdet left join insur_itemfrom on insur_itemfrom.itemtype_id = ihsp_costdet.itemtype_id AND insur_itemfrom.cost_insurtype_id = 6 "
                       + " where  ihsp_costdet.ihsp_id =" + DataTool.addFieldBraces(mtzyjl_iid) + " GROUP BY xmlb";
            return BllMain.Db.Select(sql).Tables[0];
        }
        public DataTable GetDygrxx(String mtzyjl_iid)
        {
            String sql = "select (case sex when 'M' then '男' when 'W' then '女' when 'U' then '' end) as xb,feeamt as amt from inhospital where id=" + mtzyjl_iid;
            return BllMain.Db.Select(sql).Tables[0];
        }

        private void btn_YbChScfy_Click(object sender, EventArgs e)
        {
            lblFeeUpLoad.Text = "";
            //删除费用
            string zyhTmp = this.cyjsZyh.Text.Trim();
            string xm = this.cyjsXm.Text.Trim();
            if (zyhTmp == null || zyhTmp == "")
            {
                MessageBox.Show("没有选中患者，不允许删除费用", "提示信息");
                return;
            }
            if (this.combocyjssslb.SelectedValue.ToString() == "28" || this.combocyjssslb.SelectedValue.ToString() == "29")
            {
                string mes1 = "是年终结算或年终结算后出院，确定删除费用？";
                if (MessageBox.Show(mes1, "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return;
                }
            }
            string mes = "确定删除[住院号:" + zyhTmp + ",姓名:" + xm + "]的费用吗?";
            if (MessageBox.Show(mes, "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            YBCJ_IN yw_in_scfy = new YBCJ_IN();
            yw_in_scfy.Yw = "BB310000";
            yw_in_scfy.Ybcjbz = "0";
            string sql_gxsfck = "select sfck,nhflag from inhospital where id='" + ihsp_id + "'";
            DataSet ds_sfck = BllMain.Db.Select(sql_gxsfck);
            if (ds_sfck.Tables[0].Rows[0]["sfck"].ToString() == "1")
            {
                yw_in_scfy.Ylzh = "0";
            }
            else
            {
                yw_in_scfy.Ylzh = this.cyjsGrbh.Text.Trim();
            }
            yw_in_scfy.Hisjl = zyhTmp;
            yw_in_scfy.Rc = zyhTmp + "|" + zyhTmp;

            int opt_scfy = yw1.ybcjhs(yw_in_scfy);
            if (opt_scfy != 0)
            {
                MessageBox.Show(yw_in_scfy.Mesg, "提示信息");
                return;
            }

            //删除kc22数据
            this.del_kc22_zyh(zyhTmp);
            string sql_scfy = "update  ihsp_costdet set insursync='N',ybxfdhje=0,ybxfdhjebz=0,dqdzxx='',yptsxx='',yblx='',ypspbz=0  where ihsp_id=" + ihsp_id;
            BllMain.Db.Update(sql_scfy);
            cxfy();
            this.fymxcount();
            this.ybfy(this.cyjsZyh.Text.Trim());
            MessageBox.Show("删除费用成功！");
        }
        private void del_kc22_zyh(string zyh)
        {
            string sql = "delete from KC22 where AKC190='" + zyh + "'";

            int ac = jkdb.Update(sql);
            int ab = ac;
        }

        private void btn_jsht_Click(object sender, EventArgs e)
        {
            MTHIS.FrmMain fm = new MTHIS.FrmMain();
            if (fm.ybsyqx() != true)
            {
                return;
            }
            lblFeeUpLoad.Text = "";
            string zyhTmp = this.cyjsZyh.Text.Trim();//住院号
            string yllbTmp = this.combocyjssslb.SelectedValue.ToString().Trim();//医疗类别
            string zyjlId = ihsp_id;//住院记录id
            string grbhTmp = this.cyjsGrbh.Text.Trim();//个人编号
            string mes = "确定结算回退[住院号:" + zyhTmp + ",姓名:" + this.cyjsXm.Text + "]吗?";
            if (MessageBox.Show(mes, "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            js_ht(zyhTmp, yllbTmp, zyjlId, grbhTmp);
        }
        public void js_ht(string strZyh, string strYllb, string strZyjlId, string strGrbh)
        {
            if (string.IsNullOrEmpty(strZyh) || string.IsNullOrEmpty(strYllb) || string.IsNullOrEmpty(strZyjlId) || string.IsNullOrEmpty(strGrbh))
            {
                MessageBox.Show("获取结算回退参数失败!!!");
                return;
            }
            string sql1 = "select ihsp_account.id from ihsp_account,inhospital where  ihsp_account.ihsp_id = inhospital.id and inhospital.id=" + strZyjlId;
            string account_id = BllMain.Db.Select(sql1).Tables[0].ToString();
            DataTable dataTable = billIhspAct.retAccountSearch(account_id);
            if (dataTable.Rows.Count > 0)
            {
                DataTable dt = billIhspcost.ihspIdSearch(ihsp_id);
                string ihspcode = dt.Rows[0]["ihspcode"].ToString();
                string unlocked = dt.Rows[0]["unlocked"].ToString();
                string datetime = Convert.ToDateTime(dataTable.Rows[0]["chargedate"]).ToString("yyyy-MM-dd");

                if (datetime == Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") || unlocked == "Y" || 1 == 1)
                { }
                else
                {
                    MessageBox.Show("不是当天结算,请进行回退申请");
                    return;
                }
            }
            //读人员基本信息和帐户信息
            YBCJ_IN yw_in_ryjbxxhzh = new YBCJ_IN();
            yw_in_ryjbxxhzh.Yw = "AA311012";
            yw_in_ryjbxxhzh.Ybcjbz = "0";
            string sql_gxsfck = "select sfck,nhflag from inhospital where id='" + strZyjlId + "'";
            DataSet ds_sfck = BllMain.Db.Select(sql_gxsfck);
            if (ds_sfck.Tables[0].Rows[0]["sfck"].ToString() == "1")
            {
                yw_in_ryjbxxhzh.Ylzh = "0";
            }
            else
            {
                yw_in_ryjbxxhzh.Ylzh = strGrbh;
            }
            yw_in_ryjbxxhzh.Hisjl = strZyh;
            yw_in_ryjbxxhzh.Rc = "";
            int opt_ryjbxxhzh = yw1.ybcjhs(yw_in_ryjbxxhzh);
            if (opt_ryjbxxhzh != 0)
            {
                MessageBox.Show(yw_in_ryjbxxhzh.Mesg, "提示信息");
                return;
            }
            string[] ryjbxxhzh_cc = yw_in_ryjbxxhzh.Cc.Split('|');
            if (ryjbxxhzh_cc[17] == "住院未结算" || ryjbxxhzh_cc[17] == "中途结算")
            {
                MessageBox.Show("此人目前为住院状态，不能进行结算回退操作！", "提示信息");
                return;
            }
            string djh = "";
            //查询KC22的AAE072 单据号
            if ("29" == strYllb)
            {
                string newdjh = "select fph from zlsyb_zyinfo where mzzyjliid=" + strZyjlId;
                DataTable dd = BllMain.Db.Select(newdjh).Tables[0];
                djh = dd.Rows[0]["fph"].ToString().Trim();

            }
            else
            {
                string sql_djh = "select AAE072 from KC22 where AKC190='" + strZyh + "'";
                DataTable dt = jkdb.Select(sql_djh).Tables[0];
                djh = dt.Rows[0]["AAE072"].ToString().Trim();
            }
            //结算回退
            YBCJ_IN yw_in_zyjsht = new YBCJ_IN();
            yw_in_zyjsht.Yw = "DC511002";
            yw_in_zyjsht.Ybcjbz = "0";
            if (ds_sfck.Tables[0].Rows[0]["sfck"].ToString() == "1")
            {
                yw_in_zyjsht.Ylzh = "0";
            }
            else
            {
                yw_in_zyjsht.Ylzh = strGrbh;
            }
            yw_in_zyjsht.Hisjl = strZyh;
            yw_in_zyjsht.Rc = strGrbh + "|" + strZyh + "|" + ProgramGlobal.Username;
            int opt_zyjsht = yw1.ybcjhs(yw_in_zyjsht);
            if (opt_zyjsht != 0)
            {
                MessageBox.Show(yw_in_zyjsht.Mesg, "提示信息");
                return;
            }
            //修改kc22传输标志，置为0
            this.upcsbz_Kc22_JK0(strZyh);
            string sql2 = "";
            if (strYllb == "29")
            {
                sql2 += "UPDATE KC21 set AKA130= '28'  where  AKC190 = '" + strZyh + "' and AKA130='29'";
                jkdb.Update(sql2);
                string sql23 = "delete from kc22 where AKC190='" + strZyh + "';";
                jkdb.Update(sql23);
                string his_sql_update_ht = "update  ihsp_costdet set insursync='N',ybxfdhje=0,ybxfdhjebz=0,dqdzxx='',yptsxx='',yblx='',ypspbz=0  where ihsp_id=" + strZyjlId;
                BllMain.Db.Update(his_sql_update_ht);
                //修改his医保标志
                string sql = "update inhospital set nhflag=1501,yllb = '28',settInsurdate=null where id=" + strZyjlId;//_iid.ToString().Trim();
                BllMain.Db.Update(sql);
            }
            else
            {
                sql2 = "delete from kc22 where AKC190='" + strZyh + "'";
                jkdb.Update(sql2);
                string his_sql_update_ht = "update  ihsp_costdet set insursync='N',ybxfdhje=0,ybxfdhjebz=0,dqdzxx='',yptsxx='',yblx='',ypspbz=0 where ihsp_id=" + strZyjlId;//
                BllMain.Db.Update(his_sql_update_ht);
                string sql = "update inhospital set nhflag=1501,settInsurdate=null where id=" + strZyjlId;//_iid.ToString().Trim();
                BllMain.Db.Update(sql);
            }
            if (Ini.IniReadValue2("pz", "ISXJHB") == "0")
            {
                if (!retAccount(strZyjlId))
                {
                    MessageBox.Show("his撤销失败");
                    return;
                }
            }
            else
            {
                string sql_upaccount = "UPDATE ihsp_account SET insurefee = 0 insuraccountfee = 0  WHERE ihsp_id = " + strZyjlId;
                BllMain.Db.Update(sql_upaccount);
            }
            initButton();
            MessageBox.Show("结算回退成功！", "提示信息");
            return;
        }
        private bool retAccount(string ihsp_id)
        {
            //string sql = "select ihsp_account.id,ihsp_invoicedet.bas_paytype_id from ihsp_account,ihsp_invoicedet,inhospital where  ihsp_invoicedet.ihsp_account_id=ihsp_account.id and ihsp_account.ihsp_id = inhospital.id and inhospital.id=" + ihsp_id;
            //DataTable d1t = BllMain.Db.Select(sql).Tables[0];
            string sqll = "select ihsp_account_id from ihsp_costdet where ihsp_id=" + ihsp_id;
            DataTable d2t = BllMain.Db.Select(sqll).Tables[0];
            string account_id = d2t.Rows[0]["ihsp_account_id"].ToString();
            string sql = "select bas_paytype_id from ihsp_invoicedet where  ihsp_account_id=" + account_id;
            DataTable d1t = BllMain.Db.Select(sql).Tables[0];


            DataTable dataTable = billIhspAct.retAccountSearch(account_id);
            if (dataTable.Rows.Count > 0)
            {
                string ihspaccountId = dataTable.Rows[0]["id"].ToString();
                string sourceHisOrderNo = dataTable.Rows[0]["hisOrderNo"].ToString();
                DataTable dt = billIhspcost.ihspIdSearch(ihsp_id);
                string ihspcode = dt.Rows[0]["ihspcode"].ToString();
                string unlocked = dt.Rows[0]["unlocked"].ToString();
                string datetime = Convert.ToDateTime(dataTable.Rows[0]["chargedate"]).ToString("yyyy-MM-dd");

                if (datetime == Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") || unlocked == "Y" || 1 == 1)
                {

                    //网络支付退费
                    //string currDate = BillSysBase.currDate();
                    //string hisRefundNo = "";
                    //if (!doexecNetPayTradeRefund(currDate, ref hisRefundNo))
                    //{
                    //    return false;
                    //}

                    //网络支付退费_END
                    string paytypeId = d1t.Rows[0]["bas_paytype_id"].ToString();//从界面获取实收金额的paytype
                    if (billIhspAct.cancleAccount(ihspaccountId, paytypeId) < 0)
                    {

                        return false;
                    }


                    return true;
                }
                else
                {
                    MessageBox.Show("不是当天结算,请进行回退申请");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("没有可退结算记录!");
                return false;
            }
        }
        private void upcsbz_Kc22_JK0(string zyh)//修改kc22传输标志，置为0
        {

            string sql = "UPDATE KC22 SET CKC126 =0 WHERE AKC190 ='" + zyh + "'";


            int r = jkdb.Update(sql);
            if (-1 == r)
            {
                MessageBox.Show("数据库更新错误");
                return;
            }
        }

        private void btn_yjs_Click(object sender, EventArgs e)
        {
            int _iid = int.Parse(ihsp_id);
            if (_iid == 0)
            {
                return;
            }
            //if (Tool.IsUpload == true)
            //{
            //    string sqlfyxx = "select id from ihsp_costdet where insursync ='N' and ihsp_id = " + ihsp_id;

            //    DataTable dtxx = BllMain.Db.Select(sqlfyxx).Tables[0];
            //    if (dtxx.Rows.Count > 0)
            //    {
            //        MessageBox.Show("后台正在自动上传费用,稍后再预结算！", "提示信息");
            //        return;
            //    }
            //}
            if (int.Parse(label_ysx.Text) < 1)
            {
                MessageBox.Show("请先上传费用！");
                return;
            }
            lblFeeUpLoad.Text = "正在预结算..........";
            lblFeeUpLoad.Update();
            string zyh = this.cyjsZyh.Text;
            string sslb = this.combocyjssslb.SelectedValue.ToString().Trim();
            string grbh = this.cyjsGrbh.Text;
            //出院登记
            if (cydj() != 1)
            {
                lblFeeUpLoad.Text = "更新kc21失败！！";
                return;
            }
            //读人员基本信息和帐户信息
            YBCJ_IN yw_in_ryjbxxhzh = new YBCJ_IN();
            yw_in_ryjbxxhzh.Yw = "AA311012";
            yw_in_ryjbxxhzh.Ybcjbz = "0";
            string sql_gxsfck = "select status,nhflag,sfck from inhospital where id='" + ihsp_id + "'";
            DataSet ds_sfck = BllMain.Db.Select(sql_gxsfck);
            if (ds_sfck.Tables[0].Rows[0]["sfck"].ToString() == "1")
            {
                yw_in_ryjbxxhzh.Ylzh = "0";
            }
            else
            {
                yw_in_ryjbxxhzh.Ylzh = this.cyjsGrbh.Text.Trim();
            }
            yw_in_ryjbxxhzh.Hisjl = zyh;
            yw_in_ryjbxxhzh.Rc = "";
            int opt_ryjbxxhzh = yw1.ybcjhs(yw_in_ryjbxxhzh);
            if (opt_ryjbxxhzh != 0)
            {
                lblFeeUpLoad.Text = "";
                MessageBox.Show(yw_in_ryjbxxhzh.Mesg, "提示信息");
                return;
            }
            string[] ryjbxxhzh_cc = yw_in_ryjbxxhzh.Cc.Split('|');
            if (ryjbxxhzh_cc[17] == "出院已结算")
            {
                lblFeeUpLoad.Text = "";
                MessageBox.Show("此人目前为出院状态，不能再做出院结算操作！", "提示信息");
                return;
            }

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
            this.cyjsZhye.Text = (lnjz + bnzr - zhzc).ToString().Trim();
            //读封锁信息
            YBCJ_IN yw_in_ryfsxx = new YBCJ_IN();
            yw_in_ryfsxx.Yw = "AB51KC08";
            yw_in_ryfsxx.Ybcjbz = "0";
            yw_in_ryfsxx.Ylzh = yw_in_ryjbxxhzh.Ylzh;
            yw_in_ryfsxx.Hisjl = zyh;
            yw_in_ryfsxx.Rc = grbh;
            int opt_ryfsxx = yw1.ybcjhs(yw_in_ryfsxx);
            if (opt_ryfsxx != 0)
            {
                MessageBox.Show(yw_in_ryfsxx.Mesg, "提示信息");
                return;
            }
            string[] ryfsxx_cc = yw_in_ryfsxx.Cc.Split('|');
            int fsjb = int.Parse(ryfsxx_cc[4]);
            if (fsjb == 1)
            {
                if (MessageBox.Show("此卡处于半封锁状态，应由统筹支付的医疗费用需由个人现金支付!", "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    lblFeeUpLoad.Text = "此卡处于半封锁状态";
                    return;
                }
            }
            if (fsjb == 2)
            {
                lblFeeUpLoad.Text = "此卡已经被封锁";
                MessageBox.Show("此卡已经被封锁，不能再用此卡看病！", "提示信息");
                return;
            }
            YBCJ_IN yw_in_zyjs = new YBCJ_IN();
            yw_in_zyjs.Yw = "BC510001";
            yw_in_zyjs.Ybcjbz = "0";
            yw_in_zyjs.Ylzh = yw_in_ryjbxxhzh.Ylzh;
            yw_in_zyjs.Hisjl = this.cyjsZyh.Text.Trim();
            //个人编号|门诊住院号|手术类别|医疗费总额|胎儿数 |经办人
            yw_in_zyjs.Rc = this.cyjsGrbh.Text.Trim() + "|" + zyh + "|" + sslb + "|" + this.hisFeeLable.Text.Trim() + "|" + this.tbx_tes.Text.Trim() + "|" + ProgramGlobal.Username;
            int opt_zyyjs = yw1.ybcjhs(yw_in_zyjs);
            if (opt_zyyjs != 0)
            {
                lblFeeUpLoad.Text = "预结算失败";
                MessageBox.Show(yw_in_zyjs.Mesg + "预结算失败", "提示信息");
                return;
            }
            string[] zyjs_cc = yw_in_zyjs.Cc.Split('|');
            this.cyjsFyzje.Text = zyjs_cc[0]; //医疗费总额
            this.cyjsYlfdebtxe.Text = zyjs_cc[1]; //生育医疗费定额补贴限额
            this.cyjsgrzf.Text = zyjs_cc[2]; //个人自费
            this.cyjsZhzf.Text = "0";
            this.tbx_ylfdebtje.Text = zyjs_cc[3]; //生育医疗费定额补贴金额

            this.fymxcount();
            this.ybfy(zyh);
            MessageBox.Show("预结算成功，返回帐户支付金额，下一步请点结算按钮！");
            //this.btn_js.Enabled = true;
            //-判断自费是否结算，如果未结算，不允许医保结算
            if (billIhspAct.isHisAccount(ihsp_id))
            {
                this.btn_js.Enabled = true;
            }
            else
            {
                this.btn_js.Enabled = false;
                MessageBox.Show("该病人自费未结算，不能医保结算");
            }

            this.cyjsXjsjzf.Text = this.cyjsgrzf.Text.Trim();
            String bcxjyzf = this.cyjsXjsjzf.Text;
            if (bcxjyzf != null && bcxjyzf != "")
            {
                if (this.yjkzfy.Text.Trim() == "" || this.yjkzfy.Text.Trim() == null)
                {
                    this.tbx_thbxj.Text = (0 - double.Parse(this.cyjsXjsjzf.Text)).ToString().Trim();
                }
                else
                {
                    this.tbx_thbxj.Text = (double.Parse(this.yjkzfy.Text) - double.Parse(this.cyjsXjsjzf.Text)).ToString().Trim();
                }
            }
            cxfy();
            lblFeeUpLoad.Text = "预结算成功";
        }
        private int cydj()
        {
            //修改kc21
            string zyh = this.cyjsZyh.Text;
            string cyrq = this.cyjsCyrq.Text;
            string cyyy1 = this.comboCyyy.Text;
            if (string.IsNullOrEmpty(this.cyjsCyjb.Text.Trim()))
            {
                lblFeeUpLoad.Text = "";
                MessageBox.Show("请注意：出院疾病不能为空！");
                return 0;
            }
            if (cyyy1 == null || cyyy1 == "")
            {
                MessageBox.Show("出院原因不能为空！", "提示信息");
                this.comboCyyy.Focus();
                return 0;
            }
            string cyyy = this.comboCyyy.SelectedValue.ToString().Trim();
            string cyjb = this.cyjsCyjb.Text;
            string ys = this.cyjsYs.Text;
            string ks = this.CyjsKs.Text;

            if (cyrq == null || cyrq == "")
            {
                MessageBox.Show("出院日期不能为空，请输入出院日期，格式为'yyyy-MM-dd'!", "提示信息");
                this.cyjsCyrq.Focus();
                return 0;
            }
            if (cyjb.Length > 7)
            {
                cyjb = cyjb.Substring(0, 7);
            }

            string sql = "update KC21 set AKC194='" + cyrq + "', AKC195='" + cyyy + "',AKC196='" + cyjb + "',zkc271='" + ys + "',zkc272='" + ks + "' where AKC190='" + zyh + "'";
            if (jkdb.Update(sql) == -1)
            {
                return -1;
            }
            return 1;
        }

        private void btn_js_Click(object sender, EventArgs e)
        {
            MTHIS.FrmMain fm = new MTHIS.FrmMain();
            if (fm.ybsyqx() != true)
            {
                return;
            }
            //住院结算
            //发票号
            lblFeeUpLoad.Text = "";
            if (string.IsNullOrEmpty(this.cyjsCyrq.Text.Trim()))
            {
                MessageBox.Show("没有出院时间！");
                return;
            }
            string sslb = this.combocyjssslb.SelectedValue.ToString().Trim();
            double ybFee = Convert.ToDouble(cyjsFyzje.Text.Trim());
            double hisFee = Convert.ToDouble(hisFeeLable.Text.Trim());
            double chaZhi = hisFee - ybFee;
            //if ((chaZhi > 0.01 || chaZhi < -0.01) && !(sslb == "28" || sslb == "29"))
            if (chaZhi > 0.01 || chaZhi < -0.01)
            {

                MessageBox.Show("HIS系统费用与医保系统费用不符，不能结算！！！");
                return;
            }
            string zyh = this.cyjsZyh.Text;
            string grbh = this.cyjsGrbh.Text;
            string sql_gxsfck = "select sfck,status from inhospital where id='" + ihsp_id + "'";
            DataSet ds_sfck = BllMain.Db.Select(sql_gxsfck);
            string djh = "";

            djh = this.fphtext.Text.Trim();
            //if (ds_sfck.Tables[0].Rows[0]["status"].ToString() != "SIGN")
            //{
            //    MessageBox.Show("此患者未挂账，请挂账之后再进行结算!");
            //    return;
            //}
            //if (string.IsNullOrEmpty(djh))
            //{
            //    MessageBox.Show("发票号为空,请领取发票!");
            //    return;
            //}
            if (Ini.IniReadValue2("pz", "ISXJHB") == "1")
            {
                djh = this.fphtext.Text.Trim();
                //if (ds_sfck.Tables[0].Rows[0]["outcondition"].ToString() == "OO" || ds_sfck.Tables[0].Rows[0]["outcondition"].ToString() == null || ds_sfck.Tables[0].Rows[0]["outcondition"].ToString() == "")
                if (!ds_sfck.Tables[0].Rows[0]["status"].ToString().Equals("SETT"))
                {
                    lblFeeUpLoad.Text = "";
                    MessageBox.Show("His系统没有结算，不允许城乡结算！");
                    return;
                }
            }
            else
            {
                String[] getfph = new String[1];
                if (ds_sfck.Tables[0].Rows[0]["status"].ToString() != "SIGN")
                {
                    lblFeeUpLoad.Text = "";
                    MessageBox.Show("此患者未挂账，请挂账之后再进行结算!");
                    return;
                }
                if (string.IsNullOrEmpty(djh))
                {
                    MessageBox.Show("发票号为空,请领取发票!");
                    return;
                }
            }
            //结算
            YBCJ_IN yw_in_zyjs = new YBCJ_IN();
            yw_in_zyjs.Yw = "CC511003";
            yw_in_zyjs.Ybcjbz = "0";
            if (ds_sfck.Tables[0].Rows[0]["sfck"].ToString() == "1")
            {
                yw_in_zyjs.Ylzh = "0";
            }
            else
            {
                yw_in_zyjs.Ylzh = this.cyjsGrbh.Text.Trim();
            }
            yw_in_zyjs.Hisjl = zyh;
            //个人编号|门诊住院号|手术类别|医疗费总额|胎儿数 |经办人
            yw_in_zyjs.Rc = this.cyjsGrbh.Text.Trim() + "|" + zyh + "|" + sslb + "|" + this.hisFeeLable.Text.Trim() + "|" + this.tbx_tes.Text.Trim() + "|" + ProgramGlobal.Username;
            int opt_zyyjs = yw1.ybcjhs(yw_in_zyjs);
            if (opt_zyyjs != 0)
            {
                //单据号修改成住院号
                string sql_8 = "update KC22 set AAE072='" + zyh + "' where AKC190='" + zyh + "';";
                jkdb.Update(sql_8);
                MessageBox.Show(yw_in_zyjs.Mesg + "结算失败", "提示信息");
                return;
            }
            string[] zyjs_cc = yw_in_zyjs.Cc.Split('|');
            string _iid = ihsp_id;
            string insetyb = "delete from zlsyb_zyinfo where mzzyjliid = " + _iid + ";"
                             + "insert into zlsyb_zyinfo(mzzyjliid,ybgrbh,fph,jbr,jssj,yllb,yyzfy,ybzfy,zyh,"
                             + "jsqzhye,jshzhye,bctczfje,bcxjzfje,bczhzfje,hzname,qfybch,gwyjjzf,syylfdebtxe,syylfdebtje,sygrzf,jswzsczfc) "
                             + "values ('"
                             + _iid + "','"//1
                             + this.cyjsGrbh.Text.Trim() + "','"//2
                             + djh + "','"//3
                             + ProgramGlobal.Username + "','"//4
                             + BillSysBase.currDate() + "','"//5
                             + sslb + "','"//6
                             + this.hisFeeLable.Text.Trim() + "','"//7
                             + zyjs_cc[0] + "','"//8
                             + zyh + "','"//9
                             + cyjsZhye.Text.Trim() + "','"//10
                             + "0" + "','"//11
                             + zyjs_cc[2] + "','"//12
                             + "0" + "','"//13
                             + "0" + "','"//14
                             + cyjsXm.Text.Trim() + "','"//15
                             + "3" + "','"
                             + "0" + "','"
                             + zyjs_cc[1] + "','" //生育医疗费定额补贴限额
                             + zyjs_cc[3] + "','" //生育医疗费定额补贴金额
                             + zyjs_cc[2] + "','"
                             + yw_in_zyjs.Cc + "'); ";
            //是否先结后报
            string isxjhb = Ini.IniReadValue2("pz", "ISXJHB");
            if (isxjhb == "0")
            {
                if (actMethod() < 0)
                {
                    MessageBox.Show("医保结算成功，his结算失败");
                    return;
                }
            }
            else
            {
                string sql_upaccount = "UPDATE ihsp_account SET insurefee = '" + Convert.ToDouble(tbx_ylfdebtje.Text.Trim()).ToString() + "', insuraccountfee = '" + cyjsZhzf.Text.Trim().ToString() + "'  WHERE ihsp_id = " + _iid.ToString();
                BllMain.Db.Update(sql_upaccount);
            }
            StringBuilder message = new StringBuilder();
            if (BllMain.Db.Update(insetyb) == -1)
            {
                SysWriteLogs.writeLogs1("市医保结算更新his错误信息", DateTime.Now, "sql=" + insetyb);
                MessageBox.Show("医保结算成功，更新his失败！" + message);
                return;
            }
            string settinsurdate = BillSysBase.currDate();//获取当前时间
            //修改his系统nhflag标志
            if (sslb == "28")
            {
                string sql2 = "update inhospital set nhflag=1502, nh_fph='" + djh + "'  where id=" + _iid.ToString() + "; ";
                sql2 += " update inhospital set yllb = '28',settInsurdate='" + settinsurdate + "'  where zyjlzyh = '" + zyh + "';";
                BllMain.Db.Update(sql2);
                MessageBox.Show("年终结算成功！");
            }
            else
            {
                string sql2 = "update inhospital set nhflag=1502,nh_fph='" + djh + "' , yllb = '" + sslb + "',settInsurdate='" + settinsurdate + "'  where id=" + _iid.ToString().Trim();
                BllMain.Db.Update(sql2);
                MessageBox.Show("出院结算成功！");
            }
            initButton();
            string mes = "需要打印发票吗?";
            if (MessageBox.Show(mes, "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            this.dyfp(grbh, zyh, ihsp_id);
        }
        /// <summary>
        /// 结算时更改数据
        /// </summary>
        public int actMethod()
        {
            string hisOrderNo = "";
            List<IhspInvoicedet> invoicedets = new List<IhspInvoicedet>();
            ihspaccount.Id = BillSysBase.nextId("ihsp_account");
            ihspaccount.Ihsp_id = ihsp_id;
            ihspaccount.Billcode = BillSysBase.newBillcode("ihsp_account_billcode");
            ihspaccount.Member_id = member_id;
            ihspaccount.Bas_paytype_id = this.cbx_fklx.SelectedValue.ToString();
            ihspaccount.HisOrderNo = hisOrderNo;
            ihspaccount.Cheque = "";
            ihspaccount.Bas_patienttype_id = ylkfkfs;
            ihspaccount.Num = "1";
            ihspaccount.Invoice = invoicecode;//发票
            ihspaccount.Nextinvoicesql = nextinvoicesql;//发票sql

            ihspaccount.Feeamt = this.cyjsFyzje.Text.ToString().Trim();
            ihspaccount.Prepamt = yjkzfy.Text.ToString();
            ihspaccount.Balanceamt = tbx_thbxj.Text.ToString().Trim();
            ihspaccount.Recivefee = this.tbx_thbxj.Text.Trim().ToString();
            ihspaccount.Retfee = this.tbx_thbxj.Text.Trim().ToString();
            ihspaccount.Depart_id = ProgramGlobal.Depart_id;
            ihspaccount.Chargedby_id = ProgramGlobal.User_id;
            ihspaccount.Chargedate = BillSysBase.currDate();
            ihspaccount.Cancleby = "";
            ihspaccount.Ihsp_account_id = "";
            ihspaccount.Status = IhspAccountStatus.SETT.ToString();
            ihspaccount.Insurefee = Convert.ToDouble(tbx_ylfdebtje.Text.Trim()).ToString();
            ihspaccount.Selffee = cyjsZhzf.Text.Trim().ToString();

            IhspInvoicedet ihspInvoicedet = new IhspInvoicedet();
            ihspInvoicedet.Id = BillSysBase.nextId("ihsp_invoicedet");
            ihspInvoicedet.IhspAccountId = ihspaccount.Id;
            ihspInvoicedet.PaytypeId = cbx_fklx.SelectedValue.ToString();
            ihspInvoicedet.PaysumbyId = billIhspAct.getPaysumby(cbx_fklx.SelectedValue.ToString());
            ihspInvoicedet.Payfee = ihspaccount.Balanceamt;
            invoicedets.Clear();
            invoicedets.Add(ihspInvoicedet);

            string account_sql = "";
            account_sql = billIhspAct.doAccount(ihspaccount, invoicedets, "selfcost");
            if (-1 == billIhspMan.doExeSql(account_sql))//结算
            {

                return -1;
            }
            return 0;
        }

        private void btnXfsj_Click(object sender, EventArgs e)
        {
            string sql_sfjs = "select nhflag from inhospital where id = " + ihsp_id;
            DataTable dtxx_sfjs = BllMain.Db.Select(sql_sfjs).Tables[0];
            if (dtxx_sfjs.Rows[0]["nhflag"].ToString() != "1501")
                return;
            //if (Tool.IsUpload == true)
            //{
            //    string sqlfyxx = "select iid from mtzyjlstuff where ybsc = 0 and mtzyjl = " + mtzyjl_iid;

            //    DataTable dtxx = hisdb.Select(sqlfyxx).Tables[0];
            //    if (dtxx.Rows.Count > 0)
            //    {
            //        MessageBox.Show("后台正在自动上传费用,稍后再预结算！", "提示信息");
            //        return;
            //    }
            //}
            string ybjk_sql_delete = " delete from KC22 where AKC190 = '" + this.cyjsZyh.Text.Trim() + "' and  CKC126=0";
            jkdb.Update(ybjk_sql_delete);
            string ybjk_sql = "select AKC220 from KC22 where AKC190 = '" + this.cyjsZyh.Text.Trim() + "'";

            DataTable dt = jkdb.Select(ybjk_sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                string his_sql_update = "update  ihsp_costdet set insursync='N' where ihsp_id=" + this.ihsp_id + " and id not in (";
                string iid_sqls = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    iid_sqls += dt.Rows[i]["AKC220"].ToString() + ",";
                }
                iid_sqls = iid_sqls.Remove(iid_sqls.Length - 1);
                his_sql_update += iid_sqls + ")";

                BllMain.Db.Update(his_sql_update);
            }
            else
            {
                string his_sql_update = "update ihsp_costdet set insursync='N' where ihsp_id='" + this.ihsp_id + "'";
                int ac = BllMain.Db.Update(his_sql_update);
            }
            //Zyybfysc ybfysc = new Zyybfysc();
            Zysyybfysc zysyybfysc = new Zysyybfysc();
            RetMsg ret = zysyybfysc.ybscfymx(int.Parse(ihsp_id), ylkfkfs, cyjsGrbh.Text.Trim(), this.cyjsZyh.Text.Trim(), lblFeeUpLoad);
            string msg_ybxfdhjebz = "";
            zysyybfysc.xfdhje(int.Parse(ihsp_id), this.cyjsZyh.Text.Trim(), out msg_ybxfdhjebz);
            cxfy();
            this.fymxcount();
            this.ybfy(this.cyjsZyh.Text.Trim());
            if (!string.IsNullOrEmpty(msg_ybxfdhjebz))
            {
                FrmMesg frmmesg = new FrmMesg();
                frmmesg.StartPosition = FormStartPosition.CenterScreen;
                frmmesg.In_mesg = "上传费用情况如下：【住院号：" + this.cyjsZyh.Text.Trim() + "-" + ret.Mesg + msg_ybxfdhjebz + "】";
                frmmesg.ShowDialog(this);
            }
            lblFeeUpLoad.Text = "上传费用成功！";
            lblFeeUpLoad.Update();
        }

        private void btn_sfck_Click(object sender, EventArgs e)
        {
            if (this.btn_sfck.Text.Trim() == "有卡")
            {
                BllMain.Db.Update("update inhospital set sfck=0 where id=" + this.ihsp_id);
                this.btn_sfck.Text = "无卡";
            }
            else
            {
                BllMain.Db.Update("update inhospital set sfck=1 where id=" + this.ihsp_id);
                this.btn_sfck.Text = "有卡";
            }
        }

        private void btn_tc_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            { return; }

            string mtzyjlstuffiid = dataGridView2.CurrentRow.Cells["id"].Value.ToString().Trim();
            string xmmc = dataGridView2.CurrentRow.Cells["项目名称"].Value.ToString().Trim();
            string fydj = dataGridView2.CurrentRow.Cells["费用等级"].Value.ToString().Trim();
            string hism = dataGridView2.CurrentRow.Cells["prodiid"].Value.ToString().Trim();
            string xmbmsql = " select hiscode as xmbm from bas_item where id = " + hism + " ";
            DataTable dt = BllMain.Db.Select(xmbmsql).Tables[0];
            string xmbm = dt.Rows[0]["xmbm"].ToString().Trim();
            FrmXgjyb jyb = new FrmXgjyb();
            jyb.Hzmc = this.cyjsXm.Text.Trim();
            jyb.Xmmc = xmmc;
            jyb.Jyb = fydj;
            jyb.Xmbm = xmbm;
            jyb.Xzxyysm = dataGridView2.CurrentRow.Cells["药品提示信息"].Value.ToString().Trim();
            jyb.StartPosition = FormStartPosition.CenterScreen;
            jyb.ShowDialog();
            if (jyb.Flag == false)
            {
                return;
            }
            string updateyblx = "update ihsp_costdet set ypspbz='" + jyb.Xzxyysfkb + "', yblx = '" + jyb.Jyb + "' where insursync='N' and ihsp_id = " + ihsp_id + " and id = " + mtzyjlstuffiid;
            BllMain.Db.Update(updateyblx);
            this.cxfy();
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                if (dataGridView2.Rows[i].Cells["iid"].Value.ToString() == mtzyjlstuffiid)
                {
                    dataGridView2.CurrentCell = dataGridView2.Rows[i].Cells["项目名称"];
                    break;
                }
            }
        }
        //明细汇总
        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                string sqlitem = "select ihsp_costdet.ihsp_id as Mtzyjl,ihsp_costdet.itemfrom AS Xmlb,bas_item.hiscode as Ybbm,ihsp_costdet.yblx AS Yblx"
                               + ",ihsp_costdet.spec as Guige,ihsp_costdet.unit as Uom,ihsp_costdet.prc as Prc,sum(ihsp_costdet.num) as Qty,sum(ihsp_costdet.fee) as Amt"
                               + ",sum(ihsp_costdet.ybxfdhje) as xfdhje,bas_item.id as mtprod "
                               + " from bas_item,ihsp_costdet where ihsp_costdet.item_id=bas_item.id and ihsp_costdet.ihsp_id=" + ihsp_id + " "
                               + " and ihsp_costdet.charged in('CHAR','RET','RREC') "
                               + " GROUP BY ihsp_costdet.ihsp_id,ihsp_costdet.itemfrom,bas_item.hiscode,ihsp_costdet.insurclass,ihsp_costdet.spec,ihsp_costdet.unit,bas_item.id";

                dataGridView3.DataSource = BllMain.Db.Select(sqlitem).Tables[0];
                double zjehj = 0;
                double xfdhjehj = 0;
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    if ((dataGridView3.Rows[i].Cells["Ybbm"].Value.ToString() == "") || (dataGridView3.Rows[i].Cells["Ybbm"].Value.ToString() == "0"))
                        dataGridView3.Rows[i].DefaultCellStyle.BackColor = Color.Red;//
                    zjehj += double.Parse(dataGridView3.Rows[i].Cells["xmje"].Value.ToString());
                    string xfdhje5 = dataGridView3.Rows[i].Cells["xfdhje"].Value.ToString().Trim();
                    if (!string.IsNullOrEmpty(xfdhje5))
                    {
                        xfdhjehj += double.Parse(xfdhje5);
                    }
                }
                //this.lbl_zje.Text = zjehj.ToString("0.00");
                //this.lbl_xfdhje.Text = xfdhjehj.ToString("0.00");

            }
            else if (tabControl1.SelectedIndex == 0)
            {
                cxfy();
            }
        }
    }
}
