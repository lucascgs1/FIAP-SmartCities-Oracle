using Pokedevs.Data.Context;
using Pokedevs.Data.Interfaces;
using Pokedevs.Models;

namespace Pokedevs.Data
{
    public class ViagemRepository : Repository<Viagem>, IViagemRepository
    {
        private readonly ApplicationDbContext _context;

        public ViagemRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}