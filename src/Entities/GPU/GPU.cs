using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GraphicsAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCIVershions;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.GPU;

public class GPU : IComponent, ICloneable
{
    public GPU(DimentionsGPU dimensions, double videoMemory, PCIVershion pciVersion, double chipFrequency, int powerConsumption)
    {
        Id = Guid.NewGuid();
        Dimentions = dimensions;
        VideoMemory = videoMemory;
        PCIVersion = pciVersion;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
    }

    public Guid Id { get; }
    public DimentionsGPU Dimentions { get; }
    public double VideoMemory { get; }
    public PCIVershion PCIVersion { get; }
    public double ChipFrequency { get; }
    public int PowerConsumption { get; }

    public object Clone()
    {
        return new GPU(Dimentions, VideoMemory, PCIVersion, ChipFrequency, PowerConsumption);
    }
}