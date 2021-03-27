using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.ihsp.bo;
using MTREG.ihsp.bll;
using MTREG.ihsptab.bo;
using MTREG.ihsptab.bll;
using MTREG.common;

namespace MTREG.ihsptab
{
    public partial class FrmHspAdjustByDoctor : Form
    {
        DepDocAcc depDocAcc = new DepDocAcc();
        BllFrxOper billFrxOper = new BllFrxOper();
        public FrmHspAdjustByDoctor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 住院查询/打印方法
        /// </summary>
        public void ihspSearchMethod()
        {
            depDocAcc.Depart = cmbIhspDoc.Text.Trim();
            if (depDocAcc.Depart == "--全部--")
            {
                depDocAcc.Depart = "全部科室";
            }
            depDocAcc.Departid = cmbIhspDoc.SelectedValue.ToString();
            depDocAcc.EndTime = dtpIhspEt.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            depDocAcc.StartTime = dtpIhspSt.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            depDocAcc.Itemtype1 = cmbIhspItem.Text.Trim();
            if (depDocAcc.Itemtype1 == "--全部--")
            {
                depDocAcc.Itemtype1 = "全部类型";
            }
            depDocAcc.Itemtype1id = cmbIhspItem.SelectedValue.ToString();
            depDocAcc.Tablename = "ihsptab_costgather";
        }

        /// <summary>
        /// 出院查询/打印方法
        /// </summary>
        public void ohspSearchMethod()
        {
            depDocAcc.Depart = cmbOhspDoc.Text.Trim();
            if (depDocAcc.Depart == "--全部--")
            {
                depDocAcc.Depart = "全部科室";
            }
            depDocAcc.Departid = cmbOhspDoc.SelectedValue.ToString();
            depDocAcc.EndTime = dtpOhspEt.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            depDocAcc.StartTime = dtpOhspSt.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            depDocAcc.Itemtype1 = cmbOhspItem.Text.Trim();
            if (depDocAcc.Itemtype1 == "--全部--")
            {
                depDocAcc.Itemtype1 = "全部类型";
            }
            depDocAcc.Itemtype1id = cmbOhspItem.SelectedValue.ToString();
            depDocAcc.Tablename = "ihsptab_outcostgather";          
        }
        /// <summary>
        /// 住院查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIhspSearch_Click(object sender, EventArgs e)
        {
            ihspSearchMethod();
            FrxPrintView frxPrintView = new FrxPrintView(this.rptIPreviewCtrl);
            frxPrintView.ihspInDocAcc(depDocAcc, "view", billFrxOper.getPrintFrmurl(SysPrintCodeid.IIDoA.ToString()).Rows[0]["frmurl"].ToString());
        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmDoctorAcc_Load(object sender, EventArgs e)
        {
            tcDoc.SelectedTab = tpIhspDoc;
            #region cmb设置
            BillCmbList billCmbList = new BillCmbList();
            this.cmbIhspDoc.ValueMember = "id";
            this.cmbIhspDoc.DisplayMember = "name";
            this.cmbOhspDoc.ValueMember = "id";
            this.cmbOhspDoc.DisplayMember = "name";
            var dtde = billCmbList.departList();
            var drde = dtde.NewRow();
            drde["Id"] = 0;
            drde["Name"] = "--全部--";
            dtde.Rows.InsertAt(drde, 0);
            this.cmbIhspDoc.DataSource = dtde;
            this.cmbOhspDoc.DataSource = dtde;

            this.cmbIhspItem.ValueMember = "id";
            this.cmbIhspItem.DisplayMember = "name";
            this.cmbOhspItem.ValueMember = "id";
            this.cmbOhspItem.DisplayMember = "name";
            var dtit = billCmbList.itemtype1List();
            var drit = dtit.NewRow();
            drit["Id"] = 0;
            drit["Name"] = "--全部--";
            dtit.Rows.InsertAt(drit, 0);
            this.cmbIhspItem.DataSource = dtit;
            this.cmbOhspItem.DataSource = dtit;
            #endregion
            ihspSearchMethod();
            FrxPrintView frxPrintView = new FrxPrintView(this.rptIPreviewCtrl);
            frxPrintView.ihspInDocAcc(depDocAcc, "view", billFrxOper.getPrintFrmurl(SysPrintCodeid.IIDoA.ToString()).Rows[0]["frmurl"].ToString());
        }

        /// <summary>
        /// 出院查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOhspSearch_Click(object sender, EventArgs e)
        {
            ohspSearchMethod();
            FrxPrintView frxPrintView = new FrxPrintView(this.rptOPreviewCtrl);
            frxPrintView.ihspInDocAcc(depDocAcc, "view", billFrxOper.getPrintFrmurl(SysPrintCodeid.IODoA.ToString()).Rows[0]["frmurl"].ToString());
        }
        
        /// <summary>
        /// 出院打印按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOhspPrint_Click(object sender, EventArgs e)
        {
            ohspSearchMethod();
            FrxPrintView frxPrintView = new FrxPrintView(this.rptOPreviewCtrl);
            frxPrintView.ihspInDocAcc(depDocAcc, "print", billFrxOper.getPrintFrmurl(SysPrintCodeid.IODoA.ToString()).Rows[0]["frmurl"].ToString());
        }

        /// <summary>
        /// 在院打印按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIhspPrint_Click(object sender, EventArgs e)
        {
            ihspSearchMethod();
            FrxPrintView frxPrintView = new FrxPrintView(this.rptIPreviewCtrl);
            frxPrintView.ihspInDocAcc(depDocAcc, "print", billFrxOper.getPrintFrmurl(SysPrintCodeid.IIDoA.ToString()).Rows[0]["frmurl"].ToString());
        }

        /// <summary>
        /// 页面切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tcDoc_Selected(object sender, TabControlEventArgs e)
        {
            if (tcDoc.SelectedTab == tpIhspDoc)
            {
                ihspSearchMethod();
                FrxPrintView frxPrintView = new FrxPrintView(this.rptIPreviewCtrl);
                frxPrintView.ihspInDocAcc(depDocAcc, "view", billFrxOper.getPrintFrmurl(SysPrintCodeid.IIDoA.ToString()).Rows[0]["frmurl"].ToString());
            }
            else if (tcDoc.SelectedTab == tpOhspDoc)
            {
                ohspSearchMethod();
                FrxPrintView frxPrintView = new FrxPrintView(this.rptOPreviewCtrl);
                frxPrintView.ihspInDocAcc(depDocAcc, "view", billFrxOper.getPrintFrmurl(SysPrintCodeid.IODoA.ToString()).Rows[0]["frmurl"].ToString());
            }
        }
    }
}
