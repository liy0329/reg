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
using zhongluyiyuan.db;
using WindowsFormsApplication1.common;
using zhongluyiyuan.Util;
using zhongluyiyuan.ch;
using WindowsFormsApplication1;
using zhongluyiyuan.Common;
using zhongluyiyuan.Report;
using zhongluyiyuan.syb;
using zhongluyiyuan.Entity;
using zhongluyiyuan.global;
using System.Text.RegularExpressions;
using zhongluyiyuan.gsbx.bll;


namespace zhongluyiyuan.gsbx
{
    public partial class FrmgsCy : Form
    {
        public FrmgsCy()
        {
            InitializeComponent();
        }
        YBCJ yw1 = new YBCJ();
        HISDB hisdb = new HISDB();
        JKDB jkdb = new JKDB();
        Gyd gyd = Gyd.getGyd();
        DlDC dldc=new DlDC();
         GSBX_IN in1 = new GSBX_IN();
        GSBX_OUT out1 = new GSBX_OUT();
        Common_Util util = new Common_Util();
        GSBXinterface GSBXinterface = new GSBXinterface();
        ZfRydj zfrydj = new ZfRydj();
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
        string sessionid="";
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
            string sql = "select mtzyjl.ybgrbh,mtzyjl.fph,mtzyjl.rdsh,ctct.fullname as brxm,ctct1.fullname as ysname,org.name as ryks,ctct.gender as brxb,mtszks.zyjlbs as bfh,mtszks.zyjlch as bch,ctct.ssn as sfzh,to_char(mtzyjl.zyjlrysj,'yyyy-MM-dd') as zyjlrysj,to_char(mtzyjl.zyjlcysj,'yyyy-MM-dd') as zyjlcysj"
                        +" from mtzyjl,ctct,ctct ctct1,cimsuser,mtszks,org "
                        +"where mtzyjl.ctct=ctct.iid and mtszks.mtzyjl=mtzyjl.iid and org.iid=mtzyjl.org and mtzyjl.zyjlzyys =cimsuser.iid and cimsuser.ctct=ctct1.iid and mtzyjl.iid="+mtzyjl_iid;
            DataTable dt = hisdb.Select(sql).Tables[0];
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
            string sumFeeSql = "select sum(amt) as sumAmt from mtprecharge where tp=0 and mtzyjl= " + mtzyjl_iid;
            DataTable temSum = hisdb.Select(sumFeeSql).Tables[0];
            tbx_yjj.Text = temSum.Rows[0]["sumAmt"].ToString().Trim();//预交金
            string sumFee = "select amt  from mtchargeinfo where  mtzyjl= " + mtzyjl_iid;
            DataTable tem = hisdb.Select(sumFee).Tables[0];
            label2.Text = tem.Rows[0]["amt"].ToString().Trim();//金额

        }
        private void initdgv()
        {
            string sql = " select mtzyjlstuff.iid as cfh,to_char(mtzyjlstuff.createdat,'yyyy-MM-dd') as cfsj,'1' as cfts,mtprod.iid as prodid,mtprod.gsbm as xmbm,mtzyjlstuff.xmmc as xmmc, gsxmlb.name as sflb,'' as sfdj,case  when (mtzyjlstuff.projecttype='2') or (mtzyjlstuff.projecttype='3' ) or (mtzyjlstuff.projecttype='4') then '0' else '1' end as zl,mtzyjlstuff.prc,mtzyjlstuff.qty as num,mtzyjlstuff.amt,mtzyjlstuff.guige,prodjixing.name as jixing, mtzyjlstuff.ybsc as sfsc "
                        +" from mtzyjlstuff,mtprod,prodjixing,gsxmlb where mtzyjlstuff.mtprod=mtprod.iid and gsxmlb.hisid=mtzyjlstuff.projecttype and prodjixing.iid=mtprod.prodjixing "
                        +" and mtzyjlstuff.mtzyjl= "+mtzyjl_iid+" "
                        +"union  "
                        +" select mtzyjlstuff.iid as cfh,to_char(mtzyjlstuff.createdat,'yyyy-MM-dd') as cfsj,'1' as cfts,mtjcxm.iid as prodid,mtjcxm.gsbm as xmbm,mtzyjlstuff.xmmc as xmmc, gsxmlb.name as sflb,'' as sfdj,case  when (mtzyjlstuff.projecttype='2') or (mtzyjlstuff.projecttype='3' ) or (mtzyjlstuff.projecttype='4') then '0' else '1' end as zl,mtzyjlstuff.prc,mtzyjlstuff.qty as num,mtzyjlstuff.amt,mtzyjlstuff.guige,'' as jixing, mtzyjlstuff.ybsc as sfsc "
                        +" from mtzyjlstuff,mtjcxm,gsxmlb where mtzyjlstuff.mtprod=mtjcxm.iid and gsxmlb.hisid=mtzyjlstuff.projecttype  "
                        +" and mtzyjlstuff.mtzyjl="+mtzyjl_iid;
            dataGridView3.DataSource = hisdb.Select(sql).Tables[0];
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {

                if (dataGridView3.Rows[i].Cells["sfsc"].Value.ToString() == "0" || dataGridView3.Rows[i].Cells["sfsc"].Value.ToString() == "")
                    dataGridView3.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;//未上传
            }
            string sql_count = "select count(*) as sum from mtzyjlstuff where mtzyjl="+mtzyjl_iid;
            DataSet dt_count=hisdb.Select(sql_count);
            lab_zg.Text = dt_count.Tables[0].Rows[0]["sum"].ToString().Trim();
        }

