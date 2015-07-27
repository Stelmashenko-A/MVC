using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Result
    {
        [Key]
        public int Id { get; set; }
        public string Path { get; set; }
        public float Length { get; set; }
        public int ParametersId { get; set; }
        public int ArraysId { get; set; }
    }
}