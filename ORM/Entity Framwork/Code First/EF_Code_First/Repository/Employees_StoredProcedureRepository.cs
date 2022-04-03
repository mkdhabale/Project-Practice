using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EF_Code_First.Model;
using EF_Code_First.EntityDBContext;

namespace EF_Code_First.Repository
{
    public class Employees_StoredProcedureRepository
    {
        Employees_StoredProcedure_DBContext employeeDBContext = new Employees_StoredProcedure_DBContext();

        public List<Employees_StoredProcedure> GetEmployees()
        {
            return employeeDBContext.Employees_StoredProcedure.ToList();
        }

        public void InsertEmployee(Employees_StoredProcedure employee)
        {
            employeeDBContext.Employees_StoredProcedure.Add(employee);
            employeeDBContext.SaveChanges();
        }

        public void UpdateEmployee(Employees_StoredProcedure employee)
        {
            Employees_StoredProcedure employeeToUpdate = employeeDBContext
                .Employees_StoredProcedure.SingleOrDefault(x => x.ID == employee.ID);
            employeeToUpdate.Name = employee.Name;
            employeeToUpdate.Gender = employee.Gender;
            employeeToUpdate.Salary = employee.Salary;
            employeeDBContext.SaveChanges();
        }

        public void DeleteEmployee(Employees_StoredProcedure employee)
        {
            Employees_StoredProcedure employeeToDelete = employeeDBContext
                .Employees_StoredProcedure.SingleOrDefault(x => x.ID == employee.ID);
            employeeDBContext.Employees_StoredProcedure.Remove(employeeToDelete);
            employeeDBContext.SaveChanges();
        }
    }
}