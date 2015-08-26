using System.Collections.Generic;
using System.IO;
using Grsu.Lab.Aoc.Contracts;

namespace AntColonySystem
{
    public class Graph : IGraph
    {
        public IList<INode> GetSibilings(INode node)
        {
            throw new System.NotImplementedException();
        }

        public void LoadGraph(Stream stream)
        {
            throw new System.NotImplementedException();
        }

        public IList<IEdge> Edges { get; set; }
        public IList<INode> Nodes { get; set; }
    }
}
