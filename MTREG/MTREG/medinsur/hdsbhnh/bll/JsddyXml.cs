using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTREG.medinsur.hdsbhnh.bo;
using System.Data;

using MTREG.common;
using MTHIS.common;
using MTREG.clintab.bo;
using MTREG.ihsptab.bll;

namespace MTREG.medinsur.hdsbhnh.bll
{
    class JsddyXml
    {        
        public int InvoicePrint(string settlementNo,string ihsp_id,string printOrView,StringBuilder rtMessage)
        {
            string functionNo = "B020007";
            HeaderXml haderXml = new HeaderXml();
            BllSnhMethod bllSnhMethod = new BllSnhMethod();
            //住院流水号|个人编号|登记属性|就医机构代码|转外类型|webservice地址|医疗单位身份|目标机构代码|密码|经办人
            HdsbhRegInfo hdsbhRegInfo = bllSnhMethod.readRegInfo(ihsp_id);
            string data = haderXml.allDataInput_head(functionNo, hdsbhRegInfo.TargetOrg, hdsbhRegInfo.Trustpointcode, hdsbhRegInfo.Password);
            data += "<body>";
            data += "<D506_01>" + settlementNo + "</D506_01>";
            data += "</body>";
            data += haderXml.allDatInput_end();
            string[] args = new string[1];
            args[0] = data;
            string nhdata;
            BhnhReturn ret = new BhnhReturn();
            try
            {
                nhdata = (string)BllHdsbhnh.InvokeWebService(hdsbhRegInfo.Weburl, "nh_pipe", args).ToString();//调用webservice是需要创建实例
            }
            catch (Exception er)
            {
                rtMessage.Append("客户端调用失败！" + er.ToString());
                return -1;
            }

            //string data = System.IO.File.ReadAllText(@"d:test.xml");
            //解析返回的xml
            System.IO.StringReader sr = new System.IO.StringReader(nhdata);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables["head"].Rows[0]["stateCode"].ToString() != "0000000")//stateCode 参数返回“0000000”是成功其他失败，其他参数参照文件夹下的文档
            {
                rtMessage.Append("业务调用失败[..失败码:" + nhdata + "..]");
                return -1;
            }
            DataTable dtLbl = new DataTable();
            dtLbl.Columns.Add("Jsdjh", typeof(string));
            dtLbl.Columns.Add("Nhzyh", typeof(string));
            dtLbl.Columns.Add("Zyh", typeof(string));
            dtLbl.Columns.Add("Yljgmc", typeof(string));
            dtLbl.Columns.Add("Yljgdj", typeof(string));
            dtLbl.Columns.Add("Hzxm", typeof(string));
            dtLbl.Columns.Add("Xb", typeof(string));
            dtLbl.Columns.Add("Csrq", typeof(string));
            dtLbl.Columns.Add("Sfzh", typeof(string));
            dtLbl.Columns.Add("Jtbh", typeof(string));
            dtLbl.Columns.Add("Grchh", typeof(string));
            dtLbl.Columns.Add("Bcfl", typeof(string));
            dtLbl.Columns.Add("Lxdh", typeof(string));
            dtLbl.Columns.Add("Ryrq", typeof(string));
            dtLbl.Columns.Add("Cyrq", typeof(string));
            dtLbl.Columns.Add("Fph", typeof(string));
            dtLbl.Columns.Add("Fpsj", typeof(string));
            dtLbl.Columns.Add("Cyks", typeof(string));
            dtLbl.Columns.Add("Ys", typeof(string));
            dtLbl.Columns.Add("Jb", typeof(string));
            dtLbl.Columns.Add("Ss", typeof(string));
            dtLbl.Columns.Add("Cyzd", typeof(string));
            dtLbl.Columns.Add("Hrsx", typeof(string));
            dtLbl.Columns.Add("Xyf", typeof(string));
            dtLbl.Columns.Add("Zyf", typeof(string));
            dtLbl.Columns.Add("Cwf", typeof(string));
            dtLbl.Columns.Add("Hlf", typeof(string));
            dtLbl.Columns.Add("Hyf", typeof(string));
            dtLbl.Columns.Add("Zlf", typeof(string));
            dtLbl.Columns.Add("Ssf", typeof(string));
            dtLbl.Columns.Add("Jcf", typeof(string));
            dtLbl.Columns.Add("Qtf", typeof(string));
            dtLbl.Columns.Add("Fyhj", typeof(string));
            dtLbl.Columns.Add("Ecbcje", typeof(string));
            dtLbl.Columns.Add("Yljgfdje", typeof(string));
            dtLbl.Columns.Add("Bcxyf", typeof(string));
            dtLbl.Columns.Add("Bczyf", typeof(string));
            dtLbl.Columns.Add("Bccwf", typeof(string));
            dtLbl.Columns.Add("Bchlf", typeof(string));
            dtLbl.Columns.Add("Bchyf", typeof(string));
            dtLbl.Columns.Add("Bczlf", typeof(string));
            dtLbl.Columns.Add("Bcshf", typeof(string));
            dtLbl.Columns.Add("Bcjcf", typeof(string));
            dtLbl.Columns.Add("Bcqtf", typeof(string));
            dtLbl.Columns.Add("Bcfyhj", typeof(string));
            dtLbl.Columns.Add("Zf", typeof(string));
            dtLbl.Columns.Add("Sjbcje", typeof(string));
            dtLbl.Columns.Add("Mlwfy", typeof(string));
            dtLbl.Columns.Add("Mlwypfy", typeof(string));
            dtLbl.Columns.Add("Tsbbcljcs", typeof(string));
            dtLbl.Columns.Add("Tsbcljje", typeof(string));
            dtLbl.Columns.Add("Ptzyljbccs", typeof(string));
            dtLbl.Columns.Add("Ptzyljbcje", typeof(string));
            dtLbl.Columns.Add("Dbzljbccs", typeof(string));
            dtLbl.Columns.Add("Dbzljbcje", typeof(string));
            dtLbl.Columns.Add("Fmljbccs", typeof(string));
            dtLbl.Columns.Add("Fmljbcje", typeof(string));
            dtLbl.Columns.Add("Qtzyljbccs", typeof(string));
            dtLbl.Columns.Add("Qtzyljbcje", typeof(string));
            dtLbl.Columns.Add("Jtzhcdje", typeof(string));
            dtLbl.Columns.Add("Tszdjbbcje", typeof(string));
            dtLbl.Columns.Add("Dsfbcylbxbzje", typeof(string));
            dtLbl.Columns.Add("Dsfdejzbcje", typeof(string));
            dtLbl.Columns.Add("Bcfwndyfzgjjbywfy", typeof(string));
            dtLbl.Columns.Add("Fgjjbywfy", typeof(string));
            dtLbl.Columns.Add("Ljybcje", typeof(string));
            dtLbl.Columns.Add("Zzh", typeof(string));
            dtLbl.Columns.Add("Jzbz", typeof(string));
            dtLbl.Columns.Add("Zwlx", typeof(string));
            dtLbl.Columns.Add("Zwlyjgmc", typeof(string));
            dtLbl.Columns.Add("Sfqfx", typeof(string));
            dtLbl.Columns.Add("Bcbl", typeof(string));
            dtLbl.Columns.Add("Ddfdxbs", typeof(string));           

