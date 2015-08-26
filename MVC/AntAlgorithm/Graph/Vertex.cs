namespace AntAlgorithm.Graph
{
    class Vertex : IVertex
    {
        public Vertex(int number)
        {
            Number = number;
        }

        public int Number { get; private set; }
    }
}