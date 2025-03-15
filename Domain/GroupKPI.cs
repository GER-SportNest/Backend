namespace SportNest.Domain;

/// <summary>
/// A KPI that a group actually uses. It can point to a DepartmentKPI (if inherited) 
/// or be defined independently by the group.
/// </summary>
public class GroupKPI
{
    public long Id { get; set; }

    public long GroupId { get; set; }
    public Group Group { get; set; }

    public long? DepartmentKPIId { get; set; }
    public DepartmentKPI? DepartmentKPI { get; set; }

    public string Name { get; set; }
    public string? Description { get; set; }

    public List<UserGroupKPIValue> UserGroupKPIValues { get; set; } = [];
}