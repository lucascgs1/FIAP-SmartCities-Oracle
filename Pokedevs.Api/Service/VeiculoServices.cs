using Pokedevs.Api.Models;
using Pokedevs.Api.Repository.Interface;
using Pokedevs.Api.Service.Interface;
using System;
using System.Collections.Generic;

namespace Pokedevs.Api.Service
{
    public class VeiculoServices : IVeiculoServices
    {
        public IVeiculoRepository ProdutoRepository { get; set; }

        public VeiculoServices(IVeiculoRepository produtoRepository)
        {
            ProdutoRepository = produtoRepository;
        }

        public IList<Veiculo> GetAll()
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