using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MinusBugs.Institute.Web.FrontEnd.Models;
namespace MinusBugs.Institute.Web.FrontEnd.Models.dbOperations
{
    public class UserLogin
    {
        public MinusBugsLogin checklogin(string username,string password)
        {
            MinusBugsContext mbc = new MinusBugsContext();
            MinusBugsLogin mbl = mbc.Login.Single(m => m.username == username && m.Password == password);

            return mbl;
        }
    }
}