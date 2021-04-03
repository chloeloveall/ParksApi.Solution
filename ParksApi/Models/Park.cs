using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParksApi.Models
{
  public class Park
  {
    public Park()
    {
      this.Reviews = new HashSet<Review>();
    }
    public int ParkId { get; set; }
    [Required]
    public string ParkName { get; set; }
    [Required]
    public string ParkState { get; set; }
    [Required]
    public string ParkDescription { get; set; }
    [Required]
    public string ParkCategory { get; set; } // state or national 
    public ICollection<Review> Reviews { get; set; }
  }
}