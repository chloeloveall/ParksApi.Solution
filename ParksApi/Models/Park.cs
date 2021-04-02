using System.Collections.Generic;

namespace ParksApi.Models
{
  public class Park
  {
    public Park()
    {
      this.Reviews = new HashSet<Review>();
    }
    public int ParkId { get; set; }
    public string State { get; set; }
    public ICollection<Review> Reviews { get; set; }
  }
}