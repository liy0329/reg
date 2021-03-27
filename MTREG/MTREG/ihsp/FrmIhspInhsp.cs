using System;
using System.Data;
using System.Windows.Forms;
using MTREG.ihsp.bll;
using MTREG.common;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using MTHIS.common;
using System.Drawing;
using MTREG.medinsur.gzsnh;
using MTREG.medinsur.gysyb;
using MTREG.medinsur.gysyb.bo;
using MTHIS.main.bll;
using MTREG.medinsur.gysyb.bll;
//using MTREG.medinsur.gzsyb.ihsp;
//using MTREG.medinsur.gzsyb.ihsp.bll;
using MTREG.medinsur.hdyb;
using MTREG.ihsptab.bo;
using MTREG.medinsur.sjzsyb;
using zhongluyiyuan.gsbx;
using MTHIS.tools;
using zhongluyiyuan.gsbx.bll;
using MTREG.common.bll;

namespace MTREG.ihsp
{
    public partial class FrmIhspInhsp : Form
    {
        BillCmbList billCmbList = new BillCmbList();
        BillIhspMan billIhspMan = new BillIhspMan();
        /// <summary>
        /// 控制listbox显示
        /// </summary>
        bool isleave = false;
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmIhspInhsp()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmIhspInhsp(bool pay)
        {
            InitializeComponent();
            cbxPay.Checked = true;
        }

