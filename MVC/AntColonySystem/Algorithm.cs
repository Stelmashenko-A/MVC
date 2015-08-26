using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Grsu.Lab.Aoc.Contracts;

namespace AntColonySystem
{
    class Algorithm : IAlgorithm
    {
        public IGraph Graph { get; set; }
        public IList<IAnt> Ants { get; set; }
        public IList<INode> MinPath { get; set; }

        protected Func<IAnt, IGraph, INode> Role;
        protected IAntFactory AntFactory { get; set; }
        public int CurrentIteration { get; set; }
        public void Run()
        {
            while (!IsFinished())
            {
                Ants = AntFactory.Create(Graph.Nodes.Count);
                SetStartPositions();
                foreach (var ant in Ants)
                {
                    AntTravel(ant);
                }
                var oldMinPath = MinPath;
                CheckForMinPath();
                if (Equals(CalculatePathValue(MinPath), CalculatePathValue(oldMinPath))) CurrentIterationNoChanges++;
                else CurrentIterationNoChanges = 0;
                UpdateGeneration();
                CurrentIteration++;
                Ants.Clear();
            }
        }
        public INode GetNextNode(object item)
        {
            var ant = item as IAnt;
            return ant != null ? Role.Invoke(ant, Graph) : null;
        }
        public int CurrentIterationNoChanges { get; set; }
        public void UpdateGeneration()
        {
            foreach (var ant in Ants)
            {
                for (int currentStep = 1; currentStep < ant.VisitedNodes.Count; currentStep++)
                {
                    Graph.Edges.First(
                        edge => edge.Begin == ant.VisitedNodes[currentStep - 1].Id &&
                                edge.End == ant.VisitedNodes[currentStep].Id).Pheromone += Pheromone;
                }
            }
        }

        public bool IsFinished()
        {
            throw new System.NotImplementedException();
        }

       

        private void SetStartPositions()
        {
            for (var i = 0; i < Graph.Nodes.Count;i++)
            {
                Ants[i].VisitedNodes.Add(Graph.Nodes[i]);
            }
        }
        public Stream Result()
        {
            throw new System.NotImplementedException();
        }
        public void AntTravel(IAnt ant)
        {
            while (ant.VisitedNodes.Last() != ant.VisitedNodes.First() || ant.VisitedNodes.Count == 1)
            {
                ant.VisitedNodes.Add(GetNextNode(ant));
            }
        }
        private void CheckForMinPath()
        {
            foreach (var ant in Ants)
            {
                if (CalculatePathValue(ant.VisitedNodes) < CalculatePathValue(MinPath)) MinPath = ClonePath(ant.VisitedNodes);
            }
        }
        private double CalculatePathValue(IList<INode> path)
        {
            var value = 0D;
            for (var currentStep = 1; currentStep < path.Count; currentStep++)
            {
                value += Graph.Edges.First(
                    edge => edge.Begin == path[currentStep - 1].Id &&
                            edge.End == path[currentStep].Id).HeuristicInformation;
            }
            return value;
        }

        private static IList<INode> ClonePath(IList<INode> obj)
        {
            object objResult;
            using (var ms = new MemoryStream())
            {
                var bf = new BinaryFormatter();
                bf.Serialize(ms, obj);

                ms.Position = 0;
                objResult = bf.Deserialize(ms);
            }
            return objResult as IList<INode>;
        }
        
    }
}
