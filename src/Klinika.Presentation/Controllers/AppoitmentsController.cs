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
using Klinika.Application.Appoitments.GetAppoitmentById;
using Klinika.Application.Appoitments.UpdateAppoitment;
using Klinika.Application.Appoitments.CreateAppoitment;
using Klinika.Application.Appoitments.DeleteAppoitment;
using Klinika.Application.Appoitments.CheckAppoitmentByDate;

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
        public async Task<ActionResult<IEnumerable<Appoitment>>> GetAppoitments([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
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
        [HttpGet("{id}")]
        public async Task<ActionResult<Appoitment>> GetAppoitment(int id)
        {
            var query = new GetAppoitmentByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

       // GET: api/Appoitments/Date
       [HttpGet("Date")]
        public async Task<IActionResult> CheckDate(DateTime date)
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
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppoitment(int id, Appoitment appoitment)
        {
            if (id != appoitment.Id)
            {
                return BadRequest();
            }

            var command = new UpdateAppoitmentCommand(id, appoitment);
            await _mediator.Send(command);
            return NoContent();
        }

        // POST: api/Appoitments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appoitment>> PostAppoitment(Appoitment appoitment)
        {
            var command = new CreateAppoitmentCommand(appoitment);
            var result = await _mediator.Send(command);
            return CreatedAtAction("GetAppoitment", new { id = result.Id }, result);
        }

        // DELETE: api/Appoitments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppoitment(int id)
        {
            var command = new DeleteAppoitmentCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
