using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Microsoft.Office.Interop.Excel;
using MTHIS.db;
using MTREG.ihsp.bll;
using MTREG.ihsp.bo;
using MTREG.medinsur.gzsyb.listitem;
using MTREG.ihsp;
using MTHIS.main.bll;
using MTREG.common;
using MTHIS.common;
using MTREG.ihsptab.bo;
using MTREG.medinsur.hdyb.bll;
using MTREG.medinsur.hdyb.dor;
using MTREG;

namespace MTREG.medinsur.hdyb
{
    public partial class frmXJHB : Form
    {
        YBCJ yw1 = new YBCJ();
        BillIhspMan billIhspMan = new BillIhspMan();
        BillCmbList billCmbList = new BillCmbList();
        BillIhspcost billIhspcost = new BillIhspcost();
        BillIhspAct billIhspAct = new BillIhspAct();
        Inhospital inhospital = new Inhospital();
        public frmXJHB()
        {
            InitializeComponent();
        }
        private string chState;

        public string ChState
        {
            get { return chState; }
            set { chState = value; }
        }
        private string ybState;

        public string YbState
        {
            get { return ybState; }
            set { ybState = value; }
        }
        private string zyState;

        public string ZyState
        {
            get { return zyState; }
            set { zyState = value; }
        }
        private string qybState;

        public string QybState
        {
            get { return qybState; }
            set { qybState = value; }
        }
        private string qchState;

        public string QchState
        {
            get { return qchState; }
            set { qchState = value; }
        }
        private string isxjhb;

        public string Isxjhb
        {
            get { return isxjhb; }
            set { isxjhb = value; }
        }
        private string isytdnzjbx;

        public string Isytdnzjbx
        {
            get { return isytdnzjbx; }
            set { isytdnzjbx = value; }
        }

        private string mrylfkfs;

        public string Mrylfkfs
        {
            get { return mrylfkfs; }
            set { mrylfkfs = value; }
        }
        private string mrybcjbz;

