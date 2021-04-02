// using System.Data.Common;
// using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksApi.Models;

namespace ParksApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ReviewsController : ControllerBase
  {
    private ParksApiContext _db;
    public ReviewsController(ParksApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Review>>> GetAction(int rating, string reviewTitle, string reviewBody)
    {
      var query = _db.Reviews.AsQueryable();
      if (rating == 1 || rating == 2 || rating == 3 || rating == 4 || rating == 5)
      {
        query = query.Where(entry => entry.Rating == rating);
      }
      if (reviewTitle != null)
      {
        query = query.Where(entry => entry.ReviewTitle == reviewTitle);
      }
      if (reviewBody != null)
      {
        query = query.Where(entry => entry.ReviewBody == reviewBody);
      }

      return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Review>> GetReview(int id)
    {
      var review = await _db.Reviews.FindAsync(id);
      if(review == null)
      {
        return NotFound();
      }
      return review;
    }

  }
}