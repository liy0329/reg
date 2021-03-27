using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTREG.medinsur.ynsyb.bo
{
    class CostInsurcrossYNSYB
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string cost_insurtype_id;

        public string Cost_insurtype_id
        {
            get { return cost_insurtype_id; }
            set { cost_insurtype_id = value; }
        }
        private string itemfrom;

        public string Itemfrom
        {
            get { return itemfrom; }
            set { itemfrom = value; }
        }
        private string item_id;

        public string Item_id
        {
            get { return item_id; }
            set { item_id = value; }
        }
        private string drug_factyitem_id;

        public string Drug_factyitem_id
        {
            get { return drug_factyitem_id; }
            set { drug_factyitem_id = value; }
        }
        private string cost_insuritem_id;

        public string Cost_insuritem_id
        {
            get { return cost_insuritem_id; }
            set { cost_insuritem_id = value; }
        }
    }
}
