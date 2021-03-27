using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using zhongluyiyuan.listitem;
using MTHIS.main.bll;
using WindowsFormsApplication1.common;
using zhongluyiyuan.Util;
using WindowsFormsApplication1;
using zhongluyiyuan.Entity;
using System.Text.RegularExpressions;
using zhongluyiyuan.gsbx.bll;
using MTHIS.tools;
using MTREG.common.bll;
using MTREG.ihsp.bo;
using MTREG.common;
using MTREG.ihsp.bll;
using MTHIS.common;


namespace zhongluyiyuan.gsbx
{
    public partial class FrmgsCy : Form
    {
        public FrmgsCy()
        {
            InitializeComponent();
        }
        DlDC dldc = new DlDC();
        GSBX_IN in1 = new GSBX_IN();
        GSBX_OUT out1 = new GSBX_OUT();
        GSBXinterface GSBXinterface = new GSBXinterface();
        private string member_id = "";
        //住院记录iid
        private string mtzyjl_iid;
        public string Mtzyjl_iid
        {
            get { return mtzyjl_iid; }
            set { mtzyjl_iid = value; }
        }
        //医疗付款方式
        private string ylkfkfs;
        public string Ylkfkfs
        {
            get { return ylkfkfs; }
            set { ylkfkfs = value; }
        }
        //住院号
        private string zyh_;
        public string Zyh
        {
            get { return zyh_; }
            set { zyh_ = value; }
        }
        private string grbh_;

