using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Socket;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystem;

public class CoolingSystem : IComponent, ICloneable
{
    public CoolingSystem(DimentionsCoolingSystem dimentionsCoolingSystem, double tdp, ICollection<ProcessorSocket> supportedSockets)
    {
        Id = Guid.NewGuid();
        Dimensions = dimentionsCoolingSystem;
        TDP = tdp;
        SupportedSockets = supportedSockets;
    }

    public Guid Id { get; }
    public DimentionsCoolingSystem Dimensions { get; }
    public double TDP { get; }
    public ICollection<ProcessorSocket> SupportedSockets { get; }

    public object Clone()
    {
        return new CoolingSystem(Dimensions, TDP, new List<ProcessorSocket>(SupportedSockets));
    }
}