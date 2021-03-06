﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EntityFramework.Data
{
    public interface IRepository
    {
        T GetByKey<T>(params object[] keyValues) where T : class;
        ICollection<T> GetAll<T>(bool isEager = false) where T : class;
        void Add<T>(T entity) where T : class;
        void Delete<T>(T attachedEntity) where T : class;
        void Delete<T>(Func<T, bool> func) where T : class;
        void Overwrite<T>(T oldEntity, T newEntity) where T : class;
        void Detach<T>(T entity) where T : class;
        int Commit();
        void RollBack();
        DbSet<T> GetDbSet<T>() where T : class;
    }
}
