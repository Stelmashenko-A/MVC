using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Results
    {
        [Key]
        public int Id { get; set; }
        public string Path { get; set; }
        public System.Single Length { get; set; }
        public int ParametersId { get; set; }
        public int ArraysId { get; set; }
    }
}