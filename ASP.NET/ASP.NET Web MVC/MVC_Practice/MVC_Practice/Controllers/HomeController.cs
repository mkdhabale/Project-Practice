using MVC_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Practice.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        /* public ActionResult Index()
         {
             return View();
         }*/

        public string Index()
        {
            return "MVC Practice from Index";
        }
        public string GetDetails(string id, string name)
        {
            return "MVC Practice from GetDetails id:" + id + ", name: " + name;
        }

        public ActionResult GetDetailsInView()
        {
            // Store the list of Countries in ViewBag.  
            ViewBag.Countries = new List<string>()
            {
                "India",
                "US",
                "UK",
                "Canada"
            };
            return View();
        }

        public ActionResult GetEmployeeDetailsInView()
        {
            Employee employee = new Employee()
            {
                EmployeeId = 101,
                Name = "John",
                Gender = "Male",
                City = "London"
            };

            return View(employee);
        }

        public ActionResult GetEmployeeDetailsByID(int id)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee employee = employeeContext.Employees.Single(x => x.EmployeeId == id);

            return View(employee);
        }

        public ActionResult EmployeeNameList()
        {
            EmployeeContext employeeContext = new EmployeeContext();
            List<Employee> employees = employeeContext.Employees.ToList();

            return View(employees);
        }
    }
}