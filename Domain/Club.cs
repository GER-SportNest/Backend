namespace Domain;

/// <summary>
/// Represents a club (sports club) that contains multiple departments.
/// </summary>
public class Club
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }

    public List<Department> Departments { get; set; } = new();
    public List<UserClubMembership> Memberships { get; set; } = new();
    public List<Option> Options { get; set; } = new();
}