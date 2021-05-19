using Microsoft.Extensions.Logging;
using Pokedevs.Data.Interfaces;
using Pokedevs.Models;
using Pokedevs.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Pokedevs.Services
{
    public class VeiculoServices : IVeiculoServices
    {
        #region repositorios

        private readonly ILogger<VeiculoServices> _logger;

        public IVeiculoRepository VeiculoRepository { get; set; }

        #endregion repositorios

        public VeiculoServices(
            IVeiculoRepository veiculoRepository,
            ILogger<VeiculoServices> logger
            )
        {
            VeiculoRepository = veiculoRepository;
            _logger = logger;
        }

        #region crud

        /// <summary>
        /// obtem um veiculo pelo codigo
        /// </summary>
        /// <param name="id">codigo da veiculo</param>
        /// <returns>dados da veiculo</returns>
        public Veiculo GetById(int id)
        {
            var veiculo = VeiculoRepository.GetById(id);

            if (veiculo == null)
                throw new Exception("Viagem não encontrada!");

            return veiculo;
        }

        /// <summary>
        /// obtem os dados de todos os veiculo
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Veiculo> GetAllVeiculos()
        {
            return VeiculoRepository.GetAll();
        }

        /// <summary>
        /// Salva ou atualiza um veiculo
        /// </summary>
        /// <param name="veiculoNovo">dados do veiculo</param>
        /// <param name="veiculoId">codigo do veiculo</param>
        /// <returns></returns>
        public void Save(Veiculo veiculoNovo, int veiculoId = 0)
        {
            try
            {
                if (veiculoNovo.Id > 0)
                {
                    if (veiculoNovo.Id != veiculoId)
                        throw new Exception("Acesso negado!");

                    var viagem = VeiculoRepository.GetById(veiculoNovo.Id);

                    VeiculoRepository.Update(viagem);
                }
                else
                {
                    veiculoNovo.DataCadastro = DateTime.Now;

                    VeiculoRepository.Add(veiculoNovo);
                }

                VeiculoRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// exclui um veiculo pelo codigo
        /// </summary>
        /// <param name="veiculoId">codigo do veiculo</param>
        public void DeleteById(int veiculoId)
        {
            VeiculoRepository.Remove(veiculoId);
            VeiculoRepository.SaveChanges();
        }

        #endregion crud
    }
}