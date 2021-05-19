using Pokedevs.Data.Context;
using Pokedevs.Data.Interfaces;
using Pokedevs.Models;

namespace Pokedevs.Data
{
    public class VeiculoRepository : Repository<Veiculo>, IVeiculoRepository
    {
        private readonly ApplicationDbContext _context;

        public VeiculoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}