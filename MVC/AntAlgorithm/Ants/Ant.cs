using System.Collections.Generic;
using AntAlgorithm.Graph;

namespace AntAlgorithm.Ants
{
    internal class Ant : IAnt
    {
        public Ant()
        {
            VisitedVetecies = new List<IVertex>();
        }

        public IList<IVertex> VisitedVetecies { get; set; }
    }
}