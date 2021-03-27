using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Security.Cryptography;
using MTHIS.main.bll;
using zhongluyiyuan.Entity;
using zhongluyiyuan.gsbx.bll;
using zhongluyiyuan.Util;
using MTREG.gsbx1;
using zhongluyiyuan.listitem;
using MTHIS.tools;
using MTREG.common.bll;
namespace zhongluyiyuan.gsbx
{
    public partial class FrmgsRy : Form
    {
        public FrmgsRy()
        {
            InitializeComponent();
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
        private bool flag;
        /// <summary>
        /// 标志位
        /// </summary>
        public bool Flag
        {
            get { return flag; }
            set { flag = value; }
        }
        private string ylfkfs;
        /// <summary>
        /// 医疗付款方式id
        /// </summary>
        public string Ylfkfs
        {
            get { return ylfkfs; }
            set { ylfkfs = value; }
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
        DlDC dldc = new DlDC();
        GSBX_IN in1 = new GSBX_IN();
        GSBX_OUT out1 = new GSBX_OUT();
        GSBXinterface GSBXinterface = new GSBXinterface();
        string sessionid = "";
        
        private void FrmgsRy_Load(object sender, EventArgs e)
        {
            initMessage();
            ylcsh();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView3.AutoGenerateColumns = false;

        }
        private void initMessage()
        {
            this.RydjXm.Text = zfrydj.Brxm;//姓名
            this.RydjKs.Text = zfrydj.Ryks;//入院科室
            this.RydjYs.Text = zfrydj.Ysname;//医生
            this.RydjRyrq.Text = zfrydj.Rysj;//入院时间
            this.RydjBfh.Text = zfrydj.Bfh;//病房号
            this.RydjBc.Text = zfrydj.Bch;//病床号
            this.RydjZyh.Text = Zfrydj.Zyh;//住院号
            this.RydjSfzh.Text = zfrydj.Brsfzh;//病人身份证号
            if (zfrydj.Brsfzh != "")
            {
                this.tbx_jmylzh.Text = zfrydj.Brsfzh;//病人身份证号
            }
            this.Rydjxb.Text = zfrydj.Brxb;
            //if (zfrydj.Brxb == "1")
            //{
            //    this.Rydjxb.Text = "男";
            //}
            //else if (zfrydj.Brxb == "2")
            //{
            //    this.Rydjxb.Text = "女";
            //}
        }
        private void ylcsh()
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("11", "门诊"));
            items.Add(new ListItem("21", "住院"));
            this.comboYllb.DisplayMember = "Text";
            this.comboYllb.ValueMember = "Value";
            this.comboYllb.DataSource = items;
            comboYllb.SelectedValue = "21";

            List<ListItem> items1 = new List<ListItem>();
            items1.Add(new ListItem("4", "康复"));
            items1.Add(new ListItem("7", "治疗"));
            this.cbx_zllb.DisplayMember = "Text";
            this.cbx_zllb.ValueMember = "Value";
            this.cbx_zllb.DataSource = items1;
            cbx_zllb.SelectedValue = "7";

        }

        private void btn_yk_Click(object sender, EventArgs e)
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
            in1.Log_name = "getInjuryByNameAndId";
            in1.YwName = "getInjuryByNameAndId";
            string data = "<injuryReqData>";
            string sfzh = tbx_jmylzh.Text.Trim();//"130121197007251637";//
            string xm = RydjXm.Text.Trim();//"李志红";//
            data += " <sessionid>" + sessionid + "</sessionid>";
                   data += " <aac002>" + sfzh + "</aac002>";
                   data += " <aac003>" + xm+ "</aac003>";
                   data+= " </injuryReqData>";
            in1.YwData = Base64.encodebase64(in1.head()+data);

            out1 = GSBXinterface.request(in1); 
            if (out1.State == "2")
            {
                MessageBox.Show("工伤保险提示！\r\n" + in1.Log_name + "出错！\r\n【" + out1.Message + "】"); string flag11 = dldc.dengchu(sessionid);
                if (flag11 == "1")
                {
                    MessageBox.Show(dldc.Message);
                    return;
                }
                sessionid = ""; return;
            }

