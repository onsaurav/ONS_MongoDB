using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ONS_MongoDB.Models
{
    public class Student
    {
        public object _id { get; set; }
        public string Name { get; set; }
        public int RollNo { get; set; }
        public string Address { get; set; }
    }
}