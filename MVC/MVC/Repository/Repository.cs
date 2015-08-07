using System.Data.Entity;
using System.Linq;
using MVC.DataBase;

namespace MVC.Repository
{
    internal abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ForMvc NewDataBaseContext = new ForMvc();

        public void Dispose()
        {
            //todo: спросить про dispose
        }

        public IQueryable<T> GetAll()
        {
            return NewDataBaseContext.Set<T>().AsQueryable();
        }

        public T Get(int id)
        {
            return NewDataBaseContext.Set<T>().Find(id);
        }

        public void Delete(int id)
        {
            //todo: спросить про сохранение базы, про создание абстрактного класса
            NewDataBaseContext.Set<T>().Remove(NewDataBaseContext.Set<T>().Find(id));
            NewDataBaseContext.SaveChanges();
        }

        public void Save()
        {
            NewDataBaseContext.SaveChanges();
        }

        public void Add(T obj)
        {
            NewDataBaseContext.Set<T>().Attach(obj);
            NewDataBaseContext.Entry(obj).State=EntityState.Added;
            NewDataBaseContext.SaveChanges();
        }
    }
}