        private void btnXfsj_Click(object sender, EventArgs e)
        {
            string sql_sfjs = "select nhflag from mtzyjl where iid = " + mtzyjl_iid;
            DataTable dtxx_sfjs = hisdb.Select(sql_sfjs).Tables[0];
            if (dtxx_sfjs.Rows[0]["nhflag"].ToString() != "501")
                return;
            if (Tool.IsUpload==true)
            {
                MessageBox.Show("后台正在自动上传费用！", "提示信息");
                return;
            }
            
            
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
            string sql_yz = " select  mtyznr.iid as  aae080 ,to_char( mtyz.createdat ,'yyyy-MM-dd') as  alk007 ,to_char( mtyz.createdat ,'yyyy-MM-dd') as  alk008 , case when mtyznr.dictate=''   or mtyznr.dictate is null then mtyznr.prodname when mtyznr.prodname='' or mtyznr.prodname is null then mtyznr.dictate else mtyznr.dictate || mtyznr.prodname end as  alk009 ,'' as  alk011 ,'' as  alk012 , case when mtyznr.uom=''   or mtyznr.uom is null then mtyznr.qty || mtyznr.mtuom else mtyznr.qty || mtyznr.uom end as  alk013 , mtusage.name || mtfrequency.frename as  alk014 , mtyznr.descr as  alk015 , ysqm.fullname as  alk016 , hsqm.fullname as  alk017 , zxzqm.fullname as  alk020 , case mtyz.yzyzlb when 0 then 1 when 1 then 2 end as  alk022 , org.name as  alk023 , mtszks.zyjlch as  alk024  from  mtzyjl,mtszks,org,mtyz left join ctct ysqm on mtyz.yzxdys = ysqm.iid,mtyznr left join ctct hsqm on mtyznr.yzkszxhs = hsqm.iid left join ctct zxzqm on mtyznr.yzzxhs = zxzqm.iid left join mtusage on mtyznr.mtusageiid = mtusage.iid left join mtfrequency on mtyznr.mtfreqiid = mtfrequency.iid where  mtzyjl.iid = mtyz.mtzyjl and mtyz.iid = mtyznr.yznryz and mtszks.mtzyjl = mtzyjl.iid and mtszks.isactive = 1 and mtszks.iscurrent = 1 and mtszks.org = org.iid and mtyznr.sfsc = 0 and mtzyjl.iid =" + mtzyjl_iid;
            DataTable dt_yz = hisdb.Select(sql_yz).Tables[0];

            string sql = " select mtzyjlstuff.iid as cfh,mtprod.gszf,to_char(mtzyjlstuff.createdat,'yyyy-MM-dd') as cfsj,'1' as cfts,mtprod.gsbm as xmbm,mtzyjlstuff.xmmc as xmmc,mtzyjlstuff.xmmc as tym, gsxmlb.id as sflb,case  when (mtzyjlstuff.projecttype='2') or (mtzyjlstuff.projecttype='3' ) or (mtzyjlstuff.projecttype='4') then '0' else '1' end as zl,mtzyjlstuff.prc,mtzyjlstuff.qty as num,mtzyjlstuff.amt,mtzyjlstuff.guige,prodjixing.name as jixing "
                        +" from mtzyjlstuff,mtprod,prodjixing,gsxmlb where  mtzyjlstuff.mtprod=mtprod.iid and gsxmlb.hisid=mtzyjlstuff.projecttype and prodjixing.iid=mtprod.prodjixing and mtzyjlstuff.ybsc=0 "
                        +" and mtzyjlstuff.mtzyjl= "+mtzyjl_iid+" "
                        +"union  "
                        + " select mtzyjlstuff.iid as cfh,mtjcxm.gszf,to_char(mtzyjlstuff.createdat,'yyyy-MM-dd') as cfsj,'1' as cfts,mtjcxm.gsbm as xmbm,mtzyjlstuff.xmmc as xmmc,mtzyjlstuff.xmmc as tym, gsxmlb.id as sflb,case  when (mtzyjlstuff.projecttype='2') or (mtzyjlstuff.projecttype='3' ) or (mtzyjlstuff.projecttype='4') then '0' else '1' end as zl,mtzyjlstuff.prc,mtzyjlstuff.qty as num,mtzyjlstuff.amt,mtzyjlstuff.guige,'' as jixing "
                        + " from mtzyjlstuff,mtjcxm,gsxmlb where  mtzyjlstuff.mtprod=mtjcxm.iid and gsxmlb.hisid=mtzyjlstuff.projecttype  and mtzyjlstuff.ybsc=0 "
                        +" and mtzyjlstuff.mtzyjl="+mtzyjl_iid+" order by cfh limit 50";
            DataTable dt = hisdb.Select(sql).Tables[0];
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
            data += "<advices>";
            if (dt_yz.Rows.Count > 0)
            {
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
            }
            data += "</advices>";
            data += "<meds>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                data += "<med>";
                data += "<alc400>" + dt.Rows[i]["cfh"].ToString().Trim() + "</alc400>";
                data += "<alc401>" + dt.Rows[i]["cfsj"].ToString().Trim() + "</alc401>";
                data += "<akc229>" + dt.Rows[i]["cfts"].ToString().Trim() + "</akc229>";
                string gszf = dt.Rows[i]["gszf"].ToString().Trim();

                if (gszf == "1") { dt.Rows[i]["xmbm"] ="S"+dt.Rows[i]["xmbm"]; }
                data += "<alc402>" + dt.Rows[i]["xmbm"].ToString().Trim() + "</alc402>";
                data += "<alc403>" + dt.Rows[i]["xmmc"].ToString().Trim() + "</alc403>";
                data += "<aka063>" + dt.Rows[i]["sflb"].ToString().Trim() + "</aka063>";
                string sfdj = "";
                string xmbm = dt.Rows[i]["xmbm"].ToString().Trim();
                string sql1 = "select gssfdj from gsml where bm='"+xmbm+"'";
                DataTable dt1 = hisdb.Select(sql1).Tables[0];
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
                data += "<akc515>" + dt.Rows[i]["xmbm"].ToString().Trim() + "</akc515>";
                data += "<reason></reason>";
                data += "<noinjury></noinjury>";
                data += "</med>";
            }
            data += "</meds>";
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
                MessageBox.Show("工伤保险提示！\r\n"+in1.Log_name + "出错！\r\n【" + out1.Message + "】");
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
            string sql_up = "update mtzyjlstuff set ybsc=1 where iid in (";
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
                sql_up += " update mtyznr set sfsc=1 where iid in (";
                for (int q = 0; q < dt_yz.Rows.Count; q++)
                {
                    sql_up += dt_yz.Rows[q]["aae080"].ToString().Trim() + ",";
                }
                sql_up = sql_up.Substring(0, sql_up.Length - 1);

