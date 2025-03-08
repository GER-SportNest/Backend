namespace Application.Clubs.DTOs;

public class ClubDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}