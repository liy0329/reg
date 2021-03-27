using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MTHIS.main.bll;
using MTHIS.common;
using MTREG.common;
using MTREG.medinsur.hdsbhnh.bo;
using MTREG.ihsp.bll;

namespace MTREG.medinsur.hdsbhnh.bll
{
    class BllSnhMethod
    {
        /// <summary>
        /// 选择区域
        /// </summary>
        /// <returns></returns>
        public DataTable area()
        {
            DataTable dt = new DataTable();
            string sql="select * from insur_hdsbhnh_trustpointcode;";
            try
            {
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }

        /// <summary>
        /// 根据id获取地址
        /// </summary>
        /// <returns></returns>
        public DataTable getWebUrl(string id)
        {
            DataTable dt = new DataTable();
            string sql = "select weburl,trustpointcode,uniquekey,password from insur_hdsbhnh_trustpointcode where id=" + DataTool.addIntBraces(id);
            try
            {
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }

        public DataTable getdict(string insurcode)
        {
            DataTable dt = new DataTable();
            string sql = "select sn,name from insur_hdsbh_sysdict where insurcode=" + DataTool.addFieldBraces(insurcode);
            try
            {
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }

        /// <summary>
        /// 插入市北航登记信息表
        /// </summary>
        /// <param name="inhospital"></param>
        /// <returns></returns>
        public int registInfo(string reginfo, string ihsp_id)
        {
            string opstat = "OO";//医保信息OO
            string id = BillSysBase.nextId("ihsp_insurinfo");
            string sql = "insert into ihsp_insurinfo (id,ihsp_id"
                + ",registinfo"
                + ",opstat)values(" + DataTool.addFieldBraces(id)
                                     + "," + DataTool.addFieldBraces(ihsp_id)
                                     + "," + DataTool.addFieldBraces(reginfo)
                                     + "," + DataTool.addFieldBraces(opstat)
                                     + ")";
            return BllMain.Db.Update(sql);
        }

        /// <summary>
        /// 保存邯郸市北航农合登记信息
        /// </summary>
        /// <param name="hdsbhInfo"></param>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public int saveRegInfo(HdsbhRegInfo hdsbhRegInfo, string ihsp_id)
        {
            //住院流水号|个人编号|登记属性|就医机构代码|转外类型|webservice地址|医疗单位身份|目标机构代码|密码|经办人
            string strXml = "<info>";
            strXml += "<inpatientSn>" + hdsbhRegInfo.InpatientSn + "</inpatientSn>";//住院流水号
            strXml += "<personNum>" + hdsbhRegInfo.PersonNum + "</personNum>";//个人编号
            strXml += "<djsx>" + hdsbhRegInfo.Djsx + "</djsx>";//登记属性
            strXml += "<hspcode>" + hdsbhRegInfo.Hspcode + "</hspcode>";//就医机构代码
            strXml += "<zwlx>" + hdsbhRegInfo.Zwlx + "</zwlx>";//转外类型
            strXml += "<weburl>" + hdsbhRegInfo.Weburl + "</weburl>";//webservice地址
            strXml += "<trustpointcode>" + hdsbhRegInfo.Trustpointcode + "</trustpointcode>";//医疗单位身份
            strXml += "<targetOrg>" + hdsbhRegInfo.TargetOrg + "</targetOrg>";//目标机构代码
            strXml += "<password>" + hdsbhRegInfo.Password + "</password>";//密码
            strXml += "<doctor>" + hdsbhRegInfo.Doctor + "</doctor>";//经办人
            strXml += "</info>";
            int flag = registInfo(strXml, ihsp_id);
            if (flag < 0)
            {
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 保存结算信息
        /// </summary>
        /// <param name="hdsbhSettInfo"></param>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public int saveSettInfo(string hdsbhSettInfo, string ihsp_id)
        {
            string[] message = hdsbhSettInfo.Split('|');
            string strXml = "<info>";
            strXml += "<D506_03>" + message[0] + "</D506_03>";//住院总费用
            strXml += "<D506_19>" + message[1] + "</D506_19>";//住院可报总费用
            strXml += "<D506_32>" + message[2] + "</D506_24>";//实际补偿金额
            strXml += "<D506_32>" + message[2] + "</D506_32>";//农村居民自费金额
            strXml += "<D506_57>" + message[3] + "</D506_57>";//家庭账户冲抵金额
            strXml += "<D506_58>" + message[4] + "</D506_58>";//特殊重大疾病补偿金额
            strXml += "<D506_59>" + message[5] + "</D506_59>";//第三方补充医疗保险补偿金额
            strXml += "<D506_60>" + message[6] + "</D506_60>";//第三方大额救助补偿金额
            strXml += "<D506_103>" + message[7] + "</D506_103>";//民政救助补偿额
            strXml += "<D506_104>" + message[8] + "</D506_104>";//二次补偿金额
            strXml += "<D506_105>" + message[9] + "</D506_105>";//医疗机构负担金额
            strXml += "</info>";
            return accountInfo(strXml, ihsp_id);
        }
        /// <summary>
        /// 读取邯郸市北航农合登记信息
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public HdsbhRegInfo readRegInfo(string ihsp_id)
        {
            HdsbhRegInfo hdsbhRegInfo = new HdsbhRegInfo();
            DataTable dt = hdsbhinfo(ihsp_id);
            string reginfo = dt.Rows[0]["registinfo"].ToString();
            System.IO.StringReader sr = new System.IO.StringReader(reginfo);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            hdsbhRegInfo.InpatientSn = ds.Tables["info"].Rows[0]["inpatientSn"].ToString();
            hdsbhRegInfo.PersonNum = ds.Tables["info"].Rows[0]["personNum"].ToString();
            hdsbhRegInfo.Djsx = ds.Tables["info"].Rows[0]["djsx"].ToString();
            hdsbhRegInfo.Hspcode = ds.Tables["info"].Rows[0]["hspcode"].ToString();
            hdsbhRegInfo.Zwlx = ds.Tables["info"].Rows[0]["zwlx"].ToString();
            hdsbhRegInfo.Weburl = ds.Tables["info"].Rows[0]["weburl"].ToString();
            hdsbhRegInfo.Trustpointcode = ds.Tables["info"].Rows[0]["trustpointcode"].ToString();
            hdsbhRegInfo.TargetOrg = ds.Tables["info"].Rows[0]["targetOrg"].ToString();
            hdsbhRegInfo.Password = ds.Tables["info"].Rows[0]["password"].ToString();
            hdsbhRegInfo.Doctor = ds.Tables["info"].Rows[0]["doctor"].ToString();
            return hdsbhRegInfo;
        }
        /// <summary>
        /// 查询市北航信息
        /// </summary>
        /// <param name="pincode"></param>
        /// <returns></returns>
        public DataTable hdsbhinfo(string ihsp_id)
        {
            DataTable dt = new DataTable();
            string sql = "select registinfo,settinfo from ihsp_insurinfo where ihsp_id=" + DataTool.addFieldBraces(ihsp_id);
            try
            {
                dt = BllMain.Db.Select(sql).Tables[0];
            }
            catch (Exception e)
            {

            }
            return dt;
        }

        /// <summary>
        /// 插入/更改邯郸市北航结账信息表
        /// </summary>
        /// <param name="inhospital"></param>
        /// <returns></returns>
        public int accountInfo(string accountinfo, string ihsp_id)
        {
            string sql = "update ihsp_insurinfo set settinfo=" + DataTool.addFieldBraces(accountinfo)
                                    + " where ihsp_id=" + DataTool.addFieldBraces(ihsp_id);
            return BllMain.Db.Update(sql);
        }

        /// <summary>
        /// 修改市北航信息状态
        /// </summary>
        /// <param name="opstat"></param>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public int upopstat(string opstat, string ihsp_id)
        {
            string sql = "update ihsp_insurinfo set opstat=" + DataTool.addFieldBraces(opstat)
                                    + " where ihsp_id=" + DataTool.addFieldBraces(ihsp_id);
            return BllMain.Db.Update(sql);
        }

        /// <summary>
        /// 市北航农合住院登记删除
        /// </summary>
        /// <returns></returns>
        public int retihsp(string ihspid,StringBuilder returnMsg )
        {
            BillIhspcost billIhspcost = new BillIhspcost();
            DataTable dt = billIhspcost.ihspIdSearch(ihspid);
            string ihspcode = dt.Rows[0]["ihspcode"].ToString();
            //住院流水号|个人编号|登记属性|就医机构代码|转外类型|webservice地址|医疗单位身份|目标机构代码|密码
            HdsbhRegInfo hdsbhRegInfo = readRegInfo(ihspid);

            string[] param = new string[3];
            param[0] = hdsbhRegInfo.InpatientSn;
            param[1] = hdsbhRegInfo.PersonNum;
            param[2] = ihspcode;

            ZydjscXml zydjscXml = new ZydjscXml();
            BhnhReturn retdata = zydjscXml.membersQueryFunction(hdsbhRegInfo.Weburl, hdsbhRegInfo.TargetOrg, hdsbhRegInfo.Trustpointcode, hdsbhRegInfo.Password, param);
            if (!retdata.Ret_flag)
            {
                returnMsg.Append(retdata.Ret_mesg);
                return -1;
            }
            //解析返回的xml
            System.IO.StringReader sr = new System.IO.StringReader(retdata.Ret_data);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables["head"].Rows[0]["stateCode"].ToString() != "0000000")//stateCode 参数返回“0000000”是成功其他失败，其他参数参照文件夹下的文档
            {
                returnMsg.Append(retdata.Ret_mesg);
                return -1;
            }
            upopstat(Insurinfostate.XX.ToString(), ihspid);
            return 0;
        }

        /// <summary>
        /// 出院登记
        /// </summary>
        /// <returns></returns>
        public int ohspReg(string ihspid, StringBuilder returnMsg)
        {
            BillIhspcost billIhspcost = new BillIhspcost();
            BillIhspMan billIhspMan=new BillIhspMan();
            DataTable dt = billIhspcost.ihspIdSearch(ihspid);
            string ihspcode = dt.Rows[0]["ihspcode"].ToString();
            DataTable dataTable = hdsbhinfo(ihspid);
            //住院流水号|个人编号|登记属性|就医机构代码|转外类型|webservice地址|医疗单位身份|目标机构代码|密码
            HdsbhRegInfo hdsbhRegInfo = readRegInfo(ihspid);
            string[] param = new string[2];
            param[1] = ihspcode;
            param[0] = hdsbhRegInfo.PersonNum;
            CydjXml cydjXml = new CydjXml();
            BhnhReturn retdata = cydjXml.membersQueryFunction(hdsbhRegInfo.Weburl, hdsbhRegInfo.TargetOrg, hdsbhRegInfo.Trustpointcode, hdsbhRegInfo.Password, param);
            if (!retdata.Ret_flag)
            {
                returnMsg.Append(retdata.Ret_mesg);
                return -1;
            }
            //解析返回的xml
            System.IO.StringReader sr = new System.IO.StringReader(retdata.Ret_data);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables["head"].Rows[0]["stateCode"].ToString() != "0000000")//stateCode 参数返回“0000000”是成功其他失败，其他参数参照文件夹下的文档
            {
                returnMsg.Append(retdata.Ret_mesg);
                return -1;
            }
            returnMsg.Append("成功说明：" + ds.Tables["head"].Rows[0]["describe"].ToString());
            int flag = billIhspMan.upinsurstat(ihspcode, Insurstat.SIGN.ToString());
            if (flag < 0)
            {
                returnMsg.Append("更新住院医保接口状态失败!");
                return -1;
            }
            return 0;
        }

        //邯郸市北航结算
        public int ihspAccount(string ihspid,string invoice,string datatime,StringBuilder rtmessage)
        {
            BillIhspcost billIhspcost = new BillIhspcost();
            BillIhspMan billIhspMan = new BillIhspMan();
            DataTable dt = billIhspcost.ihspIdSearch(ihspid);
            string ihspcode = dt.Rows[0]["ihspcode"].ToString();
            string outdate = dt.Rows[0]["outdate"].ToString();
            string name = dt.Rows[0]["ihspname"].ToString();
            //住院流水号|个人编号|登记属性|就医机构代码|转外类型|webservice地址|医疗单位身份|目标机构代码|密码
            HdsbhRegInfo hdsbhRegInfo = readRegInfo(ihspid);
            string[] param = new string[15];
            param[0] = ihspcode;//住院号
            param[1] = hdsbhRegInfo.PersonNum;//个人编码
            param[3] = DateTime.Parse(datatime).ToString("yyyy-MM-ddTHH-mm-ss");//发票时间必填    yyyy-mm-ddT24-mi-ss，强制要求位数，需补齐
            param[8] = DateTime.Parse(outdate).ToString("yyyy-MM-ddTHH-mm-ss");//出院时间必填    yyyy-mm-ddT24-mi-ss，强制要求位数，需补齐
            param[12] = name;//出院诊断);
            ZyjsXml zyjsXml = new ZyjsXml();
            BhnhReturn retdata = zyjsXml.membersQueryFunction(hdsbhRegInfo.Weburl, hdsbhRegInfo.TargetOrg, hdsbhRegInfo.Trustpointcode, hdsbhRegInfo.Password, param);
            if (!retdata.Ret_flag)
            {
                rtmessage.Append(retdata.Ret_mesg);
                return -1;
            }
            //解析返回的xml
            System.IO.StringReader sr = new System.IO.StringReader(retdata.Ret_data);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables["head"].Rows[0]["stateCode"].ToString() != "0000000")//stateCode 参数返回“0000000”是成功其他失败，其他参数参照文件夹下的文档
            {
                rtmessage.Append("业务调用失败[..失败码:" + retdata.Ret_data + "..]");
                return -1;
            }
            string D506_03 = ds.Tables["feeInfo"].Rows[0]["D506_03"].ToString();//住院总费用
            string D506_19 = ds.Tables["feeInfo"].Rows[0]["D506_19"].ToString();//住院可报总费用
            string D506_24 = ds.Tables["feeInfo"].Rows[0]["D506_24"].ToString();//实际补偿金额
            string D506_32 = ds.Tables["feeInfo"].Rows[0]["D506_32"].ToString();//农村居民自费金额
            string D506_57 = ds.Tables["feeInfo"].Rows[0]["D506_57"].ToString();//家庭账户冲抵金额
            string D506_58 = ds.Tables["feeInfo"].Rows[0]["D506_58"].ToString();//特殊重大疾病补偿金额
            string D506_59 = ds.Tables["feeInfo"].Rows[0]["D506_59"].ToString();//第三方补充医疗保险补偿金额
            string D506_60 = ds.Tables["feeInfo"].Rows[0]["D506_60"].ToString();//第三方大额救助补偿金额
            string D506_103 = ds.Tables["feeInfo"].Rows[0]["D506_103"].ToString();//民政救助补偿额
            string D506_104 = ds.Tables["allFeeSubentry"].Rows[0]["D506_104"].ToString();//二次补偿金额
            string D506_105 = ds.Tables["allFeeSubentry"].Rows[0]["D506_105"].ToString();//医疗机构负担金额
            string settinfo = D506_03 + "|" + D506_19 + "|" + D506_24 + "|" + D506_32+"|"+"|"+D506_57+"|"+D506_58+"|"+D506_59+"|"+D506_60+"|"+D506_103+"|"+D506_104+"|"+D506_105;//结算返回信息
            saveSettInfo(settinfo, ihspid);//添加结算信息
            int flag = billIhspMan.upinsurstat(ihspcode, Insurstat.SETT.ToString());
            if (flag < 0)
            {
                rtmessage.Append("修改医保接口状态失败!");
                return -1; 
            }
            return 0;
        }
        /// <summary>
        /// 退结算
        /// </summary>
        /// <param name="ihspid"></param>
        /// <returns></returns>
        public int retAccount( string ihspid, StringBuilder rtMessage)
        {
            BillCmbList billCmbList = new BillCmbList();
            //住院流水号|个人编号|登记属性|就医机构代码|转外类型|webservice地址|医疗单位身份|目标机构代码|密码|经办人
            HdsbhRegInfo hdsbhRegInfo = readRegInfo(ihspid);
            string[] param = new string[4];
            param[0] = hdsbhRegInfo.InpatientSn;
            param[1] = hdsbhRegInfo.PersonNum;
            param[2] = billCmbList.getDoctorName(ProgramGlobal.User_id);
            TpXml tpXml = new TpXml();
            BhnhReturn retdata = tpXml.membersQueryFunction(hdsbhRegInfo.Weburl, hdsbhRegInfo.TargetOrg, hdsbhRegInfo.Trustpointcode, hdsbhRegInfo.Password, param);
            if (!retdata.Ret_flag)
            {
                rtMessage.Append("失败信息 ：" + retdata.Ret_mesg+"提示信息");
                return -1;

            }
            //解析返回的xml
            System.IO.StringReader sr = new System.IO.StringReader(retdata.Ret_data);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            if (ds.Tables["head"].Rows[0]["stateCode"].ToString() != "0000000")//stateCode 参数返回“0000000”是成功其他失败，其他参数参照文件夹下的文档
            {
                rtMessage.Append("业务调用失败[..失败码:" + retdata.Ret_data + "..]");
                return -1;
            }
            string nh_tph = ds.Tables["body"].Rows[0]["D506_107"].ToString();//退票号
            return 0;
        }

    }
}
