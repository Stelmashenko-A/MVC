using MVC.Models;

namespace MVC.Repository
{
    public interface IParametersRepository:IRepository<Parameters>
    {
    }

    class ParametersRepository : Repository<Parameters>, IParametersRepository
    {
    }
}