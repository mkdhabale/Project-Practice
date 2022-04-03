using EF_Code_First.EntityDBContext;
using EF_Code_First.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EF_Code_First.View
{
    public partial class TableSplitting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private DataTable GetEmployeeData()
        {
            Employees_TableSplitting_DBContext employeeDBContext = new Employees_TableSplitting_DBContext();
            List<Employees_TableSplitting> employees = employeeDBContext.Employees_TableSplitting.ToList();

            DataTable dataTable = new DataTable();
            DataColumn[] columns = { new DataColumn("EmployeeID"),
                                 new DataColumn("FirstName"),
                                 new DataColumn("LastName"),
                                 new DataColumn("Gender")};

            dataTable.Columns.AddRange(columns);

            foreach (Employees_TableSplitting employee in employees)
            {
                DataRow dr = dataTable.NewRow();
                dr["EmployeeID"] = employee.EmployeeID;
                dr["FirstName"] = employee.FirstName;
                dr["LastName"] = employee.LastName;
                dr["Gender"] = employee.Gender;

                dataTable.Rows.Add(dr);
            }

            return dataTable;
        }

        private DataTable GetEmployeeDataIncludingContactDetails()
        {
            Employees_TableSplitting_DBContext employeeDBContext = new Employees_TableSplitting_DBContext();

            List<Employees_TableSplitting> employees = employeeDBContext.Employees_TableSplitting
                .Include("EmployeesContactDetails_TableSplitting").ToList();

            DataTable dataTable = new DataTable();
            DataColumn[] columns = { new DataColumn("EmployeeID"),
                                 new DataColumn("FirstName"),
                                 new DataColumn("LastName"),
                                 new DataColumn("Gender"),
                                 new DataColumn("Email"),
                                 new DataColumn("Mobile"),
                                 new DataColumn("LandLine") };
            dataTable.Columns.AddRange(columns);

            foreach (Employees_TableSplitting employee in employees)
            {
                DataRow dr = dataTable.NewRow();
                dr["EmployeeID"] = employee.EmployeeID;
                dr["FirstName"] = employee.FirstName;
                dr["LastName"] = employee.LastName;
                dr["Gender"] = employee.Gender;
                dr["Email"] = employee.EmployeesContactDetails_TableSplitting.Email;
                dr["Mobile"] = employee.EmployeesContactDetails_TableSplitting.Mobile;
                dr["LandLine"] = employee.EmployeesContactDetails_TableSplitting.LandLine;

                dataTable.Rows.Add(dr);
            }

            return dataTable;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkBoxIncludeContactDetails.Checked)
            {
                GridView1.DataSource = GetEmployeeDataIncludingContactDetails();
            }
            else
            {
                GridView1.DataSource = GetEmployeeData();
            }
            GridView1.DataBind();
        }
    }
}