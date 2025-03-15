namespace SportNest.Domain;

/// <summary>
/// M:N relationship between a user and a club, with a role (e.g., "Member", "Trainer") 
/// and possibly a global skill-level for that user in the club.
/// </summary>
public class UserClubMembership
{
    public long Id { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }

    public long ClubId { get; set; }
    public Club Club { get; set; }

    public List<MembershipRole> MembershipRoles { get; set; } = [];
}