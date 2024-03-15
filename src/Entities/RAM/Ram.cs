using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.XPM;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;

public class Ram : IComponent, ICloneable
{
    public Ram(int capacityGb, ICollection<FrequencyAndVoltage> supportedFrequencies, ICollection<XMPProfile> xmpProfiles, RAMFormFactor formFactor, TypeDDR ddrType, int powerConsumption)
    {
        Id = Guid.NewGuid();
        CapacityGb = capacityGb;
        SupportedFrequencies = supportedFrequencies;
        XMPProfiles = xmpProfiles;
        FormFactor = formFactor;
        DDRType = ddrType;
        PowerConsumption = powerConsumption;
    }

    public Guid Id { get; }
    public int CapacityGb { get; }
    public ICollection<FrequencyAndVoltage> SupportedFrequencies { get; }
    public ICollection<XMPProfile> XMPProfiles { get; }
    public RAMFormFactor FormFactor { get; }
    public TypeDDR DDRType { get; }
    public int PowerConsumption { get; }

    public object Clone()
    {
        return new Ram(CapacityGb, SupportedFrequencies, XMPProfiles, FormFactor, DDRType, PowerConsumption);
    }
}