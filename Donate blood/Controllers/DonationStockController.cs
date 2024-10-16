using DonateBlood.Application.Services.Stock;
using Microsoft.AspNetCore.Mvc;

namespace Donate_blood.Controllers
{
    [Route("api/bloods")]
    [ApiController]
    public class DonationStockController : ControllerBase
    {
        private readonly IStockService _service;

        public DonationStockController(IStockService service)
        {
            _service = service;    
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var results = _service.GetAll();

            if (results is null)
            {
                return BadRequest(results.Data);
            }

            return Ok(results);
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

        [HttpGet("{bloodType}/{factorRh}")]
        public IActionResult GetByType(string bloodType, string factorRh)
        {
            var result = _service.GetByType(bloodType, factorRh);

            if (result is null)
            {
                return BadRequest(result.Data);
            }

            return Ok(result);
        }
    }
}
