using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.sjzsyb.bll
{
    class Sjzsyb_IN
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Request_head()
        {
            string head = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            head += "<HOSDATA>";
            head += "<REQUESTDATA>";
            return head;
        }
        public string Request_foot()
        {
            string foot = "</REQUESTDATA>";
            foot += "</HOSDATA>";
            return foot;
        }

        private string yw;
        /// <summary>
        /// 业务
        /// </summary>
        public string Yw
        {
            get { return yw; }
            set { yw = value; }
        }

        private string ylzh;
        /// <summary>
        /// 医疗证号
        /// </summary>
        public string Ylzh
        {
            get { return ylzh; }
            set { ylzh = value; }
        }
        private string hisjl;
        /// <summary>
        /// 住院号
        /// </summary>
        public string Hisjl
        {
            get { return hisjl; }
            set { hisjl = value; }
        }
        private string rc;
        /// <summary>
        /// 入参
        /// </summary>
        public string Rc
        {
            get { return rc; }
            set { rc = value; }
        }
        private string cc;
        /// <summary>
        /// 出参
        /// </summary>
        public string Cc
        {
            get { return cc; }
            set { cc = value; }
        }
        private string ywmc;
        /// <summary>
        /// 业务名称
        /// </summary>
        public string Ywmc
        {
            get { return ywmc; }
            set { ywmc = value; }
        }
        private string ywccyb;

        public string Ywccyb
        {
            get { return ywccyb; }
            set { ywccyb = value; }
        }
        private string ywccjm;

        public string Ywccjm
        {
            get { return ywccjm; }
            set { ywccjm = value; }
        }
        private string mesg;

        public string Mesg
        {
            get { return mesg; }
            set { mesg = value; }
        }
    }
}
