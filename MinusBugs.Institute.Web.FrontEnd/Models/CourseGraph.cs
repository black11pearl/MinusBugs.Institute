﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MinusBugs.Institute.Web.FrontEnd.Models
{
    [Table("CourseGraph")]
    public class CourseGraph
    {
        [Key]
        public int CourseGraphId { get; set; }
        public string CourseType { get; set; }
        public int  January { get; set; }
        public int February { get; set; }

        public int March { get; set; }
        public int  April { get; set; }
        public int May { get; set; }
        public int June { get; set; }
        public int July { get; set; }
        public int August { get; set; }
        public int September { get; set; }
        public int October { get; set; }
        public int November { get; set; }
        public int December { get; set; }
        public int Year { get; set; }
    }
}