using System;
using System.Data;
using System.Windows.Forms;
using MTHIS.common;
using MTREG.ihsp.bll;
using MTREG.common;
using MTREG.ihsp.bo;
using MTREG.ihsptab.bo;

namespace MTREG.ihsp
{
    public partial class FrmIhspGua : Form
    {
        BillCmbList billCmbList = new BillCmbList();
        BillIhspMan billIhspMan = new BillIhspMan();
        BillIhspcost billIhspcost = new BillIhspcost();
        /// <summary>
        /// 控制listbox显示
        /// </summary>
        bool isleave = false;
        string thisid;
        int flag;
        int i = 0;
        DataTable dtbr = new DataTable();
        public FrmIhspGua()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 从FrmIhspMan中获取信息
        /// </summary>
        /// <param name="source"></param>
        public void getSource(string id)
        {
            this.thisid = id;
            DataTable dt = billIhspcost.ihspIdSearch(id);
            if (dt.Rows.Count>0)
            {
                this.lblIhspcode.Text = dt.Rows[0]["ihspcode"].ToString();
                this.lblName.Text = dt.Rows[0]["ihspname"].ToString();
                this.lblSex.Text = dt.Rows[0]["sex"].ToString();
                this.lblDepart.Text = dt.Rows[0]["deparname"].ToString();
                this.lblAge.Text = dt.Rows[0]["age"].ToString() + dt.Rows[0]["unitName"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["moonage"].ToString()) && dt.Rows[0]["moonage"].ToString()!="0")
                {
                    this.lblAge.Text = dt.Rows[0]["age"].ToString() + dt.Rows[0]["unitName"].ToString() + " " + dt.Rows[0]["moonage"].ToString() + "月";
                }
            }
            dtbr = dt;
        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmIhspGua_Load(object sender, EventArgs e)
        {
            #region combox 绑定数据
            var dtd = billIhspMan.getAllDoctorByDepart("");//billCmbList.doctorList();
            this.cmbDoctor.ValueMember = "id";
            this.cmbDoctor.DisplayMember = "name";
            DataRow drdo = dtd.NewRow();
            drdo["id"] = 0;
            drdo["name"] = "--请选择--";
            dtd.Rows.InsertAt(drdo, 0);
            this.cmbDoctor.DataSource = dtd;

            var dtde = billCmbList.departList();
            this.cmbDepart.ValueMember = "id";
            this.cmbDepart.DisplayMember = "name";
            DataRow dr = dtde.NewRow();
            dr["id"] = 0;
            dr["name"] = "--请选择--";
            dtde.Rows.InsertAt(dr, 0);
            this.cmbDepart.DataSource = dtde;
        
            #endregion
            DataTable dataTable = billIhspMan.guaSearch(thisid);
            this.dgvGuarantee.DataSource = dataTable;
            #region dgv标题设置
            this.dgvGuarantee.Columns["ihspcode"].HeaderText = "住院号";
            this.dgvGuarantee.Columns["ihspcode"].Width = 100;
            this.dgvGuarantee.Columns["ihsp_name"].HeaderText = "姓名";
            this.dgvGuarantee.Columns["ihsp_name"].Width = 100;
            this.dgvGuarantee.Columns["doctor_name"].HeaderText = "担保人";
            this.dgvGuarantee.Columns["doctor_name"].Width =100;
            this.dgvGuarantee.Columns["depart_name"].HeaderText = "担保人科室";
            this.dgvGuarantee.Columns["depart_name"].Width = 140;
            this.dgvGuarantee.Columns["amt"].HeaderText = "担保金额";
            this.dgvGuarantee.Columns["amt"].Width = 100;
            this.dgvGuarantee.Columns["enddate"].HeaderText = "担保期限";
            this.dgvGuarantee.Columns["enddate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            this.dgvGuarantee.Columns["enddate"].Width = 120;
            this.dgvGuarantee.Columns["delstat"].HeaderText = "是否作废";
            this.dgvGuarantee.Columns["delstat"].DefaultCellStyle.Format = "yyyy-MM-dd";
            this.dgvGuarantee.Columns["delstat"].Width = 80;            
            this.dgvGuarantee.Columns["id"].HeaderText = "id";
            this.dgvGuarantee.Columns["id"].Visible = false;
            #endregion
            this.dgvGuarantee.ReadOnly = true;
            this.dgvGuarantee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.cmbDepart.SelectedValue = dtbr.Rows[0]["depart_id"].ToString();
        }

        /// <summary>
        /// 担保按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGua_Click(object sender, EventArgs e)
        {
            gua();
        }
        /// <summary>
        /// 担保
        /// </summary>
        public void gua()
        {
            if (tbxAmt.Text == "")
            {
                MessageBox.Show("担保金额不能为空!");
                this.tbxAmt.Focus();
                return;
            }
            if (cmbDepart.SelectedValue == null || cmbDepart.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("担保科室不能为空!");
                this.cmbDepart.Focus();
                return;
            }
            if (cmbDoctor.SelectedValue == null || cmbDoctor.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("担保人不能为空!");
                this.cmbDoctor.Focus();
                this.cmbDoctor.DroppedDown = true;
                return;
            }

            Ihspguaranfee ihspguaranfee = new Ihspguaranfee();
            ihspguaranfee.Id = BillSysBase.nextId("ihsp_guaranfee");
            ihspguaranfee.Ihspid = thisid;
            ihspguaranfee.Depart = cmbDepart.SelectedValue.ToString().Trim();//tbxDepCode.Text.Trim().ToString();
            ihspguaranfee.Doctor = cmbDoctor.SelectedValue.ToString();
            ihspguaranfee.Enddate = this.dtpEnddate.Value.ToString("yyyy-MM-dd")+" 23:59:59";
            ihspguaranfee.Memo = tbxMemo.Text.Trim().ToString();
            ihspguaranfee.Createdby = ProgramGlobal.User_id;
            ihspguaranfee.Amt = tbxAmt.Text.Trim().ToString();
            
            flag = billIhspMan.inGua(ihspguaranfee);
            if (flag == -1)
            {
                MessageBox.Show("添加失败");
            }
            tbxAmt.Focus();
            tbxAmt.Clear();
            if (MessageBox.Show("是否打印担保凭证?", "提示信息", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                FrxPrintView frxPrintView = new FrxPrintView();
                frxPrintView.getIhspGua(ihspguaranfee.Id);
            }
            DataTable dataTable = billIhspMan.guaSearch(thisid);
            this.dgvGuarantee.DataSource = dataTable;
        }

        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRet_Click(object sender, EventArgs e)
        {
            if (dgvGuarantee.SelectedRows[0].Cells["delstat"].Value.ToString() == "Y")
            {
                MessageBox.Show("担保已作废！");
                return;
            }
            ret();
        }
        /// <summary>
        /// 删除
        /// </summary>
        public void ret()
        {
            if (dgvGuarantee.SelectedRows.Count == 0 && dgvGuarantee.SelectedCells.Count == 0)
            {
                MessageBox.Show("请先在列表中选择");
                return;
            }
            string id = dgvGuarantee.SelectedRows[0].Cells["id"].Value.ToString();
            string amt = dgvGuarantee.SelectedRows[0].Cells["amt"].Value.ToString();
            DialogResult r1 = MessageBox.Show("是否撤销" + lblName.Text + "的金额为" + amt + "的担保记录", "撤销提示", MessageBoxButtons.YesNo);
            if (r1.ToString() == "Yes")
            {
                flag = billIhspMan.guaBtnRet(id);
                if (flag == -1)
                {
                    MessageBox.Show("撤销担保失败");
                }
                else
                {
                    MessageBox.Show("撤销担保成功");
                }
            }
            tbxAmt.Focus();
            DataTable dataTable = billIhspMan.guaSearch(thisid);
            this.dgvGuarantee.DataSource = dataTable;
        }

        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 根据选择绑定下拉菜单
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="comObject"></param>
        private void bindComboxData(DataTable dt, ComboBox comObject)
        {
            comObject.DisplayMember = "name";
            comObject.ValueMember = "id";
            try
            {
                DataRow dr = dt.NewRow();
                dr["id"] = 0;
                dr["name"] = "--请选择--";
                dt.Rows.InsertAt(dr, 0);
                comObject.DataSource = dt;
                comObject.SelectedValue = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void FrmIhspGua_Activated(object sender, EventArgs e)
        {
            cmbDepart.Focus();
        }


        ///<summary>
        ///当点击回车键时，焦点在控件中一次传递
        ///</summary>
        ///<param name="keyData"></param>
        ///<returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if ((ActiveControl is Button) && (keyData == Keys.Enter))
            {
                keyData = Keys.Tab;
            }
            return base.ProcessDialogKey(keyData);
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
                DataTable dtde = billCmbList.departList(dep);
                //重新绑定
                DataRow dr = dtde.NewRow();
                dr["id"] = 0;
                dr["name"] = "--请选择--";
                dtde.Rows.InsertAt(dr, 0);
                cmbDepart.DataSource = dtde;
                cmbDepart.Text = dep;

                cmbDepart.DroppedDown = true; //打开下拉框
                cmbDepart.SelectionStart = l; //定位光标至修改时的位置
                this.Cursor = System.Windows.Forms.Cursors.Default; //显示鼠标
            }
            else if (e.KeyCode == Keys.Enter)
            {
                cmbDoctor.Focus();
            }
        }

        private void cmbDoctor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpEnddate.Focus();
            }
        }

        private void dtpEnddate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                i++;
                SendKeys.Send("{right}");
                if (i == 3)
                {
                    SendKeys.Send("{tab}");
                    i = 0;
                }
            }
        }

        private void tbxAmt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbxMemo.Focus();
            }
        }

        private void tbxMemo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGua.Focus();
            }
        }

        private void btnGua_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gua();
            }
        }

        private void btnRet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                ret();
            }
        }

        private void btnClose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                this.Close();
            }
        }

        private void cmbDepart_SelectedValueChanged(object sender, EventArgs e)
        {
            //根据科室修改医生
            if (null != cmbDepart.SelectedValue && cmbDepart.SelectedValue.ToString() != "0")
            {
                String departid = cmbDepart.SelectedValue.ToString().Trim();
                bindComboxData(billIhspMan.getAllDoctorByDepart(departid), cmbDoctor);
            }
        }

        private void dgvGuarantee_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.dgvGuarantee.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请选择担保！");
                return;
            }
            FrxPrintView frxPrintView = new FrxPrintView();
            frxPrintView.getIhspGua(this.dgvGuarantee.SelectedRows[0].Cells["id"].Value.ToString());
        }
    }
}
