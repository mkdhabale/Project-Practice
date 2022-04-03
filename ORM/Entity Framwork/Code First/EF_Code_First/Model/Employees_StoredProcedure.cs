using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF_Code_First.Model
{
    public class Employees_StoredProcedure
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
    }
}