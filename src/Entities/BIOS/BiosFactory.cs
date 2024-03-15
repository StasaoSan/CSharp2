using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.AbstractFactory;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.BIOS;

public class BiosFactory : IFactory<Bios, BiosParams>
{
    public Bios Create(BiosParams parameters)
    {
        if (parameters is null || parameters.Version is null || parameters.AvailableProcessors is null)
            throw new AggregateException("parameters cant be null");
        return new Bios(parameters.Version, parameters.TypeBios, parameters.AvailableProcessors);
    }
}