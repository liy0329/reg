using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTREG.medinsur.hdsbhnh.bo;
using System.Data;
using MTHIS.main.bll;
using MTHIS.common;
using MTREG.common;
using MTREG.common.bll;

namespace MTREG.medinsur.hdsbhnh.bll
{
    class ZyjzXml
    {
        //住院记账B020004
        private int zhuYuanDanTiaoJiZhang_data(string weburl, string targetOrg, string identity, string password, string ihsp_id,string patienttypeid, out string mesg)
        {
            mesg = "";
            string sql = "select cost_insurtype_id from bas_patienttype where id=" + DataTool.addFieldBraces(patienttypeid);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            string insurtypeid = dt.Rows[0]["cost_insurtype_id"].ToString();
            string sql1 = "select inhospital.ihspcode"
                            + ", ihsp_costdet.id"
                            + ", ihsp_costdet.chargedate"
                            + ", ihsp_costdet.name"
                            + ", ihsp_costdet.standcode"
                            + ", cost_itemtype.itemtype_id"
                            + ", insur_itemfrom.insurcode as itemfromcode"
                            + ", ihsp_costdet.spec"
                            + ", ihsp_costdet.prc"
                            + ", ihsp_costdet.fee"
                            + ", ihsp_costdet.num"
                            + ", ihsp_costdet.item_id"
                            + ", ihsp_costdet.chargedate"
                            + ", ihsp_costdet.itemtype_id"
                            + ", sys_dict.name as dosageform"
                            + ", bas_item.name as hisname"
                            + ", bas_item.hiscode"
                            + ", cost_insuritem.name as nh_name"
                            + ", cost_insuritem.insurcode as nh_code"
                            + " from ihsp_costdet"
                            + " left join inhospital on inhospital.id=ihsp_costdet.ihsp_id"
                            + " lfet join insur_itemfrom on insur_itemfrom.itemtype_id=ihsp_costdet.itemtype_id"
                            + " left join cost_insurcross on cost_insurcross.item_id=ihsp_costdet.item_id"
                            + " left join cost_insuritem on cost_insurcross.cost_insuritem_id=cost_insuritem.id"
                            + " left join bas_item on bas_item.id=ihsp_costdet.item_id"
                            + " left join sys_dict on bas_item.dosageform_id=sys_dict.sn and sys_dict.dicttype='drug_dosageform' and father<>0"
                            + " where ihsp_costdet.ihsp_id=" + DataTool.addIntBraces(ihsp_id)
                            + " and insur_itemfrom.cost_insurtype_id=" + DataTool.addFieldBraces(insurtypeid)
                            + " and ihsp_costdet.insursync='N' "
                            + " and ihsp_costdet.charged in ('RREC','RET','CHAR')";
            DataSet ds = BllMain.Db.Select(sql1);
            if (ds.Tables.Count <= 0)
            {
                //未找到相关表信息!
                return -3;
            }
            DataTable datatable = ds.Tables[0];
            if (datatable.Rows.Count <= 0)
            {
                //无可传输项
                return -4;
            }
            string functionNo = "B020004";
            HeaderXml allxml = new HeaderXml();
            string headdata = allxml.allDataInput_head(functionNo, targetOrg, identity, password);
            string enddata = allxml.allDatInput_end();

            string yphead = "<D505_03_01>";//药品开标签
            string xyhead = "<D505_30_01>";//西药开标签
            string xydata = "";             //西药明细
            string xyend = "</D505_30_01>";//西药闭标签
            string zcyhead = "<D505_30_02>";//中成药开标签
            string zcydata = "";            //中成药明细
            string zcyend = "</D505_30_02>";//中成药闭标签
            string zcaoyhead = "<D505_30_03>";//中草药开标签
            string zcaoydata = "";           //中草药明细
            string zcaoyend = "</D505_30_03>";//中草药闭标签
            string ypend = "</D505_03_01>";//药品闭标签
            string clhead = "<D505_03_03>";//材料开标签
            string cldata = "";            //材料明细
            string clend = "</D505_03_03>";//材料闭标签
            string zlhead = "<D505_03_02>";//诊疗开标签
            string zldata = "";             //诊疗明细
            string zlend = "</D505_03_02>";//诊疗闭标签
            string aaa = "";
            int retnum = 0;
            retnum = dt.Rows.Count;
            if (retnum == 0)
            {
                return retnum;
            }
            string kdsj="";
            string ihspcode = "";
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                ihspcode=datatable.Rows[i]["ihspcode"].ToString().Trim();
                kdsj = DateTime.Parse(datatable.Rows[i]["chargedate"].ToString()).ToString("yyyy-MM-ddTHH-mm-ss");//开单时间必填    yyyy-mm-ddT24-mi-ss，强制要求位数，需补齐
                string type = datatable.Rows[i]["type"].ToString().Trim();//类型
                string mtzyjlstuffiid = datatable.Rows[i]["id"].ToString().Trim();

                string his_bm = datatable.Rows[i]["hiscode"].ToString().Trim();//his编码
                string xmmc = datatable.Rows[i]["hisname"].ToString().Trim();//项目名称
                string jx = datatable.Rows[i]["dosageform"].ToString().Trim();//剂型
                string guige = datatable.Rows[i]["spec"].ToString().Trim();//规格
                string prc = datatable.Rows[i]["prc"].ToString().Trim();//单价
                string dj = Convert.ToDouble(prc).ToString("0.00").Trim() + "00";//保留小数点后四位 //单价
                string sl = datatable.Rows[i]["num"].ToString().Trim();//数量

                string fee = datatable.Rows[i]["fee"].ToString().Trim();//金额
                string je = Convert.ToDouble(fee).ToString("0.00").Trim() + "00";//保留小数点后四位,结果为//金额
                string nh_bm = datatable.Rows[i]["nh_code"].ToString().Trim();//农合编码
                string nh_mc = datatable.Rows[i]["nh_name"].ToString().Trim();//农合名称
                string zzz = datatable.Rows[i]["id"].ToString().Trim() + ",";
                aaa += zzz;
                if (type == "10" || type == "11" || type == "12")
                {
                    if (type == "10")//西药
                    {
                        xydata += "<item>";
                        xydata += "<D505_04>" + his_bm + "</D505_04>";//医院项目编码
                        xydata += "<D505_16>" + xmmc + "</D505_16>";//医院项目名称
                        xydata += "<D505_06>" + jx + "</D505_06>";//剂型
                        xydata += "<D505_05>" + guige + "</D505_05>";//规格
                        xydata += "<D505_07>" + dj + "</D505_07>"; //单价
                        xydata += "<D505_08>" + sl + "</D505_08>"; //数量
                        xydata += "<D505_10>" + je + "</D505_10>";//金额
                        if (nh_bm == "" || nh_bm == null)
                        {
                            xydata += "<D505_35>" + his_bm + "</D505_35>";//标准项目编码
                        }
                        else
                        {
                            xydata += "<D505_35>" + nh_bm + "</D505_35>";//标准项目编码
                        }
                        if (nh_mc == "" || nh_mc == null)
                        {
                            xydata += "<D505_36>" + xmmc + "</D505_36>";//标准项目名称
                        }
                        else
                        {
                            xydata += "<D505_36>" + nh_mc + "</D505_36>";//标准项目名称
                        }
                        xydata += "<D505_31></D505_31>";//包装
                        xydata += "<D505_01>" + mtzyjlstuffiid + "</D505_01>";//住院处方流水号
                        xydata += "<D505_14>" + mtzyjlstuffiid + "</D505_14>";//明细费用流水号
                        xydata += "</item>" + "\r\n";

                    }
                    if (type == "11")//中成药
                    {
                        zcydata += "<item>";
                        zcydata += "<D505_04>" + his_bm + "</D505_04>";//医院项目编码
                        zcydata += "<D505_16>" + xmmc + "</D505_16>";//医院项目名称
                        zcydata += "<D505_06>" + jx + "</D505_06>";//剂型
                        zcydata += "<D505_05>" + guige + "</D505_05>";//规格
                        zcydata += "<D505_07>" + dj + "</D505_07>";//单价
                        zcydata += "<D505_08>" + sl + "</D505_08>";//数量
                        zcydata += "<D505_10>" + je + "</D505_10>";//金额
                        if (nh_bm == "" || nh_bm == null)
                        {
                            zcydata += "<D505_35>" + his_bm + "</D505_35>";//标准项目编码
                        }
                        else
                        {
                            zcydata += "<D505_35>" + nh_bm + "</D505_35>";//标准项目编码
                        }
                        if (nh_mc == "" || nh_mc == null)
                        {
                            zcydata += "<D505_36>" + xmmc + "</D505_36>";//标准项目名称
                        }
                        else
                        {
                            zcydata += "<D505_36>" + nh_mc + "</D505_36>";//标准项目名称
                        }
                        zcydata += "<D505_31></D505_31>";//包装
                        zcydata += "<D505_01>" + mtzyjlstuffiid + "</D505_01>";//住院处方流水号
                        zcydata += "<D505_14>" + mtzyjlstuffiid + "</D505_14>";//明细费用流水号
                        zcydata += "</item>" + "\r\n";
                    }
                    if (type == "12")//中草药
                    {
                        zcaoydata += "<item>";
                        zcaoydata += "<D505_04>" + his_bm + "</D505_04>";//医院项目编码
                        zcaoydata += "<D505_16>" + xmmc + "</D505_16>";//医院项目名称
                        zcaoydata += "<D505_06>" + jx + "</D505_06>";//剂型
                        zcaoydata += "<D505_05>" + guige + "</D505_05>";//规格
                        zcaoydata += "<D505_07>" + dj + "</D505_07>";//单价
                        zcaoydata += "<D505_08>" + sl + "</D505_08>";//数量
                        zcaoydata += "<D505_10>" + je + "</D505_10>";//金额
                        if (nh_bm == "" || nh_bm == null)
                        {
                            zcaoydata += "<D505_35>" + his_bm + "</D505_35>";//标准项目编码
                        }
                        else
                        {
                            zcaoydata += "<D505_35>" + nh_bm + "</D505_35>";//标准项目编码
                        }
                        if (nh_mc == "" || nh_mc == null)
                        {
                            zcaoydata += "<D505_36>" + xmmc + "</D505_36>";//标准项目名称
                        }
                        else
                        {
                            zcaoydata += "<D505_36>" + nh_mc + "</D505_36>";//标准项目名称
                        }
                        zcaoydata += "<D505_31></D505_31>";//包装
                        zcaoydata += "<D505_09></D505_09>";//付数
                        zcaoydata += "<D505_01>" + mtzyjlstuffiid + "</D505_01>";//住院处方流水号
                        zcaoydata += "<D505_14>" + mtzyjlstuffiid + "</D505_14>";//明细费用流水号
                        zcaoydata += "</item>" + "\r\n";
                    }
                }
                else if (type == "9")//材料
                {
                    cldata += "<item>";
                    cldata += "<D505_04>" + his_bm + "</D505_04>";//医院项目编码
                    cldata += "<D505_16>" + xmmc + "</D505_16>";//医院项目名称
                    cldata += "<D505_07>" + dj + "</D505_07>";//单价
                    cldata += "<D505_08>" + sl + "</D505_08>";//数量
                    cldata += "<D505_10>" + je + "</D505_10>";//金额
                    if (nh_bm == "" || nh_bm == null)
                    {
                        cldata += "<D505_35>" + his_bm + "</D505_35>";//标准项目编码
                    }
                    else
                    {
                        cldata += "<D505_35>" + nh_bm + "</D505_35>";//标准项目编码
                    }
                    if (nh_mc == "" || nh_mc == null)
                    {
                        cldata += "<D505_36>" + xmmc + "</D505_36>";//标准项目名称
                    }
                    else
                    {
                        cldata += "<D505_36>" + nh_mc + "</D505_36>";//标准项目名称
                    }
                    cldata += "<D505_05>" + guige + "</D505_05>";//规格
                    cldata += "<D505_31></D505_31>";//包装
                    cldata += "<D505_01>" + mtzyjlstuffiid + "</D505_01>";//住院处方流水号
                    cldata += "<D505_14>" + mtzyjlstuffiid + "</D505_14>";//明细费用流水号
                    cldata += "</item>" + "\r\n";

                }
                else//诊疗
                {
                    string cwfl = "I";//其他费用
                    if (type == "1")
                    {
                        cwfl = "A";//挂号费
                    }
                    if (type == "2")
                    {
                        cwfl = "B";//诊查费
                    }
                    if (type == "7")
                    {
                        cwfl = "C";//床位费
                    }
                    if (type == "3")
                    {
                        cwfl = "D";//检查费

                    }
                    if (type == "5")
                    {
                        cwfl = "E";//治疗费
                    }
                    if (type == "8")
                    {
                        cwfl = "F";//护理费
                    }
                    if (type == "6")
                    {
                        cwfl = "G";//手术费
                    }//
                    if (type == "4")
                    {
                        cwfl = "H";//化验费
                    }

                    zldata += "<item>";
                    zldata += "<D505_04>" + his_bm + "</D505_04>";//医院项目编码
                    zldata += "<D505_16>" + xmmc + "</D505_16>";//医院项目名称
                    zldata += "<D505_07>" + dj + "</D505_07>";//单价
                    zldata += "<D505_08>" + sl + "</D505_08>";//数量
                    zldata += "<D505_10>" + je + "</D505_10>";//金额
                    zldata += "<D505_32>" + cwfl + "</D505_32>";//财务分类
                    if (nh_bm == "" || nh_bm == null)
                    {
                        zldata += "<D505_35>" + his_bm + "</D505_35>";//标准项目编码
                    }
                    else
                    {
                        zldata += "<D505_35>" + nh_bm + "</D505_35>";//标准项目编码
                    }
                    if (nh_mc == "" || nh_mc == null)
                    {
                        zldata += "<D505_36>" + xmmc + "</D505_36>";//标准项目名称
                    }
                    else
                    {
                        zldata += "<D505_36>" + nh_mc + "</D505_36>";//标准项目名称
                    }
                    zldata += "<D505_37>" + "</D505_37>";//单位
                    zldata += "<D505_01>" + mtzyjlstuffiid + "</D505_01>";//住院处方流水号
                    zldata += "<D505_14>" + mtzyjlstuffiid + "</D505_14>";//明细费用流水号
                    zldata += "</item>" + "\r\n";
                }
            }

