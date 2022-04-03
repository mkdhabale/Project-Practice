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
                    GridView1.DataSource = employeeDBContext.Employees_TablePerHierarchy.OfType<PermanentEmployees_TablePerHierarchy>().ToList();
                    GridView1.DataBind();
                    break;

                case "Contract":
                    GridView1.DataSource = employeeDBContext.Employees_TablePerHierarchy.OfType<ContractEmployees_TablePerHierarchy>().ToList();
                    GridView1.DataBind();
                    break;

                default:
                    GridView1.DataSource = ConvertEmployeesForDisplay(employeeDBContext.Employees_TablePerHierarchy.ToList());
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
                    dr["AnuualSalary"] = ((PermanentEmployees_TablePerHierarchy)employee).AnnualSalary;
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

        protected void btnAddPermanentEmployee_Click(object sender, EventArgs e)
        {
            PermanentEmployees_TablePerHierarchy permanentEmployee = new PermanentEmployees_TablePerHierarchy
            {
                FirstName = "Mike",
                LastName = "Brown",
                Gender = "Male",
                AnnualSalary = 70000,
            };

            Employees_TablePerHierarchy_DBContext employeeDBContext = new Employees_TablePerHierarchy_DBContext();
            employeeDBContext.Employees_TablePerHierarchy.Add(permanentEmployee);
            employeeDBContext.SaveChanges();
            RadioButtonList1_SelectedIndexChanged(sender, e);
        }

        protected void btnAddContractEmployee_Click(object sender, EventArgs e)
        {
            ContractEmployees_TablePerHierarchy contractEmployee = new ContractEmployees_TablePerHierarchy
            {
                FirstName = "Stacy",
                LastName = "Josh",
                Gender = "Female",
                HourlyPay = 50,
                HoursWorked = 120
            };

            Employees_TablePerHierarchy_DBContext employeeDBContext = new Employees_TablePerHierarchy_DBContext();
            employeeDBContext.Employees_TablePerHierarchy.Add(contractEmployee);
            employeeDBContext.SaveChanges();
            RadioButtonList1_SelectedIndexChanged(sender, e);
        }
    }
}