using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Parameters
    {
        [Key]
        public int Id { get; set; }
        public float Alpha { get; set; }
        public float Beta { get; set; }
        public float Ro { get; set; }
    }
}