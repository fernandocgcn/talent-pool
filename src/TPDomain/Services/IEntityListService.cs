using TPDomain.Models;
using System.Collections.Generic;

namespace TPDomain.Services
{
    public interface IEntityListService
    {
        List<Availability> GetAvailabilities();
        List<WorkingTime> GetWorkingTimes();
        List<Knowledge> GetKnowledges();
    }
}
