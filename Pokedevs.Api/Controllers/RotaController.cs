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
    public class RotaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RotaController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// obtem uma lista de rotas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rota>>> GetRota()
        {
            return await _context.Rota.ToListAsync();
        }

        /// <summary>
        /// obtem dados da rota
        /// </summary>
        /// <param name="id">codigo da rota</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Rota>> GetRota(int id)
        {
            var rota = await _context.Rota.FindAsync(id);

            if (rota == null)
            {
                return NotFound();
            }

            return rota;
        }

        /// <summary>
        /// atualiza uma rota
        /// </summary>
        /// <param name="id">codigo da rota</param>
        /// <param name="rota">dados da rota</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRota(int id, Rota rota)
        {
            if (id != rota.Id)
            {
                return BadRequest();
            }

            _context.Entry(rota).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RotaExists(id))
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
        /// Salva uma nova rota
        /// </summary>
        /// <param name="rota">dados da rota</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Rota>> PostRota(Rota rota)
        {
            _context.Rota.Add(rota);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRota", new { id = rota.Id }, rota);
        }

        /// <summary>
        /// deleta uma rota
        /// </summary>
        /// <param name="id">codigo da rota</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRota(int id)
        {
            var rota = await _context.Rota.FindAsync(id);
            if (rota == null)
            {
                return NotFound();
            }

            _context.Rota.Remove(rota);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// verifica se a rota ja existe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool RotaExists(int id)
        {
            return _context.Rota.Any(e => e.Id == id);
        }
    }
}