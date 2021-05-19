using Pokedevs.Models;
using System.Collections.Generic;

namespace Pokedevs.Services.Interfaces
{
    public interface IPassagemServices
    {
        /// <summary>
        /// obtem um passagem pelo codigo
        /// </summary>
        /// <param name="id">codigo do passagem</param>
        /// <returns>dados do passagem</returns>
        Passagem GetById(int id);

        /// <summary>
        /// obtem os dados de todos os passagem
        /// </summary>
        /// <returns></returns>
        IEnumerable<Passagem> GetAll();

        /// <summary>
        /// Salva ou atualiza um parada
        /// </summary>
        /// <param name="passagemNova">dados do parada</param>
        /// <param name="paradaId">codigo do parada autenticado</param>
        /// <returns></returns>
        void Save(Passagem passagemNova, int paradaId = 0);

        /// <summary>
        /// exclui um passagem pelo codigo
        /// </summary>
        /// <param name="passagemId">codigo do passagem</param>
        void DeleteById(int passagemId);
    }
}