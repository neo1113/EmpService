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

        [Route("~/api/teachers")]
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

        [Route("")]
        public IEnumerable<Student> Get()
        {
            return students;
        }

        [Route("{id:int:range(1,3)}")]
        public Student Get(int id)
        {
            return students.FirstOrDefault(e => e.Id == id);
        }

        [Route("{name:alpha}")]
        public Student Get(string name)
        {
            return students.FirstOrDefault(e => e.Name.ToLower() == name.ToLower());
        }

        [Route("{id}/courses")]
        public IEnumerable<string> GetStudentCourses(int id)
        {
            if(id == 1)
                return new List<String>() { "C#", "ASP.NET", "SQL Server" };
            else if (id == 2)
                return new List<String>() { "ASP.NET Web API", "C#", "SQL Server" };
            else
                return new List<String>() { "Bootstrap", "jQuery", "AngularJs" };
        }
    }
}
