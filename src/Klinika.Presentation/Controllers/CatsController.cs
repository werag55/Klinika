using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using MediatR;
using Klinika.Application.Cats.GetCats;
using Klinika.Application.Cats.GetCatById;
using Klinika.Application.Cats.UpdateCat;
using Klinika.Application.Cats.CreateCat;
using Klinika.Application.Cats.DeleteCat;
using Microsoft.AspNetCore.Authorization;

namespace Klinika.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CatsController(IMediator mediator) =>
            _mediator = mediator;

        // GET: api/Cats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cat>>> GetCats([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            //var query = _context.Cats.AsQueryable();

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

        // GET: api/Cats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cat>> GetCat(int id)
        {
            var query = new GetClientByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        // PUT: api/Cats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCat(int id, Cat cat)
        {
            if (id != cat.Id)
            {
                return BadRequest();
            }

            var command = new UpdateClientCommand(id, cat);
            await _mediator.Send(command);
            return NoContent();
        }

        // POST: api/Cats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Cat>> PostCat(Cat cat)
        {
            var command = new CreateClientCommand(cat);
            var result = await _mediator.Send(command);
            return CreatedAtAction("GetCat", new { id = result.Id }, result);
        }

        // DELETE: api/Cats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCat(int id)
        {
            var command = new DeleteClientCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
