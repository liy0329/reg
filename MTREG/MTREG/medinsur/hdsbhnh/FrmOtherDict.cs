using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.hdsbhnh.bo;
using MTREG.medinsur.hdsbhnh.bll;
using MTHIS.main.bll;
using System.Web.UI.WebControls;
using MTHIS.common;

namespace MTREG.medinsur.hdsbhnh
{
    public partial class FrmOtherDict : Form
    {
        BllSnhMethod bllSnhMethod = new BllSnhMethod();
        Header header = new Header();
        DataTable dt_area = new DataTable(); 
        public FrmOtherDict()
        {
            InitializeComponent();
        }

        private void cmbArea_SelectedValueChanged(object sender, EventArgs e)
        {
            header.Password = dt_area.Rows[int.Parse(cmbArea.SelectedIndex.ToString())]["password"].ToString().Trim();
            header.Weburl = dt_area.Rows[int.Parse(cmbArea.SelectedIndex.ToString())]["weburl"].ToString().Trim();
            header.TargetOrg = dt_area.Rows[int.Parse(cmbArea.SelectedIndex.ToString())]["uniquekey"].ToString().Trim(); ;
            header.Trustpointcode = dt_area.Rows[int.Parse(cmbArea.SelectedIndex.ToString())]["trustpointcode"].ToString().Trim();
            header.Name = dt_area.Rows[int.Parse(cmbArea.SelectedIndex.ToString())]["name"].ToString().Trim();
            header.Identity = Convert.ToInt32(dt_area.Rows[int.Parse(cmbArea.SelectedIndex.ToString())]["id"].ToString().Trim());
        }

        private void FrmOtherDict_Load(object sender, EventArgs e)
        {
            dt_area = bllSnhMethod.area();
            cmbArea.DataSource = dt_area;
            cmbArea.ValueMember = "id";
            cmbArea.DisplayMember = "name";

            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("0", "手术字典"));
            items.Add(new ListItem("1", "入院状态字典"));
            items.Add(new ListItem("2", "出院状态字典"));
            items.Add(new ListItem("3", "科室字典"));
            items.Add(new ListItem("4", "登记属性字典"));
            items.Add(new ListItem("5", "补偿分类字典"));
            items.Add(new ListItem("6", "入院类型字典"));
            items.Add(new ListItem("7", "财务分类"));
            items.Add(new ListItem("8", "转外类型"));
            items.Add(new ListItem("9", "机构等级"));
            cmbDictName.DisplayMember = "Text";
            cmbDictName.ValueMember = "Value";
            cmbDictName.DataSource = items;


        }

