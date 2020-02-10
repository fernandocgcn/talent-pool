using TPDomain.Models;
using System.Collections.Generic;

namespace TPDomain.Services
{
    public interface IDeveloperService
    {
        ICollection<Developer> GetDevelopers();
        Developer Get(int id);
        int Delete(int id);
        int Add(Developer developer, ICollection<Availability> availabilities);
        int Update(Developer developer, ICollection<Availability> availabilities);
    }
}
