using BusniessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Practice.Controllers
{
    public class Employee_CrudController : Controller
    {
        // GET: Employee_Crud
        public ActionResult Index()
        {
            EmployeeBusinessLayer employeeBusinessLayer =
            new EmployeeBusinessLayer();

            List<Employee_Crud> employees = employeeBusinessLayer.Employees_Crud.ToList();
            return View(employees);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        /*
        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                foreach (string key in formCollection.AllKeys)
                {
                    Response.Write("Key = " + key + "  ");
                    Response.Write("Value = " + formCollection[key]);
                    Response.Write("<br/>");
                }
            }
            return View();
        }*/

        /*
        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            Employee_Crud employee = new Employee_Crud();
            // Retrieve form data using form collection
            employee.Name = formCollection["Name"];
            employee.Gender = formCollection["Gender"];
            employee.City = formCollection["City"];
            employee.DateOfBirth =
                Convert.ToDateTime(formCollection["DateOfBirth"]);

            EmployeeBusinessLayer employeeBusinessLayer =
                new EmployeeBusinessLayer();

            employeeBusinessLayer.AddEmmployee(employee);
            return RedirectToAction("Index");
        }*/

        /*
        [HttpPost]
        public ActionResult Create(string name, string gender, string city, DateTime dateOfBirth)
        {
            Employee_Crud employee = new Employee_Crud();
            employee.Name = name;
            employee.Gender = gender;
            employee.City = city;
            employee.DateOfBirth = dateOfBirth;

            EmployeeBusinessLayer employeeBusinessLayer =
                new EmployeeBusinessLayer();

            employeeBusinessLayer.AddEmmployee(employee);
            return RedirectToAction("Index");
        }*/

        /*
        [HttpPost]
        public ActionResult Create(Employee_Crud employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer employeeBusinessLayer =
                    new EmployeeBusinessLayer();

                employeeBusinessLayer.AddEmmployee(employee);
                return RedirectToAction("Index");
            }
            return View();
        }*/

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {

            EmployeeBusinessLayer employeeBusinessLayer =
                new EmployeeBusinessLayer();

            Employee_Crud employee = new Employee_Crud();
            TryUpdateModel<Employee_Crud>(employee);
            if (ModelState.IsValid)
            {
                employeeBusinessLayer.AddEmmployee(employee);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer =
                   new EmployeeBusinessLayer();
            Employee_Crud employee =
                   employeeBusinessLayer.Employees_Crud.Single(emp => emp.ID == id);

            return View(employee);
        }

        /*[HttpPost]
        public ActionResult Edit(Employee_Crud employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer employeeBusinessLayer =
                    new EmployeeBusinessLayer();
                employeeBusinessLayer.SaveEmployee(employee);

                return RedirectToAction("Index");
            }
            return View(employee);
        }*/

        /*
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer =
                   new EmployeeBusinessLayer();
            Employee_Crud employee =
                   employeeBusinessLayer.Employees_Crud.Single(emp => emp.ID == id);

            //include list
            //UpdateModel(employee, new string[] { "ID", "Gender", "City", "DateOfBirth" });
            //exclude list
            TryUpdateModel(employee, null, null, new string[] { "Name" });

            if (ModelState.IsValid)
            {
                employeeBusinessLayer.SaveEmployee(employee);

                return RedirectToAction("Index");
            }

            return View(employee);
        }*/
        /*
        [HttpPost]
        [ActionName("Edit")]
        //public ActionResult Edit_Post([Bind(Include = "Id, Gender, City, DateOfBirth")] Employee_Crud employee)
        public ActionResult Edit_Post([Bind(Exclude = "Name")] Employee_Crud employee)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            employee.Name = employeeBusinessLayer.Employees_Crud.Single(x => x.ID == employee.ID).Name;

            if (ModelState.IsValid)
            {
                employeeBusinessLayer.SaveEmployee(employee);

                return RedirectToAction("Index");
            }

            return View(employee);
        }*/

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            Employee_Crud employee = employeeBusinessLayer.Employees_Crud.Single(x => x.ID == id);
            UpdateModel<IEmployee_Crud>(employee);

            if (ModelState.IsValid)
            {
                employeeBusinessLayer.SaveEmployee(employee);
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        //Deleting database records using POST request
        //Always use post request
        [HttpPost]
        public ActionResult Delete(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer =
                new EmployeeBusinessLayer();
            employeeBusinessLayer.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}