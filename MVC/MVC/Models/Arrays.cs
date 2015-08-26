using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Helpers;

namespace MVC.Models
{
    public class Arrays
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public List<List<double>> Matrix;

        public string Array
        {
            get { return Json.Encode(Matrix); }
            set { Matrix = Json.Decode<List<List<double>>>(value); }
        }
    }
}