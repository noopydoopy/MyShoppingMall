using MyShoppingMall.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShoppingMall.Web.Services
{
    public class UserService : IUserService
    {
        public IDictionary<string, (string PasswordHash, User User)> users = new Dictionary<string, (string PasswordHash, User User)>();

        public UserService(string username, string password)
        {
            users.Add(username.ToLower(), (BCrypt.Net.BCrypt.HashPassword(password), new User(username)));
        }
        public bool AddUser(string username, string password)
        {
            if (!users.ContainsKey(username.ToLower()))
            {
                users.Add(username, (BCrypt.Net.BCrypt.HashPassword(password), new User(username)));
                return true;
            }
            return false;
        }

        public bool ValidateCredentials(string username, string password, out User user)
        {
            user = null;
            string key = username.ToLower();

            if (users.ContainsKey(key))
            {
                string hashKey = users[key].PasswordHash;
                if(BCrypt.Net.BCrypt.Verify(password, hashKey))
                {
                    user = users[key].User;
                    return true;
                }
            }
            return false;
        }
    }
}
