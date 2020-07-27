using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmpFile.DAL;
using EmpFile.Models;
using EmpFile.UnitTest;
using EmpFile.ViewModel;

namespace EmpFile.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EmpPage()
        {
            EmployeeVM evm = new EmployeeVM();
            evm.Employees = new List<Employee>();
            return View(evm);

        }

        public ActionResult SearchFile()
        {
            EmployeeTests empT = new EmployeeTests();
            EmployeeDal dal = new EmployeeDal();
            Employee emp = new Employee();
            List<Employee> EL = new List<Employee>();
            string FName = Request.Form["FNameTXT"].ToString();
            string LName = Request.Form["LNameTXT"].ToString();
            string ID = Request.Form["IDTXT"].ToString();
            bool flag = false;
            if (empT.CheckIDNo(ID))
            {
                if (!empT.ChechIDS(ID))
                {
                    if (ID != null)
                    {
                        flag = true;//תשובה חח"ע
                        if (FName != null)
                        {
                            if (LName != null)
                            {
                                EL = (from X in dal.Employees
                                      where X.FirstName.Contains(FName) &&
                                      X.LastName.Contains(LName) &&
                                      X.ID.ToString() == ID
                                      select X).ToList<Employee>();
                            }
                            else
                            {
                                EL = (from X in dal.Employees
                                      where X.FirstName.Contains(FName) &&
                                      X.ID.ToString() == ID
                                      select X).ToList<Employee>();
                            }
                        }
                        else
                        {
                            if (LName != null)
                            {
                                EL = (from X in dal.Employees
                                      where X.LastName.Contains(LName) &&
                                      X.ID.ToString() == ID
                                      select X).ToList<Employee>();
                            }
                            else
                            {
                                EL = (from X in dal.Employees
                                      where X.ID.ToString() == ID
                                      select X).ToList<Employee>();
                            }
                        }
                    }
                    else
                    {
                        //תשובה רב ערכית
                        if (FName != null)
                        {
                            if (LName != null)
                            {
                                EL = (from X in dal.Employees
                                      where X.FirstName.Contains(FName) &&
                                      X.LastName.Contains(LName)
                                      select X).ToList<Employee>();
                            }
                            else
                            {
                                EL = (from X in dal.Employees
                                      where X.FirstName.Contains(FName)
                                      select X).ToList<Employee>();
                            }
                        }
                        else
                        {
                            if (LName != null)
                            {
                                EL = (from X in dal.Employees
                                      where X.LastName.Contains(LName)
                                      select X).ToList<Employee>();
                            }
                            else
                            {
                                EL = (from X in dal.Employees
                                      select X).ToList<Employee>();
                            }
                        }
                    }

                    if (flag == true && EL.Count > 1)
                    {
                        emp.Note = "There are few people with the same ID";
                        EL[0] = emp;
                    }
                }
                else
                {
                    emp.Note = "The ID number isn't exist";
                    EL[0] = emp;
                }
            }
            else
            {
                emp.Note = "The ID number isn't ligal";
                EL[0] = emp;
            }

            return Json(EL, JsonRequestBehavior.AllowGet);
        }   
        
        public ActionResult SearchEmplFileByJson()
        {
            return Json(EL, JsonRequestBehavior.AllowGet);

        }
    }
}