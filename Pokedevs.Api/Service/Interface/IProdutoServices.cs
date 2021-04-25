using Pokedevs.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedevs.Api.Service.Interface
{
    public interface IProdutoServices
    {
        IList<Produto> GetAll();
    }
}
