using Pokedevs.Models;
using System.Collections.Generic;

namespace Pokedevs.Services.Interfaces
{
    public interface IRotaServices
    {
        /// <summary>
        /// obtem um rota pelo codigo
        /// </summary>
        /// <param name="id">codigo do rota</param>
        /// <returns>dados do rota</returns>
        Rota GetById(int id);

        /// <summary>
        /// obtem os dados de todos as rotas
        /// </summary>
        /// <returns></returns>
        IEnumerable<Rota> GetAll();

        /// <summary>
        /// Salva ou atualiza um rota
        /// </summary>
        /// <param name="rotaNova">dados do rota</param>
        /// <param name="rotaId">codigo do rota autenticado</param>
        /// <returns></returns>
        void Save(Rota rotaNova, int rotaId = 0);

        /// <summary>
        /// exclui um rota pelo codigo
        /// </summary>
        /// <param name="rotaId">codigo do rota</param>
        void DeleteById(int rotaId);
    }
}