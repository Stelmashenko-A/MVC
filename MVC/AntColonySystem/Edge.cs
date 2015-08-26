using Grsu.Lab.Aoc.Contracts;

namespace AntColonySystem
{
    class Edge : IEdge
    {
        public int Begin { get; set; }
        public int End { get; set; }
        public double HeuristicInformation { get; set; }
        public double Pheromone { get; set; }
    }
}
