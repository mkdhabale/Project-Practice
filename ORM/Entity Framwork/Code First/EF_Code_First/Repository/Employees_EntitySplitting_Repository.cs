using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EF_Code_First.Model;
using EF_Code_First.EntityDBContext;

namespace EF_Code_First.Repository
{
    public class Employees_EntitySplitting_Repository
    {
        Employees_EntitySplitting_DBContext employeeDBContext = new Employees_EntitySplitting_DBContext();

        public List<Employees_EntitySplitting> GetEmployees()
        {
            return employeeDBContext.Employees_EntitySplitting.ToList();
        }

        public void InsertEmployee(Employees_EntitySplitting employee)
        {
            employeeDBContext.Employees_EntitySplitting.Add(employee);
            employeeDBContext.SaveChanges();
        }

        public void UpdateEmployee(Employees_EntitySplitting employee)
        {
            Employees_EntitySplitting employeeToUpdate = employeeDBContext.Employees_EntitySplitting
                .SingleOrDefault(x => x.EmployeeId == employee.EmployeeId);
            employeeToUpdate.EmployeeId = employee.EmployeeId;
            employeeToUpdate.FirstName = employee.FirstName;
            employeeToUpdate.Gender = employee.Gender;
            employeeToUpdate.Email = employee.Email;
            employeeToUpdate.Mobile = employee.Mobile;
            employeeToUpdate.Landline = employee.Landline;

            employeeDBContext.SaveChanges();
        }
        public void DeleteEmployee(Employees_EntitySplitting employee)
        {
            Employees_EntitySplitting employeeToDelete = employeeDBContext.Employees_EntitySplitting
                .SingleOrDefault(x => x.EmployeeId == employee.EmployeeId);
            employeeDBContext.Employees_EntitySplitting.Remove(employeeToDelete);
            employeeDBContext.SaveChanges();
        }
    }
}