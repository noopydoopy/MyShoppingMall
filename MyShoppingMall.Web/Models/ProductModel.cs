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
    public class ProductModel : EntityBase
    {
        [DataMember]
        [Required(ErrorMessage = "Product name is required")]
        public string ProductName { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int Amount { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public string PicUrl { get; set; }
        [DataMember]
        [RegularExpression(@"^[1-9][0-9]*$", ErrorMessage = "Product category is required")]
        public int CategoryId { get; set; }
    }
}
