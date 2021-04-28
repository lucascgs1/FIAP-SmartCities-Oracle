using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pokedevs.Api.Models;
using Pokedevs.Api.Repository.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedevs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParadaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ParadaController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// obtem todas as paradas
        /// </summary>
        /// <returns>lista de apradas</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parada>>> GetParada()
        {
            return await _context.Parada.ToListAsync();
        }

        /// <summary>
        /// obtem os dados de uma parada especifica
        /// </summary>
        /// <param name="id">codigo da parada</param>
        /// <returns>dados da parada</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Parada>> GetParada(int id)
        {
            var parada = await _context.Parada.FindAsync(id);

            if (parada == null)
            {
                return NotFound();
            }

            return parada;
        }

        /// <summary>
        /// atualiza uma parada
        /// </summary>
        /// <param name="id">codigo da parada</param>
        /// <param name="parada">dados da parada</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParada(int id, Parada parada)
        {
            if (id != parada.Id)
            {
                return BadRequest();
            }

            _context.Entry(parada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParadaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Salva uma nova parada
        /// </summary>
        /// <param name="parada"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Parada>> PostParada(Parada parada)
        {
            _context.Parada.Add(parada);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParada", new { id = parada.Id }, parada);
        }

        /// <summary>
        /// deleta uma parada
        /// </summary>
        /// <param name="id">codigo da parada</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParada(int id)
        {
            var parada = await _context.Parada.FindAsync(id);
            if (parada == null)
            {
                return NotFound();
            }

            _context.Parada.Remove(parada);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// verifica se a aprada existe
        /// </summary>
        /// <param name="id">codigo da parada</param>
        /// <returns></returns>
        private bool ParadaExists(int id)
        {
            return _context.Parada.Any(e => e.Id == id);
        }
    }
}