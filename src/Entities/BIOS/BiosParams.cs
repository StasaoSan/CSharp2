using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS;

public class BiosParams
{
    public string? Version { get; }
    public TypeBios TypeBios { get; }
    public ICollection<string>? AvailableProcessors { get; }
}
