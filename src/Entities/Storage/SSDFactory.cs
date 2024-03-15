using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.AbstractFactory;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Storage;

public class SSDFactory : IFactory<SSD, SSDParams>
{
    public SSD Create(SSDParams parameters)
    {
        if (parameters is null)
            throw new ArgumentException("parameters cant be null");
        return new SSD(parameters.Connection, parameters.Capacity, parameters.PowerConsumption, parameters.MaxSpeed);
    }
}