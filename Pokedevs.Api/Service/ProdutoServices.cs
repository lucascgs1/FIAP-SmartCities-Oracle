using Pokedevs.Api.Models;
using Pokedevs.Api.Repository.Interface;
using Pokedevs.Api.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedevs.Api.Service
{
    public class ProdutoServices : IProdutoServices
    {
        public IProdutoRepository ProdutoRepository { get; set; }

        public ProdutoServices(IProdutoRepository produtoRepository)
        {
            ProdutoRepository = produtoRepository;
        }


        public IList<Produto> GetAll()
        {
            try
            {
                var list = ProdutoRepository.Listar();

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
