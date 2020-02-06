using TPDomain.Models;
using System.Collections.Generic;

namespace TPDomain.Services
{
    public interface IDeveloperService
    {
        List<Developer> GetDevelopers();
        Developer Get(int id);
        int Delete(int id);
        int Add(Developer developer);
        int Update(Developer developer);
    }
}
