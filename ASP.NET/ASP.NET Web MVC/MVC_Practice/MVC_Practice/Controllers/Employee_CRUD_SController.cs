using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Practice.Models;
using PagedList.Mvc;
using PagedList;

namespace MVC_Practice.Controllers
{
    public class Employee_CRUD_SController : Controller
    {
        private Employee_CRUD_SDBContext db = new Employee_CRUD_SDBContext();
        /*
        // GET: Employee_CRUD_S
        public async Task<ActionResult> Index(string searchBy, string search, int? page)
        {
            //return View(await db.Employee_Crud.ToListAsync());
            if (searchBy == "Gender")
            {
                return View(await db.Employee_Crud.Where(x => x.Gender == search || search == null).ToList().ToPagedList(page ?? 1, 3));
            }
            else
            {
                return View(await db.Employee_Crud.Where(x => x.Name.StartsWith(search) || search == null).ToListAsync().ToPagedList(page ?? 1, 3));
            }
        }*/
        public ActionResult Index(string searchBy, string search, int? page, string sortBy)
        {
            ViewBag.NameSort = String.IsNullOrEmpty(sortBy) ? "Name desc" : "";
            ViewBag.GenderSort = sortBy == "Gender" ? "Gender desc" : "Gender";

            var employees = db.Employee_Crud.AsQueryable();
            if (searchBy == "Gender")
            {
                employees = db.Employee_Crud.Where(x => x.Gender == search || search == null);
            }
            else
            {
                employees = db.Employee_Crud.Where(x => x.Name.StartsWith(search) || search == null);
            }
            switch (sortBy)
            {
                case "Name desc":
                    employees = employees.OrderByDescending(x => x.Name);
                    break;
                case "Gender desc":
                    employees = employees.OrderByDescending(x => x.Gender);
                    break;
                case "Gender":
                    employees = employees.OrderBy(x => x.Gender);
                    break;
                default:
                    employees = employees.OrderBy(x => x.Name);
                    break;
            }
            return View(employees.ToPagedList(page ?? 1, 3));
        }

        // GET: Employee_CRUD_S/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_Crud employee_Crud = await db.Employee_Crud.FindAsync(id);
            if (employee_Crud == null)
            {
                return HttpNotFound();
            }
            return View(employee_Crud);
        }

        // GET: Employee_CRUD_S/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee_CRUD_S/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Gender,Email")] Employee_Crud employee_Crud)
        {
            if (ModelState.IsValid)
            {
                db.Employee_Crud.Add(employee_Crud);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(employee_Crud);
        }

        // GET: Employee_CRUD_S/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_Crud employee_Crud = await db.Employee_Crud.FindAsync(id);
            if (employee_Crud == null)
            {
                return HttpNotFound();
            }
            return View(employee_Crud);
        }

        // POST: Employee_CRUD_S/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Gender,Email")] Employee_Crud employee_Crud)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee_Crud).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(employee_Crud);
        }

        // GET: Employee_CRUD_S/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_Crud employee_Crud = await db.Employee_Crud.FindAsync(id);
            if (employee_Crud == null)
            {
                return HttpNotFound();
            }
            return View(employee_Crud);
        }

        // POST: Employee_CRUD_S/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Employee_Crud employee_Crud = await db.Employee_Crud.FindAsync(id);
            db.Employee_Crud.Remove(employee_Crud);
            await db.SaveChangesAsync();
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
