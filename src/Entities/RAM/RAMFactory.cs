using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.AbstractFactory;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.RAM;

public class RAMFactory : IFactory<Ram, RAMParams>
{
    public Ram Create(RAMParams parameters)
    {
        if (parameters is null || parameters.SupportedFrequencies is null || parameters.XMPProfiles is null)
            throw new AggregateException("Parameters cant be null");
        return new Ram(parameters.CapacityGb, parameters.SupportedFrequencies, parameters.XMPProfiles, parameters.FormFactor, parameters.DDRType, parameters.PowerConsumption);
    }
}