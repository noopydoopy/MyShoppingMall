using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShoppingMall.Web.Services.Interfaces
{
    public interface IUserService
    {
        bool ValidateCredentials(string username, string password, out User user);
        bool AddUser(string username, string password);
    }

    public class User
    {
        public User(string userName)
        {
            this.UserName = userName;
        }
        public string UserName { get; set; }
    }
}