            out1.State = out1.Ds.Tables["injuryRespData"].Rows[0]["code"].ToString().Trim();
            out1.Message = out1.Ds.Tables["injuryRespData"].Rows[0]["msg"].ToString().Trim();
            if (out1.State != "0")
            {
                MessageBox.Show("工伤保险提示！\r\n"+in1.Log_name + "出错！\r\n\r\n【" + out1.Message + "】");
                string flag11 = dldc.dengchu(sessionid);
                if (flag11 == "1")
                {
                    MessageBox.Show(dldc.Message);
                    return;
                }
                sessionid = "";
                return;
            }
            string count = out1.Ds.Tables["injuryRespData"].Rows[0]["counts"].ToString().Trim();
        
            insertgsxx(count,out1.Ds);

            string flag1 = dldc.dengchu(sessionid);
            if (flag1 == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = "";
        }
        private void insertgsxx(string count, DataSet out1)
        {

            DataTable dt = out1.Tables["lc01"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string xb = dt.Rows[i]["aac004"].ToString().Trim();
                if (xb == "1") { xb = "男"; } else { xb = "女"; }
                dt.Rows[i]["aac004"] = xb;
                string sc = dt.Rows[i]["ALC021"].ToString().Trim();
                if (sc == "1") { sc = "死亡"; } else if (sc == "3") { sc = "工伤"; } else if (sc == "5") { sc = "失踪"; }
                dt.Rows[i]["ALC021"] = sc;
                string sc1 = dt.Rows[i]["alc084"].ToString().Trim();
                if (sc1 == "1") { sc1 = "是"; } else  { sc1 = "否"; }
                dt.Rows[i]["alc084"] = sc1;


            }
            dataGridView1.DataSource = dt;
            dataGridView1.Visible = true;

        }
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int rowIdx = dataGridView1.CurrentRow.Index;
                    RydjGrbh.Text = dataGridView1.Rows[rowIdx].Cells["Column27"].Value.ToString();
                    tbx_rdsh.Text = dataGridView1.Rows[rowIdx].Cells["Column28"].Value.ToString();
                    RydjDwbh.Text = dataGridView1.Rows[rowIdx].Cells["Column29"].Value.ToString();
                    tbx_dkzyzt.Text = dataGridView1.Rows[rowIdx].Cells["Column30"].Value.ToString();
                    txt_qybh.Text = dataGridView1.Rows[rowIdx].Cells["Column31"].Value.ToString();
                    tbx_jmylzh.Text = dataGridView1.Rows[rowIdx].Cells["Column32"].Value.ToString();
                    tbx_dkxm.Text = dataGridView1.Rows[rowIdx].Cells["Column33"].Value.ToString();
                    tbx_dkxb.Text = dataGridView1.Rows[rowIdx].Cells["Column34"].Value.ToString();
                    txt_rylb.Text = dataGridView1.Rows[rowIdx].Cells["Column35"].Value.ToString();
                    tbx_jgbh.Text = dataGridView1.Rows[rowIdx].Cells["Column36"].Value.ToString();
                    tbx_gsfssj.Text = dataGridView1.Rows[rowIdx].Cells["Column37"].Value.ToString();

                    string shcd = dataGridView1.Rows[rowIdx].Cells["Column38"].Value.ToString();
                    if (shcd == "1") { shcd = "死亡"; } else if (shcd == "3") { shcd = "工伤"; } else if (shcd == "5") { shcd = "失踪"; }
                    tbx_shcd.Text = shcd;

                    tbx_shbw.Text = dataGridView1.Rows[rowIdx].Cells["Column39"].Value.ToString();
                    textBox4.Text = dataGridView1.Rows[rowIdx].Cells["Column40"].Value.ToString();
                    textBox2.Text = dataGridView1.Rows[rowIdx].Cells["Column41"].Value.ToString();
                    try
                    {
                        string gslb = dataGridView1.Rows[rowIdx].Cells["Column42"].Value.ToString();
                        string sql_gslb = "select name from gsgslb where id='" + gslb + "'";
                        DataTable dt_gslb = BllMain.Db.Select(sql_gslb).Tables[0];
                        tbx_gslb.Text = dt_gslb.Rows[0]["name"].ToString().Trim();
                    }
                    catch { }
                    string hldj=dataGridView1.Rows[rowIdx].Cells["Column43"].Value.ToString();
                    if (hldj == "0") { hldj = "无护理依赖"; } else if (hldj == "1") { hldj = "部分护理依赖"; } else if (hldj == "2") { hldj = "大部分护理依赖"; } else if (hldj == "3") { hldj = "完全护理依赖"; }
                    tbx_yldj.Text = hldj;
                    try
                    {
                        string scdj = dataGridView1.Rows[rowIdx].Cells["Column44"].Value.ToString();
                        string sql_scdj = "select name from gsscdj where id='" + scdj + "'";
                        DataTable dt_scdj = BllMain.Db.Select(sql_scdj).Tables[0];
                        tbx_scdj.Text = dt_scdj.Rows[0]["name"].ToString().Trim();
                    }
                    catch { }