        /// <summary>
        /// 查询方法
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hspcard"></param>
        public void seachMethod()
        {
            string name = this.tbxName.Text.Trim().ToString();
            string ihspcode = this.tbxIhspcode.Text.Trim().ToString();
            string depart = "";
            if (cmbDepart.Text.Trim() == "--全部--")
            {
                depart = "";
            }
            else
            {
                depart = this.cmbDepart.Text.Trim().ToString();
            }
            string startTime = this.dtpStartTime.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string endTime = this.dtpEndTime.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            string hspcard = this.tbxHspcard.Text.Trim().ToString();
            string status = cmbStatus.SelectedValue.ToString();
            if (status == "ALL")
            {
                status = "";
            }
            if (!cbxByInDate.Checked)
            {
                startTime = "";
                endTime = "";
            }
            DataTable dataTable = billIhspMan.manSearch(name, ihspcode, hspcard, depart, startTime, endTime, status);
            this.dgvInhospital.DataSource = dataTable;
            for (int i = 0; i < dgvInhospital.Rows.Count; i++)
            {
                string displaycolor = dgvInhospital.Rows[i].Cells["displaycolor"].Value.ToString();
                if (dgvInhospital.Rows[i].Cells["displaycolor"].Value.ToString() == "" || dgvInhospital.Rows[i].Cells["displaycolor"].Value.ToString() == null)
                {
                    dgvInhospital.Rows[i].DefaultCellStyle.BackColor = Color.FromName("red");
                }
                else
                {
                    dgvInhospital.Rows[i].DefaultCellStyle.BackColor = Color.FromName(displaycolor);
                }

            }


        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmIhspInhsp_Load(object sender, EventArgs e)
        {
            //BillSysBase.controlAutoSize(this);
            cmbSource();
            dtpEndTime.Enabled = false;
            dtpStartTime.Enabled = false;
            cbxByInDate.Checked = false;
            seachMethod();
            #region  dgv单元格标题设置
            dgvInhospital.Font = new Font("宋体", (float)(13 * ProgramGlobal.WidthScale));
            this.dgvInhospital.RowsDefaultCellStyle.Font = new Font("宋体", (float)(13 * ProgramGlobal.WidthScale));
            this.dgvInhospital.ColumnHeadersHeight = (int)(30 * ProgramGlobal.HeightScale);
            this.dgvInhospital.Columns["ihspcode"].HeaderText = "住院号";
            this.dgvInhospital.Columns["ihspcode"].Width = (int)(120 * ProgramGlobal.WidthScale);
            this.dgvInhospital.Columns["ihspname"].HeaderText = "姓名";
            this.dgvInhospital.Columns["ihspname"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dgvInhospital.Columns["sex"].HeaderText = "性别";
            this.dgvInhospital.Columns["sex"].Width = (int)(60 * ProgramGlobal.WidthScale);
            this.dgvInhospital.Columns["departname"].HeaderText = "科室";
            this.dgvInhospital.Columns["departname"].Width = (int)(130 * ProgramGlobal.WidthScale);
            this.dgvInhospital.Columns["doctorname"].HeaderText = "医生";
            this.dgvInhospital.Columns["doctorname"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dgvInhospital.Columns["mobile"].HeaderText = "联系方式";
            this.dgvInhospital.Columns["mobile"].Width = (int)(120 * ProgramGlobal.WidthScale);
            this.dgvInhospital.Columns["indate"].HeaderText = "入院时间";
            this.dgvInhospital.Columns["indate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            this.dgvInhospital.Columns["indate"].Width = (int)(120 * ProgramGlobal.WidthScale);
            this.dgvInhospital.Columns["healthcard"].HeaderText = "卡  号";
            this.dgvInhospital.Columns["healthcard"].Width = (int)(120 * ProgramGlobal.WidthScale);
            this.dgvInhospital.Columns["AKC140"].HeaderText = "入院疾病";
            this.dgvInhospital.Columns["AKC140"].Width = (int)(120 * ProgramGlobal.WidthScale);
            this.dgvInhospital.Columns["patienttype"].HeaderText = "患者类型";
            this.dgvInhospital.Columns["patienttype"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dgvInhospital.Columns["AKA130"].HeaderText = "住院类型";
            this.dgvInhospital.Columns["AKA130"].Width = (int)(160 * ProgramGlobal.WidthScale);
            this.dgvInhospital.Columns["sickroomname"].HeaderText = "病室";
            this.dgvInhospital.Columns["sickroomname"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dgvInhospital.Columns["sickbedname"].HeaderText = "床号";
            this.dgvInhospital.Columns["sickbedname"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dgvInhospital.Columns["bas_patienttype_id"].HeaderText = "患者类型id";
            this.dgvInhospital.Columns["bas_patienttype_id"].Visible = false;
            this.dgvInhospital.Columns["displaycolor"].Visible = false;
            this.dgvInhospital.Columns["id"].HeaderText = "Id";
            this.dgvInhospital.Columns["id"].Visible = false;
            this.dgvInhospital.Columns["keyname"].Visible = false;
            this.dgvInhospital.Columns["bas_doctor_id"].HeaderText = "医师Id";
            this.dgvInhospital.Columns["bas_doctor_id"].Visible = false;
            this.dgvInhospital.Columns["bas_depart_id"].HeaderText = "科室Id";
            this.dgvInhospital.Columns["bas_depart_id"].Visible = false;
            #endregion
            tbxIhspcode.Focus();
            dgvInhospital.ReadOnly = true;
            dgvInhospital.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataTable dtp = billCmbList.patientTypeListInsur();
            if (dtp.Rows.Count > 0)
            {
                this.cmbPatienttype.ValueMember = "id";
                this.cmbPatienttype.DisplayMember = "name";
                this.cmbPatienttype.DataSource = dtp;

                cmbPatienttype.SelectedValue = "41";
            }
        }
        /// <summary>
        /// 绑定combobox数据
        /// </summary>
        private void cmbSource()
        {
            DataTable dtde = billCmbList.ihspDepart(cmbDepart.Text.Trim());
            if (dtde.Rows.Count > 0)
            {
                this.cmbDepart.ValueMember = "id";
                this.cmbDepart.DisplayMember = "name";
                DataRow dr = dtde.NewRow();
                dr["id"] = 0;
                dr["name"] = "--全部--";
                dtde.Rows.InsertAt(dr, 0);
                this.cmbDepart.DataSource = dtde;
            }

            List<ListItem> status = new List<ListItem>();
            ListItem status1 = new ListItem("已登记", "BREG");
            ListItem status2 = new ListItem("已在院", "REG");
            ListItem status3 = new ListItem("已挂账", "SIGN");
            ListItem status4 = new ListItem("已结算", "SETT");
            ListItem status5 = new ListItem("--全部--", "ALL");
            status.Add(status1);
            status.Add(status2);
            status.Add(status3);
            status.Add(status4);
            status.Add(status5);
            cmbStatus.DisplayMember = "Text";
            cmbStatus.ValueMember = "Value";
            cmbStatus.DataSource = status;
            cmbStatus.SelectedValue = "ALL";
        }
        /// <summary>
        /// 住院管理窗口 中的查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            seachMethod();
        }


        /// <summary>
        /// 重置按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRest_Click(object sender, EventArgs e)
        {
            reset();
        }

        /// <summary>
        /// 重置
        /// </summary>
        public void reset()
        {
            this.tbxHspcard.Text = "";
            this.tbxIhspcode.Text = "";
            this.tbxName.Text = "";
            cmbStatus.SelectedValue = "ALL";
            cmbDepart.SelectedValue = 0;
            this.dtpStartTime.Value = Convert.ToDateTime(Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") + " 00:00:00");
            this.dtpEndTime.Value = Convert.ToDateTime(Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") + " 23:59:59");
            seachMethod();
        }

        /// <summary>
        /// 弹出登记窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            FrmIhspReg frmIhspReg = new FrmIhspReg("REG");
            frmIhspReg.ShowDialog();
            if (frmIhspReg.DialogResult == DialogResult.OK)
            {
                reset();
                MessageBox.Show("住院登记成功!");
            }
        }

        /// <summary>
        /// 预付款窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrepamt_Click(object sender, EventArgs e)
        {
            if (dgvInhospital.SelectedRows.Count == 0 && dgvInhospital.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            FrmIhspPay frmIhspPay = new FrmIhspPay();
            string id = dgvInhospital.SelectedRows[0].Cells["id"].Value.ToString();
            frmIhspPay.getManSource(id);
            frmIhspPay.ShowDialog();
        }

        /// <summary>
        /// 入院回退
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOutInhs_Click(object sender, EventArgs e)
        {
            if (dgvInhospital.SelectedRows.Count == 0 && dgvInhospital.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            FrmRetIhsp frmOuthospital = new FrmRetIhsp();
            string id = dgvInhospital.SelectedRows[0].Cells["id"].Value.ToString();
            frmOuthospital.getOutSource(id);
            frmOuthospital.ShowDialog();
            seachMethod();
        }

        /// <summary>
        /// 担保窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuarantee_Click(object sender, EventArgs e)
        {
            if (dgvInhospital.SelectedRows.Count == 0 && dgvInhospital.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            FrmIhspGua frmIhspGua = new FrmIhspGua();
            string id = dgvInhospital.SelectedRows[0].Cells["id"].Value.ToString();
            frmIhspGua.getSource(id);
            frmIhspGua.ShowDialog();
        }

        /// <summary>
        /// 起始时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpStartTime_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Compare(this.dtpStartTime.Value, this.dtpEndTime.Value) > 0)
            {
                MessageBox.Show("错误:起始日期不能大于截止日期！");
                dtpStartTime.Value = Convert.ToDateTime(Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") + " 00:00:00");
                return;
            }
        }
        private void dtpEndTime_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Compare(this.dtpStartTime.Value, this.dtpEndTime.Value) > 0)
            {
                MessageBox.Show("错误:截止日期不能小于于起始日期！");
                dtpEndTime.Value = Convert.ToDateTime(Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") + " 23:59:59");
                return;
            }
        }
        /// <summary>
        /// 选中预交款 卡号回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxHspcard_KeyDown(object sender, KeyEventArgs e)
        {
            if (cbxPay.Checked)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string hspcard = tbxHspcard.Text.ToString();
                    DataTable dataTable = billIhspMan.manSearch("", "", hspcard, "", "", "", "");
                    if (dataTable.Rows.Count > 0)
                    {
                        this.dgvInhospital.DataSource = dataTable;
                        this.dgvInhospital.CurrentCell = dgvInhospital.Rows[0].Cells[0];
                        FrmIhspPay frmIhspPay = new FrmIhspPay();
                        string id = dgvInhospital.SelectedRows[0].Cells["id"].Value.ToString();
                        frmIhspPay.getManSource(id);
                        frmIhspPay.ShowDialog();
                    }
                    else
                    {
                        //this.cmbDepart.Focus();
                        //this.cmbDepart.DroppedDown = true;
                    }
                }
            }
        }

        /// <summary>
        /// 医保管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsurMag_Click(object sender, EventArgs e)
        {
            FrmCxcwTscl cl = new FrmCxcwTscl();
            cl.StartPosition = FormStartPosition.CenterScreen;
            cl.ShowDialog(this);
            #region
            //if (dgvInhospital.SelectedRows.Count == 0 && dgvInhospital.SelectedCells.Count == 0)
            //{
            //    MessageBox.Show("请先在列表中选择");
            //    return;
            //}

            //string id = dgvInhospital.SelectedRows[0].Cells["id"].Value.ToString();
            //string patienttype = dgvInhospital.SelectedRows[0].Cells["bas_patienttype_id"].Value.ToString();
            //string keyname = billIhspMan.getInsurtype(patienttype);
            //if (keyname == CostInsurtypeKeyname.GZSNH.ToString())
            //{
            //    FrmGzsnhInsurMag frmInsurMag = new FrmGzsnhInsurMag();
            //    frmInsurMag.getSource(id, patienttype);
            //    frmInsurMag.ShowDialog();
            //}
            //else if (keyname == CostInsurtypeKeyname.GYSYB.ToString())
            //{
            //    FrmGysybInsurMag frmInsurMag = new FrmGysybInsurMag();
            //    frmInsurMag.getSource(id, patienttype);
            //    frmInsurMag.ShowDialog();
            //}
            //else if (keyname == CostInsurtypeKeyname.GZSYB.ToString())
            //{
            //    FrmGzsybInsurMag frmInsurMag = new FrmGzsybInsurMag();
            //    frmInsurMag.getSource(id, patienttype);
            //    frmInsurMag.ShowDialog();
            //}
            #endregion
        }

        private void tbxIhspcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tbxName.Focus();
            }
        }

        private void tbxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tbxHspcard.Focus();
            }
        }

        private void FrmIhspInhsp_Activated(object sender, EventArgs e)
        {
            tbxHspcard.Focus();
        }



        /// <summary>
        /// 入院登记信息修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvInhospital.SelectedRows.Count == 0 && dgvInhospital.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            string ihsp_id = dgvInhospital.SelectedRows[0].Cells["id"].Value.ToString();
            FrmIhspInfoEdit frmIhspInfoEdit = new FrmIhspInfoEdit();
            frmIhspInfoEdit.Ihsp_id = ihsp_id;
            frmIhspInfoEdit.bas_patienttype = dgvInhospital.SelectedRows[0].Cells["keyname"].Value.ToString();
            frmIhspInfoEdit.ShowDialog();
            if (frmIhspInfoEdit.DialogResult == DialogResult.OK)
            {
                //reset();
                seachMethod();
                MessageBox.Show("住院登记信息修改成功!");
            }
        }


        private void tbxHspcard_KeyUp(object sender, KeyEventArgs e)
        {
            if (cbxPay.Checked)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string hspCard = tbxHspcard.Text.Trim();
                    if (hspCard.Length > 2)
                    {
                        hspCard = hspCard.Replace(";", "");
                        hspCard = hspCard.Replace("?", "");
                        tbxHspcard.Text = hspCard;
                    }
                    if (hspCard.Trim().Equals(""))
                        return;
                    string hspcard = tbxHspcard.Text.ToString();
                    DataTable dataTable = billIhspMan.manSearch("", "", hspcard, "", "", "", "");
                    if (dataTable.Rows.Count > 0)
                    {
                        this.dgvInhospital.DataSource = dataTable;
                        this.dgvInhospital.CurrentCell = dgvInhospital.Rows[0].Cells[0];
                        FrmIhspPay frmIhspPay = new FrmIhspPay();
                        string id = dgvInhospital.SelectedRows[0].Cells["id"].Value.ToString();
                        frmIhspPay.getManSource(id);
                        frmIhspPay.ShowDialog();
                    }
                    else
                    {
                        //this.cmbDepart.Focus();
                        //this.cmbDepart.DroppedDown = true;
                    }
                }
                else
                {
                    string hspCard = tbxHspcard.Text.Trim();
                    if (hspCard.Length > 2)
                    {
                        hspCard = hspCard.Replace(";", "");
                        hspCard = hspCard.Replace("?", "");
                        tbxHspcard.Text = hspCard;
                    }
                    if (hspCard.Trim().Equals(""))
                        return;
                }
            }
        }

