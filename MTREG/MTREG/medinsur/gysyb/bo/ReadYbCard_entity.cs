using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gysyb.bo
{
    public class ReadYbCard_entity
    {
        public String iReaderhandle;//返回句柄
        public String iERRInfo;//当处理失败时的中文错误提示，处理成功时该处为NULL 
        String pSAMkh;//处理成功时返回PSAM卡编号
        public String szPasswd;//得到用户输入的密码
        public String cardId;//社保卡号
        public String icd_Id;//身份证号
        private String carType;//卡类型
        private String zdIp;//终端Ip
        /// <summary>
        /// //返回句柄
        /// </summary>
        public String IReaderhandle
        {
            get { return iReaderhandle; }
            set { iReaderhandle = value; }
        }
        
        /// <summary>
        /// //当处理失败时的中文错误提示，处理成功时该处为NULL 
        /// </summary>
        public String IERRInfo
        {
            get { return iERRInfo; }
            set { iERRInfo = value; }
        }
        
        /// <summary>
        /// //处理成功时返回PSAM卡编号
        /// </summary>
        public String PSAMkh
        {
            get { return pSAMkh; }
            set { pSAMkh = value; }
        }

        
        /// <summary>
        /// //得到用户输入的密码
        /// </summary>
        public String SzPasswd
        {
            get { return szPasswd; }
            set { szPasswd = value; }
        }
        
        /// <summary>
        /// 社保卡号
        /// </summary>
        public String CardId
        {
            get { return cardId; }
            set { cardId = value; }
        }
        
        /// <summary>
        /// //身份证号
        /// </summary>
        public String Icd_Id
        {
            get { return icd_Id; }
            set { icd_Id = value; }
        }
        
        /// <summary>
        /// //卡类型
        /// </summary>
        public String CarType
        {
            get { return carType; }
            set { carType = value; }
        }
        
        /// <summary>
        /// //终端Ip
        /// </summary>
        public String ZdIp
        {
            get { return zdIp; }
            set { zdIp = value; }
        }
    }
}
