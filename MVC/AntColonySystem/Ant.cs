using System.Collections.Generic;
using Grsu.Lab.Aoc.Contracts;

namespace AntColonySystem
{
    class Ant:IAnt
    {
        public IList<INode> VisitedNodes { get; set; }
    }
}
