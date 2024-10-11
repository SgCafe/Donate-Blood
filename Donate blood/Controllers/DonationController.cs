using DonateBlood.Application.Models.DonationsDto;
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
            var result = _service.GetAll();

            if (result is null)
            {
                return BadRequest(result.Data);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);

            if (result is null)
            {
                return BadRequest(result.Data);
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(CreateDonationInputModel model)
        {
            var result = _service.Post(model);

            return NoContent();
        }
    }
}
