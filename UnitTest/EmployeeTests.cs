using EmpFile.DAL;
using EmpFile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpFile.UnitTest
{
    public class EmployeeTests
    {
        public Boolean CheckIDNo(string strID)
        {
            int[] id_12_digits = { 1, 2, 1, 2, 1, 2, 1, 2, 1 };
            int count = 0;

            if (strID == null)
                return false;

            strID = strID.PadLeft(9, '0');

            for (int i = 0; i < 9; i++)
            {
                int num = Int32.Parse(strID.Substring(i, 1)) * id_12_digits[i];

                if (num > 9)
                    num = (num / 10) + (num % 10);

                count += num;
            }

            return (count % 10 == 0);
        }

        //adding zeros to the pre short id
        public string AddZero(string id)
        {
            if (id.Length < 9)
            {
                string a = "";
                for (int i = 0; i < 9 - id.Length; i++)
                {
                    a += "0";
                }
                id = a + id;
            }
            return id;
        }
        
        //check if the id number exist in the employee table.
        public Boolean ChechIDS(string id)
        {
            EmployeeDal dal = new EmployeeDal();
            List<Employee> LE = (from x in dal.Employees                                
                                 where x.ID.ToString() == id
                                 select x).ToList<Employee>();
            if (LE.Count == 0)
            {
                return true;
            }
            return false;
        }
    }
}