using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.ihsp.bll;
using MTREG.ihsp.bo;
using MTHIS.common;
using MTREG.common;
using MTHIS.tools;
using MTREG.ihsptab.bo;
using MTREG.medinsur.hdyb.bll;
using MTREG.medinsur.gzsyb.ihsp;
using MTREG.medinsur.gysyb;
using MTREG.medinsur.gzsnh;
using MTREG.medinsur.gzsyb;
using MTHIS.main.bll;
using MTREG.medinsur.hdyb;
using MTHIS.db;
using MTREG.medinsur.sjzsyb;
using MTREG.medinsur.sjzsyb.bll;


namespace MTREG.ihsp
{
    public partial class FrmIhspOuthsp_cw : Form
    {
        BillIhspMan billIhspMan = new BillIhspMan();
        BillCmbList billCmbList = new BillCmbList();
        BillIhspcost billIhspcost = new BillIhspcost();
        BillIhspAct billIhspAct = new BillIhspAct();
        Inhospital inhospital = new Inhospital();
        /// <summary>
        /// 控制listbox显示
        /// </summary>
        bool isleave = false;
        public FrmIhspOuthsp_cw()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmIhspCost_Load(object sender, EventArgs e)
        {
            //BillSysBase.controlAutoSize(this);
            #region 下拉菜单绑定数据
            DataTable dtStatus = new DataTable();
            dtStatus.Columns.Add("name");
            dtStatus.Columns.Add("value");

            DataRow dr1 = dtStatus.NewRow();
            dr1[0] = "已在院";
            dr1[1] = "0";
            dtStatus.Rows.Add(dr1);
            DataRow dr2 = dtStatus.NewRow();
            dr2[0] = "已挂账";
            dr2[1] = "1";
            dtStatus.Rows.Add(dr2);
            DataRow dr3 = dtStatus.NewRow();
            dr3[0] = "已结算";
            dr3[1] = "2";
            dtStatus.Rows.Add(dr3);
            DataRow dr4 = dtStatus.NewRow();
            dr4[0] = "中途挂账";
            dr4[1] = "3";
           // dtStatus.Rows.Add(dr4);

            DataRow dr5 = dtStatus.NewRow();
            dr5[0] = "已报销";
            dr5[1] = "4";
            dtStatus.Rows.Add(dr5);
            this.cmbStatus.DisplayMember = "name";
            this.cmbStatus.ValueMember = "value";
            this.cmbStatus.DataSource = dtStatus;
            this.cmbStatus.SelectedValue = 1;

            DataTable dtp = billCmbList.getpatientType();
            if (dtp.Rows.Count > 0)
            {
                this.cmbPatienttype.ValueMember = "id";
                this.cmbPatienttype.DisplayMember = "name";
                var drp = dtp.NewRow();
                drp["Id"] = 0;
                drp["Name"] = "--全部--";
                dtp.Rows.InsertAt(drp, 0);
                this.cmbPatienttype.DataSource = dtp;
            }

            DataTable dtde = billCmbList.ihspDepart(cmbDepart.Text.Trim());
            if (dtde.Rows.Count > 0)
            {
                this.cmbDepart.ValueMember = "id";
                this.cmbDepart.DisplayMember = "name";
                var dr = dtde.NewRow();
                dr["id"] = 0;
                dr["name"] = "--全部--";
                dtde.Rows.InsertAt(dr, 0);
                this.cmbDepart.DataSource = dtde;
            }

            #endregion
            this.dtpStartTime.Value = dtpEndTime.Value.AddMonths(-3);
            searchMethod();
            #region  dgvInhospital单元格标题设置
            dgvInhospital.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale));
            dgvInhospital.RowsDefaultCellStyle.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale));
            this.dgvInhospital.Columns["ihspcode"].HeaderText = "住院号";
            this.dgvInhospital.Columns["ihspcode"].Width = (int)(100*ProgramGlobal.WidthScale);
            this.dgvInhospital.Columns["ihspname"].HeaderText = "姓名";
            this.dgvInhospital.Columns["ihspname"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dgvInhospital.Columns["deparname"].HeaderText = "科室";
            this.dgvInhospital.Columns["deparname"].Width = (int)(120 * ProgramGlobal.WidthScale);
            this.dgvInhospital.Columns["indate"].HeaderText = "入院时间";
            this.dgvInhospital.Columns["indate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            this.dgvInhospital.Columns["indate"].Width = (int)(110 * ProgramGlobal.WidthScale);
            this.dgvInhospital.Columns["outdate"].HeaderText = "出院时间";
            this.dgvInhospital.Columns["outdate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            this.dgvInhospital.Columns["outdate"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dgvInhospital.Columns["prepamt"].HeaderText = "预交合计";
            this.dgvInhospital.Columns["prepamt"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dgvInhospital.Columns["prepamt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvInhospital.Columns["feeamt"].HeaderText = "费用合计";
            this.dgvInhospital.Columns["feeamt"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dgvInhospital.Columns["feeamt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvInhospital.Columns["patienttype"].HeaderText = "患者类型";
            this.dgvInhospital.Columns["patienttype"].Width = (int)(100 * ProgramGlobal.WidthScale);
            this.dgvInhospital.Columns["companyname"].HeaderText = "工作单位";
            this.dgvInhospital.Columns["companyname"].Width = (int)(150 * ProgramGlobal.WidthScale);
            this.dgvInhospital.Columns["homeaddress"].HeaderText = "家庭住址";
            this.dgvInhospital.Columns["homeaddress"].Width = (int)(150 * ProgramGlobal.WidthScale);
            this.dgvInhospital.Columns["homephone"].HeaderText = "联系电话";
            this.dgvInhospital.Columns["homephone"].Width = (int)(130 * ProgramGlobal.WidthScale);
            this.dgvInhospital.Columns["status"].HeaderText = "状态";
            this.dgvInhospital.Columns["status"].Visible = false;
            this.dgvInhospital.Columns["id"].HeaderText = "id";
            this.dgvInhospital.Columns["id"].Visible = false;
            this.dgvInhospital.Columns["bas_patienttype_id"].HeaderText = "患者类型id";
            this.dgvInhospital.Columns["bas_patienttype_id"].Visible = false;
            this.dgvInhospital.Columns["displaycolor"].Visible = false;
            this.dgvInhospital.Columns["neonate"].Visible = false;
            this.dgvInhospital.Columns["ihsp_account_id"].Visible = false;
            #endregion            
            this.dgvInhospital.ReadOnly = true;
            this.dgvInhospital.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        /// <summary>
        /// 查询
        /// </summary>
        private void searchMethod()
        {
            string patienttype = "";
            string depart = "";
            Inhospital inhospital = new Inhospital();
            inhospital.Name = this.tbxName.Text.Trim().ToString();
            inhospital.Ihspcode = this.tbxIhspcode.Text.ToString();
            inhospital.Indate = this.dtpStartTime.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            inhospital.Outdate = this.dtpEndTime.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            inhospital.Hspcard = this.tbxHspcard.Text.Trim().ToString();
            if (this.cmbDepart.Text == "--全部--")
            {
                depart = "";
            }
            else
            {
                depart = this.cmbDepart.SelectedValue.ToString();
            }
            inhospital.Depart = depart;
            string status = this.cmbStatus.Text.Trim().ToString();
            switch (status)
            {
                //case "--全部--": inhospital.Status = ""; break;
                case "已在院": inhospital.Status = "REG"; break;
                case "已挂账": inhospital.Status = "SIGN"; break;
                case "已结算": inhospital.Status = "SETT"; break;
                case "已报销": inhospital.Status = "SYBX"; break;
               // case "中途挂账": inhospital.Status = "MSIG"; break;
            }
            if (this.cmbPatienttype.Text == "--全部--")
            {
                patienttype = "";
            }
            else
            {
                patienttype = cmbPatienttype.SelectedValue.ToString();
            }
            inhospital.Patienttype = patienttype;
            DataTable dt = billIhspcost.ihspSearch(inhospital);
            this.dgvInhospital.DataSource = dt;
            for (int i = 0; i < dgvInhospital.Rows.Count; i++)
            {
                string displaycolor = dgvInhospital.Rows[i].Cells["displaycolor"].Value.ToString();
                if (dgvInhospital.Rows[i].Cells["displaycolor"].Value.ToString() == "" || dgvInhospital.Rows[i].Cells["displaycolor"].Value.ToString() == null)
                {
                    dgvInhospital.Rows[i].DefaultCellStyle.BackColor = Color.FromName("blue");
                }
                else
                {
                    dgvInhospital.Rows[i].DefaultCellStyle.BackColor = Color.FromName(displaycolor);
                }

            }
        }

        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchMethod();
            gettj();
        }
        public void gettj()
        {
            Inhospital inhospital = new Inhospital();
            inhospital.Indate = this.dtpStartTime.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            inhospital.Outdate = this.dtpEndTime.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            string Chargeby = ProgramGlobal.User_id;//"132";
            labsfje.Text = billIhspcost.getihsp_accountfee(inhospital, Chargeby);
            labtfje.Text = billIhspcost.getihsp_accountRRECfee(inhospital, Chargeby);
            this.labsfzs.Text = billIhspcost.getihsp_accountcount(inhospital, Chargeby);
            labtfzs.Text = billIhspcost.getihsp_accountRRECcount(inhospital, Chargeby);
            labssje.Text = billIhspcost.getihsp_accountsum(inhospital, Chargeby);
        }
        /// <summary>
        /// 预交款
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDoChrg_Click(object sender, EventArgs e)
        {
            if (dgvInhospital.SelectedRows.Count == 0 && dgvInhospital.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            FrmIhspPay frmIhspPay = new FrmIhspPay();
            string id = dgvInhospital.SelectedRows[0].Cells["id"].Value.ToString();
            frmIhspPay.getCostSource(id);
            frmIhspPay.ShowDialog();
        }
        /// <summary>
        /// 结算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccount_Click(object sender, EventArgs e)
        {
            BllInsur bllInsur = new BllInsur();
            if (dgvInhospital.SelectedRows.Count == 0 && dgvInhospital.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            int rowIdx = dgvInhospital.CurrentRow.Index;
            string id=dgvInhospital.SelectedRows[0].Cells["id"].Value.ToString();
            string patienttype_id = dgvInhospital.SelectedRows[0].Cells["bas_patienttype_id"].Value.ToString();
            string keyname = bllInsur.getInsurtype(patienttype_id);
             //
            if (Ini.IniReadValue2("pz", "ISXJHB") == "1")
            {
                FrmIhspAccount frmIhspAccount = new FrmIhspAccount();
                frmIhspAccount.getSource(id);
                frmIhspAccount.ShowDialog();
                if (frmIhspAccount.DialogResult == DialogResult.Cancel)
                {
                    searchMethod();
                }
            }
            else if (keyname == CostInsurtypeKeyname.SELFCOST.ToString())//自费
	        {
                FrmIhspAccount frmIhspAccount = new FrmIhspAccount();
                frmIhspAccount.getSource(id);
                frmIhspAccount.ShowDialog();
                if (frmIhspAccount.DialogResult == DialogResult.Cancel)
                {
                    searchMethod();
                }
	        }
             else if (keyname == CostInsurtypeKeyname.HDSCH.ToString())//邯郸城合
             {
                 MTHIS.FrmMain fm = new MTHIS.FrmMain();
                 if (fm.ybsyqx() != true)
                 {
                     return;
                 }
                 FrmChCy chcy = new FrmChCy();
                 chcy.Ihsp_id = id;
                 chcy.Zyh_ = dgvInhospital.Rows[rowIdx].Cells["ihspcode"].Value.ToString().Trim();
                 chcy.Ylkfkfs = patienttype_id;
                 chcy.ShowDialog();
                 if (chcy.DialogResult == DialogResult.Cancel)
                 {
                     searchMethod();
                 }
             }
            else if (keyname == CostInsurtypeKeyname.SJZSYB.ToString() || keyname == CostInsurtypeKeyname.SJZSJM.ToString())//医保
             {
                 MTHIS.FrmMain fm = new MTHIS.FrmMain();
                 if (fm.ybsyqx() != true)
                 {
                     return;
                 }
                 FrmSybCy chcy = new FrmSybCy();
                 //FrmYbCy chcy = new FrmYbCy();
                 chcy.Ihsp_id = id;
                 chcy.Zyh_ = dgvInhospital.Rows[rowIdx].Cells["ihspcode"].Value.ToString().Trim();
                 chcy.Ylkfkfs = patienttype_id;
                 chcy.ShowDialog();
                 if (chcy.DialogResult == DialogResult.Cancel)
                 {
                     searchMethod();
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
                 sycy.Zyh_ = dgvInhospital.Rows[rowIdx].Cells["ihspcode"].Value.ToString().Trim();
                 sycy.Ylkfkfs = patienttype_id;
                 sycy.ShowDialog();
                 if (sycy.DialogResult == DialogResult.Cancel)
                 {
                     searchMethod();
                 }
             }
        }

        /// <summary>
        /// 结算回退
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRetAccount_Click(object sender, EventArgs e)
        {
            if (dgvInhospital.SelectedRows.Count == 0 && dgvInhospital.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            string id = dgvInhospital.SelectedRows[0].Cells["id"].Value.ToString();
            string ihsp_account_id = dgvInhospital.SelectedRows[0].Cells["ihsp_account_id"].Value.ToString();
            string patienttype_id = dgvInhospital.SelectedRows[0].Cells["bas_patienttype_id"].Value.ToString();
            string neonate = dgvInhospital.SelectedRows[0].Cells["neonate"].Value.ToString();
            string zyhTmp = dgvInhospital.SelectedRows[0].Cells["ihspcode"].Value.ToString();
            string sqlTmp = "select yllb,insurcode,nhflag from inhospital where  id = " + id + " and ihspcode = '" + zyhTmp + "'";
            var dsTmp = BllMain.Db.Select(sqlTmp);
            BllInsur bllInsur = new BllInsur();
            string keyname = bllInsur.getInsurtype(patienttype_id);
            if (Ini.IniReadValue2("pz", "ISXJHB") == "1")
            {
                string nhflag = dsTmp.Tables[0].Rows[0]["nhflag"].ToString().Trim() ;
                if (nhflag != "1101" && nhflag != "0") 
                {
                    MessageBox.Show("提示","医保未回退，若要进行请先医保回退！");
                    return;
                }
                FrmRetAccount frmRetAccount = new FrmRetAccount();
                frmRetAccount.getSource(id, ihsp_account_id);
                frmRetAccount.ShowDialog();
                
                if (frmRetAccount.DialogResult == DialogResult.OK)
                {
                    searchMethod();
                }
            }
            if (neonate.Equals("Y"))
            {
                FrmRetAccount frmRetAccount = new FrmRetAccount();
                frmRetAccount.getSource(id, ihsp_account_id);
                frmRetAccount.ShowDialog();
                if (frmRetAccount.DialogResult == DialogResult.OK)
                {
                    searchMethod();
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
            else if (keyname == CostInsurtypeKeyname.SELFCOST.ToString())//自费
            {
                MTHIS.FrmMain fm = new MTHIS.FrmMain();
                if (fm.ybsyqx() != true)
                {
                    return;
                }
                FrmRetAccount frmRetAccount = new FrmRetAccount();
                frmRetAccount.getSource(id, ihsp_account_id);
                frmRetAccount.ShowDialog();
                if (frmRetAccount.DialogResult == DialogResult.OK)
                {
                    searchMethod();
                }
            }
            else if (keyname == CostInsurtypeKeyname.SJZSYB.ToString() || keyname == CostInsurtypeKeyname.SJZSJM.ToString())//医保
            {
                MTHIS.FrmMain fm = new MTHIS.FrmMain();
                if (fm.ybsyqx() != true)
                {
                    return;
                }
                FrmSybCy chcy = new FrmSybCy();
                string strZyh = "";
                string strZyjlId = "";
                chcy.js_ht(zyhTmp,"",id,"");
            }
        }
        /// <summary>
        /// 取消挂账
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCsSign_Click(object sender, EventArgs e)
        {
            if (dgvInhospital.SelectedRows.Count == 0 && dgvInhospital.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            string id=dgvInhospital.SelectedRows[0].Cells["id"].Value.ToString();
            FrmCsSign frmCsSign = new FrmCsSign();
            frmCsSign.getSource(id);
            frmCsSign.ShowDialog();
            if (frmCsSign.DialogResult == DialogResult.Cancel)
            {
                searchMethod();
            }
        }
        /// <summary>
        /// 重打
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRePrint_Click(object sender, EventArgs e)
        {
            if (dgvInhospital.SelectedRows.Count == 0 && dgvInhospital.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            
            BllInsur bllInsur = new BllInsur();
            int rowIdx = dgvInhospital.CurrentRow.Index;
            string id = dgvInhospital.SelectedRows[0].Cells["id"].Value.ToString();
            string patienttype_id = dgvInhospital.SelectedRows[0].Cells["bas_patienttype_id"].Value.ToString();
            string keyname = bllInsur.getInsurtype(patienttype_id);
            
            //
            if (Ini.IniReadValue2("pz", "ISXJHB") == "1")
            {
                FrmIhspAccount frmIhspAccount = new FrmIhspAccount();
                frmIhspAccount.getSource(id);
                frmIhspAccount.ShowDialog();
                if (frmIhspAccount.DialogResult == DialogResult.Cancel)
                {
                    searchMethod();
                }
            }
            else if (keyname == CostInsurtypeKeyname.SELFCOST.ToString())//自费
            {
                //FrmIhspAccount frmIhspAccount = new FrmIhspAccount();
                //frmIhspAccount.getSource(id);
                //frmIhspAccount.ShowDialog();
                //if (frmIhspAccount.DialogResult == DialogResult.Cancel)
                //{
                //    searchMethod();
                //}
                FrxPrintView frxPrintView = new FrxPrintView();
                string acc = dgvInhospital.Rows[rowIdx].Cells["id"].Value.ToString().Trim();
                frxPrintView.IhspAccPrt(acc);
            }
            else if (keyname == CostInsurtypeKeyname.HDSCH.ToString())//邯郸城合
            {
                MTHIS.FrmMain fm = new MTHIS.FrmMain();
                if (fm.ybsyqx() != true)
                {
                    return;
                }
                FrmChCy chcy = new FrmChCy();
                chcy.Ihsp_id = id;
                chcy.Zyh_ = dgvInhospital.Rows[rowIdx].Cells["ihspcode"].Value.ToString().Trim();
                chcy.Ylkfkfs = patienttype_id;
                chcy.ShowDialog();
                if (chcy.DialogResult == DialogResult.Cancel)
                {
                    searchMethod();
                }
            }
            else if (keyname == CostInsurtypeKeyname.SJZSYB.ToString())//医保
            {
                MTHIS.FrmMain fm = new MTHIS.FrmMain();
                if (fm.ybsyqx() != true)
                {
                    return;
                }
                BllInsur bs = new BllInsur();
                string strZyh = dgvInhospital.Rows[rowIdx].Cells["ihspcode"].Value.ToString();
                DataTable dt = bs.RetypeFP(strZyh);
                FrmSybCy chcy = new FrmSybCy();
                string strGrbh = dt.Rows[0]["insurcode"].ToString();
                string ihsp_id = dt.Rows[0]["id"].ToString();
                chcy.dyfp(strGrbh, strZyh, ihsp_id);
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
                sycy.Zyh_ = dgvInhospital.Rows[rowIdx].Cells["ihspcode"].Value.ToString().Trim();
                sycy.Ylkfkfs = patienttype_id;
                sycy.ShowDialog();
                if (sycy.DialogResult == DialogResult.Cancel)
                {
                    searchMethod();
                }
            }

        }
        /// <summary>
        /// 重置按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>            
        private void btnReset_Click(object sender, EventArgs e)
        {
            tbxHspcard.Text = "";
            tbxIhspcode.Text = "";
            tbxName.Text = "";
            this.dtpEndTime.Value = Convert.ToDateTime(Convert.ToDateTime(BillSysBase.currDate()).ToString("yyyy-MM-dd") + " 23:59:59");
            this.dtpStartTime.Value = dtpEndTime.Value.AddMonths(-3);
            this.cmbDepart.SelectedValue = 0;
            this.cmbPatienttype.SelectedValue = 0;
            this.cmbStatus.SelectedValue = 1;
            searchMethod();
        }
        /// <summary>
        /// dgv选择内容变化时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvInhospital_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInhospital.SelectedRows.Count != 0 && dgvInhospital.SelectedCells.Count != 0)
            {
                string ihsp_account_id = dgvInhospital.SelectedRows[0].Cells["ihsp_account_id"].Value.ToString();
                string id = dgvInhospital.SelectedRows[0].Cells["id"].Value.ToString();
                DataTable datatable = null;
                if (DataTool.stringToInt(ihsp_account_id)<=0)
                {
                    btn_xf.Enabled = false;
                    btnRetAccount.Enabled = false;
                    btnRePrint.Enabled = false;
                    btnCsSign.Enabled = true;
                    btnDoChrg.Enabled = true;
                    btnAccount.Enabled = true;
                    datatable = billIhspcost.costSearch(id);
                }
                else 
                {
                    btn_xf.Enabled = true;
                    btnRetAccount.Enabled = true;
                    btnRePrint.Enabled = true;
                    btnCsSign.Enabled = false;
                    btnDoChrg.Enabled = false;
                    btnAccount.Enabled = false;
                    datatable = billIhspcost.costSearchBySettle(ihsp_account_id);
                }
               
                this.dgvIhspCost.DataSource = datatable;
                #region  dgvIhspCost单元格标题设置
                dgvIhspCost.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale));
                dgvIhspCost.RowsDefaultCellStyle.Font = new Font("宋体", (float)(11 * ProgramGlobal.WidthScale));
                this.dgvIhspCost.Columns["item_id"].HeaderText = "编号";
                this.dgvIhspCost.Columns["item_id"].Width = (int)(50 * ProgramGlobal.WidthScale);
                this.dgvIhspCost.Columns["itemtypename"].HeaderText = "项目类别";
                this.dgvIhspCost.Columns["itemtypename"].Width = (int)(100 * ProgramGlobal.WidthScale);
                this.dgvIhspCost.Columns["name"].HeaderText = "名称";
                this.dgvIhspCost.Columns["name"].Width = (int)(180 * ProgramGlobal.WidthScale);
                this.dgvIhspCost.Columns["spec"].HeaderText = "规格";
                this.dgvIhspCost.Columns["spec"].Width = (int)(110 * ProgramGlobal.WidthScale);
                this.dgvIhspCost.Columns["unit"].HeaderText = "单位";
                this.dgvIhspCost.Columns["unit"].Width = (int)(50 * ProgramGlobal.WidthScale);
                this.dgvIhspCost.Columns["prc"].HeaderText = "单价";
                this.dgvIhspCost.Columns["prc"].Width = (int)(100 * ProgramGlobal.WidthScale);
                this.dgvIhspCost.Columns["prc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvIhspCost.Columns["num"].HeaderText = "数量";
                this.dgvIhspCost.Columns["num"].Width = (int)(100 * ProgramGlobal.WidthScale);
                this.dgvIhspCost.Columns["num"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvIhspCost.Columns["insurefee"].HeaderText = "报销金额";
                this.dgvIhspCost.Columns["insurefee"].Width = (int)(100 * ProgramGlobal.WidthScale);
                this.dgvIhspCost.Columns["insurefee"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvIhspCost.Columns["selffee"].HeaderText = "自费金额";
                this.dgvIhspCost.Columns["selffee"].Width = (int)(100 * ProgramGlobal.WidthScale);
                this.dgvIhspCost.Columns["selffee"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                this.dgvIhspCost.Columns["departname"].HeaderText = "项目科室";
                this.dgvIhspCost.Columns["departname"].Width = (int)(100 * ProgramGlobal.WidthScale);
                this.dgvIhspCost.Columns["insurclass"].HeaderText = "医保等级";
                this.dgvIhspCost.Columns["insurclass"].Width = (int)(100 * ProgramGlobal.WidthScale);
                this.dgvIhspCost.Columns["realfee"].HeaderText = "实际金额";
                this.dgvIhspCost.Columns["realfee"].Visible = false;
                this.dgvIhspCost.Columns["fee"].HeaderText = "金额";
                this.dgvIhspCost.Columns["fee"].Visible = false;
                #endregion
                double total = 0;
                for (int i = 0; i < datatable.Rows.Count; i++)
                {
                    string realfee = datatable.Rows[i]["fee"].ToString();
                    if (string.IsNullOrEmpty(datatable.Rows[i]["fee"].ToString()))
                    {
                        realfee = "0";
                    }
                    total += double.Parse(DataTool.FormatData(realfee, "2"));
                }
                lblTotal.Text = DataTool.FormatData(total.ToString(), "2") + "元";
            }
            else
            {
                dgvIhspCost.DataSource = null;
            }
        }

        /// <summary>
        /// 入院时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpStartTime_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Compare(this.dtpStartTime.Value, this.dtpEndTime.Value) > 0)
            {
                MessageBox.Show("错误:起始日期不能大于截止日期！");
                this.dtpStartTime.Value = dtpEndTime.Value.AddMonths(-3);
                return;
            }
        }

        private void FrmIhspOuthsp_Activated(object sender, EventArgs e)
        {
            tbxHspcard.Focus();
        }

        private void dtpEndTime_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Compare(this.dtpStartTime.Value, this.dtpEndTime.Value) > 0)
            {
                MessageBox.Show("错误:起始日期不能大于截止日期！");
                dtpEndTime.Value = Convert.ToDateTime(BillSysBase.currDate());
                this.dtpStartTime.Value = dtpEndTime.Value.AddMonths(-3);
                return;
            }
        }
        /// <summary>
        /// 费用清单预览和打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCostdetPrt_Click(object sender, EventArgs e)
        {
            string ihsp_id = "";
            
            if (dgvInhospital.Rows.Count != 0)
            {
                ihsp_id = dgvInhospital.SelectedRows[0].Cells["id"].Value.ToString();
                string ihsp_account_id = dgvInhospital.SelectedRows[0].Cells["ihsp_account_id"].Value.ToString();
                
                FrxPrintView frxPrintView = new FrxPrintView();
                frxPrintView.costdetPrt(ihsp_id, ihsp_account_id);
            }   
        }

        private void btnInsurMag_Click(object sender, EventArgs e)
        {
            FrmCxcwTscl cl = new FrmCxcwTscl();
            cl.StartPosition = FormStartPosition.CenterScreen;
            cl.ShowDialog(this);
            //FrmInsurMag frmInsurMag = new FrmInsurMag();
            //string id = dgvInhospital.SelectedRows[0].Cells["id"].Value.ToString();
            //string patienttype = dgvInhospital.SelectedRows[0].Cells["bas_patienttype_id"].Value.ToString();
            //frmInsurMag.getSource(id, patienttype);
            //frmInsurMag.ShowDialog();
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

        private void cmbStatus_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbStatus.Items.Count <= 0)
                return;
            lbl_timetitle.Text = "出院时间";
            if (cmbStatus.SelectedValue.ToString().Equals("2"))
            {
                lbl_timetitle.Text = "结算时间";
            }
        }

        private void btnNeonateAccount_Click(object sender, EventArgs e)
        {
             BllInsur bllInsur = new BllInsur();
            if (dgvInhospital.SelectedRows.Count == 0 && dgvInhospital.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            } 
            string ihsp_id=dgvInhospital.SelectedRows[0].Cells["id"].Value.ToString();
            string patienttype_id = dgvInhospital.SelectedRows[0].Cells["bas_patienttype_id"].Value.ToString();
            string keyname = bllInsur.getInsurtype(patienttype_id);
            if (keyname == CostInsurtypeKeyname.SELFCOST.ToString())//贵州省医保
            {
                MessageBox.Show("自费病人不能进行新生儿结算！");
                return;
            }
            double neonSum =DataTool.stringToDouble(billIhspAct.getHisNeonCostDetSum(ihsp_id));
            if (Math.Abs(neonSum) < 0.001)
            {
                MessageBox.Show("新生儿费用为[零],不能进行新生儿结算！");
                return;
            }
            FrmIhspAccount frmIhspAccount = new FrmIhspAccount();
            frmIhspAccount.getSource(ihsp_id, "neonate");
            frmIhspAccount.ShowDialog();
            if (frmIhspAccount.DialogResult == DialogResult.Cancel)
            {
                searchMethod();
            }
        }

        private void btn_CK_Click(object sender, EventArgs e)
        {
            BllInsur bllInsur = new BllInsur();
            if (dgvInhospital.SelectedRows.Count == 0 && dgvInhospital.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            int rowIdx = dgvInhospital.CurrentRow.Index;
            string id = dgvInhospital.SelectedRows[0].Cells["id"].Value.ToString();
            string patienttype_id = dgvInhospital.SelectedRows[0].Cells["bas_patienttype_id"].Value.ToString();
            string keyname = bllInsur.getInsurtype(patienttype_id);
            if (keyname == CostInsurtypeKeyname.HDSCH.ToString())//邯郸城合
            { 
                //SJZSYB
                FrmChCy chcy = new FrmChCy();
                chcy.Ihsp_id = id;
                chcy.Zyh_ = dgvInhospital.Rows[rowIdx].Cells["ihspcode"].Value.ToString().Trim();
                chcy.Ylkfkfs = patienttype_id;
                chcy.ShowDialog();
                if (chcy.DialogResult == DialogResult.Cancel)
                {
                    searchMethod();
                }
            }
            else if (keyname == CostInsurtypeKeyname.HDSYB.ToString())//邯郸医保
            {
                FrmYbCy chcy = new FrmYbCy();
                chcy.Ihsp_id = id;
                chcy.Zyh_ = dgvInhospital.Rows[rowIdx].Cells["ihspcode"].Value.ToString().Trim();
                chcy.Ylkfkfs = patienttype_id;
                chcy.ShowDialog();
                if (chcy.DialogResult == DialogResult.Cancel)
                {
                    searchMethod();
                }
            }
            else if (keyname == CostInsurtypeKeyname.HDSSY.ToString())//邯郸生育
            {
                FrmSyCy sycy = new FrmSyCy();
                sycy.Ihsp_id = id;
                sycy.Zyh_ = dgvInhospital.Rows[rowIdx].Cells["ihspcode"].Value.ToString().Trim();
                sycy.Ylkfkfs = patienttype_id;
                sycy.ShowDialog();
                if (sycy.DialogResult == DialogResult.Cancel)
                {
                    searchMethod();
                }
            }
            else if (keyname == CostInsurtypeKeyname.SJZSYB.ToString() || keyname == CostInsurtypeKeyname.SJZSJM.ToString())//石家庄医保
            {
                MTHIS.FrmMain fm = new MTHIS.FrmMain();
                if (fm.ybsyqx() != true)
                {
                    return;
                }
                FrmSybCy chcy = new FrmSybCy();
                chcy.Ihsp_id = id;
                chcy.Zyh_ = dgvInhospital.Rows[rowIdx].Cells["ihspcode"].Value.ToString().Trim();
                chcy.Ylkfkfs = patienttype_id;
                chcy.ShowDialog();
                if (chcy.DialogResult == DialogResult.Cancel)
                {
                    searchMethod();
                }
            }
            else if (keyname == CostInsurtypeKeyname.SELFCOST.ToString())//自费
	        {
                FrmIhspAccount frmIhspAccount = new FrmIhspAccount();
                frmIhspAccount.getSource(id);
                frmIhspAccount.ShowDialog();
                if (frmIhspAccount.DialogResult == DialogResult.Cancel)
                {
                    searchMethod();
                }
	        }
        }

        private void btn_xf_Click(object sender, EventArgs e)
        {
            int rowIdx = dgvInhospital.CurrentRow.Index;
            if (rowIdx < 0)
            {
                MessageBox.Show("请选择患者");
                return;
            }
            string id = dgvInhospital.Rows[rowIdx].Cells["id"].Value.ToString();
            string patienttypeId = dgvInhospital.Rows[rowIdx].Cells["bas_patienttype_id"].Value.ToString();
            string keyname = billIhspMan.getInsurtype(patienttypeId);


            string sql_ssn = "select ihsp_info.homephone as lxfs,ihsp_info.profession as ryzy,ihsp_info.homeaddress as rydz,ihsp_info.idcard as ssn,inhospital.age as age,inhospital.clinicdiagn as mzzd,inhospital.ihspdiagn as zyzd from inhospital,ihsp_info where inhospital.id=ihsp_info.ihsp_id and ihsp_info.registkind = 'IHSP' and inhospital.id=" + id;
            var ds = BllMain.Db.Select(sql_ssn);
            string ssn = "";
            if (ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
            {
                ssn = ds.Tables[0].Rows[0]["ssn"].ToString().Trim();
            }
            string sql = "select bas_doctor.name as doctorname"
                      + ",bas_sickroom.name as sickroomname"
                      + ",bas_sickbed.name as sickbedname"
                      + " from inhospital "
                      + " left join bas_doctor on inhospital.doctor_id=bas_doctor.id "
                      + " left join bas_sickroom on inhospital.sickroom_id=bas_sickroom.id "
                      + " left join bas_sickbed on inhospital.sickbed_id=bas_sickbed.id "
                      + " where 1=1"
                      + " and inhospital.id=" + id;
            var da = BllMain.Db.Select(sql);
            if (keyname == CostInsurtypeKeyname.HDSYB.ToString())
            {
                FrmYbRy ybry = new FrmYbRy();
                ybry.Zfrydj.Zyh = dgvInhospital.Rows[rowIdx].Cells["ihspcode"].Value.ToString();//住院号
                ybry.Zfrydj.Brxm = dgvInhospital.Rows[rowIdx].Cells["ihspname"].Value.ToString();//姓名
                ybry.Zfrydj.Bch = da.Tables[0].Rows[0]["sickbedname"].ToString().Trim();//病床号
                ybry.Zfrydj.Bfh = da.Tables[0].Rows[0]["sickroomname"].ToString().Trim();//病房号
                ybry.Zfrydj.Ysname = da.Tables[0].Rows[0]["doctorname"].ToString().Trim();//医生名字
                ybry.Zfrydj.Ryks = dgvInhospital.Rows[rowIdx].Cells["deparname"].Value.ToString();//科室
                ybry.Zfrydj.Rysj = dgvInhospital.Rows[rowIdx].Cells["indate"].Value.ToString();//入院时间
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
                chry.Zfrydj.Zyh = dgvInhospital.Rows[rowIdx].Cells["ihspcode"].Value.ToString();//住院号
                chry.Zfrydj.Brxm = dgvInhospital.Rows[rowIdx].Cells["ihspname"].Value.ToString();//姓名
                chry.Zfrydj.Bch = da.Tables[0].Rows[0]["sickbedname"].ToString().Trim();//病床号
                chry.Zfrydj.Bfh = da.Tables[0].Rows[0]["sickroomname"].ToString().Trim();//病房号
                chry.Zfrydj.Ysname = da.Tables[0].Rows[0]["doctorname"].ToString().Trim();//医生名字
                chry.Zfrydj.Ryks = dgvInhospital.Rows[rowIdx].Cells["deparname"].Value.ToString();//科室
                chry.Zfrydj.Rysj = dgvInhospital.Rows[rowIdx].Cells["indate"].Value.ToString();//入院时间
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
                syry.Zfrydj.Zyh = dgvInhospital.Rows[rowIdx].Cells["ihspcode"].Value.ToString();//住院号
                syry.Zfrydj.Brxm = dgvInhospital.Rows[rowIdx].Cells["ihspname"].Value.ToString();//姓名
                syry.Zfrydj.Bch = da.Tables[0].Rows[0]["sickbedname"].ToString().Trim();//病床号
                syry.Zfrydj.Bfh = da.Tables[0].Rows[0]["sickroomname"].ToString().Trim();//病房号
                syry.Zfrydj.Ysname = da.Tables[0].Rows[0]["doctorname"].ToString().Trim();//医生名字
                syry.Zfrydj.Ryks = dgvInhospital.Rows[rowIdx].Cells["deparname"].Value.ToString();//科室
                syry.Zfrydj.Rysj = dgvInhospital.Rows[rowIdx].Cells["indate"].Value.ToString();//入院时间
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
            
        }
    }
}
