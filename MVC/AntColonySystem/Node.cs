using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grsu.Lab.Aoc.Contracts;

namespace AntColonySystem
{
    internal class Node : INode
    {
        public bool Equals(INode other)
        {
            throw new NotImplementedException();
        }

        public int Id { get; set; }
    }
}