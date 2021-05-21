using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pokedevs.Data.Context;
using Pokedevs.Models;
using Pokedevs.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Pokedevs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(
            ILogger<UsuarioController> logger,
            ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// obtem todos os usuario
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetUsuarios([FromServices] IUsuarioServices usuarioService)
        {
            try
            {
                var usuario = usuarioService.GetAllUsuarios();

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// obtem os dados de um usuario
        /// </summary>
        /// <param name="id">codigo do usuario</param>
        /// <returns>dados do usuario</returns>
        [HttpGet("{id}")]
        public ActionResult<Usuario> GetUsuario([FromServices] IUsuarioServices usuarioService, int id)
        {
            try
            {
                var usuario = usuarioService.GetById(id);

                if (usuario == null)
                {
                    return NotFound();
                }

                return usuario;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza um Usuario
        /// </summary>
        /// <param name="id">codigo do usuario</param>
        /// <param name="usuario">dados do usuario</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult PutUsuario([FromServices] IUsuarioServices usuarioService, int id, Usuario usuario)
        {
            try
            {
                if (id != usuario.Id) return BadRequest();

                usuarioService.Save(usuario, id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Salva um novo usuario
        /// </summary>
        /// <param name="usuario">dados do usuario</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Usuario> PostUsuario([FromServices] IUsuarioServices usuarioService, Usuario usuario)
        {
            usuarioService.Save(usuario);

            return CreatedAtAction("GetUsuario", new { id = usuario.Id });
        }

        /// <summary>
        /// deleta um usuario
        /// </summary>
        /// <param name="id">codigo do usuario</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult DeleteUsuario([FromServices] IUsuarioServices usuarioService, int id)
        {
            try
            {
                usuarioService.DeleteById(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}