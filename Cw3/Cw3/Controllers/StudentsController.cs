using System;
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
        
    }
}