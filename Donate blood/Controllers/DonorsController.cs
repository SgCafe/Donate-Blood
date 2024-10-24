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

        /// <summary>
        /// Obter todos os doadores
        /// </summary>
        /// <returns>Coleção de doadores</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();

            if (result is null)
            {
                return BadRequest(result.Data);
            }

            return Ok(result);
        }

        /// <summary>
        /// Obtem doação
        /// </summary>
        /// <param name="id">Identificador da doação</param>
        /// <returns>Dados da Doação</returns>
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
        /// Cadastrar uma doação
        /// </summary>
        /// <param name="model">Dados da doação</param>
        /// <returns>Objeto recem criado</returns>
        /// <response code="204">Sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Post(CreateDonorInputModel model)
        {
            var result = _service.Post(model);

            return NoContent();
        }
    }
}
