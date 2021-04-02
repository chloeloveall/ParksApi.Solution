using Microsoft.EntityFrameworkCore;

namespace ParksApi.Models
{
  public class ParksApiContext : DbContext
  {
    public ParksApiContext(DbContextOptions<ParksApiContext> options) : base(options) { }
    
    public DbSet<Park> Parks { get; set; }
    public DbSet<Review> Reviews { get; set; }
  } 
}