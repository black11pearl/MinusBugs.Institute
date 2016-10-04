using MinusBugs.Institute.Web.FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinusBugs.Institute.Web.FrontEnd.Models.dbOperations
{
    public class StaffDb
    {
        MinusBugsContext mbc;
        
        public bool NewStaff(Staff staff)
        {
            try
            {
                mbc = new MinusBugsContext();
                mbc.StaffData.Add(staff);
                mbc.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return true;
        }

        public List<Staff> GetAllStaff()
        {
            mbc = new MinusBugsContext();
            List<Staff> stafflist = mbc.StaffData.ToList();

            return stafflist;

        }

        public Staff GetStaff(int staffid)
        {
            mbc = new MinusBugsContext();
            Staff staff = mbc.StaffData.Single(s => s.StaffId == staffid);

            return staff;
            
        }
    }
}