using EF_Code_First.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EF_Code_First.EntityDBContext
{
    public class ManyToManyStudentCoursesWithData_DBContext : DbContext
    {
        public DbSet<ManyToManyCoursesWithData> Courses { get; set; }
        public DbSet<ManyToManyStudentsWithData> Students { get; set; }
        public DbSet<ManyToManyStudentCoursesWithData> StudentCourses { get; set; }
    }
}