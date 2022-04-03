using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EF_Code_First.Model;
namespace EF_Code_First.EntityDBContext
{
    public class ManyToManyStudentCourses_DBContext : DbContext
    {
        public DbSet<ManyToManyCourses> Courses { get; set; }
        public DbSet<ManyToManyStudents> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ManyToManyStudents>()
            .HasMany(t => t.Courses)
            .WithMany(t => t.Students)
            .Map(m =>
            {
                m.ToTable("ManyToManyStudentCourses");
                m.MapLeftKey("StudentID");
                m.MapRightKey("CourseID");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}