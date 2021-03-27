using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MTHIS.common;
using MTREG.common;
using System.Data;
using MTHIS.main.bll;
using System.Net;
using MTREG.ihsp.bll;
using System.IO;
using System.Windows.Forms;
using MTREG.medinsur.gzsnh.bo;
using MTREG.ihsp.bo;

namespace MTREG.medinsur.gzsnh.bll
{
    class BllGzsnhMethod
    {
        /// <summary>
        /// 获取农合挂号信息
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public DataTable gzsnhIhspInfo(string ihsp_id)
        {
            string sql = "SELECT inpatientsn,membersysno,familysysno,bookno,centerno from insur_gzsnhryinfo WHERE mtzyjliid = " + DataTool.addFieldBraces(ihsp_id);
                   
            return BllMain.Db.Select(sql).Tables[0];
        }
        /// <summary>
        /// 查询贵州省农合信息
        /// </summary>
        /// <param name="pincode"></param>
        /// <returns></returns>
        public DataTable gzsnhInfo(string ihsp_id)
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
        /// 插入贵州省农合登记信息表
        /// </summary>
        /// <param name="inhospital"></param>
        /// <returns></returns>
        public int registInfo(string reginfo, string ihsp_id,string sql)
        {
            string opstat = "OO";//医保信息OO
            string id = BillSysBase.nextId("ihsp_insurinfo");
            sql += "insert into ihsp_insurinfo (id,ihsp_id"
                + ",registinfo"
                + ",opstat)values(" + DataTool.addFieldBraces(id)
                                     + "," + DataTool.addFieldBraces(ihsp_id)
                                     + "," + DataTool.addFieldBraces(reginfo)
                                     + "," + DataTool.addFieldBraces(opstat)
                                     + ");";            
            return BllMain.Db.Update(sql);
        }

