using EntityFramework.Data;
using TPDomain.Models;
using System.Collections.Generic;

namespace TPDomain.Services
{
    public class EntityList : IEntityList
    {
        private readonly IUnitOfWork _unitOfWork;

        public EntityList(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Availability> GetAvailabilities(bool eager = false)
        {
            return _unitOfWork.GetAll<Availability>(eager);
        }
    }
}
