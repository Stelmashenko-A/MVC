using System;
using System.Collections.Generic;
using System.Linq;
using AntAlgorithm.Ants;
using AntAlgorithm.Graph;
using AntAlgorithm.Rules;

namespace AntAlgorithm.Algorithm
{
    internal class StandartAlgorithm : IStandartAntAlgorithm
    {

        private IList<IAnt> _ants;
        private readonly IAntFactory _antFactory;
        private readonly IDictionary<Type, ISelectRule> _rules;
        private readonly IDictionary<Type, IIncrimentRule> _updateRules;
        private readonly IProber _prober;
        private Path _minPathLength = new Path(double.MaxValue); //забыл даблмакс

        private IList<IVertex> _result = new List<IVertex>();
        private int _currentIteration;
        private int _currentIterationNoChanges;

        public StandartAlgorithm(IAntFactory antFactory, IDictionary<Type, ISelectRule> rules, IProber prober,
            IDictionary<Type, IIncrimentRule> updateRules, int maxIterationsNoChanges, int maxIterations)
        {
            _antFactory = antFactory;
            _rules = rules;
            _prober = prober;
            _updateRules = updateRules;
            MaxIterationsNoChanges = maxIterationsNoChanges;
            MaxIterations = maxIterations;
        }

        public IList<IVertex> Calculate(IGraph input)
        {
            SetDefaultPheramone(input);
            while (!IsFinished)
            {
                _ants = _antFactory.GeneratePaulation(input.Vertecies.Count);
                SetPositions(input);
                foreach (var ant in _ants)
                {
                    Travel(ant, input);
                }
                UpdateMinPath(input);
                UpdatePheramone(input);
                _currentIteration++;
            }
            return _result;
        }

        protected void SetDefaultPheramone(IGraph input)
        {
            foreach (var edge in input.Edges)
            {
                edge.Mark.Pheromone = new Pheromone() {Value = 10};
            }
        }

        protected void UpdatePheramone(IGraph input)
        {
            foreach (var ant in _ants)
            {
                foreach (var item in input.GetEdgePath(ant.VisitedVetecies))
                {
                    item.Mark = _updateRules[ant.GetType()].Proccess(item.Mark);
                }
            }
        }

        protected bool IsFinished
        {
            get
            {
                if (_currentIteration == MaxIterations) return true;
                return _currentIterationNoChanges == MaxIterationsNoChanges;
            }
        }

        public int MaxIterationsNoChanges { get; private set; }

        public int MaxIterations { get; private set; }

        protected void SetPositions(IGraph input)
        {
            for (var i = 0; i < input.Vertecies.Count; i++)
            {
                _ants[i].VisitedVetecies.Add(input.Vertecies[i]);
            }
        }

        protected void Travel(IAnt ant, IGraph input)
        {
            while (true)
            {
                var allPossibleVertecies = input.GetSibilings(ant.VisitedVetecies.Last());
                foreach (var currentNode in ant.VisitedVetecies)
                {
                    if (allPossibleVertecies.ContainsKey(currentNode))
                    {
                        allPossibleVertecies.Remove(currentNode);
                    }
                }
                var probes = allPossibleVertecies.Keys.ToDictionary(vertex => vertex,
                    vertex => _prober.GetProb(allPossibleVertecies[vertex]));
                if (probes.Count == 0)
                {
                    ant.VisitedVetecies.Add(ant.VisitedVetecies.First());
                    return;
                }
                ant.VisitedVetecies.Add(_rules[ant.GetType()].Proccess(probes));
            }
        }

        protected void UpdateMinPath(IGraph graph)
        {
            var isChanged = false;
            foreach (var ant in _ants)
            {
                if (ant.VisitedVetecies.First() == ant.VisitedVetecies.Last() && ant.VisitedVetecies.Count != 1)
                {
                    var path = graph.CalculatePath(ant.VisitedVetecies);
                    if (path < _minPathLength)
                    {
                        _minPathLength = path;
                        _result = ant.VisitedVetecies;
                        _currentIterationNoChanges = 0;
                        isChanged = true;
                    }
                }
                if (!isChanged)
                {
                    _currentIterationNoChanges++;
                }
            }
        }
    }
}