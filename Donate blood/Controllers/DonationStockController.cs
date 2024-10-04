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
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }
    }
}
