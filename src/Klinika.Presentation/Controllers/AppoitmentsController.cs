using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using MediatR;
using Klinika.Application.Appoitments.GetAppoitments;
using Klinika.Application.Appoitments.GetAppoitmentByGuid;
using Klinika.Application.Appoitments.UpdateAppoitment;
using Klinika.Application.Appoitments.CreateAppoitment;
using Klinika.Application.Appoitments.DeleteAppoitment;
using Klinika.Application.Appoitments.CheckAppoitmentByDate;
using Klinika.Application.Appoitments.AppoitmentsDTO;

namespace Klinika.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppoitmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppoitmentsController(IMediator mediator) =>
            _mediator = mediator;

        // GET: api/Appoitments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAppoitmentDTO>>> GetAppoitments([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            //var query = _context.Appoitments.AsQueryable();

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

            var query = new GetAppoitmentsQuery(page, pageSize);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/Appoitments/5
        [HttpGet("{guid}")]
        public async Task<ActionResult<GetAppoitmentDTO>> GetAppoitment(string guid)
        {
            var query = new GetAppoitmentByGuidQuery(guid);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

       // GET: api/Appoitments/Date
       [HttpGet("Date")]
        public async Task<IActionResult> CheckDate([FromBody] DateTime date)
        {
            var query = new CheckAppoitmentByDateQuery(date);
            var result = await _mediator.Send(query);
            if (result == false)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        // PUT: api/Appoitments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{guid}")]
        public async Task<IActionResult> PutAppoitment(string guid, [FromBody] UpsertAppoitmentDTO appoitment)
        {
            var command = new UpdateAppoitmentCommand(guid, appoitment);
            await _mediator.Send(command);
            return NoContent();
        }

        // POST: api/Appoitments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GetAppoitmentDTO>> PostAppoitment([FromBody] UpsertAppoitmentDTO appoitment)
        {
            var command = new CreateAppoitmentCommand(appoitment);
            var result = await _mediator.Send(command);
            return CreatedAtAction("GetAppoitment", new { guid = result.Guid }, result);
        }

        // DELETE: api/Appoitments/5
        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeleteAppoitment(string guid)
        {
            var command = new DeleteAppoitmentCommand(guid);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
