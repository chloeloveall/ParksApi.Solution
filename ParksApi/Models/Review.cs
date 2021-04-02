namespace ParksApi.Models
{
  public class Review
  {
    public int ReviewId {get; set; }
    public int Rating { get; set; }
    public string ReviewTitle { get; set; }
    public string ReviewBody { get; set; }
    public int ParkId { get; set; }
  }
}