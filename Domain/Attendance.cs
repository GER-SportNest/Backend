namespace SportNest.Domain;

/// <summary>
/// Documents a user's attendance (yes/no) at a training session.
/// </summary>
public class Attendance
{
    public long Id { get; set; }

    public long TrainingSessionId { get; set; }
    public TrainingSession TrainingSession { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }

    public bool IsAttending { get; set; }
    public string? Reason { get; set; }
}