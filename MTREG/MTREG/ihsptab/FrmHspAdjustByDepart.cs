using System;
using System.Windows.Forms;
using MTREG.ihsp.bll;
using MTREG.ihsptab.bo;
using MTREG.common;
using MTREG.ihsptab.bll;
using System.Data;

namespace MTREG.ihsptab
{
    public partial class FrmHspAdjustByDepart : Form
    {
        BllFrxOper billFrxOper = new BllFrxOper();
        DepDocAcc depDocAcc = new DepDocAcc();
        public FrmHspAdjustByDepart()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 住院查询/打印方法
        /// </summary>
        public void ihspSearchMethod()
        {
            depDocAcc.Depart = cmbIhspDep.Text;
            if (depDocAcc.Depart == "--全部--")
            {
                depDocAcc.Depart = "全部科室";
            }
            depDocAcc.Departid = cmbIhspDep.SelectedValue.ToString();
            depDocAcc.EndTime = dtpIhspEt.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            depDocAcc.StartTime = dtpIhspSt.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            depDocAcc.Itemtype1 = cmbIhspItem.Text.Trim();
            if (depDocAcc.Itemtype1 == "--全部--")
            {
                depDocAcc.Itemtype1 = "全部类型";
            }
            depDocAcc.Itemtype1id = cmbIhspItem.SelectedValue.ToString();
            depDocAcc.Patienttype = cmbIhspPt.Text.Trim();
            if (depDocAcc.Patienttype == "--全部--")
            {
                depDocAcc.Patienttype = "全部付款类型";
            }
            depDocAcc.Patienttypeid = cmbIhspPt.SelectedValue.ToString();
            depDocAcc.Tablename = "ihsptab_costgather";
        }

        /// <summary>
        /// 出院查询/打印方法
        /// </summary>
        public void ohspSearchMethod()
        {
            depDocAcc.Depart = cmbOhspDep.Text.Trim();
            if (depDocAcc.Depart == "--全部--")
            {
                depDocAcc.Depart = "全部科室";
            }
            depDocAcc.Departid = cmbOhspDep.SelectedValue.ToString();
            depDocAcc.EndTime = dtpOhspEt.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            depDocAcc.StartTime = dtpOhspSt.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            depDocAcc.Itemtype1 = cmbOhspItem.Text.Trim();
            if (depDocAcc.Itemtype1 == "--全部--")
            {
                depDocAcc.Itemtype1 = "全部类型";
            }
            depDocAcc.Itemtype1id = cmbOhspItem.SelectedValue.ToString();
            depDocAcc.Patienttype = cmbOhspPt.Text.Trim();
            if (depDocAcc.Patienttype == "--全部--")
            {
                depDocAcc.Patienttype = "全部付款类型";
            }
            depDocAcc.Patienttypeid = cmbOhspPt.SelectedValue.ToString();
            depDocAcc.Tablename = "ihsptab_outcostgather";
        }

