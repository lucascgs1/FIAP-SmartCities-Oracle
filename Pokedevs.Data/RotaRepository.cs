using Pokedevs.Data.Context;
using Pokedevs.Data.Interfaces;
using Pokedevs.Models;

namespace Pokedevs.Data
{
    public class RotaRepository : Repository<Rota>, IRotaRepository
    {
        private readonly ApplicationDbContext _context;

        public RotaRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}