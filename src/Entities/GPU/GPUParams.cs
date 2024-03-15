using Itmo.ObjectOrientedProgramming.Lab2.Entities.GraphicsAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCIVershions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.GPU;

public class GPUParams
{
    public DimentionsGPU Dimentions { get; }
    public double VideoMemory { get; }
    public PCIVershion PCIVersion { get; }
    public double ChipFrequency { get; }
    public int PowerConsumption { get; }
}