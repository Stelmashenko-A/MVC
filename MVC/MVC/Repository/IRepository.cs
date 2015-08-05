using System;
using System.Linq;

namespace MVC.Repository
{
    public interface IRepository<T> : IDisposable
    {
        IQueryable<T> GetAll(); // получение всех объектов
        T Get(int id); // получение одного объекта по id
        void Delete(int id); // удаление объекта по id
        void Save();  // сохранение изменений
        void Add(T obj);
    }
}

