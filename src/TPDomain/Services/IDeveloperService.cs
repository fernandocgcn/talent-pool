using TPModel.Models;
using TPDomain.Models;
using System.Collections.Generic;

namespace TPDomain.Services
{
    public interface IDeveloperService
    {
        ICollection<Developer> GetDevelopers();
        int Delete(int id);
        int Add(DeveloperDto developerDto);
        int Update(DeveloperDto developerDto);
        DeveloperDto GetDeveloperDto(int id);
    }
}
