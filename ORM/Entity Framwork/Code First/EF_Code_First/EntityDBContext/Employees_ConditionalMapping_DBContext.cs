using EF_Code_First.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EF_Code_First.EntityDBContext
{
    public class Employees_ConditionalMapping_DBContext : DbContext
    {
        public DbSet<Employees_ConditionalMapping> Employees_ConditionalMapping { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees_ConditionalMapping>()
                .Map(m => m.Requires("IsTerminated")
                .HasValue(false))
                .Ignore(m => m.IsTerminated);

            base.OnModelCreating(modelBuilder);
        }
    }
}