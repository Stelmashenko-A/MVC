using System.Linq;
using MVC.DataBase;

namespace MVC.Repository
{
    internal abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataBase.NewDataBase _newDataBaseContext = new DataBase.NewDataBase();

        public void Dispose()
        {
            //todo: спросить про dispose
        }

        public IQueryable<T> GetAll()
        {
            return _newDataBaseContext.Set<T>().AsQueryable();
        }

        public T Get(int id)
        {
            return _newDataBaseContext.Set<T>().Find(id);
        }

        public void Delete(int id)
        {
            //todo: спросить про сохранение базы, про создание абстрактного класса
            _newDataBaseContext.Set<T>().Remove(_newDataBaseContext.Set<T>().Find(id));

        }

        public void Save()
        {
            _newDataBaseContext.SaveChanges();
        }
    }
}