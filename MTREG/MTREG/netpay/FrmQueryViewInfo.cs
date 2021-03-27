using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MTREG.netpay
{
    public partial class FrmQueryViewInfo : Form
    {
        public FrmQueryViewInfo()
        {
            InitializeComponent();
        }
        public void getreSource(string resultInfo)
        {
            this.tbxResultInfo.Text = resultInfo;
            
        }
    }
}
