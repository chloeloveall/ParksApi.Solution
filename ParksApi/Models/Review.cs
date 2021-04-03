using System.ComponentModel.DataAnnotations;

namespace ParksApi.Models
{
  public class Review
  {
    public int ReviewId {get; set; }
    [Required]
    public int Rating { get; set; }
    [Required]
    public string ReviewTitle { get; set; }
    [Required]
    public string ReviewBody { get; set; }
    [Required]
    public int ParkId { get; set; }
  }
}