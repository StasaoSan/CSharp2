using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Socket;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Processor;

public class ProcessorParams
{
    public string? Model { get; }
    public double Frequency { get; }
    public int CountCore { get; }
    public ProcessorSocket? Socket { get; }
    public bool IsBuiltVideoCore { get; }
    public ICollection<double>? AvailableFrequencyMemory { get; }
    public double TDP { get; }
    public int Power { get; }
}