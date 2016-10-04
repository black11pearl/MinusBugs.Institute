using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinusBugs.Institute.Web.FrontEnd.Models.dbOperations
{
    public class CourseGraphOperations
    {
        MinusBugsContext mbc;
        public List<CourseGraph> GetGraph()
        {
            mbc = new MinusBugsContext();
            List<CourseGraph> coursegraphlist = mbc.CourseGraphData.ToList();
            return coursegraphlist;

        }
    }
}