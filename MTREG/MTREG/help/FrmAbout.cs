/*************************************************************************************
     * CLR版本：       2.0.50727.4927
     * 类 名 称：       FrmAbout
     * 机器名称：       AARON-PC
     * 命名空间：       MTLIS.help
     * 文 件 名：       FrmAbout
     * 创建时间：       2013/5/23 8:16:31
     * 作    者：       田非
     * 说    明：       帮助
     * 修改时间：
     * 修 改 人：
*************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTHIS.main.bll;
namespace MTHIS.help
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            try
            {
                string sql = "select * from lis_sysconfig where id = 1";
                DataTable dt = BllMain.Db.Select(sql).Tables[0];
                this.lbl_HspName.Text = dt.Rows[0]["hspname"].ToString();
            }
            catch (Exception)
            { }
        }
    }
}
