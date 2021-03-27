using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.common;
using MTREG.ihsptab.bll;

namespace MTREG.ihsptab
{
    public partial class FrmIhspTabInit : Form
    {
        BllIhsptab bllIhsptab = new BllIhsptab();
        string type;
        public FrmIhspTabInit(string info)
        {
            InitializeComponent();
            type = info;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (type == "ihsptab")
            {
                if (bllIhsptab.ihspTabinit(dtpTime.Value.ToString().Trim()) < 0)
                {
                    MessageBox.Show("初始化失败!");
                    return;
                }
                else
                {
                    MessageBox.Show("初始化成功!");
                    this.DialogResult = DialogResult.OK;
                }
            }
            else if (type == "ihspduty")
            {
                if (bllIhsptab.ihspDutyinit(dtpTime.Value.ToString().Trim()) < 0)
                {
                    MessageBox.Show("初始化失败!");
                    return;
                }
                else
                {
                    MessageBox.Show("初始化成功!");
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
        
        private void FrmStartTime_Load(object sender, EventArgs e)
        {
           string starttime= BillSysBase.currDate();
            this.dtpTime.Value = Convert.ToDateTime(starttime);
        }
    }
}
