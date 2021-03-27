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
using MTHIS;
using MTREG.main.bo;

namespace MTREG.ihspqty
{
    public partial class FrmIhspQtyInhsp : Form
    {
        AccMenu accMenu = new AccMenu();
        List<AccMenu> list = new List<AccMenu>();
        public FrmIhspQtyInhsp(List<AccMenu> accmemus)
        {
            InitializeComponent();
            list = accmemus;
        }

        private void FrmIhspQtyInhsp_Load(object sender, EventArgs e)
        {
            string url = "";
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Id == "397")
                {
                    url = list[i].Url;
                }
            }
            try
            {
                string header = "Content-Type: application/x-www-form-urlencoded ";
                //string header = "";
                string username = ProgramGlobal.Workno;
                string password = ProgramGlobal.Password;
                //url= ProgramGlobal.Website + url;
                //url = "http://192.168.1.102:8080/his2/login.html?returnUrl=/cost/dutycost/clinictabDutyCost.html";
                url = "http://192.168.1.170:8080/his2/login.html";
                string postData = "username=" + username + "&password=" + password; // 要发放的数据
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                webBrowser1.Navigate(url, "", byteArray, header);
            }
            catch
            { }
        }
        //private void SuppressScriptErrorsOnly()
        //{
        //    // 确信 ScriptErrorsSuppressed 设为 false.    
        //    webBrowser1.ScriptErrorsSuppressed = false;

        //    // 处理 DocumentCompleted 事件以访问 Document 对象.    
        //    webBrowser1.DocumentCompleted +=
        //        new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
        //}    
        //private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        //{
        //    ((WebBrowser)sender).Document.Window.Error += new HtmlElementErrorEventHandler(Window_Error);
        //}
        //private void Window_Error(object sender, HtmlElementErrorEventArgs e)
        //{
        //    // Ignore the error and suppress the error dialog box. 
        //    e.Handled = true;
        //}
    }
}
