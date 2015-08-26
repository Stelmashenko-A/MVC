﻿using System;
using System.Linq;

namespace MVC.Repository
{
    public interface IRepository<T> : IDisposable
    {
        IQueryable<T> GetAll();
        T Get(int id);
        void Delete(int id);
        void Save();
        void Add(T obj);
    }
}

