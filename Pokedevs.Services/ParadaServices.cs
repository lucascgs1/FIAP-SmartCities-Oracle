using Microsoft.Extensions.Logging;
using Pokedevs.Data.Interfaces;
using Pokedevs.Models;
using Pokedevs.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Pokedevs.Services
{
    public class ParadaServices : IParadaServices
    {
        #region repositorios

        private readonly ILogger<ParadaServices> _logger;

        public IParadaRepository ParadaRepository { get; set; }

        #endregion repositorios

        public ParadaServices(
            IParadaRepository paradaRepository,
            ILogger<ParadaServices> logger
            )
        {
            ParadaRepository = paradaRepository;
            _logger = logger;
        }

        #region crud

        /// <summary>
        /// obtem um parada pelo codigo
        /// </summary>
        /// <param name="id">codigo do parada</param>
        /// <returns>dados do parada</returns>
        public Parada GetById(int id)
        {
            var parada = ParadaRepository.GetById(id);

            if (parada == null)
                throw new Exception("Parada não encontrada!");

            return parada;
        }

        /// <summary>
        /// obtem os dados de todos os parada
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Parada> GetAll()
        {
            return ParadaRepository.GetAll();
        }

        /// <summary>
        /// Salva ou atualiza um parada
        /// </summary>
        /// <param name="paradaNova">dados do parada</param>
        /// <param name="paradaId">codigo do parada autenticado</param>
        /// <returns></returns>
        public void Save(Parada paradaNova, int paradaId = 0)
        {
            try
            {
                if (paradaNova.Id > 0)
                {
                    if (paradaNova.Id != paradaId) throw new Exception("Acesso negado!");

                    var parada = ParadaRepository.GetById(paradaNova.Id);
                    parada.Nome = paradaNova.Nome;
                    parada.Local = paradaNova.Local;
                    parada.Longitude = paradaNova.Longitude;
                    parada.Latitude = paradaNova.Latitude;

                    ParadaRepository.Update(parada);
                }
                else
                {
                    paradaNova.DataCadastro = DateTime.Now;

                    ParadaRepository.Add(paradaNova);
                }

                ParadaRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// exclui um parada pelo codigo
        /// </summary>
        /// <param name="paradaId">codigo do parada</param>
        public void DeleteById(int paradaId)
        {
            ParadaRepository.Remove(paradaId);
            ParadaRepository.SaveChanges();
        }

        #endregion crud
    }
}