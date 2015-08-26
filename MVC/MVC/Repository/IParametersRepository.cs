using MVC.Models;

namespace MVC.Repository
{
    public interface IParametersRepository : IRepository<Parameters>
    {
    }

    internal class ParametersRepository : Repository<Parameters>, IParametersRepository
    {
    }
}