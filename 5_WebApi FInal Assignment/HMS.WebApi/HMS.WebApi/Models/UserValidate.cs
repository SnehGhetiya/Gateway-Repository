using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMS.WebApi.Models
{
    public class UserValidate
    {
        public static bool Login(string Username, string Password)
        {
            UserBL _user = new UserBL();
            var userList = _user.GetUsers();
            return userList.Any(user =>
            user.Username.Equals(Username, StringComparison.OrdinalIgnoreCase)
            && user.Password == Password);
        }
    }
}