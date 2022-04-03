using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EF_Code_First.Model
{
    [Table("ContractEmployees_TablePerType")]
    public class ContractEmployees_TablePerType : Employees_TablePerType
    {
        public int HoursWorked { get; set; }
        public int HourlyPay { get; set; }
    }
}