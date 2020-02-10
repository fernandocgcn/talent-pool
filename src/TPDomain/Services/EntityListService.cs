using EntityFramework.Data;
using TPDomain.Models;
using System;
using System.Collections.Generic;

namespace TPDomain.Services
{
    public class EntityListService : IEntityListService
    {
        private readonly IRepository _repository;

        public EntityListService(IRepository repository)
        {
            _repository = repository ?? 
                throw new ArgumentNullException(nameof(repository));
        }

        public ICollection<Availability> GetAvailabilities()
        {
            return _repository.GetAll<Availability>();
        }

        public ICollection<Knowledge> GetKnowledges()
        {
            return _repository.GetAll<Knowledge>();
        }

        public ICollection<WorkingTime> GetWorkingTimes()
        {
            return _repository.GetAll<WorkingTime>();
        }
    }
}
