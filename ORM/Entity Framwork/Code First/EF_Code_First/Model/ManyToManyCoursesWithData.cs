using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EF_Code_First.Model
{
    public class ManyToManyCoursesWithData
    {
        [Key]
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public IList<ManyToManyStudentCoursesWithData> StudentCourses { get; set; }
    }
}