using Microsoft.Extensions.Logging;
using Pokedevs.Data.Interfaces;
using Pokedevs.Models;
using Pokedevs.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Pokedevs.Services
{
    public class RotaServices : IRotaServices
    {
        #region repositorios

        private readonly ILogger<RotaServices> _logger;

        public IRotaRepository RotaRepository { get; set; }

        #endregion repositorios

        public RotaServices(
            IRotaRepository rotaRepository,
            ILogger<RotaServices> logger
            )
        {
            RotaRepository = rotaRepository;
            _logger = logger;
        }

        #region crud

        /// <summary>
        /// obtem um rota pelo codigo
        /// </summary>
        /// <param name="id">codigo do rota</param>
        /// <returns>dados do rota</returns>
        public Rota GetById(int id)
        {
            var rota = RotaRepository.GetById(id);

            if (rota == null)
                throw new Exception("Rota não encontrada!");

            return rota;
        }

        /// <summary>
        /// obtem os dados de todos as rotas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Rota> GetAll()
        {
            return RotaRepository.GetAll();
        }

        /// <summary>
        /// Salva ou atualiza um rota
        /// </summary>
        /// <param name="rotaNova">dados do rota</param>
        /// <param name="rotaId">codigo do rota autenticado</param>
        /// <returns></returns>
        public void Save(Rota rotaNova, int rotaId = 0)
        {
            try
            {
                if (rotaNova.Id > 0)
                {
                    if (rotaNova.Id != rotaId) throw new Exception("Acesso negado!");

                    var rota = RotaRepository.GetById(rotaNova.Id);
                    rota.Preco = rotaNova.Preco;
                    rota.Destino = rotaNova.Destino;
                    rota.Embarque = rotaNova.Embarque;
                    rota.TempoViagen = rotaNova.TempoViagen;
                    rota.HoraEmbarque = rotaNova.HoraEmbarque;
                    rota.HoraChegada = rotaNova.HoraChegada;

                    RotaRepository.Update(rota);
                }
                else
                {
                    rotaNova.DataCadastro = DateTime.Now;

                    RotaRepository.Add(rotaNova);
                }

                RotaRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// exclui um rota pelo codigo
        /// </summary>
        /// <param name="rotaId">codigo do rota</param>
        public void DeleteById(int rotaId)
        {
            RotaRepository.Remove(rotaId);
            RotaRepository.SaveChanges();
        }

        #endregion crud
    }
}