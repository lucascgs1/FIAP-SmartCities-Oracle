using Pokedevs.Models;
using System.Threading.Tasks;

namespace Pokedevs.Data.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> GetByEmail(string email);

        Usuario GetFullByEmail(string email);
    }
}