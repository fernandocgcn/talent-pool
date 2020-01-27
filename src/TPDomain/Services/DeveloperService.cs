using EntityFramework.Data;
using TPDomain.Models;
using System.Collections.Generic;

namespace TPDomain.Services
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeveloperService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Developer Get(int id)
        {
            return _unitOfWork.Get<Developer>(id);
        }

        public List<Developer> GetDevelopers()
        {
            return _unitOfWork.GetAll<Developer>();
        }

        public int Delete(Developer developer)
        {
            _unitOfWork.Delete(developer);
            return _unitOfWork.Commit();
        }

        public int Save(Developer developer, bool isNew)
        {
            _unitOfWork.Save(developer, isNew);
            return _unitOfWork.Commit();
        }
    }
}
