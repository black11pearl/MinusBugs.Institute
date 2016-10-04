﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MinusBugs.Institute.Web.FrontEnd.Models
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }
        public string Name { get; set; }
    }
}