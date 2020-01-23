using EntityFramework.Data;
using TPDomain.Models;
using System.Collections.Generic;

namespace TPDomain.Services
{
    public class EntityListService : IEntityListService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EntityListService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Availability> GetAvailabilities()
        {
            return _unitOfWork.GetAll<Availability>();
        }

        public List<Knowledge> GetKnowledges()
        {
            return _unitOfWork.GetAll<Knowledge>();
        }

        public List<WorkingTime> GetWorkingTimes()
        {
            return _unitOfWork.GetAll<WorkingTime>();
        }
    }
}