        /// <summary>
        /// 修改贵州省农合结算信息
        /// </summary>
        /// <param name="inhospital"></param>
        /// <returns></returns>
        public int settInfo(string settinfo, string ihsp_id)
        {
            string sql = "update ihsp_insurinfo set settinfo=" + DataTool.addFieldBraces(settinfo)
                                     + " where ihsp_id=" + DataTool.addFieldBraces(ihsp_id);
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 手术编码
        /// </summary>
        /// <returns></returns>
        public DataTable getOpsInfo()
        {
            string sql = "select insurcode as insureid,name from cost_insuritem where name like '%术%' and insuritemtype='1'";
            return BllMain.Db.Select(sql).Tables[0];
        }
        /// <summary>
        /// 手术编码
        /// </summary>
        /// <returns></returns>
        public DataTable getOpsInfo(string parm)
        {
            string sql = "select insurcode as insureid,name2 from cost_insuritem where name2 like '%术%' and insuritemtype='1' "
                         +" and name like '%"+parm+"%'"
                         +" and pincode like '%"+parm+"%'";
            return BllMain.Db.Select(sql).Tables[0];
        }
        /// <summary>
        /// 农合疾病
        /// </summary>
        /// <param name="pincode"></param>
        /// <returns></returns>
        public DataTable getICDInfo(string pincode)
        {
            string sql = "select name,illcode from cost_insurillness "
                        + " where pincode like " + DataTool.addFieldBraces("%" + pincode + "%")
                        + " and cost_insurtype_id=("
                        + "select id from cost_insurtype where keyname=" + DataTool.addFieldBraces(CostInsurtypeKeyname.GZSNH.ToString()) + ")";
            return BllMain.Db.Select(sql).Tables[0];
        }
        /// <summary>
        /// 编号简码获取农合中心编码和医疗机构信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public DataTable getAreaInfo(string info)
        {
            string sql = "select areacode"
                            +",insuritemtype"
                            + ",name"
                            + ",allname"
                            + ",hospitalcode"
                            + ",weburl "
                            + ",username "
                            + ",password "
                            + " from insur_areacode"
                            + " where areacode like " + DataTool.addFieldBraces("%" + info + "%")
                            + " and cost_insurtype_id=("
                            + "select id from cost_insurtype where keyname=" + DataTool.addFieldBraces(CostInsurtypeKeyname.GZSNH.ToString()) + ")";
            return BllMain.Db.Select(sql).Tables[0];
        }

        /// <summary>
        /// 根据areacode判断是否属于贵阳市
        /// </summary>
        /// <param name="areacode"></param>
        /// <returns></returns>
        public bool isInGysnh(string areacode)
        {
            string sql = "select * from insur_gzsnhgyscode "
                + " where areacode='" + areacode + "'";
            DataSet ds = BllMain.Db.Select(sql);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 获取医保目录类型码
        /// </summary>
        /// <param name="areacode"></param>
        /// <returns></returns>
        public string getInsurItemtype(string areacode)
        {
            string sql = "select insuritemtype"
                            + " from insur_areacode"
                            + " where areacode = " + DataTool.addFieldBraces(areacode)
                            + " and cost_insurtype_id=("
                            + "select id from cost_insurtype where keyname=" + DataTool.addFieldBraces(CostInsurtypeKeyname.GZSNH.ToString()) + ")";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["insuritemtype"].ToString();
            }
            return "0";
        }

        /// <summary>
        /// 插入医保目录类型码
        /// </summary>
        /// <returns></returns>
        public int upIhsp(string ihsp_id, string insuritemtype)
        {
            string sql = "update inhospital set insuritemtype=" + DataTool.addFieldBraces(insuritemtype)
                            + " where id=" + DataTool.addIntBraces(ihsp_id);
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 获取医保编号
        /// </summary>
        /// <param name="insurid"></param>
        /// <returns></returns>
        public string getInsurid(string keyname)
        {
            string sql = "select id from cost_insurtype where keyname=" + DataTool.addFieldBraces(keyname);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["id"].ToString();
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 插入疾病信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="illcode"></param>
        /// <param name="createdat"></param>
        /// <returns></returns>
        public string insurillness(string name, string illcode, string pincode, string createdat)
        {
            string insurtype_id = getInsurid(CostInsurtypeKeyname.GZSNH.ToString());
            string sql = "insert into cost_insurillness(id,cost_insurtype_id,name,pincode,illcode,createdat,createdby)"
                                + "values(" + DataTool.addIntBraces(BillSysBase.nextId("cost_insurillness"))
                                + "," + DataTool.addFieldBraces(insurtype_id)
                                + "," + DataTool.addFieldBraces(name)
                                + "," + DataTool.addFieldBraces(pincode)
                                + "," + DataTool.addFieldBraces(illcode)
                                + "," + DataTool.addFieldBraces(createdat)
                                + "," + DataTool.addFieldBraces(ProgramGlobal.User_id)
                                + ");";
            return sql;
        }
        /// <summary>
        /// 插入治疗方式
        /// </summary>
        /// <param name="name"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public string toNhzlfs(string name, string code)
        {
            string sql = "insert into insur_gzsnhzlsf(id,code,name)"
                                + "values(" + DataTool.addIntBraces(BillSysBase.nextId("insur_gzsnh_treat"))
                                + "," + DataTool.addFieldBraces(code)
                                + "," + DataTool.addFieldBraces(name)
                                + ");";
            return sql;
        }

        /// <summary>
        /// 获取治疗类别
        /// </summary>
        /// <returns></returns>
        public DataTable getNhzlfsbm()
        {
            string sql = "select code,name from insur_gzsnhzlfs;";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        public DataTable getNhzlfsbm(string param)//治疗方式
        {
            string sql = "select code,name from insur_gzsnhzlfs where name like '%" + param + "%'";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        public DataTable getNhksxxbm()//农合科室
        {
            string sql = "select code,name from insur_gzsnhksxx";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        public DataTable getNhksxxbm(string param)//农合科室
        {
            string sql = "select code,name from insur_gzsnhksxx where name like '%" + param + "%'";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        public DataTable getnhjbxxbm()//农合疾病
        {
            string sql = "select icdallno,icdname from insur_gzsnhjbxx";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        public DataTable getnhjbxxbm(string param)//农合疾病
        {
            string sql = "select icdallno,icdname from insur_gzsnhjbxx where (inputcodepy like '%" + param + "%' or inputcodewb like '%" + param + "%' or icdname like '%" + param + "%')";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 更新住院医保状态
        /// </summary>
        /// <param name="ihspcode">住院号</param>
        /// <returns></returns>
        public int upinsurstat(string ihsp_id, string insurstat)
        {
            string sql = "update inhospital set insurstat=" + DataTool.addFieldBraces(insurstat) + " where id=" + DataTool.addFieldBraces(ihsp_id);
            return BllMain.Db.Update(sql);
        }

        /// <summary>
        /// 取消入院登记
        /// </summary>
        /// <param name="ihsp_id"></param>
        public bool cancelIhspReg(string ihsp_id, StringBuilder smessage)
        {
            WebClient webClient = new WebClient();
            //网络地址|农合中心编码|医疗机构编码|用户名|密码|农合住院流水号|个人编号|家庭编码|医疗证卡号 
            GzsnhRegInfo gzsnhRegInfo = new GzsnhRegInfo();
            gzsnhRegInfo = readRegInfo(ihsp_id);
            string url = GzsnhGlobal.Url + "cancelInpatientRegister?userName=" + Base64.encodebase64(GzsnhGlobal.UserName) + "&userPwd=" + Base64.encodebase64(GzsnhGlobal.UserPwd) + "&centerNo=" + Base64.encodebase64(gzsnhRegInfo.Centerno) + "&hospCode=" + Base64.encodebase64(GzsnhGlobal.HospCode) + "&inpatientSn=" + Base64.encodebase64(gzsnhRegInfo.Inpatientsn) + "&cancelCause=" + Base64.encodebase64("退入院");
            try
            {
                string param = Base64.decodebase64(webClient.DownloadString(url).Split(':')[1].Replace("\"", "").Replace("}", ""));
                if (Base64.decodebase64(param.Split(',')[0]) == "1")
                {
                    int flag = cancleHisNhryinfo(ihsp_id);
                    if (flag < 0)
                    {
                        smessage.Append("入院取消成功,医保状态修改失败!");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            smessage.Append("入院取消成功");
            return true;
        }

        /// <summary>
        /// 取消结算
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <param name="smessage"></param>
        /// <returns></returns>
        public int cancelInpatientRedeem(string ihsp_id, StringBuilder smessage)
        {
            WebClient webClient = new WebClient();
            //网络地址|农合中心编码|医疗机构编码|用户名|密码|农合住院流水号|个人编号|家庭编码|医疗证卡号 
            GzsnhRegInfo gzsnhRegInfo = new GzsnhRegInfo();
            gzsnhRegInfo = readRegInfo(ihsp_id);
            string url = GzsnhGlobal.Url + "cancelInpatientRedeem?userName=" + Base64.encodebase64(GzsnhGlobal.UserName) + "&userPwd=" + Base64.encodebase64(GzsnhGlobal.UserPwd) + "&centerNo=" + Base64.encodebase64(GzsnhGlobal.CenterNo) + "&hospCode=" + Base64.encodebase64(GzsnhGlobal.HospCode) + "&inpatientSn=" + Base64.encodebase64(gzsnhRegInfo.Inpatientsn) + "";
            try
            {
                string param = Base64.decodebase64(webClient.DownloadString(url).Split(':')[1].Replace("\"", "").Replace("}", ""));
            }
            catch (Exception ex)
            {
                smessage.Append(Base64.decodebase64(Base64.GetPageCodeBy500Error(url, "utf-8").Split(':')[1].Replace("\"", "").Replace("}", "")));
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 获取his费用
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public string getCostFee(string ihsp_id)
        {
            string sql = "select sum(realfee) from ihsp_costdet where ihsp_id=" + DataTool.addIntBraces(ihsp_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["feeamt"].ToString();
            }
            return "0";
        }

        /// <summary>
        /// 获取费用明细id
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public DataTable getCostdetId(string ihsp_id)
        {
            string sql = "select id from ihsp_costdet where ihsp_id=" + DataTool.addIntBraces(ihsp_id) + ";";
            return BllMain.Db.Select(sql).Tables[0];
        }
        

        /// <summary>
        /// 修改医保传输状态
        /// </summary>
        /// <param name="costid"></param>
        /// <returns></returns>
        public int upcostState(string costid, string state)
        {
            string sql = "update ihsp_costdet set insursync=" + DataTool.addFieldBraces(state) + " where id=" + DataTool.addIntBraces(costid) + ";";
            return BllMain.Db.Update(sql);
        }


        /// <summary>
        /// 添加贵州新农合费用传输明细
        /// </summary>
        /// <returns></returns>
        public string inInsurCostdet(string costid, string detailno, string enableratio, string enablemoney)
        {
            string sql = "insert into insur_gzsnh_costdet(id"
                            + ",ihsp_costdet_id"
                            + ",detailno"
                            + ",enableratio"
                            + ",enablemoney)values(" + BillSysBase.nextId("")
                            + "," + DataTool.addFieldBraces(costid)
                            + "," + DataTool.addFieldBraces(detailno)
                            + "," + DataTool.addFieldBraces(enableratio)
                            + "," + DataTool.addFieldBraces(enablemoney)
                            + ");";
            return sql;

        }
        /// <summary>
        /// 删除贵州新农合费用传输明细
        /// </summary>
        /// <returns></returns>
        public string detInsurCostdet(string costid)
        {
            string sql = "delete from insur_gzsnh_costdet where ihsp_costdet_id=" + DataTool.addIntBraces(costid) + ";";
            return sql;
        }


        
        /// <summary>
        /// 贵州省新农合费用录入
        /// </summary>
        /// <returns></returns>
        public void costTransfer(string ihsp_id)
        {
            //获取姓名和医保目录类型码
            string sql = "select name,insuritemtype from inhospital where id=" + DataTool.addIntBraces(ihsp_id);
            DataTable dtIhsp = BllMain.Db.Select(sql).Tables[0];
            string name = dtIhsp.Rows[0]["name"].ToString();
            string insuritemtype = dtIhsp.Rows[0]["insuritemtype"].ToString(); ;//是否为贵阳市
            sql = "select bas_doctor.name as docname"
                            + ", ihsp_costdet.id"
                            + ", ihsp_costdet.chargedate"
                            + ", ihsp_costdet.spec"
                            + ", ihsp_costdet.unit"
                            + ", ihsp_costdet.prc"
                            + ", ihsp_costdet.fee"
                            + ", ihsp_costdet.num"
                            + ", sys_dict.name as dosageform"
                            + ", cost_insuritem.name as hisname"
                            + ", cost_insuritem.standcode"
                            + ", cost_insuritem.name2 as nh_name"
                            + ", cost_insuritem.insurcode as nh_code"
                            + " from ihsp_costdet"
                            + " left join bas_doctor on bas_doctor.id=ihsp_costdet.diagndoctor_id"
                            + " left join cost_insurcross on cost_insurcross.item_id=ihsp_costdet.item_id"
                            + " left join cost_insuritem on cost_insurcross.cost_insuritem_id=cost_insuritem.id"
                            + " left join bas_item on bas_item.id=ihsp_costdet.item_id"
                            + " left join sys_dict on bas_item.dosageform_id=sys_dict.sn and sys_dict.dicttype='drug_dosageform' and father<>0"
                            + " where ihsp_costdet.ihsp_id=" + DataTool.addIntBraces(ihsp_id)
                            + " and cost_insuritem.insuritemtype=" + DataTool.addFieldBraces(insuritemtype)
                            + " and cost_insuritem.cost_insurtype_id=(select id from cost_insurtype where keyname=" + DataTool.addFieldBraces(CostInsurtypeKeyname.GZSNH.ToString()) + ")"
                            + " and ihsp_costdet.insursync='N' ";
            DataTable det = BllMain.Db.Select(sql).Tables[0];
            //网络地址|农合中心编码|医疗机构编码|用户名|密码|农合住院流水号|个人编号|家庭编码|医疗证卡号 
            GzsnhRegInfo gzsnhRegInfo = new GzsnhRegInfo();
            gzsnhRegInfo = readRegInfo(ihsp_id);
            string paramc = "";
            for (int j = 0; j < det.Rows.Count; j++)
            {
                if (j != 0)
                    paramc += ",";

                paramc += "{\"hisDetailCode\":\"" + Base64.encodebase64(det.Rows[j]["id"].ToString()) + "\",\"hisMedicineCode\":\"" + Base64.encodebase64(det.Rows[j]["standcode"].ToString()) + "\",\"medicineCode\":\"" + Base64.encodebase64(det.Rows[j]["nh_code"].ToString()) + "\",\"medicineName\":\"" + Base64.encodebase64(det.Rows[j]["hisname"].ToString()) + "\",\"spec\":\"" + Base64.encodebase64(det.Rows[j]["spec"].ToString()) + "\",\"conf\":\"" + Base64.encodebase64(det.Rows[j]["dosageform"].ToString()) + "\",\"unit\":\"" + Base64.encodebase64(det.Rows[j]["unit"].ToString()) + "\",\"price\":\"" + Base64.encodebase64(det.Rows[j]["prc"].ToString()) + "\",\"quantity\":\"" + Base64.encodebase64(det.Rows[j]["num"].ToString()) + "\",\"useDate\":\"" + Base64.encodebase64(det.Rows[j]["chargedate"].ToString()) + "\"}";
                if (j % 100 == 0 && j != 0)
                {
                    string param = "{\"userName\":\"" + Base64.encodebase64(GzsnhGlobal.UserName) + "\",\"userPwd\":\"" + Base64.encodebase64(GzsnhGlobal.UserPwd) + "\",\"centerNo\":\"" + Base64.encodebase64(GzsnhGlobal.CenterNo) + "\",\"doctor\":\"" + Base64.encodebase64(det.Rows[j]["docname"].ToString()) + "\",\"hospCode\":\"" + Base64.encodebase64(GzsnhGlobal.HospCode) + "\",\"bookNo\":\"" + Base64.encodebase64(gzsnhRegInfo.BookNo) + "\",\"name\":\"" + Base64.encodebase64(name) + "\",\"familyNo\":\"" + Base64.encodebase64(gzsnhRegInfo.Familysysno) + "\",\"memberNo\":\"" + Base64.encodebase64(gzsnhRegInfo.Membersysno) + "\",\"inpatientSn\":\"" + Base64.encodebase64(gzsnhRegInfo.Inpatientsn) + "\",\"rows\":\"" + Base64.encodebase64("100") + "\",\"InpatientDetailList\":[";
                    int a = fytran(param + paramc + "]}", GzsnhGlobal.Url);
                    if (a == -1)
                    {
                        if (MessageBox.Show("费用传送出错是否继续", "提示信息", MessageBoxButtons.YesNo) == DialogResult.No)
                            break;
                    }
                }
                else if (j == det.Rows.Count - 1)
                {
                    string param = "{\"userName\":\"" + Base64.encodebase64(GzsnhGlobal.UserName) + "\",\"userPwd\":\"" + Base64.encodebase64(GzsnhGlobal.UserPwd) + "\",\"centerNo\":\"" + Base64.encodebase64(GzsnhGlobal.CenterNo) + "\",\"doctor\":\"\",\"hospCode\":\"" + Base64.encodebase64(GzsnhGlobal.HospCode) + "\",\"bookNo\":\"" + Base64.encodebase64(gzsnhRegInfo.BookNo) + "\",\"name\":\"" + Base64.encodebase64(name) + "\",\"familyNo\":\"" + Base64.encodebase64(gzsnhRegInfo.Familysysno) + "\",\"memberNo\":\"" + Base64.encodebase64(gzsnhRegInfo.Membersysno) + "\",\"inpatientSn\":\"" + Base64.encodebase64(gzsnhRegInfo.Inpatientsn) + "\",\"rows\":\"" + Base64.encodebase64((det.Rows.Count % 100).ToString()) + "\",\"InpatientDetailList\":[";
                    int a = fytran(param + paramc + "]}", GzsnhGlobal.Url);
                    if (a == -1)
                    {
                        if (MessageBox.Show("费用传送出错是否继续", "提示信息", MessageBoxButtons.YesNo) == DialogResult.No)
                            break;
                    }
                }
            }
            MessageBox.Show("操作成功");
        }
        /// <summary>
        /// 费用录入
        /// </summary>
        /// <param name="param"></param>
        /// <param name="url"></param>
        /// <param name="smessage"></param>
        /// <returns></returns>
        public int fytran(string param, string url)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            Dictionary<string, string> ResultList = new Dictionary<string, string>();
            string message = posturl(url + "uploadInpatientDetails", param);
            try
            {
                string[] info = message.Replace("\"", "").Replace(",InpatientDetailResultList:", "@").Split('@');
                string[] detial = info[0].Replace("{", "").Replace("}", "").Split(',');
                for (int h = 0; h < detial.Length; h++)
                {
                    string[] data = detial[h].Replace("{", "").Replace("}", "").Split(':');
                    result.Add(data[0], Base64.decodebase64(data[1]));
                }
                if (result["success"] != "1")
                {
                    //Log4Net.error(param + ":" + result["message"]); return -1;
                }
                else
                {
                    string[] fymx = info[1].Replace("[", "").Replace("]", "").Replace("},{", "@").Split('@');
                    string sql = "";
                    for (int k = 0; k < fymx.Length; k++)
                    {
                        string[] xm = fymx[k].Replace("{", "").Replace("}", "").Split(',');
                        for (int l = 0; l < xm.Length; l++)
                        {
                            string[] dd = xm[l].Split(':');
                            ResultList.Add(dd[0], Base64.decodebase64(dd[1]));
                        }
                        int i = doUploadCostdet(ResultList["hisDetailCode"], ResultList["detailNo"], ResultList["enableMoney"]);//修改医保费用状态 流水号  报销费用                         
                        if (i == -1)
                        {
                            //Log4Net.error("数据更新失败！" + ResultList["hisDetailCode"]);//记录信息
                        }
                      
                        ResultList.Clear();
                    }
                    BllMain.Db.Update(sql);
                }
                result.Clear();
            }
            catch (Exception ex)
            {
                //ex.ToString();
                return -1;
            }
            return 0;
        }
        public string posturl(string website, string param)//费用录入
        {
            string result = "";
            try
            {
                string postData = param;//POST参数和值写入POSTDATE里
                byte[] byteArray = Encoding.Default.GetBytes(postData);
                string url = website;
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(url));
                webRequest.Method = "POST";
                webRequest.ContentType = "application/json";
                webRequest.ContentLength = byteArray.Length;
                Stream newStream = webRequest.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length);
                newStream.Close();
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                StreamReader php = new StreamReader(response.GetResponseStream(), Encoding.Default);
                string Message = php.ReadToEnd();
                result = Message;
            }
            catch (WebException ex)
            {
                string strHtml = "";
                HttpWebResponse res = ex.Response as HttpWebResponse;
                if (res.StatusCode == HttpStatusCode.InternalServerError)
                {
                    Stream s = res.GetResponseStream();
                    StreamReader objReader = new StreamReader(s, System.Text.Encoding.GetEncoding("utf-8"));
                    string strLine = "";
                    //读取                      
                    while (strLine != null)
                    {
                        strLine = objReader.ReadLine();
                        if (strLine != null)
                        {
                            strHtml += strLine.Trim();
                        }
                    }
                }
                else { strHtml = ex.Message; }

                result = strHtml;
            }
            return result;
        }

        /// <summary>
        /// 药品诊疗分类字典下载
        /// </summary>
        /// <param name="weburl"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="centerno"></param>
        public DataTable feeClassDown(string weburl, string username, string password, string centerno)
        {
            DataTable dt = new DataTable();
            WebClient webClient = new WebClient();
            string url = weburl + "feeClassDown?userName=" + Base64.encodebase64(username) + "&userPwd=" + Base64.encodebase64(password) + "&centerNo=" + Base64.encodebase64(centerno) + "";
            try
            {
                Dictionary<int, string> result = new Dictionary<int, string>();
                string param = webClient.DownloadString(url);
                try
                {
                    string[] info = param.Replace("},{", "@").Split('@');
                    for (int i = 0; i < info.Length; i++)
                    {
                        string[] detial = info[i].Replace("[{", "").Replace("}]", "").Replace("\"", "").Split(',');
                        for (int j = 0; j < detial.Length; j++)
                        {
                            string[] data = detial[j].Split(':');
                            result.Add(j, Base64.decodebase64(data[1]).Replace("\'", "\\\'"));
                        }
                        dt.Rows.Add();
                        for (int j = 0; j < result.Count; j++)
                        {
                            dt.Rows[i][j] = result[j];
                        }
                        result.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取失败:" + Base64.decodebase64(Base64.GetPageCodeBy500Error(url, "utf-8").Split(':')[1].Replace("\"", "").Replace("}", "")));
                return null;
            }
            return dt;
        }

        /// <summary>
        /// 保存贵州农合登记信息
        /// </summary>
        /// <param name="gzsnhRegInfo"></param>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public int saveRegInfo(GzsnhRegInfo gzsnhRegInfo,string ihsp_id)
        {
            string strXml = "<info>";
            //strXml += "<weburl>" + gzsnhRegInfo.Url + "</weburl>";//网络地址
            //strXml += "<centerNo>" + gzsnhRegInfo.Centerno + "</centerNo>";//农合中心编码
            //strXml += "<hospCode>" + gzsnhRegInfo.HospCode + "</hospCode>";//医疗机构编码
            //strXml += "<userName>" + gzsnhRegInfo.UserName + "</userName>";//用户名
            //strXml += "<userPwd>" + gzsnhRegInfo.UserPwd + "</userPwd>";//密码
            strXml += "<inpatientSn>" + gzsnhRegInfo.Inpatientsn + "</inpatientSn>";//农合住院流水号
            strXml += "<membersysNo>" + gzsnhRegInfo.Membersysno + "</membersysNo>";//个人编号
            strXml += "<familysysNo>" + gzsnhRegInfo.Familysysno + "</familysysNo>";//家庭编码
            strXml += "<bookNo>" + gzsnhRegInfo.BookNo + "</bookNo>";//医疗证卡号 
            strXml += "</info>";
            string sql="update inhospital set insurcode="+DataTool.addFieldBraces(gzsnhRegInfo.Membersysno)
                +",insurdata1="+DataTool.addFieldBraces(gzsnhRegInfo.Inpatientsn)
                +",insurdata2="+DataTool.addFieldBraces(gzsnhRegInfo.Familysysno)
                +",insurdata3="+DataTool.addFieldBraces(gzsnhRegInfo.BookNo)
                +" where id="+DataTool.addIntBraces(ihsp_id)+";";
            int flag = registInfo(strXml, ihsp_id,sql);
            if (flag < 0)
            {
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// 保存贵州农合结算信息
        /// </summary>
        /// <param name="gzsnhRegInfo"></param>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public int saveSettInfo(Dictionary<string, string> result, string ihsp_id,string ihspcode)
        {
            string strXml = "<info>";
            strXml += "<ihspcode>" + ihspcode + "</ihspcode>";//
            strXml += "<memberNo>" + result["memberNo"] + "</memberNo>";//成员编码
            strXml += "<name>" + result["name"] + "</name>";//成员姓名
            strXml += "<bookNo>" + result["bookNo"] + "</bookNo>";//医疗卡号
            strXml += "<sexName>" + result["sexName"] + "</sexName>";//性别名称
            strXml += "<birthday>" + result["birthday"] + "</birthday>";//出生年月
            strXml += "<masterName>" + result["masterName"] + "</masterName>";//户主姓名
            strXml += "<relationName>" + result["relationName"] + "</relationName>";//与户主关系名称
            strXml += "<identityName>" + result["identityName"] + "</identityName>";//个人身份属性名称
            strXml += "<currYearRedeemCount>" + result["currYearRedeemCount"] + "</currYearRedeemCount>";// 当前年度成员住院已补偿次数
            strXml += "<currYearTotal>" + result["currYearTotal"] + "</currYearTotal>";//当前年度成员住院已补偿总医疗费用（单位元，小数点后 （单位元，小数点后 （单位元，小数点后 （单位元，小数点后 保留两位）
            strXml += "<currYearEnableMoney>" + result["currYearEnableMoney"] + "</currYearEnableMoney>";//当前年度成员住院已补偿总保内费用
            strXml += "<currYearReddemMoney>" + result["currYearReddemMoney"] + "</currYearReddemMoney>";//当前年度成员住院已补偿金额
            strXml += "<familyNo>" + result["familyNo"] + "</familyNo>";//成员家庭编码
            strXml += "<address>" + result["address"] + "</address>";// 成员家庭住址
            strXml += "<joinPropName>" + result["joinPropName"] + "</joinPropName>";//参合属性名称
            strXml += "<currFamilyRedeemCount>" + result["currFamilyRedeemCount"] + "</currFamilyRedeemCount>";//当前年度家庭住院已补偿次数
            strXml += "<currFamilyTotal>" + result["currFamilyTotal"] + "</currFamilyTotal>";//当前年度家庭住院已补偿总医疗费用
            strXml += "<currFamilyEnableMoney>" + result["currFamilyEnableMoney"] + "</currFamilyEnableMoney>";// 当前年度家庭住院已补偿保内费用
            strXml += "<currFamilyReddemMoney>" + result["currFamilyReddemMoney"] + "</currFamilyReddemMoney>";// 当前年度家庭住院已补偿金额
            strXml += "<totalCosts>" + result["totalCosts"] + "</totalCosts>";// 本次住院总医疗费用
            strXml += "<enableMoney>" + result["enableMoney"] + "</enableMoney>";//本次住院保内费用   
            strXml += "<essentialMedicineMoney>" + result["essentialMedicineMoney"] + "</essentialMedicineMoney>";//本次住院费用中国定基本药品费用
            strXml += "<provinceMedicineMoney>" + result["provinceMedicineMoney"] + "</provinceMedicineMoney>";//本次住院费用中省补基本药品费
            strXml += "<startMoney>" + result["startMoney"] + "</startMoney>";//本次住院补偿扣除起付线金额
            strXml += "<calculateMoney>" + result["calculateMoney"] + "</calculateMoney>";//本次住院补偿金额
            strXml += "<redeemTypeName>" + result["redeemTypeName"] + "</redeemTypeName>";//补偿类型名称
            strXml += "<isSpecial>" + result["isSpecial"] + "</isSpecial>";//是否为单病种补偿
            strXml += "<isPaul>" + result["isPaul"] + "</isPaul>";//是否实行保底补偿
            strXml += "<anlagernMoney>" + result["anlagernMoney"] + "</anlagernMoney>";//追补金额，中药和国定基本药品提高补偿额部分
            strXml += "<fundPayMoney>" + result["fundPayMoney"] + "</fundPayMoney>";//单病种费用定额
            strXml += "<hospAssumeMoney>" + result["hospAssumeMoney"] + "</hospAssumeMoney>";// 医疗机构承担费用
            strXml += "<personalPayMoney>" + result["personalPayMoney"] + "</personalPayMoney>";//重大疾病个人自付费 
            strXml += "<YFmedicalAid>" + result["YFmedicalAid"] + "</YFmedicalAid>";//民政优抚医疗补助
            strXml += "<CXmedicalAid>" + result["CXmedicalAid"] + "</CXmedicalAid>";//民政城乡医疗救助
            strXml += "<materialMoney>" + result["materialMoney"] + "</materialMoney>";// 高额材料限价超费
            strXml += "<calculationMethod>" + result["calculationMethod"] + "</calculationMethod>";//本次结算计方法 本次结算计方法 本次结算计方法
            strXml += "<ChinaCharityPay>" + result["ChinaCharityPay"] + "</ChinaCharityPay>";//慈善总会支付金额
            strXml += "<isLongPeriod>" + result["isLongPeriod"] + "</isLongPeriod>";//是否长周期定额付费 是否长周期定额付费 是否长周期定额付费
            strXml += "<isCII>" + result["isCII"] + "</isCII>";// 是否进入大病保险
            strXml += "<CIIEligibleCosts>" + result["CIIEligibleCosts"] + "</CIIEligibleCosts>";//大病保险合规费用
            strXml += "<CIIStartMoney>" + result["CIIStartMoney"] + "</CIIStartMoney>";//本次大病保险起付线
            strXml += "<CIICalculateMoney>" + result["CIICalculateMoney"] + "</CIICalculateMoney>";//本次大病保险补偿金额
            strXml += "<CIICumulativePay>" + result["CIICumulativePay"] + "</CIICumulativePay>";//累计大病保险补偿金额
            strXml += "<CIICumulativeStart>" + result["CIICumulativeStart"] + "</CIICumulativeStart>";//累计大病保险扣除起付线金额
            strXml += "<CIICumulativeEligible>" + result["CIICumulativeEligible"] + "</CIICumulativeEligible>";//累计进入大病保险合
            strXml += "<FamilyPlanningWaiver>" + result["FamilyPlanningWaiver"] + "</FamilyPlanningWaiver>";//计生两户减免费用金
            strXml += "</info>";
            int flag = settInfo(strXml, ihsp_id);
            if (flag < 0)
            {
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 获取贵州农合结算信息
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public DataTable readSettInfo(string ihsp_id)
        {
            DataTable dt = gzsnhInfo(ihsp_id);
            string reginfo = dt.Rows[0]["settinfo"].ToString();
            System.IO.StringReader sr = new System.IO.StringReader(reginfo);
            DataSet ds = new DataSet();
            ds.ReadXml(sr);
            DataTable dtNew = ds.Tables["info"];
            return dtNew;
        }

        /// <summary>
        /// 获取贵州农合登记信息
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public GzsnhRegInfo readRegInfo(string ihsp_id)
        {
            GzsnhRegInfo gzsnhRegInfo = new GzsnhRegInfo();
 
            DataTable dt=gzsnhIhspInfo(ihsp_id);
            gzsnhRegInfo.Inpatientsn = dt.Rows[0]["inpatientsn"].ToString();
            gzsnhRegInfo.Membersysno = dt.Rows[0]["membersysno"].ToString();
            gzsnhRegInfo.Familysysno = dt.Rows[0]["familysysno"].ToString();
            gzsnhRegInfo.Centerno = dt.Rows[0]["centerno"].ToString();
            gzsnhRegInfo.BookNo = dt.Rows[0]["bookno"].ToString();
            return gzsnhRegInfo;
        }
        /// <summary>
        /// 入院登记取消
        /// </summary>
        /// <param name="ihspcode">住院号</param>
        /// <returns></returns>
        public int cancleHisNhryinfo(string ihsp_id)
        {
            string sql = "update inhospital set insurstat='OO', bas_patienttype_id= '1', bas_patienttype1_id= '1',Insuritemtype='1'  where id=" + DataTool.addFieldBraces(ihsp_id);
            return BllMain.Db.Update(sql);
        }

        public int updateHisNhcyinfo(string ihsp_id)
        {
            string sql = "update inhospital set insurouthsp=1  where id=" + DataTool.addFieldBraces(ihsp_id);
            return BllMain.Db.Update(sql);
        }

        public int cancleHisNhcyinfo(string ihsp_id)
        {
            string sql = "update inhospital set insurouthsp=0  where id=" + DataTool.addFieldBraces(ihsp_id);
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 入院登记，和 编辑入院登记信息
        /// </summary>
        /// <param name="zyjliid"></param>
        /// <param name="nhdj"></param>
        /// <param name="patienttypeId"></param>
        /// <param name="insuritemtype"></param>
        /// <returns></returns>
        public int updateHisNhryinfo(string zyjliid, GzsnhRegInfo nhdj, string patienttypeId, string insuritemtype)
        {
            string sql = "select * from insur_gzsnhryinfo where mtzyjliid=" + zyjliid;
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            string sql2 = "";
            if (dt.Rows.Count == 0)
            {
                sql2 = "INSERT INTO insur_gzsnhryinfo(";
                sql2 += "mtzyjliid, stature, weight, icdallno, secondicdno, threeicdno,";
                sql2 += "opsid, treatcode, cureid, complication, inhosid, curedocotor, ";
                sql2 += "bedno, sectionno, ticketno, ministernotice, procreatenotice, ";
                sql2 += "tel, isnewborn, newbornbirthday, newbornname, newbornsex"
                +",inpatientsn"
                +",bookno"
                +",familysysno"
                +",membersysno"
                +",centerno"
                + ",turnmode"//转诊类型
                + ",turncode"//转诊编码
                + ",turndate"//转诊日期
                +") ";
                sql2 += "VALUES (" + zyjliid + ", '" + nhdj.Stature + "', '" + nhdj.Weight + "', '" + nhdj.Icdallno + "', '" + nhdj.Secondicdno + "', '" + nhdj.Threeicdno + "', ";
                sql2 += "'" + nhdj.Opsid + "', '" + nhdj.Treatcode + "', '" + nhdj.Cureid + "', '" + nhdj.Complication + "', '" + nhdj.Inhosid + "', '" + nhdj.Curedoctor + "', ";
                sql2 += "'" + nhdj.Bedno + "', '" + nhdj.Sectionno + "', '" + nhdj.Ticketno + "', '" + nhdj.Ministernotice + "', '" + nhdj.Procreatenotice + "', ";
                sql2 += "'" + nhdj.Tel + "', '" + nhdj.Isnewborn + "', '" + nhdj.Newbornbirthday + "', '" + nhdj.Newbornname + "', '" + nhdj.Newbornsex +"'"
                   + "," + DataTool.addFieldBraces(nhdj.Inpatientsn)
                   + "," + DataTool.addFieldBraces(nhdj.BookNo)
                   + "," + DataTool.addFieldBraces(nhdj.Familysysno)
                   + "," + DataTool.addFieldBraces(nhdj.Membersysno)
                   + "," + DataTool.addFieldBraces(nhdj.Centerno)
                   + "," + DataTool.addFieldBraces(nhdj.Turnmode)
                   + "," + DataTool.addFieldBraces(nhdj.Turncode)
                   + "," + DataTool.addFieldBraces(nhdj.Turndate)
                    + ");";
                
            }
            else
            {
                sql2 = "UPDATE insur_gzsnhryinfo ";
                sql2 += "SET  stature='" + nhdj.Stature + "', weight='" + nhdj.Weight + "', icdallno='" + nhdj.Icdallno + "', secondicdno='" + nhdj.Secondicdno + "', ";
                sql2 += "threeicdno='" + nhdj.Threeicdno + "', opsid='" + nhdj.Opsid + "', treatcode='" + nhdj.Treatcode + "', cureid='" + nhdj.Cureid + "', complication='" + nhdj.Complication + "', ";
                sql2 += "inhosid='" + nhdj.Inhosid + "', curedocotor='" + nhdj.Curedoctor + "', bedno='" + nhdj.Bedno + "', sectionno='" + nhdj.Sectionno + "', ticketno='" + nhdj.Ticketno + "', ministernotice='" + nhdj.Ministernotice + "',";
                sql2 += "procreatenotice='" + nhdj.Procreatenotice + "', tel='" + nhdj.Tel + "', isnewborn='" + nhdj.Isnewborn + "', newbornbirthday='" + nhdj.Newbornbirthday + "', newbornname='" + nhdj.Newbornname + "', ";
                sql2 += "newbornsex='" + nhdj.Newbornsex + "'"
                 + ",inpatientsn=" + DataTool.addFieldBraces(nhdj.Inpatientsn)
                 + ",bookno=" + DataTool.addFieldBraces(nhdj.BookNo)
                 + ",familysysno=" + DataTool.addFieldBraces(nhdj.Familysysno)
                 + ",membersysno=" + DataTool.addFieldBraces(nhdj.Membersysno)
                 + ",centerno=" + DataTool.addFieldBraces(nhdj.Centerno)
                 + ",turnmode=" + DataTool.addFieldBraces(nhdj.Turnmode)
                 + ",turncode=" + DataTool.addFieldBraces(nhdj.Turncode)
                 + ",turndate=" + DataTool.addFieldBraces(nhdj.Turndate);
                sql2 += " WHERE mtzyjliid=" + zyjliid + ";";
            }
            sql2 += " update inhospital set insurstat= 'REG'"
                 + ",bas_patienttype_id=" + DataTool.addFieldBraces(patienttypeId)
                 + ",bas_patienttype1_id='32'" 
                 + ",insuritemtype=" + DataTool.addFieldBraces(insuritemtype)
                    + " where id = " + DataTool.addFieldBraces(zyjliid) + ";";
            return BllMain.Db.Update(sql2);
        }
        public DataTable getHisCenternoList(string centerno)
        {
                  string sql = "select * from insur_gzsnhzxbm where dqmc like '%"+centerno+"%'";
                  DataTable dt = BllMain.Db.Select(sql).Tables[0];
                  return dt;
            
        }
        public string getHisInpatientsn(string ihsp_id)
        {
            string inpatientsn = "";
                string sql =  "select * from insur_gzsnhryinfo where mtzyjliid=" + ihsp_id;
                    DataTable dt = BllMain.Db.Select(sql).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        inpatientsn = dt.Rows[0]["inpatientsn"].ToString();
                    }
                    return inpatientsn;
        }
        public DataTable getHisInhspInfo(string ihsp_id)
        {
            string sql = "select name,ihspcode from inhospital where id=" + DataTool.addIntBraces(ihsp_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;

        }
        public DataTable getHisIhspInsurInfo(string ihsp_id)
        {
              string sql = " SELECT "
                            +" inhospital.id,"
                            +" inhospital.name,"
                            +" inhospital.insuritemtype,"
                            +" inhospital.bas_patienttype_id,"
                            +" inhospital.member_id,"
                            +" insur_gzsnhryinfo.centerno,"
                            +" insur_gzsnhryinfo.membersysno,"
                            +" insur_gzsnhryinfo.inpatientsn,"
                            +" insur_gzsnhryinfo.familysysno,"
                            +" inhospital.outdate,"
                            +" ihsp_diagnmes.diagnname,"
                            +" cost_insurdepart.insurcode as nhkscode,"
                            +" insur_gzsnhryinfo.turnmode,"
                            +" insur_gzsnhryinfo.turncode,"
                            +" insur_gzsnhryinfo.turndate,"
                            +" insur_gzsnhryinfo.bookno,"
                            +" inhospital.status ,"
                            +" ihsp_account.id as ihsp_account_id"
                            +" FROM inhospital"
                            +" LEFT JOIN  insur_gzsnhryinfo on insur_gzsnhryinfo.mtzyjliid = inhospital.id"
                            +" LEFT JOIN  ihsp_diagnmes on ihsp_diagnmes.ihsp_id = inhospital.id and ihsp_diagnmes.diagnKind='OUT' and ihsp_diagnmes.opkind='MAIN'"
                            +" LEFT JOIN  cost_insurdepart on inhospital.depart_id = cost_insurdepart.depart_id and cost_insurdepart.insuritemtype = '1'"
                            +" LEFT JOIN ihsp_account on inhospital.id = ihsp_account.ihsp_id"
                            +" WHERE inhospital.id = " + DataTool.addIntBraces(ihsp_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        public DataTable getHisCostDet(string zyjliid, string insuritemtype)//费用明细查询
        {
            string sql = " SELECT"
                                + " ihsp_costdet.id as iid,"
                                + " ihsp_costdet.item_id as mtprod,"
                                + " ihsp_costdet.name as xmmc,"
                                + " drug_dosageform.name as prodjixing, "
                                + " cost_insuritem.name as xmmc,"
                                + " cost_insuritem.insurcode as nhbm,"
                                + " ihsp_costdet.spec as guige,"
                                + " ihsp_costdet.prc AS prc,"
                                + " ihsp_costdet.num AS qty,"
                                + " ihsp_costdet.chargedate AS createdat,"
                                + " ihsp_costdet.insurcostsn AS detailno"
                                + " FROM"
                                + " ihsp_costdet"
                                + " LEFT JOIN cost_insurcross  on ihsp_costdet.item_id=cost_insurcross.item_id"
                                + " LEFT JOIN cost_insuritem cost_insuritem on cost_insurcross.cost_insuritem_id=cost_insuritem.id"
                                + " LEFT JOIN sys_dict drug_dosageform on drug_dosageform.id=ihsp_costdet.dosageform_id and drug_dosageform.father_id<>0"
                                + " WHERE cost_insurcross.insuritemtype = " + DataTool.addFieldBraces(insuritemtype)
                                + " and ihsp_costdet.charged in ('RREC', 'RET','CHAR') and  settled='N'"
                                + " and ihsp_costdet.neonate_id =0"
                                + " and ihsp_costdet.ihsp_id =" + DataTool.addFieldBraces(zyjliid)
                                + " order by createdat";
            
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
      
        /// <summary>
        /// 费用上传
        /// </summary>
        /// <param name="mtzyjliid"></param>
        public bool uploadDetials(string mtzyjliid,ref string returnMsg)//费用录入
        {
            DataTable ihsp = getHisIhspInsurInfo(mtzyjliid);
            string insuritemtype = ihsp.Rows[0]["insuritemtype"].ToString();
            bool isgynh = false;
            if (insuritemtype.Trim().Equals("2"))
            {
                isgynh = true;
            }
            DataTable det = getTranCostDet(mtzyjliid, insuritemtype);


            string wdmxm = "";
            for (int i = 0; i < det.Rows.Count; i++)
            {

                if (string.IsNullOrEmpty(det.Rows[i]["nh_code"].ToString()))
                {
                    wdmxm += det.Rows[i]["hisname"].ToString() + ",";
                }

            }
            if (wdmxm != "")
            {
                if (isgynh)
                {
                    returnMsg+="贵阳农合下列项目未对码：" + wdmxm + "请对码后再结算";
                    return false;
                }
                else
                {
                    returnMsg+="贵州异地农合下列项目未对码：" + wdmxm + "请对码后再结算";
                    return false;
                }
            }

            string paramc = "";
            string mw = "";
            for (int j = 0; j < det.Rows.Count; j++)
            {
                if (j % 100 != 0)
                    paramc += ",";
                string prodjixing = "0";
                if (det.Rows[j]["dosageform"].ToString() != "")
                    prodjixing = det.Rows[j]["dosageform"].ToString();
                
               
                if (isgynh)
                {
                    paramc += "{\"hisDetailCode\":\"" + Base64.encodebase64(det.Rows[j]["id"].ToString()) + "\",\"hisMedicineCode\":\"" + Base64.encodebase64(det.Rows[j]["item_id"].ToString()) + "\",\"medicineCode\":\"" + Base64.encodebase64(det.Rows[j]["nh_code"].ToString()) + "\",\"medicineName\":\"" + Base64.encodebase64(det.Rows[j]["name"].ToString()) + "\",\"spec\":\"" + Base64.encodebase64(det.Rows[j]["spec"].ToString()) + "\",\"conf\":\"" + Base64.encodebase64(prodjixing) + "\",\"unit\":\"" + Base64.encodebase64(det.Rows[j]["unit"].ToString()) + "\",\"price\":\"" + Base64.encodebase64(det.Rows[j]["prc"].ToString()) + "\",\"quantity\":\"" + Base64.encodebase64(det.Rows[j]["num"].ToString()) + "\",\"useDate\":\"" + Base64.encodebase64(DateTime.Parse(det.Rows[j]["chargedate"].ToString()).ToString("yyyy-MM-dd")) + "\",\"recipeID\":\"" + Base64.encodebase64(det.Rows[j]["id"].ToString()) + "\"}";
                    mw += "{\"hisDetailCode\":\"" + det.Rows[j]["id"].ToString() + "\",\"hisMedicineCode\":\"" + det.Rows[j]["item_id"].ToString() + "\",\"medicineCode\":\"" + det.Rows[j]["nh_code"].ToString() + "\",\"medicineName\":\"" + det.Rows[j]["name"].ToString() + "\",\"spec\":\"" + det.Rows[j]["spec"].ToString() + "\",\"conf\":\"" + prodjixing + "\",\"unit\":\"" + det.Rows[j]["unit"].ToString() + "\",\"price\":\"" + det.Rows[j]["prc"].ToString() + "\",\"quantity\":\"" + det.Rows[j]["num"].ToString() + "\",\"useDate\":\"" + DateTime.Parse(det.Rows[j]["chargedate"].ToString()).ToString("yyyy-MM-dd") + "\",\"recipeID\":\"" + det.Rows[j]["id"].ToString() + "\"}";
                }
                else
                {
                    paramc += "{\"hisDetailCode\":\"" + Base64.encodebase64(det.Rows[j]["id"].ToString()) + "\",\"hisMedicineCode\":\"" + Base64.encodebase64(det.Rows[j]["item_id"].ToString()) + "\",\"medicineCode\":\"" + Base64.encodebase64(det.Rows[j]["nh_code"].ToString()) + "\",\"medicineName\":\"" + Base64.encodebase64(det.Rows[j]["name"].ToString()) + "\",\"spec\":\"" + Base64.encodebase64(det.Rows[j]["spec"].ToString()) + "\",\"conf\":\"" + Base64.encodebase64(prodjixing) + "\",\"unit\":\"" + Base64.encodebase64(det.Rows[j]["unit"].ToString()) + "\",\"price\":\"" + Base64.encodebase64(det.Rows[j]["prc"].ToString()) + "\",\"quantity\":\"" + Base64.encodebase64(det.Rows[j]["num"].ToString()) + "\",\"useDate\":\"" + Base64.encodebase64(DateTime.Parse(det.Rows[j]["chargedate"].ToString()).ToString("yyyy-MM-dd")) + "\",\"recipeID\":\"" + Base64.encodebase64(det.Rows[j]["id"].ToString()) + "\"}";
                    mw += "{\"hisDetailCode\":\"" + det.Rows[j]["id"].ToString() + "\",\"hisMedicineCode\":\"" + det.Rows[j]["item_id"].ToString() + "\",\"medicineCode\":\"" + det.Rows[j]["nh_code"].ToString() + "\",\"medicineName\":\"" + det.Rows[j]["name"].ToString() + "\",\"spec\":\"" + det.Rows[j]["spec"].ToString() + "\",\"conf\":\"" + prodjixing + "\",\"unit\":\"" + det.Rows[j]["unit"].ToString() + "\",\"price\":\"" + det.Rows[j]["prc"].ToString() + "\",\"quantity\":\"" + det.Rows[j]["num"].ToString() + "\",\"useDate\":\"" + DateTime.Parse(det.Rows[j]["chargedate"].ToString()).ToString("yyyy-MM-dd") + "\",\"recipeID\":\"" + det.Rows[j]["id"].ToString() + "\"}";
                }
                if ((j + 1) % 100 == 0)
                {
                    string param = "{\"userName\":\"" + Base64.encodebase64(GzsnhGlobal.UserName) + "\",\"userPwd\":\"" + Base64.encodebase64(GzsnhGlobal.UserPwd) + "\",\"centerNo\":\"" + Base64.encodebase64(ihsp.Rows[0]["centerno"].ToString()) + "\",\"doctor\":\"\",\"hospCode\":\"" + Base64.encodebase64(GzsnhGlobal.HospCode) + "\",\"bookNo\":\"" + Base64.encodebase64(ihsp.Rows[0]["bookno"].ToString()) + "\",\"name\":\"" + Base64.encodebase64(ihsp.Rows[0]["name"].ToString()) + "\",\"familyNo\":\"" + Base64.encodebase64(ihsp.Rows[0]["familysysno"].ToString()) + "\",\"memberNo\":\"" + Base64.encodebase64(ihsp.Rows[0]["membersysno"].ToString()) + "\",\"inpatientSn\":\"" + Base64.encodebase64(ihsp.Rows[0]["inpatientsn"].ToString()) + "\",\"rows\":\"" + Base64.encodebase64("100") + "\",\"InpatientDetailList\":[";
                    int a = fytran(param + paramc + "]}", GzsnhGlobal.Url);
                    if (a == -1)
                    {
                            returnMsg += "费用传送出错是否继续";
                            return false;
                    }
                    paramc = "";
                    mw = "";
                }
                else if (j == det.Rows.Count - 1)
                {
                    string param = "{\"userName\":\"" + Base64.encodebase64(GzsnhGlobal.UserName) + "\",\"userPwd\":\"" + Base64.encodebase64(GzsnhGlobal.UserPwd) + "\",\"centerNo\":\"" + Base64.encodebase64(ihsp.Rows[0]["centerno"].ToString()) + "\",\"doctor\":\"\",\"hospCode\":\"" + Base64.encodebase64(GzsnhGlobal.HospCode) + "\",\"bookNo\":\"" + Base64.encodebase64(ihsp.Rows[0]["bookno"].ToString()) + "\",\"name\":\"" + Base64.encodebase64(ihsp.Rows[0]["name"].ToString()) + "\",\"familyNo\":\"" + Base64.encodebase64(ihsp.Rows[0]["familysysno"].ToString()) + "\",\"memberNo\":\"" + Base64.encodebase64(ihsp.Rows[0]["membersysno"].ToString()) + "\",\"inpatientSn\":\"" + Base64.encodebase64(ihsp.Rows[0]["inpatientsn"].ToString()) + "\",\"rows\":\"" + Base64.encodebase64((det.Rows.Count % 100).ToString()) + "\",\"InpatientDetailList\":[";
                    int a = fytran(param + paramc + "]}", GzsnhGlobal.Url);
                    if (a == -1)
                    {
                        returnMsg += "费用传送出错是否继续";
                        return false;
                    }
                }
            }
          return true;
        }

        public DataTable getTranCostDet(string ihsp_id, string insuritemtype)
        {

            string sql = "select "
                             + " ihsp_costdet.id"
                              + ", ihsp_costdet.item_id"
                             + ", ihsp_costdet.chargedate"
                              + ", ihsp_costdet.name"
                             + ", ihsp_costdet.spec"
                             + ", ihsp_costdet.unit"
                             + ", ihsp_costdet.prc"
                             + ", ihsp_costdet.fee"
                             + ", ihsp_costdet.num"
                             + ", drug_dosageform.name as dosageform"
                             + ", ihsp_costdet.name as hisname"
                             + ", cost_insurcross.insurname as nh_name"
                             + ", cost_insurcross.insurcode as nh_code"
                             + " from ihsp_costdet"
                             + " left join cost_insurcross on cost_insurcross.item_id=ihsp_costdet.item_id and cost_insurcross.drug_factyitem_id=ihsp_costdet.drug_factyitem_id"
                             + " LEFT JOIN sys_dict drug_dosageform on drug_dosageform.id=ihsp_costdet.dosageform_id and drug_dosageform.father_id<>0"
                             + " where ihsp_costdet.ihsp_id=" + DataTool.addIntBraces(ihsp_id)
                             + " and ihsp_costdet.charged in ('RREC', 'RET','CHAR')   and settled='N'"
                             + " and ihsp_costdet.neonate_id = 0" //非新生儿
                             + " and cost_insurcross.insuritemtype=" + DataTool.addFieldBraces(insuritemtype)
                             + " and ihsp_costdet.insursync='N'";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 修改医保传输状态
        /// </summary>
        /// <param name="costid"></param>
        /// <returns></returns>
        public int doUploadCostdet(string costid, string insurCostSn, string insurefee)
        {

            string sql = "update ihsp_costdet set insursync='Y', insurCostSn="+DataTool.addFieldBraces(insurCostSn)
                + " , insurefee=" + DataTool.addIntBraces(insurefee)
                + " , selffee= (realfee-" + DataTool.addIntBraces(insurefee)+")"
                +" where id=" + DataTool.addIntBraces(costid) + ";";
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 修改医保传输状态
        /// </summary>
        /// <param name="costid"></param>
        /// <returns></returns>
        public int undoUploadCostdet(string ihsp_id)
        {

            string sql = "update ihsp_costdet set "
                +" insursync='N', insurCostSn=''"
                + ", insurefee= 0"
                + ", selffee= 0"
                + " where ihsp_id=" + DataTool.addIntBraces(ihsp_id)
                + " and  settled='N';";
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 判断挂账
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <returns></returns>
        public bool isHisihspSign(string ihsp_id)
        {
            string sql = " select id from inhospital where status in ('SIGN ','MSIG') and id= "+ DataTool.addFieldBraces(ihsp_id);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 补偿类型
        /// </summary>
        /// <returns></returns>
        public DataTable getHisnhbcflcx()
        {
            string sql = "select code,name from insur_gzsnhbclbzd";
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            return dt;
        }

        public int accountNhStat(string ihsp_id)
        {
            string sql = " update inhospital set insurstat= 'SETT' where id=" + DataTool.addFieldBraces(ihsp_id);
            return BllMain.Db.Update(sql);
            
        }
     
        public int doAccNhJsxx(Dictionary<string, string> result, string ihsp_id)
        {
            string sql = "insert into insur_gzsnhzyinfo (memberno,name,bookno,sexname,birthday,mastername,relationname,identityname,idcard,curryearredeemcount,curryeartotal,curryearenablemoney,curryearreddemmoney,familyno,address,joinpropname,currfamilyredeemcount,currfamilytotal,currfamilyenablemoney,currfamilyreddemmoney,totalcosts,enablemoney,essentialmedicinemoney,provincemedicinemoney,startmoney,calculatemoney,redeemtypename,isspecial,ispaul,anlagernmoney,fundpaymoney,hospassumemoney,personalpaymoney,yfmedicalaid,cxmedicalaid,materialmoney,ihsp_id,calculationmethod,chinacharitypay,islongperiod,iscii,ciieligiblecosts,ciistartmoney,ciicalculatemoney,ciicumulativepay,ciicumulativestart,ciicumulativeeligible,familyplanningwaiver) values";
            sql += "('" + result["memberNo"] + "','" + result["name"] + "','" + result["bookNo"] + "','" + result["sexName"] + "','" + result["birthday"] + "','" + result["masterName"] + "','" + result["relationName"] + "','" + result["identityName"] + "','" + result["idCard"] + "','" + result["currYearRedeemCount"] + "','" + result["currYearTotal"] + "','" + result["currYearEnableMoney"] + "','" + result["currYearReddemMoney"] + "','" + result["familyNo"] + "','" + result["address"] + "','" + result["joinPropName"] + "','" + result["currFamilyRedeemCount"] + "','" + result["currFamilyTotal"] + "','" + result["currFamilyEnableMoney"] + "','" + result["currFamilyReddemMoney"] + "','" + result["totalCosts"] + "','" + result["enableMoney"] + "','" + result["essentialMedicineMoney"] + "','" + result["provinceMedicineMoney"] + "','" + result["startMoney"] + "','" + result["calculateMoney"] + "','" + result["redeemTypeName"] + "','" + result["isSpecial"] + "','" + result["isPaul"] + "','" + result["anlagernMoney"] + "','" + result["fundPayMoney"] + "','" + result["hospAssumeMoney"] + "','" + result["personalPayMoney"] + "','" + result["YFmedicalAid"] + "','" + result["CXmedicalAid"] + "','" + result["materialMoney"] + "','" + ihsp_id + "','" + result["calculationMethod"] + "','" + result["ChinaCharityPay"] + "','" + result["isLongPeriod"] + "','" + result["isCII"] + "','" + result["CIIEligibleCosts"] + "','" + result["CIIStartMoney"] + "','" + result["CIICalculateMoney"] + "','" + result["CIICumulativePay"] + "','" + result["CIICumulativeStart"] + "','" + result["CIICumulativeEligible"] + "','" + result["FamilyPlanningWaiver"] + "')";

            return BllMain.Db.Update(sql);
        }
        public int doAccNhbcfdxx(Dictionary<int, string> result, string ihsp_id)
        {
            string sql = "insert into  insur_gzsnhbcfdxx(inpatientsn,startmoney,endmoney,ratio,redeemmoney,ihsp_id) values ('" + result[0] + "','" + result[1] + "','" + result[2] + "','" + result[3] + "','" + result[4] + "','" +ihsp_id + "')";
            return BllMain.Db.Update(sql);
        }
        public int cancleAccNhJsxx(string ihsp_id)
        {
            string sql = "update inhospital set insurstat= 'REG' where id=" + DataTool.addFieldBraces(ihsp_id)+"; delete from insur_gzsnhzyinfo where ihsp_id=" + DataTool.addFieldBraces(ihsp_id) + ";";
            return BllMain.Db.Update(sql);
        }
        /// <summary>
        /// 获取PaysumbyId
        /// </summary>
        /// <param name="PaytypeId"></param>
        /// <returns></returns>
        public string getPaysumby(string PaytypeId)
        {
            string sql = " SELECT id from bas_paysumby WHERE bas_paysumby.bas_paytype_id =" + DataTool.addFieldBraces(PaytypeId);
            DataTable dt = BllMain.Db.Select(sql).Tables[0];
            string ret = dt.Rows[0]["id"].ToString();
            return ret;
        }

        public bool NursYjs(string ihsp_id)
        {
              string returnMsg = "";
              if (!uploadDetials(ihsp_id, ref returnMsg))
              {
                  return false;
              }
            Yjs_data jsxx = new Yjs_data();
            List<Dictionary<int, string>> bcxxList = new List<Dictionary<int, string>>();
           return nhYjs(ihsp_id, "1", "1", ref jsxx, bcxxList);
        }

        /// <summary>
        /// 农合预结算
        /// </summary>
        /// <param name="ihsp_id"></param>
        /// <param name="sftgcl">身份属性证明 默认 "1"</param>
        /// <param name="bclx">补偿类别 默认 "1"</param>
        /// <param name="jsxx">输出</param>
        /// <param name="bcxxList">输出</param>
        /// <returns></returns>
        public bool nhYjs(string ihsp_id, string sftgcl, string bclx, ref Yjs_data jsxx, List<Dictionary<int, string>> bcxxList)
        {
            if (string.IsNullOrEmpty(bclx))
                bclx = "1";
            DataTable dt = getHisIhspInsurInfo(ihsp_id);
           
            WebClient webClient = new WebClient();
            string inpatientsn = dt.Rows[0]["inpatientSn"].ToString();
            string centerno = dt.Rows[0]["centerno"].ToString();
            string cysj = BillSysBase.currDate();
            Dictionary<string, string> result = new Dictionary<string, string>();
           
            string url = GzsnhGlobal.Url + "inpatientCalculate?userName=" + Base64.encodebase64(GzsnhGlobal.UserName) + "&userPwd=" + Base64.encodebase64(GzsnhGlobal.UserPwd) + "&centerNo=" + Base64.encodebase64(centerno) + "&hospCode=" + Base64.encodebase64(GzsnhGlobal.HospCode) + "&inpatientSn=" + Base64.encodebase64(inpatientsn) + "&redeemNo=" + Base64.encodebase64(bclx) + "&outDate=" + Base64.encodebase64(cysj) + "&type=" + Base64.encodebase64("1") + "&isMaterials=" + Base64.encodebase64(sftgcl) + "&operationName=" + Base64.encodebase64(ProgramGlobal.Username) + "";
            try
            {
                string param = webClient.DownloadString(url);//.Split(':')[1].Replace("\"", "").Replace("}", "");
                string[] info = param.Replace("\"", "").Replace(",gradeList:", "@").Split('@');
                string[] firstp = info[0].Replace("{", "").Replace("}", "").Split(',');
                for (int i = 0; i < firstp.Length; i++)
                {
                    string[] item = firstp[i].Split(':');
                    result.Add(item[0], Base64.decodebase64(item[1]));
                }
                jsxx.Jsxx= "成员编码:" + result["memberNo"] + "\t成员姓名:" + result["name"] + "\t医疗证、卡号:" + result["bookNo"] + "\t性别:" + result["sexName"] + "\r\n出生年月日:" + result["birthday"] + "\t户主姓名:" + result["masterName"] + "";
                    jsxx.Jsxx += "\t与户主关系名称:" + result["relationName"] + "\t个人身份属性名称:" + result["identityName"] + "\r\n身份证号码:" + result["idCard"] + "\r\n当前年度成员住院已补偿次数:" + result["currYearRedeemCount"] + "\t当前年度成员住院已补偿总医疗费用:" + result["currYearTotal"] + "\r\n当前年度成员住院已补偿总保内费用:" + result["currYearEnableMoney"] + "";
                    jsxx.Jsxx += "当前年度成员住院已补偿金额:" + result["currYearReddemMoney"] + "\r\n家庭编码:" + result["familyNo"] + "\t家庭住址:" + result["address"] + "\t参合属性:" + result["joinPropName"] + "\r\n当前年度家庭住院已补偿次数:" + result["currFamilyRedeemCount"] + "\t当前年度家庭住院已补偿总医疗费用:" + result["currFamilyTotal"] + "\r\n";
                    jsxx.Jsxx += "当前年度家庭住院已补偿保内费用:" + result["currFamilyEnableMoney"] + "\t当前年度家庭住院已补偿金额:" + result["currFamilyReddemMoney"] + "\r\n本次住院总医疗费用:" + result["totalCosts"] + "\t本次住院保内费用:" + result["enableMoney"] + "\r\n本次住院费用中国定基本药品费用:" + result["essentialMedicineMoney"] + "\t本次住院费用中省补基本药品费用:" + result["provinceMedicineMoney"] + "\r\n";
                    jsxx.Jsxx += "本次住院补偿扣除起付线金额:" + result["startMoney"] + "\t本次住院补偿金额:" + result["calculateMoney"] + "\t补偿类型名称:" + result["redeemTypeName"] + "\r\n是否为单病种补偿:" + result["isSpecial"] + "\t是否实行保底补偿:" + result["isPaul"] + "\r\n追补金额，中药和国定基本药品提高补偿额部分:" + result["anlagernMoney"] + "\r\n";
                    jsxx.Jsxx += "单病种费用定额:" + result["fundPayMoney"] + "\t医疗机构承担费用:" + result["hospAssumeMoney"] + "\t重大疾病个人自付费用:" + result["personalPayMoney"] + "\r\n民政优抚医疗补助:" + result["YFmedicalAid"] + "\t民政城乡医疗救助:" + result["CXmedicalAid"] + "\t高额材料限价超额费用:" + result["materialMoney"] + "\r\n";
                    jsxx.Jsxx += "本次结算计算方法：" + result["calculationMethod"] + "\t慈善总会支付金额:" + result["ChinaCharityPay"] + "\t是否长周期定额付费:" + result["isLongPeriod"] + "\t是否进入大病保险:" + result["isCII"] + "\t大病保险合规费用:" + result["CIIEligibleCosts"] + "\t本次大病保险起付线:" + result["CIIStartMoney"] + "\r\n";
                    jsxx.Jsxx += "本次大病保险补偿金额:" + result["CIICalculateMoney"] + "\t累计大病保险补偿额:" + result["CIICumulativePay"] + "\t累计大病保险扣除起付线金额:" + result["CIICumulativeStart"] + "\t累计进入大病保险合规费用:" + result["CIICumulativeEligible"] + "\t计生两户减免费用金额:" + result["FamilyPlanningWaiver"];
                double nhbx = Convert.ToDouble(result["calculateMoney"]);
                double mzbz = 0;
                if (result["YFmedicalAid"] != "")
                    mzbz = Convert.ToDouble(result["YFmedicalAid"]);
                double cxbz = 0;
                if (result["CXmedicalAid"] != "")
                    cxbz = Convert.ToDouble(result["CXmedicalAid"]);
                double dbbx = 0;
                if (result["CIICalculateMoney"] != "")
                    dbbx = Convert.ToDouble(result["CIICalculateMoney"]);
                double csbz = 0;
                if (result["ChinaCharityPay"] != "")
                    csbz = Convert.ToDouble(result["ChinaCharityPay"]);
                double jsbz = 0;
                if (result["FamilyPlanningWaiver"] != "")
                    jsbz = Convert.ToDouble(result["FamilyPlanningWaiver"]);
                double zbx = nhbx + mzbz + cxbz + dbbx + csbz + jsbz;
                jsxx.Nhbx = zbx.ToString("0.00");
                jsxx.Nhfy  = result["totalCosts"];
                
                string insuraccountfee = "0";
                string sql = "update inhospital set insurefee=" + DataTool.addFieldBraces(jsxx.Nhbx)
                    + ", insuraccountfee = " + DataTool.addFieldBraces(insuraccountfee)
                     + ", nustmpamt = balanceamt+ insuraccountfee+insurefee "
                    + " where id =" + DataTool.addFieldBraces(ihsp_id) + ";";

                //string[] secondp = info[1].Replace("[", "").Replace("]", "").Replace("},{", "@").Replace("{", "").Replace("}", "").Split('@');
                //bcxxList.Clear();
                //for (int j = 0; j < secondp.Length; j++)
                //{
                //    if (secondp[j] == "")
                //    {
                //        continue;
                //    }
                //    string[] item1 = secondp[j].Split(',');
                //    Dictionary<int, string> gradeList = new Dictionary<int, string>();
                //    for (int k = 0; k < item1.Length; k++)
                //    {
                //        string[] item2 = item1[k].Split(':');
                //        gradeList.Add(k, Base64.decodebase64(item2[1]));
                //    }
                //    bcxxList.Add(gradeList);
                //    gradeList.Clear();
                //}

                if( BllMain.Db.Update(sql)<0)
                    return false;      
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        //贵州省目录下载
        public bool insurItemGZSNH(string lasttime, ref string msg)
        {
           
            Dictionary<string, string> result = new Dictionary<string, string>();
            WebClient webClient = new WebClient();
            string centerno = "520000";
            string url = GzsnhGlobal.Url + "updateLeechdom?userName=" + Base64.encodebase64(GzsnhGlobal.UserName) + "&userPwd=" + Base64.encodebase64(GzsnhGlobal.UserPwd) + "&centerNo=" + Base64.encodebase64(centerno) + "&LastTime=" + Base64.encodebase64(lasttime) + "&hospCode=" + Base64.encodebase64(GzsnhGlobal.HospCode) + "";
            try
            {
                string param = webClient.DownloadString(url);//.Split(':')[1].Replace("\"", "").Replace("}", "");
                try
                {
                    string[] info = param.Replace("},{", "@").Split('@');
                
                    for (int i = 0; i < info.Length; i++)
                    {
                        string[] detial = info[i].Replace("[{", "").Replace("}]", "").Replace("\"", "").Split(',');
                        for (int j = 0; j < detial.Length; j++)
                        {
                            string[] data = detial[j].Split(':');
                            result.Add(data[0], Base64.decodebase64(data[1]).Replace("\'", "\\\'"));
                        }
                        string sql2 = "select insurcode from cost_insuritem where insurcode='" + result["insureId"] + "' and Insuritemtype='1'";
                        DataTable dt2 = BllMain.Db.Select(sql2).Tables[0];
                      
                        string insurclass = "";
                        if (result["ratio"].ToString().Trim().Equals("1"))
                        {
                            insurclass = "甲";

                        }
                        else if (result["ratio"].ToString().Trim().Equals("0"))
                        {
                            insurclass = "丙";
                        }
                        else
                        {
                            insurclass = "乙" + result["ratio"].ToString();
                        }
                        string sql_update = "";
                        if (dt2.Rows.Count == 0)
                        {
                            sql_update = " INSERT INTO cost_insuritem ("
                                    + "insurcode, "//insureId
                                //+"classno,"
                                 + "druggrade,"
                                  + "NAME,"// 名称 name
                                  + "spec,"// 规格 spec
                                  + "dosageform,"// 剂型  conf
                                  + "unit,"// 单位 unit
                                // +"price,"// 单价
                                + "everymoney,"
                                  + "ratioihsp,"// 报销比例 ratio
                                //+"adminlevel,"//
                                + "isclinic, "//门诊项目
                                //  +"projecttype,"
                                  + "limituse," //remark
                                  + "pincode,"// 拼音简码 inputpycode
                                  + "updateat,"// 更新时间updatetime
                                //+"inputwbcode,"//  
                                  + "limitprc,"// 最高限价approvemaxprice
                                + " limitminprc,"// +"approveminprice,"//  最低限价
                                // +"approvemaxpricecity, "// 市限价 
                                //+"approvemaxpricecounty,"// 县级限价
                                // +"approvemaxpricetown,"//  存限价
                                // +"xmid,"//   医保码 
                                //  +"manufacture,"// 厂家   
                                //  +"content,"//  
                                 + "insurclass,"// 甲乙丙 insurclass
                                 + "Insuritemtype"
                              + ")    VALUES ("
                                  + "'" + result["insureId"] + "',"
                                //+"'" + result["classNo"] + "',"
                                  + "'" + result["grade"] + "',"
                                  + "'" + result["name"] + "',"
                                  + "'" + result["spec"] + "',"
                                  + "'" + result["conf"] + "',"
                                  + "'" + result["unit"] + "',"
                                //+"'" + result["price"] + "',"
                                  + "'" + result["everyMoney"] + "',"
                                  + "'" + result["ratio"] + "',"
                                //+"'" + result["adminLevel"] + "',"
                                  + "'" + result["isClinic"] + "',"
                                //+"'" + result["projectType"] + "',"
                                  + "'" + result["remark"] + "',"
                                  + "'" + result["inputPyCode"] + "',"
                                  + "'" + result["UPDATE_TIME"] + "',"
                                //+"'" + result["inputWbCode"] + "',"
                                  + "'" + result["approveMaxPrice"] + "',"
                                  + "'" + result["approveMinPrice"] + "',"
                                //+"'" + result["approveMaxPrice_city"] + "',"
                                //+"'" + result["approveMaxPrice_county"] + "',"
                                //+"'" + result["approveMaxPrice_town"] + "',"
                                //+"'" + result["XMID"] + "',"
                                //+"'" + result["manufacturer"] + "',"
                                //+"'" + result["content"] + "',"
                                //+"'" + result["admitType"] + "'"

                                    + "'" + insurclass + "',"
                                    + "'1'"
                                  + ") ";
                        }
                        else
                        {

                            sql_update = "update set cost_insuritem"
                                + "NAME= " + "'" + result["name"] + "',"
                                + "spec=" + "'" + result["spec"] + "',"
                                + "dosageform=" + "'" + result["conf"] + "',"
                                + "unit=" + "'" + result["unit"] + "',"
                                //+"'" + result["price"] + "',"
                                + "everymoney=" + "'" + result["everyMoney"] + "',"
                                + "ratioihsp=" + "'" + result["ratio"] + "',"
                                //+"'" + result["adminLevel"] + "',"
                                //+"'" + result["isClinic"] + "',"
                                //+"'" + result["projectType"] + "',"
                                + "limituse=" + "'" + result["remark"] + "',"
                                + "pincode=" + "'" + result["inputPyCode"] + "',"
                                + "updateat=" + "'" + result["UPDATE_TIME"] + "',"
                                //+"'" + result["inputWbCode"] + "',"
                                + "limitprc=" + "'" + result["approveMaxPrice"] + "'"
                                + "where insurcode='" + result["insureId"] + "' and Insuritemtype='1'";

                        }
                        BllMain.Db.Update(sql_update);
                        result.Clear();
                    }
                 
                }
                catch (Exception ex)
                {
                    msg = "下载失败"+ex.ToString();
                    return false;
                }
            }
            catch (Exception ex)
            {
                msg = "下载失败:";//+ Base64.decodebase64(GetPageCodeBy500Error(url, "utf-8").Split(':')[1].Replace("\"", "").Replace("}", ""));
                return false;
            }
            msg = "下载完成！";
            return true;
        }
        //贵阳市农合目录下载
        public bool insurItemGYSNH(string lasttime, ref string msg)
        {
             Dictionary<string, string> result = new Dictionary<string, string>();
             WebClient webClient = new WebClient();
         
            string centerno = "520100";
            string url = GzsnhGlobal.Url + "updateLeechdom?userName=" + Base64.encodebase64(GzsnhGlobal.UserName) + "&userPwd=" + Base64.encodebase64(GzsnhGlobal.UserPwd) + "&centerNo=" + Base64.encodebase64(centerno) + "&LastTime=" + Base64.encodebase64(lasttime) + "&hospCode=" + Base64.encodebase64(GzsnhGlobal.HospCode) + "";
            try
            {
                string param = webClient.DownloadString(url);//.Split(':')[1].Replace("\"", "").Replace("}", "");
                try
                {
                    string[] info = param.Replace("},{", "@").Split('@');
                    //getdata.nhypzlxxdelete();
                    for (int i = 0; i < info.Length; i++)
                    {
                        string[] detial = info[i].Replace("[{", "").Replace("}]", "").Replace("\"", "").Split(',');
                        for (int j = 0; j < detial.Length; j++)
                        {
                            string[] data = detial[j].Split(':');
                            result.Add(data[0], Base64.decodebase64(data[1]).Replace("\'", "\\\'"));
                        }
                        //getdata.nhypzlxx(result); //his table nhypzlxm2
                        string sql2 = "select insurcode from cost_insuritem where insurcode='" + result["xmid"] + "' and Insuritemtype='2'";
                        DataTable dt2 = BllMain.Db.Select(sql2).Tables[0];
                        string sql_update = "";
                        if (dt2.Rows.Count == 0)
                        {
                            sql_update = " INSERT INTO cost_insuritem ("
                                    // + "insurcode, "//insureId
                                //+"classno,"
                                +"druggrade,"
                                   + "NAME,"// 名称 name
                                   + "spec,"// 规格 spec
                                   + "dosageform,"// 剂型  conf
                                   + "unit,"// 单位 unit
                                // +"price,"// 单价
                                 + "everymoney,"
                                   + "ratioihsp,"// 报销比例 ratio
                                //+"adminlevel,"//
                                // +"isclinic, "//门诊项目
                                //  +"projecttype,"
                                   + "limituse," //remark
                                   + "pincode,"// 拼音简码 inputpycode
                                   + "updateat,"// 更新时间updatetime
                                //+"inputwbcode,"//  
                                  + "limitprc, " //  + ","// 最高限价approvemaxprice
                                   + "limitminprc, " // +"approveminprice,"//  最低限价
                               //approvemaxpricecity, 市限价 
                                //+"approvemaxpricecounty,"// 县级限价
                                // +"approvemaxpricetown,"//  存限价
                                 +"insurcode,"//xmid,   医保码 
                                 + "drugfactory, "// manufacture,厂家   
                                //  +"content,"//  
                                  + "insurclass,"//admittype, 甲乙丙 
                                  + "Insuritemtype"
                               + ")    VALUES ("
                                //   + "'" + result["insureId"] + "',"
                                //+"'" + result["classNo"] + "',"
                                //+"'" + result["grade"] + "',"
                                   + "'" + result["name"] + "',"
                                   + "'" + result["spec"] + "',"
                                   + "'" + result["conf"] + "',"
                                   + "'" + result["unit"] + "',"
                                //+"'" + result["price"] + "',"
                                +"'" + result["everyMoney"] + "',"
                                   + "'" + result["ratio"] + "',"
                                //+"'" + result["adminLevel"] + "',"
                                //+"'" + result["isClinic"] + "',"
                                //+"'" + result["projectType"] + "',"
                                   + "'" + result["remark"] + "',"
                                   + "'" + result["inputPyCode"] + "',"
                                   + "'" + result["UPDATE_TIME"] + "',"
                                //+"'" + result["inputWbCode"] + "',"
                                 + "'" + result["approveMaxPrice"] + "',"
                                 +"'" + result["approveMinPrice"] + "',"
                               // +"'" + result["approveMaxPrice_city"] + "',"
                                //+"'" + result["approveMaxPrice_county"] + "',"
                                //+"'" + result["approveMaxPrice_town"] + "',"
                                +"'" + result["XMID"] + "',"
                              +"'" + result["manufacturer"] + "',"
                                //+"'" + result["content"] + "',"
                              +"'" + result["admitType"] + "',"
                                   + "'1'"
                                   + ") ";
                        }
                        else
                        {

                            sql_update = "update set cost_insuritem"
                                + "NAME= " + "'" + result["name"] + "',"
                                + "spec=" + "'" + result["spec"] + "',"
                                 + "dosageform=" + "'" + result["conf"] + "',"
                                  + "unit=" + "'" + result["unit"] + "',"
                                //+"'" + result["price"] + "',"
                                //+"'" + result["everyMoney"] + "',"
                                 + "ratioihsp=" + "'" + result["ratio"] + "',"
                                //+"'" + result["adminLevel"] + "',"
                                //+"'" + result["isClinic"] + "',"
                                //+"'" + result["projectType"] + "',"
                                + "limituse=" + "'" + result["remark"] + "',"
                                 + "pincode=" + "'" + result["inputPyCode"] + "',"
                                 + "updateat=" + "'" + result["UPDATE_TIME"] + "',"
                                //+"'" + result["inputWbCode"] + "',"
                                  + "limitprc=" + "'" + result["approveMaxPrice"] + "'"
                                    + "limitminprc=" + "'" + result["approveMinPrice"] + "'"
                                 + "drugfactory=" + "'" + result["manufacturer"] + "',"
                                //+"'" + result["content"] + "',"
                                 + "insurclass=" + "'" + result["admitType"] + "'"
                                + " where insurcode='" + result["XMID"] + "' and Insuritemtype='1'";

                        }
                        BllMain.Db.Update(sql_update);

                       result.Clear();
                    }
                  
                }
                catch (Exception ex)
                {
                    msg ="下载失败"+ex.ToString();
                    return false;
                }
            }
            catch (Exception ex)
            {
                msg = "下载网路失败";
                return false;
            }
            msg = "下载完成";
            return true;
    }
        public String GetPageCodeBy500Error(String PageURL, String Charset)
        {
            String strHtml = "";
            HttpWebRequest wreq = null;
            try { wreq = (HttpWebRequest)WebRequest.Create(PageURL); }
            catch ( Exception ex)
            {
                return "";
            }
            try{
                //连接到目标网页                  
              
                wreq.Method = "GET";
                wreq.Timeout = 20000;
                wreq.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1)  .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022)";
                HttpWebResponse wresp = (HttpWebResponse)wreq.GetResponse();
                //采用流读取，并确定编码方式                  
                Stream s = wresp.GetResponseStream();
                StreamReader objReader = new StreamReader(s, System.Text.Encoding.GetEncoding(Charset));
                string strLine = "";
                //读取                  
                while (strLine != null)
                {
                    strLine = objReader.ReadLine();
                    if (strLine != null)
                    {
                        strHtml += strLine.Trim();
                    }
                }
                return strHtml;
            }
            catch (WebException ex)
            {
                HttpWebResponse res = ex.Response as HttpWebResponse;
                if (res.StatusCode == HttpStatusCode.InternalServerError)
                {
                    Stream s = res.GetResponseStream();
                    StreamReader objReader = new StreamReader(s, System.Text.Encoding.GetEncoding(Charset));
                    string strLine = "";
                    //读取                      
                    while (strLine != null)
                    {
                        strLine = objReader.ReadLine();
                        if (strLine != null)
                        {
                            strHtml += strLine.Trim();
                        }
                    } return strHtml;
                }
                else { strHtml = ex.Message; }
                return strHtml;
            }
        }
    }
}

