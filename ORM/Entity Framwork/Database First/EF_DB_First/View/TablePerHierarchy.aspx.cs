using EF_DB_First.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EF_DB_First.View
{
    public partial class TablePerHierarchy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Employees_TablePerHierarchy_DBContext employeeDBContext = new Employees_TablePerHierarchy_DBContext();

            switch (RadioButtonList1.SelectedValue)
            {
                case "Permanent":
                    GridView1.DataSource = employeeDBContext.Employees_TablePerHierarchy
                        .OfType<PermanentEmployees_TablePerHierarchy>().ToList();
                    GridView1.DataBind();
                    break;

                case "Contract":
                    GridView1.DataSource = employeeDBContext.Employees_TablePerHierarchy
                        .OfType<ContractEmployees_TablePerHierarchy>().ToList();
                    GridView1.DataBind();
                    break;

                default:
                    GridView1.DataSource = ConvertEmployeesForDisplay(
                        employeeDBContext.Employees_TablePerHierarchy.ToList());
                    GridView1.DataBind();
                    break;
            }
        }

        private DataTable ConvertEmployeesForDisplay(List<Employees_TablePerHierarchy> employees)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("FirstName");
            dt.Columns.Add("LastName");
            dt.Columns.Add("Gender");
            dt.Columns.Add("AnuualSalary");
            dt.Columns.Add("HourlyPay");
            dt.Columns.Add("HoursWorked");
            dt.Columns.Add("Type");

            foreach (Employees_TablePerHierarchy employee in employees)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = employee.ID;
                dr["FirstName"] = employee.FirstName;
                dr["LastName"] = employee.LastName;
                dr["Gender"] = employee.Gender;

                if (employee is PermanentEmployees_TablePerHierarchy)
                {
                    dr["AnuualSalary"] = ((PermanentEmployees_TablePerHierarchy)employee).AnuualSalary;
                    dr["Type"] = "Permanent";
                }
                else
                {
                    dr["HourlyPay"] = ((ContractEmployees_TablePerHierarchy)employee).HourlyPay;
                    dr["HoursWorked"] = ((ContractEmployees_TablePerHierarchy)employee).HoursWorked;
                    dr["Type"] = "Contract";
                }
                dt.Rows.Add(dr);
            }

            return dt;
        }
    }
}