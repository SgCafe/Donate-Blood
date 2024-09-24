using Microsoft.AspNetCore.Mvc;

namespace Donate_blood.Controllers
{
    [Route("api/bloods")]
    [ApiController]
    public class DonationStockController : ControllerBase
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
