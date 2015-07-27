using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Repository
{
    public interface IRepository<T> : IDisposable
    {
        IQueryable<T> GetAll(); // получение всех объектов
        T Get(int id); // получение одного объекта по id
        void Delete(int id); // удаление объекта по id
        void Save();  // сохранение изменений
    }
}

