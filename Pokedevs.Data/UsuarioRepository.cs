using Microsoft.EntityFrameworkCore;
using Pokedevs.Data.Context;
using Pokedevs.Data.Interfaces;
using Pokedevs.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedevs.Data
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Usuario> GetByEmail(string email)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
        }

        public Usuario GetFullByEmail(string email)
        {
            return DbSet.AsNoTracking().Include(e => e.CodigoSeguranca).FirstOrDefault(x => x.Email == email);
        }
    }
}