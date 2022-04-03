using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EF_Code_First.Model
{
    [Table("Employee")]
    public class Employee
    {
        public int Id { get; set; }

        [Column("FirstName")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Gender { get; set; }



        public int DepartId { get; set; }

        [ForeignKey("DepartId")]
        public Department Department { get; set; }

        public int Salary { get; set; }
        public string JobTitle { get; set; }

        public string JobTitle1 { get; set; }
        //public string JobTitle4 { get; set; }
    }
}