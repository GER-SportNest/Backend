namespace SportNest.Domain;

public enum UserGroupRole
{
    Player,
    Trainer,
    CoTrainer,
    Guest
}

public class UserGroupMembership : TrackedEntity
{
    public long UserId { get; set; }
    public long GroupId { get; set; }
    public UserGroupRole Role { get; set; }
    public User? User { get; set; }
    public Group? Group { get; set; }
}