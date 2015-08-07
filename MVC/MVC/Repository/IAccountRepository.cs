﻿using MVC.Authentication;
using MVC.Models;

namespace MVC.Repository
{
    interface IAccountRepository:IRepository<User>
    {
        User GetUser(string name, string passwordHash);
        AccountRepositoryState AddUnique(User model);
    }
}