using EF_Code_First.EntityDBContext;
using EF_Code_First.Seeder;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace EF_Code_First
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            /*Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EmployeeDBContext>());*/
            /*Database.SetInitializer(new DropCreateDatabaseAlways<EmployeeDBContext>());
            */
            /*Database.SetInitializer(new EmployeeDBContextSeeder()); */
           //Database.SetInitializer(new DropCreateDatabaseAlways<EmployeeDBContext>());
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}