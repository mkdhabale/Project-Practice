using EF_Code_First.EntityDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EF_Code_First.View
{
    public partial class ManyToManyStudentCoursesWithData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ManyToManyStudentCoursesWithData_DBContext employeeDBContext = new ManyToManyStudentCoursesWithData_DBContext();

            GridView1.DataSource = (from student in employeeDBContext.Students
                                    from studentCourse in student.StudentCourses
                                    select new
                                    {
                                        StudentName = student.StudentName,
                                        CourseName = studentCourse.Course.CourseName,
                                        EnrolledDate = studentCourse.EnrolledDate
                                    }).ToList();

            // The above query can also be written as shown below
            //GridView1.DataSource = (from course in employeeDBContext.Courses
            //                        from studentCourse in course.StudentCourses
            //                        select new
            //                        {
            //                            StudentName = studentCourse.Student.StudentName,
            //                            CourseName = course.CourseName,
            //                            EnrolledDate = studentCourse.EnrolledDate
            //                        }).ToList();

            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ManyToManyStudentCoursesWithData_DBContext employeeDBContext = new ManyToManyStudentCoursesWithData_DBContext();
            employeeDBContext.StudentCourses.Add(new Model.ManyToManyStudentCoursesWithData
            { StudentID = 1, CourseID = 4, EnrolledDate = DateTime.Now });
            employeeDBContext.SaveChanges();
            Page_Load(sender, e);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ManyToManyStudentCoursesWithData_DBContext employeeDBContext = new ManyToManyStudentCoursesWithData_DBContext();
            Model.ManyToManyStudentCoursesWithData studentCourseToRemove = employeeDBContext.StudentCourses
                .FirstOrDefault(x => x.StudentID == 2 && x.CourseID == 3);
            employeeDBContext.StudentCourses.Remove(studentCourseToRemove);
            employeeDBContext.SaveChanges();
            Page_Load(sender, e);
        }
    }
}