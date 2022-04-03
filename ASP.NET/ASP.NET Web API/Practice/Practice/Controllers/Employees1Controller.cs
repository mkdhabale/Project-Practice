using EmployeeDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Practice.Controllers
{
    public class Employees1Controller : ApiController
    {
        public HttpResponseMessage Put([FromBody] int id, [FromUri] ASP_NETWebAPI_Employees employee)
        {
            try
            {
                using (ASP_NETWebAPI entities = new ASP_NETWebAPI())
                {
                    var entity = entities.ASP_NETWebAPI_Employees.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with Id " + id.ToString() + " not found to update.");
                    }
                    else
                    {
                        //To update and set those values which are passed in Body otherwise it will set that in db as null
                        if (employee.FirstName != null)
                            entity.FirstName = employee.FirstName;
                        if (employee.LastName != null)
                            entity.LastName = employee.LastName;
                        if (employee.Gender != null)
                            entity.Gender = employee.Gender;
                        if (employee.Salary != null)
                            entity.Salary = employee.Salary;

                        entities.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
