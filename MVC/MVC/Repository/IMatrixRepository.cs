using MVC.Models;

namespace MVC.Repository
{
    public interface IArrayRepository:IRepository<Arrays>
    {
    }

    class ArrayRepository : Repository<Arrays>,IArrayRepository
    {

       
    }
}
