using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ParksApi.Models
{
  public class ParksApiContext : IdentityDbContext
  {
    public ParksApiContext(DbContextOptions<ParksApiContext> options) : base(options) { }
    
    public DbSet<Park> Parks { get; set; }
    public DbSet<Review> Reviews { get; set; }
  } 
}