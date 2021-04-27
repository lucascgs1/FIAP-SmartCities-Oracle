using Pokedevs.Api.Models;
using Pokedevs.Api.Repository.Context;
using Pokedevs.Api.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Pokedevs.Api.Repository
{
    public class VeiculoRepository : Repository<Veiculo>, IVeiculoRepository
    {
        private readonly ApplicationDbContext _context;

        public VeiculoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// listar Produtos
        /// </summary>
        /// <returns></returns>
        public IList<Veiculo> Listar()
        {
            return _context.Veiculo.ToList(); ;
        }

        //public Produto Consultar(int id)
        //{
        //    var prod = context.Produto
        //        .Include(t => t.Tipo)
        //        .FirstOrDefault(p => p.IdProduto == id);
        //    return prod;
        //}

        //public IList<Produto> ConsultarProdutosPorTipo(int idTipo)
        //{
        //    // Consulta a lista de produtos de um determinado tipo.
        //    var tipoProduto =
        //        context.TipoProduto
        //            .Include(t => t.Produtos)
        //            .FirstOrDefault(t => t.IdTipo == idTipo);

        //    return tipoProduto.Produtos;
        //}
    }
}