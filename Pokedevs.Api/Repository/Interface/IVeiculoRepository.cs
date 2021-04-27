using Pokedevs.Api.Models;
using System.Collections.Generic;

namespace Pokedevs.Api.Repository.Interface
{
    public interface IVeiculoRepository : IRepository<Veiculo>
    {
        IList<Veiculo> Listar();
    }
}