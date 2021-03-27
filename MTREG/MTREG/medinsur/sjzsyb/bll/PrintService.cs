using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MTREG.medinsur.gzsyb;
using MTHIS.common;

namespace MTREG.medinsur.sjzsyb.bll
{
    class PrintService
    {
        public PrintService()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            this.docToPrint.PrintPage += new PrintPageEventHandler(docToPrint_PrintPage);
        }//将事件处理函数添加到PrintDocument的PrintPage中

        // Declare the PrintDocument object.
        private System.Drawing.Printing.PrintDocument docToPrint =
         new System.Drawing.Printing.PrintDocument();//创建一个PrintDocument的实例

        private string streamType;
        private string streamtxt;
        private Image streamima;

        // This method will set properties on the PrintDialog object and
        // then display the dialog.
        public void StartPrint(string txt, string streamType)
        {
            this.streamType = streamType;
            this.streamtxt = txt;
            // Allow the user to choose the page range he or she would
            // like to print.
            System.Windows.Forms.PrintDialog PrintDialog1 = new PrintDialog();//创建一个PrintDialog的实例。
            PrintDialog1.AllowSomePages = true;

            // Show the help button.
            PrintDialog1.ShowHelp = true;

            // Set the Document property to the PrintDocument for 
            // which the PrintPage Event has been handled. To display the
            // dialog, either this property or the PrinterSettings property 
            // must be set 
            PrintDialog1.Document = docToPrint;//把PrintDialog的Document属性设为上面配置好的PrintDocument的实例

            //DialogResult result = PrintDialog1.ShowDialog();//调用PrintDialog的ShowDialog函数显示打印对话框,如果不要注释即可，直接调用docToPrint.Print()
            //// If the result is OK then print the document.
            //if (result == DialogResult.OK)
            //{
            //    docToPrint.Print();//开始打印
            //}
            docToPrint.Print();//开始打印
        }
        public void StartPrint(Image ima, string streamType)
        {
            this.streamType = streamType;
            this.streamima = ima;
            // Allow the user to choose the page range he or she would
            // like to print.
            System.Windows.Forms.PrintDialog PrintDialog1 = new PrintDialog();//创建一个PrintDialog的实例。
            PrintDialog1.AllowSomePages = true;

            // Show the help button.
            PrintDialog1.ShowHelp = true;
            PrintDialog1.Document = docToPrint;//把PrintDialog的Document属性设为上面配置好的PrintDocument的实例

            DialogResult result = PrintDialog1.ShowDialog();//调用PrintDialog的ShowDialog函数显示打印对话框,如果不要注释即可，直接调用docToPrint.Print()
            // If the result is OK then print the document.
            if (result == DialogResult.OK)
            {
                docToPrint.Print();//开始打印
            }

            //docToPrint.Print();//开始打印
        }
        // The PrintDialog will print the document
        // by handling the document's PrintPage event.
        private void docToPrint_PrintPage(object sender,
         System.Drawing.Printing.PrintPageEventArgs e)//设置打印机开始打印的事件处理函数
        {

            // Insert code to render the page here.
            // This code will be called when the control is drawn.

            // The following code will render a simple
            // message on the printed document
            switch (this.streamType)
            {
                case "txt":
                    string text = null;
                    System.Drawing.Font printFont = new System.Drawing.Font
                     ("Arial", 7, System.Drawing.FontStyle.Regular);//在这里设置打印字体以及大小

                    // Draw the content.

                    text = streamtxt;
                    //e.Graphics.DrawString(text, printFont, System.Drawing.Brushes.Black, e.MarginBounds.X, e.MarginBounds.Y);
                    e.Graphics.DrawString(text, printFont, System.Drawing.Brushes.Black, 5, 5);//设置打印初始位置
                    break;
                case "image":
                    System.Drawing.Image image = streamima;
                    int x = e.MarginBounds.X;
                    int y = e.MarginBounds.Y;
                    int width = image.Width;
                    int height = image.Height;
                    if ((width / e.MarginBounds.Width) > (height / e.MarginBounds.Height))
                    {
                        width = e.MarginBounds.Width;
                        height = image.Height * e.MarginBounds.Width / image.Width;
                    }
                    else
                    {
                        height = e.MarginBounds.Height;
                        width = image.Width * e.MarginBounds.Height / image.Height;
                    }
                    System.Drawing.Rectangle destRect = new System.Drawing.Rectangle(x, y, width, height);
                    e.Graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, System.Drawing.GraphicsUnit.Pixel);
                    break;
                default:
                    break;
            }


        }
        public string WriteTxt(DataTable dt_info, DataTable dt_data)
        {
            StringBuilder sb = new StringBuilder();
            string tou = "井陉县中医院健康卡收费明细单";
            int count = dt_data.Rows.Count;

            sb.Append("            " + tou + "     \r\n");
            sb.Append("-----------------------------------------------------------------\r\n");
            sb.Append("姓名:" + dt_info.Rows[0]["name"] + "\r\n");
            sb.Append("卡号:" + dt_info.Rows[0]["hspcard"] + "\r\n");
            //sb.Append("日期:" + dt_info.Rows[0]["shday"] + "\r\n");
            sb.Append("-----------------------------------------------------------------\r\n");
            sb.Append("业务" + "\0\0\0" + "金额" + "\t" + "余额" + "\t\0" + "时间" + "\t\0" + "付款方式" + "\r\n");
            for (int i = 0; i < count; i++)
            {
                string type = dt_data.Rows[i]["opertype"].ToString();
                string Num = dt_data.Rows[i]["amount"].ToString().PadLeft(8);
                string Unit = dt_data.Rows[i]["balance"].ToString().PadLeft(8);
                string Prc = Convert.ToDateTime(dt_data.Rows[i]["operatdate"].ToString()).ToString("yyyy-MM-dd");
                string pattype = dt_data.Rows[i]["paytype"].ToString();

                sb.Append(type + "\0\0\0" + Num + "\0\0" + Unit + "\0\0" + Prc + "\0\0\0" + pattype + "\r\n");
                if (i != count)
                    sb.Append("\r\n");

            }
            sb.Append("-----------------------------------------------------------------\r\n");
            sb.Append("卡内余额：" + "    " + dt_info.Rows[0]["balance"] + "\r\n");
            sb.Append("注：此单只作为医疗服务记录，避光，避热保存                    ");
            return sb.ToString();
        }
        public string WriteTxt_mzxm(DataTable dt_info, DataTable dt_data)
        {
            StringBuilder sb = new StringBuilder();
            string tou = "井陉县中医院门诊收费明细单";
            int count = dt_data.Rows.Count;

            sb.Append("            " + tou + "     \r\n");
            sb.Append("-----------------------------------------------------------------\r\n");
            sb.Append("姓名:" + dt_info.Rows[0]["name"] + "  " + "                 单号:" + dt_info.Rows[0]["dh"] + "\r\n");
            sb.Append("科室:" + dt_info.Rows[0]["depart"] + "  " + "                 医师:" + dt_info.Rows[0]["doctor"] + "\r\n");
            sb.Append("-----------------------------------------------------------------\r\n");
            sb.Append("项目" + "\t\t\0\0\0" + "数量" + "\0" + "单位" + "\0" + "单价" + "\r\n");
            for (int i = 0; i < count; i++)
            {
                string name = dt_data.Rows[i]["NAME"].ToString();
                string Num = dt_data.Rows[i]["Num"].ToString();
                string Unit = dt_data.Rows[i]["Unit"].ToString();
                double Prc = Double.Parse(dt_data.Rows[i]["Prc"].ToString());
                string name_foot = "";
                string name_foots = "";
                if (name.Length > 10)
                {
                    int con = name.Length;
                    name_foots = name.Substring(8, con - 8);
                    name = name.Substring(0, 9);
                }
                for (int j = name.Length; j < 11; j++)
                {
                    name_foot += "\0\0";
                }
                name += name_foot;

                string Num_foot = "";
                for (int j = Num.Length; j < 4; j++)
                {
                    Num_foot += "\0";
                }
                Num += Num_foot;
                string Unit_foot = "";
                for (int j = Unit.Length; j < 2; j++)
                {
                    Unit_foot += "\0";
                }
                Unit += Unit_foot;
                sb.Append(name + Num + "" + Unit + "  " + Prc.ToString("0.00"));

                if (i != (count))
                    sb.Append("\r\n");
                if (!String.IsNullOrEmpty(name_foots))
                {
                    sb.Append(name_foots + "\r\n");
                }
            }
            sb.Append("-----------------------------------------------------------------\r\n");
            money n = new money(DataTool.Getdouble(dt_info.Rows[0]["yfee"].ToString()));

            sb.Append("应收金额: " + dt_info.Rows[0]["yfee"] + "元" + "       实收金额:   " + dt_info.Rows[0]["sfee"] + "元" + "\r\n");
            sb.Append("大写：" + n.Convert() + "\r\n");
            sb.Append("收费员:" + dt_info.Rows[0]["sfy"] + "  " + "                 日期:" + dt_info.Rows[0]["shday"] + "\r\n");
            sb.Append("-----------------------------------------------------------------\r\n");
            sb.Append("1. 药品离院不退  2.退药七日内办理\r\n");
            sb.Append("3. 小票为退药依据，清妥善保存！\r\n");
            return sb.ToString();
        }
    }
}
