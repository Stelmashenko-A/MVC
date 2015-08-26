using AntAlgorithm.Ants;

namespace AntAlgorithm.Graph
{
    public class Mark
    {
        public Mark(Path path)
        {
            Path = path;
        }

        public Pheromone Pheromone { get; set; }
        public Path Path { get; private set; }

    }
}