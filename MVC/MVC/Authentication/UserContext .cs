using System.Data.Entity;
using MVC.Models;

namespace MVC.Authentication
{
    public class UserContext : DbContext
    {
        public UserContext() :
            base("DefaultConnection")
        { }

        public DbSet<User> Users { get; set; }
    }
}