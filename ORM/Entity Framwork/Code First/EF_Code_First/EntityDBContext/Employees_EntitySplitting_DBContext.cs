using EF_Code_First.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace EF_Code_First.EntityDBContext
{
    public class Employees_EntitySplitting_DBContext : DbContext
    {
        public DbSet<Employees_EntitySplitting> Employees_EntitySplitting { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees_EntitySplitting>()
            // Specify properties to map to Employees table
            .Map(map =>
            {
                map.Properties(p => new
                {
                    p.EmployeeId,
                    p.FirstName,
                    p.LastName,
                    p.Gender
                });

                map.ToTable("Employees_EntitySplitting");
            })
            // Specify properties to map to EmployeeContactDetails table
            .Map(map =>
            {
                map.Properties(p => new
                {
                    p.EmployeeId,
                    p.Email,
                    p.Mobile,
                    p.Landline
                });

                map.ToTable("EmployeeContactDetails_EntitySplitting");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}