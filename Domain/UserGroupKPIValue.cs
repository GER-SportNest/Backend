namespace SportNest.Domain;

/// <summary>
/// Stores the actual KPI value for a given user and a specific GroupKPI.
/// </summary>
public class UserGroupKPIValue
{
    public long Id { get; set; }

    public long GroupKPIId { get; set; }
    public GroupKPI GroupKPI { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }

    public int IntValue { get; set; }
    public string? TextValue { get; set; }
}