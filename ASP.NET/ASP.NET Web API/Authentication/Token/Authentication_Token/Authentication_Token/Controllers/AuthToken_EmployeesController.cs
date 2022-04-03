using Authentication_Token.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Authentication_Token.Controllers
{
    [Authorize]
    public class AuthToken_EmployeesController : ApiController
    {
        public IEnumerable<ASP_NETWebAPI_AuthToken_Employees> Get()
        {
            using (ASP_NETWebAPI_AuthToken_EmployeesEntities entities = new ASP_NETWebAPI_AuthToken_EmployeesEntities())
            {
                return entities.ASP_NETWebAPI_AuthToken_Employees.ToList();
            }
        }
    }
}
