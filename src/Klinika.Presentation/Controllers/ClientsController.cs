using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using MediatR;
using Klinika.Application.Clients.GetClients;
using Klinika.Application.Clients.GetClientById;
using Klinika.Application.Clients.UpdateClient;
using Klinika.Application.Clients.CreateClient;
using Klinika.Application.Clients.DeleteClient;
using Klinika.Application.Clients.Login;
using System.Security.Authentication;

namespace Klinika.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientsController(IMediator mediator) =>
            _mediator = mediator;

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            //var query = _context.Clients.AsQueryable();

            //var totalCount = query.Count();
            //var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            //query = query.Skip((page - 1) * pageSize).Take(pageSize);

            //var result = new
            //{
            //    TotalCount = totalCount,
            //    TotalPages = totalPages,
            //    CurrentPage = page,
            //    PageSize = pageSize,
            //    Articles = query.ToList()
            //};

            //return Ok(result);

            var query = new GetClientsQuery(page, pageSize);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var query = new GetClientByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Client Client)
        {
            if (id != Client.Id)
            {
                return BadRequest();
            }

            var command = new UpdateClientCommand(id, Client);
            await _mediator.Send(command);
            return NoContent();
        }

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client Client)
        {
            var command = new CreateClientCommand(Client);
            var result = await _mediator.Send(command);
            return CreatedAtAction("GetClient", new { id = result.Id }, result);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var command = new DeleteClientCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginClient([FromBody] string userName)
        {
            try
            {
                var command = new LoginCommand(userName);
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.InnerException is InvalidCredentialException)
                    return BadRequest("Invalid user name");
            }
            return BadRequest();
        }
    }
}
