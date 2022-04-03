using EF_Code_First.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EF_Code_First.EntityDBContext
{
    public class Employees_TablePerType_DBContext : DbContext
    {
        public DbSet<Employees_TablePerType> Employees { get; set; }
    }
}