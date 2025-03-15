namespace SportNest.Domain;

public class ClubRole
{
    public long Id { get; set; }

    // FK to the Club this role belongs to
    public long ClubId { get; set; }
    public Club Club { get; set; } = default!;

    // e.g. "Founder", "Admin", "Trainer", "Kassenwart", ...
    public string RoleName { get; set; } = default!;

    // Optional: store permissions in JSON or separate columns
    public string? PermissionsJson { get; set; }

    // Navigation to bridging table
    public List<MembershipRole> MembershipRoles { get; set; } = [];
    public List<ClubPermission> ClubPermissions { get; set; } = [];
}
