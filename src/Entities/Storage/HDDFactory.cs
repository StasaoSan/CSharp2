using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.AbstractFactory;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Storage;

public class HDDFactory : IFactory<HDD, HDDParams>
{
    public HDD Create(HDDParams parameters)
    {
        if (parameters is null)
            throw new ArgumentException("parameters cant be null");
        return new HDD(parameters.Connection, parameters.Capacity, parameters.SpinSpeed, parameters.PowerConsumption);
    }
}