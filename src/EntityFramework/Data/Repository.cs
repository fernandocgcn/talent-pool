﻿using Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFramework.Data
{
    public class Repository : IRepository
    {
        private readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext ?? 
                throw new ArgumentNullException(nameof(dbContext));
        }

        public T GetByKey<T>(params object[] keyValues) where T : class
        {
            T entity = _dbContext.Find<T>(keyValues);
            if (entity != null)
            {
                _dbContext.Entry(entity).Reload();
                LoadParent(entity);
            }
            return entity;
        }

        public ICollection<T> GetAll<T>(bool isEager) where T : class
        {
            return IncludeAll<T>(isEager).AsNoTracking().ToList();
        }

        public void Add<T>(T entity) where T : class
        {
            _dbContext.Add(entity);
        }

        public void Delete<T>(T attachedEntity) where T : class
        {
            _dbContext.Remove(attachedEntity);
        }

        public void Delete<T>(Func<T, bool> func) where T : class
        {
            _dbContext.RemoveRange(_dbContext.Set<T>().Where(func));
        }

        public void Overwrite<T>(T oldEntity, T newEntity) where T : class
        {
            _dbContext.Entry(oldEntity).CurrentValues.SetValues(newEntity);
        }

        public void Detach<T>(T entity) where T : class
        {
            if (entity != null && _dbContext.Entry(entity) != null)
                _dbContext.Entry(entity).State = EntityState.Detached;
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public void RollBack()
        {
            var changedEntries = _dbContext.ChangeTracker.Entries()
                .Where(entry => entry.State == EntityState.Added || 
                        entry.State == EntityState.Modified ||
                        entry.State == EntityState.Deleted)
                .Reverse();
            foreach (var entry in changedEntries)
                entry.State = EntityState.Detached;
        }

        public DbSet<T> GetDbSet<T>() where T : class
        {
            return _dbContext.Set<T>();
        }

        private void LoadParent<T>(T entity) where T : class
        {
            foreach (var navigation in _dbContext.Entry(entity).Navigations)
            {
                navigation.Load();
                var parent = navigation.CurrentValue;
                if (parent != null)
                {
                    LoadParent(parent);
                }
            }
        }

        private IQueryable<T> IncludeAll<T>(bool isEager) where T : class
        {
            var query = _dbContext.Set<T>().AsQueryable();
            if (isEager)
            {
                string[] includes = GetIncludes(typeof(T));
                if (!includes.IsNullOrEmpty())
                    query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query;
        }

        private string[] GetIncludes(Type type, string parentProperty = "", params Type[] parentsType)
        {
            List<string> includes = new List<string>();
            IEntityType EntityType = _dbContext.Model.FindEntityType(type);
            parentsType = parentsType.Concat(new Type[] { type }).ToArray();
            foreach (var property in EntityType.GetNavigations())
            {
                if (EntityType.Equals(property.ForeignKey.DeclaringEntityType))
                {
                    includes.Add(parentProperty + property.Name);
                    if (!parentsType.Contains(property.FieldInfo.FieldType))
                    {
                        includes.AddRange(GetIncludes(property.FieldInfo.FieldType,
                            parentProperty + property.Name + ".", parentsType));
                    }
                }
            }
            return includes.ToArray();
        }
    }
}
