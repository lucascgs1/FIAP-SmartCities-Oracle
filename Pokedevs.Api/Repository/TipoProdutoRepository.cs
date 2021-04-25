using Pokedevs.Api.Models;
using Pokedevs.Api.Repository.Context;
using Pokedevs.Api.Repository.Interface;
using System.Collections.Generic;
using System.Linq;


namespace Pokedevs.Api.Repository
{
    public class TipoProdutoRepository : Repository<TipoProduto>, ITipoProdutoRepository
    {
        private readonly ApplicationDbContext _context;

        public TipoProdutoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


        public IList<TipoProduto> Listar()
        {
            return _context.TipoProduto.ToList();
        }


        public TipoProduto Consultar(int id)
        {
            return _context.TipoProduto.Find(id);
        }


        public void Inserir(TipoProduto tipoProduto)
        {
            _context.TipoProduto.Add(tipoProduto);
            _context.SaveChanges();
        }

        public void Alterar(TipoProduto tipoProduto)
        {
            // Informa o contexto que um objeto foi alterado
            _context.TipoProduto.Update(tipoProduto);

            // Salva as alterações
            _context.SaveChanges();
        }

        public void Excluir(int id)
        {
            // Criar um tipo produto apenas com o Id
            var tipoProduto = new TipoProduto()
            {
                IdTipo = id
            };

            _context.TipoProduto.Remove(tipoProduto);
            _context.SaveChanges();
        }




        public IList<TipoProduto> ListarOrdenadoPorNome()
        {
            var lista = _context.TipoProduto.OrderBy(t => t.DescricaoTipo)
                                            .ToList();

            return lista;
        }


        public IList<TipoProduto> ListarOrdenadoPorNomeDescendente()
        {
            var lista =
                _context.TipoProduto.OrderByDescending(t => t.DescricaoTipo)
                                    .ToList();

            return lista;
        }


        public IList<TipoProduto> ListarTiposComercializados()
        {
            // Filtro com Where
            var lista =
                _context.TipoProduto.Where(t => t.Comercializado == '0')
                                    .OrderByDescending(t => t.DescricaoTipo)
                                    .ToList();

            return lista;
        }


        public IList<TipoProduto> ListarTiposComercializadosCritedio(char selecao)
        {
            // Filtro com Where
            var lista = _context.TipoProduto
                                .Where(t => t.Comercializado == selecao)
                                .OrderByDescending(t => t.DescricaoTipo)
                                .ToList();

            return lista;
        }



        public IList<TipoProduto> ListarTiposComercializados(char selecao)
        {
            // Filtro com Where
            var lista =_context.TipoProduto.Where(t => t.Comercializado == selecao && t.IdTipo > 2)
                                            .OrderByDescending(t => t.DescricaoTipo)
                                            .ToList();

            return lista;
        }



        public TipoProduto ConsultaPorDescricao(string descricao)
        {
            // Retorno único
            TipoProduto tipo = _context.TipoProduto.Where(t => t.DescricaoTipo == descricao) .FirstOrDefault();

            return tipo;
        }



        public IList<TipoProduto> ListarTiposParteDescricao(string parteDescricao)
        {
            // Filtro com Where e Contains
            var lista = _context.TipoProduto.Where(t => t.DescricaoTipo.Contains(parteDescricao)).ToList();

            return lista;
        }



    }
}
