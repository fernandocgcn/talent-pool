using TPModel.Models;
using System.Collections.Generic;

namespace TPDomain.Services
{
    public interface IEntityListService
    {
        ICollection<Availability> GetAvailabilities();
        ICollection<WorkingTime> GetWorkingTimes();
        ICollection<Knowledge> GetKnowledges();
    }
}
