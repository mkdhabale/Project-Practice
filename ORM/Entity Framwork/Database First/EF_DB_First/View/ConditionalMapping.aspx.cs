using EF_DB_First.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EF_DB_First.View
{
    public partial class ConditionalMapping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Employees_ConditionalMapping_DBContext employeeDBContext = new Employees_ConditionalMapping_DBContext();

            GridView1.DataSource = employeeDBContext.EmployeesConditionalMappings;
            GridView1.DataBind();
        }
    }
}