using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MTREG.medinsur.hdyb
{
    public partial class FrmSelectCross : Form
    {
        public FrmSelectCross()
        {
            InitializeComponent();
        }

        private string insurtype_id;
        /// <summary>
        /// 医保类型
        /// </summary>
        public string Insurtype_id
        {
            get { return insurtype_id; }
            set { insurtype_id = value; }
        }

        /// <summary>
        /// 三目录对照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Click(object sender, EventArgs e)
        {
            FrmItemcross frmItemcross = new FrmItemcross();
            frmItemcross.ShowDialog();
        }

        /// <summary>
        /// 药品类别对照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDrugtype_Click(object sender, EventArgs e)
        {
            FrmDrugtype frmDrugtype = new FrmDrugtype();
            frmDrugtype.Insurtype_id = Insurtype_id;
            frmDrugtype.ShowDialog();
        }
        /// <summary>
        /// 医药类别对照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnItemfrom_Click(object sender, EventArgs e)
        {
            FrmItemfrom frmItemfrom = new FrmItemfrom();
            frmItemfrom.Insurtype_id = Insurtype_id;
            frmItemfrom.ShowDialog();
        }

        /// <summary>
        /// 财务类别对照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnItemtype_Click(object sender, EventArgs e)
        {
            //FrmItemtype frmItemtype = new FrmItemtype();
            //frmItemtype.Insurtype_id = Insurtype_id;
            //frmItemtype.ShowDialog();
        }
    }
}
