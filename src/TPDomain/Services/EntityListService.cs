using EntityFramework.Data;
using TPDomain.Models;
using System.Collections.Generic;

namespace TPDomain.Services
{
    public class EntityListService : IEntityListService
    {
        private readonly IRepository _repository;

        public EntityListService(IRepository repository)
        {
            _repository = repository;
        }

        public List<Availability> GetAvailabilities()
        {
            return _repository.GetAll<Availability>();
        }

        public List<Knowledge> GetKnowledges()
        {
            return _repository.GetAll<Knowledge>();
        }

        public List<WorkingTime> GetWorkingTimes()
        {
            return _repository.GetAll<WorkingTime>();
        }
    }
}
