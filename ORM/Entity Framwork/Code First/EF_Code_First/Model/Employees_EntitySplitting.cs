using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EF_Code_First.Model
{
    public class Employees_EntitySplitting
    {
        // These property values should be stored in Employees Table
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

        // These property values should be stored in EmployeeContactDetails Table
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Landline { get; set; }
    }
}