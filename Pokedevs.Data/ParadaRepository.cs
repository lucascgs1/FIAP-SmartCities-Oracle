using Pokedevs.Data.Context;
using Pokedevs.Data.Interfaces;
using Pokedevs.Models;

namespace Pokedevs.Data
{
    public class ParadaRepository : Repository<Parada>, IParadaRepository
    {
        private readonly ApplicationDbContext _context;

        public ParadaRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}