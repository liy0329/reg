using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MTREG.medinsur.gzsyb.bll;
using MTREG.medinsur.hdyb.clinic.bo;
using MTREG.ihsp;
using MTHIS.common;
using MTREG.medinsur.hdyb.bo;
using MTREG.medinsur.hdyb.bll;
using MTREG.clinic.bo;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using MTREG.medinsur.hdyb.clinic.bll;
using MTREG.common;
using MTREG.common.bll;
using MTREG.medinsur.hdyb;
using MTREG.medinsur.hdyb.dor;
using MTHIS.main.bll;
using MTREG.medinsur;
using System.Drawing;
using MTREG.clinic.bll;

namespace MTREG.kls
{
    public partial class Frmxzybml : Form
    {
        Gzsybservice Swybservice = new Gzsybservice();
        public Frmxzybml()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rq = dateTimeYdyb.Value.ToLocalTime().ToString().Split(' ')[0];
            Swybservice.xzfwxmml(rq);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            YBCJ yw1 = new YBCJ();
            string sql_prod = @"SELECT
	                            bas_item.id,
	                            bas_item.standcode AS sfxmdm,
	                            bas_item. NAME AS xmmc,
                                bas_item.itemfrom,
	                            (
		                            SELECT
			                            insur_itemfrom.insurcode
		                            FROM
			                            insur_itemfrom
		                            WHERE
			                            insur_itemfrom.itemtype_id = bas_item.itemtype_id
		                            AND insur_itemfrom.cost_insurtype_id = 6
	                            ) AS itemfromcode
                            FROM
	                            bas_item where sfsc=0";
            Sfbx bx = new Sfbx();
            DataTable dt_xmcx = BllMain.Db.Select(sql_prod).Tables[0];
            if (dt_xmcx.Rows.Count == 0)
            {
                return;
            }
            string mesg_pd = "";
            for (int j = 0; j < dt_xmcx.Rows.Count; j++)
            {
                #region
                string iid = dt_xmcx.Rows[j]["id"].ToString().Trim();
                string sfxmdm = dt_xmcx.Rows[j]["sfxmdm"].ToString().Trim();
                string xmmc = dt_xmcx.Rows[j]["xmmc"].ToString().Trim();
                string insurcode = dt_xmcx.Rows[j]["itemfromcode"].ToString();//药品/诊疗/床位费
                string itemfrom = dt_xmcx.Rows[j]["itemfrom"].ToString();
                if (string.IsNullOrEmpty(sfxmdm))
                {
                    mesg_pd += "[项目医保编码为空：" + iid + "-" + xmmc + "]\r\n";
                    continue;
                }
                string projecttype = dt_xmcx.Rows[j]["itemfromcode"].ToString().Trim();
                //三目录对照函数
                YBCJ_IN yw_in_smldz = new YBCJ_IN();
                yw_in_smldz.Ybcjbz = "1";
                yw_in_smldz.Ylzh = "130425196402243036";
                yw_in_smldz.Rc = sfxmdm;
                if (insurcode == ((int)InsurEnum.Yzc.YP).ToString())
                {
                    yw_in_smldz.Yw = "BB31KA02";
                    int opt_smldz = yw1.ybcjhs(yw_in_smldz);
                    if (opt_smldz != 0)
                    {
                        mesg_pd += "[对照药品失败：" + iid + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
                        continue;
                    }
                    string[] smldz_cc = yw_in_smldz.Cc.Split('|');
                    if (smldz_cc[1] == "XX")
                    {
                        mesg_pd += "[药品没有对码：" + iid + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
                        continue;
                    }
                    if (renewCatalog(smldz_cc, iid, sfxmdm, xmmc, itemfrom) != 0)
                    {
                        MessageBox.Show("药品更新失败【ID："+iid+"name:"+xmmc+"】");
                        continue;
                    }
                }
                //读取床位信息
                else if (insurcode == ((int)InsurEnum.Yzc.CWF).ToString())
                {
                    yw_in_smldz.Yw = "BB31KA04";
                    int opt_smldz = yw1.ybcjhs(yw_in_smldz);
                    if (opt_smldz != 0)
                    {
                        mesg_pd += "[对照床位失败：" + iid + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
                        continue;
                    }
                    string[] smldz_cc = yw_in_smldz.Cc.Split('|');
                    if (smldz_cc[1] == "XX")
                    {
                        mesg_pd += "[床位没有对码：" + iid + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
                        continue;
                    }
                    if (renewCatalog(smldz_cc, iid, sfxmdm, xmmc, itemfrom) != 0)
                    {
                        MessageBox.Show("药品更新失败【ID：" + iid + "name:" + xmmc + "】");
                        continue;
                    }
                }
                //读取诊疗信息
                else if (insurcode == ((int)InsurEnum.Yzc.ZL).ToString())
                {
                    yw_in_smldz.Yw = "BB31KA03";
                    int opt_smldz = yw1.ybcjhs(yw_in_smldz);
                    if (opt_smldz != 0)
                    {
                        mesg_pd += "[对照诊疗失败：-" + iid + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
                        continue;
                    }
                    string[] smldz_cc = yw_in_smldz.Cc.Split('|');
                    if (smldz_cc[1] == "XX")
                    {
                        mesg_pd += "[诊疗没有对码：-" + iid + "-" + xmmc + "-" + yw_in_smldz.Mesg + "]\r\n";
                        continue;
                    }
                    if (renewCatalog(smldz_cc, iid, sfxmdm, xmmc, itemfrom) != 0)
                    {
                        MessageBox.Show("药品更新失败【ID：" + iid + "name:" + xmmc + "】");
                        continue;
                    }
                }
                #endregion
            }
            if (!string.IsNullOrEmpty(mesg_pd))
            {
                FrmMesg frmmesg = new FrmMesg();
                frmmesg.StartPosition = FormStartPosition.CenterScreen;
                frmmesg.In_mesg = mesg_pd;
                frmmesg.ShowDialog(this);
            }
        }
        /// <summary>
        /// 没有完成
        /// </summary>
        /// <param name="smldz_cc"></param>
        /// <param name="insurcode"></param>
        /// <returns></returns>
        private int renewCatalog(string[] smldz_cc, string itemid, string xmbm, string name, string itemfrom)
        {
            string id = getMaxid(itemid,name);
            if (id == "0")
            {
                string sql_updaterenew = @"update cost_insurcross set itemfrom = "
                                                + DataTool.addFieldBraces(itemfrom)
                                                + ",insurclass = " + DataTool.addFieldBraces(smldz_cc[0])
                                                + ",limituse = " + DataTool.addFieldBraces(smldz_cc[6])
                                                + ",hiscode = " + DataTool.addFieldBraces(xmbm)
                                                + ",insuritemtype='41'"
                                                + " where item_id = " + itemid + " and insurname = '" + name + "'";
                if (BllMain.Db.Update(sql_updaterenew) != 0)
                {
                    return -1;
                }
                string sqlsx = "update bas_item set sfsc=1 where id=" + itemid + "";
                BllMain.Db.Update(sqlsx);
                return 0;
            }
            string sql_renew = @"insert into cost_insurcross (id,
                                          insuritemtype,
                                          itemfrom,
                                          item_id,
                                          insurname,
                                          insurclass,
                                          limituse,
                                          hiscode)
                                        values (" +
                                                (Convert.ToInt32(id) + 1).ToString()+","
                                                + "'41',"
                                                + DataTool.addFieldBraces(itemfrom) + ","
                                                + DataTool.addFieldBraces(itemid) + ","
                                                + DataTool.addFieldBraces(name) + ","
                                                + DataTool.addFieldBraces(smldz_cc[0]) + ","
                                                + DataTool.addFieldBraces(smldz_cc[6]) + ","
                                                + DataTool.addFieldBraces(xmbm)
                                               +")";
            if (BllMain.Db.Update(sql_renew)!=0)
            {
                return -1;
            }
            string sqlsx1 = "update bas_item set sfsc=1 where id=" + itemid + "";
            BllMain.Db.Update(sqlsx1);
            return 0;
        }

        private string getMaxid(string id,string name)
        {
            string sql_ = "select COUNT(*) as c from cost_insurcross where item_id = " + id + " and insurname = '"+ name+"'";
            DataTable dt = BllMain.Db.Select(sql_).Tables[0];
            if (Convert.ToInt32(dt.Rows[0][0].ToString()) == 0)
            {
                string sql_Maxid = "select max(id) as id from cost_insurcross ";
                DataTable tb = BllMain.Db.Select(sql_Maxid).Tables[0];
                if (tb.Rows[0][0].ToString() == "" || tb.Rows[0][0].ToString() == null)
                    return "1";
                return tb.Rows[0][0].ToString();
            }
            return "0";
        }
    }
}
