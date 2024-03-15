using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GraphicsAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PCIVershions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.GPU;

public class GPUBuilder
{
    private DimentionsGPU? _dimensions;
    private double _videoMemory;
    private PCIVershion _pciVersion;
    private double _chipFrequency;
    private int _powerConsumption;

    public GPUBuilder WithDimensions(DimentionsGPU dimensions)
    {
        _dimensions = dimensions;
        return this;
    }

    public GPUBuilder WithVideoMemory(double videoMemory)
    {
        _videoMemory = videoMemory;
        return this;
    }

    public GPUBuilder WithPCIVersion(PCIVershion pciVersion)
    {
        _pciVersion = pciVersion;
        return this;
    }

    public GPUBuilder WithChipFrequency(double chipFrequency)
    {
        _chipFrequency = chipFrequency;
        return this;
    }

    public GPUBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public GPU Build()
    {
        if (!_dimensions.HasValue)
            throw new InvalidOperationException("Dimensions must be specified.");

        return new GPU(_dimensions.Value, _videoMemory, _pciVersion, _chipFrequency, _powerConsumption);
    }
}