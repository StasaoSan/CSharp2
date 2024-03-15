using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.AbstractFactory;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Processor;

public class ProcessorFactory : IFactory<Processor, ProcessorParams>
{
    public Processor Create(ProcessorParams parameters)
    {
        if (parameters is null || parameters.Model is null || parameters.Socket is null || parameters.AvailableFrequencyMemory is null)
            throw new AggregateException("parameters cant be null");
        return new Processor(parameters.Model, parameters.Frequency, parameters.CountCore,  parameters.Socket, parameters.IsBuiltVideoCore, parameters.AvailableFrequencyMemory, parameters.TDP, parameters.Power);
    }
}