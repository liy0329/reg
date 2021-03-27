using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.Util;
using MTHIS.common;
using MTREG.common;
using MTREG.clinic;
using MTHIS.main.bll;
using MTREG.medinsur.sjzsyb.bll;
using MTREG.medinsur.sjzsyb.clinic.bo;
using System.IO;
using MTREG.medinsur.sjzsyb.bean;
using System.Web.UI.WebControls;
using MTREG.medinsur.sjzsyb;


namespace MTREG
{
    public partial class FrmMzYb : Form
    {

        SjzybInterface sjzybInterface = new SjzybInterface();
        public FrmMzYb()
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
        /// <summary>
        /// 病历本号
        /// </summary>
        public string blbcard { get; set; }
        public mz_dk dk_out { get; set; }



        public string regist_id { get; set; }
        DataTable dtdir = new DataTable();


        private void btn_Dk_Click(object sender, EventArgs e)
        {
            SJZYB_IN<DK_IN> yb_in_ryjbxxhzh = new SJZYB_IN<DK_IN>();
            yb_in_ryjbxxhzh.INPUT = new List<DK_IN>();
            DK_IN dk = new DK_IN();
            DK_OUT yb_out_ryjbxxhzh = new DK_OUT();
            dk.BKA130 = "30";//出院预结算
            yb_in_ryjbxxhzh.INPUT.Add(dk);
            yb_in_ryjbxxhzh.MSGNO = "1401";
            yb_in_ryjbxxhzh.AAC001 = "0";
            int ret = sjzybInterface.DK(yb_in_ryjbxxhzh, ref yb_out_ryjbxxhzh);
            if (ret == -1)
            {
                MessageBox.Show(yb_out_ryjbxxhzh.ERRORMSG, "提示信息");
                return;
            }
            fz(yb_out_ryjbxxhzh);
            if (cbx_yllb.SelectedValue.ToString() == "12")
            {
                dataGridView1.Visible = true;
                getdir(yb_out_ryjbxxhzh.AAC001,"12");
            }
            if (cbx_yllb.SelectedValue.ToString() == "15")
            {
                dataGridView1.Visible = true;
                getdir(yb_out_ryjbxxhzh.AAC001, "15");
            }
            //if (yb_out_ryjbxxhzh.CKAA34 == "0" && yb_out_ryjbxxhzh.CKAA36 == "0")
            //{
            //    if (MessageBox.Show("该卡尚未设置定点，是否现在设置为定点？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            //    {
            //        FrmclinicPoint FrmclinicPoint = new FrmclinicPoint();
            //        FrmclinicPoint.ShowDialog();
            //    }
            //}
            if (cbx_yllb.SelectedValue.ToString().Trim() == "11")
            {
                if (yb_out_ryjbxxhzh.ZKA102 != "")
                {
                    MessageBox.Show("该患者存在慢性病！");
                }
                if (yb_out_ryjbxxhzh.ZKA103 != "")
                {
                    MessageBox.Show("该患者存在特殊病！");
                }
            }
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SJZYB_IN<DK_IN> yb_in_ryjbxxhzh = new SJZYB_IN<DK_IN>();
            yb_in_ryjbxxhzh.INPUT = new List<DK_IN>();
            DK_IN dk = new DK_IN();
            DK_OUT yb_out_ryjbxxhzh = new DK_OUT();
            dk.BKA130 = "30";//出院预结算
            yb_in_ryjbxxhzh.INPUT.Add(dk);
            yb_in_ryjbxxhzh.MSGNO = "1401";
            yb_in_ryjbxxhzh.AAC001 = tbxsfzh.Text.ToString();
            dk_out.sfcf = tbxsfzh.Text.ToString();
            int ret = sjzybInterface.DK(yb_in_ryjbxxhzh, ref yb_out_ryjbxxhzh);
            if (ret != 0)
            {
                MessageBox.Show(yb_out_ryjbxxhzh.ERRORMSG, "提示信息");
                return;
            }
            fz(yb_out_ryjbxxhzh);
            if (yb_out_ryjbxxhzh.CKAA34 == "0")
            {
                if (MessageBox.Show("该卡尚未设置定点，是否现在设置为定点？", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    FrmclinicPoint FrmclinicPoint = new FrmclinicPoint();
                    FrmclinicPoint.ShowDialog();
                }
            }
        }
        public void fz(DK_OUT yb_out_ryjbxxhzh)
        {
            dk_out = new mz_dk();
            dk_out.DK_OUT = new DK_OUT();
            dk_out.DK_OUT = yb_out_ryjbxxhzh;
            Ylfkfs_id = cbx_yllb.SelectedValue.ToString();
            ipt_xm.Text = yb_out_ryjbxxhzh.AAC003;
            cmbxcsny.Text = yb_out_ryjbxxhzh.AAC006;
            tbx_xb.Text = yb_out_ryjbxxhzh.AAC004 == "1" ? "男" : "女";
            tbxsfzh.Text = yb_out_ryjbxxhzh.AAC002;
            ipt_grbh.Text = yb_out_ryjbxxhzh.AAC001;
            ipt_ickh.Text = yb_out_ryjbxxhzh.AKC020;
            tbx_grzhye.Text = yb_out_ryjbxxhzh.AKC087;
            checkBox1.Checked = yb_out_ryjbxxhzh.CKAA12 == "1" ? true : false;
            #region 医疗人员类别
            string rylb = "";
            if (yb_out_ryjbxxhzh.AKC021.ToString().Equals("11"))
            {
                rylb = "在职";
            }
            else if (yb_out_ryjbxxhzh.AKC021.ToString().Equals("21"))
            {
                rylb = "退休";

            }
            else if (yb_out_ryjbxxhzh.AKC021.ToString().Equals("31"))
            {
                rylb = "机关离休";
            }
            else if (yb_out_ryjbxxhzh.AKC021.ToString().Equals("32"))
            {
                rylb = "企事业离休";
            }
            else if (yb_out_ryjbxxhzh.AKC021.ToString().Equals("33"))
            {
                rylb = "医疗费实报实销六级及以上伤残军人";
            }
            else if (yb_out_ryjbxxhzh.AKC021.ToString().Equals("41"))
            {
                rylb = "城乡居民";
            }
            else if (yb_out_ryjbxxhzh.AKC021.ToString().Equals("99"))
            {
                rylb = "其他";
            }
            #endregion
            tbx_rylb.Text = rylb;
        }

        private void but_ok_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ipt_grbh.Text))
                return;
            dk_out.AKA130 = cbx_yllb.SelectedValue.ToString();
            for (int i = dataGridView2.Rows.Count - 1; i >= 0; i--)
            {
                if (dataGridView2.Rows[i].Cells["jbbm"].Value != null && dataGridView2.Rows[i].Cells["jbbm"].Value.ToString() != "")
                {
                    if (String.IsNullOrEmpty(dk_out.AKC193))
                    {
                        dk_out.AKC193 += dataGridView2.Rows[i].Cells["jbbm"].Value.ToString();
                        dk_out.AKC140 += dataGridView2.Rows[i].Cells["jbmc"].Value.ToString();
                    }
                    else
                    {
                        dk_out.AKC193 += "," + dataGridView2.Rows[i].Cells["jbbm"].Value.ToString();
                        dk_out.AKC140 += "," + dataGridView2.Rows[i].Cells["jbmc"].Value.ToString();
                    }
                }
            }
            //dk_out.AKC193 = this.txtjbbmcode.Text;
            //dk_out.AKC140 = this.txtjbbm.Text;
            blbcard = tb_blbh.Text;
            flag = true;
            this.Close();
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.flag = false;
            this.Dispose();
        }


        //医疗类别
        private void init_yblb()
        {
            List<ListItem> list = new List<ListItem>();
            list.Add(new ListItem("普通门诊", "11"));
            list.Add(new ListItem("门诊慢性病", "12"));
            list.Add(new ListItem("公务员普通门诊", "14"));
            list.Add(new ListItem("特殊病门诊", "15"));
            list.Add(new ListItem("生育门诊", "13"));
            cbx_yllb.DisplayMember = "Text";
            cbx_yllb.ValueMember = "Value";
            cbx_yllb.DataSource = list;
        }

        private void FrmMzYb_Load(object sender, EventArgs e)
        {
            init_yblb();
            string jbmc = "";
            string jbbm = "";
            dtdir.Columns.Add("jbmc");
            dtdir.Columns.Add("jbbm");
            
            //string sql = " SELECT insur_illness_name AS '疾病名称',insur_illness_illcode AS '疾病编码'  FROM insur_directory_contrast WHERE bas_caseicd_name = (SELECT clinicdiagn FROM clinic_record WHERE regist_id = '" + regist_id + "' )";
            string sql = "SELECT distinct clinicdiagn FROM clinic_record WHERE regist_id = '" + regist_id + "'";
            DataTable zyjlds = BllMain.Db.Select(sql).Tables[0];
            string[] bmlist = zyjlds.Rows[0]["clinicdiagn"].ToString().Split(' ');
            foreach (string bm in bmlist)
            {
                if (bm.Length > 2)
                {
                    string sql_insur = " SELECT distinct insur_illness_name AS '疾病名称',insur_illness_illcode AS '疾病编码'  FROM insur_directory_contrast WHERE bas_caseicd_name = '" + bm.Substring(2, bm.Length - 2).ToString().Trim() + "'";
                    DataTable dt_insur = BllMain.Db.Select(sql_insur).Tables[0];
                    if (dt_insur.Rows.Count >= 1)
                    {
                        if (String.IsNullOrEmpty(jbbm))
                        {
                            jbmc = dt_insur.Rows[0]["疾病名称"].ToString();
                            jbbm = dt_insur.Rows[0]["疾病编码"].ToString();
                        }
                        else
                        {
                            jbmc =  dt_insur.Rows[0]["疾病名称"].ToString();
                            jbbm =  dt_insur.Rows[0]["疾病编码"].ToString();
                        }
                        DataRow dr = dtdir.NewRow();
                        dr["jbmc"] = jbmc;
                        dr["jbbm"] = jbbm;
                        try
                        {
                            dtdir.Rows.Add(dr);
                        }catch( Exception ex )
                        {
                        }
                    }

                }
            }
            dataGridView2.DataSource = dtdir;

            try
            {
                DataGridViewColumn col = dataGridView2.Columns[1];
                //按降序(即始终每次新添加的数据排最前)
                ListSortDirection direction = ListSortDirection.Descending;
                dataGridView2.Sort(col, direction);
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Name = "btnModify";
                btn.HeaderText = "删除";
                btn.DefaultCellStyle.NullValue = "删除";
                dataGridView2.Columns.Add(btn);
                dataGridView2.Columns["btnModify"].HeaderText = "删除";
                dataGridView2.Columns["btnModify"].Width = 50;
                dataGridView2.Columns["btnModify"].DisplayIndex = 0;
            }
            catch (Exception ex)
            {

            }
            //for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            //{
            //    dataGridView2.Rows[i].Cells["jbmc"].ReadOnly = true;
            //    dataGridView2.Rows[i].Cells["jbbm"].ReadOnly = true;
            //}
            dk_out = new mz_dk();
        }
        public void setdate(string jbmc, string jbbm)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                label8.Visible = true;
                tb_blbh.Visible = true;
            }
            else
            {
                label8.Visible = false;
                tb_blbh.Visible = false;
            }
        }

        private void cbx_yllb_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        public void getdir(string AAC001, string AKA130)
        {
            #region
            
            SJZYB_IN<grmxbspxxcx_In> yb_in_grmx = new SJZYB_IN<grmxbspxxcx_In>();
            yb_in_grmx.INPUT = new List<grmxbspxxcx_In>();
            grmxbspxxcx_In doc = new grmxbspxxcx_In();
            List<grmxbspxxcx_Out> yb_out_grmx = new List<grmxbspxxcx_Out>();
            doc.AAC001 = AAC001;
            doc.AKA130 = AKA130;
            yb_in_grmx.MSGNO = "1910";
            yb_in_grmx.INPUT.Add(doc);

            int opstat = sjzybInterface.grmxbspxxcx(yb_in_grmx, ref yb_out_grmx);

            string ReturnMsg = "";
            //int opstat = Convert.ToInt32(yb_out_grmx[0].RETURNNUM);
            if (opstat == -1)//错误，业务出参中的errorMSG为错误信息
            {
                ReturnMsg = yb_out_grmx[0].ERRORMSG;
                MessageBox.Show(ReturnMsg, "提示信息");
                return;
            }
            dataGridView1.DataSource = yb_out_grmx.ToDataTable<grmxbspxxcx_Out>();

            #region 编辑格式

            dataGridView1.Columns["BKC462"].HeaderText = "疾病编码";
            dataGridView1.Columns["BKC462"].Width = 130;
            dataGridView1.Columns["BKC462"].DisplayIndex = 0;

            dataGridView1.Columns["AKA121"].HeaderText = "疾病名称";
            dataGridView1.Columns["AKA121"].Width = 130;
            dataGridView1.Columns["AKA121"].DisplayIndex = 1;

            dataGridView1.Columns["AAE030"].HeaderText = "开始时间";
            dataGridView1.Columns["AAE030"].Width = 120;
            dataGridView1.Columns["AAE030"].DisplayIndex = 2;

            dataGridView1.Columns["AAE031"].HeaderText = "结束时间";
            dataGridView1.Columns["AAE031"].Width = 120;
            dataGridView1.Columns["AAE031"].DisplayIndex = 3;

            dataGridView1.Columns["BAE073"].Visible = false;
            dataGridView1.Columns["AKA130"].Visible = false;
            dataGridView1.Columns["AKB020"].Visible = false;
            dataGridView1.Columns["RETURNNUM"].Visible = false;
            dataGridView1.Columns["ERRORMSG"].Visible = false;
            dataGridView1.Columns["REFMSGID"].Visible = false;

            #endregion
            #endregion
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataRow dr = dtdir.NewRow();
            dr["jbmc"] = dataGridView1.CurrentRow.Cells["AKA121"].Value;
            dr["jbbm"] = dataGridView1.CurrentRow.Cells["BKC462"].Value; 
            dtdir.Rows.Add(dr);
            dataGridView2.DataSource = dtdir;
            
        }

        private void dataGridView2_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            //dataGridView2.EndEdit();
            //string sql = "";
            //DataTable ryzddata = new DataTable();
            //string jbmc = dataGridView2.CurrentRow.Cells["jbmc"].Value.ToString();
            //Console.WriteLine(jbmc);
            //if (String.IsNullOrEmpty(jbmc))
            //    return;
            //string tiaojian = " where 1=1 and (name like '" + jbmc + "%' or pincode like '%" + jbmc + "%')";
            //sql = " select illcode as code,name as name,pincode as jm from insur_illness " + tiaojian;
            //ryzddata = BllMain.Db.Select(sql).Tables[0];
            //if (ryzddata.Rows.Count > 0)
            //{
            //    dgw_ryjbmc.DataSource = ryzddata;
            //    dgw_ryjbmc.Visible = true;
            //}
            //else
            //{
            //    dgw_ryjbmc.Visible = false;
            //}
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                removeCurrentRow();
            }
        }
        //删除一行项目
        private void removeCurrentRow()
        {
            DataGridViewColumn column = dataGridView2.Columns[dataGridView2.CurrentCell.ColumnIndex];
            if (column is DataGridViewButtonColumn)
            {
                if (dataGridView2.CurrentRow.Index == dataGridView2.Rows.Count - 1)
                {
                    return;
                }
                if (dataGridView2.CurrentRow.Cells["jbmc"].Value != null && !string.IsNullOrEmpty(dataGridView2.CurrentRow.Cells["jbmc"].Value.ToString().Trim()))
                {
                    if (MessageBox.Show("确定删除【 " + dataGridView2.CurrentRow.Cells["jbmc"].Value.ToString() + " 】吗？", "提示信息", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    {
                        return;
                    }
                }
                dataGridView2.Rows.Remove(dataGridView2.CurrentRow);
                dataGridView2.CurrentCell = dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells["jbmc"];
            }
        }

        //private void tbxPincode_TextChanged(object sender, EventArgs e)
        //{
        //    dataGridView2.EndEdit();
        //    string sql = "";
        //    DataTable ryzddata = new DataTable();
        //    string jbmc = tbxPincode.Text.ToString();
        //    Console.WriteLine(jbmc);
        //    if (String.IsNullOrEmpty(jbmc))
        //        return;
        //    string tiaojian = " where 1=1 and (name like '" + jbmc + "%' or pincode like '%" + jbmc + "%')";
        //    sql = " select illcode as code,name as name,pincode as jm from insur_illness " + tiaojian;
        //    ryzddata = BllMain.Db.Select(sql).Tables[0];
        //    if (ryzddata.Rows.Count > 0)
        //    {
        //        dgw_ryjbmc.DataSource = ryzddata;
        //        dgw_ryjbmc.Visible = true;
        //    }
        //    else
        //    {
        //        dgw_ryjbmc.Visible = false;
        //    }
        //}

        //private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{
        //    //dataGridView2.EndEdit();
        //    if (dataGridView2.CurrentCell.OwningColumn.Name == "jbmc")
        //    {
        //        System.Windows.Forms.TextBox tbx = e.Control as System.Windows.Forms.TextBox;
        //        tbx.TextChanged += new EventHandler(tbx_TextChanged);
        //    }
        //}

        //private void tbx_TextChanged(object sender, EventArgs e)
        //{
        //    System.Windows.Forms.TextBox tbx = (System.Windows.Forms.TextBox)sender;
        //    if (!string.IsNullOrEmpty(tbx.Text))
        //    {
        //        showDgvBasItem();
        //        dataGridView2.ClearSelection();
        //        tbxPincode.Text = tbx.Text;
        //        tbxPincode.SelectionStart = tbxPincode.Text.Length;
        //    }
        //}

        ////焦点跳转
        //private void showDgvBasItem()
        //{
        //    if (this.dataGridView2.CurrentCell.RowIndex == dataGridView2.Rows.Count - 1 && dataGridView2.CurrentCell.ColumnIndex == 0)
        //    {
        //        Point location = dataGridView2.Location;
        //        int cellX = location.X;
        //        int cellY = location.Y + dataGridView2.ColumnHeadersHeight + (dataGridView2.Rows.Count - 1) * dataGridView2.RowTemplate.Height;
        //        dataGridView2.EndEdit();
        //        panelBasItem.Location = new Point(cellX, cellY);
        //        panelBasItem.Visible = true;
        //        tbxPincode.Focus();
        //    }
        //}

        //private void dgw_ryjbmc_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    DataRow dr = dtdir.NewRow();

        //    dr["jbmc"] = dgw_ryjbmc.CurrentRow.Cells["ryzdname"].Value;
        //    dr["jbbm"] = dgw_ryjbmc.CurrentRow.Cells["ryzdjm"].Value;
        //    if (dr["jbmc"].ToString() == null && dr["jbbm"].ToString() == null)
        //    {
        //        return;
        //    }
        //    dtdir.Rows.Add(dr);
        //    for (int i = 0; i < dtdir.Rows.Count - 1; i++)
        //    {
        //        if (dtdir.Rows[i]["jbmc"].ToString() == "" || dtdir.Rows[i]["jbbm"].ToString() == "")
        //        {
        //            dtdir.Rows.RemoveAt(i);
        //        }
        //    }
        //    dataGridView2.DataSource = dtdir;
        //    //for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
        //    //{
        //    //    dataGridView2.Rows[i].Cells["jbmc"].ReadOnly = true;
        //    //    dataGridView2.Rows[i].Cells["jbbm"].ReadOnly = true;
        //    //}
        //    panelBasItem.Visible = false;
        //}

    }
}
