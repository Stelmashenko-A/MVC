using MVC.Models;

namespace MVC.Repository
{
    public interface IResultRepository : IRepository<Results>
    {
    }

    internal class ResultRepositoty : Repository<Results>, IResultRepository
    {
    }
}