using TPDomain.Models;
using System.Collections.Generic;

namespace TPDomain.Services
{
    public interface IDeveloperService
    {
        Developer Get(int id);
        List<Developer> GetDevelopers();
        int Delete(Developer developer);
        int Save(Developer developer, bool isNew);
    }
}
