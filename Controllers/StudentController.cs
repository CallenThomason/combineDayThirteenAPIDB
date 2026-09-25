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

        [HttpPut("UpdateStudent/{id}")]

        public ActionResult<Student> UpdateStudent(int id, [FromBody] Student student)
        {
            //possible null return, we add the null operator
            Student? updated = _student.Replace(id, student);

            //if the input id is not in the database we return NotFound
            if(updated is null)
            {
                return NotFound($"No student with id {id} was found"); 
            }
            return NoContent(); 

        }

        //Send only the fields you want to change. Everything else stays the same
        [HttpPatch("Patch/{id}")]

        public ActionResult<Student> Patch(int id, [FromBody] Student changes)
        {
            Student? changed = _student.Patch(id, changes);
            if(changed is null)
            {
                return NotFound($"No student with id {id} was found"); 
            }
            return NoContent(); 
        }

    //     "id": 1,
    // "firstname": "Chris",
    // "lastname": "Estrada", 
    // "email": "cestrada@codestack.co"

    }
}