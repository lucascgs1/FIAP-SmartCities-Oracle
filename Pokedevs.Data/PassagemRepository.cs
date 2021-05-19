using Pokedevs.Data.Context;
using Pokedevs.Data.Interfaces;
using Pokedevs.Models;

namespace Pokedevs.Data
{
    public class PassagemRepository : Repository<Passagem>, IPassagemRepository
    {
        private readonly ApplicationDbContext _context;

        public PassagemRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}