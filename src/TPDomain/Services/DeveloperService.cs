using Kernel.Extensions;
using EntityFramework.Data;
using EntityFramework.Validations;
using EntityFramework.Resources;
using TPDomain.DataTransferObjects;
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

        public DeveloperDto GetDeveloperDto(int id)
        {
            return new DeveloperDto
            {
                Developer = _repository.GetByKey<Developer>(id),
                Availabilities = _repository.GetDbSet<DeveloperAvailability>()
                    .Where(da => da.Developer.DeveloperId == id)
                    .Select(da => da.Availability)?.ToArray(),
                WorkingTimes = _repository.GetDbSet<DeveloperWorkingTime>()
                    .Where(da => da.Developer.DeveloperId == id)
                    .Select(da => da.WorkingTime)?.ToArray()
            };
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

        public int Add(DeveloperDto developerDto)
        {
            if (developerDto == null)
                throw new ArgumentNullException(nameof(developerDto));
            _dataAnnotationValidator.Validate(developerDto.Developer);

            var existingDeveloper = _repository.GetByKey<Developer>(developerDto.Developer.DeveloperId);
            if (existingDeveloper != null)
            {
                throw new ValidationException(typeof(DataMessages).GetMessage("ErrorMessage_RecordFound"));
            }
            if (developerDto.Availabilities == null || developerDto.Availabilities.Count == 0)
            {
                throw new ValidationException(typeof(DataMessages).GetMessage("ErrorMessage_Required", "Disponibilidades"));
            }
            if (developerDto.WorkingTimes == null || developerDto.WorkingTimes.Count == 0)
            {
                throw new ValidationException(typeof(DataMessages).GetMessage("ErrorMessage_Required", "Horários para Trabalhar"));
            }

            _repository.Add(developerDto.Developer);
            foreach (var availability in developerDto.Availabilities)
            {
                _repository.Attach(availability);
                _repository.Add(
                    new DeveloperAvailability()
                    {
                        Availability = availability,
                        Developer = developerDto.Developer
                    });
            }
            foreach (var workingTime in developerDto.WorkingTimes)
            {
                _repository.Attach(workingTime);
                _repository.Add(
                    new DeveloperWorkingTime()
                    {
                        WorkingTime = workingTime,
                        Developer = developerDto.Developer
                    });
            }

            return _repository.Commit();
        }

        public int Update(DeveloperDto developerDto)
        {
            if (developerDto == null)
                throw new ArgumentNullException(nameof(developerDto));
            _repository.Detach(developerDto.Developer);
            _dataAnnotationValidator.Validate(developerDto.Developer);

            var existingDeveloper = _repository.GetByKey<Developer>(developerDto.Developer.DeveloperId);
            if (existingDeveloper == null)
            {
                throw new ValidationException(typeof(DataMessages).GetMessage("ErrorMessage_RecordNotFound"));
            }
            if (developerDto.Availabilities == null || developerDto.Availabilities.Count == 0)
            {
                throw new ValidationException(typeof(DataMessages).GetMessage("ErrorMessage_Required", "Disponibilidades"));
            }
            if (developerDto.WorkingTimes == null || developerDto.WorkingTimes.Count == 0)
            {
                throw new ValidationException(typeof(DataMessages).GetMessage("ErrorMessage_Required", "Horários para Trabalhar"));
            }

            _repository.Overwrite(existingDeveloper, developerDto.Developer);

            _repository.Delete<DeveloperAvailability>
                (da => da.Developer.Equals(existingDeveloper));
            foreach (var availability in developerDto.Availabilities)
            {
                _repository.Attach(availability);
                _repository.Add(
                    new DeveloperAvailability()
                    {
                        Availability = availability,
                        Developer = existingDeveloper
                    });
            }

            _repository.Delete<DeveloperWorkingTime>
                (da => da.Developer.Equals(existingDeveloper));
            foreach (var workingTime in developerDto.WorkingTimes)
            {
                _repository.Attach(workingTime);
                _repository.Add(
                    new DeveloperWorkingTime()
                    {
                        WorkingTime = workingTime,
                        Developer = existingDeveloper
                    });
            }

            return _repository.Commit();
        }
    }
}
