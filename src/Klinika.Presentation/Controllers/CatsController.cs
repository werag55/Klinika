using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Klinika.Domain.Models;
using Klinika.Domain.Repositories;

namespace Klinika.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        private readonly ICatRepository _CatRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CatsController(ICatRepository CatRepository, IUnitOfWork unitOfWork)
        {
            _CatRepository = CatRepository;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Cats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cat>>> GetCats([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            return await _CatRepository.GetAllAsync();
        }

        // GET: api/Cats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cat>> GetCat(int id)
        {
            var Cat = await _CatRepository.GetByIdAsync(id);

            if (Cat == null)
            {
                return NotFound();
            }

            return Cat;
        }

        // PUT: api/Cats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCat(int id, Cat Cat)
        {
            if (id != Cat.Id)
            {
                return BadRequest();
            }

            _CatRepository.Update(Cat);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Cats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cat>> PostCat(Cat Cat)
        {
            _CatRepository.Add(Cat);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetCat", new { id = Cat.Id }, Cat);
        }

        // DELETE: api/Cats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCat(int id)
        {
            var Cat = await _CatRepository.GetByIdAsync(id);
            if (Cat == null)
            {
                return NotFound();
            }

            _CatRepository.Remove(Cat);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
