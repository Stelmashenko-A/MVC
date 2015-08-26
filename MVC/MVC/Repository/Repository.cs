using System.Data.Entity;
using System.Linq;
using MVC.AOP;
using MVC.DataBase;

namespace MVC.Repository
{
    internal abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ForMvc NewDataBaseContext = new ForMvc();

        public void Dispose()
        {
            if (NewDataBaseContext != null)
            {
                NewDataBaseContext.Dispose();
            }
        }

        [TransactionAspect]
        public IQueryable<T> GetAll()
        {
            return NewDataBaseContext.Set<T>().AsQueryable();
        }

        [TransactionAspect]
        public T Get(int id)
        {
            return NewDataBaseContext.Set<T>().Find(id);
        }

        [TransactionAspect]
        public void Delete(int id)
        {
            NewDataBaseContext.Set<T>().Remove(NewDataBaseContext.Set<T>().Find(id));
            NewDataBaseContext.SaveChanges();
        }

        [TransactionAspect]
        public void Save()
        {
            NewDataBaseContext.SaveChanges();
        }

        [TransactionAspect]
        public void Add(T obj)
        {
            NewDataBaseContext.Set<T>().Attach(obj);
            NewDataBaseContext.Entry(obj).State = EntityState.Added;
            NewDataBaseContext.SaveChanges();
        }
    }
}