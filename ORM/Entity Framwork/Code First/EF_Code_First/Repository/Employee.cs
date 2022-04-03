using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EF_Code_First.Model;
using EF_Code_First.EntityDBContext;

namespace EF_Code_First.Repository
{
    public class Employee
    {
        public List<Department> GetDepartments()
        {
            EmployeeDBContext employeeDBContext = new EmployeeDBContext();
            return employeeDBContext.Departments.Include("Employees").ToList();
        }
    }
}