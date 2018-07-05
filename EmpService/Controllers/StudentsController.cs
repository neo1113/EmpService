using EmpService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmpService.Controllers
{
    [RoutePrefix("api/students")]
    public class StudentsController : ApiController
    {
        static List<Student> students = new List<Student>()
        {
            new Student() { Id = 1, Name = "Tome" },
            new Student() { Id = 2, Name = "Sam" },
            new Student() { Id = 3, Name = "John" },
        };

        [Route("{id:int}")]
        public Student Get(int id)
        {
            return students.FirstOrDefault(e => e.Id == id);
        }

        //public HttpResponseMessage Post(Student student)
        //{
        //    students.Add(student);
        //    var response = Request.CreateResponse(HttpStatusCode.Created);
        //    return response;
        //}
    }
}
