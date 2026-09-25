

namespace combineDayThirteenAPIDB.Models
{
    public class Student : BaseEntity
    {
       // public int Id{get; set;}
        public string FirstName{get; set;}
        public string LastName{get; set;}
        public string email{get; set;}
    }
}

//Student student = new Student()
//student.FirstName = "Isaiah" {set}
//We would also be able to Console.WriteLine(Student.LastName); {get}