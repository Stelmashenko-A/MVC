using System.Collections.Generic;
using AntAlgorithm.Graph;

namespace AntAlgorithm.Ants
{
    internal interface IAnt
    {
        IList<IVertex> VisitedVetecies { get; set; }
    }
}