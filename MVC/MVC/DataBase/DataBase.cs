using System.Data.Entity;
using MVC.Models;

namespace MVC.DataBase
{
    public class NewDataBase : DbContext
    {
        public DbSet<Arrays> Arrays { get; set; }
        public DbSet<Parameters> Parameters { get; set; }
        public DbSet<Results> Results { get; set; }
    }
}