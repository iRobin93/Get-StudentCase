using Get_StudentCase.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Get_StudentCase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentStatusController : ControllerBase
    {
       

        private readonly ILogger<StudentStatusController> _logger;

        public StudentStatusController(ILogger<StudentStatusController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetStudentStatus")]
        public void Get()
        {

        }
    }
}
