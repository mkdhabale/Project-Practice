using EF_Code_First.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EF_Code_First.EntityDBContext
{
    public class Employees_StoredProcedure_DBContext : DbContext
    {
        public DbSet<Employees_StoredProcedure> Employees_StoredProcedure { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // This line will tell entity framework to use stored procedures
            // when inserting, updating and deleting Employees
            modelBuilder.Entity<Employees_StoredProcedure>().MapToStoredProcedures();
            base.OnModelCreating(modelBuilder);

            /*
             * To custom employee ame
            modelBuilder.Entity<Employee>()
            .MapToStoredProcedures(p => p.Insert(x => x.HasName("InsertEmployee")));
            modelBuilder.Entity<Employee>()
                .MapToStoredProcedures(p => p.Update(x => x.HasName("UpdateEmployee")));
            modelBuilder.Entity<Employee>()
                .MapToStoredProcedures(p => p.Delete(x => x.HasName("DeleteEmployee")));

            base.OnModelCreating(modelBuilder);*/


            /* //OR
            modelBuilder.Entity<Employee>()
            .MapToStoredProcedures(p => p.Insert(x => x.HasName("InsertEmployee")));
        modelBuilder.Entity<Employee>()
            .MapToStoredProcedures(p => p.Update(x => x.HasName("UpdateEmployee")));
        modelBuilder.Entity<Employee>()
            .MapToStoredProcedures(p => p.Delete(x => x.HasName("DeleteEmployee")));

        base.OnModelCreating(modelBuilder);
             * */



            /*The default parameter names of the stored procedures can also be changed using the following code.*/
            /* modelBuilder.Entity<Employee>().MapToStoredProcedures
                 (p => p.Insert(i => i.HasName("InsertEmployee")
                                         .Parameter(n => n.Name, "EmployeeName")
                                         .Parameter(n => n.Gender, "EmployeeGender")
                                         .Parameter(n => n.Salary, "EmployeeSalary"))
                         .Update(u => u.HasName("UpdateEmployee")
                                         .Parameter(n => n.ID, "EmployeeID")
                                         .Parameter(n => n.Name, "EmployeeName")
                                         .Parameter(n => n.Gender, "EmployeeGender")
                                         .Parameter(n => n.Salary, "EmployeeSalary"))
                         .Delete(d => d.HasName("DeleteEmployee")
                                         .Parameter(n => n.ID, "EmployeeID"))
                 );
             base.OnModelCreating(modelBuilder);*/
        }
    }
}