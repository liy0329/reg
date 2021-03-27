
using MTREG.medinsur.bo;
namespace MTREG.medinsur.bll
{
    class InsurInfo
    {
            string patientType;
            string balance;
            string companyname;
            string companynum;
            string iccardid;
            string idcard;
            string isblock;
            string name;
            string personalNum;
            string sex;
            string birth;
            string insurefee;
            string ihspicd;
            string insuraccountFee;
            string approvenum;
            string ihsptype;
            string maker;
            string OPStype;
            string fetusNum;
            string useCard;
            /// <summary>
            /// 是否用卡
            /// </summary>
            public string UseCard
            {
                get { return useCard; }
                set { useCard = value; }
            }
            
            /// <summary>
            /// 胎儿数
            /// </summary>
            public string FetusNum
            {
                get { return fetusNum; }
                set { fetusNum = value; }
            }
            /// <summary>
            /// 生育手术类别
            /// </summary>
            public string OPStype1
            {
                get { return OPStype; }
                set { OPStype = value; }
            }
        /// <summary>
        /// 经办人
        /// </summary>
            public string Maker
            {
                get { return maker; }
                set { maker = value; }
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
        /// 审批编码
        /// </summary>
            public string Approvenum
            {
                get { return approvenum; }
                set { approvenum = value; }
            }
        /// <summary>
        /// 账户支付
        /// </summary>
            public string InsuraccountFee
            {
                get { return insuraccountFee; }
                set { insuraccountFee = value; }
            }
             /// <summary>
            /// 住院诊断编码
            /// </summary>
            public string Ihspicd
            {
                get { return ihspicd; }
                set { ihspicd = value; }
            }
            string ihspdiagn;
            /// <summary>
            /// 住院诊断
            /// </summary>
            public string Ihspdiagn
            {
                get { return ihspdiagn; }
                set { ihspdiagn = value; }
            }
            string clinicicd;
            /// <summary>
            /// 门诊疾病编码
            /// </summary>
            public string Clinicicd
            {
                get { return clinicicd; }
                set { clinicicd = value; }
            }
            string clinicdiagn;
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
            string selffee;
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
            public void readInsurCard()
        {
            patientType = "qwe";
            balance = "12";
            companyname="qwe";
            companynum="qwe";
            iccardid = "123";
            idcard = "123";
            isblock = "qe";
            name = "qwe";
            personalNum = "qwe";
            sex = "q";
            birth = "2001-01-02 00:00:00";
        }

         public void preClinicAccount()
            {
                patientType = "qwe";
                balance = "12";
                companyname = "qwe";
                companynum = "qwe";
                iccardid = "123";
                idcard = "123";
                isblock = "qe";
                name = "qwe";
                personalNum = "qwe";
                sex = "q";
                birth = "2001-01-02 00:00:00";
                insurefee = "2.23";
                selffee = "1.21";
            }
         
                   
         public void preRegInHsp()
         {
             patientType = "qwe";
             balance = "12";
             companyname = "qwe";
             companynum = "qwe";
             iccardid = "123";
             idcard = "123";
             isblock = "qe";
             name = "qwe";
             personalNum = "qwe";
             sex = "q";
             birth = "2001-01-02 00:00:00";
             Ihspdiagn="qwe";
             ihspicd="qwe";
             clinicicd="qwe";
             clinicdiagn = "qwe";
         }

         public int regInHsp(InHspData inHspData)
         {
             int num = 0;
             return num;
         }

        public void preOutAccountHsp()
         {
             balance = "12";
             companyname = "qwe";
             personalNum = "qwe";
             Isblock = "true";
             insurefee="100";
             selffee="100";
         }

          public int OutAccountHsp(string ihspcode)
         {
             int num = 0;
             return num;
         }

        }
    }

