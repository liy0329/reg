using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace mtcalling.tools
{
    class Decode
    {
        public string ProductDetails { get; set; }
        public Dictionary<string, string> ProductDetailList
        {
            get
            {
                if (string.IsNullOrEmpty(ProductDetails))
                {
                    return new Dictionary<string, string>();
                }
                try
                {
                    var obj = JToken.Parse(ProductDetails);
                }
                catch (Exception)
                {
                   
                    throw new FormatException("ProductDetails不符合json格式.");
                }
                return JsonConvert.DeserializeObject<Dictionary<string, string>>(ProductDetails);
            }
        }
    }
}
