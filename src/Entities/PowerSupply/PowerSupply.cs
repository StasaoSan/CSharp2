using System;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerSupply;

public class PowerSupply : IComponent, ICloneable
{
    public PowerSupply(double peakLoad)
    {
        Id = Guid.NewGuid();
        PeakLoad = peakLoad;
    }

    public Guid Id { get; }
    public double PeakLoad { get; }

    public object Clone()
    {
        return new PowerSupply(PeakLoad);
    }
}