        /// <summary>
        /// 在院查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIhspSearch_Click(object sender, EventArgs e)
        {
            ihspSearchMethod();
            FrxPrintView frxPrintView = new FrxPrintView(this.rptIPreviewCtrl);
            frxPrintView.ihspInDepAcc(depDocAcc, "view", billFrxOper.getPrintFrmurl(SysPrintCodeid.IIDeA.ToString()).Rows[0]["frmurl"].ToString());
        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmDepartAcc_Load(object sender, EventArgs e)
        {
            tcDep.SelectedTab = tpIhspDep;
            #region cmb设置
            BillCmbList billCmbList=new BillCmbList();
            DataTable dtde = billCmbList.departList();
            if (dtde.Rows.Count > 0)
            {
                this.cmbIhspDep.ValueMember = "id";
                this.cmbIhspDep.DisplayMember = "name";
                this.cmbOhspDep.ValueMember = "id";
                this.cmbOhspDep.DisplayMember = "name";
                var drde = dtde.NewRow();
                drde["Id"] = 0;
                drde["Name"] = "--全部--";
                dtde.Rows.InsertAt(drde, 0);
                this.cmbIhspDep.DataSource = dtde;
                this.cmbOhspDep.DataSource = dtde;
            }

            DataTable dtp = billCmbList.patientTypeList();
            if (dtp.Rows.Count > 0)
            {
                this.cmbIhspPt.ValueMember = "id";
                this.cmbIhspPt.DisplayMember = "name";
                this.cmbOhspPt.ValueMember = "id";
                this.cmbOhspPt.DisplayMember = "name";
                var drp = dtp.NewRow();
                drp["Id"] = 0;
                drp["Name"] = "--全部--";
                dtp.Rows.InsertAt(drp, 0);
                this.cmbIhspPt.DataSource = dtp;
                this.cmbOhspPt.DataSource = dtp;
            }

            DataTable dtit = billCmbList.itemtype1List();
            if (dtit.Rows.Count > 0)
            {
                this.cmbIhspItem.ValueMember = "id";
                this.cmbIhspItem.DisplayMember = "name";
                this.cmbOhspItem.ValueMember = "id";
                this.cmbOhspItem.DisplayMember = "name";
                var drit = dtit.NewRow();
                drit["Id"] = 0;
                drit["Name"] = "--全部--";
                dtit.Rows.InsertAt(drit, 0);
                this.cmbIhspItem.DataSource = dtit;
                this.cmbOhspItem.DataSource = dtit;
            }
            #endregion
            ihspSearchMethod();
            FrxPrintView frxPrintView = new FrxPrintView(this.rptIPreviewCtrl);
            frxPrintView.ihspInDepAcc(depDocAcc, "view", billFrxOper.getPrintFrmurl(SysPrintCodeid.IIDeA.ToString()).Rows[0]["frmurl"].ToString());
        }

        /// <summary>
        /// 页面变化时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tcDep_Selected(object sender, TabControlEventArgs e)
        {
            if (tcDep.SelectedTab == tpIhspDep)
            {
                ihspSearchMethod();
                FrxPrintView frxPrintView = new FrxPrintView(this.rptIPreviewCtrl);
                frxPrintView.ihspInDepAcc(depDocAcc, "view", billFrxOper.getPrintFrmurl(SysPrintCodeid.IIDeA.ToString()).Rows[0]["frmurl"].ToString());
            }
            else if (tcDep.SelectedTab == tpOhspDep)
            {
                ohspSearchMethod();
                FrxPrintView frxPrintView = new FrxPrintView(this.rptOPreviewCtrl);
                frxPrintView.ihspInDepAcc(depDocAcc, "view", billFrxOper.getPrintFrmurl(SysPrintCodeid.IODeA.ToString()).Rows[0]["frmurl"].ToString());
            }
        }

        /// <summary>
        /// 在院打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIhspPrint_Click(object sender, EventArgs e)
        {
            ihspSearchMethod();
            FrxPrintView frxPrintView = new FrxPrintView(this.rptIPreviewCtrl);
            frxPrintView.ihspInDepAcc(depDocAcc, "print", billFrxOper.getPrintFrmurl(SysPrintCodeid.IIDeA.ToString()).Rows[0]["frmurl"].ToString());
        }

        /// <summary>
        /// 出院打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOhspPrint_Click(object sender, EventArgs e)
        {
            ohspSearchMethod();
            FrxPrintView frxPrintView = new FrxPrintView(this.rptOPreviewCtrl);
            frxPrintView.ihspInDepAcc(depDocAcc, "print", billFrxOper.getPrintFrmurl(SysPrintCodeid.IODeA.ToString()).Rows[0]["frmurl"].ToString());
        }

        /// <summary>
        /// 出院查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOhspSearch_Click(object sender, EventArgs e)
        {
            ohspSearchMethod();
            FrxPrintView frxPrintView = new FrxPrintView(this.rptIPreviewCtrl);
            frxPrintView.ihspInDepAcc(depDocAcc, "view", billFrxOper.getPrintFrmurl(SysPrintCodeid.IODeA.ToString()).Rows[0]["frmurl"].ToString());
        }
    }
}
