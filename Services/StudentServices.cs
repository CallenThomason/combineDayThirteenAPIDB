
using combineDayThirteenAPIDB.Data;
using combineDayThirteenAPIDB.Models;

namespace combineDayThirteenAPIDB.Services
{
    public class StudentServices : IStudentServices 
    {
        private AppDbContext _db; 

        public StudentServices(AppDbContext db) // must have the same name as the class
        {
            _db = db;
            //When our StudentServices Class is called
            //The constuctor runs automatically
            //We pass in our database as a parameter and set inside our _dn variable
        }

        public List<Student> GetAll()
        {
            return _db.Students.ToList(); 
        }
        public Student AddStudent(Student newStudent)
        {
            //The Database assigns the Id, so we can ignore any id the client sent
            newStudent.Id = 0; 

            _db.Students.Add(newStudent); //stages the add
            _db.SaveChanges(); //Actually writes it to our students.db

            return newStudent; 
        }
    }
}