using Kernel.Extensions;
using EntityFramework.Data;
using EntityFramework.Validations;
using EntityFramework.Resources;
using TPDomain.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TPDomain.Services
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IRepository _repository;
        private readonly IDataAnnotationValidator _dataAnnotationValidator;

        public DeveloperService(IRepository repository,
            IDataAnnotationValidator dataAnnotationValidator)
        {
            _repository = repository;
            _dataAnnotationValidator = dataAnnotationValidator;
        }

        public Developer Get(int id)
        {
            return _repository.GetByKey<Developer>(id);
        }

        public List<Developer> GetDevelopers()
        {
            return _repository.GetAll<Developer>();
        }

        public int Delete(Developer entity)
        {
            _repository.Detach(entity);
            _dataAnnotationValidator.Validate(entity, true, _repository.GetKeyProperties(entity));

            var existingEntity = _repository.GetByKey<Developer>(_repository.GetKeyValues(entity));
            if (existingEntity == null)
            {
                throw new Exception(typeof(DataMessages).GetMessage("ErrorMessage_RecordNotFound"));
            }

            try
            {
                _repository.Delete(existingEntity);
                return _repository.Commit();
            }
            catch (DbUpdateException)
            {
                throw new Exception(typeof(DataMessages).GetMessage("ErrorMessage_RecordRelated"));
            }
        }

        public int Save(Developer entity, bool isNew)
        {
            _repository.Detach(entity);
            _dataAnnotationValidator.Validate(entity);

            var existingEntity = _repository.GetByKey<Developer>(_repository.GetKeyValues(entity));
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

            return _repository.Commit();
        }
    }
}
