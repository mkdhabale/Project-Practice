using EF_Code_First.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EF_Code_First.EntityDBContext
{
    public class Employees_SelfReferencing_DBContext : DbContext
    {
        public DbSet<Employees_SelfReferencing> Employees_SelfReferencing { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees_SelfReferencing>()
                .HasOptional(e => e.Manager)
                .WithMany()
                .HasForeignKey(m => m.ManagerID);

            base.OnModelCreating(modelBuilder);
        }
    }
}