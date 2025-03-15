namespace SportNest.Domain;

public class MembershipRole
{
    public long Id { get; set; }

    // Links to the membership
    public long UserClubMembershipId { get; set; }
    public UserClubMembership UserClubMembership { get; set; } = default!;

    // Links to the actual ClubRole definition
    public long ClubRoleId { get; set; }
    public ClubRole ClubRole { get; set; } = default!;
}
