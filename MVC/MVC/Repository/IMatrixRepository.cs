using System.Linq;
using MVC.DataBase;
using MVC.Models;

namespace MVC.Repository
{
    public interface IArrayRepository:IRepository<Arrays>
    {
    }

    class ArrayRepository : Repository<Arrays>,IArrayRepository
    {

        private DataBase.NewDataBase _newDataBaseContext = new DataBase.NewDataBase();

        public void Dispose()
        {
            //todo: спросить про dispose
        }

        public IQueryable<Arrays> GetAll()
        {
            return _newDataBaseContext.Arrays.AsQueryable();
        }

        public Arrays Get(int id)
        {
            return _newDataBaseContext.Arrays.Find(id);
        }

        public void Delete(int id)
        {
            //todo: спросить про сохранение базы, про создание абстрактного класса
            _newDataBaseContext.Arrays.Remove(_newDataBaseContext.Arrays.Find(id));

        }

        public void Save()
        {
            _newDataBaseContext.SaveChanges();
        }
    }
}
