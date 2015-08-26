using System.Collections.Generic;

namespace AntAlgorithm.Ants
{
    internal interface IAntFactory
    {
        IList<IAnt> GeneratePaulation(int number);
    }
}
