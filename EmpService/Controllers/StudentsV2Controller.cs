using EmpService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmpService.Controllers
{
    public class StudentsV2Controller : ApiController
    {
        static List<StudentV2> students = new List<StudentV2>()
        {
            new StudentV2() { Id = 1, FirstName = "Tome", LastName = "T" },
            new StudentV2() { Id = 2, FirstName = "Sam", LastName = "S" },
            new StudentV2() { Id = 3, FirstName = "John", LastName = "J" },
        };

        // web API versioning
        //[Route("api/v2/students")]
        public IEnumerable<StudentV2> Get()
        {
            return students;
        }

        //[Route("api/v2/students/{id}")]
        public StudentV2 Get(int id)
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
