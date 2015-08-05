using MVC.Authentication;
using MVC.Models;

namespace MVC.Repository
{
    interface IAccountRepository:IRepository<LoginModel>
    {
        User GetUser(LoginModel model);
        AccountRepositoryState AddUnique(RegisterModel model);
    }
}