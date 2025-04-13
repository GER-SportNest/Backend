namespace SportNest.Domain;

/// <summary>
/// A group or team within a department.
/// </summary>
public class Group : TrackedEntity
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public long? SportId { get; set; }
    public Sport? Sport { get; set; }
    public List<TrainingSession> TrainingSessions { get; set; } = [];
    public List<UserGroupMembership> Memberships { get; set; } = [];
}