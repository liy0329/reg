using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.sjzsyb.bll;
using MTHIS.common;
using System.IO;
using MTHIS.main.bll;
using MTREG.common;
using MTREG.medinsur.sjzsyb.bean;

namespace MTREG.medinsur.sjzsyb
{
    public partial class FrmDepartments : Form
    {
        Sjzsyb syb = new Sjzsyb();
        DataTable dt1 = new DataTable();
        public FrmDepartments()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGxypzd_Click(object sender, EventArgs e)
        {
            //下载当前定点中心的所有科室信息
            Sjzsyb_IN syb_in = new Sjzsyb_IN();
            string msgid = BllItemcrossSJZ.getTradingStream(); //交易流水号
            syb_in.Yw = "1630";
            syb_in.Rc = syb_in.Request_head()
                        + "<AAE140>0</AAE140>"//险种类型 
                        + "<AAC001></AAC001>"//患者识别信息 
                        + "<AKB020>" + ProgramGlobal.AKB020 + "</AKB020>"//定点医疗机构编码 
                        + "<AKC190></AKC190>"//门诊/住院流水号 
                        + "<AKC020></AKC020>"//社保卡号 
                        + "<AKA130></AKA130>"//可空 
                        + "<MSGNO>1630</MSGNO>"//交易代码 
                        + "<MSGID>" + msgid + "</MSGID>"//发送方交易流水号 
                        + "<GRANTID>H001</GRANTID>"//授权码 ,东软提供，必录
                        + "<ORGMSGNO></ORGMSGNO>"//原交易代码 
                        + "<ORGMSGID></ORGMSGID>"//原发送方交易流水号 
                        + "<OPERID>" + ProgramGlobal.User_id + "</OPERID>"//操作员编号 
                        + "<OPERNAME>" + ProgramGlobal.Nickname + "</OPERNAME>"//操作员姓名 
                        + "<BATNO>" + ProgramGlobal.batno + "</BATNO>"//业务周期号 
                        + "<OPTTIME>" + DateTime.Now.ToString("yyyyMMddHHmmss") + "</OPTTIME>"//系统时间
                        + syb_in.Request_foot();
            int opt_ryjbxxhzh = syb.ybcjhs(syb_in);

            StringReader sr = new StringReader(syb_in.Cc);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            dt1 = ds.Tables["OUTPUT"];
            DataTable dt2 = ds.Tables["RESPONSEDATA"];
            string ReturnMsg = "";

            int returnnum = Convert.ToInt32(dt2.Rows[0]["RETURNNUM"].ToString());
            if (returnnum == -1)//错误，业务出参中的errorMSG为错误信息
            {
                ReturnMsg = dt2.Rows[0]["ERRORMSG"].ToString();
                MessageBox.Show(ReturnMsg, "提示信息");
                return;
            }
            else
            {
                dataGridView1.DataSource = dt1;
            }


            //添加sjz_yb_dep
            string sql = "";

            //添加前先删除原先记录
            string sql_delete = "DELETE FROM sjz_yb_dep ;";
            sql += sql_delete;
            

            string AKF001 = ""; //科室编码
            string AKF003 = ""; //科室代码
            string AKF002 = ""; //科室名称
            string AKB020 = ""; //医疗机构编号
            string BKF075 = ""; //科室分类
            string AKF015 = ""; //床位数
            string AKF008 = ""; //职工数量
            string BKF005 = ""; //负责人
            string BKF006 = ""; //联系电话
            string BKF061 = ""; //业务范围
            string AAE013 = ""; //备注
            int count = dt1.Rows.Count;
            
            foreach (DataRow dr in dt1.Rows)
            {

                AKF001 = dr["AKF001"].ToString().Trim();
                AKF003 = dr["AKF003"].ToString().Trim();
                AKF002 = dr["AKF002"].ToString().Trim();
                AKB020 = dr["AKB020"].ToString().Trim();
                BKF075 = dr["BKF075"].ToString().Trim();
                AKF015 = dr["AKF015"].ToString().Trim();
                AKF008 = dr["AKF008"].ToString().Trim();
                BKF005 = dr["BKF005"].ToString().Trim();
                BKF006 = dr["BKF006"].ToString().Trim();
                BKF061 = dr["BKF061"].ToString().Trim();
                AAE013 = dr["AAE013"].ToString().Trim();
                string sql_dep = "INSERT INTO sjz_yb_dep (AKF001,AKF003,AKF002,AKB020,BKF075,AKF015,AKF008,BKF005,BKF006,BKF061,AAE013) "
                              + " VALUES ("

                              + DataTool.addFieldBraces(AKF001)
                              + "," + DataTool.addFieldBraces(AKF003)
                              + "," + DataTool.addFieldBraces(AKF002)
                              + "," + DataTool.addFieldBraces(AKB020)
                              + "," + DataTool.addFieldBraces(BKF075)
                              + "," + DataTool.addFieldBraces(AKF015)
                              + "," + DataTool.addFieldBraces(AKF008)
                              + "," + DataTool.addFieldBraces(BKF005)
                              + "," + DataTool.addFieldBraces(BKF006)
                              + "," + DataTool.addFieldBraces(BKF061)
                              + "," + DataTool.addFieldBraces(AAE013)
                              + ");";
                
                sql += sql_dep;
            }
            if (BllMain.Db.Update(sql) == -1)
            {
                MessageBox.Show("更新医保科室失败", "提示信息");
            }
            else
            {
                MessageBox.Show("更新医保科室成功", "提示信息");
            }

        }

        private void btnGxypzd_Click_1(object sender, EventArgs e)
        {
            SJZYB_IN<DBNull> yb_in_dep = new SJZYB_IN<DBNull>();
            SjzybInterface yb_xz = new SjzybInterface();
            List<Depart_Out> yb_out_dep = new List<Depart_Out>();
            yb_in_dep.MSGNO = "1630";
            int opstat = yb_xz.DownloadDepart(yb_in_dep, ref yb_out_dep);

            string ReturnMsg = "";
            int returnnum = Convert.ToInt32(yb_out_dep[0].RETURNNUM);
            if (returnnum == -1)//错误，业务出参中的errorMSG为错误信息
            {
                ReturnMsg = yb_out_dep[0].ERRORMSG;
                MessageBox.Show(ReturnMsg, "提示信息");
                return;
            }
            string sql = "";

            Yb_Itme depitme = new Yb_Itme();
            depitme.deleteyb_Departitme();
            for (int i = 0; i < yb_out_dep.Count; i++)
            {
                sql += depitme.addyb_Departitme(yb_out_dep[i]);
            }
            if (depitme.doExeSql(sql) == -1)
            {
                MessageBox.Show("添加医生失败！");
                return;
            }
            DataTable dt = depitme.selectyb_Deparitme();
            dataGridView1.DataSource = dt;
            this.label1.Visible = true;

            this.label1.Text = "共获取科室：" + dt.Rows.Count.ToString() + "位";
        }

       

        

        
    }
}
