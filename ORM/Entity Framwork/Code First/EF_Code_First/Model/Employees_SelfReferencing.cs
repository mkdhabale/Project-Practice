using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EF_Code_First.Model
{
    public class Employees_SelfReferencing
    {
        // Scalar properties
        [Key]
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public int? ManagerID { get; set; }

        // Navigation property
        public Employees_SelfReferencing Manager { get; set; }
    }
}