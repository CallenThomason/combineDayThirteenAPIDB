
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

        public Student Replace (int id, Student student)
        {
            //We must FIND the student that we are updating
            //and store that student and eventually change it

            Student? existingStudent = _db.Students.Find(id); 
            //If we find something in the database EF Core Tracks it

            if(existingStudent is null)
            {
                return null; 
            }
            existingStudent.FirstName = student.FirstName; 
            existingStudent.LastName = student.LastName;
            existingStudent.Age = student.Age; 
            existingStudent.IsVacinated = student.IsVacinated; 
            
            //_db.Students.Update(existingStudent); //This is the old way
            _db.SaveChanges(); 
            //When we pull a entity from our DB, it is tracked and ef core knows if changes are being made to it
            //it is not a simple copy of the information
            return existingStudent; 
        }

        //PATCH: Changes only the fields the client sent. 
        //A field the client left our arrives as "" or (blank / null)
        //blank means leave it alone. 
        public Student Patch(int id, Student changes)
        {
            Student? existingStudent = _db.Students.Find(id); 

            if(existingStudent is null)
            {
                return null; 
            }
            //If a field has a blank or white space we do not change it 
            //IsNullOrWhiteSpace is true for null, "", and " " 
            if (!string.IsNullOrWhiteSpace(changes.FirstName))
            {
                existingStudent.FirstName = changes.FirstName; 
            }
            if(string.IsNullOrWhiteSpace(changes.LastName) == false)
            {
                existingStudent.LastName = changes.LastName; 
            }
            if(string.IsNullOrWhiteSpace(changes.email) != true)
            {
                existingStudent.email = changes.email; 
            }
            //Ef Core tracks our entity automatically
            _db.SaveChanges(); 

            return existingStudent; 
        }
    }
}