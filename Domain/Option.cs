namespace SportNest.Domain;

/// <summary>
/// Enum to distinguish whether an Option belongs to a Club, Department, or Group.
/// </summary>
public enum OptionType
{
    ClubOption = 0,
    DepartmentOption = 1,
    GroupOption = 2
}

/// <summary>
/// A shared "Option" entity that can store configuration-like data for Clubs, Departments, or Groups.
/// </summary>
public class Option
{
    public long Id { get; set; }

    public OptionType Type { get; set; }
    public string Name { get; set; }
    public string? Value { get; set; }

    // Nullable foreign keys depending on the Type
    public long? ClubId { get; set; }
    public Club? Club { get; set; }

    public long? DepartmentId { get; set; }
    public Department? Department { get; set; }

    public long? GroupId { get; set; }
    public Group? Group { get; set; }
}