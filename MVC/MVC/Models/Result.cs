﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Results
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Path { get; set; }
        public float Length { get; set; }
        public int ParametersId { get; set; }
        public int ArraysId { get; set; }
    }
}