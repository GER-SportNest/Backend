namespace Domain;

/// <summary>
/// A training session that belongs to a specific group.
/// </summary>
public class TrainingSession
{
    public long Id { get; set; }
    public DateTime SessionDate { get; set; }
    public string? Location { get; set; }

    public long GroupId { get; set; }
    public Group Group { get; set; }

    public List<Attendance> Attendances { get; set; } = new();
}