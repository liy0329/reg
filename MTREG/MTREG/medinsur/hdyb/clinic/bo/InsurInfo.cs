using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.hdyb.clinic.bo
{
    public class InsurInfo
    {
            string patientType;//患者类型
            string balance;//账户余额
            string companyname;//公司名称
            string companynum;//公司编码
            string iccardid;//IC卡号
            string idcard;//身份证号
            string isblock;//封锁状态
            string name;//姓名
            string personalNum;//个人编码
            string sex;//性别
            string birth;//生日
            string insurefee;//统筹支付
            string selffee;//账户支付
            string approveType;//审批类别
            string approvenum;//审批病种编码
            string ihsptype;//医疗类别
            string ihspdiagn;//住院诊断
            string clinicicd;//门诊疾病编码
            string cliniciname;//门诊疾病名称
            string clinicdiagn;//门诊诊断
            string msg;
            private string _qh;

            public string Qh
            {
                get { return _qh; }
                set { _qh = value; }
            }
            string _sfck;//是否持卡

            public string Sfck
            {
                get { return _sfck; }
                set { _sfck = value; }
            }

            string yllb;//医疗类别

            public string Yllb
            {
                get { return yllb; }
                set { yllb = value; }
            }
            public string Msg
            {
                get { return msg; }
                set { msg = value; }
            }
            /// <summary>
            /// 门诊疾病名称
            /// </summary>
            public string Cliniciname
            {
                get { return cliniciname; }
                set { cliniciname = value; }
            }
            /// <summary>
            /// 门诊疾病编码
            /// </summary>
            public string Clinicicd
            {
                get { return clinicicd; }
                set { clinicicd = value; }
            }
            

            /// <summary>
            /// 医疗类别
            /// </summary>
            public string Ihsptype
            {
                get { return ihsptype; }
                set { ihsptype = value; }
            }
            /// <summary>
            /// 审批类别
            /// </summary>
            public string ApproveType
            {
                get { return approveType; }
                set { approveType = value; }
            }
            /// <summary>
            /// 审批病种编码
            /// </summary>
            public string Approvenum
            {
                get { return approvenum; }
                set { approvenum = value; }
            }
            /// <summary>
            /// 住院诊断
            /// </summary>
            public string Ihspdiagn
            {
                get { return ihspdiagn; }
                set { ihspdiagn = value; }
            }       
                      
            /// <summary>
            /// 门诊诊断
            /// </summary>
            public string Clinicdiagn
            {
                get { return clinicdiagn; }
                set { clinicdiagn = value; }
            }
            /// <summary>
            /// 统筹支付
            /// </summary>
            public string Insurfee
            {
                get { return insurefee; }
                set { insurefee = value; }
            }
            
           /// <summary>
           /// 账户支付
           /// </summary>
            public string Selffee
            {
                get { return selffee; }
                set { selffee = value; }
            }
           /// <summary>
           /// 出生日期
           /// </summary>
            public string Birth
            {
                get { return birth; }
                set { birth = value; }
            }
             /// <summary>
             /// 患者类型
             /// </summary>
            public string PatientType
            {
                get { return patientType;}
                set { patientType = value;}
            }
            /// <summary>
            /// 账户余额
            /// </summary>
            public string Balance
            {
                get { return balance; }
                set { balance = value; }
            }
            /// <summary>
           /// 单位名称
           /// </summary>
            public string Companyname
            {
                get { return companyname; }
                set { companyname = value; }
            }
           /// <summary>
           /// 单位编号
           /// </summary>
            public string Companynum
            {
                get { return companynum; }
                set { companynum = value; }
            }
           /// <summary>
           /// IC卡号
           /// </summary>
            public string Iccardid
            {
                get { return iccardid; }
                set { iccardid = value; }
            }
           /// <summary>
           /// 身份证号
           /// </summary>
            public string Idcard
            {
                get { return idcard; }
                set { idcard = value; }
            }
           /// <summary>
          /// 封锁情况
           /// </summary>
            public string Isblock
            {
                get { return isblock; }
                set { isblock = value; }
            }
           /// <summary>
           /// 姓名
           /// </summary>
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
           /// <summary>
           /// 个人编号
           /// </summary>
            public string PersonalNum
            {
                get { return personalNum; }
                set { personalNum = value; }
            }
           /// <summary>
           /// 性别
           /// </summary>
            public string Sex
            {
                get { return sex; }
                set { sex = value; } 
            }




    }
}
