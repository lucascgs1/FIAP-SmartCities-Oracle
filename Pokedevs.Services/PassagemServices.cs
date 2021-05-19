using Microsoft.Extensions.Logging;
using Pokedevs.Data.Interfaces;
using Pokedevs.Models;
using Pokedevs.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Pokedevs.Services
{
    public class PassagemServices : IPassagemServices
    {
        #region repositorios

        private readonly ILogger<PassagemServices> _logger;

        public IPassagemRepository PassagemRepository { get; set; }

        #endregion repositorios

        public PassagemServices(
            IPassagemRepository passagemRepository,
            ILogger<PassagemServices> logger
            )
        {
            PassagemRepository = passagemRepository;
            _logger = logger;
        }

        #region crud

        /// <summary>
        /// obtem um passagem pelo codigo
        /// </summary>
        /// <param name="id">codigo do passagem</param>
        /// <returns>dados do passagem</returns>
        public Passagem GetById(int id)
        {
            var passagem = PassagemRepository.GetById(id);

            if (passagem == null)
                throw new Exception("Passagem não encontrada!");

            return passagem;
        }

        /// <summary>
        /// obtem os dados de todos os passagem
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Passagem> GetAll()
        {
            return PassagemRepository.GetAll();
        }

        /// <summary>
        /// Salva ou atualiza um parada
        /// </summary>
        /// <param name="passagemNova">dados do parada</param>
        /// <param name="paradaId">codigo do parada autenticado</param>
        /// <returns></returns>
        public void Save(Passagem passagemNova, int paradaId = 0)
        {
            try
            {
                if (passagemNova.Id > 0)
                {
                    if (passagemNova.Id != paradaId) throw new Exception("Acesso negado!");

                    var passagem = PassagemRepository.GetById(passagemNova.Id);
                    passagem.Preco = passagemNova.Preco;
                    passagem.RotaParada = passagemNova.RotaParada;
                    passagem.Descricao = passagemNova.Descricao;
                    passagem.RotaParadaId = passagemNova.RotaParadaId;

                    PassagemRepository.Update(passagem);
                }
                else
                {
                    passagemNova.DataCadastro = DateTime.Now;

                    PassagemRepository.Add(passagemNova);
                }

                PassagemRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// exclui um passagem pelo codigo
        /// </summary>
        /// <param name="passagemId">codigo do passagem</param>
        public void DeleteById(int passagemId)
        {
            PassagemRepository.Remove(passagemId);
            PassagemRepository.SaveChanges();
        }

        #endregion crud
    }
}