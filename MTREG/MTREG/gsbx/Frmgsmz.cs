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
using MTREG.common.bll;
using MTREG.clinic.bll;
using MTREG.clinic.bo;
using MTHIS.common;
using MTREG.common;
using MTREG.medinsur.sjzsyb.bll;
using MTHIS.tools;

namespace zhongluyiyuan.gsbx
{
    public partial class Frmgsmz : Form
    {
        public Frmgsmz()
        {
            InitializeComponent();
        }
        BllClinicReg bllClinicReg = new BllClinicReg();
        DlDC dldc = new DlDC();
        GSBX_IN in1 = new GSBX_IN();
        GSBX_OUT out1 = new GSBX_OUT();
        DataTable dt_xxxx = new DataTable();
        DataTable dt_brxx = new DataTable();
        GSBXinterface GSBXinterface = new GSBXinterface();
        string sessionid = "";
        string _iid="";//工伤门诊号
        string iid4 = "";
        private void btn_yk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.tbx_jmylzh.Text.Trim()))
            {
                MessageBox.Show("请输入身份证号！");
                return;
            }
            if (string.IsNullOrEmpty(this.tbx_dkxm.Text.Trim()))
            {
                MessageBox.Show("请输入姓名！");
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
            string sfzh = tbx_jmylzh.Text.Trim();
            string xm = this.tbx_dkxm.Text;
            data += " <sessionid>" + sessionid + "</sessionid>";
            data += " <aac002>" + sfzh + "</aac002>";
            data += " <aac003>" + xm + "</aac003>";
            data += " </injuryReqData>";
            
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

            out1.State = out1.Ds.Tables["injuryRespData"].Rows[0]["code"].ToString().Trim();
            out1.Message = out1.Ds.Tables["injuryRespData"].Rows[0]["msg"].ToString().Trim();
            if (out1.State != "0")
            {
                MessageBox.Show("工伤保险提示！\r\n" + in1.Log_name + "出错！\r\n\r\n【" + out1.Message + "】");
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

            insertgsxx(count, out1.Ds);

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
            DataTable dt=out1.Tables["lc01"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string xb = dt.Rows[i]["aac004"].ToString().Trim();
                if (xb == "1") { xb = "男"; } else { xb = "女"; }
                dt.Rows[i]["aac004"] = xb;
                string sc = dt.Rows[i]["ALC021"].ToString().Trim();
                if (sc == "1") { sc = "死亡"; } else if (sc == "3") { sc = "工伤"; } else if (sc == "5") { sc = "失踪"; }
                dt.Rows[i]["ALC021"] = sc;
            }
            dataGridView1.DataSource = dt;
                tabControl1.SelectedTab = tabPage4;
        }
        private void Frmgsmz_Load(object sender, EventArgs e)
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("11", "门诊"));
            items.Add(new ListItem("21", "住院"));
            this.comboYllb.DisplayMember = "Text";
            this.comboYllb.ValueMember = "Value";
            this.comboYllb.DataSource = items;
            comboYllb.SelectedValue = "11";

            List<ListItem> items1 = new List<ListItem>();
            items1.Add(new ListItem("4", "康复"));
            items1.Add(new ListItem("7", "治疗"));
            this.cbx_zllb.DisplayMember = "Text";
            this.cbx_zllb.ValueMember = "Value";
            this.cbx_zllb.DataSource = items1;
            cbx_zllb.SelectedValue = "7";

            List<ListItem> items2 = new List<ListItem>();
            items2.Add(new ListItem("1", "康复"));
            items2.Add(new ListItem("2", "转院"));
            items2.Add(new ListItem("3", "死亡"));
            items2.Add(new ListItem("4", "市内转院结算"));
            items2.Add(new ListItem("9", "其他"));
            this.comboCyyy.DisplayMember = "Text";
            this.comboCyyy.ValueMember = "Value";
            this.comboCyyy.DataSource = items2;
            this.comboCyyy.SelectedValue = "9";
            //添加按钮
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int rowIdx = dataGridView1.CurrentRow.Index;
                RydjGrbh.Text = dataGridView1.Rows[rowIdx].Cells["Column27"].Value.ToString();
                try
                {
                    tbx_rdsh.Text = dataGridView1.Rows[rowIdx].Cells["Column28"].Value.ToString();
                }
                catch { }
                try
                {
                RydjDwbh.Text = dataGridView1.Rows[rowIdx].Cells["Column29"].Value.ToString();
                     }
                catch { }
                    try
                {
                tbx_dkzyzt.Text = dataGridView1.Rows[rowIdx].Cells["Column30"].Value.ToString();
                         }
                catch { }
                        try
                {
                txt_qybh.Text = dataGridView1.Rows[rowIdx].Cells["Column31"].Value.ToString();
                             }
                catch { }
                            try
                {
                tbx_jmylzh.Text = dataGridView1.Rows[rowIdx].Cells["Column32"].Value.ToString();
                                 }
                catch { }
                                try
                {
                tbx_dkxm.Text = dataGridView1.Rows[rowIdx].Cells["Column33"].Value.ToString();
                                     }
                catch { }
                                    try
                {
                tbx_dkxb.Text = dataGridView1.Rows[rowIdx].Cells["Column34"].Value.ToString();
                                         }
                catch { }
                                        try
                {
                txt_rylb.Text = dataGridView1.Rows[rowIdx].Cells["Column35"].Value.ToString();
                                             }
                catch { }
                                            try
                {
                tbx_jgbh.Text = dataGridView1.Rows[rowIdx].Cells["Column36"].Value.ToString();
                                                 }
                catch { }
                                                try
                {
                tbx_gsfssj.Text = dataGridView1.Rows[rowIdx].Cells["Column37"].Value.ToString();
                                                     }
                catch { }
                                                    try
                {

                string shcd = dataGridView1.Rows[rowIdx].Cells["Column38"].Value.ToString();
                if (shcd == "1") { shcd = "死亡"; } else if (shcd == "3") { shcd = "工伤"; } else if (shcd == "5") { shcd = "失踪"; }
                tbx_shcd.Text = shcd;
                }
                                                    catch { }
                try
                {
                tbx_shbw.Text = dataGridView1.Rows[rowIdx].Cells["Column39"].Value.ToString();
                 }
                catch { }
                try
                {
                textBox4.Text = dataGridView1.Rows[rowIdx].Cells["Column40"].Value.ToString();
             }
                catch { }
                try
                {
                textBox2.Text = dataGridView1.Rows[rowIdx].Cells["Column41"].Value.ToString();
         }
                catch { }
                try
                {
                    string gslb = dataGridView1.Rows[rowIdx].Cells["Column42"].Value.ToString();
                    string sql_gslb = "select name from gsgslb where id='" + gslb + "'";
                    DataTable dt_gslb = BllMain.Db.Select(sql_gslb).Tables[0];
                    tbx_gslb.Text = dt_gslb.Rows[0]["name"].ToString().Trim();
                }
                catch { tbx_gslb.Text = ""; }
                try
                {
                    string scdj = dataGridView1.Rows[rowIdx].Cells["Column44"].Value.ToString();
                    string sql_scdj = "select name from gsscdj where id='" + scdj + "'";
                    DataTable dt_scdj = BllMain.Db.Select(sql_scdj).Tables[0];
                    tbx_scdj.Text = dt_scdj.Rows[0]["name"].ToString().Trim();
                }
                catch { }
                tbx_lgsbz.Text = dataGridView1.Rows[rowIdx].Cells["Column45"].Value.ToString();

                string dyffzt = dataGridView1.Rows[rowIdx].Cells["Column46"].Value.ToString();
                if (dyffzt == "0") { dyffzt = "暂停发放"; } else if (dyffzt == "1") { dyffzt = "正常发放"; } else if (dyffzt == "3") { dyffzt = "待遇终止"; } else if (dyffzt == "5") { dyffzt = "新增待复核"; }
                tbx_dyffzt.Text = dyffzt;
                textBox1.Text = tbx_dkxm.Text;
                if (tbx_rdsh.Text.Trim() == "")
                {
                    MessageBox.Show("该病人为新发工伤！请点击获取工伤备案按钮！");
                    checkBox1.Checked = true;
                }
                else
                {
                    //MessageBox.Show("该病人为老工伤！请点击获取继续治疗按钮！");
                    checkBox1.Checked = false;
                    //button1.Visible = true;
                }
            }
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            
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

        private void dgw_ryjbmc_KeyUp(object sender, KeyEventArgs e)
        {

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

        private void button11_Click(object sender, EventArgs e)
        {
            
            //dt_xxxx.Clear();
            //this.dataGridView3.DataSource = dt_xxxx;
            string xm = textBox1.Text.Trim();
            string ksrq = dateTime_cxrqks.Value.ToString("yyyy-MM-dd");
            string jsrq = dateTime_cxrqjs.Value.ToString("yyyy-MM-dd");
            string today = System.DateTime.Today.ToString("yyyy-MM-dd");

            string sql_brxx = @"SELECT	register.`name` AS brxm,
	                                   (CASE WHEN register.sex = 'M' THEN '男' WHEN register.sex = 'W' THEN '女' END) AS xb,
	                                   clinic_invoice.realfee AS zje,
	                                   bas_doctor.`name` AS ys,
	                                   bas_depart.`name` AS ks,
	                                   clinic_invoice.chargedate AS cfsj,
	                                   register.age AS nl,
	                                   clinic_invoice.billcode AS mzh,clinic_invoice.invoice,
	                                   clinic_invoice.id AS iid,clinic_invoice.gsjlh,
	                                   clinic_invoice.chargedate AS sksj,
	                                   clinic_invoice.chargedate AS fyrq,clinic_invoice.regist_id,register.member_id,clinic_invoice.rcpdep_id,clinic_invoice.rcpdoctor_id
                                 FROM clinic_invoice,bas_doctor,register,bas_depart
	                             WHERE  clinic_invoice.regist_id = register.id and clinic_invoice.rcpdoctor_id=bas_doctor.id and clinic_invoice.rcpdep_id = bas_depart.id and clinic_invoice.charged='CHAR' and clinic_invoice.bas_patienttype_id in (1,38)";
            sql_brxx += " and clinic_invoice.chargedate >='" + ksrq + " 00:00:00' and clinic_invoice.chargedate<='" + jsrq + " 23:59:59'";
            if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                sql_brxx += " and register.name like '%" + xm + "%'";
            }
            sql_brxx += "  order by clinic_invoice.chargedate desc";
            dt_brxx = BllMain.Db.Select(sql_brxx).Tables[0];
            dataGridView_brxx.DataSource = dt_brxx;
            if (dt_brxx.Rows.Count > 0)
            {
                _iid = dataGridView_brxx.Rows[0].Cells["gsjlh"].Value.ToString().Trim();
                this.tbx_fph.Text = dataGridView_brxx.Rows[0].Cells["invoice"].Value.ToString().Trim();
            }
            for (int i = 0; i < dataGridView_brxx.Rows.Count; i++)
            {
                dataGridView_brxx.Rows[i].Cells[0].Value = true;
            }
            cxfy();
        }

        private void dataGridView_brxx_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            //_iid = dataGridView_brxx.Rows[e.RowIndex].Cells["iid"].Value.ToString().Trim();
            // brxx_CellClick(_iid);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_iid == "")
            {
                string sqlzyh = " select NEXTID('gsjlh');  ";
                DataTable dtzyh = BllMain.Db.Select(sqlzyh).Tables[0];
                _iid = Convert.ToInt32(dtzyh.Rows[0][0]).ToString();
            }
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

            if (cyjsjbbm.Text.Trim() == "")
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

            in1.Log_name = "入院登记";
            in1.YwName = "register";
            string data = "<regReqData>";
            data += " <sessionid>" + sessionid + "</sessionid>";
            data += " <isnewinjure>" + sfxgs + "</isnewinjure>";
            data += "<kc21>";
            data += "<aab001>" + RydjDwbh.Text.Trim() + "</aab001>";
            data += "<aac001>" + RydjGrbh.Text.Trim() + "</aac001>";
            data += "<aac002>" + tbx_jmylzh.Text.Trim() + "</aac002>";
            data += "<aac003>" + tbx_dkxm.Text.Trim() + "</aac003>";
            string xb = (tbx_dkxb.Text.Trim() == "男") ? ("1") : ("2");
            data += "<aac004>" +xb+ "</aac004>";
            data += "<aka130>" + comboYllb.SelectedValue.ToString() + "</aka130>";
            data += "<akc191>" + cbx_zllb.SelectedValue.ToString() + "</akc191>";
            data += "<akc190>" + _iid + "</akc190>";
            data += "<akc192>" + dateTimePicker1.Value.ToString("yyyy-MM-dd") +"</akc192>";
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
            if (!dataUpload())
            {
                return;
            }

            MessageBox.Show("工伤入院成功！");
        }
        private bool dataUpload()
        {
            string jmylzh = this.RydjGrbh.Text.Trim();
            string yllb = this.comboYllb.SelectedValue.ToString().Trim();//医疗类别
            int sfxgs = (checkBox1.Checked == true) ? (1) : (0);
            string sql2 = "update clinic_invoice set bas_patienttype_id=38 ,gsjlh=" + _iid + ",rdsh='" + tbx_rdsh.Text.Trim() + "',sfxgs='" + sfxgs + "',ybgrbh=  '" + RydjGrbh.Text.Trim() + "' where id in( " + iid4 + ");";//修改his系统stuff标志，置为501
            string sql_in = "INSERT INTO gsryinfo(id, grbh, name, dwmc, scdj, shbw, yllb,jssj)VALUES (" + _iid + ",'" + RydjGrbh.Text.Trim() + "','" + tbx_dkxm.Text.Trim() + "','" + RydjDwbh.Text.Trim() + "','" + tbx_scdj.Text.Trim() + "','" + tbx_shbw.Text.Trim() + "','" + comboYllb.Text.Trim() + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "');";
            if (BllMain.Db.Update(sql2) == -1 || BllMain.Db.Update(sql_in) == -1)
            {
                SysWriteLogs.writeLogs1("转工伤成功，但更新HIS标志失败！", DateTime.Now, "sql=" + sql2 + "-------" + sql_in);
                MessageBox.Show("转工伤成功，但更新HIS标志失败！");
                return false;
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView_brxx.CurrentRow == null)
                return;
            int rowIdx = dataGridView_brxx.CurrentRow.Index;
            if (rowIdx < 0)
            {
                MessageBox.Show("请选择患者");
                return;
            }

            string sqlTmp = "select gsjlh,bas_patienttype_id as clinictype,id,rdsh  from clinic_invoice where id in (  " + iid4 + ")";
            DataTable dt = BllMain.Db.Select(sqlTmp).Tables[0];
            if (dt.Rows[0]["clinictype"].ToString().Trim() != "38")
            {
                MessageBox.Show("请选择工伤已登记患者！");
                return;
            }
            string mes = "";
            if (MessageBox.Show("确定要入院回退该患者吗？", "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
            { return; }
            string flag = dldc.dengru();
            if (flag == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = dldc.Sessionid;
            in1.Log_name = "regundo";
            in1.YwName = "regundo";
            string data = "<regundoReqData>";
            data += " <sessionid>" + sessionid + "</sessionid>";
            data += " <akc190>" + dt.Rows[0]["gsjlh"].ToString().Trim() + "</akc190>";
            data += " <alca02>" + tbx_rdsh.Text + "</alca02>";
            data += " </regundoReqData>";
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

            out1.State = out1.Ds.Tables["regundoRespData"].Rows[0]["code"].ToString().Trim();
            out1.Message = out1.Ds.Tables["regundoRespData"].Rows[0]["msg"].ToString().Trim();
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
            string sql_up = "update clinic_invoice set bas_patienttype_id=1,rdsh='',spbh='' where id in(" + iid4 + ") ; ";
            sql_up += " delete from gsryinfo where id=" + _iid+" ;";
            if (BllMain.Db.Update(sql_up) == -1)
            {
                SysWriteLogs.writeLogs1("工伤回退更新his错误信息", DateTime.Now, "sql=" + sql_up);
                MessageBox.Show("工伤入院回退成功,更新his失败！");
            }
            string flag1 = dldc.dengchu(sessionid);
            if (flag1 == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = "";
            _iid = "";
            MessageBox.Show("工伤回退成功！");
        }

        private void btnXfsj_Click(object sender, EventArgs e)
        {
            if (_iid == "0")
            {
                return;
            }
            string sql_sfjs = "select bas_patienttype_id as clinictype from clinic_invoice where id  in( " + iid4 + ")";
            DataTable dtxx_sfjs = BllMain.Db.Select(sql_sfjs).Tables[0];
            if (dtxx_sfjs.Rows[0]["clinictype"].ToString() != "38")
                return;
            
            if (dataGridView3.Rows.Count < 0)
            {
                return;
            }
            string sql_mzbr = @" SELECT
                                        clinic_costdet.id AS idx,
                                        clinic_costdet.id AS cfh,
                                        '' AS fph,
                                        DATE_FORMAT(clinic_costdet.createdate,'%Y-%m-%d') AS cfsj,
                                        '1' AS cfts,
                                        bas_item.gszf as gszf,
                                        bas_item.gsbm AS xmbm,
                                        bas_item.`name` AS xmmc,
                                        gsxmlb.id AS sflb,
                                        '' AS sfdj,
                                        CASE WHEN (bas_item.itemtype_id = 10) OR (bas_item.itemtype_id = 11) OR (bas_item.itemtype_id = 12) THEN '0' ELSE '1' END AS zl,
                                        clinic_costdet.prc,
                                        clinic_costdet.num,
                                        clinic_costdet.realfee as je,
                                        clinic_costdet.spec AS guige,
                                        prodjixing. NAME AS jixing,bas_item.id as item_id
                                   FROM clinic_costdet left join bas_item on clinic_costdet.item_id = bas_item.id
                                        left join gsxmlb on gsxmlb.hisid = clinic_costdet.itemtype_id 
                                        left join (select sn as id,name from sys_dict where father_id=40) prodjixing on bas_item.dosageform_id = prodjixing.id
                                   WHERE clinic_costdet.clinic_Invoice_id IN (" + iid4 + ") ";
            DataTable dt = BllMain.Db.Select(sql_mzbr).Tables[0];
            if (dt.Rows.Count < 1 || dt.Rows == null)
            {
                return;
            }
            string flag = dldc.dengru();
            if (flag == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = dldc.Sessionid;
            in1.Log_name = "费用上传";
            in1.YwName = "sendMedInfo";
            string data = "<medReqData>";
            data += " <sessionid>" + sessionid + "</sessionid>";
            data += " <akc190>" + _iid + "</akc190>";
            data += "<advices>";
            if (dataGridView8.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView8.Rows.Count; i++)
                {
                    data += "<advice>";
                    data += "<aae080>" + dataGridView8.Rows[i].Cells["Column1"].Value.ToString().Trim() + "</aae080>";
                    data += "<alk007>" + dataGridView8.Rows[i].Cells["Column2"].Value.ToString().Trim().Substring(0,10) + "</alk007>";
                    data += "<alk008>" + dataGridView8.Rows[i].Cells["Column3"].Value.ToString().Trim().Substring(0, 10) + "</alk008>";
                    data += "<alk009>" + dataGridView8.Rows[i].Cells["Column4"].Value.ToString().Trim() + "</alk009>";
                    data += "<alk011>" + dataGridView8.Rows[i].Cells["Column5"].Value.ToString().Trim() + "</alk011>";
                    data += "<alk012>" + dataGridView8.Rows[i].Cells["Column6"].Value.ToString().Trim() + "</alk012>";
                    data += "<alk013>" + dataGridView8.Rows[i].Cells["Column7"].Value.ToString().Trim() + "</alk013>";
                    data += "<alk014>" + dataGridView8.Rows[i].Cells["Column8"].Value.ToString().Trim() + "</alk014>";
                    data += "<alk015>" + dataGridView8.Rows[i].Cells["Column9"].Value.ToString().Trim() + "</alk015>";
                    data += "<alk016>" + dataGridView8.Rows[i].Cells["Column10"].Value.ToString().Trim() + "</alk016>";
                    data += " <alk017>" + dataGridView8.Rows[i].Cells["Column11"].Value.ToString().Trim() + "</alk017>";
                    data += "<alk020>" + dataGridView8.Rows[i].Cells["Column12"].Value.ToString().Trim() + "</alk020>";
                    data += "<alk022>" + dataGridView8.Rows[i].Cells["Column14"].Value.ToString().Trim() + "</alk022>";
                    data += "<alk023>" + dataGridView8.Rows[i].Cells["Column13"].Value.ToString().Trim() + "</alk023>";
                    data += "<alk024></alk024>";
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
                string xmbm2 = dt.Rows[i]["xmbm"].ToString().Trim();
                if (xmbm2 == "")
                {
                    xmbm2 = "S" + dt.Rows[i]["item_id"].ToString().Trim();
                }
                data += "<alc402>" + xmbm2 + "</alc402>";
                data += "<alc403>" + dt.Rows[i]["xmmc"].ToString().Trim() + "</alc403>";
                data += "<aka063>" + dt.Rows[i]["sflb"].ToString().Trim() + "</aka063>";
                string xmbm = dt.Rows[i]["xmbm"].ToString().Trim();
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
                data += "<alc407>" + dt.Rows[i]["je"].ToString().Trim() + "</alc407>";
                data += "<aka070>" + dt.Rows[i]["jixing"].ToString().Trim() + "</aka070>";
                data += "<zka100>" + dt.Rows[i]["guige"].ToString().Trim() + "</zka100>";
                data += "<akc230></akc230>";
                data += "<akc231>" + dt.Rows[i]["xmmc"].ToString().Trim() + "</akc231>";
                string gszf = dt.Rows[i]["gszf"].ToString().Trim();
                if (gszf == "1") { dt.Rows[i]["xmbm"] = "S" + dt.Rows[i]["xmbm"].ToString().Trim(); }
                data += "<akc515>" + dt.Rows[i]["item_id"].ToString().Trim() + "</akc515>";
                data += "<reason></reason>";
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
                    return;
                }
                sessionid = ""; return;
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
                    return;
                }
                sessionid = "";
                return;
            }
            string sql_up = "update clinic_costdet set ybsfsc=1 where clinic_Invoice_id in (" + iid4 + ")";
            BllMain.Db.Update(sql_up);
            MessageBox.Show("上传成功！");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (_iid == "0")
            {
                return;
            }
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
            data += " <akc190>" + _iid + "</akc190>";
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
            string sql_up = "update clinic_costdet set ybsfsc=0 where clinic_Invoice_id in(" + iid4 + ")";
            BllMain.Db.Update(sql_up);
            MessageBox.Show("删除费用成功！");
            string flag1 = dldc.dengchu(sessionid);
            if (flag1 == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (_iid == "0")
            {
                return;
            }
            string flag = dldc.dengru();
            if (flag == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = dldc.Sessionid;
            if (dataGridView3.Rows.Count < 0)
            {
                return;
            }
            string sql_mzbr = @" SELECT
                                        clinic_costdet.iid AS idx,
                                        clinic_costdet.iid AS cfh,
                                        '' AS fph,
                                        DATE_FORMAT(clinic_costdet.createdate,'%Y-%m-%d') AS cfsj,
                                        '1' AS cfts,
                                        0 as gszf,
                                        bas_item.gsbm AS xmbm,
                                        bas_item.`name` AS xmmc,
                                        gsxmlb.id AS sflb,
                                        '' AS sfdj,
                                        CASE WHEN (bas_item.itemtype_id = 10) OR (bas_item.itemtype_id = 11) OR (bas_item.itemtype_id = 12) THEN '0' ELSE '1' END AS zl,
                                        clinic_costdet.prc,
                                        clinic_costdet.num,
                                        clinic_costdet.realfee as je,
                                        clinic_costdet.spec AS guige,
                                        prodjixing. NAME AS jixing
                                   FROM clinic_costdet left join bas_item on clinic_costdet.item_id = bas_item.id
                                        left join gsxmlb on gsxmlb.hisid = clinic_costdet.itemtype_id 
                                        left join (select sn as id,name from sys_dict where father_id=40) prodjixing on bas_item.dosageform_id = prodjixing.id
                                   WHERE clinic_costdet.clinic_Invoice_id IN ( " + iid4 + " )";

            DataTable dt = BllMain.Db.Select(sql_mzbr).Tables[0];
            in1.Log_name = "sendAdviceInfo";
            in1.YwName = "sendAdviceInfo";
            string data = "<advReqData>";
            data += " <sessionid>" + sessionid + "</sessionid>";
            data += " <akc190>" + _iid + "</akc190>";
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
                    return;
                }
                sessionid = ""; return;
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
                    return;
                }
                sessionid = "";
                return;
            }
            DataTable dtfh = out1.Ds.Tables["kc22"];
            for (int i = 0; i < dtfh.Rows.Count; i++)
            {
                string sql_cx = " update clinic_costdet set tcsl='" + dtfh.Rows[i]["zkc266"].ToString().Trim() + "',tcje='" + dtfh.Rows[i]["alc408"].ToString().Trim() + "',tcyy='" + dtfh.Rows[i]["aka073"].ToString().Trim() + "' where id=" + dtfh.Rows[i]["idx"].ToString().Trim();
                BllMain.Db.Update(sql_cx);
            }
            string sql_tc = "SELECT	clinic_costdet.id AS idx,	bas_item.`name` AS xmmc,	clinic_costdet.createdate AS sfsj,	clinic_costdet.prc,	clinic_costdet.realfee as amt,	clinic_costdet.num as qty,tcsl,	tcje,	tcyy FROM	clinic_costdet,	bas_item WHERE	clinic_costdet.item_id = bas_item.id AND clinic_costdet.clinic_cost_id IN (" + iid4+")";
            
            DataTable dt_tc = BllMain.Db.Select(sql_tc).Tables[0];
            dataGridView5.DataSource = dt_tc;
            
            tabControl1.SelectedTab = tabPage3;
        }

        private void btn_js_Click(object sender, EventArgs e)
        {
            if (_iid == "0")
            {
                return;
            }
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
            data += " <akc190>" + _iid + "</akc190>";
            data += " <aaca07>" + tbx_fph.Text.Trim() + "</aaca07>";
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
                string sql = "select name from gsxmlb where id='"+lb+"'";
                DataTable dt2 = BllMain.Db.Select(sql).Tables[0];
                dt_sf.Rows[i]["aka063"] = dt2.Rows[0]["name"].ToString().Trim();
            }
                dataGridView7.DataSource = dt_sf;
            tabControl1.SelectedTab = tabPage5;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_iid == "0")
            {
                return;
            }
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
            data += " <akc190>" + _iid + "</akc190>";
            data += " <aaca07>" + tbx_fph.Text.Trim() + "</aaca07>";
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
            tabControl1.SelectedTab = tabPage1;
            string flag1 = dldc.dengchu(sessionid);
            if (flag1 == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (_iid == "0")
            {
                return;
            }
            if (cyjsjbbm.Text.Trim() == "")
            {
                MessageBox.Show("没有出院疾病!");
                return;
            }
            string sql_sfxgs = "select sfxgs from clinic_invoice  where id in(" + iid4 + ")";
            DataTable dt_sfxgs = BllMain.Db.Select(sql_sfxgs).Tables[0];
            if (dt_sfxgs.Rows[0]["sfxgs"].ToString().Trim() == "1")
            {
                if (gsba_rdbz.Text.Trim() == "")
                {
                    MessageBox.Show("该病人为新工伤，先获取备案信息！");
                    return;
                }
                if (gsba_rdbz.Text.Trim() != "1" || gsba_rdbz.Text.Trim() != "3")
                {
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
            string zyts = "1";
            string data = "<leaveReqData>";
            data += " <sessionid>" + sessionid + "</sessionid>";
            data += " <akc190>" + _iid + "</akc190>";
            data += "<aac002>" + tbx_jmylzh.Text + "</aac002>";
            data += "<aac003>" + tbx_dkxm.Text + "</aac003>";
            data += "<akc194>" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "</akc194>";
            data += "<akc195>" + comboCyyy.SelectedValue.ToString() + "</akc195>";
            data += "<akc196>" + cyjsjbbm.Text + "</akc196>";
            data += "<ints>" + zyts + "</ints>";
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
            MessageBox.Show("出院成功！");
            string flag1 = dldc.dengchu(sessionid);
            if (flag1 == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = "";
        }

        private void dataGridView2_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (_iid == "0")
            {
                return;
            }
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
            data += " <akc190>" + _iid + "</akc190>";
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
            MessageBox.Show("撤销出院成功！");
            string flag1 = dldc.dengchu(sessionid);
            if (flag1 == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(this.RydjGrbh.Text.Trim()))
            {
                MessageBox.Show("请先获取工伤信息！");
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
            data += " <aac001>" + this.RydjGrbh.Text.Trim() + "</aac001>";
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
            DataTable dt= out1.Ds.Tables["ldc1"];
            for(int i=0;i<dt.Rows.Count;i++)
            {
                string bz=dt.Rows[i]["alc029"].ToString().Trim();
                if(bz=="0"){bz="未认定";}else if(bz=="1"){bz="认定为工伤";}else if(bz=="2"){bz="不认定为工伤";}else if(bz=="3"){bz="认定为视同工伤";}else if(bz=="4"){bz="不认定为视同工伤";}
                dt.Rows[i]["alc029"]=bz;
                string bz1 = dt.Rows[i]["CLC004"].ToString().Trim();
                if (bz1 == "00") { bz1 = "事故报告"; } else if (bz1 == "10") { bz1 = "认定申请"; } else if (bz1 == "20") { bz1 = "认定受理"; } else if (bz1 == "30") { bz1 = "认定决议"; } else if (bz1 == "40") { bz1 = "认定回证"; } else if (bz1 == "50") { bz1 = "认定补证"; } else if (bz1 == "60") { bz1 = "认定举证"; } else if (bz1 == "70") { bz1 = "认定调查"; } else if (bz1 == "80") { bz1 = "认定中止"; }
                dt.Rows[i]["CLC004"] = bz1;
            }
            dataGridView2.DataSource = dt;
            string flag1 = dldc.dengchu(sessionid);
            if (flag1 == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = "";
            dataGridView2.Visible = true;
            tabControl1.SelectedTab = tabPage2;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (_iid == "")
            {
                return;
            }
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
            data += " <akc190>" + _iid + "</akc190>";
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
            data += " <akc190>" + _iid + "</akc190>";
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
            string grbh = RydjGrbh.Text.Trim();

            DataTable dt2 = out1.Ds.Tables["kc22dtos"];
            string flag1 = dldc.dengchu(sessionid);
            if (flag1 == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = "";
            Frmgsjsd gsjsd = new Frmgsjsd();
            gsjsd.PreView(dt1, dt2,grbh);
            gsjsd.StartPosition = FormStartPosition.CenterScreen;
            gsjsd.ShowDialog(this);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            
            if (tbx_rdsh.Text.Trim() == "")
            {
                return;
            }
            FrmJxzl jxzl = new FrmJxzl();
            jxzl.Xm = tbx_dkxm.Text.Trim();
            jxzl.Rdsh = tbx_rdsh.Text.Trim();
            jxzl.Sfzh = tbx_jmylzh.Text.Trim();
            jxzl.Grbh = RydjGrbh.Text.Trim();
            string sql_ys = "select bas_doctor.name as fullname from clinic_cost,bas_doctor where bas_doctor.id=clinic_cost.doctor_id and clinic_cost.id=" + _iid;
            DataTable dt1 = BllMain.Db.Select(sql_ys).Tables[0];
            jxzl.Zzys = dt1.Rows[0]["fullname"].ToString().Trim();
            jxzl.Mtzyjliid = _iid;

            //string sql = "select zyjlryzd from mtzyjl where iid=" + zyjlh;
            //DataTable dt = hisdb.Select(sql).Tables[0];
            jxzl.Ylzd = "";//dt.Rows[0]["zyjlryzd"].ToString().Trim();
            jxzl.StartPosition = FormStartPosition.CenterScreen;
            jxzl.ShowDialog(this);
        }

        private void button13_Click(object sender, EventArgs e)
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
            DataTable dt1 = dt.Tables["lkb7"];
             for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string bz = dt1.Rows[i]["akc175"].ToString();
                if (bz == "11") { bz = "初审状态"; } else if (bz == "0") { bz = "未审核"; } else if (bz == "1") { bz = "审核通过"; } else if (bz == "2") { bz = "审核未通过"; } else if (bz == "12") { bz = "复审状态"; }

                dt1.Rows[i]["akc175"] = bz;
                string bz1 = dt1.Rows[i]["jxzl"].ToString();
                if (bz1 == "2") { bz1 = "住院"; }
                dt1.Rows[i]["jxzl"] = bz1;

                string bz2 = dt1.Rows[i]["ale021"].ToString();
                if (bz2 == "3") { bz2 = "康复治疗"; } else if (bz2 == "2") { bz2 = "继续治疗"; } 

                dt1.Rows[i]["ale021"] = bz2;

            }
             dataGridView9.DataSource = dt1;
                dataGridView9.Visible = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            
            string sql = "select spbh from clinic_cost where id=" + _iid;
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
            string sql_up = "update clinic_cost set spbh='' where id=" + _iid;
            MessageBox.Show("撤销继续治疗成功！");

            string flag1 = dldc.dengchu(sessionid);
            if (flag1 == "1")
            {
                MessageBox.Show(dldc.Message);
                return;
            }
            sessionid = "";

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
                }
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int rowIdx = dataGridView1.CurrentRow.Index;
                    RydjGrbh.Text = dataGridView1.Rows[rowIdx].Cells["Column27"].Value.ToString();

                     try
                {
                    tbx_rdsh.Text = dataGridView1.Rows[rowIdx].Cells["Column28"].Value.ToString();
                }
                catch { }
                try
                {
                RydjDwbh.Text = dataGridView1.Rows[rowIdx].Cells["Column29"].Value.ToString();
                     }
                catch { }
                    try
                {
                tbx_dkzyzt.Text = dataGridView1.Rows[rowIdx].Cells["Column30"].Value.ToString();
                         }
                catch { }
                        try
                {
                txt_qybh.Text = dataGridView1.Rows[rowIdx].Cells["Column31"].Value.ToString();
                             }
                catch { }
                            try
                {
                tbx_jmylzh.Text = dataGridView1.Rows[rowIdx].Cells["Column32"].Value.ToString();
                                 }
                catch { }
                                try
                {
                tbx_dkxm.Text = dataGridView1.Rows[rowIdx].Cells["Column33"].Value.ToString();
                                     }
                catch { }
                                    try
                {
                tbx_dkxb.Text = dataGridView1.Rows[rowIdx].Cells["Column34"].Value.ToString();
                                         }
                catch { }
                                        try
                {
                txt_rylb.Text = dataGridView1.Rows[rowIdx].Cells["Column35"].Value.ToString();
                                             }
                catch { }
                                            try
                {
                tbx_jgbh.Text = dataGridView1.Rows[rowIdx].Cells["Column36"].Value.ToString();
                                                 }
                catch { }
                                                try
                {
                tbx_gsfssj.Text = dataGridView1.Rows[rowIdx].Cells["Column37"].Value.ToString();
                                                     }
                catch { }
                                                    try
                {

                string shcd = dataGridView1.Rows[rowIdx].Cells["Column38"].Value.ToString();
                if (shcd == "1") { shcd = "死亡"; } else if (shcd == "3") { shcd = "工伤"; } else if (shcd == "5") { shcd = "失踪"; }
                tbx_shcd.Text = shcd;
                }
                                                    catch { }
                try
                {
                tbx_shbw.Text = dataGridView1.Rows[rowIdx].Cells["Column39"].Value.ToString();
                 }
                catch { }
                try
                {
                textBox4.Text = dataGridView1.Rows[rowIdx].Cells["Column40"].Value.ToString();
             }
                catch { }
                try
                {
                textBox2.Text = dataGridView1.Rows[rowIdx].Cells["Column41"].Value.ToString();
         }
                catch { }
                try
                {
                    string gslb = dataGridView1.Rows[rowIdx].Cells["Column42"].Value.ToString();
                    string sql_gslb = "select name from gsgslb where id='" + gslb + "'";
                    DataTable dt_gslb = BllMain.Db.Select(sql_gslb).Tables[0];
                    tbx_gslb.Text = dt_gslb.Rows[0]["name"].ToString().Trim();
                }
                catch { tbx_gslb.Text = ""; }
                try
                {
                    string scdj = dataGridView1.Rows[rowIdx].Cells["Column44"].Value.ToString();
                    string sql_scdj = "select name from gsscdj where id='" + scdj + "'";
                    DataTable dt_scdj = BllMain.Db.Select(sql_scdj).Tables[0];
                    tbx_scdj.Text = dt_scdj.Rows[0]["name"].ToString().Trim();
                }
                catch { }
                tbx_lgsbz.Text = dataGridView1.Rows[rowIdx].Cells["Column45"].Value.ToString();

                string dyffzt = dataGridView1.Rows[rowIdx].Cells["Column46"].Value.ToString();
                if (dyffzt == "0") { dyffzt = "暂停发放"; } else if (dyffzt == "1") { dyffzt = "正常发放"; } else if (dyffzt == "3") { dyffzt = "待遇终止"; } else if (dyffzt == "5") { dyffzt = "新增待复核"; }
                tbx_dyffzt.Text = dyffzt;
                }
            }
            if (tbx_rdsh.Text.Trim() == "")
            {
                MessageBox.Show("该病人为新发工伤！请点击获取工伤备案按钮！");
                checkBox1.Checked = true;
            }
            else
            {
                //MessageBox.Show("该病人为老工伤！请点击获取继续治疗按钮！");
                checkBox1.Checked = false;
                //button1.Visible = true;
            }
            textBox1.Text = tbx_dkxm.Text;
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
                    brxx_CellClick(_iid);
                }
            }
        }
        private void brxx_CellClick(string iid)
        {
            if (_iid == "")
            {
                return;
            }
            string sql_mzbr = @"SELECT clinic_costdet.id AS cfh,	clinic_invoice.invoice AS fph,DATE_FORMAT(clinic_costdet.rcpdate, '%Y-%m-%d') AS cfsj,
                                  '1' AS cfts,bas_item.gsbm AS xmbm,bas_item.`name` AS xmmc,gsxmlb.`name` AS sflb,'' AS sfdj,
                                  CASE WHEN (bas_item.itemtype_id = 10) OR (bas_item.itemtype_id = 11) OR (	bas_item.itemtype_id = 12) THEN	'0' ELSE	'1' END AS zl,
                                   clinic_costdet.prc,clinic_costdet.num AS num,clinic_costdet.realfee as amt,
                                   clinic_costdet.spec AS guige, prodjixing. NAME AS jixing, bas_item.id AS prodid
                           FROM clinic_costdet left join bas_item on clinic_costdet.item_id = bas_item.id
                                left join gsxmlb on gsxmlb.hisid = clinic_costdet.itemtype_id 
                                left join clinic_invoice on clinic_invoice.id = clinic_costdet.clinic_invoice_id 
	                            left join (select sn as id,name from sys_dict where father_id=40) prodjixing on bas_item.dosageform_id = prodjixing.id
                           WHERE clinic_costdet.clinic_invoice_id=" + _iid;
            dt_xxxx = BllMain.Db.Select(sql_mzbr).Tables[0];
            if (dt_xxxx.Rows.Count != 0)
            {
                this.tbx_fph.Text = dt_xxxx.Rows[0]["fph"].ToString().Trim();
            }
            else
            { this.tbx_fph.Text = ""; }
            string sql_yz = @" SELECT clinic_costdet.id AS aae080,
                                      clinic_costdet.rcpdate AS alk007,
                                      clinic_costdet.rcpdate AS alk008,
                                      bas_item.`name` AS alk009,
                                      '' AS alk011,
                                      '' AS alk012,
                                      clinic_costdet.num AS alk013,
                                      '' AS alk014,
                                      '' AS alk015,
                                      bas_doctor.`name` AS alk016,
                                      '' AS alk017,
                                      bas_doctor.`name` AS alk020,
                                      '2' AS alk022,
                                      bas_depart.`name`  AS alk023,
                                      '' AS alk024
                                FROM clinic_cost,clinic_costdet,bas_item,bas_doctor,bas_depart
                                WHERE	clinic_costdet.item_id = bas_item.id AND clinic_cost.doctor_id = bas_doctor.id AND bas_depart.id = clinic_cost.depart_id
                                      AND clinic_cost.id = clinic_costdet.clinic_cost_id AND clinic_cost.clinic_invoice_id=" + _iid;
            DataTable dt_yz = BllMain.Db.Select(sql_yz).Tables[0];
            dataGridView8.DataSource = dt_yz;
            dataGridView3.DataSource = dt_xxxx.DefaultView;
            tabControl1.SelectedTab = tabPage2;
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

        private void dataGridView_brxx_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0)
            {
                return;
            }
            string _val = dataGridView_brxx.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString().Trim();
            if (_val.Equals("False"))
                dataGridView_brxx.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
            else
                dataGridView_brxx.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
            cxfy();
        }
        private void cxfy()
        {
            List<string> _sel = new List<string>();
            if (dataGridView_brxx.RowCount < 1)
            {
                return;
            }
            for (int i = 0; i < dataGridView_brxx.RowCount; i++)
            {
                if (dataGridView_brxx.Rows[i].Cells[0].EditedFormattedValue.ToString() == "True")
                {
                    _sel.Add(dataGridView_brxx.Rows[i].Cells["iid"].Value.ToString());
                }
            }

            if (_sel.Count > 0)
            {
                iid4 = "";
                for (int i = 0; i < _sel.Count; i++)
                {
                    if (i < _sel.Count - 1)
                    {
                        iid4 += "'" + _sel[i].ToString() + "',";
                    }
                    else
                    {
                        iid4 += "'" + _sel[i].ToString() + "'";
                    }
                }
            }
            //else
            //    iid += " and 1=0";
            //string mtmzbl = dataGridView1.Rows[0].Cells[2].Value.ToString().Trim();
            string sql = @"SELECT clinic_costdet.id AS cfh,	clinic_invoice.invoice AS fph,DATE_FORMAT(clinic_costdet.rcpdate, '%Y-%m-%d') AS cfsj,
                                  '1' AS cfts,bas_item.gsbm AS xmbm,bas_item.`name` AS xmmc,gsxmlb.`name` AS sflb,'' AS sfdj,
                                  CASE WHEN (bas_item.itemtype_id = 10) OR (bas_item.itemtype_id = 11) OR (	bas_item.itemtype_id = 12) THEN	'0' ELSE	'1' END AS zl,
                                   clinic_costdet.prc,clinic_costdet.num AS num,clinic_costdet.realfee as amt,
                                   clinic_costdet.spec AS guige, prodjixing. NAME AS jixing, bas_item.id AS prodid
                           FROM clinic_costdet left join bas_item on clinic_costdet.item_id = bas_item.id
                                left join gsxmlb on gsxmlb.hisid = clinic_costdet.itemtype_id 
                                left join clinic_invoice on clinic_costdet.clinic_invoice_id = clinic_invoice.id
	                            left join (select sn as id,name from sys_dict where father_id=40) prodjixing on bas_item.dosageform_id = prodjixing.id
                           WHERE clinic_costdet.clinic_invoice_id IN (" + iid4 + " )";

            DataTable cfdb = BllMain.Db.Select(sql).Tables[0];
            dataGridView3.DataSource = cfdb;
            
            tabControl1.SelectedTab = tabPage2;
            if (cfdb.Rows.Count==0)
                return;
            dateTimePicker1.Text = cfdb.Rows[0]["cfsj"].ToString().Trim();
            string sql_iid = "select gsjlh from clinic_cost where id in(" + iid4 + ")";
            DataTable dtiid = BllMain.Db.Select(sql_iid).Tables[0];
            if (dtiid.Rows.Count > 0)
            {
                _iid = dtiid.Rows[0]["gsjlh"].ToString().Trim();
            }

        }
       
    }
}
