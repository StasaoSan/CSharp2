using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.AbstractFactory;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PCFrame;

public class PCFrameFactory : IFactory<PCFrame, PCFrameParams>
{
    public PCFrame Create(PCFrameParams parameters)
    {
        if (parameters is null || parameters.SupportedMotherboardFormFactors is null)
            throw new AggregateException("parameters cant be null");
        return new PCFrame(parameters.MaxGraphicsCardSize, parameters.SupportedMotherboardFormFactors, parameters.Dimensions);
    }
}