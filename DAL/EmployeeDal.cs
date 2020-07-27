using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EmpFile.Models;

namespace EmpFile.DAL
{
    public class EmployeeDal:DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().ToTable("tblEmp");
        }
        public DbSet<Employee> Employees { get; set; }

    }
}