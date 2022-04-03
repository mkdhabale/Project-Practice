using EF_Code_First.EntityDBContext;
using EF_Code_First.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EF_Code_First.Seeder
{
    public class EmployeeDBContextSeeder : DropCreateDatabaseIfModelChanges<EmployeeDBContext>
    {
        protected override void Seed(EmployeeDBContext context)
        {
            Department department = new Department()
            {
                Name = "IT",
                Location = "newypr",
                Employees = new List<Employee>()
            {
                new Employee()
                {
                    FirstName = "ddd", LastName = "fff", Gender = "fff",
                    Salary= 4544, JobTitle = "333", JobTitle1 = "dfd"
                }
            }
            };

            context.Departments.Add(department);
            base.Seed(context);
        }
    }
}