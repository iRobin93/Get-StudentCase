using Get_StudentCase.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Get_StudentCase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseStatusController : ControllerBase
    {
       

        private readonly ILogger<CourseStatusController> _logger;

        public CourseStatusController(ILogger<CourseStatusController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCourseStatus")]
        public void Get()
        {

        }
    }
}
