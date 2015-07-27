using System.Data.Entity;
using MVC.Models;

namespace MVC.DataBase
{
    public class NewDataBase : DbContext
    {
        public DbSet<Arrays> Arrays { get; set; }
        //public DbSet<Parameters> Parameters { get; set; }
        //public DbSet<Result> Results { get; set; }
    }
}