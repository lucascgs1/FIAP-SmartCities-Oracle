using Pokedevs.Models;
using System.Collections.Generic;

namespace Pokedevs.Services.Interfaces
{
    public interface IVeiculoServices
    {
        /// <summary>
        /// obtem um veiculo pelo codigo
        /// </summary>
        /// <param name="id">codigo da veiculo</param>
        /// <returns>dados da veiculo</returns>
        Veiculo GetById(int id);

        /// <summary>
        /// obtem os dados de todos os veiculo
        /// </summary>
        /// <returns></returns>
        IEnumerable<Veiculo> GetAllVeiculos();

        /// <summary>
        /// Salva ou atualiza um veiculo
        /// </summary>
        /// <param name="veiculoNovo">dados do veiculo</param>
        /// <param name="veiculoId">codigo do veiculo</param>
        /// <returns></returns>
        void Save(Veiculo veiculoNovo, int veiculoId = 0);

        /// <summary>
        /// exclui um veiculo pelo codigo
        /// </summary>
        /// <param name="veiculoId">codigo do veiculo</param>
        void DeleteById(int veiculoId);
    }
}