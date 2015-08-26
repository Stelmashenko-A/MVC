using System.Data.Entity.Core;
using System.Linq;
using MVC.AOP;
using MVC.Models;

namespace MVC.Repository
{
    internal class AccountRepository : Repository<User>, IAccountRepository
    {
        [TransactionAspect]
        public User GetUser(string name, string passHash)
        {
            try
            {
                return NewDataBaseContext.Users
                    .FirstOrDefault(u => u.Name == name && u.Password == passHash);
            }

            catch (EntityException)
            {
                return null;
            }
        }

        [TransactionAspect]
        public AccountRepositoryState AddUnique(User user)
        {
            var tmp = NewDataBaseContext.Users
                .FirstOrDefault(u => u.Name == user.Name && u.Password == user.Password);
            if (tmp != null) return AccountRepositoryState.UserIsNotUnique;

            user.Id = user.GetHashCode();
            NewDataBaseContext.Users.Add(user);
            NewDataBaseContext.SaveChanges();

            user = NewDataBaseContext.Users
                .FirstOrDefault(u => u.Name == user.Name && u.Password == user.Password);

            return user != null ? AccountRepositoryState.Success : AccountRepositoryState.SavingError;
        }
    }
}