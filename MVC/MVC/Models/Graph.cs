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
    }
}