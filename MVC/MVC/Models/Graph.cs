using System.Collections.Generic;

namespace MVC.Models
{
    public class Graph
    {
        public int Size { get; set; }
        public string Alpha { get; set; }
        public string Beta { get; set; }
        public string Ro { get; set; }
        public List<double> Array { get; set; }

        public bool IsValid
        {
            get { return Array != null && Array.Count != 0; }
        }
    }
}