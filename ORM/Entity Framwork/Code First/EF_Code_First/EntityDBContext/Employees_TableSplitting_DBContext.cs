using EF_Code_First.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EF_Code_First.EntityDBContext
{
    public class Employees_TableSplitting_DBContext : DbContext
    {
        public DbSet<Employees_TableSplitting> Employees_TableSplitting { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees_TableSplitting>()
                .HasKey(pk => pk.EmployeeID)
                .ToTable("Employees_TableSplitting");

            modelBuilder.Entity<EmployeesContactDetails_TableSplitting>()
                .HasKey(pk => pk.EmployeeID)
                .ToTable("Employees_TableSplitting");

            modelBuilder.Entity<Employees_TableSplitting>()
                .HasRequired(p => p.EmployeesContactDetails_TableSplitting)
                .WithRequiredPrincipal(c => c.Employee);
        }
    }
}