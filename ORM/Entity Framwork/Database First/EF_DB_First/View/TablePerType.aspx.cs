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
    public partial class TablePerType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Employees_TablePerType_DBContext employeeDBContext = new Employees_TablePerType_DBContext();

            switch (RadioButtonList1.SelectedValue)
            {
                case "Permanent":
                    GridView1.DataSource = employeeDBContext.Employees_TablePerType
                        .OfType<PermanentEmployees_TablePerType>().ToList();
                    GridView1.DataBind();
                    break;

                case "Contract":
                    GridView1.DataSource = employeeDBContext.Employees_TablePerType
                        .OfType<ContractEmployees_TablePerType>().ToList();
                    GridView1.DataBind();
                    break;

                default:
                    GridView1.DataSource =
                        ConvertEmployeesForDisplay(employeeDBContext.Employees_TablePerType.ToList());
                    GridView1.DataBind();
                    break;
            }
        }

        private DataTable ConvertEmployeesForDisplay(List<Employees_TablePerType> employees)
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

            foreach (Employees_TablePerType employee in employees)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = employee.EmployeeID;
                dr["FirstName"] = employee.FirstName;
                dr["LastName"] = employee.LastName;
                dr["Gender"] = employee.Gender;

                if (employee is PermanentEmployees_TablePerType)
                {
                    dr["AnuualSalary"] = ((PermanentEmployees_TablePerType)employee).AnnualSalary;
                    dr["Type"] = "Permanent";
                }
                else
                {
                    dr["HourlyPay"] = ((ContractEmployees_TablePerType)employee).HourlyPay;
                    dr["HoursWorked"] = ((ContractEmployees_TablePerType)employee).HoursWorked;
                    dr["Type"] = "Contract";
                }
                dt.Rows.Add(dr);
            }

            return dt;
        }
    }
}