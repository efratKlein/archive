using EmpFile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpFile.ViewModel
{
    public class EmployeeVM
    {
        public Employee Emp { get; set; }
        public List<Employee> Employees { get; set; }
    }
}