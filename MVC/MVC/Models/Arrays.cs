using System;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Arrays
    {
        [Key]
        public int Id { get; set; }
        public string Array { get; set; }
    }
}