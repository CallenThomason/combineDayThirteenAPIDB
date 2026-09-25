

namespace combineDayThirteenAPIDB.Models
{
    public class Staff : BaseEntity
    {
        //because it is inheriting the id from BaseEntity we don't need it here
     // public int Id{get; set;}  //This ID is our unique identifier for our table
      public string FullName{get; set;} = string.Empty; //holds an empty string if they dont input anything
      public string Job{get; set;} = string.Empty;
      
      public bool HasComputer{get; set;} = false; //we can asign values to our properties 
      

    }
}