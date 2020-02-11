using Kernel.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections;
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

        public string[] GetKeyProperties<T>(T entity) where T : class
        {
            object[] objects = GetKey(entity, false);
            string[] strings = ((IEnumerable)objects).Cast<object>()
                .Select(obj => obj.ToString()).ToArray();
            return strings;
        }

        public object[] GetKeyValues<T>(T entity) where T : class
        {
            return GetKey(entity, true);
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
            try
            {
                _dbContext.Add(entity);
            }
            catch (Exception e)
            {
                _dbContext.Entry(entity).State = EntityState.Detached;
                throw e;
            }
        }

        public void Delete<T>(T attachedEntity) where T : class
        {
            try
            {
                _dbContext.Remove(attachedEntity);
            }
            catch (Exception e)
            {
                _dbContext.Entry(attachedEntity).State = EntityState.Detached;
                throw e;
            }
        }

        public void Delete<T>(Func<T, bool> func) where T : class
        {
            _dbContext.RemoveRange(_dbContext.Set<T>().Where(func));
        }

        public void Overwrite<T>(T oldEntity, T newEntity) where T : class
        {
            try
            {
                _dbContext.Entry(oldEntity).CurrentValues.SetValues(newEntity);
            }
            catch (Exception e)
            {
                _dbContext.Entry(oldEntity).State = EntityState.Detached;
                throw e;
            }
        }

        public void Update<T>(T attachedEntity) where T : class
        {
            try
            {
                _dbContext.Update(attachedEntity);
            }
            catch (Exception e)
            {
                _dbContext.Entry(attachedEntity).State = EntityState.Detached;
                throw e;
            }
        }

        private object[] GetKey<T>(T entity, bool isValue) where T : class
        {
            if (entity == null)
            {
                throw new NullReferenceException();
            }
            List<object> values = new List<object>();
            var entry = _dbContext.Entry(entity);
            var primaryKey = entry.Metadata.FindPrimaryKey();
            var keys = primaryKey.Properties.ToDictionary(k => k.Name, k => k.PropertyInfo);
            foreach (var item in keys)
            {
                values.Add(isValue ? item.Value.GetValue(entity) : item.Value.Name);
            }
            return values.ToArray();
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

        public void Detach<T>(T entity) where T : class
        {
            if (entity != null)
                _dbContext.Entry(entity).State = EntityState.Detached;
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public DbSet<T> GetDbSet<T>() where T : class
        {
            return _dbContext.Set<T>();
        }
    }
}
