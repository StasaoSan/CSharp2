using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboard;

public class Chipset
{
    public Chipset(ICollection<double> supportedMemoryFrequencies, bool supportsXMP)
    {
        SupportedMemoryFrequencies = supportedMemoryFrequencies;
        SupportsXMP = supportsXMP;
    }

    public ICollection<double> SupportedMemoryFrequencies { get; init; } = new List<double>();
    public bool SupportsXMP { get; }
}