using System.Collections.Generic;

namespace AntAlgorithm.Graph
{
    public interface IGraph
    {
        IList<IVertex> Vertecies { get; }
        IList<IEdge> Edges { get; }

        Dictionary<IVertex, IEdge> GetSibilings(IVertex vertex);
        Path CalculatePath(IList<IVertex> items);
        IList<IEdge> GetEdgePath(IList<IVertex> items);
    }
}
