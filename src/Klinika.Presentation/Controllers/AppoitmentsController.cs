using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Klinika.Domain.Models;
using Klinika.Domain.Repositories;

namespace Klinika.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppoitmentsController : ControllerBase
    {
        private readonly IAppoitmentRepository _appoitmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AppoitmentsController(IAppoitmentRepository appoitmentRepository,IUnitOfWork unitOfWork)
        {
            _appoitmentRepository = appoitmentRepository;
            _unitOfWork = unitOfWork;
        }

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
            ////return await _context.Appoitments.ToListAsync();
            return await _appoitmentRepository.GetAllAsync();
        }

        // GET: api/Appoitments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appoitment>> GetAppoitment(int id)
        {
            var appoitment = await _appoitmentRepository.GetByIdAsync(id);

            if (appoitment == null)
            {
                return NotFound();
            }

            return appoitment;
        }

        // GET: api/Appoitments/Date
        //[HttpGet("Date")]
        //public IActionResult CheckDate(DateTime date)
        //{
        //    DayOfWeek day = date.DayOfWeek;
        //    if (day == DayOfWeek.Saturday || day == DayOfWeek.Sunday)
        //        return BadRequest("You cannot schedule an appoitment at weekend");

        //    if (date.Hour > 15 || date.Hour < 8)
        //        return BadRequest("Schedule an appoitment between 8 and 15");

        //    Appoitment? app = _context.Appoitments.FirstOrDefault(a => a.Date.Hour == date.Hour);
        //    if (app != null)
        //        return BadRequest("There is already an appoitment on a given hour");

        //    return Ok(true);
        //}

        // PUT: api/Appoitments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppoitment(int id, Appoitment appoitment)
        {
            if (id != appoitment.Id)
            {
                return BadRequest();
            }

            //DayOfWeek day = appoitment.Date.DayOfWeek;
            //if (day == DayOfWeek.Saturday || day == DayOfWeek.Sunday)
            //    return BadRequest("You cannot schedule an appoitment at weekend");

            //if (appoitment.Date.Hour > 15 || appoitment.Date.Hour < 8)
            //    return BadRequest("Schedule an appoitment between 8 and 15");

            //Appoitment? app = _context.Appoitments.FirstOrDefault(a => a.Date.Hour == appoitment.Date.Hour);
            //if (app != null)
            //    return BadRequest("There is already an appoitment on a given hour");

            //_context.Entry(appoitment).State = EntityState.Modified;

            _appoitmentRepository.Update(appoitment);
            await _unitOfWork.SaveChangesAsync();

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!AppoitmentExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return NoContent();
        }

        // POST: api/Appoitments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appoitment>> PostAppoitment(Appoitment appoitment)
        {
            //DayOfWeek day = appoitment.Date.DayOfWeek;
            //if (day == DayOfWeek.Saturday || day == DayOfWeek.Sunday)
            //    return BadRequest("You cannot schedule an appoitment at weekend");

            //if (appoitment.Date.Hour > 15 || appoitment.Date.Hour < 8)
            //    return BadRequest("Schedule an appoitment between 8 and 15");

            //Appoitment? app = _context.Appoitments.FirstOrDefault(a => a.Date.Hour == appoitment.Date.Hour);
            //if (app != null)
            //    return BadRequest("There is already an appoitment on a given hour");

            _appoitmentRepository.Add(appoitment);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetAppoitment", new { id = appoitment.Id }, appoitment);
        }

        // DELETE: api/Appoitments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppoitment(int id)
        {
            var appoitment = await _appoitmentRepository.GetByIdAsync(id);
            if (appoitment == null)
            {
                return NotFound();
            }

            _appoitmentRepository.Remove(appoitment);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
