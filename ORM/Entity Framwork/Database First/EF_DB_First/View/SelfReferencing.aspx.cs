using EF_DB_First.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EF_DB_First.View
{
    public partial class SelfReferencing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Employees_SelfReferencing_DBContext employeeDBContext = new Employees_SelfReferencing_DBContext();
            GridView1.DataSource = employeeDBContext.Employees_SelfReferencing.Select(emp => new
            {
                EmployeeName = emp.EmployeeName,
                ManagerName = emp.Manager == null ? "Super Boss"
                                : emp.Manager.EmployeeName
            }).ToList();
            GridView1.DataBind();
        }
    }
}