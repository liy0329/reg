using System;
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
using MTREG.medinsur.sjzsyb.bll;
using MTREG.medinsur.sjzsyb.clinic;
using MTREG.medinsur.sjzsyb.dor;
using System.Xml;
using System.IO;
using MTREG.medinsur.sjzsyb.bean;
using MTREG.ihsp.bll;

namespace MTREG.medinsur.sjzsyb
{
    public partial class FrmSybRy : Form
    {
        Sjzsyb syb = new Sjzsyb();
        public FrmSybRy()
        {
            InitializeComponent();
        }
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
        private string zyjlh;
        /// <summary>
        /// 住院记录号
        /// </summary>
        public string Zyjlh
        {
            get { return zyjlh; }
            set { zyjlh = value; }
        }
        /// <summary>
        /// 个人编号
        /// </summary>
        private string grbh { get; set; }

        ZfRydj zfrydj = new ZfRydj();
        /// <summary>
        /// 界面信息
        /// </summary>
        public ZfRydj Zfrydj
        {
            get { return zfrydj; }
            set { zfrydj = value; }
        }
        private void FrmSybRy_Load(object sender, EventArgs e)
        {
            initYllb();
            initMessage();
            initSYlb();
            initDir();
        }

        private void initSYlb()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("", "无"));
            items.Add(new ListItem("30", "自然分娩"));
            items.Add(new ListItem("31", "人工干预分娩（手剥胎盘术、子宫 破裂、产钳术、臀位牵引术、胎头 吸引术、毁胎手术分娩）"));
            items.Add(new ListItem("32", "剖宫产"));
            items.Add(new ListItem("33", "剖宫产伴子宫肌瘤切除术、卵巢囊 肿切除术、子宫切除术、阑尾切除 术、输卵管结扎术等其他手术"));
            items.Add(new ListItem("34", "因母婴原因住院终止妊娠术"));
            items.Add(new ListItem("35", "因母婴原因门诊终止妊娠术"));
            items.Add(new ListItem("36", "宫腔内节育器情况检查"));
            items.Add(new ListItem("37", "放置（取出）宫腔内节育器术"));
            items.Add(new ListItem("38", "皮下埋植（取出）术"));
            items.Add(new ListItem("39", "输精管结扎术"));
            items.Add(new ListItem("40", "输卵管结扎术"));
            items.Add(new ListItem("41", "输精管复通术"));
            items.Add(new ListItem("42", "输卵管复通术"));
            items.Add(new ListItem("43", "住院终止妊娠术"));
            items.Add(new ListItem("44", "门诊终止妊娠术"));
            items.Add(new ListItem("45", "职工因治疗计划生育手术并发症"));
            this.comboSYlb.DisplayMember = "Text";
            this.comboSYlb.ValueMember = "Value";
            this.comboSYlb.DataSource = items;
        }
        private void initYllb()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("21", "普通住院"));
            items.Add(new ListItem("25", "转入住院"));
            items.Add(new ListItem("27", "意外伤害住院"));
            items.Add(new ListItem("52", "生育住院"));
            this.comboYllb.DisplayMember = "Text";
            this.comboYllb.ValueMember = "Value";
            this.comboYllb.DataSource = items;
            this.comboYllb.SelectedValue = "21";
        }
        private void initDir()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("34", "职工医保"));
            items.Add(new ListItem("35", "居民医保"));
            this.combohzlb.DisplayMember = "Text";
            this.combohzlb.ValueMember = "Value";
            this.combohzlb.DataSource = items;
        }
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
            this.tbx_sfzh.Text = zfrydj.Brsfzh;//病人身份证号
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
            this.mzryzd.Text = zfrydj.Mzryzd;//
            this.tbx_jbmc.Text = zfrydj.Mzryzd;
            this.cyjsjbbm.Text = zfrydj.Mzryzd_bm;
            if (zfrydj.Brsfzh != "")
            {
                this.tbx_jmylzh.Text = zfrydj.Brsfzh;//病人身份证号
            }
            //if (zfrydj.Mzryzd != "")//诊断
            //{
            //    this.txt_ryzd.Text = zfrydj.Mzryzd;
            //}
            //else
            //{
            //    this.txt_ryzd.Text = zfrydj.Zyryzd;
            //}
        }
        /// <summary>
        /// 有卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_yk_Click(object sender, EventArgs e)
        {
            SJZYB_IN<DK_IN> yb_in_dk = new SJZYB_IN<DK_IN>();
            SjzybInterface sjzybInterface = new SjzybInterface();
            yb_in_dk.INPUT = new List<DK_IN>();
            DK_IN dk = new DK_IN();
            DK_OUT yb_out_dk = new DK_OUT();
            dk.BKA130 = "20";//出院预结算
            yb_in_dk.INPUT.Add(dk);
            yb_in_dk.MSGNO = "1401";
            yb_in_dk.AAC001 = "0";
            //dk_out.sfcf = "0";
            int ret = sjzybInterface.DK(yb_in_dk, ref yb_out_dk);
            if (ret == -1)
            {
                MessageBox.Show(yb_out_dk.ERRORMSG, "提示信息");
                return;
            }
            else
            {
                this.tbx_jmylzh.Text = yb_out_dk.AAC002.ToString();//身份证
                this.tbx_dkxm.Text = yb_out_dk.AAC003.ToString().Replace(" ","");//姓名
                this.tbx_xb.Text = (yb_out_dk.AAC004.ToString() == "1") ? "男" : "女";//性别
                BillCmbList BillCmbList = new BillCmbList();
                DataTable dt = BillCmbList.getRaceInfo_code(yb_out_dk.AAC005);
                if (dt.Rows.Count >= 1)
                {
                    this.tbx_mz.Text = dt.Rows[0]["name"].ToString();
                }
                else
                {
                    this.tbx_mz.Text = "无";
                }
                this.tbx_csrq.Text = yb_out_dk.AAC006.ToString();//出生日期
                grbh = yb_out_dk.AAC001.ToString();//个人编号
                //this.tbx_dwbh.Text = yb_out_dk.AAB001.ToString();//单位编号
                this.tbx_dkickh.Text = yb_out_dk.AKC020.ToString();//卡号
                if (yb_out_dk.AKC021.ToString() == "11")
                    this.tbx_rylb.Text = "在职";//人员类别
                if (yb_out_dk.AKC021.ToString() == "21")
                    this.tbx_rylb.Text = "退休";//人员类别
                if (yb_out_dk.AKC021.ToString() == "31")
                    this.tbx_rylb.Text = "机关离休";//人员类别
                if (yb_out_dk.AKC021.ToString() == "32")
                    this.tbx_rylb.Text = "企事业离休";//人员类别
                if (yb_out_dk.AKC021.ToString() == "33")
                    this.tbx_rylb.Text = "医疗费实报实销六级及以上伤残军人";//人员类别
                if (yb_out_dk.AKC021.ToString() == "41")
                    this.tbx_rylb.Text = "城乡居民";//人员类别
                if (yb_out_dk.AKC021.ToString() == "99")
                    this.tbx_rylb.Text = "其他";//人员类别

                string yllb = yb_out_dk.AKC021;

                if (yllb == "41")
                {
                    combohzlb.SelectedValue = "35";
                }
                else
                {
                    combohzlb.SelectedValue = "34";
                }
                //添加患者类型
                ylfkfs_id = combohzlb.SelectedValue.ToString();
;

                this.tbx_cbrq.Text = yb_out_dk.AAC030.ToString();//参保日期
                this.tbx_ryzt.Text = yb_out_dk.AAC008.ToString();//人员状态
                if (yb_out_dk.ZKC031.ToString() == "0")
                    this.tbx_zyzt.Text = "不在院";//住院状态
                if (yb_out_dk.ZKC031.ToString() == "1")
                    this.tbx_zyzt.Text = "在院";//住院状态
                if (yb_out_dk.ZKC031.ToString() == "2")
                    this.tbx_zyzt.Text = "出院未结算";//住院状态
                this.tbx_zhye.Text = yb_out_dk.AKC087.ToString();//账户余额
                this.tbx_cbdm.Text = yb_out_dk.AKC803.ToString();//参保地行政区划代码
                this.tbx_cbmc.Text = yb_out_dk.AKC804.ToString();//参保地行政区划名称
                this.tbx_zycs.Text = yb_out_dk.AKC090.ToString();//住院次数
                if (yb_out_dk.CKAA35.ToString() == "0")
                    this.tbx_pkrk.Text = "否";//贫困人口标识
                if (yb_out_dk.CKAA35.ToString() == "1")
                    this.tbx_pkrk.Text = "是";//贫困人口标识

                this.tbx_dwmc.Text = "";// yb_out_dk.AAB004.ToString();//单位名称
            }
            btn_ry.Focus();
        }
        /// <summary>
        /// 入院
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ry_Click(object sender, EventArgs e)
        {
            if (this.tbx_jbmc.Text.Trim().ToString() == "")
            {
                MessageBox.Show("疾病名称不能为空!");
                return;
            }
            if (this.cyjsjbbm.Text.Trim().ToString() == "")
            {
                MessageBox.Show("疾病编码不能为空!");
                return;
            }
            //住院状态
            string zyzt = this.tbx_zyzt.Text;
            if (zyzt == "1" || zyzt == "2")//0=不在院，1=在院，2=出院未结算
            {
                this.btn_ry.Enabled = false;
                //MessageBox.Show("此人目前为职工住院状态，不能再做入院登记业务操作！请去【东软软件】里的‘住院人员信息查询’里通过姓名查询‘住院号’，‘个人编号’，当前‘住院状态’；如果东软查不到，但是无卡时还提示东软住院状态是‘在院’，那就说明他在其他医院住院，不能职工入院，只有等他在其他医院职工结算完才可以！", "提示信息");
                return;
            }

            string xm_ = this.RydjXm.Text.Trim().ToString().Trim();
            string mess = "";
            if (this.tbx_dkxm.Text.Trim() != xm_)
            {
                MessageBox.Show(string.Format(@"患者姓名与医保卡持有者不一致，请确认！(患者姓名为：【{0}】,医保卡持有者姓名为：【{1}】)", xm_, this.tbx_dkxm.Text.Trim()));
                flag = false;
                return;
            }
            else if (dataUpload(ref mess))
            {
                flag = true;
                // MessageBox.Show("医保入院成功！如果是异地医保！请马上去东软软件【打印异地通知单】！", "提示信息");
                MessageBox.Show("医保入院成功！", "提示信息");
                this.Dispose();
                return;
            }
            else
            {
                MessageBox.Show("转医保入院失败！"+ mess);
                return;
            }
        }

        int jzsx = 0;//拼接KC33时需要循环添加就诊顺序字段
        public string suijishu()
        {
            Random rad = new Random();//实例化随机数产生器rad；
            int value = rad.Next(1000, 10000);//用rad生成大于等于1000，小于等于9999的随机数；
            string suijishu = value.ToString(); //转化为字符串；
            return suijishu;
        }
        private bool dataUpload(ref string messges)
        {
            //string jmylzh = this.tbx_grbh.Text.Trim();
            string zyh = this.RydjZyh.Text.Trim();//住院号
            string ickh = this.tbx_dkickh.Text.Trim();//ic卡号
            string xm = this.tbx_dkxm.Text.Trim();//读卡-姓名
            //string grbh = this.tbx_grbh.Text.Trim();//个人编号
            //string dwbh = this.tbx_dwbh.Text.Trim();//单位编号
            string ryrq = Convert.ToDateTime(this.RydjRyrq.Text.Trim()).ToString("yyyyMMddHHmmss");//入院日期
            string bch = this.RydjBc.Text.Trim();//病床号
            string bfh = this.RydjBfh.Text.Trim();//病房号
            string ys = this.RydjYs.Text.Trim();//医生
            string ks = this.RydjKs.Text.Trim();//科室
            string yllb = this.comboYllb.SelectedValue.ToString().Trim();//医疗类别
            string jbbm = this.cyjsjbbm.Text.Trim();//疾病编码
            string jbmc = this.tbx_jbmc.Text.Trim();//疾病名称
            string sylb = this.comboSYlb.SelectedValue.ToString().Trim();//生育类别
            string ryyz = this.ryyz.Text.Trim();//孕周
            string jbr = ProgramGlobal.Username;//经办人
            string zz = this.txtzz.Text.Trim();//住址
            string zy = this.mzryzd.Text.Trim();//职业
            string lxfs = this.textBox1.Text.Trim();//联系方式
            string dqrq = DateTime.Now.ToString("yyyyMMddHHmmss");

            string BKF040 = "";//中心科室编码
            string BKF050 = "";//中心医师编码
            messges = "";//错误信息

            //查询科室的中心编码
            string ks_sql = "select AKF001 from contrast_dep where  bas_depart_id='" + Zfrydj.ryks_id + "'";
            DataTable ks_dt = BllMain.Db.Select(ks_sql).Tables[0];
            if (ks_dt.Rows.Count == 0)
            {
                messges += "未找到对应的医保科室";
                return false;
            }
            if (!string.IsNullOrEmpty(ks_dt.Rows[0][0].ToString()))
            {
                BKF040 = ks_dt.Rows[0][0].ToString();
            }
            //查询医师的中心编码
            string ys_sql = "select BKF050 from contrast_doc where bas_doctor_id='" + Zfrydj.ysname_id + "'";
            DataTable ys_dt = BllMain.Db.Select(ys_sql).Tables[0];
            if (ys_dt.Rows.Count == 0)
            {
                messges += "未找到对应的医保医生";
                return false;
            }
            if (!string.IsNullOrEmpty(ys_dt.Rows[0][0].ToString()))
            {
                BKF050 = ys_dt.Rows[0][0].ToString();
            }

            SJZYB_IN<DBNull> yb_in_dj = new SJZYB_IN<DBNull>();
            SJZYB_OUT yb_out_dj = new SJZYB_OUT();
            yb_in_dj.KC21XML = new KC21();
            yb_in_dj.AKC190 = zyh;
            yb_in_dj.AAC001 = "0";
            yb_in_dj.AKA130 = yllb;
            yb_in_dj.MSGNO = "1101";
            yb_in_dj.AKC020 = ickh;
            yb_in_dj.KC21XML.AKC190 = zyh;
            yb_in_dj.KC21XML.AKA130 = yllb;
            if (yllb =="27" )
            yb_in_dj.KC21XML.AKC120 = "1";
            yb_in_dj.KC21XML.AKC192 = ryrq;
            yb_in_dj.KC21XML.AKC193 = jbbm;
            yb_in_dj.KC21XML.AAE011 = jbr;
            yb_in_dj.KC21XML.AAE036 = dqrq;
            yb_in_dj.KC21XML.AKC008 = ys;
            yb_in_dj.KC21XML.AKC025 = ks;
            yb_in_dj.KC21XML.AKC140 = jbmc;
            yb_in_dj.KC21XML.AKC031 = zyh;
            yb_in_dj.KC21XML.AMC026 = sylb;
            yb_in_dj.KC21XML.AMC100 = ryyz;
            yb_in_dj.KC21XML.BKF040 = BKF040;
            yb_in_dj.KC21XML.BKF050 = BKF050;
            yb_in_dj.KC21XML.KC33XML = "<KC33ROW>"
                                        + "<AKC190>" + zyh + "</AKC190>"//门诊（住院）号
                                        + "<BKE150>" + 1 + "</BKE150>"//诊断顺序
                                        + "<AKC221>" + DateTime.Now.ToString("yyyyMMddHHmmss") + "</AKC221>"//确诊日期
                                        + "<AKA120>" + jbbm + "</AKA120>"//诊断编码
                                        + "<AKA121>" + jbmc + "</AKA121>"//诊断名称
                                        + "<AAE013></AAE013>"//备注
                                     + "</KC33ROW>";
            //先把交易方流水号，卡号，个人编号更新到数据库
            string sql333 = "update inhospital set healthcard = '" + yb_in_dj.AKC020 + "', insurcode=  '" + grbh + "',MSGID='" + yb_in_dj.MSGID + "' where id= " + zyjlh + ";";
            BllMain.Db.Update(sql333);
            SjzybInterface sjzybInterface = new bll.SjzybInterface();
            sjzybInterface.zydj(yb_in_dj, ref yb_out_dj);

            int returnnum = Convert.ToInt32(yb_out_dj.RETURNNUM);
            if (returnnum == -1)//错误，业务出参中的errorMSG为错误信息
            {
                messges += yb_out_dj.ERRORMSG;
                return false;
            }
            else
            {
                Yb_hospital hospital = new Yb_hospital();

                //新建表存储所有转医保住院人员信息
                string search_sql = "select count(*) from Sybzyjl where AKC190='" + zyh + "'";
                DataSet ds1 = BllMain.Db.Select(search_sql);
                if (int.Parse(ds1.Tables[0].Rows[0][0].ToString()) == 0)
                {
                    string sql = hospital.add_Sybzyjl(yb_in_dj.KC21XML);
                    if (BllMain.Db.Update(sql) == -1)
                    {
                        ProgramGlobal.SysWriteLogs.writeLogs("转市医保插入Sybzyjl表失败", DateTime.Now, "sql=" + sql);
                        MessageBox.Show("转市医保，插入Sybzyjl表失败！");
                        return false;
                    }
                }


                //入院登记成功
                string sql2 = "update inhospital set healthcard = '" + yb_in_dj.AKC020 + "', insurcode=  '" + grbh + "',bas_patienttype_id= " + ylfkfs_id + ",Insuritemtype='" + yllb + "',MSGID='" + yb_in_dj.MSGID + "' where id= " + zyjlh + ";";//修改his系统nhflag标志，置为301
                
                if (BllMain.Db.Update(sql2) == -1)
                {
                    SysWriteLogs.writeLogs1("转医保职工成功，但更新HIS标志失败！", DateTime.Now, "sql=" + sql2);
                    MessageBox.Show("转医保职工成功，但更新HIS标志失败！");
                    return false;
                }
            }
            return true;
        }

        #region 疾病编码事件和小窗体事件
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
            string tiaojian = " where 1=1 and illcode like '%" + cyjsjbbm.Text.Trim() + "%' and (name like '%" + tbx_jbmc.Text.Trim() + "%' or pincode like '" + tbx_jbmc.Text.Trim().ToUpper() + "%' ) AND sign ='1' ";
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

        private void dgw_ryjbmc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tbx_jbmc.Text = dgw_ryjbmc.Rows[e.RowIndex].Cells["ryzdname"].Value.ToString().Trim();
                cyjsjbbm.Text = dgw_ryjbmc.Rows[e.RowIndex].Cells["ryzdcode"].Value.ToString().Trim();
                dgw_ryjbmc.Visible = false;
                cyjsjbbm.Focus();
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
                    tbx_jbmc.Text = dgw_ryjbmc.Rows[rowindex].Cells["ryzdname"].Value.ToString().Trim();
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
                    tbx_jbmc.Text = dgw_ryjbmc.Rows[rowindex].Cells["ryzdname"].Value.ToString().Trim();
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

        #endregion

        private void comboYllb_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                string value = this.comboYllb.SelectedValue.ToString();
                if (value == "52")
                {
                    this.label7.Visible = true;
                    this.comboSYlb.Visible = true;
                    this.ryyz.Visible = true;
                    this.label12.Visible = true;
                }
                else
                {
                    this.label7.Visible = false;
                    this.comboSYlb.Visible = false;
                    this.ryyz.Visible = false;
                    this.label12.Visible = false;
                }
            }
            catch { }
        }
    }
}
