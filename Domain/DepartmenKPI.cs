namespace Domain;

/// <summary>
/// Defines a KPI at the department level. Groups in this department can decide 
/// to use (or inherit) this KPI.
/// </summary>
public class DepartmentKPI
{
    public long Id { get; set; }

    public long DepartmentId { get; set; }
    public Department Department { get; set; }

    public string Name { get; set; }
    public string? Description { get; set; }

    public List<GroupKPI> GroupKPIs { get; set; } = new();
}