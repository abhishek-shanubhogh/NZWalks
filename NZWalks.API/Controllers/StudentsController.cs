using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalks.API.Controllers
{
    //Https://locathost:<portnumber>/api/Students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //get: Https://locathost:<portnumber>/api/Students
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] studentsName = new string[] { "abhi", "nivrut", "rajath", "emily" };
            return Ok(studentsName);
        }
    }
}
