﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTHIS.db;
using MTREG.common.bll;
using MTHIS.main.bll;
using MTHIS.common;
using MTREG.medinsur.hdyb.dor;
using MTREG.medinsur.hdyb.clinic;
using MTREG.medinsur.hdyb.bll;

namespace MTREG.medinsur.hdyb
{
    public partial class FrmChRy : Form
    {
        public FrmChRy()
        {
            InitializeComponent();
        }
        //
        YBCJ yw1 = new YBCJ();

        private bool flag;
        /// <summary>
        /// 标志位
        /// </summary>
        public bool Flag
        {
            get { return flag; }
            set { flag = value; }
        }
        private string ylfkfs_id;
        /// <summary>
        /// 医疗付款方式id
        /// </summary>
        public string Ylfkfs_id
        {
            get { return ylfkfs_id; }
            set { ylfkfs_id = value; }
        }
        private string fszt;
        /// <summary>
        /// 封锁状态
        /// </summary>
        public string Fszy
        {
            get { return fszt; }
            set { fszt = value; }
        }
        private string zyjlh;//
        /// <summary>
        /// 住院记录号
        /// </summary>
        public string Zyjlh
        {
            get { return zyjlh; }
            set { zyjlh = value; }
        }
        ZfRydj zfrydj = new ZfRydj();
        /// <summary>
        /// 界面信息
        /// </summary>
        public ZfRydj Zfrydj
        {
            get { return zfrydj; }
            set { zfrydj = value; }
        }
        private void FrmChRy_Load(object sender, EventArgs e)
        {
            initYllb();
            initMessage();
        }
        private void initYllb()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("21", "普通住院"));
            items.Add(new ListItem("25", "转入住院"));
            items.Add(new ListItem("26", "困难企业住院"));
            items.Add(new ListItem("28", "年终结算"));
            items.Add(new ListItem("29", "年终结算后出院"));
            items.Add(new ListItem("51", "顺产"));
            items.Add(new ListItem("55", "剖腹产"));
            this.comboYllb.DisplayMember = "Text";
            this.comboYllb.ValueMember = "Value";
            this.comboYllb.DataSource = items;
        }
        /// <summary>
        /// 初始化病人信息
        /// </summary>
        private void initMessage()
        {
            this.RydjXm.Text = zfrydj.Brxm;//姓名
            this.RydjNl.Text = zfrydj.Brnl;//年龄
            this.RydjKs.Text = zfrydj.Ryks;//入院科室
            this.RydjYs.Text = zfrydj.Ysname;//医生
            this.RydjRyrq.Text = zfrydj.Rysj;//入院时间
            this.RydjBfh.Text = zfrydj.Bfh;//病房号
            this.RydjBc.Text = zfrydj.Bch;//病床号
            this.RydjZyh.Text = zfrydj.Zyh;//住院号
            this.textBox1.Text = zfrydj.MTel;//联系方式
            this.RydjSfzh.Text = zfrydj.Brsfzh;//病人身份证号
            if (zfrydj.Brdz != null)//住址
            {
                if (zfrydj.Brdz.Length > 17)
                {
                    this.txtzz.Text = zfrydj.Brdz.Substring(0, 17);
                }
                else
                {
                    this.txtzz.Text = zfrydj.Brdz;
                }
            }
            this.txtzy.Text = zfrydj.Ctctprof;//职业
            if (zfrydj.Brsfzh != "")
            {
                this.tbx_jmylzh.Text = zfrydj.Brsfzh;//病人身份证号
            }
            if (zfrydj.Mzryzd != "")//诊断
            {
                this.txt_ryzd.Text = zfrydj.Mzryzd;
            }
            else
            {
                this.txt_ryzd.Text = zfrydj.Zyryzd;
            }
            #region
            //if (zfrydj.Zyryzd.Contains("1"))
            //{

            //    string[] retdata = zfrydj.Zyryzd.Split('2');
            //    this.tbx_jbmc.Text = retdata[0].Trim();
            //}
            //else
            //{
            //    this.tbx_jbmc.Text = zfrydj.Zyryzd.Trim();
            //}
            #endregion
        }

        private void btn_wk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.tbx_jmylzh.Text.Trim()))
            {
                MessageBox.Show("请输入身份证（个人编）号！");
                return;
            }
            //读人员基本信息和帐户信息
            YBCJ_IN yw_in_ryjbxxhzh = new YBCJ_IN();
            yw_in_ryjbxxhzh.Yw = "AA311012";
            yw_in_ryjbxxhzh.Ybcjbz = "1";
            yw_in_ryjbxxhzh.Ylzh = tbx_jmylzh.Text.Trim();
            yw_in_ryjbxxhzh.Hisjl = RydjZyh.Text.Trim();
            yw_in_ryjbxxhzh.Rc = "";
            int opt_ryjbxxhzh = yw1.ybcjhs(yw_in_ryjbxxhzh);
            if (opt_ryjbxxhzh != 0)
            {
                Tbx_tsxx.Text += yw_in_ryjbxxhzh.Mesg + "\r\n";
                MessageBox.Show(yw_in_ryjbxxhzh.Mesg, "提示信息");
                return;
            }
            Tbx_tsxx.Text += yw_in_ryjbxxhzh.Mesg + "\r\n";
            string[] ryjbxxhzh_cc = yw_in_ryjbxxhzh.Cc.Split('|');
            //读封锁信息
            string grbh = ryjbxxhzh_cc[0];
            this.RydjGrbh.Text = grbh;//个人编号
            YBCJ_IN yw_in_ryfsxx = new YBCJ_IN();
            yw_in_ryfsxx.Yw = "AB31KC08";
            yw_in_ryfsxx.Ybcjbz = "1";
            yw_in_ryfsxx.Ylzh = grbh;
            yw_in_ryfsxx.Hisjl = RydjZyh.Text.Trim();
            yw_in_ryfsxx.Rc = grbh;
            int opt_ryfsxx = yw1.ybcjhs(yw_in_ryfsxx);
            if (opt_ryfsxx != 0)
            {
                Tbx_tsxx.Text += yw_in_ryfsxx.Mesg + "\r\n";
                MessageBox.Show(yw_in_ryfsxx.Mesg, "提示信息");
                return;
            }
            Tbx_tsxx.Text += yw_in_ryfsxx.Mesg + "\r\n";
            string[] ryfsxx_cc = yw_in_ryfsxx.Cc.Split('|');

            int fsjb = int.Parse(ryfsxx_cc[4]);
            if (fsjb == 1)
            {
                this.label_fsqk.Text = "统筹不可用";
                if (MessageBox.Show("此卡处于半封锁状态，应由统筹支付的医疗费用需由个人现金支付!", "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    this.btn_qd.Enabled = false;
                    return;
                }
            }
            else if (fsjb == 2)
            {
                this.btn_qd.Enabled = false;
                this.label_fsqk.Text = "全封锁";
                MessageBox.Show("此卡已经被封锁，不能再用此卡看病！", "提示信息");
                return;
            }
            else if (fsjb == 0)
            {
                this.btn_qd.Enabled = true;
                this.label_fsqk.Text = "不封";
            }
            this.tbx_dkxm.Text = ryjbxxhzh_cc[4];//姓名
            this.tbx_dkickh.Text = ryjbxxhzh_cc[3];//IC卡号
            this.RydjDwbh.Text = ryjbxxhzh_cc[2];//单位编号 
            this.tbx_dkzyzt.Text = ryjbxxhzh_cc[17];//住院状态
            this.tbx_dwmc.Text = ryjbxxhzh_cc[38];//单位名称
            this.txt_qybh.Text = ryjbxxhzh_cc[21];//区域编号
            this.txt_rylb.Text = ryjbxxhzh_cc[7];//人员类别
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

            this.rydjZhye.Text = (lnjz + bnzr - zhzc).ToString().Trim();
            //dkxx_syb = ryjbxxhzh;//保存读卡信息
            fszt = this.label_fsqk.Text;

            string sql_gxsfck = "update inhospital set sfck=0 where id='" + this.zyjlh + "'";
            BllMain.Db.Update(sql_gxsfck);
            btn_ry.Focus();
        }

        private void btn_yk_Click(object sender, EventArgs e)
        {
            //读人员基本信息和帐户信息
            YBCJ_IN yw_in_ryjbxxhzh = new YBCJ_IN();
            yw_in_ryjbxxhzh.Yw = "AA311012";
            yw_in_ryjbxxhzh.Ybcjbz = "1";
            yw_in_ryjbxxhzh.Ylzh = "0";
            yw_in_ryjbxxhzh.Hisjl = RydjZyh.Text.Trim();
            yw_in_ryjbxxhzh.Rc = "";
            int opt_ryjbxxhzh = yw1.ybcjhs(yw_in_ryjbxxhzh);
            if (opt_ryjbxxhzh != 0)
            {
                Tbx_tsxx.Text += yw_in_ryjbxxhzh.Mesg + "\r\n";
                MessageBox.Show(yw_in_ryjbxxhzh.Mesg, "提示信息");
                return;
            }
            Tbx_tsxx.Text += yw_in_ryjbxxhzh.Mesg + "\r\n";
            string[] ryjbxxhzh_cc = yw_in_ryjbxxhzh.Cc.Split('|');
            //读封锁信息
            string grbh = ryjbxxhzh_cc[0];
            this.RydjGrbh.Text = grbh;//个人编号
            YBCJ_IN yw_in_ryfsxx = new YBCJ_IN();
            yw_in_ryfsxx.Yw = "AB31KC08";
            yw_in_ryfsxx.Ybcjbz = "1";
            yw_in_ryfsxx.Ylzh = "1";
            yw_in_ryfsxx.Hisjl = RydjZyh.Text.Trim();
            yw_in_ryfsxx.Rc = grbh;
            int opt_ryfsxx = yw1.ybcjhs(yw_in_ryfsxx);
            if (opt_ryfsxx != 0)
            {
                Tbx_tsxx.Text += yw_in_ryfsxx.Mesg + "\r\n";
                MessageBox.Show(yw_in_ryfsxx.Mesg, "提示信息");
                return;
            }
            Tbx_tsxx.Text += yw_in_ryfsxx.Mesg + "\r\n";
            string[] ryfsxx_cc = yw_in_ryfsxx.Cc.Split('|');

            int fsjb = int.Parse(ryfsxx_cc[4]);
            if (fsjb == 1)
            {
                this.label_fsqk.Text = "统筹不可用";
                if (MessageBox.Show("此卡处于半封锁状态，应由统筹支付的医疗费用需由个人现金支付!", "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    this.btn_qd.Enabled = false;
                    return;
                }
            }
            else if (fsjb == 2)
            {
                this.btn_qd.Enabled = false;
                this.label_fsqk.Text = "全封锁";
                MessageBox.Show("此卡已经被封锁，不能再用此卡看病！", "提示信息");
                return;
            }
            else if (fsjb == 0)
            {
                this.btn_qd.Enabled = true;
                this.label_fsqk.Text = "不封";
            }
            this.tbx_dkxm.Text = ryjbxxhzh_cc[4];//姓名
            this.tbx_dkickh.Text = ryjbxxhzh_cc[3];//IC卡号
            this.RydjDwbh.Text = ryjbxxhzh_cc[2];//单位编号 
            this.tbx_dkzyzt.Text = ryjbxxhzh_cc[17];//住院状态
            this.tbx_dwmc.Text = ryjbxxhzh_cc[38];//单位名称
            this.txt_qybh.Text = ryjbxxhzh_cc[21];//区域编号
            this.txt_rylb.Text = ryjbxxhzh_cc[7];//人员类别
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

            this.rydjZhye.Text = (lnjz + bnzr - zhzc).ToString().Trim();
            //dkxx_syb = ryjbxxhzh;//保存读卡信息
            fszt = this.label_fsqk.Text;

            string sql_gxsfck = "update inhospital set sfck=1 where ihspcode='" + this.RydjZyh.Text.Trim() + "'";
            BllMain.Db.Update(sql_gxsfck);
            //string zyh = this.RydjZyh.Text.Trim();//住院号
            btn_ry.Focus();
        }

        private void btn_ry_Click(object sender, EventArgs e)
        {
            //住院状态
            string zyzt = this.tbx_dkzyzt.Text;
            if (zyzt == "住院未结算" || zyzt == "出院未结算" || zyzt == "出院未结" || zyzt == "在院")
            {
                MessageBox.Show("此人目前为城乡住院状态，不能再做入院登记业务操作！请去【东软软件】里的‘住院人员信息查询’里通过姓名查询‘住院号’，‘个人编号’，当前‘住院状态’；如果东软查不到，但是无卡时还提示东软住院状态是‘在院’，那就说明他在其他医院住院，不能城乡入院，只有等他在其他医院城乡结算完才可以！", "提示信息");
            }
            if (this.RydjGrbh.Text.Trim() == "" || this.RydjGrbh.Text.Trim() == null)
            {
                MessageBox.Show("请输入身份证号或个人编号，读卡获取病人信息！", "提示信息");
                return;
            }
            string jbmcTmp = this.cyjsCyjb.Text;
            if (string.IsNullOrEmpty(jbmcTmp))
            {
                MessageBox.Show("请填写疾病名称!");
                return;
            }
            string xm_ = this.RydjXm.Text.Trim();
            if (this.tbx_dkxm.Text.Trim() != xm_)
            {
                MessageBox.Show(string.Format(@"患者姓名与城乡卡持有者不一致，请确认！(患者姓名为：【{0}】,医保卡持有者姓名为：【{1}】)", xm_, this.tbx_dkxm.Text.Trim()));
                flag = false;
                return;
            }
            else if (dataUpload())
            {
                flag = true;
                MessageBox.Show("城乡入院成功！", "提示信息");
                this.Dispose();
                return;
            }
            else
            {
                flag = false;
                MessageBox.Show("城乡接口上传失败!");
                return;
            }
        }
        /// <summary>
        /// 城乡数据上传
        /// </summary>
        /// <returns></returns>
        private bool dataUpload()
        {
            string jmylzh = this.RydjGrbh.Text.Trim();
            string zyh = this.RydjZyh.Text.Trim();//住院号
            string ickh = this.tbx_dkickh.Text.Trim();//ic卡号
            string xm = this.tbx_dkxm.Text.Trim();//读卡-姓名
            string grbh = this.RydjGrbh.Text.Trim();//个人编号
            string dwbh = this.RydjDwbh.Text.Trim();//单位编号
            string ryrq = Convert.ToDateTime(this.RydjRyrq.Text.Trim()).ToString("yyyy-MM-dd HH:mm:ss");
            string bch = this.RydjBc.Text.Trim();//病床号
            string bfh = this.RydjBfh.Text.Trim();//病房号
            string ys = this.RydjYs.Text.Trim();//医生
            string ks = this.RydjKs.Text.Trim();//科室
            string yllb = this.comboYllb.SelectedValue.ToString().Trim();//医疗类别
            string jbbm = this.cyjsjbbm.Text.Trim();//疾病编码
            string jbmc = this.cyjsCyjb.Text.Trim();//疾病名称
            string jbr = ProgramGlobal.Username;//经办人
            string zz = this.txtzz.Text.Trim();//住址
            string zy = this.txtzy.Text.Trim();//职业
            string lxfs = this.textBox1.Text.Trim();//联系方式
            string dqrq = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string search_sql = "select count(*) from KC21 where AKC190='" + zyh + "'";

            string sql = "INSERT INTO KC21 (AKC190,CKC502,AAC003,AAC001,AAB001,AKA130,AKC192,AKC193,zkc274,zkc271,zkc272,Cka040,Cka041,AAE011,AAE036,CKC126,zhiye,zhuzhi,zkc282) values ";
            sql += "('" + zyh + "','" + ickh + "','" + xm + "','" + grbh + "','" + dwbh + "','" + yllb + "','" + ryrq + "','" + jbbm + "','" + jbmc + "','" + ys + "','" + ks + "','" + bfh + "','" + bch + "','" + jbr + "','" + dqrq + "',0,'" + zy + "','" + zz + "','" + lxfs + "')";
            JKDB db = new JKDB();
            DataSet ds = db.Select(search_sql);
            if (int.Parse(ds.Tables[0].Rows[0][0].ToString()) == 0)
            {
                if (db.Update(sql) == -1)
                {
                    ProgramGlobal.SysWriteLogs.writeLogs("转医保城乡插入KC21表失败", DateTime.Now, "sql=" + sql);
                    MessageBox.Show("转医保城乡，插入KC21表失败！");
                    return false;
                }
            }
            //入院登记
            YBCJ_IN yw_in_rydj = new YBCJ_IN();
            yw_in_rydj.Yw = "CC311001";
            yw_in_rydj.Ybcjbz = "1";
            string sql_gxsfck = "select sfck from inhospital where ihspcode='" + zyh + "'";
            DataSet ds_sfck = BllMain.Db.Select(sql_gxsfck);
            if (ds_sfck.Tables[0].Rows[0]["sfck"].ToString() == "1")
            {
                yw_in_rydj.Ylzh = "0";
            }
            else
            {
                yw_in_rydj.Ylzh = grbh;
            }
            yw_in_rydj.Hisjl = RydjZyh.Text.Trim();
            yw_in_rydj.Rc = grbh + "|" + zyh;
            int opt_rydj = yw1.ybcjhs(yw_in_rydj);
            if (opt_rydj != 0)
            {
                this.del_kc21_zyh(zyh);//入院登记失败，删除kc21相应记录
                Tbx_tsxx.Text += yw_in_rydj.Mesg + "\r\n";
                MessageBox.Show(yw_in_rydj.Mesg, "提示信息");
                return false;
            }
            Tbx_tsxx.Text += yw_in_rydj.Mesg + "\r\n";
            string[] rydj_cc = yw_in_rydj.Cc.Split('|');
            //入院登记成功
            this.up_ryjbxx_jk_csbz(zyh);//修改KC21传输标志，置为1
            string sql2 = "update inhospital set nhflag=1101,qfybch = 2,qh='" + txt_qybh.Text.Trim() + "',insurcode=  '" + grbh + "',yllb = '" + yllb + "',bas_patienttype_id= " + ylfkfs_id + ",Insuritemtype='41' where ihspcode= '" + zyh + "';";//修改his系统nhflag标志，置为1101
            //sql2 += " update ihsp_info set companyname = '" + tbx_dwmc.Text + "' where ihsp_id = " + zyjlh + ";";
            if (BllMain.Db.Update(sql2) == -1)
            {
                SysWriteLogs.writeLogs1("转城乡居民成功，但更新HIS-mtzyjl表标志失败！", DateTime.Now, "sql=" + sql2);
                MessageBox.Show("转城乡居民成功，但更新HIS-mtzyjl表标志失败！");
                return false;
            }
            return true;
        }
        private void del_kc21_zyh(string zyh)
        {
            string sql = "delete from KC21 where AKC190='" + zyh + "'";
            JKDB jkdb = new JKDB();
            jkdb.Update(sql);
        }
        private void up_ryjbxx_jk_csbz(String zyh)//修改kc21传输标志，置为1
        {
            String sql = "UPDATE KC21 SET CKC126 =1 WHERE AKC190='" + zyh + "';";
            JKDB jkdb = new JKDB();//更改KC21 医保接口表 KC21 的传输标志
            jkdb.Update(sql);
        }

        private void btn_tc_Click(object sender, EventArgs e)
        {
            string zyh = this.RydjZyh.Text.Trim();
            string nh="select nhflag from inhospital where ihspcode= '" + zyh + "'";
            DataSet ds_nh = BllMain.Db.Select(nh);
            if (ds_nh.Tables[0].Rows[0]["nhflag"].ToString() == "0")
            {
                string sql = "update inhospital set bas_patienttype_id=1 where ihspcode= '" + zyh + "'";
                BllMain.Db.Update(sql);
                this.flag = false;
                this.Dispose();
            }
            else
            {
                this.flag = false;
                this.Dispose();
            }
            
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
            if (e.KeyValue == (char)Keys.Space)
            {
                sql = " select illcode as code,name as name,pincode as jm from insur_illness where cost_insurtype_id='19' ";

                ryzddata = BllMain.Db.Select(sql).Tables[0];
                if (dgw_ryjbmc.Rows.Count > 0)
                {
                    dgw_ryjbmc.DataSource = ryzddata;
                    dgw_ryjbmc.Visible = true;
                }
                else
                {
                    dgw_ryjbmc.Visible = false;
                }
                return;
            }
            //查询
            if (cyjsjbbm.Text.Trim().Equals(""))
            {
                dgw_ryjbmc.Visible = false;
                return;
            }
            string tiaojian = " where 1=1 and illcode like '%" + cyjsjbbm.Text.Trim() + "%' or name like '%" + cyjsjbbm.Text.Trim() + "%' or pincode like '%" + cyjsjbbm.Text.Trim().ToUpper() + "%'";
            sql = " select illcode as code,name as name,pincode as jm from insur_illness " + tiaojian;
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

        private void dgw_ryjbmc_KeyDown(object sender, KeyEventArgs e)
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

        private void dgw_ryjbmc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                cyjsCyjb.Text = dgw_ryjbmc.Rows[e.RowIndex].Cells["ryzdname"].Value.ToString().Trim();
                cyjsjbbm.Text = dgw_ryjbmc.Rows[e.RowIndex].Cells["ryzdcode"].Value.ToString().Trim();
                dgw_ryjbmc.Visible = false;
                cyjsjbbm.Focus();
            }
        }

        private void btn_qd_Click(object sender, EventArgs e)
        {

        }


    }
}
