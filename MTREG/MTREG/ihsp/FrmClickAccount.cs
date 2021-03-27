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
using MTREG.common;
using MTHIS.common;
using MTHIS.tools;
using MTREG.ihsptab.bo;
using MTREG.medinsur.hdyb.bll;

namespace MTREG.ihsp
{
    public partial class FrmClickAccount : Form
    {
        string ihspid;
        string acc_id;
        
        public FrmClickAccount()
        {
            InitializeComponent();
        }
        private string patienttype;

        public string Patienttype
        {
            get { return patienttype; }
            set { patienttype = value; }
        }
        /// <summary>
        /// 从结算窗口获取数据
        /// </summary>
        /// <param name="source"></param>
        public void getSource(string invoice,string id,string acc_id)
        {
            this.ihspid = id;
            this.acc_id = acc_id;
            lblInvoice.Text = invoice;
        }
        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            FrxPrintView frxPrintView = new FrxPrintView();
            frxPrintView.IhspAccPrt(ihspid);
            //BllInsur bllInsur = new BllInsur();
            //string keyname = bllInsur.getInsurtype(patienttype);
            //if (keyname == CostInsurtypeKeyname.GZSNH.ToString())
            //{
            //    //frxPrintView.IhspAccGzsnhPrt(ihspid, patienttype);
            //    frxPrintView.IhspAccPrt(acc_id);
            //}
            //else if (keyname == CostInsurtypeKeyname.GYSYB.ToString())
            //{
            //    frxPrintView.IhspAccPrt(acc_id);
            //}
            //else if (keyname == CostInsurtypeKeyname.GZSYB.ToString())
            //{
            //    frxPrintView.IhspAccPrt(acc_id);
            //}
            //else if (keyname == CostInsurtypeKeyname.SELFCOST.ToString())
            //{
            //    frxPrintView.IhspAccPrt(acc_id);
            //}
            this.Close();
        }
    }
}