        private void btnInsur_Click(object sender, EventArgs e)
        {
            if (dgvInhospital.CurrentRow == null)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            if (cmbPatienttype.SelectedValue == null)
            {
                MessageBox.Show("请选择正确的类型");
                return;
            }
            int rowIdx = dgvInhospital.CurrentRow.Index;
            if (rowIdx < 0)
            {
                MessageBox.Show("请选择患者");
                return;
            }
            string id = dgvInhospital.Rows[rowIdx].Cells["id"].Value.ToString();
            string bas_patienttype_id = dgvInhospital.Rows[rowIdx].Cells["bas_patienttype_id"].Value.ToString();
            
            string patienttypeId = cmbPatienttype.SelectedValue.ToString();
            string keyname = billIhspMan.getInsurtype(patienttypeId);

            if (btnInsur.Text == "转自费")
            {
                if (bas_patienttype_id == "34" || bas_patienttype_id == "35")
                {
                    FrmRyHt ryht = new FrmRyHt();
                    string zyh = dgvInhospital.Rows[rowIdx].Cells["ihspcode"].Value.ToString();
                    string sql = "select healthcard from inhospital where ihspcode='" + zyh + "'";
                    DataTable dt = BllMain.Db.Select(sql).Tables[0];
                    ryht.Zyh = zyh;
                    ryht.Xm = dgvInhospital.Rows[rowIdx].Cells["ihspname"].Value.ToString();
                    ryht.Grbh = dt.Rows[0]["healthcard"].ToString().Trim();
                    //ryht.Ylfkfs_id = (dt.Rows[0]["qfybch"].ToString().Trim() == "1") ? ("职工医保") : ("城乡居民");
                    ryht.Zyjlh = id;
                    //ryht.Sfck = int.Parse(dt1.Rows[0]["sfck"].ToString());
                    //ryht.IQfybch = dt.Rows[0]["qfybch"].ToString().Trim();
                    ryht.StartPosition = FormStartPosition.CenterScreen;
                    ryht.ShowDialog(this);
                }
                else if (bas_patienttype_id == "38")
                {
                    DlDC dldc = new DlDC();
                    GSBX_IN in1 = new GSBX_IN();
                    GSBX_OUT out1 = new GSBX_OUT();
                    GSBXinterface GSBXinterface = new GSBXinterface();
                    string sessionid = "";
                    String mtzyjl_iid = id; //住院记录表iid
                    string sqlTmp = "select nhflag,ihspcode as zyjlzyh,rdsh  from inhospital where id =  " + mtzyjl_iid;
                    DataTable dt = BllMain.Db.Select(sqlTmp).Tables[0];
                    if (dt.Rows[0]["nhflag"].ToString().Trim() != "501")
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
                    data += " <akc190>" + dt.Rows[0]["zyjlzyh"].ToString().Trim() + "</akc190>";
                    data += " <alca02>" + dt.Rows[0]["rdsh"].ToString().Trim() + "</alca02>";
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
                    string sql_up = "update inhospital set nhflag=0,rdsh='',spbh='',bas_patienttype_id=1,bas_patienttype_id=1 where id=" + mtzyjl_iid + " ; ";
                    sql_up += " delete from gsryinfo where id=" + mtzyjl_iid + " ;";
                    if (BllMain.Db.Update(sql_up) == -1)
                    {
                        SysWriteLogs.writeLogs1("工伤回退更新his错误信息", DateTime.Now, "sql=" + sql_up);
                        MessageBox.Show("工伤回退成功,更新his失败！");
                    }
                    string flag1 = dldc.dengchu(sessionid);
                    if (flag1 == "1")
                    {
                        MessageBox.Show(dldc.Message);
                        return;
                    }
                    sessionid = "";
                    MessageBox.Show("回退成功！");
                }
                else if (bas_patienttype_id == "36" || bas_patienttype_id == "37" || bas_patienttype_id == "39")
                {
                    string sql_up = "UPDATE inhospital SET bas_patienttype_id = " + DataTool.addFieldBraces("1") + " WHERE id = " + id;
                    int flag = BllMain.Db.Update(sql_up);
                    if (flag < 0)
                    {
                        MessageBox.Show("住院类型更改为自费失败!", "提示信息");
                    }
                    else
                    {

                        MessageBox.Show("住院类型更改为自费成功!", "提示信息");
                    }
                }

            }
            else if (btnInsur.Text == "转医保")
            {
                string sql_ssn = "select ihsp_info.homephone as lxfs,ihsp_info.profession as ryzy,ihsp_info.homeaddress as rydz,ihsp_info.idcard as ssn,inhospital.age as age,inhospital.clinicdiagn as mzzd,clinicicd as mzzdbm ,inhospital.ihspdiagn as zyzd from inhospital,ihsp_info where inhospital.id=ihsp_info.ihsp_id and ihsp_info.registkind = 'IHSP' and inhospital.id=" + id;
                var ds = BllMain.Db.Select(sql_ssn);
                string ssn = "";
                if (ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
                {
                    ssn = ds.Tables[0].Rows[0]["ssn"].ToString().Trim();
                }


                if (keyname == CostInsurtypeKeyname.SJZSYB.ToString() || keyname == CostInsurtypeKeyname.SJZSJM.ToString())
                {
                    FrmSybRy syry = new FrmSybRy();
                    syry.Zfrydj.Zyh = dgvInhospital.Rows[rowIdx].Cells["ihspcode"].Value.ToString();//住院号
                    syry.Zfrydj.Brxm = dgvInhospital.Rows[rowIdx].Cells["ihspname"].Value.ToString();//姓名
                    syry.Zfrydj.Bch = dgvInhospital.Rows[rowIdx].Cells["sickbedname"].Value.ToString();//病床号
                    syry.Zfrydj.Bfh = dgvInhospital.Rows[rowIdx].Cells["sickroomname"].Value.ToString();//病房号
                    syry.Zfrydj.Ysname = dgvInhospital.Rows[rowIdx].Cells["doctorname"].Value.ToString();//医生名字
                    syry.Zfrydj.ysname_id = dgvInhospital.Rows[rowIdx].Cells["bas_doctor_id"].Value.ToString();//医生id
                    syry.Zfrydj.Ryks = dgvInhospital.Rows[rowIdx].Cells["departname"].Value.ToString();//科室
                    syry.Zfrydj.ryks_id = dgvInhospital.Rows[rowIdx].Cells["bas_depart_id"].Value.ToString();//科室id
                    syry.Zfrydj.Rysj = dgvInhospital.Rows[rowIdx].Cells["indate"].Value.ToString();//入院时间
                    syry.Zfrydj.Brsfzh = ds.Tables[0].Rows[0]["ssn"].ToString().Trim();//身份证号
                    syry.Zyjlh = id;
                    syry.Ylfkfs_id = patienttypeId;
                    syry.Zfrydj.Brnl = ds.Tables[0].Rows[0]["age"].ToString().Trim();//病人年龄
                    syry.Zfrydj.Ctctprof = ds.Tables[0].Rows[0]["ryzy"].ToString().Trim();//职业
                    syry.Zfrydj.MTel = ds.Tables[0].Rows[0]["lxfs"].ToString().Trim();//联系方式
                    syry.Zfrydj.Brdz = ds.Tables[0].Rows[0]["rydz"].ToString().Trim();//地址
                    syry.Zfrydj.Mzryzd = ds.Tables[0].Rows[0]["mzzd"].ToString().Trim();//门诊诊断
                    syry.Zfrydj.Mzryzd_bm = ds.Tables[0].Rows[0]["mzzdbm"].ToString().Trim();//门诊诊断编码
                    syry.Zfrydj.Zyryzd = ds.Tables[0].Rows[0]["zyzd"].ToString().Trim();//住院诊断
                    syry.StartPosition = FormStartPosition.CenterScreen;
                    syry.ShowDialog(this);
                }
                else if (keyname == CostInsurtypeKeyname.GSBX.ToString() )
                {
                    FrmgsRy frmsybry = new FrmgsRy();
                    frmsybry.Ylfkfs = "工伤保险";//医疗付款方式
                    frmsybry.Ylfkfs_id = "38";//医疗付款方式id
                    frmsybry.Zyjlh = id;//住院记录号
                    frmsybry.Zfrydj.Zyh = dgvInhospital.Rows[rowIdx].Cells["ihspcode"].Value.ToString();//住院号 
                    frmsybry.Zfrydj.Brxm = dgvInhospital.Rows[rowIdx].Cells["ihspname"].Value.ToString();//姓名
                    frmsybry.Zfrydj.Bch = dgvInhospital.Rows[rowIdx].Cells["sickbedname"].Value.ToString();//病床号
                    frmsybry.Zfrydj.Bfh = dgvInhospital.Rows[rowIdx].Cells["sickroomname"].Value.ToString();//病房号
                    frmsybry.Zfrydj.Ysname = dgvInhospital.Rows[rowIdx].Cells["doctorname"].Value.ToString();//医生名字
                    frmsybry.Zfrydj.Ryks = dgvInhospital.Rows[rowIdx].Cells["departname"].Value.ToString();//科室
                    frmsybry.Zfrydj.Rysj = dgvInhospital.Rows[rowIdx].Cells["indate"].Value.ToString();//入院时间
                    frmsybry.Zfrydj.Brsfzh = ds.Tables[0].Rows[0]["ssn"].ToString().Trim();//身份证号
                    frmsybry.Zfrydj.Brxb = dgvInhospital.Rows[rowIdx].Cells["sex"].Value.ToString(); //性别
                    frmsybry.Zfrydj.Zyryzd = ds.Tables[0].Rows[0]["mzzd"].ToString().Trim();//门诊诊断
                    frmsybry.StartPosition = FormStartPosition.CenterScreen;
                    frmsybry.ShowDialog(this);
                }
                else if (patienttypeId == "36")//交通事故
                {
                    string sql_up = "UPDATE inhospital SET bas_patienttype_id = " + DataTool.addFieldBraces("36") + " WHERE id = " + id;
                    int flag = BllMain.Db.Update(sql_up);
                    if (flag < 0)
                    {
                        MessageBox.Show("住院类型更改为交通事故失败!", "提示信息");
                    }
                    else
                    {

                        MessageBox.Show("住院类型更改为交通事故成功!", "提示信息");
                    }
                }
                else if (patienttypeId == "37")//交通事故
                {
                    string sql_up = "UPDATE inhospital SET bas_patienttype_id = " + DataTool.addFieldBraces("37") + " WHERE id = " + id;
                    int flag = BllMain.Db.Update(sql_up);
                    if (flag < 0)
                    {
                        MessageBox.Show("住院类型更改为商业保险失败!", "提示信息");
                    }
                    else
                    {

                        MessageBox.Show("住院类型更改为商业保险成功!", "提示信息");
                    }
                }
                else if (patienttypeId == "39")//职工外伤
                {
                    string sql_up = "UPDATE inhospital SET bas_patienttype_id = " + DataTool.addFieldBraces("39") + " WHERE id = " + id;
                    int flag = BllMain.Db.Update(sql_up);
                    if (flag < 0)
                    {
                        MessageBox.Show("住院类型更改为职工外伤失败!", "提示信息");
                    }
                    else
                    {

                        MessageBox.Show("住院类型更改为职工外伤成功!", "提示信息");
                    }
                }
                else
                { return; }
            }
            seachMethod();
        }

        private void dgvInhospital_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInhospital.SelectedRows.Count == 0)// && dgvInhospital.SelectedCells.Count == 0)
            {
                return;
            }
            //获取医保类型
            string id = dgvInhospital.SelectedRows[0].Cells["id"].Value.ToString();
            string patienttype = dgvInhospital.SelectedRows[0].Cells["bas_patienttype_id"].Value.ToString();
            string keyname = billIhspMan.getInsurtype(patienttype);

