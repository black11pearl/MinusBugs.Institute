using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinusBugs.Institute.Web.FrontEnd.Models.dbOperations
{
    public class CourseOperations
    {
        MinusBugsContext mbc;

        public bool NewCourse(Courses course)
        {
            try
            {
                mbc = new MinusBugsContext();
                mbc.CourseData.Add(course);
                mbc.SaveChanges();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Courses> GetCourses()
        {
            mbc = new MinusBugsContext();
            List<Courses> courses = mbc.CourseData.ToList();
            return courses;

        }

        public Courses GetCourse(int id)
        {
            mbc = new MinusBugsContext();
            Courses course = mbc.CourseData.Single(c => c.CourseId == id);
            return course;

        }
       
    }
}