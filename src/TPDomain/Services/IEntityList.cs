using TPDomain.Models;
using System.Collections.Generic;

namespace TPDomain.Services
{
    public interface IEntityList
    {
        List<Availability> GetAvailabilities(bool eager = false);

    }
}
