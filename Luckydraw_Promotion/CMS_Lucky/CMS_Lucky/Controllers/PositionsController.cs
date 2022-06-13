using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMS_Lucky.Data;
using Datactx.Models;
using TransactionLibrary.IService;
using AutoMapper;
using TransactionLibrary.Response;

namespace CMS_Lucky.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IPositionService _positionService;
        private readonly IMapper _mapper;
        private readonly CMS_LuckyContext _context;
        public PositionsController(IPositionService positionsv, IMapper mapper)
        {
            _positionService = positionsv;
            _mapper = mapper;
        }
        public PositionsController(CMS_LuckyContext context)
        {
            _context = context;
        }

        // GET: api/Positions
        [HttpGet]
        public async Task<ActionResult<List<PositionRP>>> GetAll()
        {
            var getallposition = await _positionService.PositionGetAll();
            var response = this._mapper.Map<List<PositionRP>>(getallposition);
            return response;
        }

        // GET: api/Positions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Position>> GetPosition(int id)
        {
          if (_context.Position == null)
          {
              return NotFound();
          }
            var position = await _context.Position.FindAsync(id);

            if (position == null)
            {
                return NotFound();
            }

            return position;
        }

        // PUT: api/Positions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosition(int id, Position position)
        {
            if (id != position.posId)
            {
                return BadRequest();
            }

            _context.Entry(position).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PositionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Positions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Position>> PostPosition(Position position)
        {
          if (_context.Position == null)
          {
              return Problem("Entity set 'CMS_LuckyContext.Position'  is null.");
          }
            _context.Position.Add(position);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPosition", new { id = position.posId }, position);
        }

        // DELETE: api/Positions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePosition(int id)
        {
            if (_context.Position == null)
            {
                return NotFound();
            }
            var position = await _context.Position.FindAsync(id);
            if (position == null)
            {
                return NotFound();
            }

            _context.Position.Remove(position);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PositionExists(int id)
        {
            return (_context.Position?.Any(e => e.posId == id)).GetValueOrDefault();
        }
    }
}
