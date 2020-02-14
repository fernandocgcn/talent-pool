using TPModel.Models;
using TPDomain.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TPWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntityListController : ControllerBase
    {
        private readonly IEntityListService _entityListService;

        public EntityListController(IEntityListService entityListService)
        {
            _entityListService = entityListService;
        }

        [HttpGet]
        [Route("availabilities")]
        public IEnumerable<Availability> GetAvailabilities()
        {
            return _entityListService.GetAvailabilities();
        }

        [HttpGet]
        [Route("knowledges")]
        public IEnumerable<Knowledge> GetKnowledges()
        {
            return _entityListService.GetKnowledges();
        }

        [HttpGet]
        [Route("workingtimes")]
        public IEnumerable<WorkingTime> GetWorkingTimes()
        {
            return _entityListService.GetWorkingTimes();
        }
    }
}
