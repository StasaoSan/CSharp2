using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models.AbstractFactory;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.GPU;

public class GPUFactory : IFactory<GPU, GPUParams>
{
   public GPU Create(GPUParams parameters)
   {
       if (parameters is null)
           throw new AggregateException("parameters cant be null");
       return new GPU(parameters.Dimentions, parameters.VideoMemory, parameters.PCIVersion, parameters.ChipFrequency, parameters.PowerConsumption);
   }
}