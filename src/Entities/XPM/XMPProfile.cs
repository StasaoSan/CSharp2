using System;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.XPM;

public class XMPProfile : IComponent, ICloneable
{
    public XMPProfile(string timings, double voltage, double frequency)
    {
        Id = Guid.NewGuid();
        Timings = timings;
        Voltage = voltage;
        Frequency = frequency;
    }

    public Guid Id { get; }
    public string Timings { get; }
    public double Voltage { get; }
    public double Frequency { get; }

    public object Clone()
    {
        return new XMPProfile(Timings, Voltage, Frequency);
    }
}