                sql_up += "); ";
            }
            if (hisdb.Update(sql_up) == -1)
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
                MessageBox.Show("工伤保险提示！\r\n"+in1.Log_name + "出错！\r\n【" + out1.Message + "】");
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
                DataTable dt2 = hisdb.Select(sql).Tables[0];
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
            data += " <aaca07>"+fphtext.Text.Trim()+"</aaca07>";
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
                MessageBox.Show("工伤保险提示！\r\n"+in1.Log_name + "出错！\r\n【" + out1.Message + "】");
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
                MessageBox.Show("工伤保险提示！\r\n"+in1.Log_name + "出错！\r\n【" + out1.Message + "】");
                string flag11 = dldc.dengchu(sessionid);
                if (flag11 == "1")
                {
                    MessageBox.Show(dldc.Message);
                    return;
                }
                sessionid = "";
                return;
            }
            
            string sql_ssfy = "update mtzyjlstuff set ybsc=0,issc=0 where mtzyjl="+mtzyjl_iid+";";
            sql_ssfy += "update mtyznr set sfsc=0 from  mtyz where mtyznr.yznryz = mtyz.iid and mtyz.mtzyjl=" + mtzyjl_iid + ";";
            hisdb.Update(sql_ssfy);
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
            if (cyjsCyrq.Text.Trim() == "" && fphtext.Text.Trim()=="")
            {
                MessageBox.Show("自费没有结算！");
                return;
            }
            if (cyjsjbbm.Text.Trim() == "")
            {
                MessageBox.Show("没有出院疾病!");
                return;
            }
            string sql_sfxgs = "select sfxgs from mtzyjl  where iid=" + mtzyjl_iid;
            DataTable dt_sfxgs = hisdb.Select(sql_sfxgs).Tables[0];
            if (dt_sfxgs.Rows[0]["sfxgs"].ToString().Trim() == "1")
            {
                if (gsba_rdbz.Text.Trim()=="")
                {
                    MessageBox.Show("该病人为新工伤，先获取备案信息！");
                    return;
                }
                if (gsba_rdbz.Text.Trim() == "认定为工伤" || gsba_rdbz.Text.Trim() == "认定为视同工伤")
                { }
                else{
                    MessageBox.Show("该病人认定未通过！按自费结算！");
                    button2.Enabled = false;
                    return;
                }
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
                string sql_ryjl = "select ctct.gender as aac004 ,substr(ctct.dob,1,11) as  aac006 ,ctct.h_tel as  aac008 ,	address.addr_dt1 as  aac010 ,mtszks.zyjlzs as  blz060 ,	mtzyjl.zyjlxbs as  blz061 ,mtzyjl.zyjljws as  blz062 ,mtzyjl.zyjlgrs as  blz063 ,case when mtzyjl.zyjlyjs='' then mtzyjl.zyjlsys else case when mtzyjl.zyjlsys='' then mtzyjl.zyjlyjs else mtzyjl.zyjlyjs || mtzyjl.zyjlsys end end as  blz064 ,mtzyjl.zyjljzs as  blz065 ,mtszks.zyjltgjc as  blz066 ,	mtszks.zyjlfzjc as  blz067 ,mtzyjl.zyjlryzd as  blz068 from mtzyjl,ctct,address,ctctaddr,mtszks where mtzyjl.ctct=ctct.iid and ctctaddr.addr = address.iid and ctctaddr.ctct = ctct.iid	and mtzyjl.iid=mtszks.mtzyjl and mtszks.isactive=1 and mtszks.iscurrent=1 and mtzyjl.iid =" + mtzyjl_iid;
                DataTable dt_ryjl = hisdb.Select(sql_ryjl).Tables[0];
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
                string sql_cyjl = "select 	ctct.gender as  aac004 ,substr(ctct.dob,1,11) as  aac006 ,ctct.h_tel as  aac008 ,address.addr_dt1 as  aac010 ,	mtzyjl.zyjlmqqk as  blc074 ,	mtzyjl.zyjlcyyz as  blc075 ,case when mtzyjl.zyjlryqk=1 then  '危'  when mtzyjl.zyjlryqk=2 then  '急'  when mtzyjl.zyjlryqk=4 then  '重'  else  '一般'  end as  blz070 ,mtzyjl.zyjlryzd as  blz071 ,mtszks.zyjlzljg as  blz072 ,mtszks.zyjljbmcdesc as  blz073  from mtzyjl,ctct,address,ctctaddr,mtszks where mtzyjl.ctct=ctct.iid 	and ctctaddr.addr = address.iid and ctctaddr.ctct = ctct.iid and mtzyjl.iid=mtszks.mtzyjl and mtszks.isactive=1 and mtszks.iscurrent=1	and mtzyjl.iid =" + mtzyjl_iid;
                DataTable dt_cyjl = hisdb.Select(sql_cyjl).Tables[0];
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
                string sql_ssjl = "select  mtbcjl.bcjlssczbm2 as  opr030 , substr(mtbcjl.bcjlsskssj,1,11) as  opr031 , mtbcjl.bcjlssdj as  opr032 , mtbcjl.bcjlssczmcst2 as  opr033 , mtbcjl.ssz as  opr040 , czzlname.fullname as  opr041 ,'' as  opr042 , mtmzfs.name as  opr043 , mzysname.fullname as  opr044 from  mtzyjl,mtbcjl,mtmzfs,(select mtbcjl,min(ctct) as czzliid from mtsszl where ctcttp=1 group by mtbcjl) czzl,(select  mtbcjl,min(ctct) as mzysiid from mtsszl where ctcttp=3 group by mtbcjl) mzys,ctct czzlname,ctct mzysname where  mtzyjl.iid=mtbcjl.mtzyjl and mtbcjl.bcjlmzfs=mtmzfs.iid and mtbcjl.bcjljllb=1 and mtbcjl.iid=czzl.mtbcjl and czzlname.iid=czzl.czzliid and mtbcjl.iid=mzys.mtbcjl and mzysname.iid=mzys.mzysiid and mtzyjl.iid =" + mtzyjl_iid;
          DataTable dt_ssjl = hisdb.Select(sql_ssjl).Tables[0];
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
                string sql_basy = "select '' as aab034, '' as aab301, ctct.ssn as aac002, ctct.fullname as aac003, ctct.gender as aac004, ethnics.name as aac005, substr(ctct.dob,1,11) as aac006, address.addr_dt2 as aac009, address.addr_dt1 as aac010, ctctprof.name as aac020, case ctct.maritalstatus when 1 then '未婚' when 2 then '已婚' when 3 then '丧偶' when 4 then '离婚' else '其它' end as aac021, mtzyjl.dwdh as aad005, mtzyjl.dwyb as aad007, ctct.orgname as aad010, ctct.h_tel as aae005, address.addr_dt1 as aae006, mtzyjl.xzzyb as aae007, address.addr_dt1 as aae010, mtzyjl.hkzzyb as aae017, ctct.lx_xm as aam003, ctct.lx_tel as aam005, ctct.lx_addr as aam010, ctct.lx_gx as aam036, '中国' as akc020, (now()::date-ctct.dob::date)/365 as akc023, substr(mtzyjl.zyjlrysj,1,11) as akc192, substr(mtzyjl.zyjlcysj,1,11) as akc194, mtzyjl.mzzddm as alc028, mtzyjl.sszdwbysbm2 as alc029, mtzyjl.blzddm as alc030, '' as blm001, mtzyjl.zyjlzrcs as blm002, mtzyjl.zyjlbah as blm003, case mtzyjl.ryfs when 1 then '急诊' when 2 then '门诊' when 3 then '其他医疗机构转入' else '其它' end as blm004, ryks.ryksname as blm005, ryks.zyjlbs as blm006, cyks.cyksname as blm007, cyks.cyksname as blm009, cyks.zyjlbs as blm010, mtzyjl.zyjlzyts as blm011, mtzyjl.zyjlsszdwbys2 as blm012, mtzyjl.blzd2 as blm013, mtzyjl.blzdh as blm014, '' as blm015, mtzyjl.zyjlywgms as blm016, case mtzyjl.zyjlsj when 1 then '否' when 2 then '是'  end as blm017, case cyks.zyjlxx when 1 then 'A' when 2 then 'B' when 3 then 'AB' when 4 then 'O' when 6 then '未做' else '其它' end as blm018, case cyks.zyjlrh when 1 then '阴' when 2 then '阳' when 3 then '不详' else '未查' end as blm019, mtzyjl.kzr as blm020, mtzyjl.zrys as blm021, mtzyjl.zzys as blm022, mtzyjl.zyys as blm023, mtzyjl.zrhs as blm024, mtzyjl.jxys as blm025, mtzyjl.sxys as blm026, mtzyjl.bmy as blm027, mtzyjl.bazl as blm028, mtzyjl.zkys as blm029, mtzyjl.zkhs as blm030, mtzyjl.zkrq as blm031, case cyks.zyjlxx when 1 then '医嘱离院' when 2 then '医嘱转院' when 3 then '医嘱转社区/乡镇卫生院' when 4 then '非医嘱离院' when 5 then '死亡' else '其它' end as blm032, '' as blm033, '' as blm034, '' as blm035, '' as blm036, '' as blm037, '' as blm038, '' as blm039, '' as blm040, '' as blm041, '' as blm042,'' as blm043, mtzyjl.mzzd2 as blz068 from mtzyjl,ctct,ethnics,address,ctctaddr,ctctprof,(select mtszks.mtzyjl,org.name as ryksname,mtszks.zyjlbs from mtszks,org where mtszks.zyjlzrdate is null and org.iid=mtszks.org) ryks,(select mtszks.mtzyjl,org.name as cyksname,mtszks.zyjlbs,mtszks.zyjlxx,mtszks.zyjlrh from mtszks,org where mtszks.isactive=1 and mtszks.iscurrent=1 and org.iid=mtszks.org) cyks where mtzyjl.ctct = ctct.iid and ctct.ethnics = ethnics.iid and ctctaddr.addr = address.iid   and ctctaddr.ctct = ctct.iid and ctct.ctctprof = ctctprof.iid and mtzyjl.iid = ryks.mtzyjl and mtzyjl.iid = cyks.mtzyjl and mtzyjl.iid =" + mtzyjl_iid;
               
                DataTable dt_basy = hisdb.Select(sql_basy).Tables[0];
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
                string sql_bcbg = "select mtjcxm.mtjcbw as kcb001,mtjc.jcsqdh as kcb002,substr(mtjc.jyysubmittedat,1,11) as kcb003,mtjc.jcjg as kcb004,mtjc.jczdjy as kcb005,jcys.fullname as kcb006,shys.fullname as kcb007 from mtzyjl,mtjc,mtjcjl,mtjcxm,ctct jcys,ctct shys,projecttype where mtjc.iid = mtjcjl.mtjc and mtjcjl.jcjljcxm = mtjcxm.iid and jcys.iid = mtjc.jyysubmittedby and shys.iid = mtjc.jcsjys and mtjc.jczyjl = mtzyjl.iid and mtjcxm.projecttype2 = projecttype.iid and projecttype.name = 'B超' and mtzyjl.iid =" + mtzyjl_iid;
                //string sql_bcbg = "select 123 as kcb001,12 as kcb002,'2014-11-03' as kcb003,111 as kcb004,11111 as kcb005,11111 as kcb006,2323 as kcb007 from mtzyjl limit 1 ";//,mtjc,mtjcjl,mtjcxm,ctct jcys,ctct shys,projecttype where mtjc.iid = mtjcjl.mtjc and mtjcjl.jcjljcxm = mtjcxm.iid and jcys.iid = mtjc.jyysubmittedby and shys.iid = mtjc.jcsjys and mtjc.jczyjl = mtzyjl.iid and mtjcxm.projecttype2 = projecttype.iid and projecttype.name = 'B超' and mtzyjl.iid =" + mtzyjl_iid;

                DataTable dt_bcbg = hisdb.Select(sql_bcbg).Tables[0];
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
                string sql_xgbg = "select 	mtjcxm.mtjcbw as kcx001,mtjc.jcsqdh as kcx002,substr(mtjc.jyysubmittedat,1,11) as kcx003,mtjc.jcjg as kcx004,mtjc.jczdjy as kcx005,jcys.fullname as kcx006,shys.fullname as kcx007 from	mtzyjl,mtjc,mtjcjl,mtjcxm,ctct jcys,ctct shys,projecttype where mtjc.iid = mtjcjl.mtjc 	and mtjcjl.jcjljcxm = mtjcxm.iid and jcys.iid = mtjc.jyysubmittedby and shys.iid = mtjc.jcsjys and mtjc.jczyjl = mtzyjl.iid and mtjcxm.projecttype2 = projecttype.iid and projecttype.name = 'X光' and mtzyjl.iid =" + mtzyjl_iid;
                //string sql_xgbg = "select 	5646 as kcx001,345345 as kcx002,'2014-11-03' as  kcx003,8676 as kcx004,12314 as kcx005,12314 as kcx006,123124 as kcx007 from	mtzyjl limit 1";//,mtjc,mtjcjl,mtjcxm,ctct jcys,ctct shys,projecttype where mtjc.iid = mtjcjl.mtjc 	and mtjcjl.jcjljcxm = mtjcxm.iid and jcys.iid = mtjc.jyysubmittedby and shys.iid = mtjc.jcsjys and mtjc.jczyjl = mtzyjl.iid and mtjcxm.projecttype2 = projecttype.iid and projecttype.name = 'X光' and mtzyjl.iid =" + mtzyjl_iid;

                DataTable dt_xgbg = hisdb.Select(sql_xgbg).Tables[0];
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
                string sql_ctbg = "select mtjcxm.mtjcbw as kcc001,	mtjc.jcsqdh as kcc002,substr(mtjc.jyysubmittedat,1,11) as kcc003,mtjc.jcjg as kcc004,mtjc.jczdjy as kcc005,jcys.fullname as kcc006,shys.fullname as kcc007 from	mtzyjl,mtjc,mtjcjl,mtjcxm,ctct jcys,ctct shys,projecttype where mtjc.iid = mtjcjl.mtjc and mtjcjl.jcjljcxm = mtjcxm.iid	and jcys.iid = mtjc.jyysubmittedby and shys.iid = mtjc.jcsjys and mtjc.jczyjl = mtzyjl.iid and mtjcxm.projecttype2= projecttype.iid and projecttype.name = 'CT' and mtzyjl.iid =" + mtzyjl_iid;
                //string sql_ctbg = "select 8768 as kcc001,6787 as kcc002,'2014-11-03' as kcc003,23423 as kcc004,234234 as kcc005,234234 as kcc006,5656 as kcc007 from	mtzyjl limit 1 ";//,mtjc,mtjcjl,mtjcxm,ctct jcys,ctct shys,projecttype where mtjc.iid = mtjcjl.mtjc and mtjcjl.jcjljcxm = mtjcxm.iid	and jcys.iid = mtjc.jyysubmittedby and shys.iid = mtjc.jcsjys and mtjc.jczyjl = mtzyjl.iid and mtjcxm.projecttype2= projecttype.iid and projecttype.name = 'CT' and mtzyjl.iid =" + mtzyjl_iid;

                DataTable dt_ctbg = hisdb.Select(sql_ctbg).Tables[0];
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
                string sql_hcbg = "select 	mtjcxm.mtjcbw as kch001,mtjc.jcsqdh as kch002,substr(mtjc.jyysubmittedat,1,11) as kch003,mtjc.jcjg as kch004,mtjc.jczdjy as kch005,jcys.fullname as kch006,shys.fullname as kch007,'' as kch008 from mtzyjl,mtjc,mtjcjl,mtjcxm,ctct jcys,ctct shys,projecttype where mtjc.iid = mtjcjl.mtjc and mtjcjl.jcjljcxm = mtjcxm.iid and jcys.iid = mtjc.jyysubmittedby	and shys.iid = mtjc.jcsjys and mtjc.jczyjl = mtzyjl.iid	and mtjcxm.projecttype2 = projecttype.iid and projecttype.name = '核磁'	and mtzyjl.iid =" + mtzyjl_iid;
                //string sql_hcbg = "select 	123123 as kch001,3333 as kch002,'2014-11-03' as kch003,56578 as kch004,123123 as kch005,4353453 as kch006,343434 as kch007,'' as kch008 from mtzyjl limit 1 ";//,mtjc,mtjcjl,mtjcxm,ctct jcys,ctct shys,projecttype where mtjc.iid = mtjcjl.mtjc and mtjcjl.jcjljcxm = mtjcxm.iid and jcys.iid = mtjc.jyysubmittedby	and shys.iid = mtjc.jcsjys and mtjc.jczyjl = mtzyjl.iid	and mtjcxm.projecttype2 = projecttype.iid and projecttype.name = '核磁'	and mtzyjl.iid =" + mtzyjl_iid;

                DataTable dt_hcbg = hisdb.Select(sql_hcbg).Tables[0];
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
                MessageBox.Show("工伤保险提示！\r\n"+in1.Log_name + "出错！\r\n【" + out1.Message + "】");
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
            string jkr = Tool.Oprcode;
            string sql_cysj = "select zyjlcysj from mtzyjl where iid="+mtzyjl_iid;
            DataTable dt_cysj = hisdb.Select(sql_cysj).Tables[0];
            String updatesql = " update mtzyjl set nhflag=502 where iid=" + mtzyjl_iid + ";";
            updatesql += " update gsryinfo set jssj='" + cyjsCyrq.Text.Trim() + "' where iid=" + mtzyjl_iid + ";";
            if (hisdb.Update(updatesql) == -1)
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
                MessageBox.Show("工伤保险提示！\r\n"+in1.Log_name + "出错！\r\n【" + out1.Message + "】");
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
            string sql = "update mtzyjl set nhflag=501 where iid=" + mtzyjl_iid;//_iid.ToString().Trim();
            hisdb.Update(sql);
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
                MessageBox.Show("工伤保险提示！\r\n"+in1.Log_name + "出错！\r\n【" + out1.Message + "】");
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
                MessageBox.Show("工伤保险提示！\r\n"+in1.Log_name + "出错！\r\n【" + out1.Message + "】");
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
                MessageBox.Show("工伤保险提示！\r\n"+in1.Log_name + "出错！\r\n【" + out1.Message + "】");
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
            gsjsd.PreView(dt1,dt2,grbh);
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
            ryzddata = hisdb.Select(sql).Tables[0];
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
                    return;
                }
            }
            string sql_tc = "select iid as idx,xmmc,createdat as sfsj,prc ,amt ,qty,tcsl,tcje,tcyy from mtzyjlstuff where ybsc=0 and mtzyjl=" + mtzyjl_iid;
            DataTable dt_tc = hisdb.Select(sql_tc).Tables[0];
            dataGridView5.DataSource = dt_tc;
            //dataGridView5.DataSource = dt;
            tabControl1.SelectedTab = tabPage3;
        }
        public int fyysh()
        {
            string sql = " select  mtzyjlstuff.iid as idx,mtzyjlstuff.iid as cfh,to_char(mtzyjlstuff.createdat,'yyyy-MM-dd') as cfsj,'1' as cfts,mtprod.gszf,mtprod.gsbm as xmbm,mtzyjlstuff.xmmc as xmmc,mtzyjlstuff.xmmc as tym, gsxmlb.id as sflb,'' as sfdj,case  when (mtzyjlstuff.projecttype='2') or (mtzyjlstuff.projecttype='3' ) or (mtzyjlstuff.projecttype='4') then '0' else '1' end as zl,mtzyjlstuff.prc,mtzyjlstuff.qty as num,mtzyjlstuff.amt,mtzyjlstuff.guige,prodjixing.name as jixing ";
            sql += " from mtzyjlstuff,mtprod,prodjixing,gsxmlb where mtzyjlstuff.mtprod=mtprod.iid and gsxmlb.hisid=mtzyjlstuff.projecttype and prodjixing.iid=mtprod.prodjixing and mtzyjlstuff.ybsc=0 and mtzyjlstuff.issc!=1 ";
            sql += " and mtzyjlstuff.mtzyjl= " + mtzyjl_iid + " union ";
            sql += " select  mtzyjlstuff.iid as idx,mtzyjlstuff.iid as cfh,to_char(mtzyjlstuff.createdat,'yyyy-MM-dd') as cfsj,'1' as cfts,mtjcxm.gszf,mtjcxm.gsbm as xmbm,mtzyjlstuff.xmmc as xmmc,mtzyjlstuff.xmmc as tym, gsxmlb.id as sflb,'' as sfdj,case  when (mtzyjlstuff.projecttype='2') or (mtzyjlstuff.projecttype='3' ) or (mtzyjlstuff.projecttype='4') then '0' else '1' end as zl,mtzyjlstuff.prc,mtzyjlstuff.qty as num,mtzyjlstuff.amt,mtzyjlstuff.guige,'' as jixing ";
            sql += " from mtzyjlstuff,mtjcxm,prodjixing,gsxmlb where mtzyjlstuff.mtprod=mtjcxm.iid and gsxmlb.hisid=mtzyjlstuff.projecttype and mtzyjlstuff.ybsc=0 and mtzyjlstuff.issc!=1 ";
            sql += " and mtzyjlstuff.mtzyjl= " + mtzyjl_iid + " order by idx limit 50";

            DataTable dt = hisdb.Select(sql).Tables[0];
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
                data += "<noinjury></noinjury>";
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
            DataTable dtfh=out1.Ds.Tables["kc22"];
            try
            {
                for (int i = 0; i < dtfh.Rows.Count; i++)
                {
                    string sql_cx = " update mtzyjlstuff set issc=1, tcsl='" + dtfh.Rows[i]["zkc266"].ToString().Trim() + "',tcje='" + dtfh.Rows[i]["alc408"].ToString().Trim() + "',tcyy='" + dtfh.Rows[i]["aka073"].ToString().Trim() + "' where iid=" + dtfh.Rows[i]["idx"].ToString().Trim();
                    hisdb.Update(sql_cx);
                }
            }
            catch {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sql_cx = " update mtzyjlstuff set issc=1  where iid=" + dt.Rows[i]["idx"].ToString().Trim();
                    hisdb.Update(sql_cx);
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