            DataRow row = dtLbl.NewRow();
            row["Jsdjh"] = ds.Tables["baseInfo"].Rows[0]["D506_01"].ToString();
            row["Nhzyh"] = ds.Tables["baseInfo"].Rows[0]["D504_01"].ToString();
            row["Zyh"] = ds.Tables["baseInfo"].Rows[0]["D504_09"].ToString();
            row["Yljgmc"] = ds.Tables["baseInfo"].Rows[0]["D101_02"].ToString(); ;
            row["Yljgdj"] = ds.Tables["baseInfo"].Rows[0]["D504_15"].ToString();
            row["Hzxm"] = ds.Tables["baseInfo"].Rows[0]["D504_03"].ToString();
            row["Xb"] = ds.Tables["baseInfo"].Rows[0]["D504_04"].ToString();
            row["Csrq"] = ds.Tables["baseInfo"].Rows[0]["D504_74"].ToString();
            row["Sfzh"] = ds.Tables["baseInfo"].Rows[0]["D504_05"].ToString();
            row["Jtbh"] = ds.Tables["baseInfo"].Rows[0]["D504_07"].ToString();
            row["Grchh"] = ds.Tables["baseInfo"].Rows[0]["D504_07"].ToString();
            row["Bcfl"] = ds.Tables["baseInfo"].Rows[0]["D504_10"].ToString();
            row["Lxdh"] = ds.Tables["baseInfo"].Rows[0]["D504_75"].ToString();
            row["Ryrq"] = ds.Tables["baseInfo"].Rows[0]["D504_11"].ToString();
            row["Cyrq"] = ds.Tables["baseInfo"].Rows[0]["D504_12"].ToString();
            row["Fph"] = ds.Tables["baseInfo"].Rows[0]["D506_52"].ToString();
            row["Fpsj"] = ds.Tables["baseInfo"].Rows[0]["D506_53"].ToString();
            row["Cyks"] = ds.Tables["baseInfo"].Rows[0]["D504_17"].ToString();
            row["Ys"] = ds.Tables["baseInfo"].Rows[0]["D504_18"].ToString();
            row["Bcrq"] = ds.Tables["baseInfo"].Rows[0]["D506_26"].ToString();
            try
            {
                row["Jb"] = ds.Tables["baseInfo"].Rows[0]["D505_16"].ToString();
            }
            catch
            {
                row["Jb"] = ds.Tables["baseInfo"].Rows[0]["D504_76"].ToString();
            }
            row["Ss"] = ds.Tables["baseInfo"].Rows[0]["D505_17"].ToString();
            row["Cyzd"] = ds.Tables["baseInfo"].Rows[0]["D506_54"].ToString();
            row["Hrsx"] = ds.Tables["baseInfo"].Rows[0]["D505_15"].ToString();
            row["Xyf"] = ds.Tables["allFeeSubentry"].Rows[0]["D506_06"].ToString();
            row["Zyf"] = ds.Tables["allFeeSubentry"].Rows[0]["D506_07"].ToString();
            row["Cwf"] = ds.Tables["allFeeSubentry"].Rows[0]["D506_04"].ToString();
            row["Hlf"] = ds.Tables["allFeeSubentry"].Rows[0]["D506_05"].ToString();
            row["Hyf"] = ds.Tables["allFeeSubentry"].Rows[0]["D506_08"].ToString();    
            row["Zlf"]=ds.Tables["allFeeSubentry"].Rows[0]["D506_09"].ToString();
            row["Ssf"]=ds.Tables["allFeeSubentry"].Rows[0]["D506_10"].ToString();
            row["Jcf"]=ds.Tables["allFeeSubentry"].Rows[0]["D506_11"].ToString();
            row["Qtf"]=ds.Tables["allFeeSubentry"].Rows[0]["D506_12"].ToString();
            row["Fyhj"]=ds.Tables["allFeeSubentry"].Rows[0]["D506_03"].ToString();
            row["Ecbcje"]=ds.Tables["allFeeSubentry"].Rows[0]["D506_104"].ToString();
            row["Yljgfdje"]=ds.Tables["allFeeSubentry"].Rows[0]["D506_105"].ToString();
            row["Bcxyf"]=ds.Tables["computeTypeFee"].Rows[0]["D506_06_A"].ToString();
            row["Bczyf"]=ds.Tables["computeTypeFee"].Rows[0]["D506_07_A"].ToString();
            row["Bccwf"]=ds.Tables["computeTypeFee"].Rows[0]["D506_04_A"].ToString();
            row["Bchlf"]=ds.Tables["computeTypeFee"].Rows[0]["D506_05_A"].ToString();
            row["Bchyf"]=ds.Tables["computeTypeFee"].Rows[0]["D506_08_A"].ToString();
            row["Bczlf"]=ds.Tables["computeTypeFee"].Rows[0]["D506_09_A"].ToString();
            row["Bcshf"]=ds.Tables["computeTypeFee"].Rows[0]["D506_10_A"].ToString();
            row["Bcjcf"]=ds.Tables["computeTypeFee"].Rows[0]["D506_11_A"].ToString();
            row["Bcqtf"]=ds.Tables["computeTypeFee"].Rows[0]["D506_12_A"].ToString();
            row["Bcfyhj"]=ds.Tables["computeTypeFee"].Rows[0]["D506_76"].ToString();
            row["Zf"]=ds.Tables["computeTypeFee"].Rows[0]["D506_32"].ToString();
            row["Sjbcje"]=ds.Tables["computeTypeFee"].Rows[0]["D506_24"].ToString();
            row["Mlwfy"]=ds.Tables["computeTypeFee"].Rows[0]["D506_77"].ToString();
            row["Mlwypfy"]=ds.Tables["computeTypeFee"].Rows[0]["D506_78"].ToString();
            row["Tsbbcljcs"]=ds.Tables["computeTypeFee"].Rows[0]["D506_79"].ToString();
            row["Tsbcljje"] = ds.Tables["computeTypeFee"].Rows[0]["D506_80"].ToString();
            row["Ptzyljbccs"] = ds.Tables["computeTypeFee"].Rows[0]["D506_80"].ToString();
            row["Ptzyljbcje"] = ds.Tables["computeTypeFee"].Rows[0]["D506_80"].ToString();
            row["Dbzljbccs"] = ds.Tables["computeTypeFee"].Rows[0]["D506_80"].ToString();
            row["Dbzljbcje"] = ds.Tables["computeTypeFee"].Rows[0]["D506_80"].ToString();
            row["Fmljbccs"] = ds.Tables["computeTypeFee"].Rows[0]["D506_80"].ToString();
            row["Fmljbcje"] = ds.Tables["computeTypeFee"].Rows[0]["D506_80"].ToString();
            row["Qtzyljbccs"] = ds.Tables["computeTypeFee"].Rows[0]["D506_80"].ToString();
            row["Qtzyljbcje"] = ds.Tables["computeTypeFee"].Rows[0]["D506_80"].ToString();
            row["Jtzhcdje"] = ds.Tables["computeTypeFee"].Rows[0]["D506_80"].ToString();
            row["Tszdjbbcje"] = ds.Tables["computeTypeFee"].Rows[0]["D506_80"].ToString();
            row["Dsfbcylbxbzje"] = ds.Tables["computeTypeFee"].Rows[0]["D506_80"].ToString();
            row["Dsfdejzbcje"] = ds.Tables["computeTypeFee"].Rows[0]["D506_80"].ToString();
            row["Bcfwndyfzgjjbywfy"] = ds.Tables["computeTypeFee"].Rows[0]["D506_80"].ToString();
            row["Fgjjbywfy"] = ds.Tables["computeTypeFee"].Rows[0]["D506_80"].ToString();
            row["Ljybcje"] = ds.Tables["computeTypeFee"].Rows[0]["D506_80"].ToString();
            row["Zzh"] = ds.Tables["computeTypeFee"].Rows[0]["D506_80"].ToString();
            row["Jzbz"] = ds.Tables["computeTypeFee"].Rows[0]["D506_80"].ToString();
            row["Zwlx"] = ds.Tables["computeTypeFee"].Rows[0]["D506_80"].ToString();
            row["Zwlyjgmc"] = ds.Tables["computeTypeFee"].Rows[0]["D506_80"].ToString();
            row["Sfqfx"] = ds.Tables["computeTypeFee"].Rows[0]["D506_80"].ToString();
            row["Bcbl"] = ds.Tables["computeTypeFee"].Rows[0]["D506_80"].ToString();
            row["Ddfdxbs"] = ds.Tables["computeTypeFee"].Rows[0]["D506_80"].ToString();
            if (row["Xb"].ToString() == "2")
            {
                row["Xb"] = "女";
            }
            if (row["Xb"].ToString() == "1")
            {
                row["Xb"] = "男";
            }
            dtLbl.Rows.Add(row);
            BllFrxOper billFrxOper = new BllFrxOper();
            string frmurl = billFrxOper.getPrintFrmurl(SysPrintCodeid.ITFC.ToString()).Rows[0]["frmurl"].ToString();//邯郸市北航打印模板
            string ihspTabForChargerPath = GlobalParams.reportDir + "\\" + frmurl;
            FastReport.Report ihspTabForCharger = new FastReport.Report();
            try
            {
                ihspTabForCharger.Load(ihspTabForChargerPath);
                ihspTabForCharger.RegisterData(dtLbl, "Tb_LblText");
                if (ihspTabForCharger.Prepare() && printOrView == "view")
                {
                    ihspTabForCharger.ShowPrepared();
                }
                else
                {
                    FrxPrintView frxPrintView = new FrxPrintView();
                    frxPrintView.print("IhspTabForCharger.frx", ihspTabForCharger);
                }
            }
            catch
            {
                rtMessage.Append("预览/预览失败！");
                return -1;
            }
            return 0;
        }
    }
}
