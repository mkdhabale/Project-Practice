using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF_Code_First.Model
{
    public class EmployeesContactDetails_TableSplitting
    {
        public int EmployeeID { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string LandLine { get; set; }

        public Employees_TableSplitting Employee { get; set; }
    }
}