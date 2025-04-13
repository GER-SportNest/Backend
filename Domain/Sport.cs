using NpgsqlTypes;

namespace SportNest.Domain;

public class Sport
{
    public long Id { get; set; }
    /// <summary>
    /// Default name in German
    /// </summary>
    public string Name { get; set; }

    public List<string> Translations { get; set; } = [];
    public List<Group> Groups { get; set; }
    public NpgsqlTsVector SearchVector { get; set; }

}