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
    public class PassagemController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PassagemController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtem as passagens do usuario
        /// </summary>
        /// <returns>lista de passagens</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passagem>>> GetPassagem()
        {
            return await _context.Passagem.ToListAsync();
        }

        /// <summary>
        /// Obtem uma passagem em especifico
        /// </summary>
        /// <param name="id">codigo da passagem</param>
        /// <returns>dados da passagem</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Passagem>> GetPassagem(int id)
        {
            var passagem = await _context.Passagem.FindAsync(id);

            if (passagem == null)
            {
                return NotFound();
            }

            return passagem;
        }

        /// <summary>
        /// salva uma nova passavem
        /// </summary>
        /// <param name="id">codigo da passagem</param>
        /// <param name="passagem">dados da nova passagem</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassagem(int id, Passagem passagem)
        {
            if (id != passagem.Id)
            {
                return BadRequest();
            }

            _context.Entry(passagem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassagemExists(id))
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
        /// salva ou atualiza uma passagem
        /// </summary>
        /// <param name="passagem">dados da passagem</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Passagem>> PostPassagem(Passagem passagem)
        {
            _context.Passagem.Add(passagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPassagem", new { id = passagem.Id }, passagem);
        }

        /// <summary>
        /// deleta uma passagem
        /// </summary>
        /// <param name="id">codigo da passagem</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassagem(int id)
        {
            var passagem = await _context.Passagem.FindAsync(id);
            if (passagem == null)
            {
                return NotFound();
            }

            _context.Passagem.Remove(passagem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// verifica se a passagem existe
        /// </summary>
        /// <param name="id">codigo da passagem</param>
        /// <returns></returns>
        private bool PassagemExists(int id)
        {
            return _context.Passagem.Any(e => e.Id == id);
        }
    }
}