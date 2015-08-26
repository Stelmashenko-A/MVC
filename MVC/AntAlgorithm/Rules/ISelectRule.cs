using System.Collections.Generic;
using AntAlgorithm.Graph;

namespace AntAlgorithm.Rules
{
    internal interface ISelectRule : IRule<Dictionary<IVertex, double>, IVertex>
    {
    }
}
