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
    }
}