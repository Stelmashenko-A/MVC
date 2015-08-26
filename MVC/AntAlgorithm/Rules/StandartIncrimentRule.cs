using AntAlgorithm.Ants;
using AntAlgorithm.Graph;

namespace AntAlgorithm.Rules
{
    internal class StandartIncrimentRule : IIncrimentRule
    {
        private readonly Pheromone _pheromoneIncriment;

        public StandartIncrimentRule(Pheromone pheromoneIncriment)
        {
            _pheromoneIncriment = pheromoneIncriment;
        }

        public Mark Proccess(Mark input)
        {
            var pheramone = new Pheromone();
            pheramone.Value = input.Pheromone.Value;
            input.Pheromone.Value += _pheromoneIncriment.Value;
            var mark = new Mark(input.Path);
            mark.Pheromone = pheramone;
            return mark;
        }
    }
}