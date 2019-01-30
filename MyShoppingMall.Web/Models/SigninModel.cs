using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShoppingMall.Web.Models
{
    public class SigninModel
    {
        [Required(ErrorMessage = "Username is requesired")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is requesired")]
        public string Password { get; set; }
    }
}
