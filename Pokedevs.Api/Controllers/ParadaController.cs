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

        // GET: api/Parada
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parada>>> GetParada()
        {
            return await _context.Parada.ToListAsync();
        }

        // GET: api/Parada/5
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

        // PUT: api/Parada/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

        // POST: api/Parada
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Parada>> PostParada(Parada parada)
        {
            _context.Parada.Add(parada);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParada", new { id = parada.Id }, parada);
        }

        // DELETE: api/Parada/5
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

        private bool ParadaExists(int id)
        {
            return _context.Parada.Any(e => e.Id == id);
        }
    }
}