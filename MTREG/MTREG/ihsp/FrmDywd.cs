using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
//using guizhousheng.Util;
//using guizhousheng.Entity;
using System.Collections;
using MTREG.ihsp.bll;
using MTHIS.tools;

//namespace guizhousheng.Report_form
namespace MTREG.ihsp
{
    public partial class FrmDywd : Form
    {
        BillIhspMan billIhspMan = new BillIhspMan();
        PrintDialog printDialog = new PrintDialog();
        PrintDocument printDocument = new PrintDocument();
        PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();

        public FrmDywd()
        {
            InitializeComponent();
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage); 
        }

        /// <summary>
        /// 打印条形码
        /// </summary>
        public void PrintBarCode()
        {
            try
            {
                printDialog.Document = printDocument;
                string printerName = "";
                string printerIp = IniUtils.IniReadValue(IniUtils.syspath, "WD", "PrinterIp");
                if (!string.IsNullOrEmpty(printerIp))
                {
                    printerName = string.Format(@"\\{0}\", printerIp);
                }
                printerName += IniUtils.IniReadValue(IniUtils.syspath, "WD", "PrinterName");
                printDocument.PrinterSettings.PrinterName = printerName;
                printDocument.PrinterSettings.Copies = 1;
                string width= printDocument.PrinterSettings.DefaultPageSettings.PaperSize.Width.ToString();
                string height = printDocument.PrinterSettings.DefaultPageSettings.PaperSize.Height.ToString();
                
                printDialog.PrinterSettings = printDocument.PrinterSettings;
                printDocument.Print();//开始文档打印进程
            }
            catch
            {
                //文档停止打印
                printDocument.PrintController.OnEndPrint(printDocument, new System.Drawing.Printing.PrintEventArgs());
            }
          
        }
        /// <summary>
        /// 打印预览
        /// </summary>
        public void BarCodeShow(String Mtzyjl_iid)
        {
            DataTable dwddt = billIhspMan.GetWdxx(Mtzyjl_iid);
            //DywdEntity dywdEntity = new DywdEntity();
            //dywdEntity.Xm = "姓名："+dwddt.Rows[0]["hzxm"].ToString();//姓名
            //dywdEntity.Xb = "性别："+dwddt.Rows[0]["xb"].ToString();//性别
            //dywdEntity.Zyh = dwddt.Rows[0]["zyh"].ToString();//住院号
            //dywdEntity.Ryrq = "入院日期：" + DateTime.Parse(dwddt.Rows[0]["zyjlrysj"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");//入院日期
            //String csrq = DateTime.Parse(dwddt.Rows[0]["dob"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");//出生日期
            //String hznl= Tool.xsage(csrq);
            //dywdEntity.Nl ="年龄："+ hznl;
            // get39(dywdEntity);
            // // printDialog.ShowDialog();
            //printPreviewDialog.Document = printDocument;
            code391.Sickname = "姓名：" + dwddt.Rows[0]["hzxm"].ToString();//姓名
            code391.Sex = "性别：" + dwddt.Rows[0]["xb"].ToString();//性别
            code391.Hspregid = "住院号：" + dwddt.Rows[0]["zyh"].ToString();//住院号
            code391.Inhspat = "入院日期：" + DateTime.Parse(dwddt.Rows[0]["zyjlrysj"].ToString()).ToString("yyyy-MM-dd");//入院日期
            String csrq = DateTime.Parse(dwddt.Rows[0]["dob"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");//出生日期
            String hznl = xsage(csrq);
            code391.Age = "年龄：" + hznl;
            code391.BarcodeValue = dwddt.Rows[0]["zyh"].ToString().Trim();
            btnPrintBarcode_Click(null, null);
            //code391.PrintBarcodeToImage();
            //this.Show();
            //PrintBarCode();
            //printPreviewDialog.ShowDialog();
        }

        /// <summary>
        /// 根据年龄算出出生日期
        /// </summary>
        /// <param name="strCsrq"></param>
        /// <returns></returns>
        public String xsage(String strCsrq)
        {
            String nl = "";
            if (strCsrq != null || !strCsrq.Equals(""))
            {
                string nowtime = DateTime.Now.ToString("yyyy-MM");
                string nown = nowtime.Split('-')[0];
                string nowy = nowtime.Split('-')[1];
                string csrqn = strCsrq.Split('-')[0];
                string csrqy = strCsrq.Split('-')[1];
                int c = int.Parse(csrqy) - int.Parse(nowy);
                int age = int.Parse(nown) - int.Parse(csrqn);
                if (c > 0)
                {
                    return nl = (age - 1).ToString();
                }
                else
                {
                    return nl = age.ToString();
                }
            }
            return nl;
        }

        /// <summary>
        /// 打印的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.PageSettings.Landscape = false;
           
            Image img = Image.FromFile(Application.StartupPath + "\\123.jpg");
            e.Graphics.DrawImage(img, new Rectangle(new Point(0, 0), new Size(390, 390)), new RectangleF(new PointF(0, 0), new SizeF(390, 390)), GraphicsUnit.Pixel);
            img.Dispose();
        }
        /// <summary>
        /// 得到39码的图像
        /// </summary>
        /// <param name="s">输入的字符串</param>
        /// <returns>图片所在的路径</returns>
        /*
        public string get39(DywdEntity dywdEntity)
        {
            String Strzyh = dywdEntity.Zyh;
            Pen PenBlack = new Pen(Brushes.Black);//黑色线
            Pen PenWhite = new Pen(Brushes.White);//白色线
            PenBlack.Width = 2;//统一的黑色线的宽
            PenWhite.Width = 2;//统一的白色线的宽

            Bitmap bm = new Bitmap(1400, 130);//定义画布的像素（长，高）

            Graphics g = Graphics.FromImage(bm);//声明绘图
            g.Clear(Color.White);//定义绘图的背景色为白色
            #region 自定义字符的二进制格式
            Hashtable ht = new Hashtable();//自定义字符的二进制的格式
            #region 39码 12位
            ht.Add('A', "110101001011");
            ht.Add('B', "101101001011");
            ht.Add('C', "110110100101");
            ht.Add('D', "101011001011");
            ht.Add('E', "110101100101");
            ht.Add('F', "101101100101");
            ht.Add('G', "101010011011");
            ht.Add('H', "110101001101");
            ht.Add('I', "101101001101");
            ht.Add('J', "101011001101");
            ht.Add('K', "110101010011");
            ht.Add('L', "101101010011");
            ht.Add('M', "110110101001");
            ht.Add('N', "101011010011");
            ht.Add('O', "110101101001");
            ht.Add('P', "101101101001");
            ht.Add('Q', "101010110011");
            ht.Add('R', "110101011001");
            ht.Add('S', "101101011001");
            ht.Add('T', "101011011001");
            ht.Add('U', "110010101011");
            ht.Add('V', "100110101011");
            ht.Add('W', "110011010101");
            ht.Add('X', "100101101011");
            ht.Add('Y', "110010110101");
            ht.Add('Z', "100110110101");
            ht.Add('0', "101001101101");
            ht.Add('1', "110100101011");
            ht.Add('2', "101100101011");
            ht.Add('3', "110110010101");
            ht.Add('4', "101001101011");
            ht.Add('5', "110100110101");
            ht.Add('6', "101100110101");
            ht.Add('7', "101001011011");
            ht.Add('8', "110100101101");
            ht.Add('9', "101100101101");
            ht.Add('+', "100101001001");
            ht.Add('-', "100101011011");
            ht.Add('*', "100101101101");
            ht.Add('/', "100100101001");
            ht.Add('%', "101001001001");
            ht.Add('$', "100100100101");
            ht.Add('.', "110010101101");
            ht.Add(' ', "100110101101");
            #endregion
            #endregion
            float w = 1F;//条形码单个一条的宽度
            float h = 40F;//条形码单个一条的高度
            //dywdEntity.Zyh = "*" + dywdEntity.Zyh.ToString().ToUpper() + "*";//39码格式的定义为“*……*”;
            //s = s.ToString().ToUpper();
            string result_bin = "";//把字符的二进制toString()显示,"00"表示开始标签
            try
            {
                foreach (char ch in dywdEntity.Zyh)
                {
                    result_bin += ht[ch].ToString();
                    result_bin += "0";//规定每个字符隔开一条白线
                    result_bin += ",";//为以后的DrawString(即：画字符串)做准备（因为每个字符要求隔开）
                }
                result_bin += "10";//"10"表示结束标签
            }
            catch
            {

                g.DrawString("存在不允许的字符", new Font("宋体", 5), Brushes.Black, new PointF(0, 50));//当出现错误时，通过画布显示

                g.Dispose();
                bm.Save("12.jpg");
                string path2 = Application.StartupPath + "\\12.jpg";
                return path2;
            }
            Pen thePen = null;
            float x = w;//画布逐渐向右扩展的宽为线条的宽
            float x2 = 90;//字符的X坐标的逐渐向右扩展的初始值
            float topY = 80F;//线条顶点的Y坐标
            float chInt = 0;//为DrawString 做准备
            float len = ht['1'].ToString().Length;//任意单个字符的二进制的长度
            foreach (char c in result_bin)
            {
                if (c != ',')
                {
                    thePen = c == '0' ? PenWhite : PenBlack;//当二进制为“0”时，显示白线，当二进制为“1”时，显示黑线
                    g.DrawLine(thePen, new PointF(x + 90, topY), new PointF(x + 90, 1F + h));//根据上边的线条，画在画布上
                    x += w;
                    x2 += w;
                }
                //打印字符串
                else if (c == ',')
                {

                    int chint2 = 0;
                    foreach (char thec in dywdEntity.Zyh)
                    {
                        if (chint2 == chInt)
                        {
                            g.DrawString(thec.ToString(), new Font("宋体", 10), Brushes.Black, new PointF(x2 - ((len + 1) * 1), 50 + h + 1));//在画布上显示文字
                        }
                        chint2 = chint2 + 1;
                    }
                    chInt = chInt + 1;
                }
            }
            float barcodeX = 12F;
            float Ys = 15;//Y间隔长度
            int strNum = 9;//画字符串的大小
            //画名字
            float nameY = 40;//名字的Y坐标
            float nameX = barcodeX + 187;
            g.DrawString(dywdEntity.Xm, new Font("黑体", strNum), Brushes.Black, new PointF(nameX, nameY));

            //画性别
            float sexX = nameX;
            float sexY = nameY + Ys;
            g.DrawString(dywdEntity.Xb, new Font("黑体", strNum), Brushes.Black, new PointF(sexX, sexY));

            //画年龄
            float bedX = sexX + 80;
            float bedY = sexY;
            g.DrawString(dywdEntity.Nl, new Font("宋体", strNum), Brushes.Black, new PointF(bedX, bedY));

            //画入院日期
            float departX = nameX;
            float departY = sexY + Ys;
            g.DrawString(dywdEntity.Ryrq, new Font("宋体", strNum), Brushes.Black, new PointF(departX, departY));
            //画入住院号
            float zyhX = nameX;
            float zyhY = departY + Ys;
            g.DrawString("住院号：" + Strzyh, new Font("宋体", strNum), Brushes.Black, new PointF(zyhX, zyhY));

            g.Dispose();
            bm.Save("12.jpg");
            string path = Application.StartupPath + "\\12.jpg";
            return path;
        }
        */ 

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintBarcode_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            try
            {
                string printerName = "";
                string printerIp = IniUtils.IniReadValue(IniUtils.syspath, "WD", "PrinterIp");
                if (!string.IsNullOrEmpty(printerIp))
                {
                    printerName = string.Format(@"\\{0}\", printerIp);
                }
                printerName += IniUtils.IniReadValue(IniUtils.syspath, "WD", "PrinterName");
                if (!string.IsNullOrEmpty(printerName))
                    pd.PrinterSettings.PrinterName = printerName;
                pd.PrinterSettings.Copies = 1;
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                pd.Print();//开始文档打印进程
            }
            catch
            {
                //文档停止打印
                pd.PrintController.OnEndPrint(pd, new System.Drawing.Printing.PrintEventArgs());
            }
            
        }
        private void pd_PrintPage(object Sender, PrintPageEventArgs e)
        {
            code391.PrintBarcode(e.Graphics);
        }

        private void btn_PrintToImg_Click(object sender, EventArgs e)
        {
            code391.PrintBarcodeToImage();
        }
    }
}
