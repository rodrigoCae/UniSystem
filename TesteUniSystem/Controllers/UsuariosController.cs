using TesteUnisystem.Context;
using TesteUniSystem.Recursos.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteUniSystem.Models;
using TesteUnisystem.Recursos.Commands;
using TesteUniSystem.Recursos.Commands;

namespace TesteUnisystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UsuariosController(AppDbContext context, IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            try
            {
                var command = new GetTodosUsuariosQuery();
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario>> GetUsuarios(int id)
        {
            try
            {
                var command = new GetUsuarioPorIdQuery { Id = id };
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario([FromBody] UsuarioCreateCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            try
            {
                var command = new UsuarioDeleteCommand { ID = id };
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Usuario>> PutUsuario([FromBody] UsuarioUpdateCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
