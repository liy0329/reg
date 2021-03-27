using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.gysyb.bo
{
    class Zyjs_rets
    {
        private string itemserial;//数据批号
        private string itemcode;//医保编码
        private string itemname;//项目名称
        private string hospprice;//医院单价
        private string price;//医保单价
        private string quantity;//数量
        private string selfrate;//自付比例
        private string specpayflag;//特殊报销项目标志
        private string bgitemtype;//包干结算项目类别
        private string returnfalg;//冲销标志
        private string mtzyjl_iid;
        public string Mtzyjl_iid
        {
            get { return mtzyjl_iid; }
            set { mtzyjl_iid = value; }
        }
        public string Itemserial
        {
            get { return itemserial; }
            set { itemserial = value; }
        }
        public string Itemcode
        {
            get { return itemcode; }
            set { itemcode = value; }
        }
        public string Itemname
        {
            get { return itemname; }
            set { itemname = value; }
        }
        public string Hospprice
        {
            get { return hospprice; }
            set { hospprice = value; }
        }
        public string Price
        {
            get { return price; }
            set { price = value; }
        }
        public string Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public string Selfrate
        {
            get { return selfrate; }
            set { selfrate = value; }
        }
        public string Specpayflag
        {
            get { return specpayflag; }
            set { specpayflag = value; }
        }
        public string Bgitemtype
        {
            get { return bgitemtype; }
            set { bgitemtype = value; }
        }
        public string Returnfalg
        {
            get { return returnfalg; }
            set { returnfalg = value; }
        }
    }
}
