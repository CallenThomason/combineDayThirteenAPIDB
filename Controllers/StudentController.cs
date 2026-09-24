using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using combineDayThirteenAPIDB.Models;
using combineDayThirteenAPIDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace combineDayThirteenAPIDB.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // -> /api/student
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _student; 
        //private because we don't want any class to access this variable
        //readonly because once it is assigned we do not want to reasign it
        public StudentController(IStudentServices student)
        {
            _student = student; //supplying the empty variable with methods from our student services class
        }

        [HttpGet("GetAllStudents")]
        public ActionResult<List<Student>> GetAll()
        {
         
         //Storing students from our database into the students list
          List<Student> students = _student.GetAll(); 

            return Ok(_student.GetAll()); //return 200 status and students
        }

        [HttpPost("Create")]
        public ActionResult<Student> CreateStudent([FromBody] Student newStudent)
        {
            Student createdStudent = _student.AddStudent(newStudent); 


            return CreatedAtAction(
                    nameof(GetAll),
                    createdStudent

            ); 
        }

    }
}