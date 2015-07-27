using System.Linq;
using MVC.DataBase;
using MVC.Models;

namespace MVC.Repository
{
    public interface IResultRepository:IRepository<Result>
    {
    }

    class ResultRepositoty : Repository<Result>, IResultRepository
    {

    }
}