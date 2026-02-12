using Get_StudentCase.Entities;
using Get_StudentCase.Services;
using Microsoft.AspNetCore.Mvc;

namespace Get_StudentCase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpPost(Name = "PostEvent")]
        public async Task<IActionResult> Post([FromBody] Event @event)
        {
            var studentId = await _eventService.CreateEventAsync(@event);

            var response = new Response(200, studentId);
            return Ok(response);
        }
    }

    public record Response(int responses, Guid studentId);
}