            if (keyname == CostInsurtypeKeyname.SELFCOST.ToString())
            {
                //自费，转医保
                cmbPatienttype.Enabled = true;
                btnInsur.Text = "转医保";
                btnInsurMag.Enabled = false;
            }
            else
            {
                //非自费，获取类型，转自费
                cmbPatienttype.SelectedValue = patienttype;
                cmbPatienttype.Enabled = false;
                btnInsur.Text = "转自费";
                btnInsurMag.Enabled = true;
            }
            if (patienttype == "36" || patienttype == "37" || patienttype == "39")
            {
                cmbPatienttype.SelectedValue = patienttype;
                cmbPatienttype.Enabled = false;
                btnInsur.Text = "转自费";
                btnInsurMag.Enabled = true;
            }

            string ihspStatus = billIhspMan.getIhspStatus(id);
            if (ihspStatus.Equals("SIGN") || ihspStatus.Equals("SETT"))
            {
                btnOutInhs.Enabled = false;
            }
            else
            {
                btnOutInhs.Enabled = true;
            }
        }

        private void cmbDepart_KeyUp(object sender, KeyEventArgs e)
        {
            //判断输入是否 为字母键 或者 删除键，delete键 数字键
            if ((e.KeyValue >= 65) && (e.KeyValue <= 90)
                || (e.KeyCode == Keys.Back)
                || (e.KeyCode == Keys.Delete)
                || (e.KeyValue >= 48) && (e.KeyValue <= 57)
                || (e.KeyValue >= 96) && (e.KeyValue <= 105))
            {

                int l = cmbDepart.SelectionStart; //记录修改时光标位置
                cmbDepart.DroppedDown = false; //下拉框关闭

                string dep = cmbDepart.Text.Trim();
                //简码查询科室
                DataTable dtde = billCmbList.ihspDepart(dep);
                //重新绑定
                DataRow dr = dtde.NewRow();
                dr["id"] = 0;
                dr["name"] = "--全部--";
                dtde.Rows.InsertAt(dr, 0);
                cmbDepart.DataSource = dtde;
                cmbDepart.Text = dep;

                cmbDepart.DroppedDown = true; //打开下拉框
                cmbDepart.SelectionStart = l; //定位光标至修改时的位置
                this.Cursor = System.Windows.Forms.Cursors.Default; //显示鼠标
            }
        }

        private void btnPrintWD_Click(object sender, EventArgs e)
        {
            if (dgvInhospital.SelectedRows.Count == 0 && dgvInhospital.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            String mtzyjl_iid = dgvInhospital.SelectedRows[0].Cells["id"].Value.ToString(); //住院记录表iid
            //FrmDywd frmdywd = new FrmDywd();
            //frmdywd.BarCodeShow(mtzyjl_iid);
            FrxPrintView frxPrintView = new FrxPrintView();
            frxPrintView.WristbandPrt(mtzyjl_iid);
            //frxPrintView.xse(mtzyjl_iid);
        }

        private void cbxByInDate_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxByInDate.Checked)
            {
                dtpStartTime.Enabled = true;
                dtpEndTime.Enabled = true;
            }
            else
            {
                dtpStartTime.Enabled = false;
                dtpEndTime.Enabled = false;
            }
        }

        private void cmbPatienttype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
