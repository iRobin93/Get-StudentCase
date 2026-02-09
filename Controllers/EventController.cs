using Get_StudentCase.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Get_StudentCase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
       

        private readonly ILogger<EventController> _logger;

        public EventController(ILogger<EventController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetEvent")]
        public void Get()
        {

        }
    }
}
