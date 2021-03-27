using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using MTREG.medinsur.sjzsyb.bll;
using MTHIS.common;
using System.IO;
using MTHIS.main.bll;
using MTREG.common;

namespace MTREG.medinsur.sjzsyb
{
    public partial class Frmydjyjzzysbxxcx : Form
    {
        Sjzsyb syb = new Sjzsyb();
        public Frmydjyjzzysbxxcx()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string code = tb_code.Text.ToString().Trim();
            if( code.Equals(""))
            {
                MessageBox.Show("请输入社保卡号", "提示信息");
                return;
            }

            string msgid = BllItemcrossSJZ.getTradingStream(); //交易流水号
            Sjzsyb_IN syb_in = new Sjzsyb_IN();
            syb_in.Yw = "1639";
            syb_in.Rc = syb_in.Request_head()
                        + "<AAE140>0</AAE140>"//险种类型 
                        + "<AAC001></AAC001>"//患者识别信息 
                        + "<AKB020>" + ProgramGlobal.AKB020 + "</AKB020>"//定点医疗机构编码 
                        + "<AKC190></AKC190>"//门诊/住院流水号 
                        + "<AKC020></AKC020>"//社保卡号 
                        + "<AKA130></AKA130>"//可空 
                        + "<MSGNO>1639</MSGNO>"//交易代码 
                        + "<MSGID>" + msgid + "</MSGID>"//发送方交易流水号 
                        + "<GRANTID>H001</GRANTID>"//授权码 ,东软提供，必录
                        + "<ORGMSGNO></ORGMSGNO>"//原交易代码 
                        + "<ORGMSGID></ORGMSGID>"//原发送方交易流水号 
                        + "<OPERID>" + ProgramGlobal.User_id + "</OPERID>"//操作员编号 
                        + "<OPERNAME>" + ProgramGlobal.Nickname + "</OPERNAME>"//操作员姓名 
                        + "<BATNO>" + ProgramGlobal.batno + "</BATNO>"//业务周期号 
                        + "<OPTTIME>" + DateTime.Now.ToString("yyyyMMddHHmmss") + "</OPTTIME>"//系统时间
                        + "<INPUT>"
                            + "<AKC020>" + code + "</AKC020>"
                        + "</INPUT>"
                        + syb_in.Request_foot();
            int opt_ryjbxxhzh = syb.ybcjhs(syb_in);

            StringReader sr = new StringReader(syb_in.Cc);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            DataTable dt1 = ds.Tables["PAGE"];
            DataTable dt2 = ds.Tables["RESPONSEDATA"];
            DataTable dt3 = ds.Tables["OUTROW"];
            string ReturnMsg = "";

            int returnnum = Convert.ToInt32(dt2.Rows[0]["RETURNNUM"].ToString());
            if (returnnum == -1)//错误，业务出参中的errorMSG为错误信息
            {
                ReturnMsg = dt2.Rows[0]["ERRORMSG"].ToString();
                MessageBox.Show(ReturnMsg, "提示信息");
                return;
            }
            foreach ( DataRow dr in dt3.Rows )
            {
                if( dr["AAE022"].Equals("0") )
                {
                    dr["AAE022"] = "未审核";
                } else if( dr["AAE022"].Equals("1") )
                {
                    dr["AAE022"] = "参保地政策结算";
                } else if ( dr["AAE022"].Equals("2") )
                {
                    dr["AAE022"] = "现金结算";
                }
                
                if( dr["AAE100"].Equals("0") )
                {
                    dr["AAE100"] = "无效";
                }
                else if (dr["AAE100"].Equals("1"))
                {
                    dr["AAE100"] = "有效";
                }
            }
            dataGridView1.DataSource = dt3;
        }
    }
}
