using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Parameters
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public float Alpha { get; set; }
        public float Beta { get; set; }
        public float Ro { get; set; }
    }
}