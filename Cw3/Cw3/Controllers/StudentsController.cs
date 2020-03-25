using System;
using Cw3.DAL;
using Cw3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cw3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        
        //Zadanie 4
        
        // [HttpGet]
        // public string GetStudent()
        // {
        //     return "Kowalski, Nowak, Matejko";
        // }
        
        //Zadanie 5

        // public string GetStudents(string orderBy)
        // {
        //     return $"Kowalski, Nowak, Matejko sortowanie={orderBy}";
        // }

        //zadanie 6
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            //add to database
            //generating index nr
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }
        
        //zadanie 7
        
        [HttpPut("{id}")]
        public IActionResult PutStudent(int id)
        {
            return Ok("Aktualizacja dokończona");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            return Ok("Usuwanie ukończone");
        }
        
        //zadanie 8
        
        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        //[HttpGet]
        //public IActionResult GetStudents(string orderBy)
        //{
        //    return Ok(_dbService.GetStudents());
        //}

        //[HttpGet("{id}")]
        //public IActionResult GetStudents(string orderBy){

        [HttpGet("{id}")]
        public IActionResult GetStudents(string id){
            var list = new List<Object>();
            using(var client= new SqlConnection("Data Source=db-mssql;Initial Catalog=s18324;Integrated Security=True")){
                using (var command = new SqlCommand())
            {
                command.Connection = client;

                command.CommandText =   "select e.Semester Semester, " +
                                        "st.Name StudiesName from Student s" +
                                        "inner join Enrollment e on s.IdEnrollment=e.IdEnrollment" +
                                        "inner join Studies st on e.IdStudy=st.IdStudy"+
                                        $"where s.IndexNumber=@id";
                command.Parameters.AddWithValue("id", id);


                client.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var studia = new
                    {
                        Semestr = reader["Semester"].ToString(),
                        StudiesName = reader["StudiesName"].ToString()
                    };
                    list.Add(studia);
                }
            }

            return Ok(list);
            }
        }

    }
}