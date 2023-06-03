using cev.api.Domain.Interfaces;
using cev.api.Domain.ModelsApi;
using Microsoft.AspNetCore.Mvc;

namespace cev.api.Controllers
{
    [ApiController]
    [Route("vendedor")]
    public class VendedorController : ApiBaseController
    {
        private readonly IVendedorApplication _vendedorApplication;

        public VendedorController(IVendedorApplication vendedorApplication)
        {
            _vendedorApplication = vendedorApplication;
        }

        [HttpPost]
        [ProducesResponseType(typeof(VendedorCriar), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public IActionResult Inserir([FromBody] VendedorCriar vendedorCriar)
        {
            var resultado = _vendedorApplication.Inserir(vendedorCriar);

            if (resultado.Invalid)
                return BadRequest(resultado.Notifications);

            return Created("", resultado);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<VendedorLeitura>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public IActionResult Listar()
        {
            var resultado = _vendedorApplication.Listar();

            if (resultado.Invalid)
                return BadRequest(resultado.Notifications);

            if (resultado.Object.Count == 0)
                return NoContent();

            return Ok(resultado.Object);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(VendedorLeitura), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public IActionResult RecuperarPorId(int id)
        {
            var resultado = _vendedorApplication.RecuperarPorId(id);

            if (resultado == null)
                return NoContent();

            if (resultado.Invalid)
                return BadRequest(resultado.Notifications);

            return Ok(resultado.Object);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(VendedorCriar), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public IActionResult Atualizar(int id, string nome)
        {
            var resultado = _vendedorApplication.AtualizarNome(id, nome);

            if (resultado.Invalid)
                return BadRequest(resultado.Notifications);

            return Ok(resultado.Object);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public IActionResult Excluir(int id)
        {
            var resultado = _vendedorApplication.Excluir(id);

            if (resultado.Invalid)
                return BadRequest(resultado.Notifications);

            return NoContent();
        }
    }
}
