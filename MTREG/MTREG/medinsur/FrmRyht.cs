using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.hdyb.bll;
using MTREG.medinsur.hdyb.dor;
using MTHIS.main.bll;

namespace MTREG.medinsur
{
    public partial class FrmRyht : Form
    {
        public FrmRyht()
        {
            InitializeComponent();
        }
        private string xm;

        public string Xm
        {
            get { return xm; }
            set { xm = value; }
        }
        private string zyh;

        public string Zyh
        {
            get { return zyh; }
            set { zyh = value; }
        }
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }


        JKDB jkdb = new JKDB();
        YBCJ yw1 = new YBCJ();
        private void FrmRyht_Load(object sender, EventArgs e)
        {
            textBox1.Text = xm;
            textBox2.Text = zyh;

            string sql = "select aac001 from kc21 where akc190='" + zyh + "'";
            var dt = jkdb.Select(sql);
            textBox3.Text = dt.Tables[0].Rows[0]["aac001"].ToString().Trim();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //修改日期 2019_2_20 --czh
            if (string.IsNullOrEmpty(this.textBox3.Text.Trim()))
            {
                MessageBox.Show("个人编号不能为空！");
                return;
            }
            string sql1 = "select sfck,qfybch from inhospital where id=" + id;
            DataTable dt1 = BllMain.Db.Select(sql1).Tables[0];
            int sfck = int.Parse(dt1.Rows[0]["sfck"].ToString());
            //读人员基本信息和帐户信息
            YBCJ_IN yw_in_ryjbxxhzh = new YBCJ_IN();
            yw_in_ryjbxxhzh.Yw = "AA311012";
            yw_in_ryjbxxhzh.Ybcjbz = "1";
            if (sfck == 1)
            {
                yw_in_ryjbxxhzh.Ylzh = "0";
            }
            else
            {
                yw_in_ryjbxxhzh.Ylzh = this.textBox3.Text.Trim();;
            }
            yw_in_ryjbxxhzh.Hisjl = zyh;
            yw_in_ryjbxxhzh.Rc = "";
            int opt_ryjbxxhzh = yw1.ybcjhs(yw_in_ryjbxxhzh);
            if (opt_ryjbxxhzh != 0)
            {
                MessageBox.Show(yw_in_ryjbxxhzh.Mesg, "提示信息");
                return;
            }
            string[] ryjbxxhzh_cc = yw_in_ryjbxxhzh.Cc.Split('|');
            if (ryjbxxhzh_cc[17] == "出院已结算" || ryjbxxhzh_cc[17] == "中途结算")
            {
                MessageBox.Show("此人目前为出院状态，不能做入院登记回退业务操作!", "提示信息");
                return;
            }
            //调用入院登记回退
            YBCJ_IN yw_in_rydjht = new YBCJ_IN();
            yw_in_rydjht.Yw = "DC311001";
            yw_in_rydjht.Ybcjbz = "0";
            if (sfck == 1)
            {
                yw_in_rydjht.Ylzh = "0";
            }
            else
            {
                yw_in_rydjht.Ylzh = this.textBox3.Text.Trim();;
            }
            yw_in_rydjht.Hisjl = zyh;
            yw_in_rydjht.Rc = this.textBox3.Text.Trim() + "|" + zyh;
            int opt_rydjht = yw1.ybcjhs(yw_in_rydjht);
            if (opt_rydjht != 0)
            {
                MessageBox.Show(yw_in_rydjht.Mesg, "提示信息");
                return;
            }
            //入院登记回退成功，删除KC21，kc22 表相应记录
            JKDB jkdb = new JKDB();
            string sql = "delete from KC21 where AKC190='" + zyh + "'";
            jkdb.Update(sql);
            string sql2 = "delete from KC22 where AKC190='" + zyh + "'";
            jkdb.Update(sql2);
            //修改his系统nhflag标志
            string sql4 = "update inhospital set nhflag=0,qfybch='0',bas_patienttype_id='1',Insuritemtype='1'  where id= " + id;//
            string sql3 = "update ihsp_costdet set insursync='N',ybxfdhjebz=0,dqdzxx='',yptsxx='',yblx='',ypspbz=0  where ihsp_id = " + id;//
            BllMain.Db.Update(sql2);
            BllMain.Db.Update(sql4);
            MessageBox.Show("城乡入院登记回退成功！");
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
