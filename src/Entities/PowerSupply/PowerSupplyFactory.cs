using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.AbstractFactory;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PowerSupply;

public class PowerSupplyFactory : IFactory<PowerSupply, PowerSupplyParams>
{
    public PowerSupply Create(PowerSupplyParams parameters)
    {
        if (parameters is null)
            throw new AggregateException("parameters cant be null");
        return new PowerSupply(parameters.PeakLoad);
    }
}