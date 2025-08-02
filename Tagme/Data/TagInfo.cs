using System.ComponentModel.DataAnnotations;

namespace Tagme.Data;

public class TagInfo
{
    [Key]
    public ulong Id { get; set; }

    public string Name { get; set; }

    public string Tag { get; set; }

    public ulong Times { get; set; }
}
