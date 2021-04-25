using Pokedevs.Api.Repository.Interface;
using Pokedevs.Api.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedevs.Api.Service
{
    public class TipoProdutoServices : ITipoProdutoServices
    {
        public ITipoProdutoRepository TipoProdutoRepository { get; set; }

    }
}
