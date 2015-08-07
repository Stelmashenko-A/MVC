using System.Collections.Generic;

namespace MVC.Models
{
    public class Graph
    {
        public List<double> Array { get; set; }

        public bool IsValid
        {
            get { return Array != null && Array.Count != 0; }
        }
    }
}