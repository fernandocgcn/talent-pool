using Kernel.Extensions;
using EntityFramework.Data;
using EntityFramework.Validations;
using EntityFramework.Resources;
using TPDomain.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
        
        public ICollection<Developer> GetDevelopers()
        {
            return _repository.GetAll<Developer>();
        }

        public Developer Get(int id)
        {
            return _repository.GetByKey<Developer>(id);
        }

        public int Delete(int id)
        {
            var existingDeveloper = _repository.GetByKey<Developer>(id);
            if (existingDeveloper == null)
            {
                throw new ValidationException(typeof(DataMessages).GetMessage("ErrorMessage_RecordNotFound"));
            }

            try
            {
                _repository.Delete(existingDeveloper);
                return _repository.Commit();
            }
            catch (DbUpdateException)
            {
                throw new Exception(typeof(DataMessages).GetMessage("ErrorMessage_RecordRelated"));
            }
        }

        public int Add(Developer developer, ICollection<Availability> availabilities)
        {
            _dataAnnotationValidator.Validate(developer);

            var existingDeveloper = _repository.GetByKey<Developer>(developer.DeveloperId);
            if (existingDeveloper != null)
            {
                throw new ValidationException(typeof(DataMessages).GetMessage("ErrorMessage_RecordFound"));
            }
            if (availabilities == null || availabilities.Count == 0)
            {
                throw new ValidationException(typeof(DataMessages).GetMessage("ErrorMessage_Required", "Disponibilidades"));
            }

            _repository.Add(developer);
            foreach (var availability in availabilities)
            {
                _repository.Attach(availability);
                _repository.Add(
                    new DeveloperAvailability()
                    {
                        Availability = availability,
                        Developer = developer
                    });
            }

            return _repository.Commit();
        }

        public int Update(Developer developer, ICollection<Availability> availabilities)
        {
            _repository.Detach(developer);
            _dataAnnotationValidator.Validate(developer);

            var existingDeveloper = _repository.GetByKey<Developer>(developer.DeveloperId);
            if (existingDeveloper == null)
            {
                throw new ValidationException(typeof(DataMessages).GetMessage("ErrorMessage_RecordNotFound"));
            }
            if (availabilities == null || availabilities.Count == 0)
            {
                throw new ValidationException(typeof(DataMessages).GetMessage("ErrorMessage_Required", "Disponibilidades"));
            }

            _repository.Overwrite(existingDeveloper, developer);
            _repository.Delete<DeveloperAvailability>
                (da => da.Developer.Equals(existingDeveloper));
            foreach (var availability in availabilities)
            {
                _repository.Attach(availability);
                _repository.Add(
                    new DeveloperAvailability()
                    {
                        Availability = availability,
                        Developer = existingDeveloper
                    });
            }

            return _repository.Commit();
        }
    }
}
