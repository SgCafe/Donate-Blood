using DonateBlood.Application.Services.Donations;
using Microsoft.AspNetCore.Mvc;

namespace Donate_blood.Controllers
{

    [Route("api/donation")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private readonly IDonationsService _service;
        public DonationController(IDonationsService service)
        {
            _service = service;
        }

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
