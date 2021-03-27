using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.hsdryb.bll;
using MTREG.medinsur.hsdryb.bo;
using MTHIS.common;

namespace MTREG.medinsur.hsdryb
{
    public partial class FrmDiseaseCaseHSDR : Form
    {
        public FrmDiseaseCaseHSDR()
        {
            InitializeComponent();
        }
        private string insurtype_id;

        public string Insurtype_id
        {
            get { return insurtype_id; }
            set { insurtype_id = value; }
        }
        BllItemCrossHSDR bllItemCrossHSDR = new BllItemCrossHSDR();
        private void FrmDiseaseCaseHSDR_Load(object sender, EventArgs e)
        {
            loadDataGrid();
            #region updateHeaderText
            dgvInsurDisease.Font = new Font("宋体", 12, (System.Drawing.FontStyle.Bold));
            dgvInsurDisease.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInsurDisease.Columns["name"].HeaderText = "疾病名称";
            dgvInsurDisease.Columns["name"].DisplayIndex = 1;
            dgvInsurDisease.Columns["name"].Width = 140;
            dgvInsurDisease.Columns["illcode"].HeaderText = "疾病编码";
            dgvInsurDisease.Columns["illcode"].DisplayIndex = 0;
            dgvInsurDisease.Columns["illcode"].Width = 200;
            dgvInsurDisease.Columns["pincode"].HeaderText = "pincode";
            dgvInsurDisease.Columns["pincode"].Width = 200;
            dgvInsurDisease.Columns["pincode"].DisplayIndex = 2;
            dgvInsurDisease.Columns["id"].Visible = false;
            dgvInsurDisease.ReadOnly = true;
            dgvInsurDisease.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            #endregion
        }
        private void loadDataGrid()
        {
            dgvInsurDisease.DataSource = bllItemCrossHSDR.getDiseaseInfo(Insurtype_id);
        }

        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            TopParameter common = new TopParameter();
            common.AKA130 = "0";
            common.MSGNO = "1711";
            common.AKB020 = "WYH001";
            common.AKC190 = "0";
            common.AKC020 = "0";
            common.MSGID = WYJK.getLsh();
            common.GRANTID = "WYH001";
            common.OPERID = "WYH001";// Global.MyuserId;
            common.OPERNAME = "WYH001";// Global.Myuser;
            common.BATNO = ProgramGlobal.Othvar_1;
            common.INPUT = "<PAGECNT>1</PAGECNT>";
            common.KC22XML = "";
           
            WYJK wyjk = new WYJK();
            DataTable temdt = new DataTable();

            var temopt = wyjk.bzxxcx(common,out temdt);
            if (temopt.ReturnNum == "-1")
            {
                MessageBox.Show("调用医保接口失败：" + temopt.ErrorMsg);
            }
            else
            {
                int res = bllItemCrossHSDR.clearInsurillness(Insurtype_id);
                if (res == -1)
                {
                    MessageBox.Show("清空医保疾病分类表失败");
                }
                int n = 0;
                for (n = 1; n <= Convert.ToInt32(temdt.Rows[0]["PAGESIZE"].ToString());n++ )
                {
                    DataTable dt = new DataTable();
                    common.INPUT = string.Format("<PAGECNT>{0}</PAGECNT>",n.ToString());
                    var opt = wyjk.bzxxcx(common,out dt);
                    if (dt == null)
                    {
                        break;
                    }
                    if (opt.ReturnNum != "-1")
                    {
                        bllItemCrossHSDR.updateInsurillness(n, dt, Insurtype_id);
                    }
                    else
                    {
                        MessageBox.Show("调用医保接口失败：" + opt.ErrorMsg);
                    }
                }
                if(n == Convert.ToInt32(temdt.Rows[0]["PAGESIZE"].ToString()))
                {
                    MessageBox.Show("更新病种信息" + n + "页成功");
                }
            }
            loadDataGrid();
        }
    }
}
