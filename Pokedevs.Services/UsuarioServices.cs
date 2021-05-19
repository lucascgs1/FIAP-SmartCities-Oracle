using Microsoft.Extensions.Logging;
using Pokedevs.Data.Interfaces;
using Pokedevs.Models;
using Pokedevs.Services.Helper;
using Pokedevs.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pokedevs.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        #region repositorios

        private readonly ILogger<UsuarioServices> _logger;

        public IUsuarioRepository UsuarioRepository { get; set; }

        #endregion repositorios

        public UsuarioServices(
            IUsuarioRepository usuarioRepository,
            ILogger<UsuarioServices> logger
            )
        {
            UsuarioRepository = usuarioRepository;
            _logger = logger;
        }

        #region crud

        /// <summary>
        /// obtem um usuario pelo codigo
        /// </summary>
        /// <param name="id">codigo do usuario</param>
        /// <returns>dados do usuario</returns>
        public Usuario GetById(int id)
        {
            var usuario = UsuarioRepository.GetById(id);

            if (usuario == null)
                throw new Exception("Usuário não encontrado!");

            return usuario;
        }

        /// <summary>
        /// obtem os dados de todos os usuarios
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Usuario> GetAllUsuarios()
        {
            return UsuarioRepository.GetAll();
        }

        /// <summary>
        /// Salva ou atualiza um usuario
        /// </summary>
        /// <param name="usuarioNovo">dados do usuario</param>
        /// <param name="usuarioId">codigo do usuario autenticado</param>
        /// <returns></returns>
        public Usuario Save(Usuario usuarioNovo, int usuarioId = 0)
        {
            try
            {
                if (usuarioNovo.Id > 0)
                {
                    if (usuarioNovo.Id != usuarioId) throw new Exception("Acesso negado!");

                    var usuario = UsuarioRepository.GetById(usuarioNovo.Id);
                    usuario.Nome = usuarioNovo.Nome;
                    usuario.Email = usuarioNovo.Email;
                    usuario.Telefone = usuarioNovo.Telefone;

                    UsuarioRepository.Update(usuario);
                }
                else
                {
                    if (UsuarioRepository.FindFirstBy(x => x.Email == usuarioNovo.Email) != null)
                        throw new ValidationException("E-mail já cadastrado!");

                    usuarioNovo.DataCadastro = DateTime.Now;
                    usuarioNovo.Senha = usuarioNovo.Senha.Md5Hash();

                    UsuarioRepository.Add(usuarioNovo);
                }

                UsuarioRepository.SaveChanges();

                return UsuarioRepository.GetFullByEmail(usuarioNovo.Email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// exclui um usuario pelo codigo
        /// </summary>
        /// <param name="usuarioId">codigo do usuario</param>
        public void DeleteById(int usuarioId)
        {
            UsuarioRepository.Remove(usuarioId);
            UsuarioRepository.SaveChanges();
        }

        #endregion crud
    }
}