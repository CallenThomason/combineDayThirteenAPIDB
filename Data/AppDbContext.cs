

using combineDayThirteenAPIDB.Models;
using Microsoft.EntityFrameworkCore;

namespace combineDayThirteenAPIDB.Data
{
    public class AppDbContext : DbContext //Db context is our connection to the Database
    {
       //Constructor runs automatically when a class is called
        //Constructor and class share the same name
       public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        //This IS the Students table as far as our C# code is concerned
        public DbSet<Student> Students{get; set;} 
        public DbSet<Staff> Staff{get; set;}
    }
}