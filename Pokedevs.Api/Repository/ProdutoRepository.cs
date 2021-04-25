using Pokedevs.Api.Models;
using Pokedevs.Api.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Pokedevs.Api.Repository.Interface;

namespace Pokedevs.Api.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProdutoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// listar Produtos
        /// </summary>
        /// <returns></returns>
        public IList<Produto> Listar()
        {
            var pokemano = 2;

            var teste = DbSet.AsNoTracking().Include(e => e.Tipo).ToList();
            return teste;
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
