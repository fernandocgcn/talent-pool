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
            _repository = repository ?? 
                throw new ArgumentNullException(nameof(repository));
            _dataAnnotationValidator = dataAnnotationValidator ?? 
                throw new ArgumentNullException(nameof(dataAnnotationValidator));
        }
        
        public List<Developer> GetDevelopers()
        {
            return _repository.GetAll<Developer>();
        }

        public Developer Get(int id)
        {
            return _repository.GetByKey<Developer>(id);
        }

        public int Delete(int id)
        {
            var existingEntity = _repository.GetByKey<Developer>(id);
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

        public int Add(Developer entity)
        {
            _dataAnnotationValidator.Validate(entity);

            var existingEntity = _repository.GetByKey<Developer>(entity.DeveloperId);
            if (existingEntity != null)
            {
                throw new Exception(typeof(DataMessages).GetMessage("ErrorMessage_RecordFound"));
            }
            _repository.Add(entity);

            return _repository.Commit();
        }

        public int Update(Developer entity)
        {
            _repository.Detach(entity);
            _dataAnnotationValidator.Validate(entity);

            var existingEntity = _repository.GetByKey<Developer>(entity.DeveloperId);
            if (existingEntity == null)
            {
                throw new Exception(typeof(DataMessages).GetMessage("ErrorMessage_RecordNotFound"));
            }
            _repository.Overwrite(existingEntity, entity);

            return _repository.Commit();
        }
    }
}
