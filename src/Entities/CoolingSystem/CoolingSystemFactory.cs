using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.AbstractFactory;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystem;

public class CoolingSystemFactory : IFactory<CoolingSystem, CoolingSystemParams>
{
    public CoolingSystem Create(CoolingSystemParams parameters)
    {
        if (parameters is null || parameters.SupportedSockets is null)
            throw new AggregateException("parameters cant be null");
        return new CoolingSystem(parameters.Dimensions, parameters.Tdp, parameters.SupportedSockets);
    }
}