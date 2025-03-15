namespace SportNest.Domain;

/// <summary>
/// A group or team within a department.
/// </summary>
public class Group
{
    public long Id { get; set; }
    public string GroupName { get; set; }
    public string? Description { get; set; }

    public long DepartmentId { get; set; }
    public Department Department { get; set; }

    public List<TrainingSession> TrainingSessions { get; set; } = [];
    public List<GroupKPI> GroupKPIs { get; set; } = [];
    public List<Option> Options { get; set; } = [];
    public List<ClubPermission> ClubPermissions { get; set; } = [];
}