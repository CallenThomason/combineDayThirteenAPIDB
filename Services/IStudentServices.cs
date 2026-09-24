

using combineDayThirteenAPIDB.Models;

namespace combineDayThirteenAPIDB.Services
{
    public interface IStudentServices
    {
        // 2 Methods. A method that gets all students, and a method that creates a student

        List<Student> GetAll(); 

        Student AddStudent(Student newStudent); //parameters are just place holders for information
        
    }
}