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

        public async Task<Usuario> GetByEmailAsync(string email)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
        }

        public Usuario GetByEmail(string email)
        {
            return _context.Usuario.Where(e => e.Email == email).FirstOrDefault();
        }

        public Usuario GetByCPF(string cpf)
        {
            return _context.Usuario.Where(e => e.CPF == cpf).FirstOrDefault();
        }
    }
}