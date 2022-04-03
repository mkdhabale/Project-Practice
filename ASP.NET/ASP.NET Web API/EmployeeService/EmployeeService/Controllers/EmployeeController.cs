using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using EmployeeDataAccess;
using Newtonsoft.Json.Linq;

namespace EmployeeService.Controllers
{
    public class EmployeeController : ApiController
    {

        [BasicAuthentication]
        public HttpResponseMessage Get()
        {
            string username = Thread.CurrentPrincipal.Identity.Name;

            using (TrainingDBEntities entities = new TrainingDBEntities())
            {
                switch (username.ToLower())
                {
                    case "male":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            entities.Employees1.Where(e => e.Gender.ToLower() == "male").ToList());
                    case "female":
                        return Request.CreateResponse(HttpStatusCode.OK,
                            entities.Employees1.Where(e => e.Gender.ToLower() == "female").ToList());
                    default:
                        return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
        }

        /*public IEnumerable<Employees1> Get()
        {
            using(TrainingDBEntities entities = new TrainingDBEntities())
            {
                return entities.Employees1.ToList();
            }
        }*/

        public HttpResponseMessage Get(int id)
        {
            using (TrainingDBEntities entities = new TrainingDBEntities())
            {
                var entity = entities.Employees1.FirstOrDefault(e => e.ID == id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with Id " + id.ToString() + " not found");
                }
            }
        }
        /*
        [HttpGet]
        public HttpResponseMessage GetEmployee([FromBody] JObject data )
        {
            using (TrainingDBEntities entities = new TrainingDBEntities())
            {
                int id = Convert.ToInt32(data["id"]);
                string name = Convert.ToString(data["name"]);
                var entity = entities.Employees1.FirstOrDefault(e => e.ID == id && e.FirstName == name);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with Id " + id.ToString() + " not found");
                }
            }
        }*/

        public IEnumerable<Employees1> Get(string name)
        {
            using (TrainingDBEntities entities = new TrainingDBEntities())
            {
                return entities.Employees1.Where(f => f.FirstName.Contains(name)).ToList();
            }
        }

        public HttpResponseMessage Post([FromBody] Employees1 employee)
        {
            try
            {
                using (TrainingDBEntities entities = new TrainingDBEntities())
                {
                    entities.Employees1.Add(employee);
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

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (TrainingDBEntities entities = new TrainingDBEntities())
                {
                    var entity = entities.Employees1.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with Id = " + id.ToString() + " not found to delete");
                    }
                    else
                    {
                        entities.Employees1.Remove(entity);
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

        public HttpResponseMessage Delete(string name)
        {
            try
            {
                using (TrainingDBEntities entities = new TrainingDBEntities())
                {
                    var entity = entities.Employees1.FirstOrDefault(e => e.FirstName == name);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with FirstName = " + name.ToString() + " not found to delete");
                    }
                    else
                    {
                        entities.Employees1.Remove(entity);
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
        public HttpResponseMessage Put(int id, [FromBody] Employees1 employee)
        {
            try
            {
                using (TrainingDBEntities entities = new TrainingDBEntities())
                {
                    var entity = entities.Employees1.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with Id " + id.ToString() + " not found to update");
                    }
                    else
                    {
                        entity.FirstName = employee.FirstName;
                        entity.LastName = employee.LastName;
                        entity.Gender = employee.Gender;
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


        public HttpResponseMessage Put(string name, [FromBody] Employees1 employee)
        {
            try
            {
                using (TrainingDBEntities entities = new TrainingDBEntities())
                {
                    var entity = entities.Employees1.FirstOrDefault(e => e.FirstName == name);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                            "Employee with FirstName " + name.ToString() + " not found to update");
                    }
                    else
                    {
                        entity.FirstName = employee.FirstName;
                        entity.LastName = employee.LastName;
                        entity.Gender = employee.Gender;
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
