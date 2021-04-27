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

        // GET: api/Rota
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rota>>> GetRota()
        {
            return await _context.Rota.ToListAsync();
        }

        // GET: api/Rota/5
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

        // PUT: api/Rota/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

        // POST: api/Rota
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rota>> PostRota(Rota rota)
        {
            _context.Rota.Add(rota);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRota", new { id = rota.Id }, rota);
        }

        // DELETE: api/Rota/5
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

        private bool RotaExists(int id)
        {
            return _context.Rota.Any(e => e.Id == id);
        }
    }
}