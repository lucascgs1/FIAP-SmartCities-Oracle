using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pokedevs.Api.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Pokedevs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Get([FromServices] IProdutoServices produtoServices)
        {
            try
            {
                var produtosLst = produtoServices.GetAll();

                return Ok(produtosLst);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return Problem(ex.Message);
            }
        }

        // GET api/<Home>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Home>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Home>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Home>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