        private void otherDictIssue_Djsx()//登记属性
        {
            QtzdhqXml qtzdhqXml = new QtzdhqXml();
            string[] param = new string[1];
            param[0] = "12";
            BhnhReturn retdata = qtzdhqXml.membersQueryFunction(header.Weburl, header.Trustpointcode, header.TargetOrg, header.Password, param);
            if (!retdata.Ret_flag)
            {
                MessageBox.Show(retdata.Ret_mesg, "提示信息");
                return;
            }
            //解析返回的xml
            System.IO.StringReader sr = new System.IO.StringReader(retdata.Ret_data);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables["head"].Rows[0]["stateCode"].ToString() != "0000000")//stateCode 参数返回“0000000”是成功其他失败，其他参数参照文件夹下的文档
            {
                MessageBox.Show("业务调用失败[..失败码:" + retdata.Ret_data + "..]");
                return;
            }
            string sql = "delete from insur_hdsbh_sysdict where orgid='" + header.Identity + "' and insurcode='12'";
            BllMain.Db.Update(sql);
            for (int i = 0; i < ds.Tables["item"].Rows.Count; i++)
            {

                string sql1 = "insert into insur_hdsbh_sysdict (insurcode,sn,name,pincode,trustpointcode_id,memo) values('12'" + "'" +
                ds.Tables["baseInfo"].Rows[i]["D911_02"].ToString() + "','" +
                ds.Tables["baseInfo"].Rows[i]["D911_03"].ToString() + "','" +
                ds.Tables["baseInfo"].Rows[i]["D911_04"].ToString() + "'," +
                  header.Identity + ",'" +
                ds.Tables["baseInfo"].Rows[i]["D911_05"].ToString() + "')";
                //调用数据库操作。完成功能。
                BllMain.Db.Update(sql1);
            }
            MessageBox.Show("操作成功！", "提示信息");
        }

        private void otherDictIssue_bcfl()//补偿分类
        {
            //业务类
            QtzdhqXml qtzdhqXml = new QtzdhqXml();
            string[] param = new string[1];
            param[0] = "25";
            BhnhReturn retdata = qtzdhqXml.membersQueryFunction(header.Weburl, header.Trustpointcode, header.TargetOrg, header.Password, param);
            if (!retdata.Ret_flag)
            {
                MessageBox.Show(retdata.Ret_mesg, "提示信息");
                return;
            }
            //解析返回的xml
            System.IO.StringReader sr = new System.IO.StringReader(retdata.Ret_data);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables["head"].Rows[0]["stateCode"].ToString() != "0000000")//stateCode 参数返回“0000000”是成功其他失败，其他参数参照文件夹下的文档
            {
                MessageBox.Show("业务调用失败[..失败码:" + retdata.Ret_data + "..]");
                return;
            }
            string sql = "delete from insur_hdsbh_sysdict where orgid='" + header.Identity + "' and insurcode='25'";
            BllMain.Db.Update(sql);
            for (int i = 0; i < ds.Tables["item"].Rows.Count; i++)
            {
                string bcflpym = GetData.GetChineseSpell((ds.Tables["baseInfo"].Rows[i]["D911_03"].ToString()));
                string sql1 = "insert into insur_hdsbh_sysdict(insurcode,sn,name,pincode,trustpointcode_id) values('25'" + "'" +
                ds.Tables["baseInfo"].Rows[i]["D911_02"].ToString() + "','" +
                ds.Tables["baseInfo"].Rows[i]["D911_03"].ToString() + "','" + 
                bcflpym+"','"+
                header.Identity + "')";
                
                //调用数据库操作。完成功能。
                BllMain.Db.Update(sql1);
            }
            MessageBox.Show("操作成功！", "提示信息");
        }
        /// <summary>
        /// 财务分类
        /// </summary>
        private void otherDictIssue_cwfl()
        {
            QtzdhqXml qtzdhqXml = new QtzdhqXml();
            string[] param = new string[1];
            param[0] = "27";


            BhnhReturn retdata = qtzdhqXml.membersQueryFunction(header.Weburl, header.Trustpointcode, header.TargetOrg, header.Password, param);
            if (!retdata.Ret_flag)
            {
                MessageBox.Show(retdata.Ret_mesg, "提示信息");
                return;
            }
            //解析返回的xml
            System.IO.StringReader sr = new System.IO.StringReader(retdata.Ret_data);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables["head"].Rows[0]["stateCode"].ToString() != "0000000")//stateCode 参数返回“0000000”是成功其他失败，其他参数参照文件夹下的文档
            {
                MessageBox.Show("业务调用失败[..失败码:" + retdata.Ret_data + "..]");
                return;
            }
            string sql = "delete from insur_hdsbh_sysdict where orgid='" + header.Identity + "' and insurcode='27'";
            BllMain.Db.Update(sql);
            for (int i = 0; i < ds.Tables["item"].Rows.Count; i++)
            {
                string cwflpym = GetData.GetChineseSpell(ds.Tables["baseInfo"].Rows[i]["D911_03"].ToString());
                string sql1 = "insert into insur_hdsbh_sysdict(insurcode,sn,name,pincode,trustpointcode_id,memo) values('27'" + "'" +
                 ds.Tables["baseInfo"].Rows[i]["D911_02"].ToString() + "','" +
                 ds.Tables["baseInfo"].Rows[i]["D911_03"].ToString() + "','" +
                 cwflpym + "','" +
                 header.Identity + "','" +
                ds.Tables["baseInfo"].Rows[i]["D911_05"].ToString() + "')";
                BllMain.Db.Update(sql1);
            }
            MessageBox.Show("操作成功！", "提示信息");
        }
        /// <summary>
        /// 转外类型
        /// </summary>
        private void otherDictIssue_zwlx()//转外类型
        {
            QtzdhqXml issue = new QtzdhqXml();
            string[] param = new string[1];
            param[0] = "29";
            BhnhReturn retdata = issue.membersQueryFunction(header.Weburl, header.Trustpointcode, header.TargetOrg, header.Password, param);
            if (!retdata.Ret_flag)
            {
                MessageBox.Show(retdata.Ret_mesg, "提示信息");
                return;
            }
            //解析返回的xml
            System.IO.StringReader sr = new System.IO.StringReader(retdata.Ret_data);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables["head"].Rows[0]["stateCode"].ToString() != "0000000")//stateCode 参数返回“0000000”是成功其他失败，其他参数参照文件夹下的文档
            {
                MessageBox.Show("业务调用失败[..失败码:" + retdata.Ret_data + "..]");
                return;
            }
            string sql = "delete from insur_hdsbh_sysdict where orgid='" + header.Identity + "' and insurcode='29'";
            BllMain.Db.Update(sql);
            for (int i = 0; i < ds.Tables["item"].Rows.Count; i++)
            {

                string sql1 = "insert into otherdictissue_zwlx(insurcode,sn,name,trustpointcode_id) values('29" + "','" +
               ds.Tables["baseInfo"].Rows[i]["D911_02"].ToString() + "','" +
               ds.Tables["baseInfo"].Rows[i]["D911_03"].ToString() + "','" +
               header.Identity + "'";
                //调用数据库操作。完成功能。
               BllMain.Db.Update(sql1);
            }
            MessageBox.Show("操作成功！", "提示信息");
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            switch (cmbDictName.SelectedIndex)
            {
                case 4: otherDictIssue_Djsx(); break;
                case 5: otherDictIssue_bcfl(); break;
                case 8: otherDictIssue_zwlx(); break;
            }
        }
    }
}