                    tbx_lgsbz.Text = dataGridView1.Rows[rowIdx].Cells["Column45"].Value.ToString();
                    try
                    {
                        string dyffzt = dataGridView1.Rows[rowIdx].Cells["Column46"].Value.ToString();
                        if (dyffzt == "0") { dyffzt = "暂停发放"; } else if (dyffzt == "1") { dyffzt = "正常发放"; } else if (dyffzt == "3") { dyffzt = "待遇终止"; } else if (dyffzt == "5") { dyffzt = "新增待复核"; }
                        tbx_dyffzt.Text = dyffzt;
                    }
                    catch { }
                    dataGridView1.Visible = false;
                }
            }
            if (tbx_rdsh.Text.Trim() == "")
            {
                MessageBox.Show("该病人为新发工伤！请点击获取工伤备案按钮！");
                checkBox1.Checked = true;
                btn_qd.Visible = true;
            }
            else
            {
                MessageBox.Show("该病人为老工伤！请点击获取继续治疗按钮！");
                checkBox1.Checked = false;
                button1.Visible = true;
            }
        }

        private void btn_qd_Click(object sender, EventArgs e)
        {
            string flag = dldc.dengru();
            if (flag == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = dldc.Sessionid;

            in1.Log_name = "getReport";
            in1.YwName = "getReport";
            string data1 = "<getReportReqData>";
            data1 += " <sessionid>" + sessionid + "</sessionid>";
            data1 += " <aac001>" + RydjGrbh.Text.Trim() + "</aac001>";
            data1 += " </getReportReqData>";
            in1.YwData = Base64.encodebase64(in1.head() + data1);

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
                sessionid = "";
                return;
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
            insertgsba(out1.Ds);
            string flag1 = dldc.dengchu(sessionid);
            if (flag1 == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = "";
        }
        private void insertgsba(DataSet dt)
        {
            dataGridView2.DataSource = dt.Tables["ldc01"];
            dataGridView2.Visible = true;
        }
        private void dataGridView2_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string flag = dldc.dengru();
            if (flag == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = dldc.Sessionid;

            in1.Log_name = "getCure";
            in1.YwName = "getCure";
            string data1 = "<getCureReqData>";
            data1 += " <sessionid>" + sessionid + "</sessionid>";
            data1 += " <alca02>" + tbx_rdsh.Text.Trim() + "</alca02>";
            data1 += " </getCureReqData>";
            in1.YwData = Base64.encodebase64(in1.head() + data1);

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

            out1.State = out1.Ds.Tables["getCureRespData"].Rows[0]["code"].ToString().Trim();
            out1.Message = out1.Ds.Tables["getCureRespData"].Rows[0]["msg"].ToString().Trim();
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
            //foreach (DataRow item in out1.Ds.Tables[0].Rows)
            //{
            //    switch (item[4].ToString())
            //    {
            //        case "0": item[4] = "未审核";
            //            break;
            //        case "1": item[4] = "审核通过";
            //            break;
            //        case "2": item[4] = "审核不通过";
            //            break;
            //        case "11": item[4] = "初审状态";
            //            break;
            //        case "12": item[4] = "复核状态";
            //            break;
            //        default:
            //            break;
            //    }
            //}
            //for (int i = 0; i < out1.Ds.Tables[0].Rows.Count; i++)
            //{
            //    switch (out1.Ds.Tables[0].Rows[i][4].ToString())
            //    {
            //        case "0": out1.Ds.Tables[0].Rows[i][4 = "未审核";
            //            break;
            //        case "1": item[4] = "审核通过";
            //            break;
            //        case "2": item[4] = "审核不通过";
            //            break;
            //        case "11": item[4] = "初审状态";
            //            break;
            //        case "12": item[4] = "复核状态";
            //            break;
            //        default:
            //            break;
            //    }
            //}
            insertjszl(out1.Ds);
            string flag1 = dldc.dengchu(sessionid);
            if (flag1 == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = "";

        }
        private void insertjszl(DataSet dt)
        {
            dataGridView3.DataSource = dt.Tables["lkb7"];
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                switch (dataGridView3.Rows[i].Cells[4].Value.ToString())
                {
                    case "0": dataGridView3.Rows[i].Cells[4].Value = "未审核";
                        break;
                    case "1": dataGridView3.Rows[i].Cells[4].Value = "审核通过";
                        break;
                    case "2": dataGridView3.Rows[i].Cells[4].Value = "审核不通过";
                        break;
                    case "11": dataGridView3.Rows[i].Cells[4].Value = "初审状态";
                        break;
                    case "12": dataGridView3.Rows[i].Cells[4].Value = "复核状态";
                        break;
                    default:
                        break;
                }
                switch (dataGridView3.Rows[i].Cells[7].Value.ToString())
                {
                    case "2": dataGridView3.Rows[i].Cells[7].Value = "住院";
                        break;
                    case "1": dataGridView3.Rows[i].Cells[7].Value = "门诊";
                        break;
                    default:
                        break;
                }
                switch (dataGridView3.Rows[i].Cells[8].Value.ToString())
                {
                    case "3": dataGridView3.Rows[i].Cells[8].Value = "康复治疗";
                        break;
                    case "5": dataGridView3.Rows[i].Cells[8].Value = "特殊项目";
                        break;
                    case "2": dataGridView3.Rows[i].Cells[8].Value = "继续治疗";
                        break;
                    default:
                        break;
                }
            }
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tbx_rdsh.Text.Trim() == "")
            {
                return;
            }
            FrmJxzl jxzl = new FrmJxzl();
            jxzl.Xm = RydjXm.Text.Trim();
            jxzl.Rdsh = tbx_rdsh.Text.Trim();
            jxzl.Sfzh = tbx_jmylzh.Text.Trim();
            jxzl.Grbh = RydjGrbh.Text.Trim();
            jxzl.Zzys = RydjYs.Text.Trim();
            jxzl.Mtzyjliid = zyjlh;
            string sql = "select ihspdiagn as zyjlryzd from inhospital where id="+zyjlh;
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            jxzl.Ylzd = dt.Rows[0]["zyjlryzd"].ToString().Trim();
            jxzl.StartPosition = FormStartPosition.CenterScreen;
            jxzl.ShowDialog(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "select spbh from inhospital where id="+zyjlh;
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (tbx_rdsh.Text.Trim() == "")
            {
                return;
            }
            if (dt.Rows[0]["spbh"].ToString().Trim() == "")
            {
                MessageBox.Show("没有审批编号！请确定已申请！");
                return;
            }

            string flag = dldc.dengru();
            if (flag == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = dldc.Sessionid;


            in1.Log_name = "revokeCure";
            in1.YwName = "revokeCure";
            string data1 = "<revokeCureReqData>";
            data1 += " <sessionid>" + sessionid + "</sessionid>";
            data1 += " <aae073>" + dt.Rows[0]["spbh"].ToString().Trim() + "</aae073>";
            data1 += " <alca02>" + tbx_rdsh.Text.Trim() + "</alca02>";
            data1 += " </revokeCureReqData>";
            in1.YwData = Base64.encodebase64(in1.head() + data1);

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

            out1.State = out1.Ds.Tables["revokeCureRespData"].Rows[0]["code"].ToString().Trim();
            out1.Message = out1.Ds.Tables["revokeCureRespData"].Rows[0]["msg"].ToString().Trim();
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
            string sql_up = "update inhospital set spbh='' where id="+zyjlh;
            MessageBox.Show("撤销继续治疗成功！");

            string flag1 = dldc.dengchu(sessionid);
            if (flag1 == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = "";

        }

        private void btn_ry_Click(object sender, EventArgs e)
        {
            string sfxgs = (checkBox1.Checked == true) ? ("1") : ("0");
            if (sfxgs == "1")
            {
                if (gsba_rdbz.Text.Trim() == "未认定" || gsba_rdbz.Text == "不认定为工伤" || gsba_rdbz.Text == "不认定为视同工伤")
                {
                    MessageBox.Show("未认定为工伤！");
                    return;
                }
            }
            //else if (jxzl_spbz.Text.Trim() == "" )
            //{
            //    MessageBox.Show("请先获取继续治疗！");
            //    return;
            //}
            //else if (jxzl_spbz.Text.Trim() != "1")
            //{
            //    MessageBox.Show("继续治疗审核未通过！");
            //    return;
            //}
            if (cyjsjbbm.Text.Trim()=="")
            {
                MessageBox.Show("请填写疾病编码！");
                return;
            }
            string flag = dldc.dengru();
            if (flag == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }

            sessionid = dldc.Sessionid;
            string sfzh = tbx_jmylzh.Text.Trim();//"130121197007251637";//
            string xm = RydjXm.Text.Trim();//"李志红";//

            in1.Log_name = "入院登记";
            in1.YwName = "register";
            string data = "<regReqData>";
            data += " <sessionid>" + sessionid + "</sessionid>";
            data += " <isnewinjure>" + sfxgs + "</isnewinjure>";
            data += "<kc21>";
            data += "<aab001>" + RydjDwbh.Text.Trim() + "</aab001>";
            data += "<aac001>" + RydjGrbh.Text.Trim() + "</aac001>";
            data += "<aac002>" + sfzh + "</aac002>";
            data += "<aac003>" + xm + "</aac003>";

            string xb = tbx_dkxb.Text.Trim();
            if (xb == "男") { xb = "1"; } else { xb = "2"; }
            data += "<aac004>" +xb  + "</aac004>";

            data += "<aka130>" + comboYllb.SelectedValue.ToString() + "</aka130>";
            data += "<akc191>" + cbx_zllb.SelectedValue.ToString() + "</akc191>";
            data += "<akc190>" + RydjZyh.Text.Trim() + "</akc190>";
            data += "<akc192>" + DateTime.Parse(RydjRyrq.Text.Trim()).ToString("yyyy-MM-dd") + "</akc192>";
            data += "<alc028>" + cyjsjbbm.Text.Trim() + "</alc028>";
            data += "<alca02>" + tbx_rdsh.Text.Trim() + "</alca02>";
            data += "</kc21>";
            data += " </regReqData>";
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

            out1.State = out1.Ds.Tables["regRespData"].Rows[0]["code"].ToString().Trim();
            out1.Message = out1.Ds.Tables["regRespData"].Rows[0]["msg"].ToString().Trim();
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
            if (!dataUpload())
            {
                return;
            }
            
            MessageBox.Show("工伤入院成功！");
            this.Dispose(); 
        }
        private bool dataUpload()
        {
            string jmylzh = this.RydjGrbh.Text.Trim();
            string yllb = this.comboYllb.SelectedValue.ToString().Trim();//医疗类别
            int sfxgs = (checkBox1.Checked == true) ? (1) : (0);
            string sql2 = "update inhospital set nhflag=501 ,rdsh='" + tbx_rdsh.Text.Trim() + "',sfxgs='" + sfxgs + "',qh='" + txt_qybh.Text.Trim() + "',ybgrbh=  '" + RydjGrbh.Text.Trim() + "',bas_patienttype_id = " + ylfkfs_id + ",bas_patienttype1_id= " + ylfkfs_id + " where id= " + zyjlh + ";";//修改his系统nhflag标志，置为501
            string sql_in = "INSERT INTO gsryinfo(id, grbh, name, dwmc, scdj, shbw, yllb)VALUES (" + zyjlh + ",'" + RydjGrbh.Text.Trim() + "','" + tbx_dkxm.Text.Trim() + "','" + RydjDwbh.Text.Trim() + "','" + tbx_scdj.Text.Trim() + "','" + tbx_shbw.Text.Trim() + "','" + comboYllb .Text.Trim()+ "');";
            if (BllMain.Db.Update(sql2) == -1 || BllMain.Db.Update(sql_in) == -1)
            {
                SysWriteLogs.writeLogs1("转工伤成功，但更新HIS标志失败！", DateTime.Now, "sql=" + sql2 + "-------" + sql_in);
                MessageBox.Show("转工伤成功，但更新HIS标志失败！");
                return false;
            }
            return true;
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
            sql = " select jbbm as code,jbmc as name,zjm as jm from gsjblx " + tiaojian+" order by jbmc";
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

        private void dgw_ryjbmc_KeyUp(object sender, KeyEventArgs e)
        {
            //if (dgw_ryjbmc.CurrentRow == null)
            //{
            //    cyjsjbbm.Focus();
            //    return;
            //}
            //if (e.KeyValue == 13)
            //{
            //    int rowindex = this.dgw_ryjbmc.CurrentRow.Index;
            //    if (rowindex >= 0)
            //    {
            //        cyjsCyjb.Text = dgw_ryjbmc.Rows[rowindex].Cells["ryzdname"].Value.ToString().Trim();
            //        cyjsjbbm.Text = dgw_ryjbmc.Rows[rowindex].Cells["ryzdcode"].Value.ToString().Trim();
            //        dgw_ryjbmc.Visible = false;
            //        cyjsjbbm.Focus();
            //    }
            //}
            //if (e.KeyValue == (char)Keys.Escape)
            //{
            //    cyjsjbbm.Focus();
            //    dgw_ryjbmc.Visible = false;
            //}
        }

        private void dgw_ryjbmc_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void dataGridView3_KeyUp(object sender, KeyEventArgs e)
        {
            if (dataGridView3.Rows.Count > 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int rowIdx = dataGridView3.CurrentRow.Index;
                    jxzl_spbh.Text = dataGridView3.Rows[rowIdx].Cells["Column1"].Value.ToString();
                    tbx_rdsh.Text = dataGridView3.Rows[rowIdx].Cells["Column3"].Value.ToString();
                    jxzl_sqsj.Text = dataGridView3.Rows[rowIdx].Cells["Column4"].Value.ToString();
                    string spbz = dataGridView3.Rows[rowIdx].Cells["Column5"].Value.ToString();
                    if (spbz == "0") { spbz = "未审核"; } else if (spbz == "1") { spbz = "审核通过"; } else if (spbz == "2") { spbz = "审核不通过"; } else if (spbz == "11") { spbz = "初审状态"; } else if (spbz == "12") { spbz = "复核状态"; }

                    jxzl_spbz.Text = spbz;
                    jxzl_sfzh.Text = dataGridView3.Rows[rowIdx].Cells["Column6"].Value.ToString();
                    jxzl_xm.Text = dataGridView3.Rows[rowIdx].Cells["Column7"].Value.ToString();

                    
                    dataGridView3.Visible = false;
                    groupBox1.Visible = true;
                }
            }
            checkBox1.Checked = false;
        }

        private void btn_tc_Click(object sender, EventArgs e)
        {
            this.Dispose();
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

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int rowIdx = dataGridView2.CurrentRow.Index;
                    gsba_rdlc.Text = dataGridView2.Rows[rowIdx].Cells["Column16"].Value.ToString();
                    RydjGrbh.Text = dataGridView2.Rows[rowIdx].Cells["Column17"].Value.ToString();
                    gsba_sfzh.Text = dataGridView2.Rows[rowIdx].Cells["Column18"].Value.ToString();
                    gsba_xm.Text = dataGridView2.Rows[rowIdx].Cells["Column19"].Value.ToString();
                    tbx_rdsh.Text = dataGridView2.Rows[rowIdx].Cells["Column20"].Value.ToString();
                    txt_qybh.Text = dataGridView2.Rows[rowIdx].Cells["Column21"].Value.ToString();
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
            checkBox1.Checked = true;
        }

        private void dataGridView3_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView3.Rows.Count > 0)
            {
               
                    int rowIdx = dataGridView3.CurrentRow.Index;
                    jxzl_spbh.Text = dataGridView3.Rows[rowIdx].Cells["Column1"].Value.ToString();
                    tbx_rdsh.Text = dataGridView3.Rows[rowIdx].Cells["Column3"].Value.ToString();
                    jxzl_sqsj.Text = dataGridView3.Rows[rowIdx].Cells["Column4"].Value.ToString();
                    string spbz = dataGridView3.Rows[rowIdx].Cells["Column5"].Value.ToString();
                    if (spbz == "0") { spbz = "未审核"; } else if (spbz == "1") { spbz = "审核通过"; } else if (spbz == "2") { spbz = "审核不通过"; } else if (spbz == "11") { spbz = "初审状态"; } else if (spbz == "12") { spbz = "复核状态"; }

                    jxzl_spbz.Text = spbz;
                    jxzl_sfzh.Text = dataGridView3.Rows[rowIdx].Cells["Column6"].Value.ToString();
                    jxzl_xm.Text = dataGridView3.Rows[rowIdx].Cells["Column7"].Value.ToString();


                    dataGridView3.Visible = false;
                    groupBox1.Visible = true;
               
            }
            checkBox1.Checked = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
               
                    int rowIdx = dataGridView1.CurrentRow.Index;
                    RydjGrbh.Text = dataGridView1.Rows[rowIdx].Cells["Column27"].Value.ToString();
                    try
                    {
                        tbx_rdsh.Text = dataGridView1.Rows[rowIdx].Cells["Column28"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                    }
                    try
                    {
                    RydjDwbh.Text = dataGridView1.Rows[rowIdx].Cells["Column29"].Value.ToString(); 
                    }
                    catch (Exception ex)
                    {
                    }
                    try
                    {
                    tbx_dkzyzt.Text = dataGridView1.Rows[rowIdx].Cells["Column30"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                    }
                    try
                    {
                    txt_qybh.Text = dataGridView1.Rows[rowIdx].Cells["Column31"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                    }
                    try
                    {
                    tbx_jmylzh.Text = dataGridView1.Rows[rowIdx].Cells["Column32"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                    }
                    try
                    {
                    tbx_dkxm.Text = dataGridView1.Rows[rowIdx].Cells["Column33"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                    }
                    try
                    {
                    tbx_dkxb.Text = dataGridView1.Rows[rowIdx].Cells["Column34"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                    }
                    try
                    {
                    txt_rylb.Text = dataGridView1.Rows[rowIdx].Cells["Column35"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                    }
                    try
                    {
                    tbx_jgbh.Text = dataGridView1.Rows[rowIdx].Cells["Column36"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                    }
                    try
                    {
                    tbx_gsfssj.Text = dataGridView1.Rows[rowIdx].Cells["Column37"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                    }

                    string shcd = dataGridView1.Rows[rowIdx].Cells["Column38"].Value.ToString();
                    if (shcd == "1") { shcd = "死亡"; } else if (shcd == "3") { shcd = "工伤"; } else if (shcd == "5") { shcd = "失踪"; }
                    tbx_shcd.Text = shcd;

                    tbx_shbw.Text = dataGridView1.Rows[rowIdx].Cells["Column39"].Value.ToString();
                    textBox4.Text = dataGridView1.Rows[rowIdx].Cells["Column40"].Value.ToString();
                    textBox2.Text = dataGridView1.Rows[rowIdx].Cells["Column41"].Value.ToString();
                    try
                    {
                        string gslb = dataGridView1.Rows[rowIdx].Cells["Column42"].Value.ToString();
                        string sql_gslb = "select name from gsgslb where id='" + gslb + "'";
                        DataTable dt_gslb = BllMain.Db.Select(sql_gslb).Tables[0];
                        tbx_gslb.Text = dt_gslb.Rows[0]["name"].ToString().Trim();
                    }
                    catch { }
                    string hldj = dataGridView1.Rows[rowIdx].Cells["Column43"].Value.ToString();
                    if (hldj == "0") { hldj = "无护理依赖"; } else if (hldj == "1") { hldj = "部分护理依赖"; } else if (hldj == "2") { hldj = "大部分护理依赖"; } else if (hldj == "3") { hldj = "完全护理依赖"; }
                    tbx_yldj.Text = hldj;
                    try
                    {
                        string scdj = dataGridView1.Rows[rowIdx].Cells["Column44"].Value.ToString();
                        string sql_scdj = "select name from gsscdj where id='" + scdj + "'";
                        DataTable dt_scdj = BllMain.Db.Select(sql_scdj).Tables[0];
                        tbx_scdj.Text = dt_scdj.Rows[0]["name"].ToString().Trim();
                    }
                    catch { }

                    tbx_lgsbz.Text = dataGridView1.Rows[rowIdx].Cells["Column45"].Value.ToString();
                    try
                    {
                        string dyffzt = dataGridView1.Rows[rowIdx].Cells["Column46"].Value.ToString();
                        if (dyffzt == "0") { dyffzt = "暂停发放"; } else if (dyffzt == "1") { dyffzt = "正常发放"; } else if (dyffzt == "3") { dyffzt = "待遇终止"; } else if (dyffzt == "5") { dyffzt = "新增待复核"; }
                        tbx_dyffzt.Text = dyffzt;
                    }
                    catch { }
                    dataGridView1.Visible = false;
              
            }
            if (tbx_rdsh.Text.Trim() == "")
            {
                MessageBox.Show("该病人为新发工伤！请点击获取工伤备案按钮！");
                checkBox1.Checked = true;
                btn_qd.Visible = true;
            }
            else
            {
                MessageBox.Show("该病人为老工伤！请点击获取继续治疗按钮！");
                checkBox1.Checked = false;
                button1.Visible = true;
            }
        }

    }
}
