using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using System.Net;
using MTREG.medinsur.gzsyb.nh;
using System.IO;
using System.Text.RegularExpressions;
using MTREG.medinsur.gzsnh.bo;
using MTREG.medinsur.gzsnh.bll;
using MTHIS.main.bll;
using MTHIS.common;

namespace MTREG.medinsur.gzsyb.nh
{
    public partial class Frmxzyp : Form
    {
        public Frmxzyp()
        {
            InitializeComponent();
        }
        WebClient webClient = new WebClient();
        private void btn_xzyp_Click(object sender, EventArgs e)
        {
            string lasttime = "";
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                //lasttime = Base64.encodebase64(getdata.updatetimeypzl().Tables[0].Rows[0]["updatetime"].ToString());
            }
            catch (Exception ex) { }
            string centerno = "520100";
            string url = GzsnhGlobal.Url + "updateLeechdom?userName=" + Base64.encodebase64(GzsnhGlobal.UserName) + "&userPwd=" + Base64.encodebase64(GzsnhGlobal.UserPwd) + "&centerNo=" + Base64.encodebase64(centerno) + "&LastTime=" + lasttime + "&hospCode=" + Base64.encodebase64(GzsnhGlobal.HospCode) + "";
            try
            {
                string param = webClient.DownloadString(url);//.Split(':')[1].Replace("\"", "").Replace("}", "");
                try
                {
                    string[] info = param.Replace("},{", "@").Split('@');
                    //getdata.nhypzlxxdelete();
                    for (int i = 0; i < info.Length; i++)
                    {
                        string[] detial = info[i].Replace("[{", "").Replace("}]", "").Replace("\"", "").Split(',');
                        for (int j = 0; j < detial.Length; j++)
                        {
                            string[] data = detial[j].Split(':');
                            result.Add(data[0], Base64.decodebase64(data[1]).Replace("\'", "\\\'"));
                        }
                        //getdata.nhypzlxx(result); 更新数据库表
                        result.Clear();
                    }
                    xzypzlxx();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("下载失败:" + Base64.decodebase64(GetPageCodeBy500Error(url, "utf-8").Split(':')[1].Replace("\"", "").Replace("}", "")));
                return;
            }
            MessageBox.Show("下载完成！");
        }
        private void xzypzlxx()
        {
            //dtv_xzyp.DataSource = getdata.nhypzlxx().Tables[0];
            //if (dtv_xzyp.Rows.Count > 0)
            //    lbl_xzyp.Text = "共：" + dtv_xzyp.Rows.Count + "行";
        }
        public String GetPageCodeBy500Error(String PageURL, String Charset)
        {
            String strHtml = ""; try
            {
                //连接到目标网页                  
                HttpWebRequest wreq = (HttpWebRequest)WebRequest.Create(PageURL);
                wreq.Method = "GET";
                wreq.Timeout = 20000;
                wreq.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1)  .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
                HttpWebResponse wresp = (HttpWebResponse)wreq.GetResponse();
                //采用流读取，并确定编码方式                  
                Stream s = wresp.GetResponseStream();
                StreamReader objReader = new StreamReader(s, System.Text.Encoding.GetEncoding(Charset));
                string strLine = "";
                //读取                  
                while (strLine != null)
                {
                    strLine = objReader.ReadLine();
                    if (strLine != null)
                    {
                        strHtml += strLine.Trim();
                    }
                }
                return strHtml;
            }
            catch (WebException ex)
            {
                HttpWebResponse res = ex.Response as HttpWebResponse;
                if (res.StatusCode == HttpStatusCode.InternalServerError)
                {
                    Stream s = res.GetResponseStream();
                    StreamReader objReader = new StreamReader(s, System.Text.Encoding.GetEncoding(Charset));
                    string strLine = "";
                    //读取                      
                    while (strLine != null)
                    {
                        strLine = objReader.ReadLine();
                        if (strLine != null)
                        {
                            strHtml += strLine.Trim();
                        }
                    } return strHtml;
                }
                else { strHtml = ex.Message; }
                return strHtml;
            }
        }

        private void btn_xzyp_Click_1(object sender, EventArgs e)
        {
            string lasttime =  DataTool.dateToString(this.dtpGZSlasttime.Value, "yyyy-MM-dd HH:mm:ss");
            BllGzsnhMethod bllGzsnhMethod = new BllGzsnhMethod();
            string msg = "";
            bllGzsnhMethod.insurItemGZSNH(lasttime,ref msg);
            MessageBox.Show(msg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lasttime =DataTool.dateToString(this.dtpGZSlasttime.Value, "yyyy-MM-dd HH:mm:ss");;
            BllGzsnhMethod bllGzsnhMethod = new BllGzsnhMethod();
            string msg = "";
            bllGzsnhMethod.insurItemGYSNH(lasttime, ref msg);
            MessageBox.Show(msg);
        }

    }


}
