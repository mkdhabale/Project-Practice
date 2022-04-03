using EmployeeDataAccess;
using Practice.CustomAuthentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace Practice.Controllers
{
    [BasicAuthentication]
    public class EmployeesBasicAuthController : ApiController
    {
        public HttpResponseMessage Get(string gender = "All")
        {
            string username = Thread.CurrentPrincipal.Identity.Name;
            using (ASP_NETWebAPI entities = new ASP_NETWebAPI())
            {
                switch (username.ToLower())
                {
                    case "male":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            entities.ASP_NETWebAPI_Employees.Where(e => e.Gender.ToLower() == "male").ToList());
                    case "female":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            entities.ASP_NETWebAPI_Employees.Where(e => e.Gender.ToLower() == "female").ToList());
                    default:
                        return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
        }
    }
}
