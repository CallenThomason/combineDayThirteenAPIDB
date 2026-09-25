

namespace combineDayThirteenAPIDB.Models
{
    public class BaseEntity
    {
        public int Id{get; set;}
        public string Attendance{get; set;} = string.Empty; 
        public int? Age{get; set;} = null; 
        public bool IsVacinated{get; set;}
    }
}