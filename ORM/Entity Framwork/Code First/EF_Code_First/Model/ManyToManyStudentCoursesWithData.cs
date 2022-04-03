using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EF_Code_First.Model
{
    public class ManyToManyStudentCoursesWithData
    {
        public ManyToManyCoursesWithData Course { get; set; }

        public ManyToManyStudentsWithData Student { get; set; }

        [Key, Column(Order = 1)]
        public int StudentID { get; set; }

        [Key, Column(Order = 2)]
        public int CourseID { get; set; }

        public DateTime EnrolledDate { get; set; }
    }
}