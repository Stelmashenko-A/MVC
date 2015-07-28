using System.Linq;
using MVC.DataBase;
using MVC.Models;

namespace MVC.Repository
{
    public interface IResultRepository:IRepository<Results>
    {
    }

    class ResultRepositoty : Repository<Results>, IResultRepository
    {

    }
}