using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class User
    {
        public User(string name, string passwordHash)
        {
            Name = name;
            Password = passwordHash;
        }

        public User()
        {
            
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Password { get; private set; }

    }
}