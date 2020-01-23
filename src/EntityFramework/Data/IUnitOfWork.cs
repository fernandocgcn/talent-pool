using System.Collections.Generic;

namespace EntityFramework.Data
{
    public interface IUnitOfWork
    {
        T Get<T>(params object[] keyValues) where T : class;

        List<T> GetAll<T>(bool eager = false) where T : class;

        bool Delete<T>(T entity) where T : class;

        bool Save<T>(T entity, bool isNew) where T : class;

        int Commit();
    }
}
