using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using WebService.Model;

namespace WebService.Model
{
    [Serializable]
    [DataContract]
    public partial class st_stockproductEx : st_stockproduct
    {
         [DataMember(IsRequired = false)]
        public decimal smallsumprice
        {
            get;
            set;
        }
         [DataMember(IsRequired = false)]
        public string ProductCode
        {
            get;
            set;
        }
        [DataMember(IsRequired = false)]
        public string ProductName
        {
            get;
            set;
        }
    }
}
