using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EF_Code_First.Model
{
    public class ContractEmployees_TablePerHierarchy : Employees_TablePerHierarchy
    {
        [Column(Order = 6)]
        public int HoursWorked { get; set; }
        [Column(Order = 7)]
        public int HourlyPay { get; set; }
    }
}