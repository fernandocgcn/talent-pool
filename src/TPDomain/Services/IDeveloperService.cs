using TPDomain.Models;
using TPDomain.DataTransferObjects;
using System.Collections.Generic;

namespace TPDomain.Services
{
    public interface IDeveloperService
    {
        ICollection<Developer> GetDevelopers();
        Developer Get(int id);
        int Delete(int id);
        int Add(DeveloperDto developerDto);
        int Update(DeveloperDto developerDto);
        DeveloperDto GetDeveloperDto(int id);
    }
}
