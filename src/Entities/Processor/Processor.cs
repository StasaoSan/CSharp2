using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Socket;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Processor;

public class Processor : IComponent, ICloneable
{
    public Processor(string model, double frequency, int countCore, ProcessorSocket socket, bool isBuiltVideoCore, ICollection<double> availableFrequencyMemory, double tdp, int powerConsumtion)
    {
        Id = Guid.NewGuid();
        Model = model;
        Frequency = frequency;
        CountCore = countCore;
        Socket = socket;
        IsBuiltVideoCore = isBuiltVideoCore;
        AvailableFrequencyMemory = availableFrequencyMemory;
        TDP = tdp;
        PowerConsumtion = powerConsumtion;
    }

    public Guid Id { get; }
    public string Model { get; }
    public double Frequency { get; }
    public int CountCore { get; }
    public ProcessorSocket? Socket { get; }
    public bool IsBuiltVideoCore { get; }
    public ICollection<double> AvailableFrequencyMemory { get; }
    public double TDP { get; }
    public int PowerConsumtion { get; }

    public object Clone()
    {
        if (Socket is null)
            throw new AggregateException("Socket cant be null");
        return new Processor(Model, Frequency, CountCore, Socket, IsBuiltVideoCore, AvailableFrequencyMemory, TDP, PowerConsumtion);
    }
}