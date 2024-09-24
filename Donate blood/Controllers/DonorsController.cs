using Microsoft.AspNetCore.Mvc;

namespace Donate_blood.Controllers
{

    [Route("api/donors")]
    [ApiController]
    public class DonorsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{search}")]
        public IActionResult GetByType(string search = "")
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            return NoContent();
        }
    }
}
