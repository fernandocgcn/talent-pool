using TPDomain.Models;
using System.Collections.Generic;

namespace TPDomain.Services
{
    public interface IDeveloperService
    {
        List<Developer> GetDevelopers();
        int Delete(Developer developer);
        int New(Developer developer);
        int Update(Developer developer);
    }
}
