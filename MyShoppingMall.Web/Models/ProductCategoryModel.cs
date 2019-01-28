using JsonDatabaseConnector.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MyShoppingMall.Web.Models
{
    [DataContract]
    public class ProductCategoryModel : EntityBase
    {
        [Required(ErrorMessage = "Product name is required")]
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}
