﻿using Common.Extensions;
using Common.Resources;
using EntityFramework.Data;
using EntityFramework.Validations;
using TPModel.Models;
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

        public DeveloperDto GetDeveloperDto(int id)
        {
            return new DeveloperDto
            {
                Developer = _repository.GetByKey<Developer>(id),
                Availabilities = _repository.GetDbSet<DeveloperAvailability>()
                    .Where(da => da.Developer.DeveloperId == id)
                    .Select(da => da.Availability)?.ToArray(),
                WorkingTimes = _repository.GetDbSet<DeveloperWorkingTime>()
                    .Where(wt => wt.Developer.DeveloperId == id)
                    .Select(wt => wt.WorkingTime)?.ToArray(),
                KnowledgeDtos = _repository.GetDbSet<DeveloperKnowledge>()
                    .Where(k => k.Developer.DeveloperId == id)
                    .Select(k => 
                        new KnowledgeDto { Knowledge = k.Knowledge, Rate = k.Rate })
                    ?.ToArray()
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
                _repository.RollBack();
                throw new Exception(typeof(DataMessages).GetMessage("ErrorMessage_RecordRelated"));
            }
        }

        public int Add(DeveloperDto developerDto)
        {
            try
            {
                _dataAnnotationValidator.Validate(developerDto?.Developer);
                _repository.Add(developerDto.Developer);

                int index = 0;
                do
                {
                    var availability =
                        developerDto.Availabilities?.ElementAtOrDefault(index++);
                    Add(developerDto.Developer, availability);
                } while (index < developerDto.Availabilities?.Count);

                index = 0;
                do
                {
                    var workingTime =
                        developerDto.WorkingTimes?.ElementAtOrDefault(index++);
                    Add(developerDto.Developer, workingTime);
                } while (index < developerDto.WorkingTimes?.Count);

                index = 0;
                do
                {
                    var knowledgeDto =
                        developerDto.KnowledgeDtos?.ElementAtOrDefault(index++);
                    Add(developerDto.Developer, knowledgeDto);
                } while (index < developerDto.KnowledgeDtos?.Count);
            }
            catch (Exception)
            {
                _repository.RollBack();
                throw;
            }
            return _repository.Commit();
        }

        public int Update(DeveloperDto developerDto)
        {
            try
            {
                _dataAnnotationValidator.Validate(developerDto?.Developer);
                _repository.Detach(developerDto?.Developer);
                var existingDeveloper = _repository.GetByKey<Developer>(developerDto.Developer.DeveloperId);
                _repository.Overwrite(existingDeveloper, developerDto.Developer);

                _repository.Delete<DeveloperAvailability>
                    (da => existingDeveloper.Equals(da.Developer));
                int index = 0;
                do
                {
                    var availability =
                        developerDto.Availabilities?.ElementAtOrDefault(index++);
                    Add(existingDeveloper, availability);
                } while (index < developerDto.Availabilities?.Count);

                _repository.Delete<DeveloperWorkingTime>
                    (da => existingDeveloper.Equals(da.Developer));
                index = 0;
                do
                {
                    var workingTime =
                        developerDto.WorkingTimes?.ElementAtOrDefault(index++);
                    Add(existingDeveloper, workingTime);
                } while (index < developerDto.WorkingTimes?.Count);

                _repository.Delete<DeveloperKnowledge>
                    (dk => existingDeveloper.Equals(dk.Developer));
                index = 0;
                do
                {
                    var knowledge =
                        developerDto.KnowledgeDtos?.ElementAtOrDefault(index++);
                    Add(existingDeveloper, knowledge);
                } while (index < developerDto.KnowledgeDtos?.Count);
            }
            catch (Exception)
            {
                _repository.RollBack();
                throw;
            }
            return _repository.Commit();
        }

        private void Add(Developer developer, Availability availability)
        {
            var developerAvailability =
                new DeveloperAvailability()
                {
                    Availability = _repository.GetByKey<Availability>
                        (availability?.AvailabilityId),
                    Developer = developer
                };
            _dataAnnotationValidator.Validate(developerAvailability);
            _repository.Add(developerAvailability);
        }

        private void Add(Developer developer, WorkingTime workingTime)
        {
            var developerWorkingTime =
                new DeveloperWorkingTime()
                {
                    WorkingTime = _repository.GetByKey<WorkingTime>
                        (workingTime?.WorkingTimeId),
                    Developer = developer
                };
            _dataAnnotationValidator.Validate(developerWorkingTime);
            _repository.Add(developerWorkingTime);
        }

        private void Add(Developer developer, KnowledgeDto knowledgeDto)
        {
            var developerKnowledge =
                new DeveloperKnowledge()
                {
                    Knowledge = _repository.GetByKey<Knowledge>
                        (knowledgeDto?.Knowledge?.KnowledgeId),
                    Rate = knowledgeDto?.Rate,
                    Developer = developer
                };
            _dataAnnotationValidator.Validate(developerKnowledge);
            _repository.Add(developerKnowledge);
        }
    }
}
