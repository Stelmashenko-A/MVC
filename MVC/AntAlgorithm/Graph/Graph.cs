﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AntAlgorithm.Graph
{
    public class Graph : IGraph
    {
        public IList<IVertex> Vertecies { get; private set; }
        public IList<IEdge> Edges { get; private set; }

        private readonly IEdge[,] _edges;

        public Graph(double[,] array)
        {
            Vertecies = new List<IVertex>();
            for (var i = 0; i < Math.Sqrt(array.Length); i++)
            {
                Vertecies.Add(new Vertex(i));
            }
            Edges = new List<IEdge>();
            _edges = new IEdge[Vertecies.Count, Vertecies.Count];
            for (var i = 0; i < Vertecies.Count; i++)
            {
                for (var j = 0; j < Vertecies.Count; j++)
                {
                    if (array[i, j].Equals(-1)) continue; //лишний !
                    _edges[i, j] = new Edge(new Mark(new Path(array[i, j])));

                    Edges.Add(_edges[i, j]);
                }
            }
        }

        public Dictionary<IVertex, IEdge> GetSibilings(IVertex vertex)
        {
            var result = new Dictionary<IVertex, IEdge>();
            for (var i = 0; i < Vertecies.Count; i++)
            {
                var edge = _edges[vertex.Number, i];
                // if (edge != null)
                if (edge != null && !edge.Mark.Path.Value.Equals(-1))
                {
                    result.Add(Vertecies[i], edge);
                }
            }
            return result;
        }

        public Path CalculatePath(IList<IVertex> items)
        {
            var path = GetEdgePath(items);
            if (path != null && path.Count != 0)
            {
                return new Path(path.Sum(edge => edge.Mark.Path.Value));
            }
            return new Path(double.MaxValue);
        }

        public IList<IEdge> GetEdgePath(IList<IVertex> items)
        {
            var result = new List<IEdge>();
            if (items.Count == 2 & items.First() == items.Last()) return result;
            for (var i = 0; i < items.Count - 1; i++)
            {
                result.Add(_edges[items[i].Number, items[i + 1].Number]);
            }
            return result;
        }
    }
}