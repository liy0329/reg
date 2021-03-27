using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTHIS.sys.bll;

namespace MTHIS.sys
{
    public partial class FrmSystemConfig : Form
    {
        BllSystemConfig bllSystemConfig = new BllSystemConfig();
        public FrmSystemConfig()
        {
            InitializeComponent();
        }

        private void FrmSystemConfig_Load(object sender, EventArgs e)
        {
            this.dgvSysConfig.DataSource = bllSystemConfig.getConfigInfo();
        }
    }
}
