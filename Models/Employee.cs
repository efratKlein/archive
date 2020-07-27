using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpFile.Models
{
    public class Employee
    {    
        public int Office { get; set; } //this is for test
        public int Department { get; set; }
        public int Unit { get; set; }
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Street { get; set; }
        public int HousNum { get; set; }
        public string City { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public string FileNum { get; set; }
        public string Note { get; set; }
    }
}