using MVC.Models;

namespace MVC.Repository
{
    public interface IArrayRepository : IRepository<Arrays>
    {
    }

    internal class ArrayRepository : Repository<Arrays>, IArrayRepository
    {
    }
}
