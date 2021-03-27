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
    public partial class FrmTreatment : Form
    {
        public FrmTreatment()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            BllGzsnhMethod bllGzsnhMethod = new BllGzsnhMethod();
            WebClient webClient = new WebClient();
            DataTable dt=bllGzsnhMethod.getAreaInfo(tbxCenterNo.Text);
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("未找到对应中心编码,请从新输入","提示信息");
                tbxCenterNo.Clear();
                tbxCenterNo.Focus();
                return;
            }

            string url = dt.Rows[0]["weburl"].ToString() + "treatmentModeUpdate?userName=" + Base64.encodebase64(dt.Rows[0]["username"].ToString()) + "&userPwd=" + Base64.encodebase64(dt.Rows[0]["password"].ToString()) + "&centerNo=" + Base64.encodebase64(dt.Rows[0]["areacode"].ToString()) + "&hospCode=" + Base64.encodebase64(dt.Rows[0]["hospitalcode"].ToString()) + "&Year=" + Base64.encodebase64(dtpYear.Value.Year.ToString()) + "";
            try
            {
                string param = webClient.DownloadString(url);
                try
                {
                    string sql = "";
                    string[] info = param.Replace("\"", "").Replace(",diseaseList:", "@").Split('@');
                    string[] detial = info[0].Replace("{", "").Replace("}", "").Split(',');
                    for (int h = 0; h < detial.Length; h++)
                    {
                        string[] data = detial[h].Replace("{", "").Replace("}", "").Split(':');
                        string code=Base64.decodebase64(data[0]);
                        string name = Base64.decodebase64(data[1]);
                        sql+=bllGzsnhMethod.toNhzlfs(name,code);
                    }
                    if (BllMain.Db.Update(sql) < 0)
                    {
                        MessageBox.Show("治疗信息添加失败!", "提示信息");
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
                MessageBox.Show("获取治疗信息失败:" + Base64.decodebase64(Base64.GetPageCodeBy500Error(url, "utf-8").Split(':')[1].Replace("\"", "").Replace("}", "")));
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