        public string Grbh_
        {
            get { return grbh_; }
            set { grbh_ = value; }
        }
        string sessionid = "";
        private void FrmgsCy_Load(object sender, EventArgs e)
        {
            csh();
            initYllb();
            initCyyy();
            initdgv();
            //this.fphtext.ReadOnly = true;
            //修改编码
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.Name = "btnEdit";
            btnEdit.HeaderText = "修改编码";
            btnEdit.Text = "修改编码";
            btnEdit.InheritedStyle.NullValue = "修改编码";
            btnEdit.Width = 80;
            btnEdit.UseColumnTextForButtonValue = true;
            btnEdit.Frozen = true;
            dataGridView3.Columns.Insert(0, btnEdit);
        }
        private void initCyyy()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("1", "康复"));
            items.Add(new ListItem("2", "转院"));
            items.Add(new ListItem("3", "死亡"));
            items.Add(new ListItem("4", "市内转院结算"));
            items.Add(new ListItem("9", "其他"));
            this.comboCyyy.DisplayMember = "Text";
            this.comboCyyy.ValueMember = "Value";
            this.comboCyyy.DataSource = items;
            this.comboCyyy.SelectedValue = "1";
        }
        private void initYllb()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("11", "门诊"));
            items.Add(new ListItem("21", "住院"));
            this.combocyjsyllb.DisplayMember = "Text";
            this.combocyjsyllb.ValueMember = "Value";
            this.combocyjsyllb.DataSource = items;
            this.combocyjsyllb.SelectedValue = "21";
        }
        private void csh()
        {
            string sql = @"SELECT
                        	inhospital.ybgrbh,
                        	inhospital.invoicecode as fph,
                        	inhospital.rdsh,inhospital.member_id,
                        	inhospital.`name` AS brxm,
                        	bas_doctor.`name` AS ysname,
                        	bas_depart.`name` AS ryks,
                        	case when inhospital.sex='F' then 2 else 1 end  AS brxb,
                        	bas_sickroom.`name` AS bfh,
                        	bas_sickbed.`name` AS bch,
                        	ihsp_info.idcard AS sfzh,
                            inhospital.status,
                        	DATE_FORMAT (inhospital.indate,'%Y-%m-%d') AS zyjlrysj,
                        	DATE_FORMAT (inhospital.outdate,'%Y-%m-%d') AS zyjlcysj
                        	FROM  inhospital left join bas_sickroom on inhospital.sickroom_id=bas_sickroom.id 
                                 left join bas_sickbed on inhospital.sickbed_id=bas_sickbed.id
                                 left join bas_doctor on inhospital.doctor_id = bas_doctor.id left join bas_depart on bas_depart.id = inhospital.depart_id 
                                 LEFT JOIN ihsp_info on ihsp_info.ihsp_id=inhospital.id and ihsp_info.registkind='IHSP'
                            WHERE inhospital.id =" + mtzyjl_iid;
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            cyjsZyh.Text = Zyh;
            cyjsXm.Text = dt.Rows[0]["brxm"].ToString().Trim();
            cyjsGrbh.Text = dt.Rows[0]["ybgrbh"].ToString().Trim();
            cyjsYs.Text = dt.Rows[0]["ysname"].ToString().Trim();
            CyjsKs.Text = dt.Rows[0]["ryks"].ToString().Trim();
            textBox2.Text = (dt.Rows[0]["brxb"].ToString().Trim() == "1") ? ("男") : ("女");
            cyjsBfh.Text = dt.Rows[0]["bfh"].ToString().Trim();
            tbx_bch.Text = dt.Rows[0]["bch"].ToString().Trim();
            tbx_jmylzh.Text = dt.Rows[0]["sfzh"].ToString().Trim();
            cyjsRyrq.Text = dt.Rows[0]["zyjlrysj"].ToString().Trim();
            cyjsCyrq.Text = dt.Rows[0]["zyjlcysj"].ToString().Trim();
            tbx_rdsh.Text = dt.Rows[0]["rdsh"].ToString().Trim();
            fphtext.Text = dt.Rows[0]["fph"].ToString().Trim();
            string sumFeeSql = "select sum(ihsp_payinadv.payfee) as sumAmt from ihsp_payinadv where  ihsp_payinadv.ihsp_id=" + mtzyjl_iid;
            DataTable temSum = BllMain.Db.Select(sumFeeSql).Tables[0];
            tbx_yjj.Text = temSum.Rows[0]["sumAmt"].ToString().Trim();//预交金
            string sumFee = "select feeamt as amt from inhospital where  id=" + mtzyjl_iid;
            DataTable tem = BllMain.Db.Select(sumFee).Tables[0];
            label2.Text = tem.Rows[0]["amt"].ToString();//金额
            member_id = dt.Rows[0]["member_id"].ToString();
            string status = dt.Rows[0]["status"].ToString().Trim();
            if (!status.Equals("SETT"))
            {
                button2.Enabled = false;
            }

        }
        private void initdgv()
        {
            string sql = @" SELECT ihsp_costdet.id AS cfh,
	                               DATE_FORMAT(ihsp_costdet.chargedate,'%Y-%m-%d') AS cfsj,
	                               '1' AS cfts,
	                               ihsp_costdet.item_id AS prodid,
	                               bas_item.gsbm AS xmbm,
	                               ihsp_costdet.`name` AS xmmc,
	                               gsxmlb. NAME AS sflb,
	                               '' AS sfdj,
	                               CASE WHEN (ihsp_costdet.itemtype_id = 10) OR (ihsp_costdet.itemtype_id = 11) OR (ihsp_costdet.itemtype_id = 12) THEN '0' ELSE '1' END AS zl,
	                               ihsp_costdet.prc,
	                               ihsp_costdet.num AS num,
	                               ihsp_costdet.realfee as amt,
	                               ihsp_costdet.spec as guige,
	                               prodjixing. NAME AS jixing,
	                               ihsp_costdet.insursync AS sfsc 
	                          from ihsp_costdet left join bas_item on ihsp_costdet.item_id=bas_item.id
	                               left join  gsxmlb on ihsp_costdet.itemtype_id=gsxmlb.hisid
	                                left join (select * from sys_dict where father_id=40) prodjixing  on bas_item.dosageform_id=prodjixing.sn
	                          where ihsp_costdet.ihsp_id =" + mtzyjl_iid;
            dataGridView3.DataSource = BllMain.Db.Select(sql).Tables[0];
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {

                if (dataGridView3.Rows[i].Cells["sfsc"].Value.ToString() == "0" || dataGridView3.Rows[i].Cells["sfsc"].Value.ToString() == "")
                    dataGridView3.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;//未上传
            }
            string sql_count = "select count(*) as sum from ihsp_costdet where ihsp_id=" + mtzyjl_iid;
            DataSet dt_count = BllMain.Db.Select(sql_count);
            lab_zg.Text = dt_count.Tables[0].Rows[0]["sum"].ToString().Trim();
        }

        private void btnXfsj_Click(object sender, EventArgs e)
        {
            string sql_sfjs = "select nhflag from inhospital where id = " + mtzyjl_iid;
            DataTable dtxx_sfjs = BllMain.Db.Select(sql_sfjs).Tables[0];
            if (dtxx_sfjs.Rows[0]["nhflag"].ToString() != "501")
                return;
            //if (Tool.IsUpload==true)
            //{
            //    MessageBox.Show("后台正在自动上传费用！", "提示信息");
            //    return;
            //}


            if (dataGridView3.Rows.Count < 0)
            {
                return;
            }
            int retnum = 1;
            while (retnum > 0)
            {
                retnum = scfymx();
                if (retnum == -1)
                {
                    return;
                }
            }
            MessageBox.Show("上传完成！");
        }
        public int scfymx()
        {
            string sql_yz = @" SELECT ihsp_advdet.id AS aae080,
	                                  DATE_FORMAT (ihsp_advice.begindate,'%Y-%m-%d') AS alk007,
	                                  DATE_FORMAT (ihsp_advice.stopdate,'%Y-%m-%d') AS alk008,
	                                  ihsp_advdet.`name` AS alk009,
 	                                  '' AS alk011,
	                                   '' AS alk012,
	                                   CONCAT(ihsp_advdet.dosagenum,ihsp_advdet.dosageuom) as alk013,
	                                   CONCAT(mtusage.name,mtfrequency.`name`) AS alk014,
	                                   ihsp_advdet.memo AS alk015,
 	                                  ysqm.`name` AS alk016,
 	                                  '' AS alk017,
 	                                  '' AS alk020,
 	                                  CASE ihsp_advice.advflag WHEN 'LONG' THEN	1 WHEN 'TEMP' THEN	2 END AS alk022,
	                                   bas_depart.`name` AS alk023,
 	                                  bas_sickbed.`name` AS alk024
	                             FROM inhospital,ihsp_advice,bas_depart,bas_doctor ysqm,bas_sickbed,ihsp_advdet 
	                                  LEFT JOIN (select * from sys_dict where father_id=30) mtusage ON ihsp_advdet.drug_usage_id = mtusage.sn
	                                  LEFT JOIN drug_freq mtfrequency ON ihsp_advdet.drug_freq_id= mtfrequency.id
	                                  WHERE ihsp_advice.id=ihsp_advdet.ihsp_advice_id and inhospital.id = ihsp_advice.ihsp_id and ihsp_advice.doctor_id = ysqm.id
                                          and ihsp_advice.depart_id = bas_depart.id and inhospital.sickbed_id= bas_sickbed.id and ihsp_advdet.ybsc=1 and  
                                           inhospital.id=" + mtzyjl_iid;
            DataTable dt_yz = BllMain.Db.Select(sql_yz).Tables[0];

            string sql = @" SELECT ihsp_costdet.id AS cfh,
                                bas_item.gszf as gszf,
                                DATE_FORMAT(ihsp_costdet.chargedate,'%Y-%m-%d') AS cfsj,
                                '1' AS cfts,
                                bas_item.gsbm AS xmbm,
                                ihsp_costdet.`name` AS xmmc,
                                ihsp_costdet.`name` AS tym,
                                gsxmlb.id AS sflb,
                                CASE WHEN (ihsp_costdet.itemtype_id = 10) OR (ihsp_costdet.itemtype_id = 11) OR (ihsp_costdet.itemtype_id = 12) THEN '0' ELSE '1' END AS zl,
                                 ihsp_costdet.prc,
                                 ihsp_costdet.num AS num,
                                ihsp_costdet.realfee as amt,
                                ihsp_costdet.spec as guige,
                                prodjixing. NAME AS jixing,
                                ihsp_costdet.insursync AS sfsc,bas_item.id as yynm 
                                from ihsp_costdet left join bas_item on ihsp_costdet.item_id=bas_item.id
                                     left join  gsxmlb on ihsp_costdet.itemtype_id=gsxmlb.hisid
                                     left join (select * from sys_dict where father_id=40) prodjixing  on bas_item.dosageform_id=prodjixing.sn
                                where ihsp_costdet.insursync=0 and ihsp_costdet.ihsp_id =" + mtzyjl_iid + " order by cfh limit 50";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            int retnum = 0;
            if (dt.Rows.Count < 1 || dt.Rows == null)
            {
                return retnum;
            }
            retnum = dt.Rows.Count;
            string flag = dldc.dengru();
            if (flag == "1")
            {
                MessageBox.Show(dldc.Message);
                retnum = -1;
                return retnum;
            }
            sessionid = dldc.Sessionid;
            in1.Log_name = "费用上传";
            in1.YwName = "sendMedInfo";
            string data = "<medReqData>";
            data += " <sessionid>" + sessionid + "</sessionid>";
            data += " <akc190>" + zyh_ + "</akc190>";

            if (dt_yz.Rows.Count > 0)
            {
                data += "<advices>";
                for (int k = 0; k < dt_yz.Rows.Count; k++)
                {
                    data += "<advice>";
                    data += "<aae080>" + dt_yz.Rows[k]["aae080"].ToString().Trim() + "</aae080>";
                    data += "<alk007>" + dt_yz.Rows[k]["alk007"].ToString().Trim() + "</alk007>";
                    data += "<alk008>" + dt_yz.Rows[k]["alk008"].ToString().Trim() + "</alk008>";
                    data += "<alk009>" + dt_yz.Rows[k]["alk009"].ToString().Trim() + "</alk009>";
                    data += "<alk011>" + dt_yz.Rows[k]["alk011"].ToString().Trim() + "</alk011>";
                    data += "<alk012>" + dt_yz.Rows[k]["alk012"].ToString().Trim() + "</alk012>";
                    data += "<alk013>" + dt_yz.Rows[k]["alk013"].ToString().Trim() + "</alk013>";
                    data += "<alk014>" + dt_yz.Rows[k]["alk014"].ToString().Trim() + "</alk014>";
                    data += "<alk015>" + dt_yz.Rows[k]["alk015"].ToString().Trim() + "</alk015>";
                    data += "<alk016>" + dt_yz.Rows[k]["alk016"].ToString().Trim() + "</alk016>";
                    data += "<alk017>" + dt_yz.Rows[k]["alk017"].ToString().Trim() + "</alk017>";
                    data += "<alk020>" + dt_yz.Rows[k]["alk020"].ToString().Trim() + "</alk020>";
                    data += "<alk022>" + dt_yz.Rows[k]["alk022"].ToString().Trim() + "</alk022>";
                    data += "<alk023>" + dt_yz.Rows[k]["alk023"].ToString().Trim() + "</alk023>";
                    data += "<alk024>" + dt_yz.Rows[k]["alk024"].ToString().Trim() + "</alk024>";
                    data += "</advice>";
                }
                data += "</advices>";
            }

            if (dt.Rows.Count > 0)
            {
                data += "<meds>";
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    data += "<med>";
                    data += "<alc400>" + dt.Rows[i]["cfh"].ToString().Trim() + "</alc400>";
                    data += "<alc401>" + dt.Rows[i]["cfsj"].ToString().Trim() + "</alc401>";
                    data += "<akc229>" + dt.Rows[i]["cfts"].ToString().Trim() + "</akc229>";
                    string gszf = dt.Rows[i]["gszf"].ToString().Trim();
                    if (gszf == "1")
                    { dt.Rows[i]["xmbm"] = "S" + dt.Rows[i]["xmbm"]; }
                    string xmbm = dt.Rows[i]["xmbm"].ToString().Trim();
                    if (xmbm == "")
                    {
                        xmbm = 'S' + dt.Rows[i]["yynm"].ToString().Trim();
                    }
                    data += "<alc402>" + xmbm + "</alc402>";
                    data += "<alc403>" + dt.Rows[i]["xmmc"].ToString().Trim() + "</alc403>";
                    data += "<aka063>" + dt.Rows[i]["sflb"].ToString().Trim() + "</aka063>";
                    string sfdj = "";
                    //string xmbm = dt.Rows[i]["xmbm"].ToString().Trim();
                    string sql1 = "select gssfdj from gsml where bm='" + xmbm + "'";
                    DataTable dt1 = BllMain.Db.Select(sql1).Tables[0];
                    if (dt1.Rows.Count == 0)
                    {
                        data += "<aka065>3</aka065>";
                    }
                    else
                    {
                        data += "<aka065>" + dt1.Rows[0]["gssfdj"].ToString().Trim() + "</aka065>";
                    }
                    data += "<alc404>" + dt.Rows[i]["zl"].ToString().Trim() + "</alc404>";
                    data += "<alc405>" + dt.Rows[i]["prc"].ToString().Trim() + "</alc405>";
                    data += "<alc406>" + dt.Rows[i]["num"].ToString().Trim() + "</alc406>";
                    data += "<alc407>" + dt.Rows[i]["amt"].ToString().Trim() + "</alc407>";
                    data += "<aka070>" + dt.Rows[i]["jixing"].ToString().Trim() + "</aka070>";
                    data += "<zka100>" + dt.Rows[i]["guige"].ToString().Trim() + "</zka100>";
                    data += "<akc230></akc230>";
                    data += "<akc231>" + dt.Rows[i]["tym"].ToString().Trim() + "</akc231>";
                    data += "<akc515>" + dt.Rows[i]["yynm"].ToString().Trim() + "</akc515>";
                    data += "<reason></reason>";
                    data += "<noinjury></noinjury>";
                    data += "</med>";
                }
                data += "</meds>";
            }

            data += " </medReqData>";
            in1.YwData = Base64.encodebase64(in1.head() + data);


            out1 = GSBXinterface.request(in1);
            if (out1.State == "2")
            {
                MessageBox.Show("工伤保险提示！\r\n" + in1.Log_name + "出错！\r\n【" + out1.Message + "】");
                string flag11 = dldc.dengchu(sessionid);
                if (flag11 == "1")
                {
                    MessageBox.Show(dldc.Message);
                    retnum = -1;
                    return retnum;
                }
                sessionid = "";
                retnum = -1;
                return retnum;
            }

            out1.State = out1.Ds.Tables["medInfoRespData"].Rows[0]["code"].ToString().Trim();
            out1.Message = out1.Ds.Tables["medInfoRespData"].Rows[0]["msg"].ToString().Trim();
            if (out1.State != "0")
            {
                MessageBox.Show("工伤保险提示！\r\n" + in1.Log_name + "出错！\r\n【" + out1.Message + "】");
                string flag11 = dldc.dengchu(sessionid);
                if (flag11 == "1")
                {
                    MessageBox.Show(dldc.Message);
                    return retnum;
                }
                sessionid = "";
                retnum = -1;
                return retnum;
            }
            //string count = out1.Ds.Tables["injuryRespData"].Rows[0]["counts"].ToString().Trim();
            //insertgsxx(count, out1.Ds);
            //lab_ysx.Text = out1.Ds.Tables["medInfoRespData"].Rows[0]["count"].ToString().Trim();
            string sql_up = "update ihsp_costdet set insursync=1 where id in (";
            if (dt.Rows.Count > 0)
            {
                for (int q = 0; q < dt.Rows.Count; q++)
                {
                    sql_up += dt.Rows[q]["cfh"].ToString().Trim() + ",";
                }
                sql_up = sql_up.Substring(0, sql_up.Length - 1);

                sql_up += "); ";
            }
            if (dt_yz.Rows.Count > 0)
            {
                sql_up += " update ihsp_advdet set ybsc=1 where id in (";
                for (int q = 0; q < dt_yz.Rows.Count; q++)
                {
                    sql_up += dt_yz.Rows[q]["aae080"].ToString().Trim() + ",";
                }
                sql_up = sql_up.Substring(0, sql_up.Length - 1);

                sql_up += "); ";
            }
            if (BllMain.Db.Update(sql_up) == -1)
            {
                SysWriteLogs.writeLogs1("上传费用成功，但更新HIS标志失败！", DateTime.Now, "sql=" + sql_up);
                MessageBox.Show("上传费用成功，但更新HIS标志失败！");
            }
            initdgv();
            string flag1 = dldc.dengchu(sessionid);
            if (flag1 == "1")
            {
                MessageBox.Show(dldc.Message);
                return retnum;
            }
            sessionid = "";
            return retnum;

        }

        private void btn_js_Click(object sender, EventArgs e)
        {
            string flag = dldc.dengru();
            if (flag == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = dldc.Sessionid;

            in1.Log_name = "discharge";
            in1.YwName = "discharge";
            string data = "<discReqData>";
            data += " <sessionid>" + sessionid + "</sessionid>";
            data += " <akc190>" + zyh_ + "</akc190>";
            data += " <aaca07>" + fphtext.Text.Trim() + "</aaca07>";
            //data += " <aaca07>111111111</aaca07>";
            data += " </discReqData>";
            in1.YwData = Base64.encodebase64(in1.head() + data);

            out1 = GSBXinterface.request(in1);
            if (out1.State == "2")
            {
                MessageBox.Show("工伤保险提示！\r\n" + in1.Log_name + "出错！\r\n【" + out1.Message + "】");
                string flag11 = dldc.dengchu(sessionid);
                if (flag11 == "1")
                {
                    MessageBox.Show(dldc.Message);
                    return;
                }
                sessionid = ""; return;
            }

            out1.State = out1.Ds.Tables["discRespData"].Rows[0]["code"].ToString().Trim();
            out1.Message = out1.Ds.Tables["discRespData"].Rows[0]["msg"].ToString().Trim();
            if (out1.State != "0")
            {
                MessageBox.Show("工伤保险提示！\r\n" + in1.Log_name + "出错！\r\n【" + out1.Message + "】");
                string flag11 = dldc.dengchu(sessionid);
                if (flag11 == "1")
                {
                    MessageBox.Show(dldc.Message);
                    return;
                }
                sessionid = "";
                return;
            }
            double zje = double.Parse(out1.Ds.Tables["discRespData"].Rows[0]["alc407"].ToString().Trim());
            tbx_hzzyh.Text = out1.Ds.Tables["discRespData"].Rows[0]["akc190"].ToString().Trim();
            tbx_hzzje.Text = zje.ToString().Trim();
            DataTable dt_sf = out1.Ds.Tables["collection"];
            for (int i = 0; i < dt_sf.Rows.Count; i++)
            {
                string lb = dt_sf.Rows[i]["aka063"].ToString().Trim();
                string sql = "select name from gsxmlb where id='" + lb + "'";
                DataTable dt2 = BllMain.Db.Select(sql).Tables[0];
                dt_sf.Rows[i]["aka063"] = dt2.Rows[0]["name"].ToString().Trim();
            }
            dataGridView1.DataSource = dt_sf;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string flag = dldc.dengru();
            if (flag == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = dldc.Sessionid;
            in1.Log_name = "dischargeRollback";
            in1.YwName = "dischargeRollback";
            string data = "<rollbReqData>";
            data += " <sessionid>" + sessionid + "</sessionid>";
            data += " <akc190>" + cyjsZyh.Text.Trim() + "</akc190>";
            data += " <aaca07>" + fphtext.Text.Trim() + "</aaca07>";
            data += " </rollbReqData>";
            in1.YwData = Base64.encodebase64(in1.head() + data);

            out1 = GSBXinterface.request(in1);
            if (out1.State == "2")
            {
                MessageBox.Show("工伤保险提示！\r\n" + in1.Log_name + "出错！\r\n【" + out1.Message + "】");
                string flag11 = dldc.dengchu(sessionid);
                if (flag11 == "1")
                {
                    MessageBox.Show(dldc.Message);
                    return;
                }
                sessionid = ""; return;
            }

            out1.State = out1.Ds.Tables["rollbRespData"].Rows[0]["code"].ToString().Trim();
            out1.Message = out1.Ds.Tables["rollbRespData"].Rows[0]["msg"].ToString().Trim();
            if (out1.State != "0")
            {
                MessageBox.Show("工伤保险提示！\r\n" + in1.Log_name + "出错！\r\n【" + out1.Message + "】");
                string flag11 = dldc.dengchu(sessionid);
                if (flag11 == "1")
                {
                    MessageBox.Show(dldc.Message);
                    return;
                }
                sessionid = "";
                return;
            }
            MessageBox.Show("核准回退成功！");
            tbx_hzzyh.Text = "";
            tbx_hzzje.Text = "";
            //dataGridView1.Rows.Clear();
            string flag1 = dldc.dengchu(sessionid);
            if (flag1 == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string flag = dldc.dengru();
            if (flag == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = dldc.Sessionid;
            in1.Log_name = "invalidData";
            in1.YwName = "invalidData";
            string data = "<invalidReqData>";
            data += " <sessionid>" + sessionid + "</sessionid>";
            data += " <akc190>" + cyjsZyh.Text.Trim() + "</akc190>";
            data += " </invalidReqData>";
            in1.YwData = Base64.encodebase64(in1.head() + data);

            out1 = GSBXinterface.request(in1);
            if (out1.State == "2")
            {
                MessageBox.Show("工伤保险提示！\r\n" + in1.Log_name + "出错！\r\n【" + out1.Message + "】");
                string flag11 = dldc.dengchu(sessionid);
                if (flag11 == "1")
                {
                    MessageBox.Show(dldc.Message);
                    return;
                }
                sessionid = ""; return;
            }

            out1.State = out1.Ds.Tables["invalidRespData"].Rows[0]["code"].ToString().Trim();
            out1.Message = out1.Ds.Tables["invalidRespData"].Rows[0]["msg"].ToString().Trim();
            if (out1.State != "0")
            {
                MessageBox.Show("工伤保险提示！\r\n" + in1.Log_name + "出错！\r\n【" + out1.Message + "】");
                string flag11 = dldc.dengchu(sessionid);
                if (flag11 == "1")
                {
                    MessageBox.Show(dldc.Message);
                    return;
                }
                sessionid = "";
                return;
            }

            string sql_ssfy = "update ihsp_costdet set insursync=0 where ihsp_id=" + mtzyjl_iid + ";";
            sql_ssfy += "update ihsp_advdet set ybsc=0 where ihsp_advdet.ihsp_advice_id in (select id from ihsp_advice where ihsp_id=" + mtzyjl_iid + ");";
            BllMain.Db.Update(sql_ssfy);
            initdgv();
            MessageBox.Show("删除费用成功！");
            string flag1 = dldc.dengchu(sessionid);
            if (flag1 == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cyjsCyrq.Text.Trim() == "" && fphtext.Text.Trim() == "")
            {
                MessageBox.Show("自费没有结算！");
                return;
            }
            if (cyjsjbbm.Text.Trim() == "")
            {
                MessageBox.Show("没有出院疾病!");
                return;
            }
            string sql_sfxgs = "select sfxgs from inhospital  where id=" + mtzyjl_iid;
            DataTable dt_sfxgs = BllMain.Db.Select(sql_sfxgs).Tables[0];
            if (dt_sfxgs.Rows[0]["sfxgs"].ToString().Trim() == "1")
            {
                //if (gsba_rdbz.Text.Trim() == "")
                //{
                //    MessageBox.Show("该病人为新工伤，先获取备案信息！");
                //    return;
                //}
                //if (gsba_rdbz.Text.Trim() == "认定为工伤" || gsba_rdbz.Text.Trim() == "认定为视同工伤")
                //{ }
                //else
                //{
                //    MessageBox.Show("该病人认定未通过！按自费结算！");
                //    button2.Enabled = false;
                //    return;
                //}
            }
            string flag = dldc.dengru();
            if (flag == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = dldc.Sessionid;
            in1.Log_name = "leaveHos";
            in1.YwName = "leaveHos";
            string zyts = (DateTime.Parse(cyjsCyrq.Text) - DateTime.Parse(cyjsRyrq.Text)).TotalDays.ToString().Trim();
            string data = "<leaveReqData>";
            data += " <sessionid>" + sessionid + "</sessionid>";
            data += " <akc190>" + zyh_ + "</akc190>";
            data += "<aac002>" + tbx_jmylzh.Text + "</aac002>";
            data += "<aac003>" + cyjsXm.Text + "</aac003>";
            data += "<akc194>" + cyjsCyrq.Text + "</akc194>";
            data += "<akc195>" + comboCyyy.SelectedValue.ToString() + "</akc195>";
            data += "<akc196>" + cyjsjbbm.Text + "</akc196>";
            data += "<ints>" + zyts + "</ints>";

            try
            {
                string sql_ryjl = @"SELECT
	                                     case when inhospital.sex='M' then 1 else 2 end AS aac004,
	                                     DATE_FORMAT(inhospital.birthday,'%Y-%m-%d') AS aac006,
	                                     ihsp_info.homephone AS aac008,
	                                     ihsp_info.homeaddress AS aac010,
	                                     '入院记录--主诉' AS blz060,
	                                     '入院记录--现病史' AS blz061,
	                                     '入院记录--既往史' AS blz062,
	                                     '入院记录--个人史' AS blz063,
	                                     '入院记录--月经及生育史' AS blz064,
 	                                     '入院记录--家族史' AS blz065,
 	                                     '入院记录--体格检查' AS blz066,
 	                                     '入院记录--辅助检查' AS blz067,
 	                                     '入院记录--初步诊断' AS blz068
	                                FROM inhospital,ihsp_info
	                                WHERE inhospital.id=ihsp_info.ihsp_id and ihsp_info.registkind='IHSP' AND inhospital.id =" + mtzyjl_iid;
                DataTable dt_ryjl = BllMain.Db.Select(sql_ryjl).Tables[0];
                if (dt_ryjl.Rows.Count != 0)
                {
                    data += "<km02s>";
                    data += "<km02>";
                    data += "<aac004>" + dt_ryjl.Rows[0]["aac004"].ToString().Trim() + "</aac004>";
                    data += "<aac006>" + dt_ryjl.Rows[0]["aac006"].ToString().Trim() + "</aac006>";
                    data += "<aac008>" + dt_ryjl.Rows[0]["aac008"].ToString().Trim() + "</aac008>";
                    data += "<aac010>" + dt_ryjl.Rows[0]["aac010"].ToString().Trim() + "</aac010>";
                    data += "<blz060>" + dt_ryjl.Rows[0]["blz060"].ToString().Trim() + "</blz060>";
                    data += "<blz061>" + dt_ryjl.Rows[0]["blz061"].ToString().Trim() + "</blz061>";
                    data += "<blz062>" + dt_ryjl.Rows[0]["blz062"].ToString().Trim() + "</blz062>";
                    data += "<blz063>" + dt_ryjl.Rows[0]["blz063"].ToString().Trim() + "</blz063>";
                    data += "<blz064>" + dt_ryjl.Rows[0]["blz064"].ToString().Trim() + "</blz064>";
                    data += "<blz065>" + dt_ryjl.Rows[0]["blz065"].ToString().Trim() + "</blz065>";
                    data += "<blz066>" + dt_ryjl.Rows[0]["blz066"].ToString().Trim() + "</blz066>";
                    data += "<blz067>" + dt_ryjl.Rows[0]["blz067"].ToString().Trim() + "</blz067>";
                    data += "<blz068>" + dt_ryjl.Rows[0]["blz068"].ToString().Trim() + "</blz068>";
                    data += "</km02>";
                    data += "</km02s>";
                }
            }
            catch { }
            try
            {
                string sql_cyjl = @"SELECT
	                                      case when inhospital.sex='M' then 1 else 2 end AS aac004,
	                                      DATE_FORMAT(inhospital.birthday,'%Y-%m-%d') AS aac006,
	                                      ihsp_info.homephone AS aac008,
	                                      ihsp_info.homeaddress AS aac010,
	                                      '出院记录--出院情况' AS blc074,
	                                      '出院记录--出院医嘱' AS blc075,
	                                      '入院情况' AS blz070,
	                                      inhospital.ihspdiagn AS blz071,
 	                                      '诊断经过' AS blz072,
 	                                      '出院诊断' AS blz073
	                                 FROM  inhospital,ihsp_info
	                                 WHERE inhospital.id=ihsp_info.ihsp_id and ihsp_info.registkind='IHSP' AND inhospital.id =" + mtzyjl_iid;
                DataTable dt_cyjl = BllMain.Db.Select(sql_cyjl).Tables[0];
                if (dt_cyjl.Rows.Count != 0)
                {
                    data += "<km03s>";
                    data += "<km03>";
                    data += "<aac004>" + dt_cyjl.Rows[0]["aac004"].ToString().Trim() + "</aac004>";
                    data += "<aac006>" + dt_cyjl.Rows[0]["aac006"].ToString().Trim() + "</aac006>";
                    data += "<aac008>" + dt_cyjl.Rows[0]["aac008"].ToString().Trim() + "</aac008>";
                    data += "<aac010>" + dt_cyjl.Rows[0]["aac010"].ToString().Trim() + "</aac010>";
                    data += "<blc074>" + dt_cyjl.Rows[0]["blc074"].ToString().Trim() + "</blc074>";
                    data += "<blc075>" + dt_cyjl.Rows[0]["blc075"].ToString().Trim() + "</blc075>";
                    data += "<blz070>" + dt_cyjl.Rows[0]["blz070"].ToString().Trim() + "</blz070>";
                    data += "<blz071>" + dt_cyjl.Rows[0]["blz071"].ToString().Trim() + "</blz071>";
                    data += "<blz072>" + dt_cyjl.Rows[0]["blz072"].ToString().Trim() + "</blz072>";
                    data += "<blz073>" + dt_cyjl.Rows[0]["blz073"].ToString().Trim() + "</blz073>";
                    data += "</km03>";
                    data += "</km03s>";
                }
            }
            catch { }
            try
            {
                string sql_ssjl = @"SELECT (select opicd from oper_recorddet where oper_recorddet.oper_record_id=oper_record.id) AS opr030,
	                                       DATE_FORMAT(oper_record.appopdate,'%Y-%m-%d') AS opr031,
	                                       (select sys_dict.`name` from oper_recorddet,sys_dict where oper_recorddet.oper_class_id=sys_dict.sn and sys_dict.dicttype='oper_class' AND oper_recorddet.oper_record_id=oper_record.id) AS opr032,
	                                       (select `name` from oper_recorddet where oper_recorddet.oper_record_id=oper_record.id) AS opr033,
	                                       (select oper_operator.name from oper_operator where oper_operator.operatortype='OPER' and oper_operator.charged='Y' and oper_operator.oper_record_id=oper_record.id ) AS opr040,
	                                       (select oper_operator.name from oper_operator where oper_operator.operatortype='OPER' and oper_operator.charged='N' and oper_operator.oper_record_id=oper_record.id limit 1) AS opr041,
	                                       '' AS opr042,
	                                       (select sys_dict.`name` from oper_recorddet,sys_dict where oper_recorddet.oper_class_id=sys_dict.sn and sys_dict.dicttype='oper_hocusType' AND oper_recorddet.oper_record_id=oper_record.id) AS opr043,
	                                       (select oper_operator.name from oper_operator where oper_operator.operatortype='HOCUSER' and oper_operator.oper_record_id=oper_record.id limit 1 )  AS opr044
	                                 FROM oper_record WHERE	oper_record.registkind='IHSP' and oper_record.ihsp_id=" + mtzyjl_iid;
                DataTable dt_ssjl = BllMain.Db.Select(sql_ssjl).Tables[0];
                if (dt_ssjl.Rows.Count != 0)
                {
                    data += "<km04s>";
                    data += "<km04>";
                    data += "<opr030>" + dt_ssjl.Rows[0]["opr030"].ToString().Trim() + "</opr030>";
                    data += "<opr031>" + dt_ssjl.Rows[0]["opr031"].ToString().Trim() + "</opr031>";
                    data += "<opr032>" + dt_ssjl.Rows[0]["opr032"].ToString().Trim() + "</opr032>";
                    data += "<opr033>" + dt_ssjl.Rows[0]["opr033"].ToString().Trim() + "</opr033>";
                    data += "<opr040>" + dt_ssjl.Rows[0]["opr040"].ToString().Trim() + "</opr040>";
                    data += "<opr041>" + dt_ssjl.Rows[0]["opr041"].ToString().Trim() + "</opr041>";
                    data += "<opr042>" + dt_ssjl.Rows[0]["opr042"].ToString().Trim() + "</opr042>";
                    data += "<opr043>" + dt_ssjl.Rows[0]["opr043"].ToString().Trim() + "</opr043>";
                    data += "<opr044>" + dt_ssjl.Rows[0]["opr044"].ToString().Trim() + "</opr044>";
                    data += "</km04>";
                    data += "</km04s>";
                }
            }
            catch { }
            try
            {
                string sql_basy = @"SELECT '井陉县中医医院' AS aab034,
     	                                   '40177945-7' AS aab301,
     	                                   ihsp_info.idcard AS aac002,
     	                                   inhospital.`name` AS aac003,
     	                                   case when inhospital.sex='M' then 1 else 2 end  AS aac004,
     	                                   ihsp_info.race AS aac005,
     	                                   DATE_FORMAT(inhospital.birthday,'%Y-%m-%d') AS aac006,
     	                                   ihsp_info.birthplace AS aac009,
     	                                   ihsp_info.nativeplace AS aac010,
     	                                   ihsp_info.profession AS aac020,
     	                                   ihsp_info.marriage AS aac021,
      	                                   ihsp_info.companyphone AS aad005,
      	                                   ihsp_info.companyzip AS aad007,
     	                                    CONCAT(ihsp_info.companyname,ihsp_info.companyaddr) AS aad010,
     	                                    ihsp_info.homephone AS aae005,
     	                                   ihsp_info.homeaddress AS aae006,
      	                                   ihsp_info.homezip AS aae007,
     	                                    ihsp_info.residenceaddress AS aae010,
      	                                   ihsp_info.residencezip AS aae017,
      	                                   ihsp_info.contactname AS aam003,
     	                                    ihsp_info.contactphone AS aam005,
     	                                    ihsp_info.contactaddress AS aam010,
      	                                   (select name from ihsp_contactrelation where id=ihsp_info.contactrelation_id) AS aam036,
      	                                   '中国' AS akc020,
      	                                   inhospital.age AS akc023,
      	                                   DATE_FORMAT(inhospital.indate,'%Y-%m-%d') AS akc192,
      	                                   DATE_FORMAT(inhospital.outdate,'%Y-%m-%d') AS akc194,
      	                                   inhospital.clinicicd AS alc028,
      	                                   '' AS alc029,  
      	                                   '' AS alc030, 
      	                                   '' AS blm001,
      	                                   inhospital.ihspsn AS blm002,
      	                                   inhospital.casecode AS blm003,
      	                                   CASE inhospital.bas_ihspsource_id WHEN 1 THEN	'急诊' WHEN 2 THEN	'门诊' WHEN 3 THEN	'其他医疗机构转入' ELSE	'其它' END AS blm004,
     	                                    bas_depart.`name` AS blm005,
     	                                    bas_sickroom.`name` AS blm006,
     	                                    '' AS blm007,
     	                                    bas_depart.`name` AS blm009,
     	                                    bas_sickroom.`name` AS blm010,
     	                                    TO_DAYS(outdate) - TO_DAYS(indate) AS blm011,
     	                                    '' AS blm012,
     	                                    '' AS blm013,
     	                                    '' AS blm014,
     	                                    '' AS blm015,
     	                                    '' AS blm016,
     	                                    '否' AS blm017,
     	                                    CASE ihsp_info.bloodtype WHEN 1 THEN	'A' WHEN 2 THEN	'B' WHEN 3 THEN	'AB' WHEN 4 THEN	'O' WHEN 6 THEN	'未做' ELSE	'其它' END AS blm018,
      	                                   CASE ihsp_info.rh WHEN 1 THEN	'阴' WHEN 2 THEN	'阳' WHEN 3 THEN	'不详' ELSE	'未查' END AS blm019,
      	                                   '' AS blm020,
      	                                   '' AS blm021,
      	                                   '' AS blm022,
      	                                   '' AS blm023,
      	                                   '' AS blm024,
     	                                    '' AS blm025,
     	                                    '' AS blm026,
     	                                    '' AS blm027,
     	                                    '' AS blm028,
     	                                    '' AS blm029,
     	                                    '' AS blm030,
     	                                    '' AS blm031,
     	                                   '医嘱离院' AS blm032,
     	                                    '' AS blm033,
     	                                    '' AS blm034,
     	                                    '' AS blm035,
      	                                   '' AS blm036,
     	                                    '' AS blm037,
     	                                    '' AS blm038,
     	                                    '' AS blm039,
     	                                    '' AS blm040,
     	                                    '' AS blm041,
     	                                    '' AS blm042,
     	                                    '' AS blm043,
     	                                    inhospital.clinicdiagn AS blz068
     	                                   FROM	inhospital,ihsp_info,bas_depart,bas_sickroom 
     	                                   WHERE  inhospital.id=ihsp_info.ihsp_id and ihsp_info.registkind='IHSP' and inhospital.depart_id=bas_depart.id and inhospital.sickroom_id=bas_sickroom.id
                                                  AND inhospital.id=" + mtzyjl_iid;

                DataTable dt_basy = BllMain.Db.Select(sql_basy).Tables[0];
                if (dt_basy.Rows.Count != 0)
                {
                    data += "<km05s>";
                    data += "<km05>";
                    data += "<aab034>" + dt_basy.Rows[0]["aab034"].ToString().Trim() + "</aab034>";
                    data += "<aab301>" + dt_basy.Rows[0]["aab301"].ToString().Trim() + "</aab301>";
                    data += "<aac002>" + dt_basy.Rows[0]["aac002"].ToString().Trim() + "</aac002>";
                    data += "<aac003>" + dt_basy.Rows[0]["aac003"].ToString().Trim() + "</aac003>";
                    data += "<aac004>" + dt_basy.Rows[0]["aac004"].ToString().Trim() + "</aac004>";
                    data += "<aac005>" + dt_basy.Rows[0]["aac005"].ToString().Trim() + "</aac005>";
                    data += "<aac006>" + dt_basy.Rows[0]["aac006"].ToString().Trim() + "</aac006>";
                    data += "<aac009>" + dt_basy.Rows[0]["aac009"].ToString().Trim() + "</aac009>";
                    data += "<aac010>" + dt_basy.Rows[0]["aac010"].ToString().Trim() + "</aac010>";
                    data += "<aac020>" + dt_basy.Rows[0]["aac020"].ToString().Trim() + "</aac020>";
                    data += "<aac021>" + dt_basy.Rows[0]["aac021"].ToString().Trim() + "</aac021>";
                    data += "<aad005>" + dt_basy.Rows[0]["aad005"].ToString().Trim() + "</aad005>";
                    data += "<aad007>" + dt_basy.Rows[0]["aad007"].ToString().Trim() + "</aad007>";
                    data += "<aad010>" + dt_basy.Rows[0]["aad010"].ToString().Trim() + "</aad010>";
                    data += "<aae005>" + dt_basy.Rows[0]["aae005"].ToString().Trim() + "</aae005>";
                    data += "<aae006>" + dt_basy.Rows[0]["aae006"].ToString().Trim() + "</aae006>";
                    data += "<aae007>" + dt_basy.Rows[0]["aae007"].ToString().Trim() + "</aae007>";
                    data += "<aae010>" + dt_basy.Rows[0]["aae010"].ToString().Trim() + "</aae010>";
                    data += "<aae017>" + dt_basy.Rows[0]["aae017"].ToString().Trim() + "</aae017>";
                    data += "<aam003>" + dt_basy.Rows[0]["aam003"].ToString().Trim() + "</aam003>";
                    data += "<aam005>" + dt_basy.Rows[0]["aam005"].ToString().Trim() + "</aam005>";
                    data += "<aam010>" + dt_basy.Rows[0]["aam010"].ToString().Trim() + "</aam010>";
                    data += "<aam036>" + dt_basy.Rows[0]["aam036"].ToString().Trim() + "</aam036>";
                    data += "<akc020>" + dt_basy.Rows[0]["akc020"].ToString().Trim() + "</akc020>";
                    data += "<akc023>" + dt_basy.Rows[0]["akc023"].ToString().Trim() + "</akc023>";
                    data += "<akc192>" + dt_basy.Rows[0]["akc192"].ToString().Trim() + "</akc192>";
                    data += "<akc194>" + dt_basy.Rows[0]["akc194"].ToString().Trim() + "</akc194>";
                    data += "<alc028>" + dt_basy.Rows[0]["alc028"].ToString().Trim() + "</alc028>";
                    data += "<alc029>" + dt_basy.Rows[0]["alc029"].ToString().Trim() + "</alc029>";
                    data += "<alc030>" + dt_basy.Rows[0]["alc030"].ToString().Trim() + "</alc030>";
                    data += "<blm001>" + dt_basy.Rows[0]["blm001"].ToString().Trim() + "</blm001>";
                    data += "<blm002>" + dt_basy.Rows[0]["blm002"].ToString().Trim() + "</blm002>";
                    data += "<blm003>" + dt_basy.Rows[0]["blm003"].ToString().Trim() + "</blm003>";
                    data += "<blm004>" + dt_basy.Rows[0]["blm004"].ToString().Trim() + "</blm004>";
                    data += "<blm005>" + dt_basy.Rows[0]["blm005"].ToString().Trim() + "</blm005>";
                    data += "<blm006>" + dt_basy.Rows[0]["blm006"].ToString().Trim() + "</blm006>";
                    data += "<blm007>" + dt_basy.Rows[0]["blm007"].ToString().Trim() + "</blm007>";
                    data += "<blm009>" + dt_basy.Rows[0]["blm009"].ToString().Trim() + "</blm009>";
                    data += "<blm010>" + dt_basy.Rows[0]["blm010"].ToString().Trim() + "</blm010>";
                    data += "<blm011>" + dt_basy.Rows[0]["blm011"].ToString().Trim() + "</blm011>";
                    data += "<blm012>" + dt_basy.Rows[0]["blm012"].ToString().Trim() + "</blm012>";
                    data += "<blm013>" + dt_basy.Rows[0]["blm013"].ToString().Trim() + "</blm013>";
                    data += "<blm014>" + dt_basy.Rows[0]["blm014"].ToString().Trim() + "</blm014>";
                    data += "<blm015>" + dt_basy.Rows[0]["blm015"].ToString().Trim() + "</blm015>";
                    data += "<blm016>" + dt_basy.Rows[0]["blm016"].ToString().Trim() + "</blm016>";
                    data += "<blm017>" + dt_basy.Rows[0]["blm017"].ToString().Trim() + "</blm017>";
                    data += "<blm018>" + dt_basy.Rows[0]["blm018"].ToString().Trim() + "</blm018>";
                    data += "<blm019>" + dt_basy.Rows[0]["blm019"].ToString().Trim() + "</blm019>";
                    data += "<blm020>" + dt_basy.Rows[0]["blm020"].ToString().Trim() + "</blm020>";
                    data += "<blm021>" + dt_basy.Rows[0]["blm021"].ToString().Trim() + "</blm021>";
                    data += "<blm022>" + dt_basy.Rows[0]["blm022"].ToString().Trim() + "</blm022>";
                    data += "<blm023>" + dt_basy.Rows[0]["blm023"].ToString().Trim() + "</blm023>";
                    data += "<blm024>" + dt_basy.Rows[0]["blm024"].ToString().Trim() + "</blm024>";
                    data += "<blm025>" + dt_basy.Rows[0]["blm025"].ToString().Trim() + "</blm025>";
                    data += "<blm026>" + dt_basy.Rows[0]["blm026"].ToString().Trim() + "</blm026>";
                    data += "<blm027>" + dt_basy.Rows[0]["blm027"].ToString().Trim() + "</blm027>";
                    data += "<blm028>" + dt_basy.Rows[0]["blm028"].ToString().Trim() + "</blm028>";
                    data += "<blm029>" + dt_basy.Rows[0]["blm029"].ToString().Trim() + "</blm029>";
                    data += "<blm030>" + dt_basy.Rows[0]["blm030"].ToString().Trim() + "</blm030>";
                    data += "<blm031>" + dt_basy.Rows[0]["blm031"].ToString().Trim() + "</blm031>";
                    data += "<blm032>" + dt_basy.Rows[0]["blm032"].ToString().Trim() + "</blm032>";
                    data += "<blm033>" + dt_basy.Rows[0]["blm033"].ToString().Trim() + "</blm033>";
                    data += "<blm034>" + dt_basy.Rows[0]["blm034"].ToString().Trim() + "</blm034>";
                    data += "<blm035>" + dt_basy.Rows[0]["blm035"].ToString().Trim() + "</blm035>";
                    data += "<blm036>" + dt_basy.Rows[0]["blm036"].ToString().Trim() + "</blm036>";
                    data += "<blm037>" + dt_basy.Rows[0]["blm037"].ToString().Trim() + "</blm037>";
                    data += "<blm038>" + dt_basy.Rows[0]["blm038"].ToString().Trim() + "</blm038>";
                    data += "<blm039>" + dt_basy.Rows[0]["blm039"].ToString().Trim() + "</blm039>";
                    data += "<blm040>" + dt_basy.Rows[0]["blm040"].ToString().Trim() + "</blm040>";
                    data += "<blm041>" + dt_basy.Rows[0]["blm041"].ToString().Trim() + "</blm041>";
                    data += "<blm042>" + dt_basy.Rows[0]["blm042"].ToString().Trim() + "</blm042>";
                    data += "<blm043>" + dt_basy.Rows[0]["blm043"].ToString().Trim() + "</blm043>";
                    data += "<blm068>" + dt_basy.Rows[0]["blz068"].ToString().Trim() + "</blm068>";
                    data += "</km05>";
                    data += "</km05s>";
                }
            }
            catch { }
            try
            {
                string sql_bcbg = @"SELECT (select sys_dict.`name` from sys_dict where chk_app.chk_bodypart_id=sys_dict.sn and sys_dict.dicttype='chk_bodypart') AS kcb001,
	                                       chk_app.billcode AS kcb002,
	                                       DATE_FORMAT(chk_app.execdate,'%Y-%m-%d') AS kcb003,
	                                       chk_chkdetail.objectiveresult AS kcb004,
	                                       chk_chkdetail.subjectiveresult AS kcb005,
	                                       (select bas_doctor.`name` from bas_doctor where bas_doctor.id=chk_app.exedoctor_id) AS kcb006,
	                                       (select bas_doctor.`name` from bas_doctor where bas_doctor.id=chk_app.chkleader_id) AS kcb007
	                                 FROM chk_app,chk_chkdetail
                                     WHERE chk_app.id=chk_chkdetail.chk_app_id and chk_app.registKind='IHSP' and chk_app.chkkind='CHK' and chk_app.exedep_id=16 and chk_app.diagnsetname like '彩色超声%'
	                                       and chk_app.regist_id=" + mtzyjl_iid;
                //string sql_bcbg = "select 123 as kcb001,12 as kcb002,'2014-11-03' as kcb003,111 as kcb004,11111 as kcb005,11111 as kcb006,2323 as kcb007 from mtzyjl limit 1 ";//,mtjc,mtjcjl,mtjcxm,ctct jcys,ctct shys,projecttype where mtjc.iid = mtjcjl.mtjc and mtjcjl.jcjljcxm = mtjcxm.iid and jcys.iid = mtjc.jyysubmittedby and shys.iid = mtjc.jcsjys and mtjc.jczyjl = mtzyjl.iid and mtjcxm.projecttype2 = projecttype.iid and projecttype.name = 'B超' and mtzyjl.iid =" + mtzyjl_iid;

                DataTable dt_bcbg = BllMain.Db.Select(sql_bcbg).Tables[0];
                if (dt_bcbg.Rows.Count != 0)
                {
                    data += "<km06s>";
                    data += "<km06>";
                    data += "<kcb001>" + dt_bcbg.Rows[0]["kcb001"].ToString().Trim() + "</kcb001>";
                    data += "<kcb002>" + dt_bcbg.Rows[0]["kcb002"].ToString().Trim() + "</kcb002>";
                    data += "<kcb003>" + dt_bcbg.Rows[0]["kcb003"].ToString().Trim() + "</kcb003>";
                    data += "<kcb004>" + dt_bcbg.Rows[0]["kcb004"].ToString().Trim() + "</kcb004>";
                    data += "<kcb005>" + dt_bcbg.Rows[0]["kcb005"].ToString().Trim() + "</kcb005>";
                    data += "<kcb006>" + dt_bcbg.Rows[0]["kcb006"].ToString().Trim() + "</kcb006>";
                    data += "<kcb007>" + dt_bcbg.Rows[0]["kcb007"].ToString().Trim() + "</kcb007>";
                    data += "</km06>";
                    data += "</km06s>";
                }
            }
            catch { }
            try
            {
                string sql_xgbg = @"SELECT (select sys_dict.`name` from sys_dict where chk_app.chk_bodypart_id=sys_dict.sn and sys_dict.dicttype='chk_bodypart') AS kcx001,
	                                       chk_app.billcode AS kcx002,
	                                       DATE_FORMAT(chk_app.execdate,'%Y-%m-%d') AS kcx003,
	                                       chk_chkdetail.objectiveresult AS kcx004,
	                                       chk_chkdetail.subjectiveresult AS kcx005,
	                                       (select bas_doctor.`name` from bas_doctor where bas_doctor.id=chk_app.exedoctor_id) AS kcx006,
	                                       (select bas_doctor.`name` from bas_doctor where bas_doctor.id=chk_app.chkleader_id) AS kcx007
	                                 FROM chk_app,chk_chkdetail
                                     WHERE chk_app.id=chk_chkdetail.chk_app_id and chk_app.registKind='IHSP' and chk_app.chkkind='CHK' and chk_app.exedep_id=30 and chk_app.diagnsetname like 'DR%'
	                                       and chk_app.regist_id=" + mtzyjl_iid;
                //string sql_xgbg = "select 	5646 as kcx001,345345 as kcx002,'2014-11-03' as  kcx003,8676 as kcx004,12314 as kcx005,12314 as kcx006,123124 as kcx007 from	mtzyjl limit 1";//,mtjc,mtjcjl,mtjcxm,ctct jcys,ctct shys,projecttype where mtjc.iid = mtjcjl.mtjc 	and mtjcjl.jcjljcxm = mtjcxm.iid and jcys.iid = mtjc.jyysubmittedby and shys.iid = mtjc.jcsjys and mtjc.jczyjl = mtzyjl.iid and mtjcxm.projecttype2 = projecttype.iid and projecttype.name = 'X光' and mtzyjl.iid =" + mtzyjl_iid;

                DataTable dt_xgbg = BllMain.Db.Select(sql_xgbg).Tables[0];
                if (dt_xgbg.Rows.Count != 0)
                {
                    data += "<km07s>";
                    data += "<km07>";
                    data += "<kcx001>" + dt_xgbg.Rows[0]["kcx001"].ToString().Trim() + "</kcx001>";
                    data += "<kcx002>" + dt_xgbg.Rows[0]["kcx002"].ToString().Trim() + "</kcx002>";
                    data += "<kcx003>" + dt_xgbg.Rows[0]["kcx003"].ToString().Trim() + "</kcx003>";
                    data += "<kcx004>" + dt_xgbg.Rows[0]["kcx004"].ToString().Trim() + "</kcx004>";
                    data += "<kcx005>" + dt_xgbg.Rows[0]["kcx005"].ToString().Trim() + "</kcx005>";
                    data += "<kcx006>" + dt_xgbg.Rows[0]["kcx006"].ToString().Trim() + "</kcx006>";
                    data += "<kcx007>" + dt_xgbg.Rows[0]["kcx007"].ToString().Trim() + "</kcx007>";
                    data += "</km07>";
                    data += "</km07s>";
                }
            }
            catch { }
            try
            {
                string sql_ctbg = @"SELECT (select sys_dict.`name` from sys_dict where chk_app.chk_bodypart_id=sys_dict.sn and sys_dict.dicttype='chk_bodypart') AS kcc001,
	                                       chk_app.billcode AS kcc002,
	                                       DATE_FORMAT(chk_app.execdate,'%Y-%m-%d') AS kcc003,
	                                       chk_chkdetail.objectiveresult AS kcc004,
	                                       chk_chkdetail.subjectiveresult AS kcc005,
	                                       (select bas_doctor.`name` from bas_doctor where bas_doctor.id=chk_app.exedoctor_id) AS kcc006,
	                                       (select bas_doctor.`name` from bas_doctor where bas_doctor.id=chk_app.chkleader_id) AS kcc007
	                                 FROM chk_app,chk_chkdetail
                                     WHERE chk_app.id=chk_chkdetail.chk_app_id and chk_app.registKind='IHSP' and chk_app.chkkind='CHK' and chk_app.exedep_id=30 and chk_app.diagnsetname like 'CT%'
	                                       and chk_app.regist_id=" + mtzyjl_iid;
                //string sql_ctbg = "select 8768 as kcc001,6787 as kcc002,'2014-11-03' as kcc003,23423 as kcc004,234234 as kcc005,234234 as kcc006,5656 as kcc007 from	mtzyjl limit 1 ";//,mtjc,mtjcjl,mtjcxm,ctct jcys,ctct shys,projecttype where mtjc.iid = mtjcjl.mtjc and mtjcjl.jcjljcxm = mtjcxm.iid	and jcys.iid = mtjc.jyysubmittedby and shys.iid = mtjc.jcsjys and mtjc.jczyjl = mtzyjl.iid and mtjcxm.projecttype2= projecttype.iid and projecttype.name = 'CT' and mtzyjl.iid =" + mtzyjl_iid;

                DataTable dt_ctbg = BllMain.Db.Select(sql_ctbg).Tables[0];
                if (dt_ctbg.Rows.Count != 0)
                {
                    data += "<km08s>";
                    data += "<km08>";
                    data += "<kcc001>" + dt_ctbg.Rows[0]["kcc001"].ToString().Trim() + "</kcc001>";
                    data += "<kcc002>" + dt_ctbg.Rows[0]["kcc002"].ToString().Trim() + "</kcc002>";
                    data += "<kcc003>" + dt_ctbg.Rows[0]["kcc003"].ToString().Trim() + "</kcc003>";
                    data += "<kcc004>" + dt_ctbg.Rows[0]["kcc004"].ToString().Trim() + "</kcc004>";
                    data += "<kcc005>" + dt_ctbg.Rows[0]["kcc005"].ToString().Trim() + "</kcc005>";
                    data += "<kcc006>" + dt_ctbg.Rows[0]["kcc006"].ToString().Trim() + "</kcc006>";
                    data += "<kcc007>" + dt_ctbg.Rows[0]["kcc007"].ToString().Trim() + "</kcc007>";
                    data += "</km08>";
                    data += "</km08s>";
                }
            }
            catch { }
            try
            {
                string sql_hcbg = @"SELECT (select sys_dict.`name` from sys_dict where chk_app.chk_bodypart_id=sys_dict.sn and sys_dict.dicttype='chk_bodypart') AS kch001,
	                                       chk_app.billcode AS kch002,
	                                       DATE_FORMAT(chk_app.execdate,'%Y-%m-%d') AS kch003,
	                                       chk_chkdetail.objectiveresult AS kch004,
	                                       chk_chkdetail.subjectiveresult AS kch005,
	                                       (select bas_doctor.`name` from bas_doctor where bas_doctor.id=chk_app.exedoctor_id) AS kch006,
	                                       (select bas_doctor.`name` from bas_doctor where bas_doctor.id=chk_app.chkleader_id) AS kch007,
                                           '' as kch008
	                                 FROM chk_app,chk_chkdetail
                                     WHERE chk_app.id=chk_chkdetail.chk_app_id and chk_app.registKind='IHSP' and chk_app.chkkind='CHK' and chk_app.exedep_id=30 and chk_app.diagnsetname like '磁共振%'
	                                       and chk_app.regist_id=" + mtzyjl_iid;
                //string sql_hcbg = "select 	123123 as kch001,3333 as kch002,'2014-11-03' as kch003,56578 as kch004,123123 as kch005,4353453 as kch006,343434 as kch007,'' as kch008 from mtzyjl limit 1 ";//,mtjc,mtjcjl,mtjcxm,ctct jcys,ctct shys,projecttype where mtjc.iid = mtjcjl.mtjc and mtjcjl.jcjljcxm = mtjcxm.iid and jcys.iid = mtjc.jyysubmittedby	and shys.iid = mtjc.jcsjys and mtjc.jczyjl = mtzyjl.iid	and mtjcxm.projecttype2 = projecttype.iid and projecttype.name = '核磁'	and mtzyjl.iid =" + mtzyjl_iid;

                DataTable dt_hcbg = BllMain.Db.Select(sql_hcbg).Tables[0];
                if (dt_hcbg.Rows.Count != 0)
                {
                    data += "<km09s>";
                    data += "<km09>";
                    data += "<kch001>" + dt_hcbg.Rows[0]["kch001"].ToString().Trim() + "</kch001>";
                    data += "<kch002>" + dt_hcbg.Rows[0]["kch002"].ToString().Trim() + "</kch002>";
                    data += "<kch003>" + dt_hcbg.Rows[0]["kch003"].ToString().Trim() + "</kch003>";
                    data += "<kch004>" + dt_hcbg.Rows[0]["kch004"].ToString().Trim() + "</kch004>";
                    data += "<kch005>" + dt_hcbg.Rows[0]["kch005"].ToString().Trim() + "</kch005>";
                    data += "<kch006>" + dt_hcbg.Rows[0]["kch006"].ToString().Trim() + "</kch006>";
                    data += "<kch007>" + dt_hcbg.Rows[0]["kch007"].ToString().Trim() + "</kch007>";
                    data += "<kch008>" + dt_hcbg.Rows[0]["kch008"].ToString().Trim() + "</kch008>";
                    data += "</km09>";
                    data += "</km09s>";
                }
            }
            catch { }
            data += " </leaveReqData>";

            in1.YwData = Base64.encodebase64(in1.head() + data);

            out1 = GSBXinterface.request(in1);
            if (out1.State == "2")
            {
                MessageBox.Show("工伤保险提示！\r\n" + in1.Log_name + "出错！\r\n【" + out1.Message + "】");
                string flag11 = dldc.dengchu(sessionid);
                if (flag11 == "1")
                {
                    MessageBox.Show(dldc.Message);
                    return;
                }
                sessionid = ""; return;
            }

            out1.State = out1.Ds.Tables["leaveRespData"].Rows[0]["code"].ToString().Trim();
            out1.Message = out1.Ds.Tables["leaveRespData"].Rows[0]["msg"].ToString().Trim();
            if (out1.State != "0")
            {
                MessageBox.Show("工伤保险提示！\r\n" + in1.Log_name + "出错！\r\n【" + out1.Message + "】");
                string flag11 = dldc.dengchu(sessionid);
                if (flag11 == "1")
                {
                    MessageBox.Show(dldc.Message);
                    return;
                }
                sessionid = "";
                return;
            }
            string flag1 = dldc.dengchu(sessionid);
            if (flag1 == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = "";
            string sql_cysj = "select outdate from inhospital where id=" + mtzyjl_iid;
            DataTable dt_cysj = BllMain.Db.Select(sql_cysj).Tables[0];
            String updatesql = " update inhospital set nhflag=502 where id=" + mtzyjl_iid + ";";
            updatesql += " update gsryinfo set jssj='" + cyjsCyrq.Text.Trim() + "' where id=" + mtzyjl_iid + ";";
            if (BllMain.Db.Update(updatesql) == -1)
            {
                SysWriteLogs.writeLogs1("工伤出院成功，但更新HIS标志失败！", DateTime.Now, "sql=" + updatesql);
                MessageBox.Show("工伤出院成功，但更新HIS标志失败！");
            }
            MessageBox.Show("出院成功！");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string flag = dldc.dengru();
            if (flag == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = dldc.Sessionid;
            in1.Log_name = "leaveHosUndo";
            in1.YwName = "leaveHosUndo";
            string data = "<cyundoReqData>";
            data += " <sessionid>" + sessionid + "</sessionid>";
            data += " <akc190>" + cyjsZyh.Text.Trim() + "</akc190>";
            data += " </cyundoReqData>";
            in1.YwData = Base64.encodebase64(in1.head() + data);

            out1 = GSBXinterface.request(in1);
            if (out1.State == "2")
            {
                MessageBox.Show("工伤保险提示！\r\n" + in1.Log_name + "出错！\r\n【" + out1.Message + "】");
                string flag11 = dldc.dengchu(sessionid);
                if (flag11 == "1")
                {
                    MessageBox.Show(dldc.Message);
                    return;
                }
                sessionid = ""; return;
            }

            out1.State = out1.Ds.Tables["cyundoRespData"].Rows[0]["code"].ToString().Trim();
            out1.Message = out1.Ds.Tables["cyundoRespData"].Rows[0]["msg"].ToString().Trim();
            if (out1.State != "0")
            {
                MessageBox.Show("工伤保险提示！\r\n" + in1.Log_name + "出错！\r\n【" + out1.Message + "】");
                string flag11 = dldc.dengchu(sessionid);
                if (flag11 == "1")
                {
                    MessageBox.Show(dldc.Message);
                    return;
                }
                sessionid = "";
                return;
            }

            string flag1 = dldc.dengchu(sessionid);
            if (flag1 == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = "";
            string sql = "update inhospital set nhflag=501 where id=" + mtzyjl_iid;//_iid.ToString().Trim();
            BllMain.Db.Update(sql);
            MessageBox.Show("撤销出院成功！");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.tbx_jmylzh.Text.Trim()))
            {
                MessageBox.Show("请输入身份证号！");
                return;
            }
            string flag = dldc.dengru();
            if (flag == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = dldc.Sessionid;
            in1.Log_name = "getReport";
            in1.YwName = "getReport";
            string data = "<getReportReqData>";
            data += " <sessionid>" + sessionid + "</sessionid>";
            data += " <aac001>" + cyjsGrbh.Text.Trim() + "</aac001>";
            data += " </getReportReqData>";
            in1.YwData = Base64.encodebase64(in1.head() + data);

            out1 = GSBXinterface.request(in1);
            if (out1.State == "2")
            {
                MessageBox.Show("工伤保险提示！\r\n" + in1.Log_name + "出错！\r\n【" + out1.Message + "】");
                string flag11 = dldc.dengchu(sessionid);
                if (flag11 == "1")
                {
                    MessageBox.Show(dldc.Message);
                    return;
                }
                sessionid = ""; return;
            }

            out1.State = out1.Ds.Tables["getReportRespData"].Rows[0]["code"].ToString().Trim();
            out1.Message = out1.Ds.Tables["getReportRespData"].Rows[0]["msg"].ToString().Trim();
            if (out1.State != "0")
            {
                MessageBox.Show("工伤保险提示！\r\n" + in1.Log_name + "出错！\r\n【" + out1.Message + "】");
                string flag11 = dldc.dengchu(sessionid);
                if (flag11 == "1")
                {
                    MessageBox.Show(dldc.Message);
                    return;
                }
                sessionid = "";
                return;
            }

            dataGridView2.DataSource = out1.Ds.Tables["ldc1"];
            string flag1 = dldc.dengchu(sessionid);
            if (flag1 == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = "";
            dataGridView2.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string flag = dldc.dengru();
            if (flag == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = dldc.Sessionid;
            in1.Log_name = "getAuditData";
            in1.YwName = "getAuditData";
            string data = "<auditReqData>";
            data += " <sessionid>" + sessionid + "</sessionid>";
            data += " <akc190>" + cyjsZyh.Text.Trim() + "</akc190>";
            data += "<aae002></aae002>";
            data += " </auditReqData>";
            in1.YwData = Base64.encodebase64(in1.head() + data);

            out1 = GSBXinterface.request(in1);
            if (out1.State == "2")
            {
                MessageBox.Show("工伤保险提示！\r\n" + in1.Log_name + "出错！\r\n【" + out1.Message + "】");
                string flag11 = dldc.dengchu(sessionid);
                if (flag11 == "1")
                {
                    MessageBox.Show(dldc.Message);
                    return;
                }
                sessionid = ""; return;
            }

            out1.State = out1.Ds.Tables["auditRespData"].Rows[0]["code"].ToString().Trim();
            out1.Message = out1.Ds.Tables["auditRespData"].Rows[0]["msg"].ToString().Trim();
            if (out1.State != "0")
            {
                MessageBox.Show("工伤保险提示！\r\n" + in1.Log_name + "出错！\r\n【" + out1.Message + "】");
                string flag11 = dldc.dengchu(sessionid);
                if (flag11 == "1")
                {
                    MessageBox.Show(dldc.Message);
                    return;
                }
                sessionid = "";
                return;
            }
            dataGridView4.DataSource = out1.Ds.Tables["resData"];
            string flag1 = dldc.dengchu(sessionid);
            if (flag1 == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = "";
            tabControl1.SelectedTab = tabPage1;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string flag = dldc.dengru();
            if (flag == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = dldc.Sessionid;
            in1.Log_name = "getJSSheet";
            in1.YwName = "getJSSheet";
            string data = "<jSSheetReqData>";
            data += " <sessionid>" + sessionid + "</sessionid>";
            data += " <akc190>" + cyjsZyh.Text.Trim() + "</akc190>";
            data += " </jSSheetReqData>";
            in1.YwData = Base64.encodebase64(in1.head() + data);

            out1 = GSBXinterface.request(in1);
            if (out1.State == "2")
            {
                MessageBox.Show("工伤保险提示！\r\n" + in1.Log_name + "出错！\r\n【" + out1.Message + "】");
                string flag11 = dldc.dengchu(sessionid);
                if (flag11 == "1")
                {
                    MessageBox.Show(dldc.Message);
                    return;
                }
                sessionid = ""; return;
            }

            out1.State = out1.Ds.Tables["jSSheetRespData"].Rows[0]["code"].ToString().Trim();
            out1.Message = out1.Ds.Tables["jSSheetRespData"].Rows[0]["msg"].ToString().Trim();
            if (out1.State != "0")
            {
                MessageBox.Show("工伤保险提示！\r\n" + in1.Log_name + "出错！\r\n【" + out1.Message + "】");
                string flag11 = dldc.dengchu(sessionid);
                if (flag11 == "1")
                {
                    MessageBox.Show(dldc.Message);
                    return;
                }
                sessionid = "";
                return;
            }
            DataTable dt1 = out1.Ds.Tables["kc21dto"];
            string grbh = cyjsGrbh.Text.Trim();
            DataTable dt2 = out1.Ds.Tables["kc22dto"];

            string flag1 = dldc.dengchu(sessionid);
            if (flag1 == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = "";
            Frmgsjsd gsjsd = new Frmgsjsd();
            gsjsd.PreView(dt1, dt2, grbh);
            gsjsd.StartPosition = FormStartPosition.CenterScreen;
            gsjsd.ShowDialog(this);
        }

        private void cyjsjbbm_KeyUp(object sender, KeyEventArgs e)
        {
            string sql = "";
            DataTable ryzddata = new DataTable();
            if (e.KeyValue == (char)Keys.Enter)
            {
                if (this.dgw_ryjbmc.Rows.Count > 0)
                {
                    dgw_ryjbmc.Focus();
                    this.dgw_ryjbmc.Rows[0].Selected = true;
                }
                return;
            }
            if (e.KeyValue == (char)Keys.Up)
            {
                dgw_ryjbmc.Focus();
                this.dgw_ryjbmc.Rows[0].Selected = true;
                return;
            }
            if (e.KeyValue == (char)Keys.Down)
            {

                if (this.dgw_ryjbmc.Rows.Count > 0)
                {
                    dgw_ryjbmc.Focus();
                    this.dgw_ryjbmc.Rows[0].Selected = true;
                }
                return;
            }
            //if (e.KeyValue == (char)Keys.Space)
            //{
            //    sql = " select jbbm as code,jbmc as name,zjm as jm from gsjblx ";

            //    ryzddata = hisdb.Select(sql).Tables[0];
            //    if (dgw_ryjbmc.Rows.Count > 0)
            //    {
            //        dgw_ryjbmc.DataSource = ryzddata;
            //        dgw_ryjbmc.Visible = true;
            //    }
            //    else
            //    {
            //        dgw_ryjbmc.Visible = false;
            //    }
            //    return;
            //}
            //查询
            if (cyjsjbbm.Text.Trim().Equals(""))
            {
                dgw_ryjbmc.Visible = false;
                return;
            }
            string tiaojian = " where 1=1 and jbbm like '%" + cyjsjbbm.Text.Trim() + "%' or jbmc like '%" + cyjsjbbm.Text.Trim() + "%' or zjm like '%" + cyjsjbbm.Text.ToUpper().Trim() + "%'";
            sql = " select jbbm as code,jbmc as name,zjm as jm from gsjblx " + tiaojian + " order by jbmc";
            ryzddata = BllMain.Db.Select(sql).Tables[0];
            if (ryzddata.Rows.Count > 0)
            {
                dgw_ryjbmc.DataSource = ryzddata;
                dgw_ryjbmc.Visible = true;
            }
            else
            {
                dgw_ryjbmc.Visible = false;
            }
        }

        private void dgw_ryjbmc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                cyjsCyjb.Text = dgw_ryjbmc.Rows[e.RowIndex].Cells["ryzdname"].Value.ToString().Trim();
                cyjsjbbm.Text = dgw_ryjbmc.Rows[e.RowIndex].Cells["ryzdcode"].Value.ToString().Trim();
                dgw_ryjbmc.Visible = false;
                cyjsjbbm.Focus();
            }
        }

        private void dgw_ryjbmc_KeyUp(object sender, KeyEventArgs e)
        {
            if (dgw_ryjbmc.CurrentRow == null)
            {
                cyjsjbbm.Focus();
                return;
            }
            if (e.KeyValue == 13)
            {
                int rowindex = this.dgw_ryjbmc.CurrentRow.Index;
                if (rowindex >= 0)
                {
                    cyjsCyjb.Text = dgw_ryjbmc.Rows[rowindex].Cells["ryzdname"].Value.ToString().Trim();
                    cyjsjbbm.Text = dgw_ryjbmc.Rows[rowindex].Cells["ryzdcode"].Value.ToString().Trim();
                    dgw_ryjbmc.Visible = false;
                    cyjsjbbm.Focus();
                }
            }
            if (e.KeyValue == (char)Keys.Escape)
            {
                cyjsjbbm.Focus();
                dgw_ryjbmc.Visible = false;
            }
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                tbx_rdbz.Text = dgw_ryjbmc.Rows[e.RowIndex].Cells["alc029"].Value.ToString().Trim();

            }
        }

        private void dataGridView2_KeyUp(object sender, KeyEventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int rowIdx = dataGridView2.CurrentRow.Index;
                    gsba_rdlc.Text = dataGridView2.Rows[rowIdx].Cells["Column16"].Value.ToString();
                    cyjsGrbh.Text = dataGridView2.Rows[rowIdx].Cells["Column17"].Value.ToString();
                    gsba_sfzh.Text = dataGridView2.Rows[rowIdx].Cells["Column18"].Value.ToString();
                    gsba_xm.Text = dataGridView2.Rows[rowIdx].Cells["Column19"].Value.ToString();
                    tbx_rdsh.Text = dataGridView2.Rows[rowIdx].Cells["Column20"].Value.ToString();
                    tbx_xzqh.Text = dataGridView2.Rows[rowIdx].Cells["Column21"].Value.ToString();
                    gsba_shbw.Text = dataGridView2.Rows[rowIdx].Cells["Column22"].Value.ToString();
                    gsba_gssj.Text = dataGridView2.Rows[rowIdx].Cells["Column23"].Value.ToString();
                    gsba_sgdd.Text = dataGridView2.Rows[rowIdx].Cells["Column24"].Value.ToString();
                    gsba_zdyj.Text = dataGridView2.Rows[rowIdx].Cells["Column25"].Value.ToString();
                    string rdbz = dataGridView2.Rows[rowIdx].Cells["Column26"].Value.ToString();
                    if (rdbz == "0") { rdbz = "未认定"; } else if (rdbz == "1") { rdbz = "认定为工伤"; } else if (rdbz == "2") { rdbz = "不认定为工伤"; } else if (rdbz == "3") { rdbz = "认定为视同工伤"; } else if (rdbz == "4") { rdbz = "不认定为视同工伤"; }
                    gsba_rdbz.Text = rdbz;
                    dataGridView2.Visible = false;
                    groupBox4.Visible = true;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            if (dataGridView3.Rows.Count < 0)
            {
                return;
            }
            int retnum = 1;
            while (retnum > 0)
            {
                retnum = fyysh();
                if (retnum == -1)
                {
                    break;
                }
            }
            string sql_tc = "select id as idx,name as xmmc,ihsp_costdet.chargedate as sfsj,prc ,realfee as amt ,num as qty,tcsl,tcje,tcyy from ihsp_costdet where ihsp_costdet.isaudit=1 and ihsp_costdet.ihsp_id=" + mtzyjl_iid;
            DataTable dt_tc = BllMain.Db.Select(sql_tc).Tables[0];
            dataGridView5.DataSource = dt_tc;
            //dataGridView5.DataSource = dt;
            tabControl1.SelectedTab = tabPage3;
        }
        public int fyysh()
        {
            string sql = @" SELECT ihsp_costdet.id AS idx,
                                  ihsp_costdet.id AS cfh,
                                  DATE_FORMAT(ihsp_costdet.chargedate,'%Y-%m-%d') AS cfsj,
                                  '1' AS cfts,
                                  bas_item.gszf as gszf,
                                  bas_item.gsbm AS xmbm,
                                ihsp_costdet.`name` AS xmmc,
                                ihsp_costdet.`name` AS tym,
                                  gsxmlb.id AS sflb,
                                  '' AS sfdj,
                                  CASE WHEN (ihsp_costdet.itemtype_id = 10) OR (ihsp_costdet.itemtype_id = 11) OR (ihsp_costdet.itemtype_id = 12) THEN '0' ELSE '1' END AS zl,
                                 ihsp_costdet.prc,
                                 ihsp_costdet.num AS num,
                                ihsp_costdet.realfee as amt,
                                ihsp_costdet.spec as guige,
                                prodjixing. NAME AS jixing
                            FROM  ihsp_costdet left join bas_item on ihsp_costdet.item_id=bas_item.id
                                     left join  gsxmlb on ihsp_costdet.itemtype_id=gsxmlb.hisid
                                     left join (select * from sys_dict where father_id=40) prodjixing  on bas_item.dosageform_id=prodjixing.sn
                            WHERE (ihsp_costdet.isaudit <> 1  or ihsp_costdet.isaudit IS NULL) AND ihsp_costdet.issc != 1 AND ihsp_costdet.ihsp_id = " + mtzyjl_iid + " order by idx limit 50";

            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            int retnum = 0;
            if (dt.Rows.Count < 1)
            {
                return retnum;
            }
            retnum = dt.Rows.Count;
            string flag = dldc.dengru();
            if (flag == "1")
            {
                MessageBox.Show(dldc.Message);
                retnum = -1;
                return retnum;
            }
            sessionid = dldc.Sessionid;
            in1.Log_name = "sendAdviceInfo";
            in1.YwName = "sendAdviceInfo";
            string data = "<advReqData>";
            data += " <sessionid>" + sessionid + "</sessionid>";
            data += " <akc190>" + zyh_ + "</akc190>";
            data += "<meds>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                data += "<med>";
                data += "<idx>" + dt.Rows[i]["idx"].ToString().Trim() + "</idx>";
                data += "<alc400>" + dt.Rows[i]["cfh"].ToString().Trim() + "</alc400>";
                data += "<alc401>" + dt.Rows[i]["cfsj"].ToString().Trim() + "</alc401>";
                data += "<akc229>" + dt.Rows[i]["cfts"].ToString().Trim() + "</akc229>";
                data += "<alc402>" + dt.Rows[i]["xmbm"].ToString().Trim() + "</alc402>";
                data += "<alc403>" + dt.Rows[i]["xmmc"].ToString().Trim() + "</alc403>";
                data += "<aka063>" + dt.Rows[i]["sflb"].ToString().Trim() + "</aka063>";
                data += "<aka065>" + dt.Rows[i]["sfdj"].ToString().Trim() + "</aka065>";
                data += "<alc404>" + dt.Rows[i]["zl"].ToString().Trim() + "</alc404>";
                data += "<alc405>" + dt.Rows[i]["prc"].ToString().Trim() + "</alc405>";
                data += "<alc406>" + dt.Rows[i]["num"].ToString().Trim() + "</alc406>";
                data += "<alc407>" + dt.Rows[i]["amt"].ToString().Trim() + "</alc407>";
                data += "<aka070>" + dt.Rows[i]["jixing"].ToString().Trim() + "</aka070>";
                data += "<zka100>" + dt.Rows[i]["guige"].ToString().Trim() + "</zka100>";
                data += "<akc230></akc230>";
                data += "<akc231>" + dt.Rows[i]["xmmc"].ToString().Trim() + "</akc231>";
                string gszf = dt.Rows[i]["gszf"].ToString().Trim();
                if (gszf == "1") { dt.Rows[i]["xmbm"] = "S" + dt.Rows[i]["xmbm"].ToString().Trim(); }
                data += "<akc515>" + dt.Rows[i]["xmbm"].ToString().Trim() + "</akc515>";
                if (gszf == "1")
                {
                    data += "<noinjury>1</noinjury>";
                }
                else
                {
                    data += "<noinjury></noinjury>";
                }
                data += "</med>";
            }
            data += "</meds>";
            data += "</advReqData>";
            in1.YwData = Base64.encodebase64(in1.head() + data);

            out1 = GSBXinterface.request(in1);
            if (out1.State == "2")
            {
                MessageBox.Show("工伤保险提示！\r\n" + in1.Log_name + "出错！\r\n【" + out1.Message + "】");
                string flag11 = dldc.dengchu(sessionid);
                if (flag11 == "1")
                {
                    MessageBox.Show(dldc.Message);
                    retnum = -1;
                    return retnum;
                }
                sessionid = "";
                retnum = -1;
                return retnum;
            }

            out1.State = out1.Ds.Tables["advRespData"].Rows[0]["code"].ToString().Trim();
            out1.Message = out1.Ds.Tables["advRespData"].Rows[0]["msg"].ToString().Trim();
            if (out1.State != "0")
            {
                MessageBox.Show("工伤保险提示！\r\n" + in1.Log_name + "出错！\r\n【" + out1.Message + "】");
                string flag11 = dldc.dengchu(sessionid);
                if (flag11 == "1")
                {
                    MessageBox.Show(dldc.Message);
                    retnum = -1;
                    return retnum;
                }
                sessionid = "";
                retnum = -1;
                return retnum;
            }
            DataTable dtfh = out1.Ds.Tables["kc22"];
            try
            {
                for (int i = 0; i < dtfh.Rows.Count; i++)
                {
                    string sql_cx = " update ihsp_costdet set isaudit=1, tcsl='" + dtfh.Rows[i]["zkc266"].ToString().Trim() + "',tcje='" + dtfh.Rows[i]["alc408"].ToString().Trim() + "',tcyy='" + dtfh.Rows[i]["aka073"].ToString().Trim() + "' where id=" + dtfh.Rows[i]["idx"].ToString().Trim();
                    BllMain.Db.Update(sql_cx);
                }
            }
            catch
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sql_cx = " update ihsp_costdet set isaudit=1  where id=" + dt.Rows[i]["idx"].ToString().Trim();
                    BllMain.Db.Update(sql_cx);
                }
            }

            return retnum;
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (dataGridView3.Rows.Count <= 0)
            {
                return;
            }
            Frmgszf xfxmbm = new Frmgszf();
            xfxmbm.Xmmc = this.dataGridView3.Rows[e.RowIndex].Cells["xmmc"].Value.ToString().Trim();
            xfxmbm.Mtprodiid = this.dataGridView3.Rows[e.RowIndex].Cells["prodid"].Value.ToString().Trim();
            xfxmbm.StartPosition = FormStartPosition.CenterScreen;
            xfxmbm.ShowDialog();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewColumn column = dataGridView3.Columns[e.ColumnIndex];
                if (column is DataGridViewButtonColumn)
                {
                    String iid = dataGridView3.Rows[e.RowIndex].Cells["prodid"].Value.ToString().Trim();
                    String name = dataGridView3.Rows[e.RowIndex].Cells["xmmc"].Value.ToString().Trim();
                    Frmgsmldz xfxmbm = new Frmgsmldz();
                    xfxmbm.Iid = iid;
                    xfxmbm.Name = name;
                    xfxmbm.StartPosition = FormStartPosition.CenterScreen;
                    xfxmbm.ShowDialog();
                    initdgv();
                }
            }

        }
    }
}
