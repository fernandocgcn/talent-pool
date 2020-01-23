using Kernel.Extensions;
using EntityFramework.Resources;
using EntityFramework.Validations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EntityFramework.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRepository _repository;
        private readonly IDataAnnotationValidator _dataAnnotationValidator;

        public UnitOfWork(IRepository repository, IDataAnnotationValidator dataAnnotationValidator)
        {
            _repository = repository;
            _dataAnnotationValidator = dataAnnotationValidator;
        }

        public T Get<T>(params object[] keyValues) where T : class
        {
            return _repository.GetByKey<T>(keyValues);
        }

        public List<T> GetAll<T>(bool eager) where T : class
        {
            return _repository.GetAll<T>(eager);
        }

        public bool Delete<T>(T entity) where T : class
        {
            _repository.Detach(entity);
            _dataAnnotationValidator.Validate(entity, true, _repository.GetKeyProperties(entity));
            T existingEntity = _repository.GetByKey<T>(_repository.GetKeyValues(entity));
            if (existingEntity == null)
            {
                return false;
            }
            try
            {
                _repository.Delete(existingEntity);
                return true;
            }
            catch (DbUpdateException)
            {
                throw new Exception(typeof(DataMessages).GetMessage("ErrorMessage_RecordRelated"));
            }
        }

        public bool Save<T>(T entity, bool isNew) where T : class
        {
            _repository.Detach(entity);
            _dataAnnotationValidator.Validate(entity);
            T existingEntity = _repository.GetByKey<T>(_repository.GetKeyValues(entity));
            if (isNew)
            {
                if (existingEntity != null)
                {
                    throw new Exception(typeof(DataMessages).GetMessage("ErrorMessage_RecordFound"));
                }
                _repository.Add(entity);
            }
            else
            {
                if (existingEntity == null)
                {
                    throw new Exception(typeof(DataMessages).GetMessage("ErrorMessage_RecordNotFound"));
                }
                _repository.Overwrite(existingEntity, entity);
            }
            return true;
        }

        public int Commit()
        {
            return _repository.Commit();
        }
    }
}
