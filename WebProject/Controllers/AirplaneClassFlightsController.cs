using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProject.Database;
using WebProject.WebModels;

namespace WebProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirplaneClassFlightsController : ControllerBase
    {
        private readonly AviaSalesContext _context;

        public AirplaneClassFlightsController(AviaSalesContext context)
        {
            _context = context;
        }

        // GET: api/AirplaneClassFlights
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirplaneClassFlight>>> GetAirplaneClassFlights()
        {
          if (_context.AirplaneClassFlights == null)
          {
              return NotFound();
          }
            return await _context.AirplaneClassFlights.ToListAsync();
        }

        // GET: api/AirplaneClassFlights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AirplaneClassFlight>> GetAirplaneClassFlight(int id)
        {
          if (_context.AirplaneClassFlights == null)
          {
              return NotFound();
          }
            var airplaneClassFlight = await _context.AirplaneClassFlights.FindAsync(id);

            if (airplaneClassFlight == null)
            {
                return NotFound();
            }

            return airplaneClassFlight;
        }

        // PUT: api/AirplaneClassFlights/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirplaneClassFlight(int id, AirplaneClassFlight airplaneClassFlight)
        {
            if (id != airplaneClassFlight.ClassFlightId)
            {
                return BadRequest();
            }

            _context.Entry(airplaneClassFlight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirplaneClassFlightExists(id))
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

        // POST: api/AirplaneClassFlights
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AirplaneClassFlight>> PostAirplaneClassFlight(AirplaneClassFlight airplaneClassFlight)
        {
          if (_context.AirplaneClassFlights == null)
          {
              return Problem("Entity set 'AviaSalesContext.AirplaneClassFlights'  is null.");
          }
            _context.AirplaneClassFlights.Add(airplaneClassFlight);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAirplaneClassFlight", new { id = airplaneClassFlight.ClassFlightId }, airplaneClassFlight);
        }

        // DELETE: api/AirplaneClassFlights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirplaneClassFlight(int id)
        {
            if (_context.AirplaneClassFlights == null)
            {
                return NotFound();
            }
            var airplaneClassFlight = await _context.AirplaneClassFlights.FindAsync(id);
            if (airplaneClassFlight == null)
            {
                return NotFound();
            }

            _context.AirplaneClassFlights.Remove(airplaneClassFlight);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AirplaneClassFlightExists(int id)
        {
            return (_context.AirplaneClassFlights?.Any(e => e.ClassFlightId == id)).GetValueOrDefault();
        }
    }
}
