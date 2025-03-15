namespace SportNest.Domain;

public class ClubPermission
{
    public long Id { get; set; }
    public long? SiteId { get; set; }
    public long? DepartmentId { get; set; }
    public long? GroupId { get; set; }
    /// <summary>
    /// The Club Role to receive access to this Site, Department or Group
    /// </summary>
    public long ClubRoleId { get; set; }

    public ClubRole? ClubRole { get; set; }
    public Department? Department { get; set; }
    public Group? Group { get; set; }
}