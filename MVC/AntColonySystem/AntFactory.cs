using System.Collections.Generic;
using Grsu.Lab.Aoc.Contracts;

namespace AntColonySystem
{
    internal class AntFactory : IAntFactory
    {
        public IList<IAnt> Create(int number)
        {
            var result = new List<IAnt>();
            for (int i = 0; i < number; i++)
            {
                result.Add(new Ant());
            }
            return result;
        }
    }
}
