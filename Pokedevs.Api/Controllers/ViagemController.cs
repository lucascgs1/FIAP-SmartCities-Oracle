using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pokedevs.Data.Context;
using Pokedevs.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedevs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViagemController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ViagemController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// obtem todas as viagens
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Viagem>>> GetViagem()
        {
            return await _context.Viagem.ToListAsync();
        }

        /// <summary>
        /// obtem os dados de uma viagem
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Viagem>> GetViagem(int id)
        {
            var viagem = await _context.Viagem.FindAsync(id);

            if (viagem == null)
            {
                return NotFound();
            }

            return viagem;
        }

        /// <summary>
        /// atualiza uma viagem
        /// </summary>
        /// <param name="id">codigo da viagem</param>
        /// <param name="viagem">dados da viagem</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutViagem(int id, Viagem viagem)
        {
            if (id != viagem.Id)
            {
                return BadRequest();
            }

            _context.Entry(viagem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViagemExists(id))
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
        /// salva uma nova viagem
        /// </summary>
        /// <param name="viagem">dados da viagem</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Viagem>> PostViagem(Viagem viagem)
        {
            _context.Viagem.Add(viagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetViagem", new { id = viagem.Id }, viagem);
        }

        /// <summary>
        /// deleta uma viagem
        /// </summary>
        /// <param name="id">codigo da viagem</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteViagem(int id)
        {
            var viagem = await _context.Viagem.FindAsync(id);
            if (viagem == null)
            {
                return NotFound();
            }

            _context.Viagem.Remove(viagem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// verifica se uma viagem existe
        /// </summary>
        /// <param name="id">codigo da viagem</param>
        /// <returns></returns>
        private bool ViagemExists(int id)
        {
            return _context.Viagem.Any(e => e.Id == id);
        }
    }
}