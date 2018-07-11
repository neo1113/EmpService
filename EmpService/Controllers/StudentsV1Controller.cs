using EmpService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmpService.Controllers
{
    public class StudentsV1Controller : ApiController
    {
        static List<StudentV1> students = new List<StudentV1>()
        {
            new StudentV1() { Id = 1, Name = "Tome" },
            new StudentV1() { Id = 2, Name = "Sam" },
            new StudentV1() { Id = 3, Name = "John" },
        };

        // API versioning
        [Route("api/v1/students")]
        public IEnumerable<StudentV1> Get()
        {
            return students;
        }

        [Route("api/v1/students/{id}")]
        public StudentV1 Get(int id)
        {
            return students.FirstOrDefault(e => e.Id == id);
        }

        //// Routing Sample
        //[Route("{id:int}", Name = "GetStudentById")]
        //public Student Get(int id)
        //{
        //    return students.FirstOrDefault(e => e.Id == id);
        //}

        //public HttpResponseMessage Post(Student student)
        //{
        //    students.Add(student);
        //    var response = Request.CreateResponse(HttpStatusCode.Created);
        //    response.Headers.Location = new Uri(Url.Link("GetStudentById", new { id = student.Id }));
        //    return response;
        //}
    }
}
