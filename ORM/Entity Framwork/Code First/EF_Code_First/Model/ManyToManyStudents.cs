using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EF_Code_First.Model
{
    public class ManyToManyStudents
    {
        [Key]
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public IList<ManyToManyCourses> Courses { get; set; }
    }
}