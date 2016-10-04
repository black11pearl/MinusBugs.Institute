using MinusBugs.Institute.Web.FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinusBugs.Institute.Web.FrontEnd.Models.dbOperations
{
    public class StudentOperations
    {
        MinusBugsContext mbc;
        string Admno;
        public Student NewStudent(Student student)
        {
            try
            {
                mbc = new MinusBugsContext();
                mbc.StudentsData.Add(student);
             
                mbc.SaveChanges();
               
            }
            catch (Exception)
            {
                
                throw;
            }
            return student;

        }

        public List<Student> GetAllStudents()
        {
            mbc = new MinusBugsContext();
            List<Student> stdList = mbc.StudentsData.ToList();
            return stdList;

        }
        public Student GetStudent(int Admno)
        {
            mbc = new MinusBugsContext();
            Student student = mbc.StudentsData.Single(s => s.Admno == Admno);
            return student;

        }
    }
}