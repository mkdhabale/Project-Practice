﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF_Code_First.Model
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Location { get; set; }

        public List<Employee> Employees { get; set; }
    }
}