using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_DAL.Entities
{
    public class User
    {
        public string UserName { get; set; }
        public string Roles { get; set; }
        public string Password { get; set; }
    }
}
