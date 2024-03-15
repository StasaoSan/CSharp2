using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.AbstractFactory;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboard;

public class MotherboardFactory : IFactory<Motherboard, MotherboardParams>
{
    public Motherboard Create(MotherboardParams parameters)
    {
        if (parameters is null || parameters.ProcessorSocket is null || parameters.Chipset is null || parameters.BIOS is null)
            throw new AggregateException("parameters cant be null");
        return new Motherboard(parameters.ProcessorSocket, parameters.CountPCI, parameters.CountSata, parameters.TypeDDR, parameters.Chipset, parameters.CountSlotRam, parameters.FormFactor, parameters.BIOS);
    }
}