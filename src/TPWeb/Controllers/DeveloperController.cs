using TPDomain.Models;
using TPDomain.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TPWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeveloperController : ControllerBase
    {
        private readonly ILogger<DeveloperController> _logger;
        private readonly IDeveloperService _developerService;

        public DeveloperController(ILogger<DeveloperController> logger,
            IDeveloperService developerService)
        {
            _logger = logger;
            _developerService = developerService;
        }

        [HttpGet]
        public IEnumerable<Developer> GetDevelopers()
        {
            return _developerService.GetDevelopers();
        }

        [HttpPost]
        public int Save(Developer developer)
        {
            return _developerService.Save(developer, developer.DeveloperId == 0);
        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _developerService.Delete(_developerService.Get(id));
        }
    }
}
