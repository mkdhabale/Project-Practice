using EmployeeDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Practice.Controllers
{
    public class EmployeesController : ApiController
    {
        // Without Response code
        /*
        public IEnumerable<ASP_NETWebAPI_Employees> Get()
        {
            using (ASP_NETWebAPI entities = new ASP_NETWebAPI())
            {
                return entities.ASP_NETWebAPI_Employees.ToList();
            }
        }
        */

        //?gender=male
        // With Response code
        public HttpResponseMessage Get(string gender = "All")
        {
            using (ASP_NETWebAPI entities = new ASP_NETWebAPI())
            {
                switch (gender.ToLower())
                {
                    case "all":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            entities.ASP_NETWebAPI_Employees.ToList());
                    case "male":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            //it will execute directly in db wiht using EF for male as where condition
                            entities.ASP_NETWebAPI_Employees.Where(e => e.Gender.ToLower() == "male").ToList()); 
                    case "female":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            entities.ASP_NETWebAPI_Employees.Where(e => e.Gender.ToLower() == "female").ToList());
                    default:
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                            "Value for gender must be Male, Female or All. " + gender + " is invalid.");
                }
            }
        }

        //Custom Get method name if no get method is present
        /*
        [HttpGet]
        public IEnumerable<ASP_NETWebAPI_Employees> LoadEmployees()
        {
            using (ASP_NETWebAPI entities = new ASP_NETWebAPI())
            {
                return entities.ASP_NETWebAPI_Employees.ToList();
            }
        }
        */

        // Without Response code
        /*
        public ASP_NETWebAPI_Employees Get(int id)
        {

            using (ASP_NETWebAPI entities = new ASP_NETWebAPI())
            {
                return entities.ASP_NETWebAPI_Employees.FirstOrDefault(e => e.ID == id);
            }
        }
        */


        // With Response code
        public HttpResponseMessage Get(int id)
        {
            using (ASP_NETWebAPI entities = new ASP_NETWebAPI())
            {
                var entity = entities.ASP_NETWebAPI_Employees.FirstOrDefault(e => e.ID == id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "Employee with Id " + id.ToString() + " not found.");
                }
            }
        }

        // Without Response code
        /*
        public void Post([FromBody] ASP_NETWebAPI_Employees employee)
        {
            using (ASP_NETWebAPI entities = new ASP_NETWebAPI())
            {
                entities.ASP_NETWebAPI_Employees.Add(employee);
                entities.SaveChanges();
            }
        }
        */


        //With Response code
        public HttpResponseMessage Post([FromBody] ASP_NETWebAPI_Employees employee)
        {
            try
            {
                using (ASP_NETWebAPI entities = new ASP_NETWebAPI())
                {
                    entities.ASP_NETWebAPI_Employees.Add(employee);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                    message.Headers.Location = new Uri(Request.RequestUri +
                        employee.ID.ToString());

                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //Without Response code
        /*
        public void Delete(int id)
        {
            using (ASP_NETWebAPI entities = new ASP_NETWebAPI())
            {
                entities.ASP_NETWebAPI_Employees.Remove(entities.ASP_NETWebAPI_Employees.FirstOrDefault(e => e.ID == id));
                entities.SaveChanges();
            }
        }
        */

        //With Response code
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (ASP_NETWebAPI entities = new ASP_NETWebAPI())
                {
                    var entity = entities.ASP_NETWebAPI_Employees.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with Id = " + id.ToString() + " not found to delete.");
                    }
                    else
                    {
                        entities.ASP_NETWebAPI_Employees.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //Without Response code
        /*
        public void Put(int id, [FromBody] ASP_NETWebAPI_Employees employee)
        {
            using (ASP_NETWebAPI entities = new ASP_NETWebAPI())
            {
                var entity = entities.ASP_NETWebAPI_Employees.FirstOrDefault(e => e.ID == id);

                entity.FirstName = employee.FirstName;
                entity.LastName = employee.LastName;
                entity.Gender = employee.Gender;
                entity.Salary = employee.Salary;

                entities.SaveChanges();
            }
        }
        */

        //With Response code
        public HttpResponseMessage Put(int id, [FromBody] ASP_NETWebAPI_Employees employee)
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
                        if(employee.FirstName != null)
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
