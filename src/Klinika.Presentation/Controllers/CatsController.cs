using Microsoft.AspNetCore.Mvc;
using MediatR;
using Klinika.Application.Cats.GetCats;
using Klinika.Application.Cats.GetCatByGuid;
using Klinika.Application.Cats.UpdateCat;
using Klinika.Application.Cats.CreateCat;
using Klinika.Application.Cats.DeleteCat;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Klinika.Application.Cats.CatsDTO;

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
        public async Task<ActionResult<IEnumerable<GetCatDTO>>> GetCats([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
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

            var query = new GetCatsQuery(page, pageSize);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/Cats/5
        [HttpGet("{guid}")]
        public async Task<ActionResult<GetCatDTO>> GetCat(string guid)
        {
            var query = new GetCatByGuidQuery(guid);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        // PUT: api/Cats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{guid}")]
        public async Task<IActionResult> PutCat(string guid, [FromBody] UpsertCatDTO cat)
        {
             var command = new UpdateCatCommand(guid, cat);
            await _mediator.Send(command);
            return NoContent();
        }

        // POST: api/Cats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GetCatDTO>> PostCat([FromBody] UpsertCatDTO cat)
        {
            var userName = User.FindFirst(ClaimTypes.Name)?.Value;

            var command = new CreateCatCommand(cat);
            var result = await _mediator.Send(command);
            return CreatedAtAction("GetCat", new { guid = result.Guid }, result);
        }

        // DELETE: api/Cats/5
        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeleteCat(string guid)
        {
            var command = new DeleteCatCommand(guid);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
