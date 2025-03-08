namespace Domain;

/// <summary>
/// Represents a user/member in the system.
/// </summary>
public class User
{
    public long Id { get; set; }
    public required string DisplayName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }

    public List<UserClubMembership> UserClubMemberships { get; set; } = new();
}