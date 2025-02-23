﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EF_Code_First.Model
{
    public abstract class Employees_TablePerHierarchy
    {
        [Column(Order = 1)]
        public int ID { get; set; }
        [Column(Order = 2)]
        public string FirstName { get; set; }
        [Column(Order = 3)]
        public string LastName { get; set; }
        [Column(Order = 4)]
        public string Gender { get; set; }
    }
}