using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS_DAL.Entities;

namespace PMS_Services
{
    public class AuthenticateService
    {
        static List<User> users = new List<User>() {

        new User() {UserName="admin",Roles="Admin,User",Password="admin123" },
        new User() {UserName="user",Roles="User",Password="user123" }
    };

        public  User GetUserDetails(User user)
        {
            return users.Where(u => u.UserName.ToLower() == user.UserName.ToLower() &&
            u.Password == user.Password).FirstOrDefault();
        }
    }
}
