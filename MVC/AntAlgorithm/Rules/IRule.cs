namespace AntAlgorithm.Rules
{
    internal interface IRule<in TIn, out TOut>
    {
        TOut Proccess(TIn input);
    }
}