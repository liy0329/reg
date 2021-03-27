using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.hdsbhnh.bll;
using MTREG.medinsur.hdsbhnh.bo;
using MTHIS.common;
using MTHIS.main.bll;

namespace MTREG.medinsur.hdsbhnh
{
    public partial class FrmYljg : Form
    {
        Header header = new Header();
        DataTable dt_area = new DataTable();
        public FrmYljg()
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

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGxypzd_Click(object sender, EventArgs e)
        {
            QtzdhqXml qtzdhqXml = new QtzdhqXml();
            string[] param = new string[1];
            param[0] = "23";
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

            string sql = "delete from insur_hdsbh_hospital where Qhdm=" + DataTool.addFieldBraces(header.TargetOrg);
            BllMain.Db.Update(sql);
            for (int i = 0; i < ds.Tables["item"].Rows.Count; i++)
            {

                string sql1 = "insert into insur_hdsbh_hospital(id,name,pincode,qhdm,jgdj,sbddlx,spddlx,jglb,sfdd,sfxtmryy ,jgzt) values('" +
                ds.Tables["baseInfo"].Rows[i]["D911_02"].ToString() + "','" +//代码
                ds.Tables["baseInfo"].Rows[i]["D911_03"].ToString() + "','" +//名称
                ds.Tables["baseInfo"].Rows[i]["D911_04"].ToString() + "','" +//拼音
                    //ds.Tables["baseInfo"].Rows[i]["D911_05"].ToString() + "','" +//备注
                    //ds.Tables["otherInfo"].Rows[i]["D911_06"].ToString() + "','" +//年份
                    //ds.Tables["otherInfo"].Rows[i]["D911_07"].ToString() + "','" +//区分目录和项目的标志
                ds.Tables["otherInfo"].Rows[i]["D911_08"].ToString() + "','" +//区划代码
                ds.Tables["otherInfo"].Rows[i]["D911_09"].ToString() + "','" +//机构等级
                ds.Tables["otherInfo"].Rows[i]["D911_10"].ToString() + "','" +//申报定点类型
                ds.Tables["otherInfo"].Rows[i]["D911_11"].ToString() + "','" +//审批定点类型
                ds.Tables["otherInfo"].Rows[i]["D911_12"].ToString() + "','" + //机构类别
                ds.Tables["otherInfo"].Rows[i]["D911_13"].ToString() + "','" + //是否定点
                ds.Tables["otherInfo"].Rows[i]["D911_14"].ToString() + "','" + //是否系统默认医院
                ds.Tables["otherInfo"].Rows[i]["D911_15"].ToString() + "')"; //机构状态

                //调用数据库操作。完成功能。
                if (ds.Tables["otherInfo"].Rows[i]["D911_08"].ToString() == header.TargetOrg)
                    BllMain.Db.Update(sql1);

            }
            string sql2 = "select id,name,pincode,jgbz,jgnf,cfmlhxmdbz,qhdm,jgdj,sbddlx,spddlx,jglb,sfdd,sfxtmryy ,jgzt from insur_hdsbh_hospital where Qhdm=" + DataTool.addFieldBraces(header.TargetOrg);
            DataTable dt = BllMain.Db.Select(sql2).Tables[0];
            this.dgvHospital.DataSource = dt.DefaultView;
            this.dgvHospital.Focus();
        }

        private void FrmYljg_Load(object sender, EventArgs e)
        {
            BllSnhMethod bllSnhMethod = new BllSnhMethod();
            dt_area = bllSnhMethod.area();
            cmbArea.DataSource = dt_area;
            cmbArea.ValueMember = "id";
            cmbArea.DisplayMember = "name";


        }

        /// <summary>
        /// 区域选择变化时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbArea_SelectedValueChanged(object sender, EventArgs e)
        {
            header.Password = dt_area.Rows[int.Parse(cmbArea.SelectedValue.ToString())]["password"].ToString().Trim();
            header.Weburl = dt_area.Rows[int.Parse(cmbArea.SelectedValue.ToString())]["weburl"].ToString().Trim();
            header.TargetOrg = dt_area.Rows[int.Parse(cmbArea.SelectedValue.ToString())]["uniquekey"].ToString().Trim(); ;
            header.Trustpointcode = dt_area.Rows[int.Parse(cmbArea.SelectedValue.ToString())]["trustpointcode"].ToString().Trim();
            header.Name = dt_area.Rows[int.Parse(cmbArea.SelectedValue.ToString())]["name"].ToString().Trim();
            header.Identity = Convert.ToInt32(dt_area.Rows[int.Parse(cmbArea.SelectedValue.ToString())]["id"].ToString().Trim());
            string sql2 = "select * from insur_hdsbh_hospital where Qhdm=" + DataTool.addFieldBraces(header.TargetOrg);
            DataTable dt = BllMain.Db.Select(sql2).Tables[0];
            this.dgvHospital.DataSource = dt.DefaultView;
            this.dgvHospital.Focus();
        }
    }
}
