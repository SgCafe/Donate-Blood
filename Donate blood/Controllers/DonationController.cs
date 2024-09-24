using Microsoft.AspNetCore.Mvc;

namespace Donate_blood.Controllers
{

    [Route("api/v1")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }
    }
}
