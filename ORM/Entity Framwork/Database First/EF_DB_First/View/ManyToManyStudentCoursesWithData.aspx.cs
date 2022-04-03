using EF_DB_First.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EF_DB_First.View
{
    public partial class ManyToManyStudentCoursesWithData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ManyToMany_StudentCoursesWithData_DBContext employeeDBContext = new ManyToMany_StudentCoursesWithData_DBContext();

            GridView1.DataSource = (from student in employeeDBContext.ManyToManyStudentsWithDatas
                                    from studentCourse in student.ManyToManyStudentCoursesWithDatas
                                    select new
                                    {
                                        StudentName = student.StudentName,
                                        CourseName = studentCourse.ManyToManyCoursesWithData.CourseName,
                                        EnrolledDate = studentCourse.EnrolledDate
                                    }).ToList();

            // The above query can also be written as shown below
            //GridView1.DataSource = (from course in employeeDBContext.ManyToManyCoursesWithDatas
            //                        from studentCourse in course.ManyToManyStudentCoursesWithDatas
            //                        select new
            //                        {
            //                            StudentName = studentCourse.ManyToManyStudentsWithData.StudentName,
            //                            CourseName = course.CourseName,
            //                            EnrolledDate = studentCourse.EnrolledDate
            //                        }).ToList();

            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ManyToMany_StudentCoursesWithData_DBContext employeeDBContext = new ManyToMany_StudentCoursesWithData_DBContext();
            employeeDBContext.ManyToManyStudentCoursesWithDatas.AddObject
                (new Model.ManyToManyStudentCoursesWithData
                {
                    StudentID = 1,
                    CourseID = 4,
                    EnrolledDate = DateTime.Now
                });
            employeeDBContext.SaveChanges();
            Page_Load(sender, e);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ManyToMany_StudentCoursesWithData_DBContext employeeDBContext = new ManyToMany_StudentCoursesWithData_DBContext();
            Model.ManyToManyStudentCoursesWithData studentCourseToRemove = employeeDBContext.ManyToManyStudentCoursesWithDatas
                .FirstOrDefault(x => x.StudentID == 2 && x.CourseID == 3);
            employeeDBContext.ManyToManyStudentCoursesWithDatas.DeleteObject(studentCourseToRemove);
            employeeDBContext.SaveChanges();
            Page_Load(sender, e);
        }
    }
}