            string bodydata = "<body>";
            bodydata += "<D504_09>" + ihspcode + "</D504_09>";//住院号

            bodydata += "<D505_13>" + kdsj + "</D505_13>";//开单时间
            bodydata += "<D505_33>" + "</D505_33>";//合作标识
            bodydata += "<D505_34>" + "</D505_34>";//转外医疗机构
            bodydata += "<D505_12>" + "</D505_12>";//医生姓名

            bodydata += "<details>";
            bodydata += yphead;
            bodydata += xyhead;
            bodydata += xydata;
            bodydata += xyend;
            bodydata += zcyhead;
            bodydata += zcydata;
            bodydata += zcyend;
            bodydata += zcaoyhead;
            bodydata += zcaoydata;
            bodydata += zcaoyend;
            bodydata += ypend;
            bodydata += zlhead;
            bodydata += zldata;
            bodydata += zlend;
            bodydata += clhead;
            bodydata += cldata;
            bodydata += clend;
            bodydata += "</details>";
            bodydata += "</body>";


            string data = headdata;
            data += bodydata;
            data += enddata;
            string[] args = new string[1];
            args[0] = data;
            string nhdata;

            try
            {
                nhdata = (string)BllHdsbhnh.InvokeWebService(weburl, "nh_pipe", args).ToString();//调用webservice是需要创建实例
            }
            catch (Exception e)
            {
                mesg += "网络不通！" + e.ToString();

                return -1;
            }
            //写日志
            SysWriteLogs sysWriteLog = new SysWriteLogs();
            //解析返回的xml
            System.IO.StringReader sr = new System.IO.StringReader(nhdata);
            DataSet dsXml = new DataSet();
            dsXml.ReadXml(sr);
            if (dsXml.Tables["head"].Rows[0]["stateCode"].ToString() != "0000000")//stateCode 参数返回“0000000”是成功其他失败，其他参数参照文件夹下的文档
            {
                mesg += "业务调用失败[..失败码:" + nhdata + "..]";
                string outLog = "住院号：" + ihspcode + "业务调用失败[..失败码:" + nhdata + "..]";
                sysWriteLog.writeLogs("Errs", DateTime.Now, outLog);
                return -1;
            }
            else
            {
                aaa = aaa.Remove(aaa.Length - 1);
                string sql_sfsc = "update ihsp_costdet set insursync='Y' where id in(" + aaa +")";
                BllMain.Db.Update(sql_sfsc);
            }
            return retnum;

        }
         //拼接接口输入字符串，并调用接口函数得到返回数据
        public BhnhReturn membersQueryFunction(string weburl, string targetOrg, string identity, string password, string ihsp_id,string patienttypeid)
        {
            string mesg = "";
            BhnhReturn ret = new BhnhReturn();
            ret.Ret_flag = true;
            int retnum = 1;
            while (retnum > 0)
            {
                retnum = zhuYuanDanTiaoJiZhang_data(weburl, targetOrg, identity, password, ihsp_id, patienttypeid, out mesg);

                if (retnum == -1)
                {
                    ret.Ret_mesg = mesg;
                    ret.Ret_flag = false;
                    return ret;

                }
            }
            return ret;
        }
    }
}
