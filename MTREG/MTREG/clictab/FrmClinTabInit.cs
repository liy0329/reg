using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.clintab.bll;
using MTHIS.common;
using MTREG.common;

namespace MTREG.clintab
{
    public partial class FrmClinTabInit : Form
    {
        BllClicTab bllClicTab = new BllClicTab();
        string type;
        public FrmClinTabInit(string info)
        {
            InitializeComponent();
            type = info;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (type == "clinictab")
            {
                if (bllClicTab.clinicTabinit(dtpTime.Value.ToString().Trim()) < 0)
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
            else if (type == "clinicduty")
            {
                if (bllClicTab.clinicDutyinit(dtpTime.Value.ToString().Trim()) < 0)
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
            else if (type == "ihsptab")
            {
                if (bllClicTab.ihspTabinit(dtpTime.Value.ToString().Trim()) < 0)
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
                if (bllClicTab.ihspDutyinit(dtpTime.Value.ToString().Trim()) < 0)
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
