﻿using Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Practice.Controllers
{
    [RoutePrefix("api/studentsRoutePrefix")]
    public class StudentRoutePrefixController : ApiController
    {
        static List<Student> students = new List<Student>()
        {
            new Student() { Id = 1, Name = "Tom" },
            new Student() { Id = 2, Name = "Sam" },
            new Student() { Id = 3, Name = "John" }
        };

        [Route("")]
        public IEnumerable<Student> Get()
        {
            return students;
        }

        [Route("{id}", Name = "GetStudentById")]
        public Student Get(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        [Route("{id}/courses")]
        public IEnumerable<string> GetStudentCourses(int id)
        {
            if (id == 1)
                return new List<string>() { "C#", "ASP.NET", "SQL Server" };
            else if (id == 2)
                return new List<string>() { "ASP.NET Web API", "C#", "SQL Server" };
            else
                return new List<string>() { "Bootstrap", "jQuery", "AngularJs" };
        }

        [Route("{id}/studentDetails")]
        public Student GetStudentDetails(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        [Route("api/teachers")]
        public IEnumerable<Teacher> GetTeachers()
        {
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher() { Id = 1, Name = "Rob" },
                new Teacher() { Id = 2, Name = "Mike" },
                new Teacher() { Id = 3, Name = "Mary" }
            };

            return teachers;
        }

        [Route("~/api/teachers")]
        public IEnumerable<Teacher> GetTeachers1()
        {
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher() { Id = 1, Name = "Rob" },
                new Teacher() { Id = 2, Name = "Mike" },
                new Teacher() { Id = 3, Name = "Mary" }
            };

            return teachers;
        }

        //Post with auto location
        [Route("")]
        public HttpResponseMessage Post(Student student)
        {
            students.Add(student);
            var response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new
                Uri(Url.Link("GetStudentById", new { id = student.Id }));
            return response;
        }
    }
}
