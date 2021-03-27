using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTHIS.db;
using MTHIS.common;
using MTHIS.main.bll;
using MTREG.medinsur.hdyb.bll;
using MTREG.medinsur.hdyb.dor;
using MTREG.common;
using MTREG.ihsp.bll;
using MTREG.ihsp.bo;
using MTREG.medinsur;
using MTREG.medinsur.bll;
using MTREG.medinsur.hdyb.bo;
using System.Web.UI.WebControls;
using MTREG.netpay;
using MTHIS.tools;
using MTREG.netpay.bo;
using MTREG.common.bll;
using MTREG.medinsur.gzsyb;
using MTREG.medinsur.hdyb;
using MTREG.tools;
using System.Diagnostics;
using MTREG.medinsur.sjzsyb.bll;
using System.IO;

namespace MTREG.medinsur.hdyb
{
    public partial class FrmCxcwTscl : Form
    {
        public FrmCxcwTscl()
        {
            InitializeComponent();
        }
        YBCJ yw1 = new YBCJ();
        JKDB jkdb = new JKDB();

        private string in_zyh;//

        public string In_zyh
        {
            get { return in_zyh; }
            set { in_zyh = value; }
        }
        private string sfck;//

        public string Sfck
        {
            get { return sfck; }
            set { sfck = value; }
        }
        private string ybcjbz;//

        public string Ybcjbz
        {
            get { return ybcjbz; }
            set { ybcjbz = value; }
        }
        private string jmylzh_;//居民医疗证号

        public string Jmylzh_
        {
            get { return jmylzh_; }
            set { jmylzh_ = value; }
        }
        private void FrmCxcwTscl_Load(object sender, EventArgs e)
        {
            if (this.in_zyh != "")
            {
                this.tbx_Zyh.Text = this.in_zyh;
            }
            initYwlx();
            initTsxx();
        }
        private void initYwlx()
        {
            List<ListItem> ls = new List<ListItem>();

            ls.Add(new ListItem("住院结算(回退)","DC311003"));
            ls.Add(new ListItem( "删除错误数据","BB310000"));
            ls.Add(new ListItem("入院登记(回退)","DC311001"));
            ls.Add(new ListItem( "门诊结算(回退)","DC311002"));
            ls.Add(new ListItem("入院信息修正（慎用）","RYXXXZ"));

            this.cbx_Ywlx.DataSource = ls;
            this.cbx_Ywlx.ValueMember = "Value";
            this.cbx_Ywlx.DisplayMember = "Text";
        }
        private void initTsxx()
        {
            string tsxx = "东软软件：\r\n 【1】住院人员信息查询里通过姓名查询‘住院号’，‘个人编号’，当前‘住院状态’；\r\n ";
            tsxx += "【2】住院结算信息查询里通过姓名查询‘单据号’；\r\n\r\n";
            tsxx += "民腾报销接口：\r\n\r\n";
            tsxx += "系统管理--城乡错误特殊处理，需要东软的‘住院号’，‘个人编号’，‘单据号’三个参数；\r\n";
            tsxx += " 【1】如果在东软软件【住院人员信息查询】里查不到患者就诊信息，但是还提示东软住院状态是‘在院’，那就说明他在其他医院医保城乡住院，不能再做医保城乡入院登记回退或结算回退，";
            tsxx += " 只有等他在其他医院医保城乡结算完才可以；\r\n ";
            tsxx += "【2】如果东软软件【住院人员信息查询】里查到当前‘住院状态’是‘出院结算’，但是还提示东软住院状态是‘在院’或‘出院未结’，";
            tsxx += "那就说明他在其他医院已经住院，不能再结算回退，只有等他在其他医院结算完才可以；\r\n ";
            tsxx += "【3】如果提示跨月不能结算回退，则需要联系医保中心审批；\r\n ";

            this.Tbx_tsxx.Text = tsxx;
        }

