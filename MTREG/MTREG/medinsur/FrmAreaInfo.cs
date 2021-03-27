using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.bll;
using MTREG.medinsur.bo;

namespace MTREG.medinsur
{
    public partial class FrmAreaInfo : Form
    {
        BllInsurMethod bllInsurMethod = new BllInsurMethod();
        AreaInfo areaInfo=new AreaInfo();

        internal AreaInfo AreaInfo
        {
            get { return areaInfo; }
            set { areaInfo = value; }
        }
        public FrmAreaInfo()
        {
            InitializeComponent();
        }

        private void FrmAreaInfo_Load(object sender, EventArgs e)
        {
            init();
            searchMethod();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public void init()
        {
            DataTable dtInsur= bllInsurMethod.insurtypeInfo();            
            cmbInsurtype.DisplayMember = "name";
            cmbInsurtype.ValueMember = "id";
            cmbInsurtype.DataSource = dtInsur;
        }
        /// <summary>
        ///  查询
        /// </summary>
        public void searchMethod()
        {
            dgvAreaInfo.Columns.Clear();
            DataTable dt= bllInsurMethod.allAreaInfo(cmbInsurtype.SelectedValue.ToString(),tbxInfo.Text);
            dgvAreaInfo.DataSource = dt;
            this.dgvAreaInfo.Columns["insurname"].HeaderText = "接口名称";
            this.dgvAreaInfo.Columns["areaname"].HeaderText = "区域名称";
            this.dgvAreaInfo.Columns["areacode"].HeaderText = "区域编码";
            this.dgvAreaInfo.Columns["insuritemtype"].HeaderText = "医保目录类型码";
            this.dgvAreaInfo.Columns["memo"].HeaderText = "备注";
            this.dgvAreaInfo.Columns["cost_insurtype_id"].HeaderText = "接口ID";
            this.dgvAreaInfo.Columns["cost_insurtype_id"].Visible = false;
            this.dgvAreaInfo.Columns["id"].HeaderText = "ID";
            this.dgvAreaInfo.Columns["id"].Visible = false;
            dgvAreaInfo.ReadOnly = true;
            dgvbutton();
            
        }

        /// <summary>
        /// dgv按钮列声明
        /// </summary>
        public void dgvbutton()
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "编辑";
            btn.Text = "编辑";
            btn.InheritedStyle.NullValue = "编辑";
            btn.Width = 100;
            btn.UseColumnTextForButtonValue = true;
            btn.Frozen = false;
            dgvAreaInfo.AutoGenerateColumns = true;
            dgvAreaInfo.Columns.Insert(dgvAreaInfo.ColumnCount-1, btn);
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            searchMethod();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAreaInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn column = dgvAreaInfo.Columns[dgvAreaInfo.CurrentCell.ColumnIndex];
            if (column is DataGridViewButtonColumn && column.Name == "编辑")
            {
                string i = dgvAreaInfo.Rows[e.RowIndex].Cells["areacode"].Value.ToString();
                this.AreaInfo.Areacode = dgvAreaInfo.Rows[e.RowIndex].Cells["areacode"].Value.ToString();
                this.AreaInfo.Areaname = dgvAreaInfo.Rows[e.RowIndex].Cells["insurname"].Value.ToString();
                this.AreaInfo.Memo = dgvAreaInfo.Rows[e.RowIndex].Cells["memo"].Value.ToString();
                this.AreaInfo.Insuritemtype = dgvAreaInfo.Rows[e.RowIndex].Cells["insuritemtype"].Value.ToString();
                this.AreaInfo.Cost_insurtype_id = dgvAreaInfo.Rows[e.RowIndex].Cells["cost_insurtype_id"].Value.ToString();
                this.AreaInfo.Id = dgvAreaInfo.Rows[e.RowIndex].Cells["id"].Value.ToString();
                FrmAreaInfodet frmAreaInfodet = new FrmAreaInfodet();
                frmAreaInfodet.FrmAreaInfo = this;
                frmAreaInfodet.ShowDialog();
                searchMethod();
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {

        }
    }
}
