using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystem;

public class CoolingSystemParams
{
    public DimentionsCoolingSystem Dimensions { get; }
    public double Tdp { get; }
    public ICollection<ProcessorSocket>? SupportedSockets { get; }
}