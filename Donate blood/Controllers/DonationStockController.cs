using DonateBlood.Application.Services.Stock;
using Microsoft.AspNetCore.Mvc;

namespace Donate_blood.Controllers
{
    [Route("api/bloods")]
    [ApiController]
    public class DonationStockController : ControllerBase
    {
        private readonly IStockService _service;
        private readonly IWebHostEnvironment _webHostEnv;

        public DonationStockController(
            IStockService service,
            IWebHostEnvironment webHostEnv)
        {
            _service = service;    
            _webHostEnv = webHostEnv;
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
        public IActionResult GetByType(int bloodType, int factorRh)
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
