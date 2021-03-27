using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTHIS.common;
using MTHIS.main.bll;

namespace MTREG.clinic
{
    public partial class FrmRetHspCard : Form
    {
        
        
        public FrmRetHspCard()
        {
            InitializeComponent();
        }

         /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="id"></param>
        public void getSource(string sickname, string hspcard )
        {
            this.lbl_hspcard.Text = hspcard;
            this.lbl_name.Text = sickname;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
                string hspcard = lbl_hspcard.Text.Trim();
                string sql = "update  member set hspcard='TK" + hspcard + "' where hspcard = " + DataTool.addFieldBraces(hspcard);
                       sql+=";update  register set hspcard='TK" + hspcard + "' where hspcard = " + DataTool.addFieldBraces(hspcard);
                       sql += ";update  inhospital set hspcard='TK" + hspcard + "' where hspcard = " + DataTool.addFieldBraces(hspcard)+";";
                   if (BllMain.Db.Update(sql) == 0)
                   {
                       MessageBox.Show("退卡成功!");
                     
                   }
                   else
                        MessageBox.Show("退卡失败!");
                   this.Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
      


    }
}