        private void btn_Qd_Click(object sender, EventArgs e)
        {

            Sjzsyb syb = new Sjzsyb();
            BllItemcrossSJZ bllItemcrossSJZ = new BllItemcrossSJZ();

            if (string.IsNullOrEmpty(this.tbx_Zyh.Text.Trim()))
            {
                MessageBox.Show("住院(门诊)号不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(this.tbx_Grbh.Text.Trim()))
            {
                MessageBox.Show("个人编号不能为空！");
                return;
            }
            //读人员基本信息和帐户信息
            YBCJ_IN yw_in_ryjbxxhzh = new YBCJ_IN();
            yw_in_ryjbxxhzh.Yw = "AA311012";
            yw_in_ryjbxxhzh.Ylzh = "0";
            yw_in_ryjbxxhzh.Rc = "";
            int opt_ryjbxxhzh = yw1.ybcjhs(yw_in_ryjbxxhzh);
            if (opt_ryjbxxhzh != 0)
            {
                yw_in_ryjbxxhzh.Ylzh = this.tbx_Grbh.Text.Trim();
                yw_in_ryjbxxhzh.Rc = "";
                int opt_ryjbxxhzh1 = yw1.ybcjhs(yw_in_ryjbxxhzh);
                if (opt_ryjbxxhzh1 != 0)
                {
                    return;
                }
                this.Sfck = "0";
            }
            else
            {
                this.Sfck = "1";
            }
            string[] ryjbxxhzh_cc = yw_in_ryjbxxhzh.Cc.Split('|');
            if (ryjbxxhzh_cc[45] == "2")
            {
                this.Ybcjbz = "1";
            }
            else
            {
                this.Ybcjbz = "0";
            }
            this.tbx_xm.Text = ryjbxxhzh_cc[4];//姓名
            this.tbx_Grbh.Text = ryjbxxhzh_cc[0];//个人编号
            this.tbx_zyzt.Text = ryjbxxhzh_cc[17];//住院状态
            this.tbx_rylb.Text = ryjbxxhzh_cc[7];//人员类别
            if (this.cbx_Ywlx.SelectedValue.ToString() == "DC311003")
            {
                //结算回退
                if (string.IsNullOrEmpty(this.tbx_fph.Text.Trim()))
                {
                    MessageBox.Show("发票（单据）号不能为空！");
                    return;
                }
                //结算回退
                YBCJ_IN yw_in_zyjsht = new YBCJ_IN();
                yw_in_zyjsht.Yw = "DC311003";
                yw_in_zyjsht.Ylzh = "0";
                yw_in_zyjsht.Hisjl = this.tbx_Zyh.Text.Trim();
                yw_in_zyjsht.Rc = this.tbx_Grbh.Text.Trim() + "|" + this.tbx_Zyh.Text.Trim() + "|" + this.tbx_fph.Text.Trim() + "|" + ProgramGlobal.Username;
                int opt_zyjsht = yw1.ybcjhs(yw_in_zyjsht);
                if (opt_zyjsht != 0)
                {
                    yw_in_zyjsht.Ylzh = this.tbx_Grbh.Text.Trim();
                    int opt_zyjsht1 = yw1.ybcjhs(yw_in_zyjsht);
                    if (opt_zyjsht1 != 0)
                    {
                        MessageBox.Show(yw_in_zyjsht.Mesg, "提示信息");
                        return;
                    }
                }

                string sql1 = "delete from KC22 where AKC190='" + this.tbx_Zyh.Text.Trim() + "'";
                jkdb.Update(sql1);
                if (ryjbxxhzh_cc[45] == "2")
                {
                    string sql2 = "update inhospital set nhflag=1101 where ihspcode='" + this.tbx_Zyh.Text.Trim() + "'";
                    BllMain.Db.Update(sql2);
                }
                else
                {
                    string sqlTmp = "select inhospital.nhflag,inhospital.qfybch from inhospital where inhospital.ihspcode='" + this.tbx_Zyh.Text.Trim() + "'";
                    var dt = BllMain.Db.Select(sqlTmp);
                    try
                    {
                        if (dt.Tables[0].Rows[0]["qfybch"].ToString().Trim() == "1")
                        {
                            string sql2 = "update inhospital set nhflag=301 where ihspcode='" + this.tbx_Zyh.Text.Trim() + "'";
                            BllMain.Db.Update(sql2);
                        }
                        else if (dt.Tables[0].Rows[0]["qfybch"].ToString().Trim() == "2")
                        {
                            string sql2 = "update inhospital set nhflag=1101 where ihspcode='" + this.tbx_Zyh.Text.Trim() + "'";
                            BllMain.Db.Update(sql2);
                        }
                        else if (dt.Tables[0].Rows[0]["qfybch"].ToString().Trim() == "3")
                        {
                            string sql2 = "update inhospital set nhflag=1501 where ihspcode='" + this.tbx_Zyh.Text.Trim() + "'";
                            BllMain.Db.Update(sql2);
                        }
                    }
                    catch
                    {
                        string sql2 = "update inhospital set nhflag=301 where ihspcode='" + this.tbx_Zyh.Text.Trim() + "'";
                        BllMain.Db.Update(sql2);
                    }
                }
                string sql3 = "update ihsp_costdet set insursync = 'N',ybxfdhjebz=0,dqdzxx='',yptsxx='',yblx='',insurclass='',ypspbz=0,ybxfdhje=0  where ihsp_id in(select id from inhospital where ihspcode='" + this.tbx_Zyh.Text.Trim() + "')";
                BllMain.Db.Update(sql3);
                MessageBox.Show("医保城乡结算回退成功！");
            }
            else if (this.cbx_Ywlx.SelectedValue.ToString() == "BB310000")
            {
                YBCJ_IN yw_in_scfy = new YBCJ_IN();
                yw_in_scfy.Yw = "BB310000";
                yw_in_scfy.Ylzh = "0";
                yw_in_scfy.Hisjl = this.tbx_Zyh.Text.Trim();
                yw_in_scfy.Rc = this.tbx_Zyh.Text.Trim() + "|" + this.tbx_Zyh.Text.Trim();
                int opt_scfy = yw1.ybcjhs(yw_in_scfy);
                if (opt_scfy != 0)
                {
                    yw_in_scfy.Ylzh = this.tbx_Grbh.Text.Trim();
                    int opt_scfy1 = yw1.ybcjhs(yw_in_scfy);
                    if (opt_scfy1 != 0)
                    {
                        MessageBox.Show(yw_in_scfy.Mesg, "提示信息");
                        return;
                    }
                }

                string sql1 = "delete from KC22 where AKC190='" + this.tbx_Zyh.Text.Trim() + "'";
                jkdb.Update(sql1);
                string sql3 = "update ihsp_costdet set insursync = 'N',ybxfdhjebz=0,dqdzxx='',yptsxx='',yblx='',insurclass='',ypspbz=0,ybxfdhje=0  where ihsp_id in(select id from inhospital where ihspcode='" + this.tbx_Zyh.Text.Trim() + "')";
                BllMain.Db.Update(sql3);
                MessageBox.Show("医保城乡删除费用成功！");
            }
            else if (this.cbx_Ywlx.SelectedValue.ToString() == "DC311001")
            {
                //调用入院登记回退
                string sql_ihsp = "SELECT MSGID,ihspcode,insurcode,sfck from inhospital where ihspcode = " + DataTool.addFieldBraces(tbx_Zyh.Text.ToString());
                DataTable dt_ihsp = BllMain.Db.Select(sql_ihsp).Tables[0];
                string ihspcode = dt_ihsp.Rows[0]["ihspcode"].ToString().Trim();
                string oldmsgid = dt_ihsp.Rows[0]["MSGID"].ToString().Trim();
                string insurcode = dt_ihsp.Rows[0]["insurcode"].ToString().Trim();


                string msgid = BllItemcrossSJZ.getTradingStream(); //交易流水号
                Sjzsyb_IN syb_in = new Sjzsyb_IN();


                if (dt_ihsp.Rows[0]["sfck"].ToString() == "1")
                {
                    syb_in.Ylzh = "0";
                }
                else
                {
                    syb_in.Ylzh = ihspcode;
                }

                syb_in.Yw = "1201";
                syb_in.Rc = syb_in.Request_head()
                            + "<AAE140>0</AAE140>"//险种类型 
                            + "<AAC001>" + syb_in.Ylzh + "</AAC001>"//患者识别信息 
                            + "<AKB020>" + ProgramGlobal.AKB020 + "</AKB020>"//定点医疗机构编码 
                            + "<AKC190>" + ihspcode + "</AKC190>"//门诊/住院流水号 
                            + "<AKC020>" + insurcode + "</AKC020>"//社保卡号 
                            + "<AKA130></AKA130>"//可空 
                            + "<MSGNO>1201</MSGNO>"//交易代码 
                            + "<MSGID>" + msgid + "</MSGID>"//发送方交易流水号 
                            + "<GRANTID>H001</GRANTID>"//授权码 ,东软提供，必录
                            + "<ORGMSGNO></ORGMSGNO>"//原交易代码 
                            + "<ORGMSGID></ORGMSGID>"//原发送方交易流水号 
                            + "<OPERID>" + ProgramGlobal.User_id + "</OPERID>"//操作员编号 
                            + "<OPERNAME>" + ProgramGlobal.Nickname + "</OPERNAME>"//操作员姓名 
                            + "<BATNO>" + ProgramGlobal.batno + "</BATNO>"//业务周期号 
                            + "<OPTTIME>" + DateTime.Now.ToString("yyyyMMddHHmmss") + "</OPTTIME>"//系统时间
                            + "<INPUT>"
                                + "<AKC190>" + ihspcode + "</AKC190>"//门诊住院流水号
                                + "<AKC281>" + oldmsgid + "</AKC281>"//医院被撤销交易流水号
                            + "</INPUT>"
                            + syb_in.Request_foot();
                int opt_scfy1 = syb.ybcjhs(syb_in);


                StringReader sr = new StringReader(syb_in.Cc);
                DataSet ds = new DataSet();
                ds.ReadXml(sr);

                DataTable dt2 = ds.Tables["RESPONSEDATA"];

                string ReturnMsg = "";

                int returnnum = Convert.ToInt32(dt2.Rows[0]["RETURNNUM"].ToString());
                if (returnnum == -1)//错误，业务出参中的errorMSG为错误信息
                {
                    ReturnMsg = dt2.Rows[0]["ERRORMSG"].ToString();
                    MessageBox.Show(ReturnMsg, "提示信息");
                    return;
                }

                string sql = "update inhospital set insurstat='OO', bas_patienttype_id= '1', bas_patienttype1_id= '1',Insuritemtype='1'  where ihspcode = " + DataTool.addFieldBraces(tbx_Zyh.Text.ToString());
                int flag = BllMain.Db.Update(sql);
                if (flag < 0)
                {
                    MessageBox.Show("入院取消成功,医保状态修改失败!", "提示信息");
                    return;
                }
                string sql2 = "update inhospital set ihspcode=CONCAT('X',ihspcode), status='XX', enterdep='OO' where ihspcode = " + DataTool.addFieldBraces(tbx_Zyh.Text.ToString()) + "; delete from ihsp_info where ihsp_id = (select id from inhospital where ihspcode = " + DataTool.addFieldBraces(tbx_Zyh.Text.ToString()) + ")  and registkind='IHSP';";
                flag = BllMain.Db.Update(sql);
                if (flag < 0)
                {
                    MessageBox.Show("住院回退失败!", "提示信息");
                    return;
                }
                MessageBox.Show("入院回退成功!", "提示信息");
                this.Close(); 
                
            }
            if (cbx_Ywlx.SelectedValue.ToString().Trim() == "DC311002")
            {
                //结算回退
                YBCJ_IN yw_in_mzjsht = new YBCJ_IN();
                yw_in_mzjsht.Yw = "DC311002";
                yw_in_mzjsht.Ylzh = "0";
                yw_in_mzjsht.Hisjl = this.tbx_Zyh.Text.Trim();
                yw_in_mzjsht.Rc = this.tbx_Grbh.Text.Trim() + "|" + this.tbx_Zyh.Text.Trim() + "|" + this.tbx_fph.Text.Trim() + "|" + ProgramGlobal.Username;
                int opt_mzjsht = yw1.ybcjhs(yw_in_mzjsht);
                if (opt_mzjsht != 0)
                {
                    yw_in_mzjsht.Ylzh = this.tbx_Grbh.Text.Trim();
                    int opt_mzjsht1 = yw1.ybcjhs(yw_in_mzjsht);
                    if (opt_mzjsht1 != 0)
                    {
                        MessageBox.Show(yw_in_mzjsht.Mesg, "提示信息");
                        return;
                    }
                }
                MessageBox.Show("医保城乡门诊结算回退成功！");
            }
        }

        private void btn_cxyblog_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.tbx_Zyh.Text.Trim()))
            {
                MessageBox.Show("住院(门诊)号不能为空！");
                return;
            }
            try
            {
                Process.Start(@"D:\MTlog\logs_yb\" + this.tbx_Zyh.Text.Trim() + ".txt");
            }
            catch
            { }
        }
    }
}
