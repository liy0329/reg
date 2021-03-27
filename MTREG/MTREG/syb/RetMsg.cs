/*************************************************************************************
    * CLR版本：       2.0.50727.4984
    * 类 名 称：       RetMsg
    * 机器名称：       DELL-PC
    * 命名空间：       WindowsFormsApplication1.common
    * 文 件 名：       RetMsg
    * 创建时间：       2013/6/7 16:28:06
    * 作    者：          xxx
    * 说   明：。。。。。
    * 修改时间：
    * 修 改 人：
   *************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.common
{
    class RetMsg
    {
        private string mesg;

        public string Mesg
        {
            get { return mesg; }
            set { mesg = value; }
        }

        private bool retint;

        public bool Retint
        {
            get { return retint; }
            set { retint = value; }
        }
    }
}
