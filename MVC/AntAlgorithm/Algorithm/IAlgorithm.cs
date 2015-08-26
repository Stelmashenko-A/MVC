namespace AntAlgorithm.Algorithm
{
    public interface IAlgorithm<in TIn, out TOut>
    {
        TOut Calculate(TIn input);
    }
}
