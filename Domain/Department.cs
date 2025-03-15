namespace SportNest.Domain;

/// <summary>
/// A department within a club (e.g., a volleyball or handball department).
/// </summary>
public class Department
{
    public long Id { get; set; }
    public string DepartmentName { get; set; }
    public string? Description { get; set; }

    public long ClubId { get; set; }
    public Club Club { get; set; }

    public List<Group> Groups { get; set; } = [];
    public List<DepartmentKPI> DepartmentKPIs { get; set; } = [];
    public List<Option> Options { get; set; } = [];
    public List<ClubPermission> ClubPermissions { get; set; } = [];
}