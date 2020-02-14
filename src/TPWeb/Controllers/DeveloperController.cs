using TPModel.Models;
using TPDomain.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TPWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperService _developerService;

        public DeveloperController(IDeveloperService developerService)
        {
            _developerService = developerService;
        }

        [HttpGet]
        public IEnumerable<Developer> GetAll()
        {
            return _developerService.GetDevelopers();
        }

        [HttpPost]
        public int Save(DeveloperDto developerDto)
        {
            if (developerDto?.Developer?.DeveloperId == 0)
                return _developerService.Add(developerDto);
            else
                return _developerService.Update(developerDto);
        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _developerService.Delete(id);
        }

        [HttpGet]
        [Route("id/{id}")]
        public DeveloperDto GetDeveloper(int id)
        {
            return _developerService.GetDeveloperDto(id);
        }
    }
}
