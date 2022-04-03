using EmployeeDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Practice.Controllers
{
    [Authorize]
    public class EmployeeTokenAuthController : ApiController
    {
        public IEnumerable<ASP_NETWebAPI_Employees> Get()
        {
            using (ASP_NETWebAPI entities = new ASP_NETWebAPI())
            {
                return entities.ASP_NETWebAPI_Employees.ToList();
            }
        }

    }
}
