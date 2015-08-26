using System.Collections.Generic;

namespace AntAlgorithm.Ants
{
    internal class AntFactory : IAntFactory
    {
        public IList<IAnt> GeneratePaulation(int number)
        {
            var result = new List<IAnt>();
            for (var i = 0; i < number; i++)
            {
                result.Add(new Ant());
            }
            return result;
        }
    }
}