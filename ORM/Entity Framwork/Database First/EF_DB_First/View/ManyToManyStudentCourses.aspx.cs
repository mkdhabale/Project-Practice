using EF_DB_First.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EF_DB_First.View
{
    public partial class ManyToMany : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ManyToMany_StudentCourses_DBContext employeeDBContext = new ManyToMany_StudentCourses_DBContext();

            GridView1.DataSource = from student in employeeDBContext.ManyToManyStudents
                                   from course in student.ManyToManyCourses
                                   select new
                                   {
                                       StudentName = student.StudentName,
                                       CourseName = course.CourseName
                                   };
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ManyToMany_StudentCourses_DBContext employeeDBContext = new ManyToMany_StudentCourses_DBContext();
            ManyToManyCours WCFCourse = employeeDBContext.ManyToManyCourses
                .FirstOrDefault(x => x.CourseID == 4);

            employeeDBContext.ManyToManyStudents.FirstOrDefault(x => x.StudentID == 1)
                .ManyToManyCourses.Add(WCFCourse);
            employeeDBContext.SaveChanges();
            Page_Load(sender, e);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ManyToMany_StudentCourses_DBContext employeeDBContext = new ManyToMany_StudentCourses_DBContext();
            ManyToManyCours SQLServerCourse = employeeDBContext.ManyToManyCourses
                .FirstOrDefault(x => x.CourseID == 3);

            employeeDBContext.ManyToManyStudents.FirstOrDefault(x => x.StudentID == 2)
                .ManyToManyCourses.Remove(SQLServerCourse);
            employeeDBContext.SaveChanges();
            Page_Load(sender, e);
        }
    }
}