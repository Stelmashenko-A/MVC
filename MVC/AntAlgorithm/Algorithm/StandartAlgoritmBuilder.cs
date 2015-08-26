using System;
using System.Collections.Generic;
using AntAlgorithm.Ants;
using AntAlgorithm.Graph;
using AntAlgorithm.Rules;

namespace AntAlgorithm.Algorithm
{
    public class StandartAlgoritmBuilder
    {
        public IAlgorithm<IGraph, IList<IVertex>> GetAlgorithm(double alpha, double beta, int iteration,
            int iterationWithouChanges)
        {
            var random = new Random(DateTime.Today.Date.Millisecond);
            var antFactory = new AntFactory();
            var selectionRules = new Dictionary<Type, ISelectRule> {{typeof (Ant), new SelectRule(random)}};
            var prober = new Prober(alpha, beta);
            var updateRule = new Dictionary<Type, IIncrimentRule>
            {
                {typeof (Ant), new StandartIncrimentRule(new Pheromone() {Value = 0.5})}
            };
            var algorithm = new StandartAlgorithm(antFactory, selectionRules, prober, updateRule, iterationWithouChanges,
                iteration);
            return algorithm;
        }
    }
}
