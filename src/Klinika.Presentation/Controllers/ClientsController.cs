using Microsoft.AspNetCore.Mvc;
using MediatR;
using Klinika.Application.Clients.GetClients;
using Klinika.Application.Clients.GetClientByUserName;
using Klinika.Application.Clients.UpdateClient;
using Klinika.Application.Clients.CreateClient;
using Klinika.Application.Clients.DeleteClient;
using Klinika.Application.Clients.Login;
using Klinika.Application.Clients.ClientsDTO;
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
        public async Task<ActionResult<IEnumerable<GetClientDTO>>> GetClients([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
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
        [HttpGet("{userName}")]
        public async Task<ActionResult<GetClientDTO>> GetClient(string userName)
        {
            var query = new GetClientByUserNameQuery(userName);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        // PUT: api/Clients/JanKowalski
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{userName}")]
        public async Task<IActionResult> PutClient(string userName, [FromBody] UpdateClientDTO Client)
        {

            var command = new UpdateClientCommand(userName, Client);
            await _mediator.Send(command);
            return NoContent();
        }

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GetClientDTO>> PostClient([FromBody] CreateClientDTO Client)
        {
            var command = new CreateClientCommand(Client);
            var result = await _mediator.Send(command);
            return CreatedAtAction("GetClient", new { userName = result.UserName }, result);
        }

        // DELETE: api/Clients/JanKowalski
        [HttpDelete("{userName}")]
        public async Task<IActionResult> DeleteClient(string userName)
        {
            var command = new DeleteClientCommand(userName);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginClient([FromBody] LoginClientDTO login)
        {
            try
            {
                var command = new LoginCommand(login);
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
