using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Practice.Models;
namespace MVC_Practice.Controllers
{
    public class Employee_DController : Controller
    {
        private Employee_CRUD_SDBContext db = new Employee_CRUD_SDBContext();

        // GET: Employee_D
        public ActionResult Index()
        {
            return View(db.Employee_Crud.ToList());
        }

        [HttpPost]
        public ActionResult Delete(IEnumerable<int> employeeIdsToDelete)
        {
            db.Employee_Crud.Where(x => employeeIdsToDelete.Contains(x.ID)).ToList().ForEach(y => db.Employee_Crud.Remove(y));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}