        public string Mrybcjbz
        {
            get { return mrybcjbz; }
            set { mrybcjbz = value; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            seachMethod();
        }

        private void frmXJHB_Load(object sender, EventArgs e)
        {
            //setYbChBtnState();
            setTime();
            tabControlMain.SelectedIndex = 1;
            ksinit();//科室初始化
            //cyksinit();//科室初始化
            Bind();//付款方式住院状态
            InitXb();//初始化性别

            btn_cyjs.Enabled = true;
            button12.Enabled = true;
            button8.Visible = true;
            initcyfkfs();//出院结算付款方式
            //initdataGridView();//结算datagridview添加按钮列
            initzyzt();//住院状态
            seachMethod();//入院登记查询初始化
            //dgvcy();//出院结算界面初始化 
            //isload = true;
            cyjscx();
            System.Data.DataTable dtp = billCmbList.patientTypeListInsur();
            if (dtp.Rows.Count > 0)
            {
                this.cbxjs_zfzyb.ValueMember = "id";
                this.cbxjs_zfzyb.DisplayMember = "name";
                this.cbxjs_zfzyb.DataSource = dtp;

                cbxjs_zfzyb.SelectedValue = "41";
            }
            #region  dgv单元格标题设置
            dataGridView1.Font = new System.Drawing.Font("宋体", (float)(13 * ProgramGlobal.WidthScale));
            this.dataGridView1.RowsDefaultCellStyle.Font = new System.Drawing.Font("宋体", (float)(13 * ProgramGlobal.WidthScale));
            this.dataGridView1.ColumnHeadersHeight = (int)(30 * ProgramGlobal.HeightScale);
            this.dataGridView1.Columns["ihspcode"].HeaderText = "住院号";
            this.dataGridView1.Columns["ihspcode"].Width = (int)(120 * ProgramGlobal.WidthScale);
            this.dataGridView1.Columns["ihspname"].HeaderText = "姓名";
            this.dataGridView1.Columns["ihspname"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dataGridView1.Columns["sex"].HeaderText = "性别";
            this.dataGridView1.Columns["sex"].Width = (int)(60 * ProgramGlobal.WidthScale);
            this.dataGridView1.Columns["departname"].HeaderText = "科室";
            this.dataGridView1.Columns["departname"].Width = (int)(130 * ProgramGlobal.WidthScale);
            this.dataGridView1.Columns["doctorname"].HeaderText = "医生";
            this.dataGridView1.Columns["doctorname"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dataGridView1.Columns["sickroomname"].HeaderText = "病室";
            this.dataGridView1.Columns["sickroomname"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dataGridView1.Columns["sickbedname"].HeaderText = "床号";
            this.dataGridView1.Columns["sickbedname"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dataGridView1.Columns["indate"].HeaderText = "入院时间";
            this.dataGridView1.Columns["indate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            this.dataGridView1.Columns["indate"].Width = (int)(120 * ProgramGlobal.WidthScale);
            this.dataGridView1.Columns["hspcard"].HeaderText = "卡  号";
            this.dataGridView1.Columns["hspcard"].Width = (int)(120 * ProgramGlobal.WidthScale);
            this.dataGridView1.Columns["patienttype"].HeaderText = "患者类型";
            this.dataGridView1.Columns["patienttype"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dataGridView1.Columns["bas_patienttype_id"].HeaderText = "患者类型id";
            this.dataGridView1.Columns["bas_patienttype_id"].Visible = false;
            this.dataGridView1.Columns["displaycolor"].Visible = false;
            this.dataGridView1.Columns["id"].HeaderText = "Id";
            this.dataGridView1.Columns["id"].Visible = false;
            #endregion           
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            #region  dgvInhospital单元格标题设置
            dataGridView2.Font = new System.Drawing.Font("宋体", (float)(11 * ProgramGlobal.WidthScale));
            dataGridView2.RowsDefaultCellStyle.Font = new System.Drawing.Font("宋体", (float)(11 * ProgramGlobal.WidthScale));
            this.dataGridView2.Columns["ihspcode"].HeaderText = "住院号";
            this.dataGridView2.Columns["ihspcode"].Width = (int)(100*ProgramGlobal.WidthScale);
            this.dataGridView2.Columns["ihspname"].HeaderText = "姓名";
            this.dataGridView2.Columns["ihspname"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dataGridView2.Columns["deparname"].HeaderText = "科室";
            this.dataGridView2.Columns["deparname"].Width = (int)(120 * ProgramGlobal.WidthScale);
            this.dataGridView2.Columns["indate"].HeaderText = "入院时间";
            this.dataGridView2.Columns["indate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            this.dataGridView2.Columns["indate"].Width = (int)(110 * ProgramGlobal.WidthScale);
            this.dataGridView2.Columns["outdate"].HeaderText = "出院时间";
            this.dataGridView2.Columns["outdate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            this.dataGridView2.Columns["outdate"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dataGridView2.Columns["settInsurdate"].HeaderText = "报销时间";
            this.dataGridView2.Columns["settInsurdate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            this.dataGridView2.Columns["settInsurdate"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dataGridView2.Columns["prepamt"].HeaderText = "预交合计";
            this.dataGridView2.Columns["prepamt"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dataGridView2.Columns["prepamt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView2.Columns["feeamt"].HeaderText = "费用合计";
            this.dataGridView2.Columns["feeamt"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dataGridView2.Columns["feeamt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView2.Columns["patienttype"].HeaderText = "患者类型";
            this.dataGridView2.Columns["patienttype"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dataGridView2.Columns["companyname"].HeaderText = "工作单位";
            this.dataGridView2.Columns["companyname"].Width = (int)(150 * ProgramGlobal.WidthScale);
            this.dataGridView2.Columns["homeaddress"].HeaderText = "家庭住址";
            this.dataGridView2.Columns["homeaddress"].Width = (int)(150 * ProgramGlobal.WidthScale);
            this.dataGridView2.Columns["homephone"].HeaderText = "联系电话";
            this.dataGridView2.Columns["homephone"].Width = (int)(130 * ProgramGlobal.WidthScale);
            this.dataGridView2.Columns["status"].HeaderText = "状态";
            this.dataGridView2.Columns["status"].Visible = false;
            this.dataGridView2.Columns["id"].HeaderText = "id";
            this.dataGridView2.Columns["id"].Visible = false;
            this.dataGridView2.Columns["bas_patienttype_id"].HeaderText = "患者类型id";
            this.dataGridView2.Columns["bas_patienttype_id"].Visible = false;
            this.dataGridView2.Columns["displaycolor"].Visible = false;
            this.dataGridView2.Columns["neonate"].Visible = false;
            this.dataGridView2.Columns["ihsp_account_id"].Visible = false;
            #endregion            
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        public void cyjscx()
        {
            string patienttype = "";
            string depart = "";
            Inhospital inhospital = new Inhospital();
            inhospital.Name = this.tbx_cyjs_xm.Text.Trim().ToString();
            inhospital.Ihspcode = this.tbx_cyjs_zyh.Text.ToString();
            inhospital.Indate = this.cyjs_Starttime.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            inhospital.Outdate = this.cyjs_Endtime.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            inhospital.Hspcard = "";
            if (this.cbx_jsks.Text == "--全部--")
            {
                depart = "";
            }
            else
            {
                depart = this.cbx_jsks.SelectedValue.ToString();
            }
            inhospital.Depart = depart;
            string status = this.cbx_cyjs_zyzt.Text.Trim().ToString();
            switch (status)
            {
                //case "--全部--": inhospital.Status = ""; break;
                case "城乡未登记": inhospital.Ybzt = "WDJ"; break;
                case "城乡已登记": inhospital.Ybzt = "YDJ"; break;
                case "城乡已出院": inhospital.Ybzt = "YCY"; break;
                // case "中途挂账": inhospital.Status = "MSIG"; break;
            }
            if (this.cbx_cyjs_fkfs.Text == "--全部--")
            {
                patienttype = "";
            }
            else
            {
                patienttype = cbx_cyjs_fkfs.SelectedValue.ToString();
            }
            inhospital.Patienttype = patienttype;
            DataTable dt = billIhspcost.ihspSearch1(inhospital);
            this.dataGridView2.DataSource = dt;
            int rowCount = dataGridView2.Rows.Count;
            if (rowCount > 0)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    if (dataGridView2.Rows[i].Cells["bas_patienttype_id"].Value.ToString() == "41")
                    {
                        dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                    else if (dataGridView2.Rows[i].Cells["bas_patienttype_id"].Value.ToString() == "40")
                    {
                        dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Cyan;
                    }
                    else if (dataGridView2.Rows[i].Cells["bas_patienttype_id"].Value.ToString() == "25")
                    {
                        dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                    }
                }
            }
            //for (int i = 0; i < dataGridView2.Rows.Count; i++)
            //{
            //    string displaycolor = dataGridView2.Rows[i].Cells["displaycolor"].Value.ToString();
            //    if (dataGridView2.Rows[i].Cells["displaycolor"].Value.ToString() == "" || dataGridView2.Rows[i].Cells["displaycolor"].Value.ToString() == null)
            //    {
            //        dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.FromName("blue");
            //    }
            //    else
            //    {
            //        dataGridView2.Rows[i].DefaultCellStyle.BackColor = Color.FromName(displaycolor);
            //    }

            //}
            this.lbl_jsrs.Text = this.dataGridView1.Rows.Count.ToString().Trim();
        }
        /// <summary>
        /// 查询方法
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hspcard"></param>
        public void seachMethod()
        {
            string name = this.textBoxrydjxm.Text.Trim().ToString();
            string ihspcode = this.textBoxrydjzyh.Text.Trim().ToString();
            string depart = "";
            if (cmbKeshi.Text.Trim() == "--全部--")
            {
                depart = "";
            }
            else
            {
                depart = this.cmbKeshi.Text.Trim().ToString();
            }
            string startTime = this.kssj.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string endTime = this.jssj.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            string hspcard = "";
            string status = this.cbx_ybzt.Text.Trim().ToString();
            switch (status)
            {
                //case "--全部--": inhospital.Status = ""; break;
                case "城乡未登记": inhospital.Ybzt = "WDJ"; break;
                case "城乡已登记": inhospital.Ybzt = "YDJ"; break;
                case "城乡已出院": inhospital.Ybzt = "YCY"; break;
                
                // case "中途挂账": inhospital.Status = "MSIG"; break;
            }

            System.Data.DataTable dataTable = billIhspMan.manSearch1(name, ihspcode, hspcard, depart, startTime, endTime, status, inhospital);
            this.dataGridView1.DataSource = dataTable;
            int rowCount = dataGridView1.Rows.Count;
            if (rowCount > 0)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells["bas_patienttype_id"].Value.ToString() == "41")
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                    else if (dataGridView1.Rows[i].Cells["bas_patienttype_id"].Value.ToString() == "40")
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Cyan;
                    }
                    else if (dataGridView1.Rows[i].Cells["bas_patienttype_id"].Value.ToString() == "25")
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                    }
                }
            }
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    string displaycolor = dataGridView1.Rows[i].Cells["displaycolor"].Value.ToString();
            //    if (dataGridView1.Rows[i].Cells["displaycolor"].Value.ToString() == "" || dataGridView1.Rows[i].Cells["displaycolor"].Value.ToString() == null)
            //    {
            //        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.FromName("red");
            //    }
            //    else
            //    {
            //        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.FromName(displaycolor);
            //    }

            //}
            this.lbl_ryrs.Text = this.dataGridView1.Rows.Count.ToString().Trim();

        }
        /// <summary>
        /// 住院状态初始化
        /// </summary>
        public void initzyzt()
        {
                List<ListItem> items = new List<ListItem>();
                items.Add(new ListItem("0", "城乡未登记"));
                items.Add(new ListItem("1101", "城乡已登记"));
                items.Add(new ListItem("1102", "城乡已出院"));

                cbx_ybzt.DisplayMember = "Text";
                cbx_ybzt.ValueMember = "Value";
                cbx_ybzt.DataSource = items;
                cbx_ybzt.SelectedValue = "0";

                List<ListItem> items1 = new List<ListItem>();
                items1.Add(new ListItem("0", "城乡未登记"));
                items1.Add(new ListItem("1101", "城乡已登记"));
                items1.Add(new ListItem("1102", "城乡已出院"));

                cbx_cyjs_zyzt.DisplayMember = "Text";
                cbx_cyjs_zyzt.ValueMember = "Value";
                cbx_cyjs_zyzt.DataSource = items1;
                cbx_cyjs_zyzt.SelectedValue = "1101";
            
        }
        ///// <summary>
        ///// 结算datagridview添加按钮列
        ///// </summary>
        //public void initdataGridView()
        //{
        //    //添加按钮
        //    DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
        //    btnEdit.Name = "btnEdit";
        //    btnEdit.HeaderText = "取消挂账";
        //    btnEdit.Text = "取消挂账";
        //    btnEdit.InheritedStyle.NullValue = "取消挂账";
        //    btnEdit.Width = 80;
        //    btnEdit.UseColumnTextForButtonValue = true;
        //    btnEdit.Frozen = true;
        //    dgv_cyjs_cx.Columns.Insert(0, btnEdit);
        //}

        private void initcyfkfs()
        {
            System.Data.DataTable dtPayType = billCmbList.payPaytypeList();
            if (dtPayType.Rows.Count > 0)
            {
                this.cbx_cyjs_fkfs.ValueMember = "id";
                this.cbx_cyjs_fkfs.DisplayMember = "name";
                this.cbx_cyjs_fkfs.DataSource = dtPayType;
                this.cbx_cyjs_fkfs.SelectedValue = 1;
            }
        }
        /// <summary>
        /// 医保类别自费转医保
        /// </summary>
        //public void initzfzyb()
        //{
        //    string tj = "1,2,3";
        //    if (this.chState.Equals("1") || this.qchState.Equals("1"))
        //    {
        //        tj = "2";
        //    }
        //    else if (this.ybState.Equals("1") || this.qybState.Equals("1"))
        //    {
        //        tj = "1,3";
        //    }
        //    DataTable zfzyb = jsselect.Zfzyb_yllbinit(tj);
        //    cbxjs_zfzyb.DataSource = zfzyb;
        //    cbxjs_zfzyb.ValueMember = "iid";
        //    cbxjs_zfzyb.DisplayMember = "name";
        //}

        /// <summary>
        /// 初始化性别
        /// </summary>
        private void InitXb()
        {
            System.Data.DataTable dts = billCmbList.sexList();
            if (dts.Rows.Count > 0)
            {
                this.comboBoxrydjxb.ValueMember = "id";
                this.comboBoxrydjxb.DisplayMember = "name";
                this.comboBoxrydjxb.DataSource = dts;
            }
            
        }
        /// <summary>
        /// 科室初始化
        /// </summary>
        private void ksinit()
        {
             System.Data.DataTable dtde = billCmbList.ihspDepart(cmbKeshi.Text.Trim());
            if (dtde.Rows.Count > 0)
            {
                this.cmbKeshi.ValueMember = "id";
                this.cmbKeshi.DisplayMember = "name";
                this.cbx_jsks.ValueMember = "id";
                this.cbx_jsks.DisplayMember = "name";
                var dr = dtde.NewRow();
                dr["id"] = 0;
                dr["name"] = "--全部--";
                dtde.Rows.InsertAt(dr, 0);
                this.cmbKeshi.DataSource = dtde;
                this.cbx_jsks.DataSource = dtde;
            }


        }
        /// <summary>
        /// 付款方式
        /// </summary>
        private void Bind()
        {
            System.Data.DataTable dtPayType = billCmbList.payPaytypeList();
            if (dtPayType.Rows.Count > 0)
            {
                this.comboBoxylfkfs.ValueMember = "id";
                this.comboBoxylfkfs.DisplayMember = "name";
                this.comboBoxylfkfs.DataSource = dtPayType;
                this.comboBoxylfkfs.SelectedValue = 1;
            }
        }
        /// <summary>
        /// 权限配置
        /// </summary>
        //private void setYbChBtnState()
        //{
        //    this.chState = Ini.IniReadValue2("MTCLIENT", "chState");
        //    this.ybState = Ini.IniReadValue2("MTCLIENT", "ybState");
        //    //this.zyState = Ini.IniReadValue2("MTCLIENT", "zyState");
        //    this.qybState = Ini.IniReadValue2("MTCLIENT", "qybState");
        //    this.qchState = Ini.IniReadValue2("MTCLIENT", "qchState");
        //    if (this.chState.Equals("1") || this.ybState.Equals("1") || this.qybState.Equals("1") || this.qchState.Equals("1"))
        //    {
        //        this.btn_cdjsd.Visible = true;
        //        this.btn_YbChScfy.Visible = true;
        //        this.but_ck.Visible = true;
        //    }
        //    else
        //    {
        //        this.btn_cdjsd.Visible = false;
        //        this.btn_YbChScfy.Visible = false;
        //        this.but_ck.Visible = false;
        //    }
        //    if (this.isxjhb.Equals("1"))
        //    {
        //        this.btn_ryht.Visible = false;
        //        this.btn_ry.Visible = false;
        //        this.btn_db.Visible = false;
        //        this.button8.Visible = false;
        //        this.button3.Visible = false;
        //    }
        //    else
        //    {
        //        this.btn_ryht.Visible = true;
        //        this.btn_ry.Visible = true;
        //        this.btn_db.Visible = true;
        //        this.button8.Visible = true;
        //        this.button3.Visible = true;
        //    }
        //}
        

        private void setTime()
        {
            this.kssj.Value = DateTime.Parse(DateTime.Now.ToString("yyyy") + "-01-01 00:00:01").AddYears(-1);
            this.cyjs_Starttime.Value = DateTime.Parse(DateTime.Now.ToString("yyyy") + "-01-01 00:00:01").AddYears(-1);
        }

        private void btn_ryht_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0 && dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            FrmRyht frmOuthospital = new FrmRyht();
            string id = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
            //frmOuthospital.getOutSource(id);
            frmOuthospital.Id = id;
            frmOuthospital.Xm = dataGridView1.SelectedRows[0].Cells["ihspname"].Value.ToString();
            frmOuthospital.Zyh = dataGridView1.SelectedRows[0].Cells["ihspcode"].Value.ToString();
            frmOuthospital.ShowDialog();
            seachMethod();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0 && dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            FrmIhspPay frmIhspPay = new FrmIhspPay();
            string id = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
            frmIhspPay.getManSource(id);
            frmIhspPay.ShowDialog();
        }

        private void btn_db_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0 && dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            FrmIhspGua frmIhspGua = new FrmIhspGua();
            string id = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
            frmIhspGua.getSource(id);
            frmIhspGua.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            if (cbxjs_zfzyb.SelectedValue == null)
            {
                MessageBox.Show("请选择正确的类型");
                return;
            }
            int rowIdx = dataGridView1.CurrentRow.Index;
            if (rowIdx < 0)
            {
                MessageBox.Show("请选择患者");
                return;
            }
            string id = dataGridView1.Rows[rowIdx].Cells["id"].Value.ToString();
            string patienttypeId = cbxjs_zfzyb.SelectedValue.ToString();
            string keyname = billIhspMan.getInsurtype(patienttypeId);

            if (button5.Text == "转自费")
            {
                string sql1 = "select sfck,qfybch from inhospital where id=" + id;
                System.Data.DataTable dt1 = BllMain.Db.Select(sql1).Tables[0];

                if (dt1.Rows[0]["qfybch"].ToString().Trim() != "0")
                {
                    FrmRyHt ryht = new FrmRyHt();
                    string zyh = dataGridView1.Rows[rowIdx].Cells["ihspcode"].Value.ToString();
                    string sql = "select insurcode,qfybch  from inhospital where ihspcode='" + zyh + "'";
                    System.Data.DataTable dt = BllMain.Db.Select(sql).Tables[0];
                    ryht.Zyh = zyh;
                    ryht.Xm = dataGridView1.Rows[rowIdx].Cells["ihspname"].Value.ToString();
                    ryht.Grbh = dt.Rows[0]["insurcode"].ToString().Trim();
                    ryht.Ylfkfs_id = (dt.Rows[0]["qfybch"].ToString().Trim() == "1") ? ("职工医保") : ("城乡居民");
                    ryht.Zyjlh = id;
                    ryht.Sfck = int.Parse(dt1.Rows[0]["sfck"].ToString());
                    ryht.IQfybch = dt.Rows[0]["qfybch"].ToString().Trim();
                    ryht.StartPosition = FormStartPosition.CenterScreen;
                    ryht.ShowDialog(this);
                }
            }
            else if (button5.Text == "转医保城乡")
            {
                string sql_yllb = "select nhflag from inhospital where id=" + id;
                System.Data.DataTable dt = BllMain.Db.Select(sql_yllb).Tables[0];
                if (dt.Rows[0]["nhflag"].ToString().Trim() == "0")
                {
                    string sql_ssn = "select ihsp_info.homephone as lxfs,ihsp_info.profession as ryzy,ihsp_info.homeaddress as rydz,ihsp_info.idcard as ssn,inhospital.age as age,inhospital.clinicdiagn as mzzd,inhospital.ihspdiagn as zyzd from inhospital,ihsp_info where inhospital.id=ihsp_info.ihsp_id and ihsp_info.registkind = 'IHSP' and inhospital.id=" + id;
                    var ds = BllMain.Db.Select(sql_ssn);
                    string ssn = "";
                    if (ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
                    {
                        ssn = ds.Tables[0].Rows[0]["ssn"].ToString().Trim();
                    }

                    //if (ProgramGlobal.Ybcjbz == "1")
                    //{
                    if (keyname == CostInsurtypeKeyname.HDSYB.ToString())
                    {
                        FrmYbRy ybry = new FrmYbRy();
                        ybry.Zfrydj.Zyh = dataGridView1.Rows[rowIdx].Cells["ihspcode"].Value.ToString();//住院号
                        ybry.Zfrydj.Brxm = dataGridView1.Rows[rowIdx].Cells["ihspname"].Value.ToString();//姓名
                        ybry.Zfrydj.Bch = dataGridView1.Rows[rowIdx].Cells["sickbedname"].Value.ToString();//病床号
                        ybry.Zfrydj.Bfh = dataGridView1.Rows[rowIdx].Cells["sickroomname"].Value.ToString();//病房号
                        ybry.Zfrydj.Ysname = dataGridView1.Rows[rowIdx].Cells["doctorname"].Value.ToString();//医生名字
                        ybry.Zfrydj.Ryks = dataGridView1.Rows[rowIdx].Cells["departname"].Value.ToString();//科室
                        ybry.Zfrydj.Rysj = dataGridView1.Rows[rowIdx].Cells["indate"].Value.ToString();//入院时间
                        ybry.Zfrydj.Brsfzh = ds.Tables[0].Rows[0]["ssn"].ToString().Trim();//身份证号
                        ybry.Zyjlh = id;
                        ybry.Ylfkfs_id = patienttypeId;
                        ybry.Zfrydj.Brnl = ds.Tables[0].Rows[0]["age"].ToString().Trim();//病人年龄
                        ybry.Zfrydj.Ctctprof = ds.Tables[0].Rows[0]["ryzy"].ToString().Trim();//职业
                        ybry.Zfrydj.MTel = ds.Tables[0].Rows[0]["lxfs"].ToString().Trim();//联系方式
                        ybry.Zfrydj.Brdz = ds.Tables[0].Rows[0]["rydz"].ToString().Trim();//地址
                        ybry.Zfrydj.Mzryzd = ds.Tables[0].Rows[0]["mzzd"].ToString().Trim();//门诊诊断
                        ybry.Zfrydj.Zyryzd = ds.Tables[0].Rows[0]["zyzd"].ToString().Trim();//住院诊断
                        ybry.StartPosition = FormStartPosition.CenterScreen;
                        ybry.ShowDialog(this);
                    }
                    if (keyname == CostInsurtypeKeyname.HDSCH.ToString())
                    {
                        FrmChRy chry = new FrmChRy();
                        chry.Zfrydj.Zyh = dataGridView1.Rows[rowIdx].Cells["ihspcode"].Value.ToString();//住院号
                        chry.Zfrydj.Brxm = dataGridView1.Rows[rowIdx].Cells["ihspname"].Value.ToString();//姓名
                        chry.Zfrydj.Bch = dataGridView1.Rows[rowIdx].Cells["sickbedname"].Value.ToString();//病床号
                        chry.Zfrydj.Bfh = dataGridView1.Rows[rowIdx].Cells["sickroomname"].Value.ToString();//病房号
                        chry.Zfrydj.Ysname = dataGridView1.Rows[rowIdx].Cells["doctorname"].Value.ToString();//医生名字
                        chry.Zfrydj.Ryks = dataGridView1.Rows[rowIdx].Cells["departname"].Value.ToString();//科室
                        chry.Zfrydj.Rysj = dataGridView1.Rows[rowIdx].Cells["indate"].Value.ToString();//入院时间
                        chry.Zfrydj.Brsfzh = ds.Tables[0].Rows[0]["ssn"].ToString().Trim();//身份证号
                        chry.Zyjlh = id;
                        chry.Ylfkfs_id = patienttypeId;
                        chry.Zfrydj.Brnl = ds.Tables[0].Rows[0]["age"].ToString().Trim();//病人年龄
                        chry.Zfrydj.Ctctprof = ds.Tables[0].Rows[0]["ryzy"].ToString().Trim();//职业
                        chry.Zfrydj.MTel = ds.Tables[0].Rows[0]["lxfs"].ToString().Trim();//联系方式
                        chry.Zfrydj.Brdz = ds.Tables[0].Rows[0]["rydz"].ToString().Trim();//地址
                        chry.Zfrydj.Mzryzd = ds.Tables[0].Rows[0]["mzzd"].ToString().Trim();//门诊诊断
                        chry.Zfrydj.Zyryzd = ds.Tables[0].Rows[0]["zyzd"].ToString().Trim();//住院诊断
                        chry.StartPosition = FormStartPosition.CenterScreen;
                        chry.ShowDialog(this);
                    }
                    if (keyname == CostInsurtypeKeyname.HDSSY.ToString())
                    {
                        FormSyRy syry = new FormSyRy();
                        syry.Zfrydj.Zyh = dataGridView1.Rows[rowIdx].Cells["ihspcode"].Value.ToString();//住院号
                        syry.Zfrydj.Brxm = dataGridView1.Rows[rowIdx].Cells["ihspname"].Value.ToString();//姓名
                        syry.Zfrydj.Bch = dataGridView1.Rows[rowIdx].Cells["sickbedname"].Value.ToString();//病床号
                        syry.Zfrydj.Bfh = dataGridView1.Rows[rowIdx].Cells["sickroomname"].Value.ToString();//病房号
                        syry.Zfrydj.Ysname = dataGridView1.Rows[rowIdx].Cells["doctorname"].Value.ToString();//医生名字
                        syry.Zfrydj.Ryks = dataGridView1.Rows[rowIdx].Cells["departname"].Value.ToString();//科室
                        syry.Zfrydj.Rysj = dataGridView1.Rows[rowIdx].Cells["indate"].Value.ToString();//入院时间
                        syry.Zfrydj.Brsfzh = ds.Tables[0].Rows[0]["ssn"].ToString().Trim();//身份证号
                        syry.Zyjlh = id;
                        syry.Ylfkfs_id = patienttypeId;
                        syry.Zfrydj.Brnl = ds.Tables[0].Rows[0]["age"].ToString().Trim();//病人年龄
                        syry.Zfrydj.Ctctprof = ds.Tables[0].Rows[0]["ryzy"].ToString().Trim();//职业
                        syry.Zfrydj.MTel = ds.Tables[0].Rows[0]["lxfs"].ToString().Trim();//联系方式
                        syry.Zfrydj.Brdz = ds.Tables[0].Rows[0]["rydz"].ToString().Trim();//地址
                        syry.Zfrydj.Mzryzd = ds.Tables[0].Rows[0]["mzzd"].ToString().Trim();//门诊诊断
                        syry.Zfrydj.Zyryzd = ds.Tables[0].Rows[0]["zyzd"].ToString().Trim();//住院诊断
                        syry.StartPosition = FormStartPosition.CenterScreen;
                        syry.ShowDialog(this);
                    }
                    //}

                }
                else
                { return; }
            }
            seachMethod();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cyjscx();
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count != 0 && dataGridView2.SelectedCells.Count != 0)
            {
                string ihsp_account_id = dataGridView2.SelectedRows[0].Cells["ihsp_account_id"].Value.ToString();
                string id = dataGridView2.SelectedRows[0].Cells["id"].Value.ToString();
                DataTable datatable = null;
                if (DataTool.stringToInt(ihsp_account_id) <= 0)
                {
                    
                    datatable = billIhspcost.costSearch(id);
                }
                else
                {
                    
                    datatable = billIhspcost.costSearchBySettle(ihsp_account_id);
                }
                this.lbl_xm.Text = dataGridView2.SelectedRows[0].Cells["ihspname"].Value.ToString();
                this.lbl_zyh.Text = dataGridView2.SelectedRows[0].Cells["ihspcode"].Value.ToString();
                this.dataGridView3.DataSource = datatable;
                #region  dgvIhspCost单元格标题设置
                dataGridView3.Font = new System.Drawing.Font("宋体", (float)(11 * ProgramGlobal.WidthScale));
                dataGridView3.RowsDefaultCellStyle.Font = new System.Drawing.Font("宋体", (float)(11 * ProgramGlobal.WidthScale));
                this.dataGridView3.Columns["item_id"].HeaderText = "编号";
                this.dataGridView3.Columns["item_id"].Width = (int)(50 * ProgramGlobal.WidthScale);
                this.dataGridView3.Columns["itemtypename"].HeaderText = "项目类别";
                this.dataGridView3.Columns["itemtypename"].Width = (int)(100 * ProgramGlobal.WidthScale);
                this.dataGridView3.Columns["name"].HeaderText = "名称";
                this.dataGridView3.Columns["name"].Width = (int)(180 * ProgramGlobal.WidthScale);
                this.dataGridView3.Columns["spec"].HeaderText = "规格";
                this.dataGridView3.Columns["spec"].Width = (int)(110 * ProgramGlobal.WidthScale);
                this.dataGridView3.Columns["unit"].HeaderText = "单位";
                this.dataGridView3.Columns["unit"].Width = (int)(50 * ProgramGlobal.WidthScale);
                this.dataGridView3.Columns["prc"].HeaderText = "单价";
                this.dataGridView3.Columns["prc"].Width = (int)(100 * ProgramGlobal.WidthScale);
                this.dataGridView3.Columns["prc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView3.Columns["num"].HeaderText = "数量";
                this.dataGridView3.Columns["num"].Width = (int)(100 * ProgramGlobal.WidthScale);
                this.dataGridView3.Columns["num"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView3.Columns["insurefee"].HeaderText = "报销金额";
                this.dataGridView3.Columns["insurefee"].Width = (int)(100 * ProgramGlobal.WidthScale);
                this.dataGridView3.Columns["insurefee"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView3.Columns["selffee"].HeaderText = "自费金额";
                this.dataGridView3.Columns["selffee"].Width = (int)(100 * ProgramGlobal.WidthScale);
                this.dataGridView3.Columns["selffee"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dataGridView3.Columns["departname"].HeaderText = "项目科室";
                this.dataGridView3.Columns["departname"].Width = (int)(100 * ProgramGlobal.WidthScale);
                this.dataGridView3.Columns["insurclass"].HeaderText = "医保等级";
                this.dataGridView3.Columns["insurclass"].Width = (int)(100 * ProgramGlobal.WidthScale);
                this.dataGridView3.Columns["realfee"].HeaderText = "实际金额";
                this.dataGridView3.Columns["realfee"].Visible = false;
                this.dataGridView3.Columns["fee"].HeaderText = "金额";
                this.dataGridView3.Columns["fee"].Visible = false;
                #endregion
                

            }
            else
            {
                dataGridView3.DataSource = null;
            }
        }

        private void but_fyqd_Click(object sender, EventArgs e)
        {
            string ihsp_id = "";

            if (dataGridView2.Rows.Count != 0)
            {
                ihsp_id = dataGridView2.SelectedRows[0].Cells["id"].Value.ToString();
                string ihsp_account_id = dataGridView2.SelectedRows[0].Cells["ihsp_account_id"].Value.ToString();

                FrxPrintView frxPrintView = new FrxPrintView();
                frxPrintView.costdetPrt(ihsp_id, ihsp_account_id);
            }   
        }

        private void but_ck_Click(object sender, EventArgs e)
        {
            BllInsur bllInsur = new BllInsur();
            if (dataGridView2.SelectedRows.Count == 0 && dataGridView2.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            int rowIdx = dataGridView2.CurrentRow.Index;
            string id = dataGridView2.SelectedRows[0].Cells["id"].Value.ToString();
            string patienttype_id = dataGridView2.SelectedRows[0].Cells["bas_patienttype_id"].Value.ToString();
            string keyname = bllInsur.getInsurtype(patienttype_id);
            if (keyname == CostInsurtypeKeyname.HDSCH.ToString())//邯郸城合
            {
                FrmChCy chcy = new FrmChCy();
                chcy.Ihsp_id = id;
                chcy.Zyh_ = dataGridView2.Rows[rowIdx].Cells["ihspcode"].Value.ToString().Trim();
                chcy.Ylkfkfs = patienttype_id;
                chcy.ShowDialog();
                if (chcy.DialogResult == DialogResult.Cancel)
                {
                    cyjscx();
                }
            }
            else if (keyname == CostInsurtypeKeyname.HDSYB.ToString())//邯郸医保
            {
                FrmYbCy chcy = new FrmYbCy();
                chcy.Ihsp_id = id;
                chcy.Zyh_ = dataGridView2.Rows[rowIdx].Cells["ihspcode"].Value.ToString().Trim();
                chcy.Ylkfkfs = patienttype_id;
                chcy.ShowDialog();
                if (chcy.DialogResult == DialogResult.Cancel)
                {
                    cyjscx();
                }
            }
            else if (keyname == CostInsurtypeKeyname.HDSSY.ToString())//邯郸生育
            {
                FrmSyCy sycy = new FrmSyCy();
                sycy.Ihsp_id = id;
                sycy.Zyh_ = dataGridView2.Rows[rowIdx].Cells["ihspcode"].Value.ToString().Trim();
                sycy.Ylkfkfs = patienttype_id;
                sycy.ShowDialog();
                if (sycy.DialogResult == DialogResult.Cancel)
                {
                    cyjscx();
                }
            }
        }

        private void btn_cyjs_Click(object sender, EventArgs e)
        {
            BllInsur bllInsur = new BllInsur();
            if (dataGridView2.SelectedRows.Count == 0 && dataGridView2.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            int rowIdx = dataGridView2.CurrentRow.Index;
            string id = dataGridView2.SelectedRows[0].Cells["id"].Value.ToString();
            string patienttype_id = dataGridView2.SelectedRows[0].Cells["bas_patienttype_id"].Value.ToString();
            string keyname = bllInsur.getInsurtype(patienttype_id);
            if (keyname == CostInsurtypeKeyname.HDSCH.ToString())//邯郸城合
            {
                MTHIS.FrmMain fm = new MTHIS.FrmMain();
                if (fm.ybsyqx() != true)
                {
                    return;
                }
                FrmChCy chcy = new FrmChCy();
                chcy.Ihsp_id = id;
                chcy.Zyh_ = dataGridView2.Rows[rowIdx].Cells["ihspcode"].Value.ToString().Trim();
                chcy.Ylkfkfs = patienttype_id;
                chcy.ShowDialog();
                if (chcy.DialogResult == DialogResult.Cancel)
                {
                    cyjscx();
                }
            }
            else if (keyname == CostInsurtypeKeyname.HDSYB.ToString())//邯郸医保
            {
                MTHIS.FrmMain fm = new MTHIS.FrmMain();
                if (fm.ybsyqx() != true)
                {
                    return;
                }
                FrmYbCy chcy = new FrmYbCy();
                chcy.Ihsp_id = id;
                chcy.Zyh_ = dataGridView2.Rows[rowIdx].Cells["ihspcode"].Value.ToString().Trim();
                chcy.Ylkfkfs = patienttype_id;
                chcy.ShowDialog();
                if (chcy.DialogResult == DialogResult.Cancel)
                {
                    cyjscx();
                }
            }
            else if (keyname == CostInsurtypeKeyname.HDSSY.ToString())//邯郸生育
            {
                MTHIS.FrmMain fm = new MTHIS.FrmMain();
                if (fm.ybsyqx() != true)
                {
                    return;
                }
                FrmSyCy sycy = new FrmSyCy();
                sycy.Ihsp_id = id;
                sycy.Zyh_ = dataGridView2.Rows[rowIdx].Cells["ihspcode"].Value.ToString().Trim();
                sycy.Ylkfkfs = patienttype_id;
                sycy.ShowDialog();
                if (sycy.DialogResult == DialogResult.Cancel)
                {
                    cyjscx();
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0 && dataGridView2.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            FrmIhspRpt frmRePrint = new FrmIhspRpt();
            string id = dataGridView2.SelectedRows[0].Cells["id"].Value.ToString();
            string sql = "select insurcode,ihspcode,nhflag from inhospital where id=" + id;
            System.Data.DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows[0]["nhflag"].ToString() == "0" || dt.Rows[0]["nhflag"].ToString() == "1101")
            {
                string ihsp_account_id = dataGridView2.SelectedRows[0].Cells["ihsp_account_id"].Value.ToString();
                frmRePrint.getSouse(id, ihsp_account_id);
                frmRePrint.ShowDialog();
            }
            else if (dt.Rows[0]["nhflag"].ToString() == "302")
            {
                FrmYbCy ybcy = new FrmYbCy();
                string code = dt.Rows[0]["ihspcode"].ToString();
                string grbh = dt.Rows[0]["insurcode"].ToString();
                ybcy.dyfp(grbh, code, id);
            }
            else if (dt.Rows[0]["nhflag"].ToString() == "1102")
            {
                FrmChCy ybcy = new FrmChCy();
                string code = dt.Rows[0]["ihspcode"].ToString();
                string grbh = dt.Rows[0]["insurcode"].ToString();
                ybcy.dyfp(grbh, code, id);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0 && dataGridView2.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            string id = dataGridView2.SelectedRows[0].Cells["id"].Value.ToString();
            string ihsp_account_id = dataGridView2.SelectedRows[0].Cells["ihsp_account_id"].Value.ToString();
            string patienttype_id = dataGridView2.SelectedRows[0].Cells["bas_patienttype_id"].Value.ToString();
            string neonate = dataGridView2.SelectedRows[0].Cells["neonate"].Value.ToString();
            string zyhTmp = dataGridView2.SelectedRows[0].Cells["ihspcode"].Value.ToString();
            string sqlTmp = "select yllb,insurcode,nhflag from inhospital where  id = " + id + " and ihspcode = '" + zyhTmp + "'";
            var dsTmp = BllMain.Db.Select(sqlTmp);
            BllInsur bllInsur = new BllInsur();
            string keyname = bllInsur.getInsurtype(patienttype_id);
            if (Ini.IniReadValue2("pz", "ISXJHB") == "1")
            {
                string nhflag = dsTmp.Tables[0].Rows[0]["nhflag"].ToString().Trim();
                if (nhflag != "1101" && nhflag != "0")
                {
                    MessageBox.Show("提示", "医保未回退，若要进行请先医保回退！");
                    return;
                }
                FrmRetAccount frmRetAccount = new FrmRetAccount();
                frmRetAccount.getSource(id, ihsp_account_id);
                frmRetAccount.ShowDialog();

                if (frmRetAccount.DialogResult == DialogResult.OK)
                {
                    cyjscx();
                }
            }
            if (neonate.Equals("Y"))
            {
                FrmRetAccount frmRetAccount = new FrmRetAccount();
                frmRetAccount.getSource(id, ihsp_account_id);
                frmRetAccount.ShowDialog();
                if (frmRetAccount.DialogResult == DialogResult.OK)
                {
                    cyjscx();
                }
            }
            else if (keyname == CostInsurtypeKeyname.HDSYB.ToString())//邯郸市医保
            {
                MTHIS.FrmMain fm = new MTHIS.FrmMain();
                if (fm.ybsyqx() != true)
                {
                    return;
                }
                string yllbTmp = dsTmp.Tables[0].Rows[0]["yllb"].ToString().Trim();
                string grbhTmp = dsTmp.Tables[0].Rows[0]["insurcode"].ToString().Trim();
                FrmYbCy chcy = new FrmYbCy();
                chcy.Account = ihsp_account_id;
                chcy.js_ht(zyhTmp, yllbTmp, id, grbhTmp);
            }
        }

        private void cbx_ybzt_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cbx_ybzt_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                string tmp = cbx_ybzt.Text.Trim();
                if (tmp == "" || tmp == "System.Data.DataRowView")
                {
                    return;
                }
                if (cbx_ybzt.SelectedValue.ToString() == "0")
                {
                    btn_ryht.Enabled = false;
                    button5.Enabled = true;
                    cbxjs_zfzyb.Enabled = true;
                }
                else if (cbx_ybzt.SelectedValue.ToString() == "301" || cbx_ybzt.SelectedValue.ToString() == "1101" || cbx_ybzt.SelectedValue.ToString() == "1501")
                {
                    btn_ryht.Enabled = true;
                    button5.Enabled = false;
                    cbxjs_zfzyb.Enabled = false;
                }
                else if (cbx_ybzt.SelectedValue.ToString() == "302" || cbx_ybzt.SelectedValue.ToString() == "1102" || cbx_ybzt.SelectedValue.ToString() == "1502")
                {
                    btn_ryht.Enabled = true;
                    button5.Enabled = false;
                    cbxjs_zfzyb.Enabled = false;
                }
                
            }
            catch
            { }
        }

        private void cbx_cyjs_zyzt_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                string tmp = cbx_cyjs_zyzt.Text.Trim();
                if (tmp == "" || tmp == "System.Data.DataRowView")
                {
                    return;
                }
                if (cbx_cyjs_zyzt.SelectedValue.ToString() == "0")
                {
                    but_nzjsfyqd.Enabled = true;
                    but_fyqd.Enabled = true;
                    but_ck.Enabled = true;
                    btn_cyjs.Enabled = false;
                    button12.Enabled = false;
                    btn_cdjsd.Enabled = false;
                    ztjz_button.Enabled = false;
                    but_scztjz.Enabled = false;
                    button16.Enabled = false;
                    btn_YbChScfy.Enabled = false;
                }
                else if (cbx_cyjs_zyzt.SelectedValue.ToString() == "301" || cbx_cyjs_zyzt.SelectedValue.ToString() == "1101" || cbx_cyjs_zyzt.SelectedValue.ToString() == "1501")
                {
                    but_nzjsfyqd.Enabled = true;
                    but_fyqd.Enabled = true;
                    but_ck.Enabled = true;
                    btn_cyjs.Enabled = true;
                    button12.Enabled = false;
                    btn_cdjsd.Enabled = false;
                    ztjz_button.Enabled = true;
                    but_scztjz.Enabled = true;
                    button16.Enabled = false;
                    btn_YbChScfy.Enabled = true;
                }
                else if (cbx_cyjs_zyzt.SelectedValue.ToString() == "302" || cbx_cyjs_zyzt.SelectedValue.ToString() == "1102" || cbx_cyjs_zyzt.SelectedValue.ToString() == "1502")
                {
                    but_nzjsfyqd.Enabled = true;
                    but_fyqd.Enabled = true;
                    but_ck.Enabled = true;
                    btn_cyjs.Enabled = true;
                    button12.Enabled = true;
                    btn_cdjsd.Enabled = true;
                    ztjz_button.Enabled = false;
                    but_scztjz.Enabled = false;
                    button16.Enabled = true;
                    btn_YbChScfy.Enabled = false;
                }
                
            }
            catch
            { }
            cyjscx();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            
        }

        private void btn_cdjsd_Click(object sender, EventArgs e)
        {
            string ihsp_id = dataGridView2.SelectedRows[0].Cells["id"].Value.ToString();
            string code = dataGridView2.SelectedRows[0].Cells["ihspcode"].Value.ToString();
            string sql = "select insurcode from  inhospital where id =" + DataTool.addFieldBraces(ihsp_id);
           DataTable dt =  BllMain.Db.Select(sql).Tables[0];
           string grbh = dt.Rows[0]["insurcode"].ToString();
            jsdcd(code, "",ihsp_id, grbh);
        }
        public void jsdcd(string strZyh, string strYllb, string strZyjlId, string strGrbh)
        {
            #region
            if (string.IsNullOrEmpty(strGrbh) || string.IsNullOrEmpty(strZyh) || string.IsNullOrEmpty(strZyjlId))
            {
                MessageBox.Show("发票参数获取失败!");
                return;
            }
            //结算打印
            YBCJ_IN yw_in_zyjsddy = new YBCJ_IN();
            yw_in_zyjsddy.Yw = "BB310003";
            yw_in_zyjsddy.Ybcjbz = "1";
            string sql_gxsfck = "select yllb,sfck,nhflag from inhospital where id='" + strZyjlId + "'";
            DataSet ds_sfck = BllMain.Db.Select(sql_gxsfck);
            if (ds_sfck.Tables[0].Rows[0]["sfck"].ToString().Trim() == "1")
            {
                yw_in_zyjsddy.Ylzh = "0";
            }
            else
            {
                yw_in_zyjsddy.Ylzh = strGrbh;
            }
            string sql_cxybfph = "select fph,jssj from zlsyb_zyinfo where mzzyjliid=" + strZyjlId + ";";
            DataSet ds_ybfph = BllMain.Db.Select(sql_cxybfph);
            if (ds_ybfph.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("没有在‘zlsyb_zyinfo’表里找到此人结算信息！", "提示信息");
                return;
            }
            yw_in_zyjsddy.Hisjl = strZyh;
            yw_in_zyjsddy.Rc = strGrbh + "|" + strZyh + "|" + ds_ybfph.Tables[0].Rows[0]["fph"].ToString().Trim() + "|" + ProgramGlobal.Username;
            int opt_zyjsddy = yw1.ybcjhs(yw_in_zyjsddy);
            if (opt_zyjsddy != 0)
            {
                MessageBox.Show(yw_in_zyjsddy.Mesg, "提示信息");
                return;
            }
            string sql_insert_zyjsdy = "update zlsyb_zyinfo set zyjsdyzfc='" + yw_in_zyjsddy.Cc + "' where mzzyjliid='" + strZyjlId + "'";
            BllMain.Db.Update(sql_insert_zyjsdy);
            string[] zyjsddy_cc = yw_in_zyjsddy.Cc.Split('|');
            string in_zfc1 = "|";
            in_zfc1 += "邯郸市城乡居民医疗保险费用结算单（定点医院使用）|";

            in_zfc1 += "医疗机构:|" + zyjsddy_cc[3] + "|";
            in_zfc1 += "医院住院号:" + zyjsddy_cc[1] + "|";
            in_zfc1 += "入院日期:" + zyjsddy_cc[8].Substring(0, 4) + "-" + zyjsddy_cc[8].Substring(4, 2) + "-" + zyjsddy_cc[8].Substring(6, 2) + "|";
            in_zfc1 += "出院日期:" + zyjsddy_cc[9].Substring(0, 4) + "-" + zyjsddy_cc[9].Substring(4, 2) + "-" + zyjsddy_cc[9].Substring(6, 2) + "|";
            in_zfc1 += "个人编号:" + zyjsddy_cc[11] + "|";
            in_zfc1 += "姓名:" + zyjsddy_cc[6] + "|";
            in_zfc1 += "住院次数:" + zyjsddy_cc[5] + "|";
            in_zfc1 += "人员类别:" + zyjsddy_cc[13] + "|";

            in_zfc1 += "甲类费用|" + (DataTool.Getdouble(zyjsddy_cc[30]) + DataTool.Getdouble(zyjsddy_cc[31]) + DataTool.Getdouble(zyjsddy_cc[32])).ToString("0.00") + "|";
            in_zfc1 += "乙类费用|" + (DataTool.Getdouble(zyjsddy_cc[33]) + DataTool.Getdouble(zyjsddy_cc[34])).ToString("0.00") + "|";
            in_zfc1 += "自费费用|" + (DataTool.Getdouble(zyjsddy_cc[28]) - DataTool.Getdouble(zyjsddy_cc[30]) - DataTool.Getdouble(zyjsddy_cc[31]) - DataTool.Getdouble(zyjsddy_cc[32]) - DataTool.Getdouble(zyjsddy_cc[33]) - DataTool.Getdouble(zyjsddy_cc[34])).ToString("0.00") + "|";
            in_zfc1 += "标准床位费|" + DataTool.Getdouble(zyjsddy_cc[32]).ToString("0.00") + "|";

            in_zfc1 += "总费用|" + DataTool.Getdouble(zyjsddy_cc[28]).ToString("0.00") + "|";
            in_zfc1 += "其中:中草药的汤剂、饮片|" + DataTool.Getdouble(zyjsddy_cc[78]).ToString("0.00") + "|";
            in_zfc1 += "起付线标准|" + DataTool.Getdouble(zyjsddy_cc[38]).ToString("0.00") + "|";
            in_zfc1 += "累计起付线|" + DataTool.Getdouble(zyjsddy_cc[79]).ToString("0.00") + "|";

            in_zfc1 += "本年历次合规费用|" + DataTool.Getdouble(zyjsddy_cc[80]).ToString("0.00") + "|";
            in_zfc1 += "本年历次统筹支出|" + DataTool.Getdouble(zyjsddy_cc[42]).ToString("0.00") + "|";
            in_zfc1 += "本次合规费用|" + DataTool.Getdouble(zyjsddy_cc[57]).ToString("0.00") + "|";
            in_zfc1 += "本次统筹支付|" + DataTool.Getdouble(zyjsddy_cc[41]).ToString("0.00") + "|";

            in_zfc1 += "本年大病历次合规金额|" + DataTool.Getdouble(zyjsddy_cc[71]).ToString("0.00") + "|";
            in_zfc1 += "本年大病历次支付金额|" + DataTool.Getdouble(zyjsddy_cc[45]).ToString("0.00") + "|";
            in_zfc1 += "本次大病合规金额|" + DataTool.Getdouble(zyjsddy_cc[43]).ToString("0.00") + "|";
            in_zfc1 += "本次大病支付金额|" + DataTool.Getdouble(zyjsddy_cc[44]).ToString("0.00") + "|";

            in_zfc1 += "本年历次住院医疗救助累计|" + DataTool.Getdouble(zyjsddy_cc[81]).ToString("0.00") + "|";
            in_zfc1 += "本次住院医疗救助支付|" + DataTool.Getdouble(zyjsddy_cc[76]).ToString("0.00") + "|";
            in_zfc1 += "本年历次重特大疾病住院医疗救助累计|" + DataTool.Getdouble(zyjsddy_cc[82]).ToString("0.00") + "|";
            in_zfc1 += "本次重特大疾病住院医疗救助支付|" + DataTool.Getdouble(zyjsddy_cc[77]).ToString("0.00") + "|";

            in_zfc1 += "贫困人口提高待遇部分|" + (DataTool.Getdouble(zyjsddy_cc[72]) + DataTool.Getdouble(zyjsddy_cc[73]) + DataTool.Getdouble(zyjsddy_cc[74]) + DataTool.Getdouble(zyjsddy_cc[75])).ToString("0.00") + "|";
            in_zfc1 += "报销支付合计|" + (DataTool.Getdouble(zyjsddy_cc[41]) + DataTool.Getdouble(zyjsddy_cc[44]) + DataTool.Getdouble(zyjsddy_cc[72]) + DataTool.Getdouble(zyjsddy_cc[73]) + DataTool.Getdouble(zyjsddy_cc[74]) + DataTool.Getdouble(zyjsddy_cc[75]) + DataTool.Getdouble(zyjsddy_cc[76]) + DataTool.Getdouble(zyjsddy_cc[77])).ToString("0.00") + "|";
            in_zfc1 += "本次个人现金支付|" + DataTool.Getdouble(zyjsddy_cc[52]).ToString("0.00") + "|";
            in_zfc1 += "其中贫困人口提高待遇部分分项|";

            in_zfc1 += "住院起付线降低提高待遇|" + DataTool.Getdouble(zyjsddy_cc[72]).ToString("0.00") + "|";
            in_zfc1 += "提高住院报销比例提高待遇|" + DataTool.Getdouble(zyjsddy_cc[73]).ToString("0.00") + "|";
            in_zfc1 += "大病保险取消起付线提高待遇|" + DataTool.Getdouble(zyjsddy_cc[74]).ToString("0.00") + "|";
            in_zfc1 += "大病保险提高封顶线提高待遇|" + DataTool.Getdouble(zyjsddy_cc[75]).ToString("0.00") + "|";

            in_zfc1 += "备注提示:" + zyjsddy_cc[83] + "|";
            in_zfc1 += "医保中心名称:" + zyjsddy_cc[0] + "|";
            in_zfc1 += "参保人签字:|";
            in_zfc1 += "经办人:" + zyjsddy_cc[55] + "|";
            in_zfc1 += "经办日期:" + Convert.ToDateTime(DateTime.Now.ToString()).ToString("yyyy-MM-dd");

            FrmDy cxjsddy = new FrmDy();
            cxjsddy.in_zfc = in_zfc1;
            cxjsddy.dy("zycxjsd");
            MessageBox.Show("打印住院结算明细表成功！", "提示信息");
            #endregion
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btn_YbChScfy_Click(object sender, EventArgs e)
        {
            //医保
            //Frm_Ybzxfy frm_ybzxfy = new Frm_Ybzxfy();
            //frm_ybzxfy.ShowDialog();
        }

    }
}
