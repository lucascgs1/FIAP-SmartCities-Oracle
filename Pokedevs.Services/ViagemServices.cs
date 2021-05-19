using Microsoft.Extensions.Logging;
using Pokedevs.Data.Interfaces;
using Pokedevs.Models;
using Pokedevs.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Pokedevs.Services
{
    public class ViagemServices : IViagemServices
    {
        #region repositorios

        private readonly ILogger<ViagemServices> _logger;

        public IViagemRepository ViagemRepository { get; set; }

        #endregion repositorios

        public ViagemServices(
            IViagemRepository viagemRepository,
            ILogger<ViagemServices> logger
            )
        {
            ViagemRepository = viagemRepository;
            _logger = logger;
        }

        #region crud

        /// <summary>
        /// obtem uma viagem pelo codigo
        /// </summary>
        /// <param name="id">codigo da viagem</param>
        /// <returns>dados da viagem</returns>
        public Viagem GetById(int id)
        {
            var viagem = ViagemRepository.GetById(id);

            if (viagem == null)
                throw new Exception("Viagem não encontrada!");

            return viagem;
        }

        /// <summary>
        /// obtem os dados de todas os viagens
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Viagem> GetAllViagens()
        {
            return ViagemRepository.GetAll();
        }

        /// <summary>
        /// Salva ou atualiza uma viagem
        /// </summary>
        /// <param name="viagemNova">dados do viagem</param>
        /// <param name="viagemId">codigo do viagem autenticado</param>
        /// <returns></returns>
        public void Save(Viagem viagemNova, int viagemId = 0)
        {
            try
            {
                if (viagemNova.Id > 0)
                {
                    if (viagemNova.Id != viagemId) throw new Exception("Acesso negado!");

                    var viagem = ViagemRepository.GetById((int)viagemNova.Id);

                    ViagemRepository.Update(viagem);
                }
                else
                {
                    viagemNova.DataCadastro = DateTime.Now;

                    ViagemRepository.Add(viagemNova);
                }

                ViagemRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// exclui um viagem pelo codigo
        /// </summary>
        /// <param name="viagemId">codigo do viagem</param>
        public void DeleteById(int viagemId)
        {
            ViagemRepository.Remove(viagemId);
            ViagemRepository.SaveChanges();
        }

        #endregion crud
    }
}