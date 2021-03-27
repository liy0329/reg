using System;
using System.Data;
using System.Windows.Forms;
using MTHIS.common;
using MTREG.ihsptab.bo;
using MTREG.ihsptab.bll;

namespace MTREG.ihsptab
{
    public partial class FrmPreView : Form
    {
        public FrmPreView()
        {
            InitializeComponent();
        }
        Ihsptab ihsptab = new Ihsptab();

        internal Ihsptab Ihsptab
        {
            get { return ihsptab; }
            set { ihsptab = value; }
        }
        private const string ihspTabForCharger = "住院收费员明细日结表";
        private const string ihspTabForChargerAmt = "住院收费员汇总日结表";
        private const string ihspTabCostAmt = "出院收入汇总日结表";

        public void init()
        {
            lvPreviewItem.Clear();
            this.lvPreviewItem.BeginUpdate();            
            this.lvPreviewItem.EndUpdate();
            this.lvPreviewItem.View = View.List;
        }

        private void addItem(string text)
        {
            ListViewItem viewItem = new ListViewItem();
            viewItem.Text = text;
            this.lvPreviewItem.Items.Add(viewItem);
        }

        private void FrmPreView_Load(object sender, EventArgs e)
        {
            init();
            if (ihsptab.Paytype == "tab")
            {
                addItem(ihspTabForCharger);
                addItem(ihspTabForChargerAmt);
                addItem(ihspTabCostAmt);
            }
            else 
            {
                addItem(ihspTabForCharger);
                addItem(ihspTabForChargerAmt);
            }            
        }

        private void lvPreviewItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvPreviewItem.SelectedItems.Count == 0) { return; }
            string selectedText = this.lvPreviewItem.SelectedItems[0].Text;
            FrxPrintView frxPrintView = new FrxPrintView(this.rptPreviewCtrl);
            string id = ihsptab.Id;
            string stardate = Convert.ToDateTime(ihsptab.Startdate).ToString("yyyy-MM-dd");
            string enddate = Convert.ToDateTime(ihsptab.Enddate).ToString("yyyy-MM-dd");
            string paytype = ihsptab.Paytype;
            string depart_id = Ihsptab.Depart_id;
            switch (selectedText)
            {
                case ihspTabForCharger:
                    frxPrintView.ihspTabForCharger(id, stardate, enddate, paytype, "view");
                    break;
                case ihspTabForChargerAmt:
                    frxPrintView.ihspTabForChargerAmt(id, stardate, enddate, paytype, "view");
                    break;
                case ihspTabCostAmt:
                    frxPrintView.ihspTabCostAmt(id, stardate, enddate, paytype,depart_id, "view");
                    break;
            }
        }

        /// <summary>
        /// 设计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDesign_Click(object sender, EventArgs e)
        {
            if (this.lvPreviewItem.SelectedItems.Count == 0) { return; }
            string selectedTxt = this.lvPreviewItem.SelectedItems[0].Text;
            BllFrxOper billFrxOper = new BllFrxOper();
            DataTable printTemplates = billFrxOper.getPrintTemplate(selectedTxt);
            if (printTemplates == null || printTemplates.Rows.Count == 0) { return; }
            string templateName = printTemplates.Rows[0]["frmurl"].ToString();
            if (string.IsNullOrEmpty(templateName)) { return; }
            FastReport.Report designReport = new FastReport.Report();
            string templatePath = GlobalParams.reportDir + @"\" + templateName;
            designReport.Load(templatePath);
            designReport.Design();
        }

        /// <summary>
        /// 打印按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.lvPreviewItem.SelectedItems.Count == 0) { return; }
            string selectedText = this.lvPreviewItem.SelectedItems[0].Text;
            FrxPrintView frxPrintView = new FrxPrintView(this.rptPreviewCtrl);
            string id = ihsptab.Id;
            string stardate = Convert.ToDateTime(ihsptab.Startdate).ToString("yyyy-MM-dd");
            string enddate = Convert.ToDateTime(ihsptab.Enddate).ToString("yyyy-MM-dd");
            string paytype = ihsptab.Paytype;
            string depart_id = Ihsptab.Depart_id;
            if (this.lvPreviewItem.SelectedItems.Count == 0) { return; }
            switch (selectedText)
            {
                case ihspTabForCharger:
                    frxPrintView.ihspTabForCharger(id, stardate, enddate, paytype, "print");
                    break;
                case ihspTabForChargerAmt:
                    frxPrintView.ihspTabForChargerAmt(id, stardate, enddate, paytype, "print");
                    break;
                case ihspTabCostAmt:
                    frxPrintView.ihspTabCostAmt(id, stardate, enddate, paytype,depart_id, "print");
                    break;
            }
        }
    }
}
