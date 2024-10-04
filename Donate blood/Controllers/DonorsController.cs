using DonateBlood.Application.Models;
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
            return Ok();
        }

        [HttpGet("{search}")]
        public IActionResult GetByType(string search = "")
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(int id, CreateDonorInputModel model)
        {


            return NoContent();
        }
    }
}
