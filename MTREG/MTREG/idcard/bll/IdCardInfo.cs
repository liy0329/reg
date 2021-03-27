using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.idcard.bll
{
    class IdCardInfo
    {
            string homeaddress;
            string race;
            string idcard;
            string name;
            string sex;
            string birth;
        /// <summary>
        /// 出生日期
        /// </summary>
            public string Birth
            {
                get { return birth; }
                set { birth = value; }
            }
             /// <summary>
             /// 住址
             /// </summary>
            public string Homeaddress
            {
                get { return homeaddress; }
                set { homeaddress = value; }
            }

            /// <summary>
           /// 民族
           /// </summary>
            public string Race
            {
                get { return race; }
                set { race = value; }
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
        /// 姓名
        /// </summary>
            public string Name
            {
                get { return name; }
                set { name = value; }
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

                idcard = "130415199811202455";
                race = "han";
                name = "qwe";
                homeaddress = "qwe";
                sex = "q";
                birth = "2010-11-12 00:00:00";
            }
        }
    }

