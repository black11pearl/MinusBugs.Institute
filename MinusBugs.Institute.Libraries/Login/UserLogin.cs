using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinusBugs.Institute.Libraries.Login
{
    class UserLoginData
    {
        public string username { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
        public DateTime LastLogin { get; set; }
        public bool LoginEnabled { get; set; }

        public UserLoginData getUserDetails()
        {

            return null;
        }

    }

}
