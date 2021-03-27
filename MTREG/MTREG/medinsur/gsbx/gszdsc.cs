using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using WindowsFormsApplication1.common;
using System.IO;
using System.Security.Cryptography;
using zhongluyiyuan.db;
using zhongluyiyuan.Common;
using zhongluyiyuan.global;
using zhongluyiyuan.Entity;
using zhongluyiyuan.gsbx.bll;
using zhongluyiyuan.Util;
using zhongluyiyuan.gsbx1;
using zhongluyiyuan.listitem;
namespace zhongluyiyuan.gsbx
{
    class gszdsc
    {
        string sessionid = "";
        public RetMsg ybscfymx(int mtzyjliid, string grbh, string zyh)
        {
            string mesg = "";
            RetMsg ret = new RetMsg();
            ret.Retint = true;
            int retnum = 1;
            HISDB hisdb = new HISDB();
            string sql_xgscbzwl = "update mtzyjlstuff set ybsc = 0 where ybsc is null and  mtzyjl = " + mtzyjliid;
            hisdb.Update(sql_xgscbzwl);
            string sql_xgsfdmbz = "update mtzyjlstuff set sfdmbz = 1 where sfdmbz is null and ybsc=0 and  mtzyjl = " + mtzyjliid;
            hisdb.Update(sql_xgsfdmbz);
            string sql_xgbzwl = "update mtzyjlstuff set ypspbz = 0 where ybsc=0 and ypspbz is null and  mtzyjl = " + mtzyjliid;
            hisdb.Update(sql_xgbzwl);
            while (retnum > 0)
            {
                retnum = scfymx(mtzyjliid, grbh, zyh, out mesg);
                if (retnum == -1)
                {
                    ret.Retint = false;
                    ret.Mesg = mesg;
                    return ret;
                }
            }
            return ret;
        }
        private int scfymx(int mtzyjliid, string grbh, string zyh, out string mesg)
        {
            
            DlDC dldc = new DlDC();
            GSBX_IN in1 = new GSBX_IN();
            GSBX_OUT out1 = new GSBX_OUT();
            GSBXinterface GSBXinterface = new GSBXinterface();
            mesg = "";
            int retnum = 0;
            string flag = dldc.dengru();
            if (flag == "1")
            {
                mesg+=dldc.Message;
                retnum = -1;
                return retnum;
            }
            sessionid = dldc.Sessionid;
            HISDB hisdb = new HISDB();
            string sql = " select mtzyjlstuff.iid as cfh,to_char(mtzyjlstuff.createdat,'yyyy-MM-dd') as cfsj,'1' as cfts,mtprod.chargesn as xmbm,mtzyjlstuff.xmmc as xmmc,mtzyjlstuff.xmmc as tym, gsxmlb.id as sflb,'' as sfdj,case  when (mtzyjlstuff.projecttype='2') or (mtzyjlstuff.projecttype='3' ) or (mtzyjlstuff.projecttype='4') then '0' else '1' end as zl,mtzyjlstuff.prc,mtzyjlstuff.qty as num,mtzyjlstuff.amt,mtzyjlstuff.guige,prodjixing.name as jixing "
                       + " from mtzyjlstuff,mtprod,prodjixing,gsxmlb where mtzyjlstuff.mtprod=mtprod.iid and gsxmlb.hisid=mtzyjlstuff.projecttype and prodjixing.iid=mtprod.prodjixing and mtzyjlstuff.ybsc=0 "
                       + " and mtzyjlstuff.mtzyjl= " + mtzyjliid + " "
                       + "union  "
                       + " select mtzyjlstuff.iid as cfh,to_char(mtzyjlstuff.createdat,'yyyy-MM-dd') as cfsj,'1' as cfts,mtjcxm.sym as xmbm,mtzyjlstuff.xmmc as xmmc,mtzyjlstuff.xmmc as tym, gsxmlb.id as sflb,'' as sfdj,case  when (mtzyjlstuff.projecttype='2') or (mtzyjlstuff.projecttype='3' ) or (mtzyjlstuff.projecttype='4') then '0' else '1' end as zl,mtzyjlstuff.prc,mtzyjlstuff.qty as num,mtzyjlstuff.amt,mtzyjlstuff.guige,'' as jixing "
                       + " from mtzyjlstuff,mtjcxm,gsxmlb where mtzyjlstuff.mtprod=mtjcxm.iid and gsxmlb.hisid=mtzyjlstuff.projecttype  and mtzyjlstuff.ybsc=0 "
                       + " and mtzyjlstuff.mtzyjl=" + mtzyjliid;
            DataTable dt = hisdb.Select(sql).Tables[0];
            in1.Log_name = "费用上传";
            in1.YwName = "sendMedInfo";
            string data = "<medReqData>";
            data += " <sessionid>" + sessionid + "</sessionid>";
            data += " <akc190>" + zyh + "</akc190>";
            data += "<advices>";
            data += "</advices>";
            data += "<meds>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                data += "<med>";
                data += "<alc400>" + dt.Rows[i]["cfh"].ToString().Trim() + "</alc400>";
                data += "<alc401>" + dt.Rows[i]["cfsj"].ToString().Trim() + "</alc401>";
                data += "<akc229>" + dt.Rows[i]["cfts"].ToString().Trim() + "</akc229>";
                data += "<alc402>" + dt.Rows[i]["xmbm"].ToString().Trim() + "</alc402>";
                data += "<alc403>" + dt.Rows[i]["xmmc"].ToString().Trim() + "</alc403>";
                data += "<aka063>" + dt.Rows[i]["sflb"].ToString().Trim() + "</aka063>";
                data += "<aka065>" + dt.Rows[i]["sfdj"].ToString().Trim() + "</aka065>";
                data += "<alc404>" + dt.Rows[i]["zl"].ToString().Trim() + "</alc404>";
                data += "<alc405>" + dt.Rows[i]["prc"].ToString().Trim() + "</alc405>";
                data += "<alc406>" + dt.Rows[i]["num"].ToString().Trim() + "</alc406>";
                data += "<alc407>" + dt.Rows[i]["amt"].ToString().Trim() + "</alc407>";
                data += "<aka070>" + dt.Rows[i]["jixing"].ToString().Trim() + "</aka070>";
                data += "<zka100>" + dt.Rows[i]["guige"].ToString().Trim() + "</zka100>";
                data += "<akc230></akc230>";
                data += "<akc231>" + dt.Rows[i]["tym"].ToString().Trim() + "</akc231>";
                data += "<akc515>" + dt.Rows[i]["xmbm"].ToString().Trim() + "</akc515>";
                data += "<reason></reason>";
                data += "<noinjury></noinjury>";
                data += "</med>";
            }
            data += "</meds>";
            data += " </medReqData>";
            in1.YwData = Base64.encodebase64(in1.head() + data);

