using Pokedevs.Api.Models;
using System.Collections.Generic;

namespace Pokedevs.Api.Service.Interface
{
    public interface IVeiculoServices
    {
        IList<Veiculo> GetAll();
    }
}