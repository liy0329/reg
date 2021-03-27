using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.common
{
    class CardMsgs
    {
        private string name; //名称
        private string sex;// 性别
        private string nation;//民族
        private string born;//出生日期
        private string address;//地址
        private string idCarNo;//身份证号
        private string message;//错误消息
        private string message1;//读卡器信息
        private int nPort;//端口号
        public int NPort
        {
            get { return nPort; }
            set { nPort = value; }
        }
        public string Message1
        {
            get { return message1; }
            set { message1 = value; }
        }
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        public string Nation
        {
            get { return nation; }
            set { nation = value; }
        }
        public string Born
        {
            get { return born; }
            set { born = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string IdCarNo
        {
            get { return idCarNo; }
            set { idCarNo = value; }
        }
    }
}
