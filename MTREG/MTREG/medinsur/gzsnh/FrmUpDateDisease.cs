using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using MTREG.medinsur.gzsnh.bo;
using MTREG.medinsur.gzsnh.bll;
using MTHIS.main.bll;
 
namespace MTREG.medinsur.gzsnh
{
    public partial class FrmUpDateDisease : Form
    {
        public FrmUpDateDisease()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownload_Click(object sender, EventArgs e)
        {
            BllGzsnhMethod bllGzsnhMethod = new BllGzsnhMethod();
            WebClient webClient = new WebClient();
            DataTable dt = bllGzsnhMethod.getAreaInfo(tbxCenterNo.Text);
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("未找到对应中心编码,请从新输入", "提示信息");
                tbxCenterNo.Clear();
                tbxCenterNo.Focus();
                return;
            }
            string url = dt.Rows[0]["weburl"].ToString() + "updateDisease?userName=" + Base64.encodebase64(dt.Rows[0]["username"].ToString()) + "&userPwd=" + Base64.encodebase64(dt.Rows[0]["password"].ToString()) + "&centerNo=" + Base64.encodebase64(dt.Rows[0]["areacode"].ToString()) + "&LastTime" + Base64.encodebase64(dtpLastdate.Value.ToString()) + "&hospCode=" + Base64.encodebase64(dt.Rows[0]["hospitalcode"].ToString()) + "";
            try
            {
                string param = webClient.DownloadString(url);
                try
                {
                    string[] info = param.Replace("},{", "@").Split('@');
                    string sql = "";
                    if (info.Length > 0)
                    {
                        for (int i = 0; i < info.Length; i++)
                        {
                            string[] detial = info[i].Replace("[{", "").Replace("}]", "").Replace("\"", "").Split(',');
                            string icdAllnl = Base64.decodebase64(detial[0].Split(':')[0]).Replace("\'", "\\\'");
                            string icdName = Base64.decodebase64(detial[1].Split(':')[1]).Replace("\'", "\\\'");
                            string inputcodepy = Base64.decodebase64(detial[10].Split(':')[2]).Replace("\'", "\\\'");                           
                            string createtime = Base64.decodebase64(detial[10].Split(':')[8]).Replace("\'", "\\\'");
                            sql+=bllGzsnhMethod.insurillness(icdName, icdAllnl, inputcodepy, createtime);                            
                        }
                        if (BllMain.Db.Update(sql) < 0)
                        {
                            MessageBox.Show("疾病信息添加失败!","提示信息");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("没有更新的疾病信息!");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取疾病信息失败:" + Base64.decodebase64(Base64.GetPageCodeBy500Error(url, "utf-8").Split(':')[1].Replace("\"", "").Replace("}", "")));
                return;
            }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxFirst_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxFirst.Checked)
            {
                dtpLastdate.Enabled = false;
            }
            else
            {
                dtpLastdate.Enabled = true;
            }
        }

    }
}
