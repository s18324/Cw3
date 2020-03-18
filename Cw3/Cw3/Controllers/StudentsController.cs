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

        [HttpGet]
        public IActionResult GetStudents(string orderBy)
        {
            return Ok(_dbService.GetStudents());
        }

    }
}