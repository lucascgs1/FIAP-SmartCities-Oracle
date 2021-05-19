using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pokedevs.Data.Context;
using Pokedevs.Models;
using Pokedevs.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pokedevs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParadaController : ControllerBase
    {
        private readonly ILogger<ParadaController> _logger;
        private readonly ApplicationDbContext _context;

        public ParadaController(ILogger<ParadaController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// obtem todas as paradas
        /// </summary>
        /// <returns>lista de apradas</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parada>>> GetParada([FromServices] IParadaServices paradaServices)
        {
            try
            {
                var parada = paradaServices.GetAll();

                return Ok(parada);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// obtem os dados de uma parada especifica
        /// </summary>
        /// <param name="id">codigo da parada</param>
        /// <returns>dados da parada</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Parada>> GetParada([FromServices] IParadaServices paradaServices, int id)
        {
            try
            {
                Parada parada = paradaServices.GetById(id);

                if (parada == null)
                {
                    return NotFound();
                }
                return Ok(parada);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// atualiza uma parada
        /// </summary>
        /// <param name="id">codigo da parada</param>
        /// <param name="parada">dados da parada</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutParada([FromServices] IParadaServices paradaServices, int id, Parada parada)
        {
            try
            {
                paradaServices.Save(parada, id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Salva uma nova parada
        /// </summary>
        /// <param name="parada"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Parada>> PostParada([FromServices] IParadaServices paradaServices, Parada parada)
        {
            try
            {
                paradaServices.Save(parada);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// deleta uma parada
        /// </summary>
        /// <param name="id">codigo da parada</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParada([FromServices] IParadaServices paradaServices, int id)
        {
            try
            {
                paradaServices.DeleteById(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return Problem(ex.Message);
            }
        }
    }
}