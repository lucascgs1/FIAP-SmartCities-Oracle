using Pokedevs.Models;
using System.Collections.Generic;

namespace Pokedevs.Services.Interfaces
{
    public interface IParadaServices
    {
        /// <summary>
        /// obtem um parada pelo codigo
        /// </summary>
        /// <param name="id">codigo do parada</param>
        /// <returns>dados do parada</returns>
        Parada GetById(int id);

        /// obtem os dados de todos os parada
        /// </summary>
        /// <returns></returns>
        IEnumerable<Parada> GetAll();

        /// <summary>
        /// Salva ou atualiza um parada
        /// </summary>
        /// <param name="paradaNova">dados do parada</param>
        /// <param name="paradaId">codigo do parada autenticado</param>
        /// <returns></returns>
        void Save(Parada paradaNova, int paradaId = 0);

        /// <summary>
        /// exclui um parada pelo codigo
        /// </summary>
        /// <param name="paradaId">codigo do parada</param>
        void DeleteById(int paradaId);
    }
}