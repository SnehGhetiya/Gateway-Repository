using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMS.WebApi.Models
{
    public class UserBL
    {
        public List<User> GetUsers()
        {
            List<User> userList = new List<User>();

            userList.Add(new User()
            {
                ID = 1,
                Username = "Admin",
                Password = "123456"
            });
            return userList;
        }
    }
}