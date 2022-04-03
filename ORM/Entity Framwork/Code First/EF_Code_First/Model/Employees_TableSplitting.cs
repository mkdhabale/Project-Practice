using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF_Code_First.Model
{
    public class Employees_TableSplitting
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

        public EmployeesContactDetails_TableSplitting EmployeesContactDetails_TableSplitting { get; set; }
    }
}