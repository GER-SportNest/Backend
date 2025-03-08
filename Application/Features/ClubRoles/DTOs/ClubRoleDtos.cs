namespace Application.Clubs.DTOs;

public class ClubRoleDto
{
    public Guid Id { get; set; }
    public Guid ClubId { get; set; }
    public string RoleName { get; set; } = default!;
}
