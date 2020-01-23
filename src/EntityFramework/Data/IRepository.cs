using System.Collections.Generic;

namespace EntityFramework.Data
{
    public interface IRepository
    {
        string[] GetKeyProperties<T>(T entity) where T : class;

        object[] GetKeyValues<T>(T entity) where T : class;

        T GetByKey<T>(params object[] keyValues) where T : class;

        List<T> GetAll<T>(bool isEager = false) where T : class;

        void Add<T>(T entity) where T : class;

        void Delete<T>(T attachedEntity) where T : class;

        void Overwrite<T>(T oldEntity, T newEntity) where T : class;

        void Update<T>(T attachedEntity) where T : class;

        void Detach<T>(T attachedEntity) where T : class;

        int Commit();
    }
}
