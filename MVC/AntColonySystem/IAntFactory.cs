using System.Collections.Generic;
using Grsu.Lab.Aoc.Contracts;

namespace AntColonySystem
{
    interface IAntFactory
    {
        IList<IAnt> Create(int number);
    }
}
