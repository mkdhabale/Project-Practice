using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EF_Code_First.Model
{
    public class PermanentEmployees_TablePerHierarchy : Employees_TablePerHierarchy
    {
        [Column(Order = 5)]
        public int AnnualSalary { get; set; }
    }
}