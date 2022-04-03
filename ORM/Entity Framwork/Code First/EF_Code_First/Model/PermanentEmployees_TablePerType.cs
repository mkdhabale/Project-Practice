using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EF_Code_First.Model
{
    [Table("PermanentEmployees_TablePerType")]
    public class PermanentEmployees_TablePerType : Employees_TablePerType
    {
        public int AnnualSalary { get; set; }
    }
}