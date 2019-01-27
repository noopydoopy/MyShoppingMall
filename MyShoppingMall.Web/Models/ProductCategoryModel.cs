using JsonDatabaseConnector.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MyShoppingMall.Web.Models
{
    [DataContract]
    public class ProductCategoryModel : EntityBase
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}