            out1 = GSBXinterface.request(in1);
            if (out1.State == "2")
            {
                mesg+=out1.Message;
                string flag11 = dldc.dengchu(sessionid);
                if (flag11 == "1")
                {
                    mesg += dldc.Message;
                    retnum = -1;
                    return retnum;
                }
                sessionid = "";
                retnum = -1;
                return retnum;
            }

            out1.State = out1.Ds.Tables["medInfoRespData"].Rows[0]["code"].ToString().Trim();
            out1.Message = out1.Ds.Tables["medInfoRespData"].Rows[0]["msg"].ToString().Trim();
            if (out1.State != "0")
            {
                MessageBox.Show("工伤保险提示！\r\n" + in1.Log_name + "出错！\r\n【" + out1.Message + "】");
                string flag11 = dldc.dengchu(sessionid);
                if (flag11 == "1")
                {
                    mesg += dldc.Message;
                    retnum = -1;
                    return retnum;
                }
                sessionid = "";
                retnum = -1;
                return retnum;
            }
            //string count = out1.Ds.Tables["injuryRespData"].Rows[0]["counts"].ToString().Trim();
            //insertgsxx(count, out1.Ds);
            //lab_ysx.Text = out1.Ds.Tables["medInfoRespData"].Rows[0]["count"].ToString().Trim();
            string sql_up = "update mtzyjlstuff set ybsc=1 where mtzyjl=" + mtzyjliid + "; ";
            return retnum;
        }
    }
}
