using DonateBlood.Application.Services.Stock;
using Microsoft.AspNetCore.Mvc;

namespace Donate_blood.Controllers
{
    [Route("api/bloods")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _service;
        private readonly IWebHostEnvironment _webHostEnv;

        public StockController(
            IStockService service,
            IWebHostEnvironment webHostEnv)
        {
            _service = service;    
            _webHostEnv = webHostEnv;
        }

        /// <summary>
        /// Obter todos os Estoques
        /// </summary>
        /// <returns>Coleção de estoques</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            var results = _service.GetAll();

            if (results is null)
            {
                return BadRequest(results.Data);
            }

            return Ok(results);
        }

        /// <summary>
        /// Obtem um estoque
        /// </summary>
        /// <param name="id">Identificador de estoque</param>
        /// <returns>Dados do estoque</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id); 

            if (result is null)
            {
                return BadRequest(result.Data);
            }

            return Ok(result);
        }


        /// <summary>
        /// Filtrar tipo de sanguíne
        /// </summary>
        /// <param name="bloodType">Identificador do tipo de sangue</param>
        /// <param name="factorRh">Identificador do FatorRh</param>
        /// <returns>Estoque do tipo filtrado.</returns>
        [HttpGet("{bloodType}/{factorRh}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
