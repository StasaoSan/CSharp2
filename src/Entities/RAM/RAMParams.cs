using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.XPM;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;

public class RAMParams
{
    public int CapacityGb { get; }
    public ICollection<FrequencyAndVoltage>? SupportedFrequencies { get; }
    public ICollection<XMPProfile>? XMPProfiles { get; }
    public RAMFormFactor FormFactor { get; }
    public TypeDDR DDRType { get; }
    public int PowerConsumption { get; }
}