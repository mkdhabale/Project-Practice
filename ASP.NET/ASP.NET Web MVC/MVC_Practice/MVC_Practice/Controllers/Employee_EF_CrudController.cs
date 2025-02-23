﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Practice.Models;

namespace MVC_Practice.Controllers
{
    public class Employee_EF_CrudController : Controller
    {
        private Employee_EF_DBContext db = new Employee_EF_DBContext();

        // GET: Employee_EF_Crud
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Department);
            return View(employees.ToList());
        }
        public ActionResult EmployeesByDepartment()
        {
            var departmentTotals = db.Employees.Include("Department")
                                        .GroupBy(x => x.Department.Name)
                                        .Select(y => new DepartmentTotals
                                        {
                                            Name = y.Key,
                                            Total = y.Count()
                                        }).ToList().OrderByDescending(y => y.Total);
            return View(departmentTotals);
        }

        // GET: Employee_EF_Crud/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employee_EF_Crud/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");
            return View();
        }

        // POST: Employee_EF_Crud/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,Name,Gender,City,DepartmentId")] Employee employee)
        {
            if (string.IsNullOrEmpty(employee.Name))
            {
                ModelState.AddModelError("Name", "The Name field is required.");
            }
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employee_EF_Crud/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        // POST: Employee_EF_Crud/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,Gender,City,DepartmentId")] Employee employee)
        {
            Employee employeeFromDB = db.Employees.Single(x => x.EmployeeId == employee.EmployeeId);
            
            employeeFromDB.EmployeeId = employee.EmployeeId;
            employeeFromDB.Gender = employee.Gender;
            employeeFromDB.City = employee.City;
            employeeFromDB.DepartmentId = employee.DepartmentId;
            employee.Name = employeeFromDB.Name;
            if (ModelState.IsValid)
            {
                db.Entry(employeeFromDB).State = EntityState.Modified;
                //db.ObjectStateManager.ChangeObjectState(employeeFromDB, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", employee.DepartmentId);
            return View(employee);
        }

        // GET: Employee_EF_Crud/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee_EF_Crud/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
