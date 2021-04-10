using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace ParksApi.Controllers
{
  [ApiVersion("2.0")]
  [Route("api/{v:apiVersion}/parks")] 
  [ApiController]
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  public class ParksV2Controller : ControllerBase
  {
    private readonly ParksApiContext _db;
    public ParksV2Controller(ParksApiContext db)
    {
      _db = db;
    }

    // endpoint http://localhost:5000/api/2.0/parks/
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Park>>> Get(string parkName, string parkState, string parkDescription, string parkCategory)
    {
      var query = _db.Parks.Include(entry => entry.Reviews).AsQueryable();
      if (parkName != null)
      {
        query = query.Where(entry => entry.ParkName == parkName);
      }
      if (parkState != null)
      {
        query = query.Where(entry => entry.ParkState == parkState);
      }
      if (parkDescription != null)
      {
        query = query.Where(entry => entry.ParkDescription == parkDescription);
      }
      if (parkCategory != null)
      {
        query = query.Where(entry => entry.ParkCategory == parkCategory);
      }
      return await query.ToListAsync();
    }

    // endpoint http://localhost:5000/api/2.0/parks/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetPark(int id)
    {
      var park = await _db.Parks.FindAsync(id);
      if (park == null)
      {
        return NotFound();
      }
      return park;
    }

    // endpoint http://localhost:5000/api/2.0/parks/
    [HttpPost]
    public async Task<ActionResult<Park>> Post(Park park)
    {
      _db.Parks.Add(park);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetPark), new { id = park.ParkId }, park);
    }

    // endpoint http://localhost:5000/api/2.0/parks/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Park park)
    {
      if (id != park.ParkId)
      {
        return BadRequest();
      }
      _db.Entry(park).State = EntityState.Modified;
      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if(!ParkExists(id))
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

    // endpoint http://localhost:5000/api/2.0/parks/{id}
    private bool ParkExists(int id)
    {
      return _db.Parks.Any(e => e.ParkId == id);
    }

    // endpoint http://localhost:5000/api/2.0/parks/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePark(int id)
    {
      var park = await _db.Parks.FindAsync(id);
      if (park == null)
      {
        return NotFound();
      }
      _db.Parks.Remove(park);
      await _db.SaveChangesAsync();
      return NoContent();
    }

  }
}