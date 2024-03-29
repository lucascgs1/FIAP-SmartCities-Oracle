﻿using Microsoft.Extensions.Logging;
using Pokedevs.Data.Interfaces;
using Pokedevs.Models;
using Pokedevs.Services.Helper;
using Pokedevs.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

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
                    if (UsuarioRepository.GetByEmail(usuarioNovo.Email) != null)
                        throw new ValidationException("E-mail já cadastrado!");
                    
                    if (UsuarioRepository.GetByCPF(usuarioNovo.CPF) != null)
                        throw new ValidationException("CPF já cadastrado!");

                    usuarioNovo.DataCadastro = DateTime.Now;
                    usuarioNovo.Senha = usuarioNovo.Senha.Md5Hash();

                    UsuarioRepository.Add(usuarioNovo);
                }

                UsuarioRepository.SaveChanges();

                return UsuarioRepository.GetByEmail(usuarioNovo.Email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
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

        public Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            throw new NotImplementedException();
        }

        public Usuario Autenticar(string email, string senha)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
                throw new ValidationException("Dados não preenchidos!");

            Usuario usuario = UsuarioRepository.GetByEmail(email);

            if (usuario == null)
                throw new ValidationException("Usuário ou senha inválidos!");

            if (usuario.Senha != senha.Md5Hash())
                throw new ValidationException("Senha invalida!");

            return usuario;

        }

        public void GerarCodigoSeguranca(string email)
        {
            throw new NotImplementedException();
        }

        //public Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        //{
        //    UsuarioRepository.GetByEmail



        //    throw new NotImplementedException();
        //}

        #endregion crud
    }
}