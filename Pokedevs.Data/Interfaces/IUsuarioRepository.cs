using Pokedevs.Models;
using System.Threading.Tasks;

namespace Pokedevs.Data.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> GetByEmailAsync(string email);

        Usuario GetByEmail(string email);

        Usuario GetByCPF(string cpf);
    }
}