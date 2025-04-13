namespace SportNest.Domain;

public class UserRating
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long GroupId { get; set; }
    public double Rating { get; set; }
}