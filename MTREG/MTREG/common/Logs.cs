/*************************************************************************************
     * CLR版本：        2.0.50727.4927
     * 类 名 称：       Logs
     * 机器名称：       TIANCI
     * 命名空间：       MTLIS.common
     * 文 件 名：       Logs
     * 创建时间：       2013/5/13 14:43:37
     * 作    者：       杨天赐
     * 说   明：        日志类
     * 修改时间：        
     * 修 改 人：        
*************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTHIS.common
{
   public class Logs
    {
        private DateTime dataTime;//日期

        public DateTime DataTime
        {
            get { return dataTime; }
            set { dataTime = value; }
        }
        private string grade;//等级

        public string Grade
        {
            get { return grade; }
            set { grade = value; }
        }
        private string url;//位置

        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        private string msg;//信息

        public string Msg
        {
            get { return msg; }
            set { msg = value; }
        }


       public string RetMsg
       {
           get { return this.DataTime + " " + this.Grade + " " + this.Url + " " + this.Msg; }
       }
     
    }
}
