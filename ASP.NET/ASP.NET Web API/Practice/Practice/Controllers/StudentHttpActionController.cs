using Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Practice.Controllers
{
    public class StudentHttpActionController : ApiController
    {
        static List<Student> students = new List<Student>()
    {
        new Student() { Id = 1, Name = "Tom" },
        new Student() { Id = 2, Name = "Sam" },
        new Student() { Id = 3, Name = "John" }
    };

        public IHttpActionResult Get()
        {
            return Ok(students);
        }

        public IHttpActionResult Get(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                //return NotFound();
                return Content(HttpStatusCode.NotFound, "Student not found");
            }

            return Ok(student);
        }
    }
}
