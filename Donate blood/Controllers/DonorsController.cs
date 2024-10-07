using DonateBlood.Application.Models.DonorsDto;
using DonateBlood.Application.Services.Donors;
using Microsoft.AspNetCore.Mvc;

namespace Donate_blood.Controllers
{

    [Route("api/donors")]
    [ApiController]
    public class DonorsController : ControllerBase
    {
        private readonly IDonorsService _service;

        public DonorsController(IDonorsService service)
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
        public IActionResult Post(CreateDonorInputModel model)
        {
            var result = _service.Post(model);

            return NoContent();
        }
    }
}
