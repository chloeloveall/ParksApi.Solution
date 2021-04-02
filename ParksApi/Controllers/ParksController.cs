using System.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksApi.Models;

namespace ParksApi.Controllers
{
  // [ApiVersionNeutral]
  [Route("api/[controller]")]
  [ApiController]
  public class ParksController : ControllerBase
  {
    private readonly ParksApiContext _db;
    public ParksController(ParksApiContext db)
    {
      _db = db;
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<Park>>> Get(string state)
    {
      var query = _db.Parks.Include(entry => entry.Reviews).AsQueryable();
      if (state != null)
      {
        query = query.Where(entry => entry.State == state);
      }
      return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetParks(int id)
    {
      var park = await _db.Parks.FindAsync(id);
      if (park == null)
      {
        return NotFound();
      }
      return park;
    }

  }
}